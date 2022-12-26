using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleRendering {
static class ParseInput {

public static string minuteOfDayToString(int mod) {
    return (mod/60).ToString() + ":" + (mod%60).ToString("00");
}

static int toInt(this bool it) {
	return it ? 1 : 0;
}

public static IntRange calculateNozeropaddingRange(this int[] it) {
    var first = it.Length;
    var last = -1;

    for(int i = 0; i < it.Length; i++) {
        if(it[i] != 0) {
            first = Math.Min(first, i);
            last  = Math.Max(last, i);
        }
    }
    return new IntRange(first, last);
}

public static string Substring2(this string it, int start, int endExc) {
	return it.Substring(start, endExc - start);
}

public static int min2(int f, params int[] os) {
	var it = f;
	foreach(var o in os) it = Math.Min(it, o);
	return it;
}

public static int max2(int f, params int[] os) {
	var it = f;
	foreach(var o in os) it = Math.Max(it, o);
	return it;
}

public class Lesson{
    public string type;
    public string loc;
    public string name;
    public string extra;

	public Lesson(
		string type, string loc,
		string name, string extra
	) {
		this.type  = type;
		this.loc   = loc;
		this.name  = name;
		this.extra = extra;
	}
}

public class IntRange {
	public int first, last;

	public IntRange(
		int first, int last
	) {
		this.first = first;
		this.last = last;
	}

	public int Size { get { return last + 1 - first; } }

	public IEnumerator<int> GetEnumerator() {
		return new RangeEnumerator(first, last);
	}

	private class RangeEnumerator : IEnumerator<int> {
		private int f, l;

		private int cur;

		public RangeEnumerator(int f, int l) {
			cur = f-1;
			this.f = f;
			this.l = l;
		}

		public int Current {
			get{
				if(cur < f) throw new InvalidOperationException();
				else return cur;
			}
		}

		object IEnumerator.Current => Current;

		void IDisposable.Dispose() {
			
		}

		bool IEnumerator.MoveNext() {
			if(cur >= l) return false;
			cur++;
			return true;
		}

		void IEnumerator.Reset() {
			cur = f-1;
		}
	}
}

//(group << 1) | числитель/знаменатель
public class Day {
	public Lesson[] lessonsUsed;
	public IntRange[] time;
	public int[][] lessons;

	public Day(
		Lesson[] lessonsUsed,
		IntRange[] time,
		int[][] lessons
	) {
		this.lessonsUsed = lessonsUsed;
		this.time		 = time;
		this.lessons	 = lessons;
	}


	public int[] getForGroupAndWeek(bool group, bool week) {
	    return lessons[(week.toInt() << 1) | group.toInt()];
	}

    public static Day emptyDay;

	static Day() {
		var lesson = new int[0];
		emptyDay = new Day(
			new Lesson[0], new IntRange[0],
			new int[][]{ lesson, lesson, lesson, lesson }
		);
	}
}

public class Weeks {
	public int day, month, year;
	public bool[] weeks;

	public Weeks(
		int day, int month, int year,
		bool[] weeks
	) {
		this.day	= day;
		this.month = month;
		this.year	= year;
		this.weeks	= weeks;
	}
}

public class StringView {
	public string source;
	public int begin, end;

	public StringView(
		string source,
		int begin, int end
	) {
		this.source = source;
		this.begin = begin;
		this.end = end;
	    if(!isEmpty() && (
			   (begin < 0 || begin > source.Length)
			|| (end   < 0 || end   > source.Length)
	        || end < begin
		)) throw new IndexOutOfRangeException($"begin=${begin} end=${end} source length=${source.Length}");
	}

	public string get() { return source.Substring2(begin, end); }

	public bool isEmpty() { return begin == end; }
}

static StringView parseNextValue(this StringView it) {
	var i = it.begin;
	while(it.source[i] != ',') i++;
	return new StringView(it.source, it.begin, i);
}

static int toInt(this StringView it) {
	var str = it.get();
    try {
        return int.Parse(str.Trim());
    }
    catch (FormatException e) {
        
        var begin2 = Math.Max(it.begin-3, 0);
        var end2   = Math.Min(it.end  +3, it.source.Length);

        var f = it.source.Substring2(begin2, it.begin);
        var s = it.source.Substring2(it.begin, it.end);
        var t = it.source.Substring2(it.end, end2);
        
        (var lineIndex, var charIndex) = countPos(it.source, it.begin);

        throw new Exception(
			$"Error parsing int in [${it.begin};${it.end}> at line ${lineIndex}, " +
            $"position ${charIndex}: ...${f}`${s}`${t}...", e
		);
	}
}

static (int, int) countPos(string source, int pos) {
    var lineIndex = 1;
    var charIndex = 0;

    for(var i = 0; i < pos; i++) {
        if(source[i] == '\n') {
            charIndex = 0;
            lineIndex++;
        }
        else charIndex++;
    }

    return (lineIndex, charIndex);
}

static StringView parseRawString(this StringView it) {
    var lengthS = it.parseNextValue();
    var length = lengthS.toInt();
    return new StringView(it.source, lengthS.end+1, lengthS.end+1 + length);
}

static (StringView, Lesson) parseLesson(this StringView it) {
    var type  = new StringView(it.source, it.begin  , it.end).parseRawString();
    var loc   = new StringView(it.source, type.end+1, it.end).parseRawString();
    var name  = new StringView(it.source, loc.end+1 , it.end).parseRawString();
    var extra = new StringView(it.source, name.end+1, it.end).parseRawString();

    return (
        new StringView(it.source, it.begin, extra.end),
        new Lesson(
            type.get(),
            loc.get(),
            name.get(),
            extra.get()
        )
    );
}

static (StringView, int[][]) parseLessonIndices(this StringView it, int count) {
    var curBegin = it.begin;
    var array = new int[4][];
	for(int i = 0; i < 4; i++) {
        array[i] = new int[count];
		for(int j = 0; j < count; j++) {
            var indexS = new StringView(it.source, curBegin+1, it.end).parseNextValue();
            var index = indexS.toInt();
            curBegin = indexS.end;
            array[i][j] = index;
        }
    }

    return (new StringView(it.source, it.begin, curBegin), array);
}

static (StringView, IntRange[]) parseTime(this StringView it) {
    var curBegin = it.begin;
    var timeCountS = new StringView(it.source, curBegin+1, it.end).parseNextValue();
    var timeCount = timeCountS.toInt();
    curBegin = timeCountS.end;
    var time = new IntRange[timeCount];
	for(int i = 0; i < timeCount; i++) {
        var startHourS = new StringView(it.source, curBegin+1, it.end).parseNextValue();
        var startHour = startHourS.toInt();
        curBegin = startHourS.end;

        var startMinuteS = new StringView(it.source, curBegin+1, it.end).parseNextValue();
        var startMinute = startMinuteS.toInt();
        curBegin = startMinuteS.end;

        var endHourS = new StringView(it.source, curBegin+1, it.end).parseNextValue();
        var endHour = endHourS.toInt();
        curBegin = endHourS.end;

        var endMinuteS = new StringView(it.source, curBegin+1, it.end).parseNextValue();
        var endMinute = endMinuteS.toInt();
        curBegin = endMinuteS.end;

        time[i] = new IntRange(
            startHour * 60 + startMinute,
            endHour * 60 + endMinute
        );
    }

    return (new StringView(it.source, it.begin, curBegin), time);
}

static (StringView, Day) parseDay(this StringView it) {
    var lessonsCountS = new StringView(it.source, it.begin, it.end).parseNextValue();
    var curBegin = lessonsCountS.end;
    var lessonsCount = lessonsCountS.toInt();
    if(lessonsCount == 0) return (lessonsCountS, Day.emptyDay);
    var lessonsUsed = new Lesson[lessonsCount];
	for(int i = 0; i < lessonsCount; i++) {
        var pair = new StringView(it.source, curBegin+1, it.end).parseLesson();
        curBegin = pair.Item1.end;
        lessonsUsed[i] = pair.Item2;
    }

    var pair1 = new StringView(it.source, curBegin, it.end).parseTime();
    curBegin = pair1.Item1.end;
	var time = pair1.Item2;

    var pair2 = new StringView(it.source, curBegin, it.end).parseLessonIndices(time.Length);
    curBegin = pair2.Item1.end;
    var lessons = pair2.Item2;

    return (
        new StringView(it.source, it.begin, curBegin),
        new Day(lessonsUsed, time, lessons)
    );
}

static (StringView, Weeks) parseWeeks(this StringView it) {
    var day = it.parseNextValue();
    var month = new StringView(it.source, day.end+1  , it.end).parseNextValue();
    var year  = new StringView(it.source, month.end+1, it.end).parseNextValue();
    var str   = new StringView(it.source, year.end+1 , it.end).parseRawString();

	var bools = new bool[str.end - str.begin];
	for(int i = 0; i < bools.Length; i++) bools[i] = str.source[str.begin + i] != '0';

    return (
        new StringView(it.source, it.begin, str.end),
        new Weeks(
            day.toInt(),
            month.toInt(),
            year.toInt(),
            bools
        )
    );
}

public class Schedule{
	public Weeks weeksDescription;
	public Day[] week;

	public Schedule(
		Weeks weeksDescription,
		Day[] week
	) {
		this.weeksDescription = weeksDescription;
		this.week = week;
	}
}

public static Schedule parseSchedule(string input_) {
    string input;
	if(char.IsDigit(input_[0]) || char.IsWhiteSpace(input_[0]))
        input = input_;
    else {
        var firstSpace = -1;
		for(int i = 0; i < input_.Length; i++) {
			if(char.IsWhiteSpace(input_[i])) {
				firstSpace = i;
				break;
			}
		}

        if(firstSpace == -1) throw new Exception("No comment symbol defined");
        var comment = input_.Substring2(0, firstSpace);

        var commentSb = new StringBuilder();
        string commentRepl;
		{
            foreach(var c in comment) {
                if(c == '\n') commentSb.Append('\n');
                else commentSb.Append(' ');
            }
            commentRepl = commentSb.ToString();
        }

        var inComment = true;
        var thisCommentEnd = firstSpace;
        var sb = new StringBuilder();

        sb.Append(commentRepl);

        while(true) {
            var nextCommentStart = input_.IndexOf(comment, thisCommentEnd);
            if(!inComment) {
                var end = (nextCommentStart == -1) ? input_.Length : nextCommentStart;
                sb.Append(input_.Substring2(thisCommentEnd, end));
                sb.Append(commentRepl);
                if(nextCommentStart == -1) break;
            }
            else {
                if (nextCommentStart == -1) {
                    (var line, var ch) = countPos(input_, thisCommentEnd);
                    throw new Exception(
                        "Comment block `$comment` at $line:$char must be closed before EOF"
                    );
                }

                commentSb.Clear();
                foreach(var c in input_.Substring2(thisCommentEnd, nextCommentStart)) {
                    if(c == '\n') commentSb.Append('\n');
                    else commentSb.Append(' ');
                }
                sb.Append(commentSb.ToString());
                sb.Append(commentRepl);
            }
            thisCommentEnd = nextCommentStart + comment.Length;
            inComment = !inComment;
        }

        input = sb.ToString();
    }

    var begin = 0;

    var versionS = new StringView(input, begin, input.Length).parseNextValue();
    begin = versionS.end + 1;
    var version = versionS.toInt();

    if(version == 0) {
        var week = new List<Day>();

        for (int i = 0; i < 7; i++) {
            var pair0 = new StringView(input, begin, input.Length).parseDay();
            begin = pair0.Item1.end + 1;
            week.Add(pair0.Item2);
        }
		
        var sv = new StringView(input, begin, input.Length);
        var pair = sv.parseWeeks();
        begin = pair.Item1.end + 1;
        var weeks = pair.Item2;

        return new Schedule(weeks, week.ToArray());
    }
    else if(version == 1) {
        var lessonsCountS = new StringView(input, begin, input.Length).parseNextValue();
        begin = lessonsCountS.end + 1;
        var lessonsCount = lessonsCountS.toInt();
        var lessonsUsed = new Lesson[lessonsCount];
		for(int i = 0; i < lessonsCount; i++) {
            var pair = new StringView(input, begin, input.Length).parseLesson();
            begin = pair.Item1.end + 1;
            lessonsUsed[i] = pair.Item2;
        }

        var timeCountS = new StringView(input, begin, input.Length).parseNextValue();
        begin = timeCountS.end + 1;
        var timeCount = timeCountS.toInt();
        var timeUsed = new IntRange[timeCount][];
		for(int i = 0; i < timeCount; i++) {
            var pair = new StringView(input, begin, input.Length).parseTime();
            begin = pair.Item1.end + 1;
            timeUsed[i] = pair.Item2;
        }

        var dayCountS = new StringView(input, begin, input.Length).parseNextValue();
        begin = dayCountS.end + 1;
        var dayCount = dayCountS.toInt();
        var dayUsed = new Day[dayCount]; 
		for(int i = 0; i < dayCount; i++) {
            var timeIndexS = new StringView(input, begin, input.Length).parseNextValue();
            begin = timeIndexS.end + 1;
            var timeIndex = timeIndexS.toInt();

            var time = timeUsed[timeIndex];

            var pair = new StringView(input, begin, input.Length).parseLessonIndices(time.Length);
            begin = pair.Item1.end + 1;
            dayUsed[i] = new Day(
                lessonsUsed,
                time,
                pair.Item2
            );
        }

        var days = new int[7];
		for(int i = 0; i < 7; i++) {
            var dayS = new StringView(input, begin, input.Length).parseNextValue();
            begin = dayS.end + 1;
            var day = dayS.toInt();
            days[i] = day;
        }

        var sv = new StringView(input, begin, input.Length);
        var pair0 = sv.parseWeeks();
        begin = pair0.Item1.end + 1;
        var weeks = pair0.Item2;

        Day getDayUsed(int index) {
			if(index == 0) return Day.emptyDay;
			else return dayUsed[index-1];
		}

        return new Schedule(
            weeks,
            new[]{
				getDayUsed(days[0]), getDayUsed(days[1]),
				getDayUsed(days[2]), getDayUsed(days[3]),
				getDayUsed(days[4]), getDayUsed(days[5]),
				getDayUsed(days[6]), 
			}
        );
    }
    else throw new Exception($"unknown version=${version}");
}

}
}
