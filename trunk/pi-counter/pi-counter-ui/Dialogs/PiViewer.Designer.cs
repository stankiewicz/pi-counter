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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PiViewer));
			this.textBoxPiView = new System.Windows.Forms.TextBox();
			this.panelStatus = new System.Windows.Forms.Panel();
			this.labelPositionValue = new System.Windows.Forms.Label();
			this.labelPosition = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.fieldDecimal = new System.Windows.Forms.RadioButton();
			this.fieldHexadecimal = new System.Windows.Forms.RadioButton();
			this.indexer = new pi_counter_ui.Controls.Indexer();
			this.panelStatus.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxPiView
			// 
			this.textBoxPiView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPiView.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.textBoxPiView.Location = new System.Drawing.Point(6, 48);
			this.textBoxPiView.Multiline = true;
			this.textBoxPiView.Name = "textBoxPiView";
			this.textBoxPiView.ReadOnly = true;
			this.textBoxPiView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxPiView.Size = new System.Drawing.Size(401, 376);
			this.textBoxPiView.TabIndex = 0;
			this.textBoxPiView.Text = resources.GetString("textBoxPiView.Text");
			this.textBoxPiView.WordWrap = false;
			this.textBoxPiView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.textBoxPiView_MouseMove);
			// 
			// panelStatus
			// 
			this.panelStatus.Controls.Add(this.labelPositionValue);
			this.panelStatus.Controls.Add(this.labelPosition);
			this.panelStatus.Controls.Add(this.indexer);
			this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelStatus.Location = new System.Drawing.Point(0, 430);
			this.panelStatus.Name = "panelStatus";
			this.panelStatus.Size = new System.Drawing.Size(410, 38);
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.flowLayoutPanel1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(410, 42);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "View style";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.fieldDecimal);
			this.flowLayoutPanel1.Controls.Add(this.fieldHexadecimal);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(404, 23);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// fieldDecimal
			// 
			this.fieldDecimal.AutoSize = true;
			this.fieldDecimal.Location = new System.Drawing.Point(3, 3);
			this.fieldDecimal.Name = "fieldDecimal";
			this.fieldDecimal.Size = new System.Drawing.Size(63, 17);
			this.fieldDecimal.TabIndex = 0;
			this.fieldDecimal.TabStop = true;
			this.fieldDecimal.Text = "Decimal";
			this.fieldDecimal.UseVisualStyleBackColor = true;
			this.fieldDecimal.CheckedChanged += new System.EventHandler(this.viewStyleChanged);
			// 
			// fieldHexadecimal
			// 
			this.fieldHexadecimal.AutoSize = true;
			this.fieldHexadecimal.Location = new System.Drawing.Point(72, 3);
			this.fieldHexadecimal.Name = "fieldHexadecimal";
			this.fieldHexadecimal.Size = new System.Drawing.Size(86, 17);
			this.fieldHexadecimal.TabIndex = 1;
			this.fieldHexadecimal.TabStop = true;
			this.fieldHexadecimal.Text = "Hexadecimal";
			this.fieldHexadecimal.UseVisualStyleBackColor = true;
			this.fieldHexadecimal.CheckedChanged += new System.EventHandler(this.viewStyleChanged);
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
			// PiViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(410, 468);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panelStatus);
			this.Controls.Add(this.textBoxPiView);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "PiViewer";
			this.Text = "PiViewer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PiViewer_FormClosing);
			this.panelStatus.ResumeLayout(false);
			this.panelStatus.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxPiView;
		private System.Windows.Forms.Panel panelStatus;
		private pi_counter_ui.Controls.Indexer indexer;
		private System.Windows.Forms.Label labelPositionValue;
		private System.Windows.Forms.Label labelPosition;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.RadioButton fieldDecimal;
		private System.Windows.Forms.RadioButton fieldHexadecimal;
	}
}