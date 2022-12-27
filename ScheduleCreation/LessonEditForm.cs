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
	public partial class LessonEditForm : Form {
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

		private void saveB_Click(object sender, EventArgs e) {
			lesson.name = nameTB.Text;
			lesson.type = typeTB.Text;
			lesson.loc = placeTB.Text;
			lesson.extra = extraTB.Text;
			DialogResult = DialogResult.OK;
		}

		private void updateAutofill() {
			var str = autofillTB.Text;
			//autofillTB.Text = "";

			try {
				var newLesson = ScheduleExt.parseStringToLesson(autofillTB.Text);

				nameTB.Text = newLesson.name.Trim();
				typeTB.Text = newLesson.type.Trim();
				placeTB.Text = newLesson.loc.Trim();
				extraTB.Text = newLesson.extra.Trim();
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
