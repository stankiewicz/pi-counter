namespace pi_counter_ui.Controls {
	partial class Search {
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
			this.groupBoxSearch = new System.Windows.Forms.GroupBox();
			this.labelTo = new System.Windows.Forms.Label();
			this.labelFrom = new System.Windows.Forms.Label();
			this.numericUpDownFrom = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownTo = new System.Windows.Forms.NumericUpDown();
			this.groupBoxSearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTo)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxSearch
			// 
			this.groupBoxSearch.Controls.Add(this.numericUpDownTo);
			this.groupBoxSearch.Controls.Add(this.numericUpDownFrom);
			this.groupBoxSearch.Controls.Add(this.labelTo);
			this.groupBoxSearch.Controls.Add(this.labelFrom);
			this.groupBoxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxSearch.Location = new System.Drawing.Point(0, 0);
			this.groupBoxSearch.Name = "groupBoxSearch";
			this.groupBoxSearch.Size = new System.Drawing.Size(241, 83);
			this.groupBoxSearch.TabIndex = 1;
			this.groupBoxSearch.TabStop = false;
			this.groupBoxSearch.Text = "Search range";
			// 
			// labelTo
			// 
			this.labelTo.AutoSize = true;
			this.labelTo.Location = new System.Drawing.Point(6, 52);
			this.labelTo.Name = "labelTo";
			this.labelTo.Size = new System.Drawing.Size(23, 13);
			this.labelTo.TabIndex = 1;
			this.labelTo.Text = "To:";
			// 
			// labelFrom
			// 
			this.labelFrom.AutoSize = true;
			this.labelFrom.Location = new System.Drawing.Point(6, 25);
			this.labelFrom.Name = "labelFrom";
			this.labelFrom.Size = new System.Drawing.Size(33, 13);
			this.labelFrom.TabIndex = 0;
			this.labelFrom.Text = "From:";
			// 
			// numericUpDownFrom
			// 
			this.numericUpDownFrom.Location = new System.Drawing.Point(45, 23);
			this.numericUpDownFrom.Name = "numericUpDownFrom";
			this.numericUpDownFrom.Size = new System.Drawing.Size(185, 20);
			this.numericUpDownFrom.TabIndex = 2;
			// 
			// numericUpDownTo
			// 
			this.numericUpDownTo.Location = new System.Drawing.Point(45, 50);
			this.numericUpDownTo.Name = "numericUpDownTo";
			this.numericUpDownTo.Size = new System.Drawing.Size(185, 20);
			this.numericUpDownTo.TabIndex = 3;
			// 
			// Search
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBoxSearch);
			this.Name = "Search";
			this.Size = new System.Drawing.Size(241, 83);
			this.groupBoxSearch.ResumeLayout(false);
			this.groupBoxSearch.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTo)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxSearch;
		private System.Windows.Forms.NumericUpDown numericUpDownFrom;
		private System.Windows.Forms.Label labelTo;
		private System.Windows.Forms.Label labelFrom;
		private System.Windows.Forms.NumericUpDown numericUpDownTo;
	}
}
