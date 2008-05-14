using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using pi_counter_ui.Controls;

namespace pi_counter_ui.Dialogs {
	public partial class Calculator : Form {
		enum C : int { arg1 = 0, arg2, res1, res2 };
		PagedText[] pts;

		public Calculator() {
			InitializeComponent();

			pts = new PagedText[4];
			pts[(int)C.arg1] = arg1;
			pts[(int)C.arg2] = arg2;
			pts[(int)C.res1] = res1;
			pts[(int)C.res2] = res2;

			arg1.CharsPerPage = arg2.CharsPerPage = res1.CharsPerPage = res2.CharsPerPage = 90; //a czemu nie? :P
			fieldOp.ValueMember = "+";

			btnSaveArg1.Tag =  btnLoadArg1.Tag = C.arg1;
			btnSaveArg2.Tag = btnLoadArg2.Tag = C.arg2;
			btnSaveRes1.Tag = C.res1;
			btnSaveRes2.Tag = C.res2;
		}

		private void Calculator_Load(object sender, EventArgs e) {
		}

		void saveHelper(string file, StringBuilder sb) {
			using (StreamWriter sw = new StreamWriter(file, false, Encoding.ASCII)) {
				for (int i = 0; i < sb.Length; i++) {
					sw.Write(sb[i]);
				}
			}
		}

		void readHelper(string file, StringBuilder sb) {
			int mb = 1048576;
			char[] buffer = new char[mb]; //1MB

			using (StreamReader sr = new StreamReader(file)) {
				while (!sr.EndOfStream) {
					int count = sr.ReadBlock(buffer, 0, mb);
					sb.Append(buffer, 0, count);
				}
			}
		}

		private void btnCalculate_Click(object sender, EventArgs e) {
			string s = fieldOp.Text;
			int res = 0;

			try {
				saveHelper("arg1", arg1.Buffer);

				if (s == "+") {
					saveHelper("arg2", arg2.Buffer);
					res = PiLibrary.add();
				} else if (s == "-") {
					saveHelper("arg2", arg2.Buffer);
					res = PiLibrary.sub();
				} else if (s == "*") {
					saveHelper("arg2", arg2.Buffer);
				} else if (s == "/") {
					saveHelper("arg2", arg2.Buffer);
					res = PiLibrary.divDouble();
				} else if (s == "/ (ca³kowite)") {
					saveHelper("arg2", arg2.Buffer);
					res = PiLibrary.divInt();
					StringBuilder sb = new StringBuilder();
					readHelper("res2", sb);
					res2.Buffer = sb;
				} else if (s == "=") {
					saveHelper("arg2", arg2.Buffer);
					res = PiLibrary.equ();
				} else if (s == "2^2^n+1") {
					res = PiLibrary.fancy1();
				} else if (s == "2^n-1") {
					res = PiLibrary.fancy2();
				} else {
					MessageBox.Show("Critical Error!");
					return;
				}
				
				StringBuilder sbRes = new StringBuilder();
				readHelper("res1", sbRes);
				res1.Buffer = sbRes;

				if (res != 0) {
					MessageBox.Show("Error!");
				}
			} catch (Exception exc) {
				MessageBox.Show("Ooops... Error: " + exc.Message);
			}
		}

		private void btnLoad_Click(object sender, EventArgs e) {
			Button btn = sender as Button;
			C c = (C)btn.Tag;

			if (openFileDialog.ShowDialog() != DialogResult.OK) {
				return;
			}

			StringBuilder sb = new StringBuilder();
			try {
				readHelper(openFileDialog.FileName, sb);
				pts[(int)c].Buffer = sb;
			} catch (Exception exc) {
				MessageBox.Show("Ooops... Error: " + exc.Message);
			}
		}

		private void btnSave_Click(object sender, EventArgs e) {
			if (saveFileDialog.ShowDialog() != DialogResult.OK) {
				return;
			}
			Button btn = sender as Button;
			StringBuilder sb = pts[(int)btn.Tag].Buffer;
			try {
				saveHelper(saveFileDialog.FileName, sb);
			} catch (Exception exc) {
				MessageBox.Show("Error: " + exc.Message);
			}
		}
	}
}
