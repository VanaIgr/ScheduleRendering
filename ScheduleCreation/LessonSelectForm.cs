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
	public partial class LessonSelectForm : PositionRememberForm<LessonSelectForm> {
		ScheduleContext context;

		HashSet<int> duplicates = new HashSet<int>();
		HashSet<int> possibleDuplicates = new HashSet<int>();

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
			form.ShowDialog2();

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
			if(form.ShowDialog2() == DialogResult.OK) {
				context.schedule.lessons.Add(lesson);
				context.lessonsUsage.Add(0);

				selectedLesson = context.schedule.lessons.Count-1 + 1;
				
				update();
			}
		}

		private struct Distance {
			public int offset, maxInRow, distance;

			public Distance(int offset, int maxInRow, int distance) {
				this.offset = offset;
				this.maxInRow = maxInRow;
				this.distance = distance;
			}
		}

		private float clamp(float a, float c1, float c2) {
			if(c1 > c2) return clamp(a, c2, c1);
			return Math.Min(Math.Max(a, c1), c2);
		}

		private Color overlay(Color top, Color bot) {
			//https://stackoverflow.com/a/48343059/18704284

			var a0 = top.A / 255.0f;
			var r0 = top.R / 255.0f;
			var g0 = top.G / 255.0f;
			var b0 = top.B / 255.0f;

			var a1 = bot.A / 255.0f;
			var r1 = bot.R / 255.0f;
			var g1 = bot.G / 255.0f;
			var b1 = bot.B / 255.0f;

			var x = 1 - a0;

			var a = x * a1 + a0;
			var r = (x*a1*r1 + a0*r0) / a;
			var g = (x*a1*g1 + a0*g0) / a;
			var b = (x*a1*b1 + a0*b0) / a;

			return Color.FromArgb(
				(int) clamp(a * 255.0f, 0, 255), 
				(int) clamp(r * 255.0f, 0, 255),
				(int) clamp(g * 255.0f, 0, 255), 
				(int) clamp(b * 255.0f, 0, 255)
			);
		}

		private void update() {
			var schedule = context.schedule;
			var lessons = context.schedule.lessons;
			var lessonsUsage = context.lessonsUsage;

			selectedLessonIndexL.Text = "Номер выбранного урока: " + selectedLesson;

			lessonsTable.SuspendLayout();
			Display.clearTable(lessonsTable);

			lessonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

			string prepDupString(string src) {
				src = src.Trim();

				var sb = new StringBuilder();
				for(int i = 0; i < src.Length; i++) {
					var c = src[i];
					if(char.IsWhiteSpace(c));
					else if(c == '\r' || c == '\n');
					else sb.Append(c);
				}

				return sb.ToString();
			}

			duplicates.Clear();
			possibleDuplicates.Clear();
			var set = new Dictionary<string, int>();
			for(int i = 0; i < lessons.Count; i++) {
				var lesson = context.schedule.lessons[i];
				var str = prepDupString(lesson.name) + prepDupString(lesson.type)
					+ prepDupString(lesson.loc) + prepDupString(lesson.extra);

				int dupIndex = 0;
				if(set.TryGetValue(str, out dupIndex)) {
					duplicates.Add(dupIndex);
					duplicates.Add(i);
				}
				else if(str.Length >= 4) {
					foreach(var pair in set) {
						var str2 = pair.Key;
						if(str2.Length < 4) continue;

						bool testStr(string src, string pattern) {
							var co = (int) Math.Floor(pattern.Length * 0.15f);
							pattern = pattern.Substring2(co, pattern.Length - co);
							return src.Contains(pattern);
						}

						bool contains = false;
						if(str.Length < str2.Length) contains = testStr(str2, str);
						else if(str.Length > str2.Length) contains = testStr(str, str2);
						else contains = str == str2;

						if(contains) {
							possibleDuplicates.Add(pair.Value);
							possibleDuplicates.Add(i);
						}
					}
				}

				set[str] = i;
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

				var posDup = possibleDuplicates.Contains(i);
				var duplicate = duplicates.Contains(i);
				var selected = i == selectedLesson - 1;

				Color baseColor = Color.FromArgb(255, 255, 255, 255);
				Color selColor = Color.FromArgb(40, 0, 0, 0);
				Color dupColor = Color.FromArgb(40, 255, 20, 10);
				Color posDupColor = Color.FromArgb(40, 255, 220, 40);

				Color col = baseColor;

				if(selected) col = overlay(selColor, col);
				if(posDup) col = overlay(posDupColor, col);
				if(duplicate) col = overlay(dupColor, col);

				l.BackColor = col;

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
			if(form.ShowDialog2() == DialogResult.OK) {
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
			if(new LessonEditForm(context, lesson).ShowDialog2() != DialogResult.OK) {
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
			}
			catch(Exception ex) {
				MessageBox.Show(
@"Не удалось вставить с клавиатуры. Строка должна иметь подобный формат: 
Технология разработки и защиты баз данных лк 229-2 Куприянов А.А.
Ошибка: " + ex.ToString());
			}
			update();
		}
	}
}
