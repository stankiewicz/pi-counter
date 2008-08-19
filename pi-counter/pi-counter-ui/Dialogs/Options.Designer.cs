namespace pi_counter_ui.Dialogs {
	partial class Options {
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.piViewer_digitsPerPage = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.indicesViewer_resultsPerPage = new System.Windows.Forms.NumericUpDown();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.piViewer_digitsPerPage)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.indicesViewer_resultsPerPage)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.piViewer_digitsPerPage);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(190, 48);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "PiViewer";
			// 
			// piViewer_digitsPerPage
			// 
			this.piViewer_digitsPerPage.Location = new System.Drawing.Point(102, 14);
			this.piViewer_digitsPerPage.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.piViewer_digitsPerPage.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.piViewer_digitsPerPage.Name = "piViewer_digitsPerPage";
			this.piViewer_digitsPerPage.Size = new System.Drawing.Size(71, 20);
			this.piViewer_digitsPerPage.TabIndex = 0;
			this.piViewer_digitsPerPage.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Digits per page:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.indicesViewer_resultsPerPage);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(12, 66);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(190, 50);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "IndicesViewer";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Results per page:";
			// 
			// indicesViewer_resultsPerPage
			// 
			this.indicesViewer_resultsPerPage.Location = new System.Drawing.Point(102, 14);
			this.indicesViewer_resultsPerPage.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.indicesViewer_resultsPerPage.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.indicesViewer_resultsPerPage.Name = "indicesViewer_resultsPerPage";
			this.indicesViewer_resultsPerPage.Size = new System.Drawing.Size(71, 20);
			this.indicesViewer_resultsPerPage.TabIndex = 2;
			this.indicesViewer_resultsPerPage.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(31, 122);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(112, 122);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// Options
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(218, 156);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Options";
			this.Text = "Options";
			this.VisibleChanged += new System.EventHandler(this.Options_VisibleChanged);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Options_FormClosing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.piViewer_digitsPerPage)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.indicesViewer_resultsPerPage)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown piViewer_digitsPerPage;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown indicesViewer_resultsPerPage;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}