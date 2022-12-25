using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScheduleRendering {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) {
			if(openFileDialog1.ShowDialog() == DialogResult.OK) {
				var str = File.ReadAllText(openFileDialog1.FileName);
				var sch = ParseInput.parseSchedule(str);

				int i = sch.week.Length;
			}
		}
	}
}
