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
			this.fieldText = new System.Windows.Forms.TextBox();
			this.indexer = new pi_counter_ui.Controls.Indexer();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// fieldText
			// 
			this.fieldText.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.fieldText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.fieldText.Location = new System.Drawing.Point(3, 5);
			this.fieldText.MaxLength = 2000000000;
			this.fieldText.Name = "fieldText";
			this.fieldText.Size = new System.Drawing.Size(533, 20);
			this.fieldText.TabIndex = 1;
			this.toolTip1.SetToolTip(this.fieldText, "This field usually shows only a part of a number.\r\nUse indexer on the right side " +
					"to scroll through\r\nthe rest of the number.");
			this.fieldText.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
			// 
			// indexer
			// 
			this.indexer.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.indexer.AutoSize = true;
			this.indexer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.indexer.Location = new System.Drawing.Point(542, 1);
			this.indexer.Name = "indexer";
			this.indexer.PageCurrent = ((ulong)(1ul));
			this.indexer.PagesCount = ((ulong)(1343434ul));
			this.indexer.Size = new System.Drawing.Size(197, 29);
			this.indexer.TabIndex = 1;
			// 
			// PagedText
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.fieldText);
			this.Controls.Add(this.indexer);
			this.Name = "PagedText";
			this.Size = new System.Drawing.Size(742, 33);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Indexer indexer;
		private System.Windows.Forms.TextBox fieldText;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}
