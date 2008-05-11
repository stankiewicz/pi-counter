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
			this.indexer = new pi_counter_ui.Controls.Indexer();
			this.fieldText = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// indexer
			// 
			this.indexer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.indexer.AutoSize = true;
			this.indexer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.indexer.Location = new System.Drawing.Point(336, 0);
			this.indexer.Name = "indexer";
			this.indexer.PageCurrent = ((ulong)(0ul));
			this.indexer.PagesCount = ((ulong)(0ul));
			this.indexer.Size = new System.Drawing.Size(186, 26);
			this.indexer.TabIndex = 0;
			// 
			// textBox1
			// 
			this.fieldText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.fieldText.Location = new System.Drawing.Point(0, 0);
			this.fieldText.Name = "textBox1";
			this.fieldText.Size = new System.Drawing.Size(330, 20);
			this.fieldText.TabIndex = 1;
			this.fieldText.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
			// 
			// PagedText
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.indexer);
			this.Controls.Add(this.fieldText);
			this.Name = "PagedText";
			this.Size = new System.Drawing.Size(522, 24);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Indexer indexer;
		private System.Windows.Forms.TextBox fieldText;
	}
}
