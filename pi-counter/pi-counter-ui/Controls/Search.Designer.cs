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
			this.components = new System.ComponentModel.Container();
			this.groupBoxSearch = new System.Windows.Forms.GroupBox();
			this.fieldTo = new System.Windows.Forms.TextBox();
			this.fieldFrom = new System.Windows.Forms.TextBox();
			this.labelTo = new System.Windows.Forms.Label();
			this.labelFrom = new System.Windows.Forms.Label();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.groupBoxSearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxSearch
			// 
			this.groupBoxSearch.Controls.Add(this.fieldTo);
			this.groupBoxSearch.Controls.Add(this.fieldFrom);
			this.groupBoxSearch.Controls.Add(this.labelTo);
			this.groupBoxSearch.Controls.Add(this.labelFrom);
			this.groupBoxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxSearch.Location = new System.Drawing.Point(0, 0);
			this.groupBoxSearch.Name = "groupBoxSearch";
			this.groupBoxSearch.Size = new System.Drawing.Size(267, 80);
			this.groupBoxSearch.TabIndex = 1;
			this.groupBoxSearch.TabStop = false;
			this.groupBoxSearch.Text = "Search range";
			// 
			// fieldTo
			// 
			this.fieldTo.Location = new System.Drawing.Point(45, 49);
			this.fieldTo.Name = "fieldTo";
			this.fieldTo.Size = new System.Drawing.Size(190, 20);
			this.fieldTo.TabIndex = 3;
			this.fieldTo.Text = "1";
			this.fieldTo.Validating += new System.ComponentModel.CancelEventHandler(this.gmpNumber_Validating);
			// 
			// fieldFrom
			// 
			this.fieldFrom.Location = new System.Drawing.Point(45, 22);
			this.fieldFrom.Name = "fieldFrom";
			this.fieldFrom.Size = new System.Drawing.Size(190, 20);
			this.fieldFrom.TabIndex = 2;
			this.fieldFrom.Text = "0";
			this.fieldFrom.Validating += new System.ComponentModel.CancelEventHandler(this.gmpNumber_Validating);
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
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// Search
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBoxSearch);
			this.Name = "Search";
			this.Size = new System.Drawing.Size(267, 80);
			this.groupBoxSearch.ResumeLayout(false);
			this.groupBoxSearch.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxSearch;
		private System.Windows.Forms.Label labelTo;
		private System.Windows.Forms.Label labelFrom;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		public System.Windows.Forms.TextBox fieldTo;
		public System.Windows.Forms.TextBox fieldFrom;
	}
}
