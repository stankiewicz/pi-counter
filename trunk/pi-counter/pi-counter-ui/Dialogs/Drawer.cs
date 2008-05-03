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
			gp.Title.IsVisible = false;
			gp.YAxis.Title.Text = "indeks";
			gp.XAxis.Title.Text = "ci¹g cyfr";
			gp.XAxis.Type = AxisType.Text;
			gp.Legend.IsVisible = false;
		}

		private void Drawer_FormClosing(object sender, FormClosingEventArgs e) {
			if (e.CloseReason == CloseReason.UserClosing) {
				this.Hide();
				e.Cancel = true;
			}
		}

		public void update(string[] args, uint[] values) {
			GraphPane gp = graph.GraphPane;
			gp.CurveList.Clear();

			PointPairList ppl = new PointPairList();
			for (int i=0; i<args.Length; i++) {
				ppl.Add(i, values[i]);
			}
			LineItem data = gp.AddCurve("test", ppl, Color.Green);
			gp.XAxis.Scale.TextLabels = args;
			gp.XAxis.Type = AxisType.Text;

			gp.AxisChange();
			graph.Invalidate();
		}
	}
}