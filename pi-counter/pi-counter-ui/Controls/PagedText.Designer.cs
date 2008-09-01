namespace pi_counter_ui.Controls {
	partial class PagedText {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.fieldText = new System.Windows.Forms.RichTextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.fieldIndex = new System.Windows.Forms.NumericUpDown();
			this.fieldLength = new System.Windows.Forms.NumericUpDown();
			this.btnClear = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.fieldBufferLength = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.fieldDotPos = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(this.fieldIndex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fieldLength)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// fieldText
			// 
			this.fieldText.DetectUrls = false;
			this.fieldText.Dock = System.Windows.Forms.DockStyle.Left;
			this.fieldText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.fieldText.Location = new System.Drawing.Point(3, 3);
			this.fieldText.Multiline = false;
			this.fieldText.Name = "fieldText";
			this.fieldText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.fieldText.ShortcutsEnabled = false;
			this.fieldText.Size = new System.Drawing.Size(533, 23);
			this.fieldText.TabIndex = 1;
			this.fieldText.Text = "";
			this.toolTip1.SetToolTip(this.fieldText, "This field usually shows only a part of a number.\r\nUse indexer on the right side " +
					"to scroll through\r\nthe rest of the number.");
			this.fieldText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fieldText_KeyPress);
			this.fieldText.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
			// 
			// fieldIndex
			// 
			this.fieldIndex.Dock = System.Windows.Forms.DockStyle.Left;
			this.fieldIndex.Location = new System.Drawing.Point(542, 3);
			this.fieldIndex.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.fieldIndex.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
			this.fieldIndex.Name = "fieldIndex";
			this.fieldIndex.Size = new System.Drawing.Size(93, 20);
			this.fieldIndex.TabIndex = 2;
			this.toolTip1.SetToolTip(this.fieldIndex, "Starting index");
			// 
			// fieldLength
			// 
			this.fieldLength.Dock = System.Windows.Forms.DockStyle.Left;
			this.fieldLength.Location = new System.Drawing.Point(641, 3);
			this.fieldLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.fieldLength.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.fieldLength.Name = "fieldLength";
			this.fieldLength.Size = new System.Drawing.Size(54, 20);
			this.fieldLength.TabIndex = 3;
			this.toolTip1.SetToolTip(this.fieldLength, "Number of digits to display");
			this.fieldLength.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(701, 3);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(21, 23);
			this.btnClear.TabIndex = 8;
			this.btnClear.Text = "C";
			this.toolTip1.SetToolTip(this.btnClear, "Clears whole text");
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(725, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 29);
			this.label1.TabIndex = 4;
			this.label1.Text = "Length:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// fieldBufferLength
			// 
			this.fieldBufferLength.AutoSize = true;
			this.fieldBufferLength.Dock = System.Windows.Forms.DockStyle.Left;
			this.fieldBufferLength.Location = new System.Drawing.Point(768, 0);
			this.fieldBufferLength.Margin = new System.Windows.Forms.Padding(0);
			this.fieldBufferLength.Name = "fieldBufferLength";
			this.fieldBufferLength.Size = new System.Drawing.Size(25, 29);
			this.fieldBufferLength.TabIndex = 5;
			this.fieldBufferLength.Text = "543";
			this.fieldBufferLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(793, 0);
			this.label2.Margin = new System.Windows.Forms.Padding(0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(27, 29);
			this.label2.TabIndex = 6;
			this.label2.Text = "Dot:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// fieldDotPos
			// 
			this.fieldDotPos.AutoSize = true;
			this.fieldDotPos.Dock = System.Windows.Forms.DockStyle.Left;
			this.fieldDotPos.Location = new System.Drawing.Point(820, 0);
			this.fieldDotPos.Margin = new System.Windows.Forms.Padding(0);
			this.fieldDotPos.Name = "fieldDotPos";
			this.fieldDotPos.Size = new System.Drawing.Size(35, 29);
			this.fieldDotPos.TabIndex = 7;
			this.fieldDotPos.Text = "label3";
			this.fieldDotPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.fieldText);
			this.flowLayoutPanel1.Controls.Add(this.fieldIndex);
			this.flowLayoutPanel1.Controls.Add(this.fieldLength);
			this.flowLayoutPanel1.Controls.Add(this.btnClear);
			this.flowLayoutPanel1.Controls.Add(this.label1);
			this.flowLayoutPanel1.Controls.Add(this.fieldBufferLength);
			this.flowLayoutPanel1.Controls.Add(this.label2);
			this.flowLayoutPanel1.Controls.Add(this.fieldDotPos);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 6);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(855, 29);
			this.flowLayoutPanel1.TabIndex = 8;
			// 
			// PagedText
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "PagedText";
			this.Size = new System.Drawing.Size(861, 38);
			((System.ComponentModel.ISupportInitialize)(this.fieldIndex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fieldLength)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.NumericUpDown fieldIndex;
		private System.Windows.Forms.NumericUpDown fieldLength;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label fieldBufferLength;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label fieldDotPos;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button btnClear;
		public System.Windows.Forms.RichTextBox fieldText;
	}
}
