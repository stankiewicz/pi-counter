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
			this.fieldMaxPage = new System.Windows.Forms.Label();
			this.fieldPage = new System.Windows.Forms.MaskedTextBox();
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
			this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
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
			this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
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
			// fieldMaxPage
			// 
			this.fieldMaxPage.AutoSize = true;
			this.fieldMaxPage.Location = new System.Drawing.Point(124, 8);
			this.fieldMaxPage.Name = "fieldMaxPage";
			this.fieldMaxPage.Size = new System.Drawing.Size(37, 13);
			this.fieldMaxPage.TabIndex = 4;
			this.fieldMaxPage.Text = "50000";
			// 
			// fieldPage
			// 
			this.fieldPage.AllowPromptAsInput = false;
			this.fieldPage.Location = new System.Drawing.Point(34, 5);
			this.fieldPage.Name = "fieldPage";
			this.fieldPage.RejectInputOnFirstFailure = true;
			this.fieldPage.Size = new System.Drawing.Size(66, 20);
			this.fieldPage.TabIndex = 5;
			this.fieldPage.Text = "50000";
			// 
			// Indexer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.buttonNext);
			this.Controls.Add(this.fieldMaxPage);
			this.Controls.Add(this.labelOf);
			this.Controls.Add(this.fieldPage);
			this.Controls.Add(this.buttonPrev);
			this.Name = "Indexer";
			this.Size = new System.Drawing.Size(197, 31);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelOf;
		private System.Windows.Forms.Label fieldMaxPage;
		private System.Windows.Forms.MaskedTextBox fieldPage;
		private System.Windows.Forms.Button buttonPrev;
		private System.Windows.Forms.Button buttonNext;
	}
}
