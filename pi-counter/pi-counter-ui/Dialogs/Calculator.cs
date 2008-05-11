using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pi_counter_ui.Dialogs {
	public partial class Calculator : Form {
		enum C : int { arg1 = 0, arg2, res1, res2 };

		public Calculator() {
			InitializeComponent();

			arg1.CharsPerPage = arg2.CharsPerPage = res1.CharsPerPage = res2.CharsPerPage = 90; //a czemu nie? :P
		}

		private void Calculator_Load(object sender, EventArgs e) {
			test();
		}

		private void test() {
			Random rnd = new Random();
			StringBuilder sb = new StringBuilder();
			sb.Append("+3.1415");
			for (int i=0; i<10000; i++) { //max 100k znaków
				sb.Append(rnd.Next().ToString());
			}
			arg1.Buffer = sb;
		}
	}
}
