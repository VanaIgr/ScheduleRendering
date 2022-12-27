using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static ScheduleExt;

namespace ScheduleRendering {
	public partial class Form1 : Form {
		Schedule schedule;

		public Form1() {
			InitializeComponent();

			/*tableLayoutPanel3.GetType().InvokeMember(
				"DoubleBuffered",
				BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty,
				Type.DefaultBinder, tableLayoutPanel3, new object[]{ true }
			);*/
		}

		private void button1_Click(object sender, EventArgs e) {
			try { 
			if(openFileDialog1.ShowDialog() == DialogResult.OK) {
				var str = File.ReadAllText(openFileDialog1.FileName);
				schedule = parseSchedule(str);
			}
			} catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}

		private void button2_Click(object sender, EventArgs e) {
			if(schedule == null) {
				MessageBox.Show("Нет расписания");
				return;
			}

			var b = new Button();
			b.Text = "AAAAA";

			var width = (int) widthNUD.Value;
			var fontSize = (int) fontNUD.Value;

			var tl = scheduleTLP;
			var pad = (int) paddingNUD.Value;

			var layout = new List<List<int>>(); 
			var maxDaysCols = 0;
			{
                 layout.Add(new List<int>());
                 var start = 0;
				 var text = layoutTB.Text;
				 var curCols = 0;
                 for(int i = 0; i < text.Length; i++) {
                     if (text[i] == ',') {
                         var index = int.Parse(text.Substring2(start, i).Trim());
						 if(index < 0 || index >= 7) {
							MessageBox.Show("Непавильный день недели `" + index + "`");
							return;
						 }
                         layout[layout.Count-1].Add(index);
                         start = i+1;
						 curCols ++;
                     }
                     else if(text[i] == '\n') {
                         layout.Add(new List<int>());
						 maxDaysCols = Math.Max(maxDaysCols, curCols);
						 curCols = 0;
                     }
                 }

				 maxDaysCols = Math.Max(maxDaysCols, curCols);

                 if(start != text.Length) throw new Exception(
                     "Ошибка, `,` должна быть последним символом"
                 );
             }

			tl.SuspendLayout();

			tl.RowCount = 0;
			tl.ColumnCount = 0;
			tl.RowStyles.Clear();
			tl.ColumnStyles.Clear();
			tl.Controls.Clear();

			Display.setupDaysTable(tl, width, pad, maxDaysCols);

			var startRowIndex = 0;

			var needResizing = new List<Label>();

            foreach(var row in layout) {
				if(row.Count == 0) continue;
				var lessonIndicesRanges = new IntRange[row.Count];
				int maxLessonsCount;
				for(int i = 0; i < row.Count; i++) {
					var weekdayIndex = row[i];
					var dayIndex = weekdayIndex < 0 || weekdayIndex >= 7 ? null : (int?) schedule.daysInWeek[weekdayIndex];
					lessonIndicesRanges[i] = ScheduleExt.calcDayLessonIndices(
						dayIndex == null || dayIndex < 0 ? null : schedule.days[dayIndex.Value]
					);
				}
				maxLessonsCount = lessonIndicesRanges.Select(it => it.Size).Max();

				for(int i = 0; i < maxLessonsCount*2; i++) {
					tl.RowStyles.Add(new RowStyle(SizeType.Percent, 1));
				}

                for(var col = 0; col < row.Count; col++) {
					var weekdayIndex = row[col];
					var dayIndex = weekdayIndex < 0 || weekdayIndex >= 7 ? null : (int?) schedule.daysInWeek[weekdayIndex];
					IntRange lessonIndicesRange = lessonIndicesRanges[col]; 

					Display.addDay(
						needResizing, 
						tl, pad, col * Display.colsPerDay, startRowIndex,
						schedule, dayIndex == null || dayIndex < 0 ? null : schedule.days[dayIndex.Value], weekdayIndex, lessonIndicesRange,
						maxLessonsCount, fontSize
					);
				}

				if(row.Count < maxDaysCols) {
					Label blank = new Label();
					blank.AutoSize = true;
					blank.Anchor = Display.AllAnchors;
					blank.BackColor = Color.White;
					blank.Margin = new Padding(0, 0, pad, pad);

					tl.Controls.Add(blank, row.Count * Display.colsPerDay + 0, startRowIndex);
					tl.SetColumnSpan(blank, (maxDaysCols - row.Count) * Display.colsPerDay - 1);
					tl.SetRowSpan(blank, maxLessonsCount * 2);
				}

				tl.RowStyles.Add(new RowStyle(SizeType.Absolute, pad)); //padding between days

				startRowIndex += maxLessonsCount * 2 + 1;
            }

			tl.RowCount = tl.RowStyles.Count;

			tl.ResumeLayout(false);
			tl.PerformLayout();

			foreach(var l in needResizing) {
				Display.ScaleFont(l);
			}

			tl.Refresh();
		}

		private void button3_Click(object sender, EventArgs e) {
			using(var bmp = new Bitmap(scheduleTLP.Width, scheduleTLP.Height)) {
			scheduleTLP.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
			saveFileDialog1.FileName = "schedule.png";
			saveFileDialog1.Filter = "PNG | *.png";
			if(saveFileDialog1.ShowDialog() == DialogResult.OK) {
				bmp.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
			}
			}
		}
	}

	public class Table2 : TableLayoutPanel {
		public Table2() {
			this.DoubleBuffered = true;
		}
	}

	public class Panel2 : Panel {
		public Panel2() {
			this.DoubleBuffered = true;
		}
	}
}
