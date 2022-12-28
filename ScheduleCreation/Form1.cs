using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static ScheduleExt;

namespace ScheduleCreation {
	public partial class Form1 : PositionRememberForm<Form1> {

		ScheduleContext context;

		public Form1() {
			InitializeComponent();

			var today = DateTime.Now;

			var timeTable = new IntRange[] {
				new IntRange(timeToMinuteOfDay( 8, 30), timeToMinuteOfDay(10, 00)),
				new IntRange(timeToMinuteOfDay(10, 20), timeToMinuteOfDay(11, 50)),
				new IntRange(timeToMinuteOfDay(12, 10), timeToMinuteOfDay(13, 40)),
				new IntRange(timeToMinuteOfDay(14, 00), timeToMinuteOfDay(15, 30)),
				new IntRange(timeToMinuteOfDay(15, 50), timeToMinuteOfDay(17, 20)),
				new IntRange(timeToMinuteOfDay(17, 40), timeToMinuteOfDay(19, 10))
			};
			var l = timeTable.Length;

			context = new ScheduleContext();
			context.schedule = new Schedule(
				new Weeks(today.Day, today.Month, today.Year, new bool[]{false, true}),
				new List<ScheduleExt.Day> { newDay(l), newDay(l), newDay(l), newDay(l), newDay(l), newDay(l), newDay(l) },
				new List<IntRange[]>{ timeTable },
				new List<Lesson>(),
				new int[] { 0, 1, 2, 3, 4, 5, 6 }
			);

			updateScheduleContext();
		}

		private ScheduleExt.Day newDay(int l) {
			return new ScheduleExt.Day(0, new int[][]{ 
				new int[l], new int[l], new int[l], new int[l]
			});
		}

		private void updateScheduleContext() {
			var schedule = context.schedule;
			var timesUsage = context.timesUsage;
			var daysUsage = context.daysUsage;
			var lessonsUsage = context.lessonsUsage;

			var date = schedule.weeksDescription;
			startDate.Value = new DateTime(date.year, date.month, date.day);

			{
				var sb = new StringBuilder(schedule.weeksDescription.weeks.Length);
				foreach(var it in schedule.weeksDescription.weeks) sb.Append(it ? 'з' : 'ч');
				weeksText.Text = sb.ToString();
			}

			timesUsage.Clear();
			for(int i = 0; i < schedule.times.Count; i++) timesUsage.Add(0);

			for(int i = 0; i < context.schedule.days.Count; i++) {
				var timeIndex = context.schedule.days[i].timeIndex;
				if(timeIndex != -1) timesUsage[timeIndex]++;
			}

			lessonsUsage.Clear();
			for(int i = 0; i < schedule.lessons.Count; i++) lessonsUsage.Add(0);

			foreach(var day in context.schedule.days) 
			foreach(var lessonG in day.lessons) {
				for(int i = 0; i < lessonG.Length; i++) { 
					if(lessonG[i] > 0) lessonsUsage[lessonG[i]-1]++;
				}
			}

			daysUsage.Clear();
			for(int i = 0; i < context.schedule.days.Count; i++) daysUsage.Add(0);

			for(int i = 0; i < schedule.daysInWeek.Length; i++) {
				var dayIndex = schedule.daysInWeek[i];
				if(dayIndex >= 0) daysUsage[dayIndex]++;
			}

			updateDays();
		}

		private void updateDays() {
			var schedule = context.schedule;
			var timesUsage = context.timesUsage;

			daysTable.SuspendLayout();

			Display.clearTable(daysTable);

			for(int i = 0; i < schedule.daysInWeek.Length; i++) {
				daysTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

				var n = new Label();
				Display.setFont(n);
				n.Font = new Font(n.Font, FontStyle.Underline);
				n.Anchor = AnchorStyles.Left | AnchorStyles.Right;
				n.Text = dayNames[i] + ": ";
				int j = i;
				var dayIndex = schedule.daysInWeek[j];
				n.Click += (a, b) => {
					var form = new DaySelectForm(context, dayIndex);
					if(form.ShowDialog2() == DialogResult.OK) {
						schedule.daysInWeek[j] = form.SelectedDay;
						updateScheduleContext();
					}
				};

				daysTable.Controls.Add(n, 0, i);

				var l = new Label();
				Display.setFont(l);
				l.Anchor = AnchorStyles.Left | AnchorStyles.Right;
				l.Text = schedule.daysInWeek[i] == -1 ? "Не назначен"
					: Display.dayToStringSmall(
						schedule, context.schedule.days[dayIndex], 
						dayIndex, context.daysUsage[dayIndex]
					);

				daysTable.Controls.Add(l, 1, i);
			}

			Display.updateTableCounts(daysTable);

			daysTable.ResumeLayout(false);
			daysTable.PerformLayout();
		}

		private void button2_Click(object sender, EventArgs e) {
			new DaySelectForm(context, -1).ShowDialog2();
			updateScheduleContext();
		}

		private void button3_Click(object sender, EventArgs e) {
			new LessonSelectForm(context, 0).ShowDialog2();
			updateScheduleContext();
		}

		private void button4_Click(object sender, EventArgs e) {
			new TimeForm(context, 0).ShowDialog2();
			updateScheduleContext();
		}

