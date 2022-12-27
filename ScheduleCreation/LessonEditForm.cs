using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
		}

		private void saveB_Click(object sender, EventArgs e) {
			lesson.name = nameTB.Text;
			lesson.type = typeTB.Text;
			lesson.loc = placeTB.Text;
			lesson.extra = extraTB.Text;
			DialogResult = DialogResult.OK;
		}
	}
}
