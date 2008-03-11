using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pi_counter_ui.Dialogs {
	public partial class IndicesViewer : Form {
		public IndicesViewer() {
			InitializeComponent();
		}

		private void IndicesViewer_Load(object sender, EventArgs e) {
			flowLayoutPanel1.SuspendLayout();
			Random rnd = new Random();
			for (int i = 0; i < 300; i++) {
				Label l = new Label();
				String str = i.ToString();
				l.Text = str + " : " + rnd.Next().ToString();
				//l.Parent = this.splitContainer1.Panel1;
				flowLayoutPanel1.Controls.Add(l);
			}
			flowLayoutPanel1.ResumeLayout();
		}

		private void IndicesViewer_FormClosing(object sender, FormClosingEventArgs e) {
			if (e.CloseReason == CloseReason.UserClosing) {
				e.Cancel = true;
				this.Hide();
			}
		}
	}
}