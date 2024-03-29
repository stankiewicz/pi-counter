namespace pi_counter_ui.Controls {
	partial class Constraints {
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
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.numericUpDownConstraintLength = new System.Windows.Forms.NumericUpDown();
			this.cbConstraintLength = new System.Windows.Forms.CheckBox();
			this.cbConstraintTime = new System.Windows.Forms.CheckBox();
			this.numericUpDownConstraintTime = new System.Windows.Forms.NumericUpDown();
			this.labelConstraintLength = new System.Windows.Forms.Label();
			this.labelConstraintTime = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownConstraintLength)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownConstraintTime)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox
			// 
			this.groupBox.Controls.Add(this.numericUpDownConstraintLength);
			this.groupBox.Controls.Add(this.cbConstraintLength);
			this.groupBox.Controls.Add(this.cbConstraintTime);
			this.groupBox.Controls.Add(this.numericUpDownConstraintTime);
			this.groupBox.Controls.Add(this.labelConstraintLength);
			this.groupBox.Controls.Add(this.labelConstraintTime);
			this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox.Location = new System.Drawing.Point(0, 0);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(276, 79);
			this.groupBox.TabIndex = 0;
			this.groupBox.TabStop = false;
			this.groupBox.Text = "Constraints";
			this.toolTip1.SetToolTip(this.groupBox, "Here you can specify constraints for operation.\r\nUse \'time constraint\' to limit t" +
					"he time of operation,\r\nor use \'pi length constraint\' to limit operation using\r\nn" +
					"umber of processed digits.");
			// 
			// numericUpDownConstraintLength
			// 
			this.numericUpDownConstraintLength.Location = new System.Drawing.Point(158, 45);
			this.numericUpDownConstraintLength.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.numericUpDownConstraintLength.Name = "numericUpDownConstraintLength";
			this.numericUpDownConstraintLength.Size = new System.Drawing.Size(112, 20);
			this.numericUpDownConstraintLength.TabIndex = 5;
			this.numericUpDownConstraintLength.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			// 
			// cbConstraintLength
			// 
			this.cbConstraintLength.AutoSize = true;
			this.cbConstraintLength.Location = new System.Drawing.Point(6, 47);
			this.cbConstraintLength.Name = "cbConstraintLength";
			this.cbConstraintLength.Size = new System.Drawing.Size(117, 17);
			this.cbConstraintLength.TabIndex = 4;
			this.cbConstraintLength.Text = "Π length constraint:";
			this.cbConstraintLength.UseVisualStyleBackColor = true;
			this.cbConstraintLength.CheckedChanged += new System.EventHandler(this.cbConstraintLength_CheckedChanged);
			// 
			// cbConstraintTime
			// 
			this.cbConstraintTime.AutoSize = true;
			this.cbConstraintTime.Location = new System.Drawing.Point(6, 19);
			this.cbConstraintTime.Name = "cbConstraintTime";
			this.cbConstraintTime.Size = new System.Drawing.Size(146, 17);
			this.cbConstraintTime.TabIndex = 3;
			this.cbConstraintTime.Text = "Time constraint (minutes):";
			this.cbConstraintTime.UseVisualStyleBackColor = true;
			this.cbConstraintTime.CheckedChanged += new System.EventHandler(this.cbConstraintTime_CheckedChanged);
			// 
			// numericUpDownConstraintTime
			// 
			this.numericUpDownConstraintTime.Location = new System.Drawing.Point(158, 16);
			this.numericUpDownConstraintTime.Maximum = new decimal(new int[] {
            36000,
            0,
            0,
            0});
			this.numericUpDownConstraintTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownConstraintTime.Name = "numericUpDownConstraintTime";
			this.numericUpDownConstraintTime.Size = new System.Drawing.Size(112, 20);
			this.numericUpDownConstraintTime.TabIndex = 2;
			this.numericUpDownConstraintTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// labelConstraintLength
			// 
			this.labelConstraintLength.AutoSize = true;
			this.labelConstraintLength.Location = new System.Drawing.Point(52, 47);
			this.labelConstraintLength.Name = "labelConstraintLength";
			this.labelConstraintLength.Size = new System.Drawing.Size(0, 13);
			this.labelConstraintLength.TabIndex = 1;
			// 
			// labelConstraintTime
			// 
			this.labelConstraintTime.AutoSize = true;
			this.labelConstraintTime.Location = new System.Drawing.Point(52, 18);
			this.labelConstraintTime.Name = "labelConstraintTime";
			this.labelConstraintTime.Size = new System.Drawing.Size(0, 13);
			this.labelConstraintTime.TabIndex = 0;
			// 
			// Constraints
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox);
			this.Name = "Constraints";
			this.Size = new System.Drawing.Size(276, 79);
			this.groupBox.ResumeLayout(false);
			this.groupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownConstraintLength)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownConstraintTime)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox;
		private System.Windows.Forms.Label labelConstraintLength;
		private System.Windows.Forms.Label labelConstraintTime;
		private System.Windows.Forms.NumericUpDown numericUpDownConstraintTime;
		private System.Windows.Forms.CheckBox cbConstraintLength;
		private System.Windows.Forms.CheckBox cbConstraintTime;
		private System.Windows.Forms.NumericUpDown numericUpDownConstraintLength;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}
