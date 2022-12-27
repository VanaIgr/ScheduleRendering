
namespace ScheduleCreation {
	partial class DaySelectForm {
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
			this.dayPreviewTable = new System.Windows.Forms.TableLayoutPanel();
			this.daysTable = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.addB = new System.Windows.Forms.Button();
			this.deleteB = new System.Windows.Forms.Button();
			this.selectB = new System.Windows.Forms.Button();
			this.editB = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.dayPreviewTable, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.daysTable, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(825, 536);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// dayPreviewTable
			// 
			this.dayPreviewTable.AutoScroll = true;
			this.dayPreviewTable.ColumnCount = 1;
			this.dayPreviewTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.dayPreviewTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dayPreviewTable.Location = new System.Drawing.Point(322, 3);
			this.dayPreviewTable.Name = "dayPreviewTable";
			this.dayPreviewTable.RowCount = 1;
			this.dayPreviewTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.dayPreviewTable.Size = new System.Drawing.Size(500, 493);
			this.dayPreviewTable.TabIndex = 0;
			// 
			// daysTable
			// 
			this.daysTable.AutoSize = true;
			this.daysTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.daysTable.ColumnCount = 1;
			this.daysTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.daysTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.daysTable.Location = new System.Drawing.Point(3, 3);
			this.daysTable.Name = "daysTable";
			this.daysTable.RowCount = 1;
			this.daysTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.daysTable.Size = new System.Drawing.Size(313, 493);
			this.daysTable.TabIndex = 1;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 5;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.deleteB, 2, 0);
			this.tableLayoutPanel3.Controls.Add(this.selectB, 4, 0);
			this.tableLayoutPanel3.Controls.Add(this.addB, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.editB, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.button1, 3, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 502);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(819, 31);
			this.tableLayoutPanel3.TabIndex = 2;
			// 
			// addB
			// 
			this.addB.AutoSize = true;
			this.addB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.addB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.addB.Location = new System.Drawing.Point(3, 3);
			this.addB.Name = "addB";
			this.addB.Size = new System.Drawing.Size(69, 25);
			this.addB.TabIndex = 3;
			this.addB.Text = "Добавить";
			this.addB.UseVisualStyleBackColor = true;
			this.addB.Click += new System.EventHandler(this.addB_Click);
			// 
			// deleteB
			// 
			this.deleteB.AutoSize = true;
			this.deleteB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.deleteB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.deleteB.Location = new System.Drawing.Point(564, 3);
			this.deleteB.Name = "deleteB";
			this.deleteB.Size = new System.Drawing.Size(62, 25);
			this.deleteB.TabIndex = 2;
			this.deleteB.Text = "Удалить";
			this.deleteB.UseVisualStyleBackColor = true;
			this.deleteB.Click += new System.EventHandler(this.deleteB_Click);
			// 
			// selectB
			// 
			this.selectB.AutoSize = true;
			this.selectB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.selectB.BackColor = System.Drawing.Color.RoyalBlue;
			this.selectB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.selectB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.selectB.Location = new System.Drawing.Point(753, 3);
			this.selectB.Name = "selectB";
			this.selectB.Size = new System.Drawing.Size(63, 25);
			this.selectB.TabIndex = 0;
			this.selectB.Text = "Выбрать";
			this.selectB.UseVisualStyleBackColor = false;
			this.selectB.Click += new System.EventHandler(this.selectB_Click);
			// 
			// editB
			// 
			this.editB.AutoSize = true;
			this.editB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.editB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.editB.Location = new System.Drawing.Point(488, 3);
			this.editB.Name = "editB";
			this.editB.Size = new System.Drawing.Size(70, 25);
			this.editB.TabIndex = 1;
			this.editB.Text = "Изменить";
			this.editB.UseVisualStyleBackColor = true;
			this.editB.Click += new System.EventHandler(this.editB_Click);
			// 
			// button1
			// 
			this.button1.AutoSize = true;
			this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button1.BackColor = System.Drawing.Color.RoyalBlue;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.button1.Location = new System.Drawing.Point(632, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(115, 25);
			this.button1.TabIndex = 4;
			this.button1.Text = "Выбрать выходной";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// DaySelectForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(825, 536);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "DaySelectForm";
			this.Text = "DaySelectForm";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel dayPreviewTable;
		private System.Windows.Forms.TableLayoutPanel daysTable;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button deleteB;
		private System.Windows.Forms.Button selectB;
		private System.Windows.Forms.Button editB;
		private System.Windows.Forms.Button addB;
		private System.Windows.Forms.Button button1;
	}
}