using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
	}
}