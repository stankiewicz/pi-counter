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
			this.panelRange = new System.Windows.Forms.Panel();
			this.labelFrom = new System.Windows.Forms.Label();
			this.labelTo = new System.Windows.Forms.Label();
			this.fieldFrom = new System.Windows.Forms.TextBox();
			this.fieldTo = new System.Windows.Forms.TextBox();
			this.panelPattern = new System.Windows.Forms.Panel();
			this.fieldPattern = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.fieldChoicePattern = new System.Windows.Forms.RadioButton();
			this.fieldChoiceRange = new System.Windows.Forms.RadioButton();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.groupBoxSearch.SuspendLayout();
			this.panelRange.SuspendLayout();
			this.panelPattern.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxSearch
			// 
			this.groupBoxSearch.Controls.Add(this.panelRange);
			this.groupBoxSearch.Controls.Add(this.panelPattern);
			this.groupBoxSearch.Controls.Add(this.fieldChoicePattern);
			this.groupBoxSearch.Controls.Add(this.fieldChoiceRange);
			this.groupBoxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxSearch.Location = new System.Drawing.Point(0, 0);
			this.groupBoxSearch.Name = "groupBoxSearch";
			this.groupBoxSearch.Size = new System.Drawing.Size(255, 148);
			this.groupBoxSearch.TabIndex = 1;
			this.groupBoxSearch.TabStop = false;
			this.groupBoxSearch.Text = "Search";
			this.toolTip1.SetToolTip(this.groupBoxSearch, "Specify range for the search function.");
			// 
			// panelRange
			// 
			this.panelRange.Controls.Add(this.labelFrom);
			this.panelRange.Controls.Add(this.labelTo);
			this.panelRange.Controls.Add(this.fieldFrom);
			this.panelRange.Controls.Add(this.fieldTo);
			this.panelRange.Location = new System.Drawing.Point(7, 42);
			this.panelRange.Name = "panelRange";
			this.panelRange.Size = new System.Drawing.Size(240, 58);
			this.panelRange.TabIndex = 7;
			// 
			// labelFrom
			// 
			this.labelFrom.AutoSize = true;
			this.labelFrom.Location = new System.Drawing.Point(3, 6);
			this.labelFrom.Name = "labelFrom";
			this.labelFrom.Size = new System.Drawing.Size(33, 13);
			this.labelFrom.TabIndex = 0;
			this.labelFrom.Text = "From:";
			// 
			// labelTo
			// 
			this.labelTo.AutoSize = true;
			this.labelTo.Location = new System.Drawing.Point(3, 32);
			this.labelTo.Name = "labelTo";
			this.labelTo.Size = new System.Drawing.Size(23, 13);
			this.labelTo.TabIndex = 1;
			this.labelTo.Text = "To:";
			// 
			// fieldFrom
			// 
			this.fieldFrom.Location = new System.Drawing.Point(42, 3);
			this.fieldFrom.Name = "fieldFrom";
			this.fieldFrom.Size = new System.Drawing.Size(190, 20);
			this.fieldFrom.TabIndex = 2;
			this.fieldFrom.Text = "0";
			this.fieldFrom.Validating += new System.ComponentModel.CancelEventHandler(this.gmpNumber_Validating);
			// 
			// fieldTo
			// 
			this.fieldTo.Location = new System.Drawing.Point(42, 29);
			this.fieldTo.Name = "fieldTo";
			this.fieldTo.Size = new System.Drawing.Size(190, 20);
			this.fieldTo.TabIndex = 3;
			this.fieldTo.Text = "1";
			this.fieldTo.Validating += new System.ComponentModel.CancelEventHandler(this.gmpNumber_Validating);
			// 
			// panelPattern
			// 
			this.panelPattern.Controls.Add(this.fieldPattern);
			this.panelPattern.Controls.Add(this.label1);
			this.panelPattern.Location = new System.Drawing.Point(7, 106);
			this.panelPattern.Name = "panelPattern";
			this.panelPattern.Size = new System.Drawing.Size(240, 33);
			this.panelPattern.TabIndex = 6;
			// 
			// fieldPattern
			// 
			this.fieldPattern.Location = new System.Drawing.Point(53, 6);
			this.fieldPattern.Name = "fieldPattern";
			this.fieldPattern.Size = new System.Drawing.Size(179, 20);
			this.fieldPattern.TabIndex = 4;
			this.fieldPattern.Text = "0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Pattern:";
			// 
			// fieldChoicePattern
			// 
			this.fieldChoicePattern.AutoSize = true;
			this.fieldChoicePattern.Location = new System.Drawing.Point(70, 19);
			this.fieldChoicePattern.Name = "fieldChoicePattern";
			this.fieldChoicePattern.Size = new System.Drawing.Size(59, 17);
			this.fieldChoicePattern.TabIndex = 5;
			this.fieldChoicePattern.Text = "Pattern";
			this.fieldChoicePattern.UseVisualStyleBackColor = true;
			this.fieldChoicePattern.CheckedChanged += new System.EventHandler(this.fieldChoiceRange_CheckedChanged);
			// 
			// fieldChoiceRange
			// 
			this.fieldChoiceRange.AutoSize = true;
			this.fieldChoiceRange.Checked = true;
			this.fieldChoiceRange.Location = new System.Drawing.Point(7, 19);
			this.fieldChoiceRange.Name = "fieldChoiceRange";
			this.fieldChoiceRange.Size = new System.Drawing.Size(57, 17);
			this.fieldChoiceRange.TabIndex = 4;
			this.fieldChoiceRange.TabStop = true;
			this.fieldChoiceRange.Text = "Range";
			this.fieldChoiceRange.UseVisualStyleBackColor = true;
			this.fieldChoiceRange.CheckedChanged += new System.EventHandler(this.fieldChoiceRange_CheckedChanged);
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
			this.Size = new System.Drawing.Size(255, 148);
			this.groupBoxSearch.ResumeLayout(false);
			this.groupBoxSearch.PerformLayout();
			this.panelRange.ResumeLayout(false);
			this.panelRange.PerformLayout();
			this.panelPattern.ResumeLayout(false);
			this.panelPattern.PerformLayout();
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
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Panel panelRange;
		private System.Windows.Forms.Panel panelPattern;
		public System.Windows.Forms.TextBox fieldPattern;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.RadioButton fieldChoicePattern;
		public System.Windows.Forms.RadioButton fieldChoiceRange;
	}
}
