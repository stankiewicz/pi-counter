using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace pi_counter_ui.Controls {
	public partial class Constraints : UserControl {
		public Constraints() {
			InitializeComponent();
		}

		private void cbConstraintTime_CheckedChanged(object sender, EventArgs e) {
			updateConstraints();
		}

		void updateConstraints() {
			this.numericUpDownConstraintTime.Enabled = cbConstraintTime.Checked;
			this.numericUpDownConstraintLength.Enabled = cbConstraintLength.Checked;
		}

		private void cbConstraintLength_CheckedChanged(object sender, EventArgs e) {
			updateConstraints();
		}

		[Browsable(true)]
		public decimal TimeConstraint {
			get { return numericUpDownConstraintTime.Value; }
			set { numericUpDownConstraintTime.Value = value; }
		}

		[Browsable(true)]
		public decimal LengthConstraint {
			get { return numericUpDownConstraintLength.Value; }
			set { numericUpDownConstraintLength.Value = value; }
		}
	}
}
