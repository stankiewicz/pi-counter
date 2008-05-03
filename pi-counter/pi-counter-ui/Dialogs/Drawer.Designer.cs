namespace pi_counter_ui.Dialogs {
	partial class Drawer {
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
			this.components = new System.ComponentModel.Container();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.graph = new ZedGraph.ZedGraphControl();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(600, 370);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// graph
			// 
			this.graph.Dock = System.Windows.Forms.DockStyle.Fill;
			this.graph.EditButtons = System.Windows.Forms.MouseButtons.None;
			this.graph.EditModifierKeys = System.Windows.Forms.Keys.None;
			this.graph.IsAutoScrollRange = true;
			this.graph.Location = new System.Drawing.Point(0, 0);
			this.graph.Name = "graph";
			this.graph.ScrollGrace = 0;
			this.graph.ScrollMaxX = 0;
			this.graph.ScrollMaxY = 0;
			this.graph.ScrollMaxY2 = 0;
			this.graph.ScrollMinX = 0;
			this.graph.ScrollMinY = 0;
			this.graph.ScrollMinY2 = 0;
			this.graph.Size = new System.Drawing.Size(600, 370);
			this.graph.TabIndex = 1;
			// 
			// Drawer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(600, 370);
			this.Controls.Add(this.graph);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Drawer";
			this.Text = "Drawer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Drawer_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private ZedGraph.ZedGraphControl graph;
	}
}