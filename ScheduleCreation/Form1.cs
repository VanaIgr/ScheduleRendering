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

		List<IntRange[]> times = new List<IntRange[]>();
		List<int> timesUsage = new List<int>();

		Schedule schedule;

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
			var lesson = new int[0];
			var day = new ScheduleExt.Day(
				new Lesson[]{}, timeTable, new int[][]{ lesson, lesson, lesson, lesson }
			);

			schedule = new Schedule(
				new Weeks(today.Day, today.Month, today.Year, new bool[]{false, true}),
				new ScheduleExt.Day[] { day, day, day, day, day, day, day }
			);

			updateDisplayFromSchedule();
		}

		private void updateDisplayFromSchedule() {
			var date = schedule.weeksDescription;
			startDate.Value = new DateTime(date.year, date.month, date.day);

			{
				var sb = new StringBuilder(schedule.weeksDescription.weeks.Length);
				foreach(var it in schedule.weeksDescription.weeks) sb.Append(it ? '1' : '0');
				weeksText.Text = sb.ToString();
			}

			timesUsage.Clear();
			for(int i = 0; i < times.Count; i++) timesUsage.Add(0);

			for(int i = 0; i < schedule.week.Length; i++) {
				var time = schedule.week[i].time;
				if(time == null) continue;
				var index = times.IndexOf(time);
				if(index == -1) {
					times.Add(time);
					timesUsage.Add(1);
				}
				else timesUsage[index]++;
			}

			updateTime();

			//for(int i = 0; i < 7; i++) {
			//	var name
			//}
		}

		private void updateTime() {
			timeTable.SuspendLayout();
			timeTable.RowStyles.Clear();
			timeTable.Controls.Clear();

			int i = 0;

			for(;i < times.Count; i++) {
				timeTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

				var n = new Label();
				n.Anchor = AnchorStyles.Left | AnchorStyles.Right;
				setFont(n);
				n.Text = "№" + i + " (" + timesUsage[i] + " исп.): ";

				timeTable.Controls.Add(n, 0, i);

				var l = new TextBox();
				l.Anchor = AnchorStyles.Left | AnchorStyles.Right;
				setFont(l);
				l.Text = timeToString(times[i]);
				int j = i;
				l.KeyDown += (a, b) => {
					if(b.KeyCode != Keys.Enter) return;
					try{ 
						times[j] = parseTime(l.Text); 
						statusLabel.Text = ""; 
						this.ActiveControl = null;
					}
					catch(Exception e) { statusLabel.Text = e.ToString(); }
				};
				timeTable.Controls.Add(l, 1, i);
			}
			{
				timeTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

				var n = new Label();
				n.Anchor = AnchorStyles.Left | AnchorStyles.Right;
				setFont(n);
				n.Text = "Добавить: ";
				timeTable.Controls.Add(n, 0,i);

				var l = new TextBox();
				setFont(l);
				l.KeyDown += (a, b) => {
					if(b.KeyCode != Keys.Enter) return;
					try{ 
						var res = parseTime(l.Text); 
						times.Add(res);
						statusLabel.Text = ""; 
						updateDisplayFromSchedule();
					}
					catch(Exception e) { statusLabel.Text = e.ToString(); }
				};
				timeTable.Controls.Add(l, 1, i);

				i++;
			}

			{
				timeTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

				var n = new Label();
				n.Anchor = AnchorStyles.Left | AnchorStyles.Right;
				setFont(n);
				n.Text = "Удалить №: ";
				timeTable.Controls.Add(n, 0, i);

				var l = new NumericUpDown();
				setFont(l);
				l.KeyDown += (a, b) => {
					if(b.KeyCode != Keys.Enter) return;

					try{ 
						deleteTime((int) l.Value);
						statusLabel.Text = ""; 
						updateDisplayFromSchedule();
					}
					catch(Exception e) { statusLabel.Text = e.ToString(); }
				};
				timeTable.Controls.Add(l, 1, i);

				i++;
			}

			timeTable.RowCount = timeTable.RowStyles.Count;

			timeTable.ResumeLayout(false);
			timeTable.PerformLayout();
		}

		private void deleteTime(int index) {
			var time = times[index];
			foreach(var day in schedule.week) {
				if(day.time == time) day.time = null;
			}
			times.RemoveAt(index);
		}

		static StringBuilder sb = new StringBuilder();

		private IntRange[] parseTime(string str) {
			var list = new List<IntRange>();

			int lastSymbol = str.Length - 1;
			for(; lastSymbol > 0; lastSymbol--) if(!char.IsWhiteSpace(str[lastSymbol])) break;
			int len = lastSymbol+1;

			int i = 0;
			while(i < len) {
				var start = i;
				while(str[i] != ':') i++;
				var hourF = int.Parse(str.Substring2(start, i).Trim());
				i++;

				start = i;
				while(str[i] != '-') i++;
				var minuteF = int.Parse(str.Substring2(start, i).Trim());
				i++;

				start = i;
				while(str[i] != ':') i++;
				var hourS = int.Parse(str.Substring2(start, i).Trim());
				i++;

				start = i;
				while(i < len && str[i] != ',') i++;
				var minuteS = int.Parse(str.Substring2(start, i).Trim());
				i++;

				list.Add(new IntRange(timeToMinuteOfDay(hourF, minuteF), timeToMinuteOfDay(hourS, minuteS)));
			}

			return list.ToArray();
		}

		private string timeToString(IntRange[] time) {
			sb.Clear();
			foreach(var it in time) {
				sb.Append(minuteOfDayToString(it.first))
					.Append('-')
					.Append(minuteOfDayToString(it.last))
					.Append(", ");
			}
			return sb.ToString();
		}

		private void setFont(Control c) {
			c.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
		}
	}
}
