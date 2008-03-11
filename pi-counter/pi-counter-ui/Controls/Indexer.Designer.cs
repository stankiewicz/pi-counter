namespace pi_counter_ui.Controls {
	partial class Indexer {
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
			this.buttonPrev = new System.Windows.Forms.Button();
			this.buttonNext = new System.Windows.Forms.Button();
			this.labelOf = new System.Windows.Forms.Label();
			this.labelIndexMax = new System.Windows.Forms.Label();
			this.maskedTextBoxIndex = new System.Windows.Forms.MaskedTextBox();
			this.SuspendLayout();
			// 
			// buttonPrev
			// 
			this.buttonPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPrev.Location = new System.Drawing.Point(3, 3);
			this.buttonPrev.Name = "buttonPrev";
			this.buttonPrev.Size = new System.Drawing.Size(25, 23);
			this.buttonPrev.TabIndex = 0;
			this.buttonPrev.Text = "<";
			this.buttonPrev.UseVisualStyleBackColor = true;
			// 
			// buttonNext
			// 
			this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonNext.Location = new System.Drawing.Point(167, 3);
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.Size = new System.Drawing.Size(25, 23);
			this.buttonNext.TabIndex = 1;
			this.buttonNext.Text = ">";
			this.buttonNext.UseVisualStyleBackColor = true;
			// 
			// labelOf
			// 
			this.labelOf.AutoSize = true;
			this.labelOf.Location = new System.Drawing.Point(106, 8);
			this.labelOf.Name = "labelOf";
			this.labelOf.Size = new System.Drawing.Size(12, 13);
			this.labelOf.TabIndex = 3;
			this.labelOf.Text = "/";
			this.labelOf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelIndexMax
			// 
			this.labelIndexMax.AutoSize = true;
			this.labelIndexMax.Location = new System.Drawing.Point(124, 8);
			this.labelIndexMax.Name = "labelIndexMax";
			this.labelIndexMax.Size = new System.Drawing.Size(37, 13);
			this.labelIndexMax.TabIndex = 4;
			this.labelIndexMax.Text = "50000";
			// 
			// maskedTextBoxIndex
			// 
			this.maskedTextBoxIndex.AllowPromptAsInput = false;
			this.maskedTextBoxIndex.Location = new System.Drawing.Point(34, 5);
			this.maskedTextBoxIndex.Name = "maskedTextBoxIndex";
			this.maskedTextBoxIndex.RejectInputOnFirstFailure = true;
			this.maskedTextBoxIndex.Size = new System.Drawing.Size(66, 20);
			this.maskedTextBoxIndex.TabIndex = 5;
			this.maskedTextBoxIndex.Text = "50000";
			// 
			// Indexer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.buttonNext);
			this.Controls.Add(this.labelIndexMax);
			this.Controls.Add(this.labelOf);
			this.Controls.Add(this.maskedTextBoxIndex);
			this.Controls.Add(this.buttonPrev);
			this.Name = "Indexer";
			this.Size = new System.Drawing.Size(197, 31);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonPrev;
		private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.Label labelOf;
		private System.Windows.Forms.Label labelIndexMax;
		private System.Windows.Forms.MaskedTextBox maskedTextBoxIndex;
	}
}
