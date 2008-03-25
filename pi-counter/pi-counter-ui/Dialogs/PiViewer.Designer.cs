namespace pi_counter_ui.Dialogs {
	partial class PiViewer {
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
			this.textBoxPiView = new System.Windows.Forms.TextBox();
			this.panelStatus = new System.Windows.Forms.Panel();
			this.labelPositionValue = new System.Windows.Forms.Label();
			this.labelPosition = new System.Windows.Forms.Label();
			this.indexer1 = new pi_counter_ui.Controls.Indexer();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.decimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panelStatus.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxPiView
			// 
			this.textBoxPiView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPiView.Location = new System.Drawing.Point(12, 27);
			this.textBoxPiView.Multiline = true;
			this.textBoxPiView.Name = "textBoxPiView";
			this.textBoxPiView.ReadOnly = true;
			this.textBoxPiView.Size = new System.Drawing.Size(377, 400);
			this.textBoxPiView.TabIndex = 0;
			// 
			// panelStatus
			// 
			this.panelStatus.Controls.Add(this.labelPositionValue);
			this.panelStatus.Controls.Add(this.labelPosition);
			this.panelStatus.Controls.Add(this.indexer1);
			this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelStatus.Location = new System.Drawing.Point(0, 430);
			this.panelStatus.Name = "panelStatus";
			this.panelStatus.Size = new System.Drawing.Size(401, 38);
			this.panelStatus.TabIndex = 1;
			// 
			// labelPositionValue
			// 
			this.labelPositionValue.AutoSize = true;
			this.labelPositionValue.Location = new System.Drawing.Point(282, 3);
			this.labelPositionValue.Name = "labelPositionValue";
			this.labelPositionValue.Size = new System.Drawing.Size(13, 13);
			this.labelPositionValue.TabIndex = 2;
			this.labelPositionValue.Text = "0";
			// 
			// labelPosition
			// 
			this.labelPosition.AutoSize = true;
			this.labelPosition.Location = new System.Drawing.Point(206, 3);
			this.labelPosition.Name = "labelPosition";
			this.labelPosition.Size = new System.Drawing.Size(70, 13);
			this.labelPosition.TabIndex = 1;
			this.labelPosition.Text = "Digit position:";
			// 
			// indexer1
			// 
			this.indexer1.Location = new System.Drawing.Point(3, 3);
			this.indexer1.Name = "indexer1";
			this.indexer1.Size = new System.Drawing.Size(197, 31);
			this.indexer1.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(401, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decimalToolStripMenuItem,
            this.hexToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// decimalToolStripMenuItem
			// 
			this.decimalToolStripMenuItem.Checked = true;
			this.decimalToolStripMenuItem.CheckOnClick = true;
			this.decimalToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.decimalToolStripMenuItem.Name = "decimalToolStripMenuItem";
			this.decimalToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.decimalToolStripMenuItem.Text = "Decimal";
			// 
			// hexToolStripMenuItem
			// 
			this.hexToolStripMenuItem.CheckOnClick = true;
			this.hexToolStripMenuItem.Name = "hexToolStripMenuItem";
			this.hexToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.hexToolStripMenuItem.Text = "Hexadecimal";
			this.hexToolStripMenuItem.Click += new System.EventHandler(this.hexToolStripMenuItem_Click);
			// 
			// PiViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 468);
			this.Controls.Add(this.panelStatus);
			this.Controls.Add(this.textBoxPiView);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "PiViewer";
			this.Text = "PiViewer";
			this.Load += new System.EventHandler(this.PiViewer_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PiViewer_FormClosing);
			this.panelStatus.ResumeLayout(false);
			this.panelStatus.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxPiView;
		private System.Windows.Forms.Panel panelStatus;
		private pi_counter_ui.Controls.Indexer indexer1;
		private System.Windows.Forms.Label labelPositionValue;
		private System.Windows.Forms.Label labelPosition;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hexToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem decimalToolStripMenuItem;
	}
}