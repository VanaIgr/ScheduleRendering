
namespace ScheduleRendering {
	partial class Form1 {
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.label4 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.fontNUD = new System.Windows.Forms.NumericUpDown();
			this.widthNUD = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.paddingNUD = new System.Windows.Forms.NumericUpDown();
			this.layoutTB = new System.Windows.Forms.TextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.tableLayoutPanel3 = new ScheduleRendering.Panel2();
			this.scheduleTLP = new ScheduleRendering.Table2();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fontNUD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.widthNUD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paddingNUD)).BeginInit();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.label4, 0, 4);
			this.tableLayoutPanel2.Controls.Add(this.button3, 0, 9);
			this.tableLayoutPanel2.Controls.Add(this.button2, 0, 7);
			this.tableLayoutPanel2.Controls.Add(this.button1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.fontNUD, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.widthNUD, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.label3, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.paddingNUD, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.layoutTB, 1, 4);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 10;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(256, 450);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 109);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(76, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Размещение:";
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.AutoSize = true;
			this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button3.BackColor = System.Drawing.Color.RoyalBlue;
			this.tableLayoutPanel2.SetColumnSpan(this.button3, 2);
			this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.button3.FlatAppearance.BorderSize = 0;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.button3.Location = new System.Drawing.Point(3, 424);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(250, 23);
			this.button3.TabIndex = 7;
			this.button3.Text = "Сохранить";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.AutoSize = true;
			this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.SetColumnSpan(this.button2, 2);
			this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(3, 183);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(250, 25);
			this.button2.TabIndex = 6;
			this.button2.Text = "Обновить";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.AutoSize = true;
			this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.SetColumnSpan(this.button1, 2);
			this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(3, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(250, 25);
			this.button1.TabIndex = 0;
			this.button1.Text = "выбрать файл";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(3, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Размер шрифта:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Ширина:";
			// 
			// fontNUD
			// 
			this.fontNUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.fontNUD.Location = new System.Drawing.Point(104, 34);
			this.fontNUD.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.fontNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.fontNUD.Name = "fontNUD";
			this.fontNUD.Size = new System.Drawing.Size(149, 20);
			this.fontNUD.TabIndex = 4;
			this.fontNUD.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			// 
			// widthNUD
			// 
			this.widthNUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.widthNUD.Location = new System.Drawing.Point(104, 60);
			this.widthNUD.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.widthNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.widthNUD.Name = "widthNUD";
			this.widthNUD.Size = new System.Drawing.Size(149, 20);
			this.widthNUD.TabIndex = 5;
			this.widthNUD.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 83);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(95, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Ширина границы:";
			// 
			// paddingNUD
			// 
			this.paddingNUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.paddingNUD.Location = new System.Drawing.Point(104, 86);
			this.paddingNUD.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.paddingNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.paddingNUD.Name = "paddingNUD";
			this.paddingNUD.Size = new System.Drawing.Size(149, 20);
			this.paddingNUD.TabIndex = 9;
			this.paddingNUD.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// layoutTB
			// 
			this.layoutTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.layoutTB.Location = new System.Drawing.Point(104, 112);
			this.layoutTB.Multiline = true;
			this.layoutTB.Name = "layoutTB";
			this.layoutTB.Size = new System.Drawing.Size(149, 65);
			this.layoutTB.TabIndex = 11;
			this.layoutTB.Text = "0, 3,\r\n1, 4,\r\n2,";
			this.layoutTB.WordWrap = false;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoScroll = true;
			this.tableLayoutPanel3.Controls.Add(this.scheduleTLP);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(259, 3);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.Size = new System.Drawing.Size(538, 444);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// scheduleTLP
			// 
			this.scheduleTLP.AutoSize = true;
			this.scheduleTLP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.scheduleTLP.ColumnCount = 2;
			this.scheduleTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.scheduleTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.scheduleTLP.Location = new System.Drawing.Point(0, 0);
			this.scheduleTLP.Margin = new System.Windows.Forms.Padding(0);
			this.scheduleTLP.Name = "scheduleTLP";
			this.scheduleTLP.RowCount = 2;
			this.scheduleTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.scheduleTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.scheduleTLP.Size = new System.Drawing.Size(0, 0);
			this.scheduleTLP.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Form1";
			this.Text = "Расписание";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.fontNUD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.widthNUD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.paddingNUD)).EndInit();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown fontNUD;
		private System.Windows.Forms.NumericUpDown widthNUD;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private Panel2 tableLayoutPanel3;
		private Table2 scheduleTLP;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown paddingNUD;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox layoutTB;
	}
}

