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
			this.fieldPage = new System.Windows.Forms.NumericUpDown();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(this.fieldPage)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonPrev
			// 
			this.buttonPrev.AutoSize = true;
			this.buttonPrev.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonPrev.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonPrev.Location = new System.Drawing.Point(3, 3);
			this.buttonPrev.Name = "buttonPrev";
			this.buttonPrev.Size = new System.Drawing.Size(23, 23);
			this.buttonPrev.TabIndex = 0;
			this.buttonPrev.Text = "<";
			this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
			// 
			// buttonNext
			// 
			this.buttonNext.AutoSize = true;
			this.buttonNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonNext.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonNext.Location = new System.Drawing.Point(153, 3);
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.Size = new System.Drawing.Size(23, 23);
			this.buttonNext.TabIndex = 1;
			this.buttonNext.Text = ">";
			this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
			// 
			// labelOf
			// 
			this.labelOf.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelOf.Location = new System.Drawing.Point(98, 0);
			this.labelOf.Name = "labelOf";
			this.labelOf.Size = new System.Drawing.Size(12, 29);
			this.labelOf.TabIndex = 3;
			this.labelOf.Text = "/";
			this.labelOf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// fieldMaxPage
			// 
			this.fieldMaxPage.AutoSize = true;
			this.fieldMaxPage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fieldMaxPage.Location = new System.Drawing.Point(116, 0);
			this.fieldMaxPage.Name = "fieldMaxPage";
			this.fieldMaxPage.Size = new System.Drawing.Size(31, 29);
			this.fieldMaxPage.TabIndex = 4;
			this.fieldMaxPage.Text = "6000";
			this.fieldMaxPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// fieldPage
			// 
			this.fieldPage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fieldPage.Location = new System.Drawing.Point(32, 3);
			this.fieldPage.Name = "fieldPage";
			this.fieldPage.Size = new System.Drawing.Size(60, 20);
			this.fieldPage.TabIndex = 5;
			this.fieldPage.ValueChanged += new System.EventHandler(this.fieldPage_ValueChanged);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.buttonPrev);
			this.flowLayoutPanel1.Controls.Add(this.fieldPage);
			this.flowLayoutPanel1.Controls.Add(this.labelOf);
			this.flowLayoutPanel1.Controls.Add(this.fieldMaxPage);
			this.flowLayoutPanel1.Controls.Add(this.buttonNext);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(179, 29);
			this.flowLayoutPanel1.TabIndex = 6;
			// 
			// Indexer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "Indexer";
			this.Size = new System.Drawing.Size(179, 29);
			((System.ComponentModel.ISupportInitialize)(this.fieldPage)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelOf;
		private System.Windows.Forms.Label fieldMaxPage;
		private System.Windows.Forms.Button buttonPrev;
		private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.NumericUpDown fieldPage;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
	}
}
