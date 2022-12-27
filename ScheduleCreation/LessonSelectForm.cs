using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScheduleCreation {
	public partial class LessonSelectForm : Form {
		ScheduleContext context;

		int selectedLesson;

		public int SelectedLesson{ get{ return selectedLesson; } }

		public LessonSelectForm(ScheduleContext context, int selectedLesson) {
			this.context = context;
			this.selectedLesson = selectedLesson;

			InitializeComponent();

			update();
		}

		private void selectB_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}

		private void changeB_Click(object sender, EventArgs e) {
			if(selectedLesson <= 0) return;

			var form = new LessonEditForm(context, context.schedule.lessons[selectedLesson - 1]);
			form.ShowDialog();
		}

		private void deleteB_Click(object sender, EventArgs e) {
			if(selectedLesson <= 0) return;

			foreach(var day in context.schedule.days) 
			foreach(var lessonG in day.lessons) {
				for(int i = 0; i < lessonG.Length; i++) { 
					if(lessonG[i] == selectedLesson) lessonG[i] = 0;
					else if(lessonG[i] > selectedLesson) lessonG[i] -= 1;
				}
			}
			
			context.schedule.lessons.RemoveAt(selectedLesson - 1);
			context.lessonsUsage.RemoveAt(selectedLesson - 1);
			selectedLesson = 0;
			
			update();
		}

		private void addB_Click(object sender, EventArgs e) {
			var lesson = new ScheduleExt.Lesson("", "", "", "");
			var form = new LessonEditForm(context, lesson);
			if(form.ShowDialog() == DialogResult.OK) {
				context.schedule.lessons.Add(lesson);
				context.lessonsUsage.Add(0);

				if(selectedLesson <= 0) selectedLesson = context.schedule.lessons.Count-1 + 1;
				
				update();
			}
		}

		private void update() {
			var schedule = context.schedule;
			var lessons = context.schedule.lessons;
			var lessonsUsage = context.lessonsUsage;

			selectedLessonIndexL.Text = "Номер выбранного урока: " + selectedLesson;

			lessonsTable.SuspendLayout();
			Display.clearTable(lessonsTable);

			lessonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

			for(int i = 0; i < lessons.Count; i++) {
				lessonsTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

				var lesson = lessons[i];

				var l = new Label();
				l.Anchor = AnchorStyles.Left | AnchorStyles.Right;
				Display.setFont(l);
				l.Text = lesson.type + " " + lesson.loc + " " + lesson.extra;
				var j = i;
				l.Click += (a, b) => {
					selectedLesson = j + 1;
					update();
				};
				if(i == selectedLesson - 1) l.BackColor = Color.FromArgb(20, 0, 0, 0);
				lessonsTable.Controls.Add(l, 1, i);
			}

			Display.updateTableCounts(lessonsTable);
			lessonsTable.ResumeLayout(false);
			lessonsTable.PerformLayout();
		}

		private void button1_Click(object sender, EventArgs e) {
			var form = new NoLessonSelectForm();
			if(form.ShowDialog() == DialogResult.OK) {
				selectedLesson = form.SelectedNumber;
				update();
			}
		}
	}
}
