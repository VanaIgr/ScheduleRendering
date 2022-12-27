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
	public partial class Form1 : Form {

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
				foreach(var it in schedule.weeksDescription.weeks) sb.Append(it ? '1' : '0');
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
					if(form.ShowDialog() == DialogResult.OK) {
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
			new DaySelectForm(context, -1).ShowDialog();
			updateScheduleContext();
		}

		private void button3_Click(object sender, EventArgs e) {
			new SelectLessonForm(context, 0).ShowDialog();
			updateScheduleContext();
		}

		private void button4_Click(object sender, EventArgs e) {
			new TimeForm(context, 0).ShowDialog();
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
	}
}
