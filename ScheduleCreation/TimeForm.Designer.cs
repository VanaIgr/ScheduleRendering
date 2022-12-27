
namespace ScheduleCreation {
	partial class TimeForm {
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
			this.timeTable = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.statusLabel = new System.Windows.Forms.Label();
			this.selectB = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// timeTable
			// 
			this.timeTable.AutoSize = true;
			this.timeTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.timeTable.ColumnCount = 2;
			this.tableLayoutPanel1.SetColumnSpan(this.timeTable, 2);
			this.timeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.timeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.timeTable.Dock = System.Windows.Forms.DockStyle.Top;
			this.timeTable.Location = new System.Drawing.Point(3, 3);
			this.timeTable.Name = "timeTable";
			this.timeTable.RowCount = 2;
			this.timeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.timeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.timeTable.Size = new System.Drawing.Size(794, 0);
			this.timeTable.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.timeTable, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.statusLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.selectB, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Location = new System.Drawing.Point(3, 421);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(35, 13);
			this.statusLabel.TabIndex = 1;
			this.statusLabel.Text = "status";
			// 
			// selectB
			// 
			this.selectB.BackColor = System.Drawing.Color.RoyalBlue;
			this.selectB.FlatAppearance.BorderSize = 0;
			this.selectB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.selectB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.selectB.Location = new System.Drawing.Point(722, 424);
			this.selectB.Name = "selectB";
			this.selectB.Size = new System.Drawing.Size(75, 23);
			this.selectB.TabIndex = 2;
			this.selectB.Text = "Выбрать";
			this.selectB.UseVisualStyleBackColor = false;
			this.selectB.Click += new System.EventHandler(this.selectB_Click);
			// 
			// TimeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "TimeForm";
			this.Text = "TimeForm";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel timeTable;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Button selectB;
	}
}