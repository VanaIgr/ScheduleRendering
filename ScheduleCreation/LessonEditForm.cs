using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ScheduleCreation {
	public partial class LessonEditForm : PositionRememberForm<LessonEditForm> {
		private ScheduleContext context;
		private ScheduleExt.Lesson lesson;

		public LessonEditForm(ScheduleContext context, ScheduleExt.Lesson lesson) {
			this.context = context;
			this.lesson = lesson;

			InitializeComponent();

			nameTB.Text  = lesson.name;
			typeTB.Text  = lesson.type;
			placeTB.Text = lesson.loc;
			extraTB.Text = lesson.extra;

			autofillTB.UpdateAutofil += (a, b) => updateAutofill();
		}

		private StringBuilder sb = new StringBuilder();

		private string normalizeStr(string str) {
			sb.Clear();
			var spaceBefore = false;
			for(int i = 0; i < str.Length; i++) {
				var c = str[i];
				if(char.IsWhiteSpace(c)) {
					spaceBefore = true;
				}
				else {
					if(spaceBefore && sb.Length > 0) sb.Append(" ");
					spaceBefore = false;
					sb.Append(c);
				}
			}
			return sb.ToString();
		}

		private void saveB_Click(object sender, EventArgs e) {
			lesson.name  = normalizeStr(nameTB.Text );
			lesson.type  = normalizeStr(typeTB.Text );
			lesson.loc   = normalizeStr(placeTB.Text);
			lesson.extra = normalizeStr(extraTB.Text);
			DialogResult = DialogResult.OK;
		}

		private void updateAutofill() {
			var str = autofillTB.Text;
			//autofillTB.Text = "";

			try {
				var newLesson = ScheduleExt.parseStringToLesson(autofillTB.Text);

				nameTB.Text = normalizeStr(newLesson.name);
				typeTB.Text = normalizeStr(newLesson.type);
				placeTB.Text = normalizeStr(newLesson.loc);
				extraTB.Text = normalizeStr(newLesson.extra);
			}
			catch(Exception e) {
				statusLabel.Text = e.ToString();
			}
		}

		private void nameTB_TextChanged(object sender, EventArgs e) {
			statusLabel.Text = "";
		}

		private void typeTB_TextChanged(object sender, EventArgs e) {
			statusLabel.Text = "";
		}

		private void placeTB_TextChanged(object sender, EventArgs e) {
			statusLabel.Text = "";
		}

		private void extraTB_TextChanged(object sender, EventArgs e) {
			statusLabel.Text = "";
		}
	}

	public class Textbox2 : TextBox {
		private const int WM_PASTE = 0x0302;

		public Textbox2() : base() {
			//LostFocus += (a, b) => UpdateAutofil?.Invoke(this, new EventArgs());
			KeyUp += (a, b) => { if(b.KeyCode == Keys.Enter) UpdateAutofil?.Invoke(this, new EventArgs()); };
		}
		protected override void WndProc(ref Message m) {
			if (m.Msg == WM_PASTE) {
				var st = Clipboard.GetText();
				this.Text = ScheduleExt.patchLessonString(st);
				UpdateAutofil?.Invoke(this, new EventArgs());
			}
			else base.WndProc(ref m);
		}

		public event EventHandler UpdateAutofil;
	}
}
