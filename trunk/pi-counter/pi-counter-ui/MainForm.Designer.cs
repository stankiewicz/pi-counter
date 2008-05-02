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
			this.threadCalculation = new System.ComponentModel.BackgroundWorker();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.piToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.calculateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.calculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.labelInfo = new System.Windows.Forms.Label();
			this.panelSearch = new pi_counter_ui.Controls.Search();
			this.panelConstraints = new pi_counter_ui.Controls.Constraints();
			this.panelCalculationStatus = new pi_counter_ui.Controls.CalculationStatus();
			this.threadSearch = new System.ComponentModel.BackgroundWorker();
			this.openFileDialogSearch = new System.Windows.Forms.OpenFileDialog();
			this.menuStrip.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Pi-Counter files|*.bignum";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "bignum";
			this.saveFileDialog.Filter = "Bignum (*.bignum) | *.bignum";
			this.saveFileDialog.SupportMultiDottedExtensions = true;
			this.saveFileDialog.Title = "Please select file to save PI...";
			// 
			// threadCalculation
			// 
			this.threadCalculation.DoWork += new System.ComponentModel.DoWorkEventHandler(this.threadCalculation_DoWork);
			this.threadCalculation.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.threadCalculation_RunWorkerCompleted);
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.piToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(409, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// piToolStripMenuItem
			// 
			this.piToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.calculateToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.calculatorToolStripMenuItem,
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
			this.calculateToolStripMenuItem.Click += new System.EventHandler(this.calculateToolStripMenuItem_Click);
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.searchToolStripMenuItem.Text = "Search";
			this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click_1);
			// 
			// calculatorToolStripMenuItem
			// 
			this.calculatorToolStripMenuItem.Name = "calculatorToolStripMenuItem";
			this.calculatorToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.calculatorToolStripMenuItem.Text = "Calculator";
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
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
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
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.labelInfo);
			this.flowLayoutPanel1.Controls.Add(this.panelSearch);
			this.flowLayoutPanel1.Controls.Add(this.panelConstraints);
			this.flowLayoutPanel1.Controls.Add(this.panelCalculationStatus);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 24);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(409, 334);
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
			// panelSearch
			// 
			this.panelSearch.Location = new System.Drawing.Point(3, 16);
			this.panelSearch.Name = "panelSearch";
			this.panelSearch.Size = new System.Drawing.Size(269, 80);
			this.panelSearch.TabIndex = 3;
			// 
			// panelConstraints
			// 
			this.panelConstraints.LengthConstraint = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.panelConstraints.LengthConstraintEnabled = false;
			this.panelConstraints.Location = new System.Drawing.Point(3, 102);
			this.panelConstraints.Name = "panelConstraints";
			this.panelConstraints.Size = new System.Drawing.Size(282, 76);
			this.panelConstraints.TabIndex = 1;
			this.panelConstraints.TimeConstraint = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.panelConstraints.TimeConstraintEnabled = false;
			// 
			// panelCalculationStatus
			// 
			this.panelCalculationStatus.ConstraintLength = 0;
			this.panelCalculationStatus.ConstraintLengthMax = 100;
			this.panelCalculationStatus.ConstraintTime = 0;
			this.panelCalculationStatus.ConstraintTimeMax = 100;
			this.panelCalculationStatus.Found = ((long)(0));
			this.panelCalculationStatus.FoundMax = ((long)(0));
			this.panelCalculationStatus.FoundVisibility = true;
			this.panelCalculationStatus.Location = new System.Drawing.Point(3, 184);
			this.panelCalculationStatus.Name = "panelCalculationStatus";
			this.panelCalculationStatus.Size = new System.Drawing.Size(403, 117);
			this.panelCalculationStatus.TabIndex = 2;
			// 
			// threadSearch
			// 
			this.threadSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.threadSearch_DoWork);
			this.threadSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.threadSearch_RunWorkerCompleted);
			// 
			// openFileDialogSearch
			// 
			this.openFileDialogSearch.Filter = "Wartoœci funkcji (*.warfun) | *.warfun";
			this.openFileDialogSearch.Title = "Choose file to search within";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(409, 358);
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
		private System.ComponentModel.BackgroundWorker threadCalculation;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem piToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem calculateToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private pi_counter_ui.Controls.Constraints panelConstraints;
		private pi_counter_ui.Controls.CalculationStatus panelCalculationStatus;
		private System.Windows.Forms.Label labelInfo;
		private pi_counter_ui.Controls.Search panelSearch;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.ComponentModel.BackgroundWorker threadSearch;
		private System.Windows.Forms.ToolStripMenuItem calculatorToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialogSearch;
	}
}

