using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using pi_counter_ui;

namespace pi_counter_ui_tests {
	public partial class TestsForm : Form {
		public TestsForm() {
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) {
			Tests.test();
		}

		private void button2_Click(object sender, EventArgs e) {
			Tests.test2();
		}

		private void button3_Click(object sender, EventArgs e) {
			Tests.testIncrementalGeneration();
		}
	}
}