using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScheduleRendering {
	class VerticalLabel : Label {

		public VerticalLabel() : base() {
			this.BackColor = Color.White;
			this.ForeColor = this.BackColor;
		}

		public override Color BackColor { get => base.BackColor; set { base.BackColor=value; base.ForeColor = value; } }
		public override Color ForeColor { get => base.ForeColor; set => base.ForeColor=base.BackColor; }

		public override string Text { get => base.Text; set {
			base.Text=value; 
			updSize();
		} }

		public override Font Font { get => base.Font; set {
			base.Font=value; 
			updSize();
		} }

		private void updSize() {
			using(var g = this.CreateGraphics()) { 
			var res = TextRenderer.MeasureText(g, this.Text, this.Font);
			this.Width = res.Height;
			this.Height = res.Width;
			}
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);

			e.Graphics.TranslateTransform(this.Width / 2.0f, this.Height / 2.0f);
			e.Graphics.RotateTransform(-90);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Center;
			using(var b = new SolidBrush(Color.Black)) {

			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
			e.Graphics.DrawString(this.Text, this.Font, b, 0, 0, stringFormat);
			}
		}
	}
}
