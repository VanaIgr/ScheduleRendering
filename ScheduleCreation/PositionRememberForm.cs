using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScheduleCreation {
	public class PositionRememberForm<T> : Form where T : PositionRememberForm<T> {
		private static Point? lastPos = null;
		private static Size? lastSize = null;

		public DialogResult ShowDialog2() {
			if(lastPos != null) { 
				StartPosition = FormStartPosition.Manual;
				Location = lastPos.Value;
			}
			if(lastSize != null) Size = lastSize.Value;
			var res = this.ShowDialog();
			lastPos = this.Location;
			lastSize = this.Size;
			return res;
		}
	}
}
