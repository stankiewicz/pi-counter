namespace pi_counter_ui.Controls {
	partial class CalculationStatus {
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
			this.labelFound = new System.Windows.Forms.Label();
			this.groupBoxCalculations = new System.Windows.Forms.GroupBox();
			this.buttonResult = new System.Windows.Forms.Button();
			this.buttonStart = new System.Windows.Forms.Button();
			this.panelFound = new System.Windows.Forms.Panel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.labelFoundCount = new System.Windows.Forms.Label();
			this.labelFoundOf = new System.Windows.Forms.Label();
			this.labelFoundMax = new System.Windows.Forms.Label();
			this.panelLengthConstraint = new System.Windows.Forms.Panel();
			this.labelConstraintLength = new System.Windows.Forms.Label();
			this.progressBarLength = new System.Windows.Forms.ProgressBar();
			this.panelTimeConstraint = new System.Windows.Forms.Panel();
			this.labelConstraintTime = new System.Windows.Forms.Label();
			this.progressBarTime = new System.Windows.Forms.ProgressBar();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.groupBoxCalculations.SuspendLayout();
			this.panelFound.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.panelLengthConstraint.SuspendLayout();
			this.panelTimeConstraint.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelFound
			// 
			this.labelFound.AutoSize = true;
			this.labelFound.Location = new System.Drawing.Point(3, 0);
			this.labelFound.Name = "labelFound";
			this.labelFound.Size = new System.Drawing.Size(40, 13);
			this.labelFound.TabIndex = 1;
			this.labelFound.Text = "Found:";
			// 
			// groupBoxCalculations
			// 
			this.groupBoxCalculations.Controls.Add(this.buttonResult);
			this.groupBoxCalculations.Controls.Add(this.buttonStart);
			this.groupBoxCalculations.Controls.Add(this.panelFound);
			this.groupBoxCalculations.Controls.Add(this.panelLengthConstraint);
			this.groupBoxCalculations.Controls.Add(this.panelTimeConstraint);
			this.groupBoxCalculations.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxCalculations.Location = new System.Drawing.Point(0, 0);
			this.groupBoxCalculations.Name = "groupBoxCalculations";
			this.groupBoxCalculations.Size = new System.Drawing.Size(398, 117);
			this.groupBoxCalculations.TabIndex = 2;
			this.groupBoxCalculations.TabStop = false;
			this.groupBoxCalculations.Text = "Calculations";
			this.toolTip1.SetToolTip(this.groupBoxCalculations, "This area indicates status of current operation");
			// 
			// buttonResult
			// 
			this.buttonResult.Location = new System.Drawing.Point(87, 86);
			this.buttonResult.Name = "buttonResult";
			this.buttonResult.Size = new System.Drawing.Size(75, 23);
			this.buttonResult.TabIndex = 10;
			this.buttonResult.Text = "Result";
			this.buttonResult.UseVisualStyleBackColor = true;
			this.buttonResult.Visible = false;
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(6, 86);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 9;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			// 
			// panelFound
			// 
			this.panelFound.Controls.Add(this.flowLayoutPanel1);
			this.panelFound.Location = new System.Drawing.Point(6, 58);
			this.panelFound.Name = "panelFound";
			this.panelFound.Size = new System.Drawing.Size(386, 22);
			this.panelFound.TabIndex = 8;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.labelFound);
			this.flowLayoutPanel1.Controls.Add(this.labelFoundCount);
			this.flowLayoutPanel1.Controls.Add(this.labelFoundOf);
			this.flowLayoutPanel1.Controls.Add(this.labelFoundMax);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(386, 22);
			this.flowLayoutPanel1.TabIndex = 5;
			// 
			// labelFoundCount
			// 
			this.labelFoundCount.AutoSize = true;
			this.labelFoundCount.Location = new System.Drawing.Point(49, 0);
			this.labelFoundCount.Name = "labelFoundCount";
			this.labelFoundCount.Size = new System.Drawing.Size(14, 13);
			this.labelFoundCount.TabIndex = 2;
			this.labelFoundCount.Text = "X";
			// 
			// labelFoundOf
			// 
			this.labelFoundOf.AutoSize = true;
			this.labelFoundOf.Location = new System.Drawing.Point(69, 0);
			this.labelFoundOf.Name = "labelFoundOf";
			this.labelFoundOf.Size = new System.Drawing.Size(16, 13);
			this.labelFoundOf.TabIndex = 3;
			this.labelFoundOf.Text = "of";
			// 
			// labelFoundMax
			// 
			this.labelFoundMax.AutoSize = true;
			this.labelFoundMax.Location = new System.Drawing.Point(91, 0);
			this.labelFoundMax.Name = "labelFoundMax";
			this.labelFoundMax.Size = new System.Drawing.Size(14, 13);
			this.labelFoundMax.TabIndex = 4;
			this.labelFoundMax.Text = "Y";
			// 
			// panelLengthConstraint
			// 
			this.panelLengthConstraint.Controls.Add(this.labelConstraintLength);
			this.panelLengthConstraint.Controls.Add(this.progressBarLength);
			this.panelLengthConstraint.Location = new System.Drawing.Point(6, 36);
			this.panelLengthConstraint.Name = "panelLengthConstraint";
			this.panelLengthConstraint.Size = new System.Drawing.Size(386, 22);
			this.panelLengthConstraint.TabIndex = 7;
			// 
			// labelConstraintLength
			// 
			this.labelConstraintLength.AutoSize = true;
			this.labelConstraintLength.Location = new System.Drawing.Point(3, 0);
			this.labelConstraintLength.Name = "labelConstraintLength";
			this.labelConstraintLength.Size = new System.Drawing.Size(92, 13);
			this.labelConstraintLength.TabIndex = 4;
			this.labelConstraintLength.Text = "Length constraint:";
			// 
			// progressBarLength
			// 
			this.progressBarLength.Location = new System.Drawing.Point(106, 0);
			this.progressBarLength.Name = "progressBarLength";
			this.progressBarLength.Size = new System.Drawing.Size(277, 16);
			this.progressBarLength.TabIndex = 5;
			// 
			// panelTimeConstraint
			// 
			this.panelTimeConstraint.Controls.Add(this.labelConstraintTime);
			this.panelTimeConstraint.Controls.Add(this.progressBarTime);
			this.panelTimeConstraint.Location = new System.Drawing.Point(6, 14);
			this.panelTimeConstraint.Name = "panelTimeConstraint";
			this.panelTimeConstraint.Size = new System.Drawing.Size(386, 22);
			this.panelTimeConstraint.TabIndex = 6;
			// 
			// labelConstraintTime
			// 
			this.labelConstraintTime.AutoSize = true;
			this.labelConstraintTime.Location = new System.Drawing.Point(3, 0);
			this.labelConstraintTime.Name = "labelConstraintTime";
			this.labelConstraintTime.Size = new System.Drawing.Size(82, 13);
			this.labelConstraintTime.TabIndex = 2;
			this.labelConstraintTime.Text = "Time constraint:";
			// 
			// progressBarTime
			// 
			this.progressBarTime.Location = new System.Drawing.Point(106, 0);
			this.progressBarTime.Name = "progressBarTime";
			this.progressBarTime.Size = new System.Drawing.Size(277, 16);
			this.progressBarTime.TabIndex = 3;
			// 
			// CalculationStatus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBoxCalculations);
			this.Name = "CalculationStatus";
			this.Size = new System.Drawing.Size(398, 117);
			this.groupBoxCalculations.ResumeLayout(false);
			this.panelFound.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.panelLengthConstraint.ResumeLayout(false);
			this.panelLengthConstraint.PerformLayout();
			this.panelTimeConstraint.ResumeLayout(false);
			this.panelTimeConstraint.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label labelFound;
		private System.Windows.Forms.GroupBox groupBoxCalculations;
		private System.Windows.Forms.Label labelConstraintTime;
		private System.Windows.Forms.Panel panelFound;
		private System.Windows.Forms.Label labelFoundCount;
		private System.Windows.Forms.Panel panelLengthConstraint;
		private System.Windows.Forms.Label labelConstraintLength;
		private System.Windows.Forms.Panel panelTimeConstraint;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Label labelFoundOf;
		private System.Windows.Forms.Label labelFoundMax;
		public System.Windows.Forms.Button buttonResult;
		public System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.ProgressBar progressBarTime;
		private System.Windows.Forms.ProgressBar progressBarLength;
		private System.Windows.Forms.ToolTip toolTip1;


	}
}
