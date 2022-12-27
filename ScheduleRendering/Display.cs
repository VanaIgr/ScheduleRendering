using ScheduleRendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static ScheduleExt;

public static class Display {

	public static AnchorStyles AllAnchors = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;

	public static void setProp(Control c, float fontSize) {
		c.Font = new Font("Segoe UI", fontSize, FontStyle.Regular, GraphicsUnit.Pixel, 0);
		c.Margin = new Padding();
	}

	private static StringBuilder sb = new StringBuilder();

	public static string dayToStringSmall(Schedule sch, ScheduleExt.Day day, int index, int useges) {
		sb.Clear();
		sb.Append("День № ").Append(index).Append(" (").Append(useges).Append(" исп.): ");
		if(day.lessons.All(it => it.All(it2 => it2 == 0))) {
			sb.Append("выходной");
			return sb.ToString();
		}
		for(int i = 0; i < day.lessons[0].Length; i++) {
			var lessonIndex = day.lessons[0][i];
			if(lessonIndex > 0) { 
				var lesson = sch.lessons[lessonIndex - 1];
				sb.Append(lesson.type).Append(' ');
				sb.Append(lesson.loc).Append(' ');
				sb.Append(lesson.extra).Append(", ");
			}
			else {
				sb.Append("Окно, ");
			}
			if(sb.Length >= 50) break;
		}
		if(sb.Length >= 50) sb.Remove(50-3, sb.Length - (50-3)).Append("...");
		return sb.ToString();
	}

	public static void clearTable(TableLayoutPanel table) {
		table.RowStyles.Clear();
		table.ColumnStyles.Clear();
		table.RowCount = 0;
		table.ColumnCount = 0;
		while(table.Controls.Count > 0) table.Controls[table.Controls.Count-1].Dispose();
		//table.Controls.Clear();
	}

