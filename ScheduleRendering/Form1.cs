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

		static AnchorStyles AllAnchors = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;

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
			var maxCols = 0;
			{
                 layout.Add(new List<int>());
                 var start = 0;
				 var text = layoutTB.Text;
				 var curCols = 0;
                 for(int i = 0; i < text.Length; i++) {
                     if (text[i] == ',') {
                         var index = int.Parse(text.Substring2(start, i).Trim()) - 1;
						 if(index < -1 || index >= 6) {
							MessageBox.Show("Непавильный день недели `" + (index+1) + "`");
							return;
						 }
                         layout[layout.Count-1].Add(index);
                         start = i+1;
						 curCols ++;
                     }
                     else if(text[i] == '\n') {
                         layout.Add(new List<int>());
						 maxCols = Math.Max(maxCols, curCols);
						 curCols = 0;
                     }
                 }

				 maxCols = Math.Max(maxCols, curCols);

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

			tl.MinimumSize = new Size(width, 0);
			tl.MaximumSize = new Size(width, int.MaxValue);

			tl.BackColor = Color.Black;

            tl.Padding = new Padding(pad * 2, pad * 2, 0, 0);

			int colsPerDay = 5;

			tl.ColumnCount = maxCols * colsPerDay;
			for(int i = 0; i < maxCols; i++) { 
				tl.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0)); //day of week
				tl.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0)); //time
				tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1)); //group 1
				tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1)); //group 2
				tl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, pad)); //padding between days
			}

			var startRowIndex = 0;

			var needResizing = new List<Label>();

            foreach(var row in layout) {
				if(row.Count == 0) continue;
				var lessonIndicesRanges = new IntRange[row.Count];
				int maxLessonsCount;
				for(int i = 0; i < row.Count; i++) {
					var curDay = schedule.week[row[i]];
					var range0 = curDay.lessons[0].calculateNozeropaddingRange();
					var range1 = curDay.lessons[1].calculateNozeropaddingRange();
					var range2 = curDay.lessons[2].calculateNozeropaddingRange();
					var range3 = curDay.lessons[3].calculateNozeropaddingRange();

					lessonIndicesRanges[i] = new IntRange(
					    min2(range0.first, range1.first, range2.first, range3.first),
					    max2(range0.last, range1.last, range2.last, range3.last)
					);
				}
				maxLessonsCount = lessonIndicesRanges.Select(it => it.Size).Max();

				for(int i = 0; i < maxLessonsCount*2; i++) {
					tl.RowStyles.Add(new RowStyle(SizeType.Percent, 1));
				}

                for(var col = 0; col < row.Count; col++) {
					var dayIndex = row[col];
					IntRange lessonIndicesRange = lessonIndicesRanges[col]; 

					addDay(
						needResizing,
						tl, pad,
						col * colsPerDay, startRowIndex,
						dayIndex, lessonIndicesRange,
						maxLessonsCount, fontSize
					);
				}

				if(row.Count < maxCols) {
					Label blank = new Label();
					blank.AutoSize = true;
					blank.Anchor = AllAnchors;
					blank.BackColor = Color.White;
					blank.Margin = new Padding(0, 0, pad, pad);

					tl.Controls.Add(blank, row.Count * colsPerDay + 0, startRowIndex);
					tl.SetColumnSpan(blank, (maxCols - row.Count) * colsPerDay - 1);
					tl.SetRowSpan(blank, maxLessonsCount * 2);
				}

				tl.RowStyles.Add(new RowStyle(SizeType.Absolute, pad)); //padding between days

				startRowIndex += maxLessonsCount * 2 + 1;
            }

			tl.RowCount = tl.RowStyles.Count;

			tl.ResumeLayout(false);
			tl.PerformLayout();

			foreach(var l in needResizing) {
				ScaleFont(l);
			}

			tl.Refresh();
		}

		void setProp(Control c, float fontSize) {
			c.Font = new Font("Segoe UI", fontSize, FontStyle.Regular, GraphicsUnit.Pixel, 0);
			c.Margin = new Padding();
		}

		private void addDay(
			List<Label> needResizing,
			TableLayoutPanel tl, int pad,
			int startCol, int startRow,
			int dayIndex, IntRange lessonIndicesRange,
			int maxLessonsCount, float fontSize
		) {
			

			if(dayIndex == -1) {
				Label blank = new Label();
				blank.AutoSize = true;
				blank.Anchor = AllAnchors;
				blank.BackColor = Color.White;
				blank.Margin = new Padding(0, 0, pad, pad);

				tl.Controls.Add(blank, startCol + 0, startRow);
				tl.SetColumnSpan(blank, 4); //colsPerDay - 1
				tl.SetRowSpan(blank, maxLessonsCount * 2);

				return;
			}

			var curDay = schedule.week[dayIndex];

			var dayLabel = new VerticalLabel();
			dayLabel.AutoSize = false;
			dayLabel.Text = dayNames[dayIndex];
			dayLabel.TextAlign = ContentAlignment.MiddleLeft;
			setProp(dayLabel, fontSize * 2.0f);
			dayLabel.Margin = new Padding(0, 0, pad, pad);
			dayLabel.Anchor = AllAnchors;
			
			tl.Controls.Add(dayLabel, startCol + 0, startRow);

			if(lessonIndicesRange.Size <= 0) {
				tl.SetRowSpan(dayLabel, maxLessonsCount * 2);

				Label blank = new Label();
				blank.AutoSize = true;
				blank.Anchor = AllAnchors;
				blank.BackColor = Color.White;
				blank.Margin = new Padding(0, 0, pad, pad);

				tl.Controls.Add(blank, startCol + 1, startRow);
				tl.SetColumnSpan(blank, 3); //colsPerDay - 2
				tl.SetRowSpan(blank, maxLessonsCount * 2);

				return;
			}

			tl.SetRowSpan(dayLabel, lessonIndicesRange.Size * 2);

            for(var lessonI = 0; lessonI < lessonIndicesRange.Size; lessonI++) {
				var i = lessonIndicesRange.first + lessonI;
				var time = curDay.time[i];

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
				setProp(timeLabel, fontSize);
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

					var lesson = curDay.lessonsUsed[lessonIndex - 1];

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

					var p = new TableLayoutPanel();

					p.RowStyles.Add(new RowStyle(SizeType.Percent, 1));
					p.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1));
					p.RowCount = 1;
					p.ColumnCount = 1;

					p.Anchor = AllAnchors;
					p.AutoSize = true;
					p.AutoSizeMode = AutoSizeMode.GrowAndShrink;
					p.Margin = new Padding(0, 0, pad, pad);
					if(yellow) p.BackColor = Color.Yellow;
					else p.BackColor = Color.White;

					p.Controls.Add(lessonLabel);
					lessonLabel.Location = new Point();

					return p;
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

		//https://stackoverflow.com/a/25448687/18704284
		private void ScaleFont(Label lab) {
		    SizeF extent = TextRenderer.MeasureText(lab.Text, lab.Font);
		
		    float hRatio = lab.Height / extent.Height;
		    float wRatio = lab.Width / extent.Width;
		    float ratio = Math.Min(hRatio, wRatio);
			if(ratio < 0.001) return;
			if(ratio > 100) return;
		
		    float newSize = lab.Font.Size * ratio;
		
		    lab.Font = new Font(lab.Font.FontFamily, newSize, lab.Font.Style);
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
