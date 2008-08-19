using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using pi_counter_ui.Properties;

namespace pi_counter_ui.Dialogs {
	public partial class Options : Form {

		public Options() {
			InitializeComponent();
		}

		private void Options_FormClosing(object sender, FormClosingEventArgs e) {
			if (e.CloseReason == CloseReason.None && DialogResult == DialogResult.OK) {
				Settings.Default.IndicesViewer_ResultsPerPage = (uint)indicesViewer_resultsPerPage.Value;
				Settings.Default.PiViewer_DigitsPerPage = (uint)piViewer_digitsPerPage.Value;
				Settings.Default.Save();
			}
		}

		private void Options_VisibleChanged(object sender, EventArgs e) {
			if (Visible) { //Load data
				indicesViewer_resultsPerPage.Value = Settings.Default.IndicesViewer_ResultsPerPage;
				piViewer_digitsPerPage.Value = Settings.Default.PiViewer_DigitsPerPage;
			}
		}
	}
}