using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace pi_counter_ui.Controls {
	public partial class Search : UserControl {
		public Search() {
			InitializeComponent();

			fieldChoiceRange_CheckedChanged(null, null);
		}

		private void gmpNumber_Validating(object sender, CancelEventArgs e) {
			String input = ((TextBox)sender).Text;
			e.Cancel = !Regex.IsMatch(input, "^[0-9]+$");
			if (e.Cancel) {
				errorProvider1.SetError((Control)sender, "Format: [0-9]+");
			} else {
				errorProvider1.SetError((Control)sender, "");
			}
		}

		private void fieldChoiceRange_CheckedChanged(object sender, EventArgs e) {
			if (fieldChoiceRange.Checked) {
				panelRange.Enabled = true;
				panelPattern.Enabled = false;
			} else {
				panelRange.Enabled = false;
				panelPattern.Enabled = true;
			}
		}
	}
}
