namespace pi_counter_ui {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
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
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.piToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.calculateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.test2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.labelInfo = new System.Windows.Forms.Label();
			this.search1 = new pi_counter_ui.Controls.Search();
			this.constraints1 = new pi_counter_ui.Controls.Constraints();
			this.calculationStatus1 = new pi_counter_ui.Controls.CalculationStatus();
			this.menuStrip.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Pi-Counter files|*.pi";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "pi";
			this.saveFileDialog.SupportMultiDottedExtensions = true;
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.piToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.testsToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(491, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// piToolStripMenuItem
			// 
			this.piToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.calculateToolStripMenuItem,
            this.toolStripSeparator2,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.piToolStripMenuItem.Name = "piToolStripMenuItem";
			this.piToolStripMenuItem.Size = new System.Drawing.Size(27, 20);
			this.piToolStripMenuItem.Text = "Pi";
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.viewToolStripMenuItem.Text = "View";
			this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
			// 
			// calculateToolStripMenuItem
			// 
			this.calculateToolStripMenuItem.Name = "calculateToolStripMenuItem";
			this.calculateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.calculateToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.calculateToolStripMenuItem.Text = "Calculate";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.loadToolStripMenuItem.Text = "Load";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.saveToolStripMenuItem.Text = "Save";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.searchToolStripMenuItem.Text = "Search";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// testsToolStripMenuItem
			// 
			this.testsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.test2ToolStripMenuItem});
			this.testsToolStripMenuItem.Name = "testsToolStripMenuItem";
			this.testsToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
			this.testsToolStripMenuItem.Text = "Tests";
			// 
			// test2ToolStripMenuItem
			// 
			this.test2ToolStripMenuItem.Name = "test2ToolStripMenuItem";
			this.test2ToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
			this.test2ToolStripMenuItem.Text = "test2";
			this.test2ToolStripMenuItem.Click += new System.EventHandler(this.test2ToolStripMenuItem_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.labelInfo);
			this.flowLayoutPanel1.Controls.Add(this.search1);
			this.flowLayoutPanel1.Controls.Add(this.constraints1);
			this.flowLayoutPanel1.Controls.Add(this.calculationStatus1);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 24);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(491, 406);
			this.flowLayoutPanel1.TabIndex = 1;
			// 
			// labelInfo
			// 
			this.labelInfo.AutoSize = true;
			this.labelInfo.Location = new System.Drawing.Point(3, 0);
			this.labelInfo.Name = "labelInfo";
			this.labelInfo.Size = new System.Drawing.Size(70, 13);
			this.labelInfo.TabIndex = 4;
			this.labelInfo.Text = "[info info info]";
			// 
			// search1
			// 
			this.search1.Location = new System.Drawing.Point(3, 16);
			this.search1.Name = "search1";
			this.search1.Size = new System.Drawing.Size(241, 83);
			this.search1.TabIndex = 3;
			// 
			// constraints1
			// 
			this.constraints1.LengthConstraint = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.constraints1.Location = new System.Drawing.Point(3, 105);
			this.constraints1.Name = "constraints1";
			this.constraints1.Size = new System.Drawing.Size(278, 76);
			this.constraints1.TabIndex = 1;
			this.constraints1.TimeConstraint = new decimal(new int[] {
            0,
            0,
            0,
            0});
			// 
			// calculationStatus1
			// 
			this.calculationStatus1.ConstraintLength = 0;
			this.calculationStatus1.ConstraintLengthMax = 100;
			this.calculationStatus1.ConstraintTime = 0;
			this.calculationStatus1.ConstraintTimeMax = 100;
			this.calculationStatus1.Found = ((long)(0));
			this.calculationStatus1.FoundMax = ((long)(0));
			this.calculationStatus1.FoundVisibility = true;
			this.calculationStatus1.Location = new System.Drawing.Point(3, 187);
			this.calculationStatus1.Name = "calculationStatus1";
			this.calculationStatus1.Size = new System.Drawing.Size(398, 117);
			this.calculationStatus1.TabIndex = 2;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(491, 430);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MainForm";
			this.Text = "Pi-Counter";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem piToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem calculateToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private pi_counter_ui.Controls.Constraints constraints1;
		private pi_counter_ui.Controls.CalculationStatus calculationStatus1;
		private System.Windows.Forms.Label labelInfo;
		private pi_counter_ui.Controls.Search search1;
		private System.Windows.Forms.ToolStripMenuItem testsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem test2ToolStripMenuItem;
	}
}

