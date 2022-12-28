
namespace ScheduleCreation {
	partial class LessonEditForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.nameTB = new System.Windows.Forms.TextBox();
			this.typeTB = new System.Windows.Forms.TextBox();
			this.placeTB = new System.Windows.Forms.TextBox();
			this.extraTB = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.autofillTB = new ScheduleCreation.Textbox2();
			this.statusLabel = new System.Windows.Forms.Label();
			this.saveB = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.nameTB, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.typeTB, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.placeTB, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.extraTB, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.autofillTB, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.statusLabel, 0, 7);
			this.tableLayoutPanel1.Controls.Add(this.saveB, 2, 7);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 8;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(450, 214);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(3, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Название:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(3, 89);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Тип занятия:";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(3, 120);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Место:";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(3, 151);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(110, 17);
			this.label4.TabIndex = 3;
			this.label4.Text = "Преподаватель:";
			// 
			// nameTB
			// 
			this.nameTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.nameTB, 2);
			this.nameTB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.nameTB.Location = new System.Drawing.Point(119, 54);
			this.nameTB.Name = "nameTB";
			this.nameTB.Size = new System.Drawing.Size(328, 25);
			this.nameTB.TabIndex = 0;
			this.nameTB.TextChanged += new System.EventHandler(this.nameTB_TextChanged);
			// 
			// typeTB
			// 
			this.typeTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.typeTB, 2);
			this.typeTB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.typeTB.Location = new System.Drawing.Point(119, 85);
			this.typeTB.Name = "typeTB";
			this.typeTB.Size = new System.Drawing.Size(328, 25);
			this.typeTB.TabIndex = 2;
			this.typeTB.TextChanged += new System.EventHandler(this.typeTB_TextChanged);
			// 
			// placeTB
			// 
			this.placeTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.placeTB, 2);
			this.placeTB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.placeTB.Location = new System.Drawing.Point(119, 116);
			this.placeTB.Name = "placeTB";
			this.placeTB.Size = new System.Drawing.Size(328, 25);
			this.placeTB.TabIndex = 3;
			this.placeTB.TextChanged += new System.EventHandler(this.placeTB_TextChanged);
			// 
			// extraTB
			// 
			this.extraTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.extraTB, 2);
			this.extraTB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.extraTB.Location = new System.Drawing.Point(119, 147);
			this.extraTB.Name = "extraTB";
			this.extraTB.Size = new System.Drawing.Size(328, 25);
			this.extraTB.TabIndex = 4;
			this.extraTB.TextChanged += new System.EventHandler(this.extraTB_TextChanged);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(3, 7);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(110, 17);
			this.label5.TabIndex = 9;
			this.label5.Text = "Автопределение:";
			// 
			// autofillTB
			// 
			this.autofillTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.autofillTB, 2);
			this.autofillTB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.autofillTB.Location = new System.Drawing.Point(119, 3);
			this.autofillTB.Name = "autofillTB";
			this.autofillTB.Size = new System.Drawing.Size(328, 25);
			this.autofillTB.TabIndex = 1;
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.statusLabel, 2);
			this.statusLabel.Location = new System.Drawing.Point(3, 185);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(0, 13);
			this.statusLabel.TabIndex = 11;
			// 
			// saveB
			// 
			this.saveB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.saveB.AutoSize = true;
			this.saveB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.saveB.BackColor = System.Drawing.Color.RoyalBlue;
			this.saveB.FlatAppearance.BorderSize = 0;
			this.saveB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.saveB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.saveB.Location = new System.Drawing.Point(377, 188);
			this.saveB.Name = "saveB";
			this.saveB.Size = new System.Drawing.Size(70, 23);
			this.saveB.TabIndex = 5;
			this.saveB.Text = "Сохранить";
			this.saveB.UseVisualStyleBackColor = false;
			this.saveB.Click += new System.EventHandler(this.saveB_Click);
			// 
			// LessonEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(450, 214);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "LessonEditForm";
			this.Text = "Изменение урока";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox nameTB;
		private System.Windows.Forms.TextBox typeTB;
		private System.Windows.Forms.TextBox placeTB;
		private System.Windows.Forms.TextBox extraTB;
		private System.Windows.Forms.Button saveB;
		private System.Windows.Forms.Label label5;
		private Textbox2 autofillTB;
		private System.Windows.Forms.Label statusLabel;
	}
}