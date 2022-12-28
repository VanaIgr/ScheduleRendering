using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScheduleCreation {
	public partial class NoLessonSelectForm : PositionRememberForm<NoLessonSelectForm> {
		
		public int SelectedNumber{ get; private set; }

		public NoLessonSelectForm() {
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) {
			SelectedNumber = (int) numericUpDown1.Value;
			DialogResult = DialogResult.OK;
		}
	}
}
