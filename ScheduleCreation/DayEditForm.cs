using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScheduleCreation {
	public partial class DayEditForm : Form {

		public ScheduleExt.Day day;

		ScheduleContext context;
		public DayEditForm(ScheduleContext context, ScheduleExt.Day day) {
			this.context = context;
			this.day = day;

			InitializeComponent();

			updateDisplay();
		}

		private void label1_Click(object sender, EventArgs e) {
			var form = new TimeForm(context, day.timeIndex);
			if(form.ShowDialog() == DialogResult.OK) {
				day.timeIndex = form.SelectedTime;
			}
			if(day.timeIndex != -1) { 
				var time = context.schedule.times[day.timeIndex];
				if(day.lessons[0].Length != time.Length) {
					var newLessons = new int[4][];
					for(int i = 0; i < 4; i++) {
						newLessons[i] = new int[time.Length];
						for(int j = 0; j < Math.Min(time.Length, day.lessons[0].Length); j++) 
							newLessons[i][j] = day.lessons[i][j];
					}
					day.lessons = newLessons;
				}
			}
			updateDisplay();
		}

		private void updateDisplay() {
			timeLabel.Text = Display.timeToString(day.timeIndex == -1 ? null : context.schedule.times[day.timeIndex]);

			tableLayoutPanel1.SuspendLayout();


			tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(1, 0));
			var t = new TableLayoutPanel();
			tableLayoutPanel1.Controls.Add(t, 1, 0);
			Display.fillPreviewTable(t, context.schedule, day);


			dayLessonsTable.SuspendLayout();
			Display.clearTable(dayLessonsTable);
			dayLessonsTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

			if(day.timeIndex == -1) {
				var l = new Label{ Text = "Выберите расписание занятий" };
				dayLessonsTable.Controls.Add(l);
			}
			else {
				dayLessonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
				dayLessonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1));
				dayLessonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1));

				var time = context.schedule.times[day.timeIndex];
				for(int i = 0; i < time.Length; i++) {
					dayLessonsTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
					dayLessonsTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

					var timeL = new Label();
					timeL.AutoSize = true;
					Display.setFont(timeL);
					timeL.Margin = new Padding();
					timeL.Anchor = Display.AllAnchors;
					timeL.TextAlign = ContentAlignment.MiddleCenter;
					timeL.Text = ScheduleExt.minuteOfDayToString(time[i].first)
						+ "\n-\n" + ScheduleExt.minuteOfDayToString(time[i].last);

					dayLessonsTable.Controls.Add(timeL, 0, i*2);
					dayLessonsTable.SetRowSpan(timeL, 2);

					for(int group = 0; group < 2; group++)
					for(int week = 0; week < 2; week++) { 
						var lessonsIndices = day.getForGroupAndWeek(group == 1, week == 1);
						var lessonIndex = lessonsIndices[i];

						var l = new Label();
						timeL.AutoSize = true;
						Display.setFont(l);
						l.Font = new Font(l.Font, FontStyle.Underline);
						l.Anchor = Display.AllAnchors;
						l.TextAlign = ContentAlignment.MiddleCenter;
						int j = i;
						l.Click += (a, b) => {
							var form = new SelectLessonForm(context, lessonIndex);
							if(form.ShowDialog() == DialogResult.OK) {
								lessonsIndices[j] = form.SelectedLesson;
								updateDisplay();
							}
						};

						if(lessonIndex <= 0) {
							l.TextAlign = ContentAlignment.TopLeft;
							l.Text = "Окно (" + lessonIndex + ")";
						}
						else { 
							var lesson = context.schedule.lessons[lessonIndex - 1];
							l.Text = lesson.type + " " + lesson.loc + " " + lesson.extra;
						}

						dayLessonsTable.Controls.Add(l, 1 + group, i*2 + week);
					}
				}
			}

			Display.updateTableCounts(dayLessonsTable);
			dayLessonsTable.ResumeLayout(true);
			dayLessonsTable.PerformLayout();


			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
		}
	}
}