	public static void addDay(
		List<Label> needResizing,
		TableLayoutPanel tl, int pad,
		int startCol, int startRow,
		Schedule schedule,
		ScheduleExt.Day curDay, int weekdayIndex,
		IntRange lessonIndicesRange,
		int maxLessonsCount, float fontSize, float? fontSize2_ = null
	) {
		var fontSize2 = fontSize2_.GetValueOrDefault(fontSize);

		var dayLabel = new VerticalLabel();
		dayLabel.AutoSize = false;
		if(weekdayIndex != -1) dayLabel.Text = dayNames[weekdayIndex];
		else if(curDay != null) dayLabel.Text = "Название д.н.";

		setProp(dayLabel, fontSize2 * 2.0f);
		dayLabel.Margin = new Padding(0, 0, pad, pad);
		dayLabel.Anchor = AllAnchors;
		
		tl.Controls.Add(dayLabel, startCol + 0, startRow);

		if(curDay == null || lessonIndicesRange.Size <= 0
			|| curDay.timeIndex < 0 || curDay.lessons == null
		) {
			var height = Math.Max(1, maxLessonsCount * 2);
			tl.SetRowSpan(dayLabel, height);
			
			Label blank = new Label();
			blank.AutoSize = true;
			blank.Anchor = AllAnchors;
			blank.BackColor = Color.White;
			blank.Margin = new Padding(0, 0, pad, pad);
			
			tl.Controls.Add(blank, startCol + 1, startRow);
			tl.SetColumnSpan(blank, 3); //colsPerDay - 2
			tl.SetRowSpan(blank, height);
			
			return;
		}

		tl.SetRowSpan(dayLabel, lessonIndicesRange.Size * 2);

        for(var lessonI = 0; lessonI < lessonIndicesRange.Size; lessonI++) {
			var i = lessonIndicesRange.first + lessonI;
			var time = schedule.times[curDay.timeIndex][i];

			int lessonAt(bool group, bool week) { 
				var it = curDay.getForGroupAndWeek(group, week);
				if (i >= 0 && i < it.Length) return it[i];
				else return 0;
			}

			var timeLabel = new Label();
			timeLabel.AutoSize = true;
			timeLabel.BackColor = Color.White;
			timeLabel.Text = minuteOfDayToString(time.first) + "\n-\n" + minuteOfDayToString(time.last);
			timeLabel.Anchor = AllAnchors;
			timeLabel.TextAlign = ContentAlignment.MiddleCenter;
			setProp(timeLabel, fontSize2);
			timeLabel.Margin = new Padding(0, 0, pad, pad);
			
			tl.Controls.Add(timeLabel, startCol + 1, startRow + lessonI * 2);
			tl.SetRowSpan(timeLabel, 2);

			Control createLesson(int lessonIndex, bool yellow) {
				if(lessonIndex <= 0) return new Label() {
					AutoSize = true,
					Anchor = AllAnchors,
					Text = "",
					BackColor = Color.White,
					Margin = new Padding(0, 0, pad, pad),
				};

				var lessonLabel = new Label();
				lessonLabel.AutoSize = true;
				lessonLabel.Anchor = AllAnchors;
				lessonLabel.TextAlign = ContentAlignment.MiddleCenter;
				setProp(lessonLabel, fontSize);

				needResizing.Add(lessonLabel);

				var lesson = schedule.lessons[lessonIndex - 1];

				var noBreakSpace = '\u00A0';
                var textSB = new StringBuilder();
                textSB.Append(lesson.name);
                void addOther(string text) {
                    if (text.Length == 0) return;
                    textSB.Append(' ');
                    var newText = text.Length < 20 ? text.Replace(' ', noBreakSpace) : text;
                    textSB.Append(newText);
                }
                addOther(lesson.type);
                addOther(lesson.loc);
                addOther(lesson.extra);

                lessonLabel.Text = textSB.ToString();

				lessonLabel.Margin = new Padding(0, 0, pad, pad);
				if(yellow) lessonLabel.BackColor = Color.Yellow;
				else lessonLabel.BackColor = Color.White;

				return lessonLabel;
			}

			var groupHorizontal = lessonAt(group: false, false) == lessonAt(group: true, false) &&
			     lessonAt(group: false, true) == lessonAt(group: true, true);
			var groupVertical = lessonAt(false, week: false) == lessonAt(false, week: true) &&
			     lessonAt(true, week: false) == lessonAt(true, week: true);

			var lessonStartCol = startCol + 2;
			var lessonStartRow = startRow + lessonI * 2;

			if(groupHorizontal && groupVertical) {
				var it1 = createLesson(lessonAt(false, false), false);
				
				tl.Controls.Add(it1, lessonStartCol, lessonStartRow);
				tl.SetColumnSpan(it1, 2);
				tl.SetRowSpan(it1, 2);
			}
			else if(!groupHorizontal && !groupVertical) {
				var it1 = createLesson(lessonAt(group: false, week: false), false);
				tl.Controls.Add(it1, lessonStartCol + 0, lessonStartRow + 0);
				
				var it2 = createLesson(lessonAt(group: true, week: false), false);
				tl.Controls.Add(it2, lessonStartCol + 1, lessonStartRow + 0);
			
				var it3 = createLesson(lessonAt(group: false, week: true), true);
				tl.Controls.Add(it3, lessonStartCol + 0, lessonStartRow + 1);
			
				var it4 = createLesson(lessonAt(group: true, week: true), true);
				tl.Controls.Add(it4, lessonStartCol + 1, lessonStartRow + 1);
			}
			else if(groupHorizontal) {
				var it1 = createLesson(lessonAt(group: false, week: false), false);
				tl.Controls.Add(it1, lessonStartCol + 0, lessonStartRow + 0);
				tl.SetColumnSpan(it1, 2);
				
			
				var it3 = createLesson(lessonAt(group: false, week: true), true);
				tl.Controls.Add(it3, lessonStartCol + 0, lessonStartRow + 1);
				tl.SetColumnSpan(it3, 2);
			}
			else {
				var it1 = createLesson(lessonAt(group: false, week: false), false);
				tl.Controls.Add(it1, lessonStartCol + 0, lessonStartRow + 0);
				tl.SetRowSpan(it1, 2);
				
				var it2 = createLesson(lessonAt(group: true, week: false), false);
				tl.Controls.Add(it2, lessonStartCol + 1, lessonStartRow + 0);
				tl.SetRowSpan(it2, 2);
			}
		}

		if(lessonIndicesRange.Size < maxLessonsCount) {
			Label blank = new Label();
			blank.AutoSize = true;
			blank.Anchor = AllAnchors;
			blank.BackColor = Color.White;
			blank.Margin = new Padding(0, 0, pad, pad);

			tl.Controls.Add(blank, startCol + 0, startRow + lessonIndicesRange.Size * 2);
			tl.SetColumnSpan(blank, 4);
			tl.SetRowSpan(blank, (maxLessonsCount - lessonIndicesRange.Size) * 2);
		}
	}

