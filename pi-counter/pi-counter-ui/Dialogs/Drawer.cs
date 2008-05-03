using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace pi_counter_ui.Dialogs {
	public partial class Drawer : Form {
		public Drawer() {
			InitializeComponent();

			GraphPane gp = graph.GraphPane;
			gp.XAxis.Type = AxisType.Text;
		}

		private void Drawer_FormClosing(object sender, FormClosingEventArgs e) {
			if (e.CloseReason == CloseReason.UserClosing) {
				this.Hide();
				e.Cancel = true;
			}
		}

		public void update(string[] args, uint[] values) {
			GraphPane gp = graph.GraphPane;
			gp.XAxis.Scale.TextLabels = args;
			
			PointPairList ppl = new PointPairList();
			for (int i=0; i<args.Length; i++) {
				ppl.Add(i, values[i]);
			}
			LineItem data = gp.AddCurve("test", ppl, Color.Green);

			gp.AxisChange();
		}
	}
}