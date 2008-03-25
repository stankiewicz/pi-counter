using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using pi_counter_ui.Properties;

namespace pi_counter_ui.Dialogs {
	public partial class PiViewer : Form {
		public PiViewer() {
			InitializeComponent();
		}

		private void hexToolStripMenuItem_Click(object sender, EventArgs e) {

		}

		private void PiViewer_FormClosing(object sender, FormClosingEventArgs e) {
			if (e.CloseReason == CloseReason.UserClosing) {
				e.Cancel = true;
				this.Hide();
			}
		}

		private void PiViewer_Load(object sender, EventArgs e) {
			//TODO remove
			StringBuilder sb = new StringBuilder();

			int three = 2, six = 5, thirty = 29;
			Random rnd = new Random();
			for (int i = 0; i < 1000; i++, three--, six--, thirty--) {
				sb.Append(rnd.Next(9));
				if (three==0) {
					sb.Append(" ");
					three = 3;
				}
				if (six==0) {
					sb.Append("  ");
					six = 6;
				}
				if (thirty==0) {
					sb.Append("   ");
					thirty = 30;
				}
			}
			textBoxPiView.Text = sb.ToString();
		}
	}
}