	public static string timeToString(IntRange[] time) {
		sb.Clear();
		if(time == null) {
			sb.Append("Не выбрано");
			return sb.ToString();
		}
		foreach(var it in time) {
			sb.Append(minuteOfDayToString(it.first))
				.Append('-')
				.Append(minuteOfDayToString(it.last))
				.Append(", ");
		}
		return sb.ToString();
	}

	internal static TableLayoutPanel fillPreviewTable(TableLayoutPanel t2, Schedule schedule, ScheduleExt.Day day) {
		var needResizing = new List<Label>();
		var indices = calcDayLessonIndices(day);

		t2.SuspendLayout();
		Display.clearTable(t2);
		t2.AutoSize = true;
		t2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		//t2.Anchor = Display.AllAnchors;
		t2.Margin = new Padding();
		Display.setupDaysTable(t2, 500, 1, 1);

		Display.addDay(
			needResizing, t2, 1, 0, 0, 
			schedule, day, -1, indices, indices.Size, 10
		);
		if(indices.Size <= 0) t2.RowStyles.Add(new RowStyle(SizeType.Percent, 1));
		else for(int i = 0; i < indices.Size*2; i++) {
			t2.RowStyles.Add(new RowStyle(SizeType.Percent, 1));
		}
		t2.RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
		Display.updateTableCounts(t2);

		t2.ResumeLayout(false);
		t2.PerformLayout();

		foreach(var it in needResizing) {
			//EventHandler h = null;
			//h = (a, b) => {
			//	var c = ((Label) a);
			//	if(c.Width == 1 || c.Height == 1) return;
			//	c.Resize -= h;
			//	Display.ScaleFont(c);
			//};
			//if(it.Width == 1 || it.Height == 1) it.Resize += h;
			//else
			Display.ScaleFont(it);
		}

		return t2;
	}

	internal static void setFont(Control c) {
		c.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
	}

	internal static void updateTableCounts(TableLayoutPanel table) {
		table.ColumnCount = table.ColumnStyles.Count;
		table.RowCount = table.RowStyles.Count;
	}

	public static readonly int colsPerDay = 5;

	internal static void setupDaysTable(TableLayoutPanel tl, int width, int pad, int maxDaysCols) {
		tl.MinimumSize = new Size(width, 0);
		tl.MaximumSize = new Size(width, int.MaxValue);

		tl.BackColor = Color.Black;

        tl.Padding = new Padding(pad * 2, pad * 2, 0, 0);

		tl.ColumnCount = maxDaysCols * colsPerDay;
		for(int i = 0; i < maxDaysCols; i++) { 
			tl.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0)); //day of week
			tl.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0)); //time
			tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1)); //group 1
			tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1)); //group 2
			tl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, pad)); //padding between days
		}
	}

	//https://stackoverflow.com/a/25448687/18704284
	public static void ScaleFont(Label lab) {
	    SizeF extent = TextRenderer.MeasureText(lab.Text, lab.Font);
	
	    float hRatio = lab.Height / extent.Height;
	    float wRatio = lab.Width / extent.Width;
	    float ratio = Math.Min(hRatio, wRatio) + 0.3f;
		if(ratio < 0.001) return;
		if(ratio > 100) return;
	
	    float newSize = lab.Font.Size * ratio;
	
	    lab.Font = new Font(lab.Font.FontFamily, newSize, lab.Font.Style);
	}
}
