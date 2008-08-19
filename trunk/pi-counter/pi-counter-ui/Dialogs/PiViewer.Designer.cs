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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PiViewer));
			this.textBoxPiView = new System.Windows.Forms.TextBox();
			this.panelStatus = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelPositionValue = new System.Windows.Forms.Label();
			this.labelPosition = new System.Windows.Forms.Label();
			this.indexer = new pi_counter_ui.Controls.Indexer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.fieldDecimal = new System.Windows.Forms.RadioButton();
			this.fieldHexadecimal = new System.Windows.Forms.RadioButton();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panelStatus.SuspendLayout();
			this.panel1.SuspendLayout();
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
			this.panelStatus.Controls.Add(this.panel1);
			this.panelStatus.Controls.Add(this.indexer);
			this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelStatus.Location = new System.Drawing.Point(0, 430);
			this.panelStatus.Name = "panelStatus";
			this.panelStatus.Size = new System.Drawing.Size(410, 38);
			this.panelStatus.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.labelPositionValue);
			this.panel1.Controls.Add(this.labelPosition);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(215, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(195, 38);
			this.panel1.TabIndex = 3;
			// 
			// labelPositionValue
			// 
			this.labelPositionValue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelPositionValue.Location = new System.Drawing.Point(75, 0);
			this.labelPositionValue.Name = "labelPositionValue";
			this.labelPositionValue.Size = new System.Drawing.Size(120, 38);
			this.labelPositionValue.TabIndex = 2;
			this.labelPositionValue.Text = "0";
			this.labelPositionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip1.SetToolTip(this.labelPositionValue, "Use a mouse pointer to choose a\r\ndigit which position is to be shown.");
			// 
			// labelPosition
			// 
			this.labelPosition.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelPosition.Location = new System.Drawing.Point(0, 0);
			this.labelPosition.Name = "labelPosition";
			this.labelPosition.Size = new System.Drawing.Size(75, 38);
			this.labelPosition.TabIndex = 1;
			this.labelPosition.Text = "Digit position:";
			this.labelPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip1.SetToolTip(this.labelPosition, "Use a mouse pointer to choose a\r\ndigit which position is to be shown.");
			// 
			// indexer
			// 
			this.indexer.AutoSize = true;
			this.indexer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.indexer.Dock = System.Windows.Forms.DockStyle.Left;
			this.indexer.Location = new System.Drawing.Point(0, 0);
			this.indexer.Name = "indexer";
			this.indexer.PageCurrent = ((ulong)(1ul));
			this.indexer.PagesCount = ((ulong)(1586876856ul));
			this.indexer.Size = new System.Drawing.Size(215, 38);
			this.indexer.TabIndex = 0;
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
			this.toolTip1.SetToolTip(this.flowLayoutPanel1, "Use this to change view style");
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
			this.panel1.ResumeLayout(false);
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
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}