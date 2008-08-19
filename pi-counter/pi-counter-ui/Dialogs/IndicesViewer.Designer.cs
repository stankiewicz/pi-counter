namespace pi_counter_ui.Dialogs {
	partial class IndicesViewer {
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.indexer = new pi_counter_ui.Controls.Indexer();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Controls.Add(this.indexer);
			this.splitContainer1.Size = new System.Drawing.Size(663, 500);
			this.splitContainer1.SplitterDistance = 458;
			this.splitContainer1.TabIndex = 0;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(663, 458);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(473, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(182, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Format: [searched string] : [first index]";
			// 
			// indexer
			// 
			this.indexer.AutoSize = true;
			this.indexer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.indexer.Location = new System.Drawing.Point(3, 3);
			this.indexer.Name = "indexer";
			this.indexer.PageCurrent = ((ulong)(1ul));
			this.indexer.PagesCount = ((ulong)(1ul));
			this.indexer.Size = new System.Drawing.Size(161, 29);
			this.indexer.TabIndex = 0;
			// 
			// IndicesViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(663, 500);
			this.Controls.Add(this.splitContainer1);
			this.DoubleBuffered = true;
			this.Name = "IndicesViewer";
			this.Text = "IndicesViewer";
			this.Load += new System.EventHandler(this.IndicesViewer_Load);
			this.VisibleChanged += new System.EventHandler(this.IndicesViewer_VisibleChanged);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IndicesViewer_FormClosing);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private pi_counter_ui.Controls.Indexer indexer;
		private System.Windows.Forms.Label label1;
	}
}