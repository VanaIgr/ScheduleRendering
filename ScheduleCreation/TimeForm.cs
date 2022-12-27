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
	public partial class TimeForm : Form {
		private ScheduleContext context;

		private int selectedTime;

		public int SelectedTime{ get{ return selectedTime; } }
		public TimeForm(ScheduleContext context, int selectedTime) {
			this.context = context;
			this.selectedTime = selectedTime;

			InitializeComponent();

			updateTime();
		}

		private void selectB_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}

		private void updateTime() {
			var schedule = context.schedule;
			var times = context.schedule.times;
			var timesUsage = context.timesUsage;

			timeTable.SuspendLayout();
			timeTable.RowStyles.Clear();
			timeTable.Controls.Clear();

			int i = 0;

			for(;i < times.Count; i++) {
				timeTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

				var n = new Label();
				n.Anchor = AnchorStyles.Left | AnchorStyles.Right;
				Display.setFont(n);
				n.Text = "№" + i + " (" + timesUsage[i] + " исп.): ";
				n.Font = new Font(n.Font, FontStyle.Underline);
				var j = i;
				n.Click += (a, b) => {
					selectedTime = j;
					updateTime();
				};
				if(i == selectedTime) n.BackColor = Color.FromArgb(20, 0, 0, 0);

				timeTable.Controls.Add(n, 0, i);

				var l = new TextBox();
				l.Anchor = AnchorStyles.Left | AnchorStyles.Right;
				Display.setFont(l);
				l.Text = Display.timeToString(times[i]);
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
				Display.setFont(n);
				n.Text = "Добавить: ";
				timeTable.Controls.Add(n, 0,i);

				var l = new TextBox();
				Display.setFont(l);
				l.KeyDown += (a, b) => {
					if(b.KeyCode != Keys.Enter) return;
					try{ 
						var res = parseTime(l.Text); 
						times.Add(res);
						timesUsage.Add(0);
						statusLabel.Text = ""; 
						updateTime();
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
				Display.setFont(n);
				n.Text = "Удалить №: ";
				timeTable.Controls.Add(n, 0, i);

				var l = new NumericUpDown();
				Display.setFont(l);
				l.KeyDown += (a, b) => {
					if(b.KeyCode != Keys.Enter) return;

					try{ 
						deleteTime((int) l.Value);
						statusLabel.Text = ""; 
						updateTime();
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
			var schedule = context.schedule;
			var times = context.schedule.times;
			var timesUsage = context.timesUsage;

			foreach(var day in schedule.days) {
				if(day.timeIndex == index) day.timeIndex = -1;
				else if(day.timeIndex > index) day.timeIndex -= 1;
			}

			times.RemoveAt(index);
			timesUsage.RemoveAt(index);
			if(selectedTime == index) selectedTime = -1;
		}

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
	}
}
