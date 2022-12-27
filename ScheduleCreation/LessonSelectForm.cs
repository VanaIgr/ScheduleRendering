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
	public partial class LessonSelectForm : Form {
		ScheduleContext context;

		List<int> duplicates = new List<int>();

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

			update();
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

				selectedLesson = context.schedule.lessons.Count-1 + 1;
				
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

			duplicates.Clear();
			var set = new Dictionary<string, int>();
			for(int i = 0; i < lessons.Count; i++) {
				var lesson = context.schedule.lessons[i];
				var str = lesson.name.Trim() + lesson.type.Trim() + lesson.loc.Trim() + lesson.extra.Trim();
				if(set.ContainsKey(str)) {
					duplicates.Add(set[str]);
					duplicates.Add(i);
				}
				else set.Add(str, i);
			}

			Control selectedControl = null;

			for(int i = 0; i < lessons.Count; i++) {
				lessonsTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

				var lesson = lessons[i];

				var l = new Label();
				l.Anchor = AnchorStyles.Left | AnchorStyles.Right;
				Display.setFont(l);
				l.Text = lesson.name + " " + lesson.type + " " + lesson.loc + " " + lesson.extra;
				var j = i;
				l.Click += (a, b) => {
					selectedLesson = j + 1;
					update();
				};

				var duplicate = duplicates.Contains(i);
				var selected = i == selectedLesson - 1;

				if(selected && duplicate) l.BackColor = Color.FromArgb(30, 255/2, 10, 5);
				else if(duplicate) l.BackColor = Color.FromArgb(40, 255, 20, 10);
				else if(selected)l.BackColor = Color.FromArgb(20, 0, 0, 0);

				lessonsTable.Controls.Add(l, 1, i);

				if(selected) selectedControl = l;
			}

			Display.updateTableCounts(lessonsTable);
			lessonsTable.ResumeLayout(false);
			lessonsTable.PerformLayout();

			if(selectedControl != null) (lessonsTable.Parent as Panel)?.ScrollControlIntoView(selectedControl);
		}

		private void button1_Click(object sender, EventArgs e) {
			var form = new NoLessonSelectForm();
			if(form.ShowDialog() == DialogResult.OK) {
				selectedLesson = form.SelectedNumber;
				DialogResult = DialogResult.OK;
			}
		}

		private void cloneB_Click(object sender, EventArgs e) {
			if(selectedLesson <= 0) return;

			var lesson = (Lesson) context.schedule.lessons[selectedLesson-1].Clone();
			context.schedule.lessons.Add(lesson);
			context.lessonsUsage.Add(0);
			var oldSelected = selectedLesson;
			selectedLesson = context.schedule.lessons.Count-1 + 1;
			update();
			if(new LessonEditForm(context, lesson).ShowDialog() != DialogResult.OK) {
				context.schedule.lessons.RemoveAt(selectedLesson - 1);
				context.lessonsUsage.RemoveAt(selectedLesson - 1);
				selectedLesson = oldSelected;
			}
			update();
		}

		private void pasteFromClipboardB_Click(object sender, EventArgs e) {
			try{
				var lesson = parseStringToLesson(patchLessonString(Clipboard.GetText()));
				context.schedule.lessons.Add(lesson);
				context.lessonsUsage.Add(0);
				selectedLesson = context.schedule.lessons.Count-1 + 1;		
				update();
			}
			catch(Exception ex) {
				MessageBox.Show(
@"Не удалось вставить с клавиатуры. Строка должна иметь подобный формат: 
Технология разработки и защиты баз данных лк 229-2 Куприянов А.А.
Ошибка: " + ex.ToString());
			}
		}
	}
}
