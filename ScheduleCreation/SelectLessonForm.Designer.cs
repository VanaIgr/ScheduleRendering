
namespace ScheduleCreation {
	partial class SelectLessonForm {
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
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.button1 = new System.Windows.Forms.Button();
			this.addB = new System.Windows.Forms.Button();
			this.deleteB = new System.Windows.Forms.Button();
			this.changeB = new System.Windows.Forms.Button();
			this.selectB = new System.Windows.Forms.Button();
			this.selectedLessonIndexL = new System.Windows.Forms.Label();
			this.lessonsTable = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.lessonsTable, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AllowDrop = true;
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 6;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.addB, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.deleteB, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.selectB, 5, 0);
			this.tableLayoutPanel2.Controls.Add(this.selectedLessonIndexL, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.changeB, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.button1, 4, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 416);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 31);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.AutoSize = true;
			this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button1.BackColor = System.Drawing.Color.RoyalBlue;
			this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.button1.Location = new System.Drawing.Point(634, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(90, 25);
			this.button1.TabIndex = 5;
			this.button1.Text = "Выбрать окно";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// addB
			// 
			this.addB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.addB.AutoSize = true;
			this.addB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.addB.BackColor = System.Drawing.Color.Transparent;
			this.addB.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			this.addB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.addB.ForeColor = System.Drawing.SystemColors.ControlText;
			this.addB.Location = new System.Drawing.Point(559, 3);
			this.addB.Name = "addB";
			this.addB.Size = new System.Drawing.Size(69, 25);
			this.addB.TabIndex = 4;
			this.addB.Text = "Добавить";
			this.addB.UseVisualStyleBackColor = false;
			this.addB.Click += new System.EventHandler(this.addB_Click);
			// 
			// deleteB
			// 
			this.deleteB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.deleteB.AutoSize = true;
			this.deleteB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.deleteB.BackColor = System.Drawing.Color.Transparent;
			this.deleteB.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			this.deleteB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.deleteB.ForeColor = System.Drawing.SystemColors.ControlText;
			this.deleteB.Location = new System.Drawing.Point(491, 3);
			this.deleteB.Name = "deleteB";
			this.deleteB.Size = new System.Drawing.Size(62, 25);
			this.deleteB.TabIndex = 3;
			this.deleteB.Text = "Удалить";
			this.deleteB.UseVisualStyleBackColor = false;
			this.deleteB.Click += new System.EventHandler(this.deleteB_Click);
			// 
			// changeB
			// 
			this.changeB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.changeB.AutoSize = true;
			this.changeB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.changeB.BackColor = System.Drawing.Color.Transparent;
			this.changeB.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			this.changeB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.changeB.ForeColor = System.Drawing.SystemColors.ControlText;
			this.changeB.Location = new System.Drawing.Point(415, 3);
			this.changeB.Name = "changeB";
			this.changeB.Size = new System.Drawing.Size(70, 25);
			this.changeB.TabIndex = 2;
			this.changeB.Text = "Изменить";
			this.changeB.UseVisualStyleBackColor = false;
			this.changeB.Click += new System.EventHandler(this.changeB_Click);
			// 
			// selectB
			// 
			this.selectB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.selectB.AutoSize = true;
			this.selectB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.selectB.BackColor = System.Drawing.Color.RoyalBlue;
			this.selectB.FlatAppearance.BorderSize = 0;
			this.selectB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.selectB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.selectB.Location = new System.Drawing.Point(730, 3);
			this.selectB.Name = "selectB";
			this.selectB.Size = new System.Drawing.Size(61, 25);
			this.selectB.TabIndex = 1;
			this.selectB.Text = "Выбрать";
			this.selectB.UseVisualStyleBackColor = false;
			this.selectB.Click += new System.EventHandler(this.selectB_Click);
			// 
			// selectedLessonIndexL
			// 
			this.selectedLessonIndexL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.selectedLessonIndexL.AutoSize = true;
			this.selectedLessonIndexL.Location = new System.Drawing.Point(3, 0);
			this.selectedLessonIndexL.Name = "selectedLessonIndexL";
			this.selectedLessonIndexL.Size = new System.Drawing.Size(73, 31);
			this.selectedLessonIndexL.TabIndex = 6;
			this.selectedLessonIndexL.Text = "selectedIndex";
			// 
			// lessonsTable
			// 
			this.lessonsTable.AutoScroll = true;
			this.lessonsTable.AutoSize = true;
			this.lessonsTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lessonsTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.lessonsTable.ColumnCount = 2;
			this.lessonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.lessonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.lessonsTable.Dock = System.Windows.Forms.DockStyle.Top;
			this.lessonsTable.Location = new System.Drawing.Point(3, 3);
			this.lessonsTable.Name = "lessonsTable";
			this.lessonsTable.RowCount = 2;
			this.lessonsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.lessonsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.lessonsTable.Size = new System.Drawing.Size(794, 3);
			this.lessonsTable.TabIndex = 0;
			// 
			// SelectLessonForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "SelectLessonForm";
			this.Text = "SelectLessonForm";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel lessonsTable;
		private System.Windows.Forms.Button selectB;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button deleteB;
		private System.Windows.Forms.Button changeB;
		private System.Windows.Forms.Button addB;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label selectedLessonIndexL;
	}
}