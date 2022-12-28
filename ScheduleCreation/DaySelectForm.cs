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
	public partial class DaySelectForm : PositionRememberForm<DaySelectForm> {
		ScheduleContext context;

		int selectedDay;

		public int SelectedDay{ get{ return selectedDay; } }

		public DaySelectForm(ScheduleContext context, int selectedDay) {
			this.context = context;
			this.selectedDay = selectedDay;

			InitializeComponent();

			update();
		}

		private void update() {
			updateDaysTable();
			updatePreview();
		}

		private void updateDaysTable() {
			daysTable.SuspendLayout();
			Display.clearTable(daysTable);
			daysTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
			daysTable.ColumnCount = 1;

			for(int i = 0; i < context.schedule.days.Count; i++) {
				daysTable.RowStyles.Add(new ColumnStyle(SizeType.AutoSize));
				var l = new Label{ 
					Text = Display.dayToStringSmall(
						context.schedule, 
						context.schedule.days[i], i, 
						context.daysUsage[i]
					),
					Anchor = Display.AllAnchors,
					TextAlign = ContentAlignment.MiddleLeft,
				};
				int j = i;
				l.Click += (a, b) => {
					selectedDay = j;
					update();
				};
				if(i == selectedDay) l.BackColor = Color.FromArgb(20, 0, 0, 0);
				daysTable.Controls.Add(l);
			}
			daysTable.RowStyles.Add(new ColumnStyle(SizeType.Percent, 1));
			daysTable.RowCount = daysTable.RowStyles.Count;

			daysTable.ResumeLayout(false);
			daysTable.PerformLayout();
		}

		private void updatePreview() {
			dayPreviewTable.SuspendLayout();

			Display.clearTable(dayPreviewTable);
			dayPreviewTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
			dayPreviewTable.RowStyles.Add(new ColumnStyle(SizeType.AutoSize));

			if(selectedDay < 0) {
				dayPreviewTable.Controls.Add(new Label{ Text = "Не выбран", Anchor = AnchorStyles.None });
			}
			else {
				var t = new TableLayoutPanel();
				dayPreviewTable.Controls.Add(t, 0, 0);
				Display.fillPreviewTable(t, context.schedule, context.schedule.days[selectedDay]);
			}

			Display.updateTableCounts(dayPreviewTable);

			dayPreviewTable.ResumeLayout(false);
			dayPreviewTable.PerformLayout();
		}

		private void selectB_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}

		private void editB_Click(object sender, EventArgs e) {
			var form = new DayEditForm(context, context.schedule.days[selectedDay]);
			form.ShowDialog2();
			update();
		}

		private void deleteB_Click(object sender, EventArgs e) {
			if(selectedDay == -1) return;
			for(int i = 0; i < context.schedule.daysInWeek.Length; i++) {
				if(context.schedule.daysInWeek[i] == selectedDay) context.schedule.daysInWeek[i] = -1;
				else if(context.schedule.daysInWeek[i] > selectedDay) context.schedule.daysInWeek[i] -= 1;
			}
			context.schedule.days.RemoveAt(selectedDay);
			context.daysUsage.RemoveAt(selectedDay);
			selectedDay = -1;

			update();
		}

		private void addB_Click(object sender, EventArgs e) {
			var lesson = new int[0];
			var newDay = new ScheduleExt.Day(-1, new int[][]{ lesson, lesson, lesson, lesson });
			var newDayIndex = context.schedule.days.Count;
			context.schedule.days.Add(newDay);
			context.daysUsage.Add(0);
			selectedDay = newDayIndex;
			update();
		}

		private void button1_Click(object sender, EventArgs e) {
			selectedDay = -1;
			DialogResult = DialogResult.OK;
		}
	}
}