		private void button5_Click(object sender, EventArgs e) {
			openFileDialog1.Filter = "schedule file | *.scd";
			if(openFileDialog1.ShowDialog() == DialogResult.OK) {
				try { 
					var str = System.IO.File.ReadAllText(openFileDialog1.FileName);
					var newContext = new ScheduleContext();
					newContext.schedule = parseSchedule(str);
					context = newContext;
					statusLabel.Text = "";
					updateScheduleContext();
				} catch(Exception ex) {
					statusLabel.Text = ex.ToString();
				}
			}
		}

		private void button1_Click(object sender, EventArgs _) {
			try {
				var str = ScheduleExt.scheduleToString(context.schedule);

				saveFileDialog1.Filter = "schedule file | *.scd";
				if(saveFileDialog1.ShowDialog() == DialogResult.OK) {
					System.IO.File.WriteAllText(saveFileDialog1.FileName, str);
					statusLabel.Text = "Сохранено успешно";
				}
				else statusLabel.Text = "Сохранение отменено";
			}
			catch(Exception e) {
				statusLabel.Text = e.ToString();
			}
		}

		private void startDate_ValueChanged(object sender, EventArgs e) {
			var date = startDate.Value;
			var wd = context.schedule.weeksDescription;
			wd.day = date.Day;
			wd.month = date.Month;
			wd.year = date.Year;
			updateScheduleContext();
		}

		private void weeksText_KeyUp(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.Enter) try{
				var str = weeksText.Text;
				var weeks = new bool[str.Length];
				for(int i = 0; i < str.Length; i++) {
					var c = str[i];
					if(c == 'ч') weeks[i] = true;
					else if(c == 'з') weeks[i] = true;
					else throw new Exception("Неправильный символ `" + c + "` в строке недель на позиции "
						+ i + ". Можно использоваать только `ч` для числителя и `з` для знаменателя");
				}
				var wd = context.schedule.weeksDescription;
				wd.weeks = weeks;
				updateScheduleContext();
				statusLabel.Text = "";
			}
			catch(Exception ex) {
				statusLabel.Text = ex.ToString();
			}
		}

		private void button6_Click(object sender, EventArgs _) {
			try {
				var sc = context.schedule;

				var cDays = new List<ScheduleExt.Day>();
				var cTimes = new List<IntRange[]>();
				var cLessons = new List<Lesson>();
				var cDaysInWeek = new int[sc.daysInWeek.Length];

				for(var i = 0; i < sc.daysInWeek.Length; i++) {
					var dayIndex = sc.daysInWeek[i];
					if(dayIndex >= 0) {
						var day = sc.days[dayIndex];
						dayIndex  = cDays.IndexOf(day);
						if(dayIndex < 0) {
							dayIndex = cDays.Count;
							cDays.Add((ScheduleExt.Day) day.Clone());
						}
					}
					cDaysInWeek[i] = dayIndex;
				}

				for(var i = 0; i < cDays.Count; i++) {
					var day = cDays[i];

					for(int j = 0; j < day.lessons.Length; j++)
					for(int k = 0; k < day.lessons[j].Length; k++) {
						var lessonIndex = day.lessons[j][k];
						if(lessonIndex > 0) {
							var lesson = sc.lessons[lessonIndex - 1];
							var cLessonIndex = cLessons.IndexOf(lesson);
							if(cLessonIndex == -1) {
								cLessonIndex = cLessons.Count;
								cLessons.Add(lesson);
							}
							day.lessons[j][k] = cLessonIndex + 1;
						}
					}

					if(day.timeIndex >= 0) {
						var time = sc.times[day.timeIndex];
						var cTimeIndex = cTimes.IndexOf(time);
						if(cTimeIndex == -1) {
							cTimeIndex = cTimes.Count;
							cTimes.Add(time);
						}
						day.timeIndex = cTimeIndex;
					}
				}

				/*var cDays0 = new Dictionary<int, ScheduleExt.Day>();
				var cTimes0 = new Dictionary<int, IntRange[]>();
				var cLessons0 = new Dictionary<int, Lesson>();

				for(int i = 0; i < sc.days.Count; i++) if(context.daysUsage[i] > 0) cDays0.Add(i, sc.days[i]);
				for(int i = 0; i < sc.lessons.Count; i++) if(context.lessonsUsage[i] > 0) cLessons0.Add(i, sc.lessons[i]);
				for(int i = 0; i < sc.times.Count; i++) if(context.timesUsage[i] > 0) cTimes0.Add(i, sc.times[i]);
				
				foreach(var day in cDays0.Values) {
					if()
				}*/

				var cSchedule = new Schedule(
					sc.weeksDescription,
					cDays, cTimes, cLessons, cDaysInWeek
				);

				var str = scheduleToString(cSchedule);

				saveFileDialog1.Filter = "schedule file | *.scd";
				if(saveFileDialog1.ShowDialog() == DialogResult.OK) {
					System.IO.File.WriteAllText(saveFileDialog1.FileName, str);
					statusLabel.Text = "Сохранено успешно";
				}
				else statusLabel.Text = "Сохранение отменено";
			}
			catch(Exception e) {
				statusLabel.Text = e.ToString();
			}
		}
	}
}
