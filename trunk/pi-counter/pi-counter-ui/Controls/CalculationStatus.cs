using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace pi_counter_ui.Controls {
	public partial class CalculationStatus : UserControl {

		public enum CalculationState { Start=0, Stop=1 };
		CalculationState _cs;

		public CalculationStatus() {
			InitializeComponent();

			setState(CalculationState.Start);
			Found = 0;
			FoundMax = 0;
		}

		[Browsable(true)]
		public void setState(CalculationState cs) {
			this._cs = cs;
			buttonStart.Text = cs.ToString();
		}

		private void buttonStart_Click(object sender, EventArgs e) {
			if (_cs == CalculationState.Start) {
				setState(CalculationState.Stop);
			} else {
				setState(CalculationState.Start);
			}
		}

		[Browsable(true)]
		public bool FoundVisibility {
			get { return panelFound.Visible; }
			set { panelFound.Visible = value; }
		}

		[Browsable(true)]
		public int ConstraintTime {
			get { return progressBarTime.Value; }
			set { progressBarTime.Value = value; }
		}

		[Browsable(true)]
		public int ConstraintLength {
			get { return progressBarLength.Value; }
			set { progressBarLength.Value = value; }
		}

		[Browsable(true)]
		public int ConstraintTimeMax {
			get { return progressBarTime.Maximum; }
			set { progressBarTime.Maximum = value; }
		}

		[Browsable(true)]
		public int ConstraintLengthMax {
			get { return progressBarLength.Maximum; }
			set { progressBarLength.Maximum = value; }
		}

		private long found;

		[Browsable(true)]
		public long Found {
			get { return found; }
			set { found = value; labelFoundCount.Text = found.ToString(); }
		}

		private long foundMax;
		[Browsable(true)]
		public long FoundMax {
			get { return foundMax; }
			set { foundMax = value; labelFoundMax.Text = foundMax.ToString();  }
		}
	}
}
