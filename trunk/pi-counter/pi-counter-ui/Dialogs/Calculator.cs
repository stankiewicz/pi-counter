//TODO: dodaæ synchroniczne przewijanie. Trzeba bêdzie zmieniæ sposób wybierania ci¹gu znaków do wyœwietlenia, np. pocz¹tek i iloœæ znaków. Do tego trzeba bêdzie przepisaæ kontrolkê "PagedText".

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using pi_counter_ui.Controls;
using pi_counter_ui.Classes;

namespace pi_counter_ui.Dialogs {
	public partial class Calculator : Form {
		enum C : int { arg1 = 0, arg2, res1, res2 };
		PagedText[] pts;

		enum Operators { add, sub, mul, div, divInt, eq, fancy, mersenne };

		String[] operators = {
			"+", "-", "*", "/", "/ (ca³kowite)", "=", "2^2^n+1", "2^n-1" };

		public Calculator() {
			InitializeComponent();

			pts = new PagedText[4];
			pts[(int)C.arg1] = arg1;
			pts[(int)C.arg2] = arg2;
			pts[(int)C.res1] = res1;
			pts[(int)C.res2] = res2;

			arg1.CharsToShow = arg2.CharsToShow = res1.CharsToShow = res2.CharsToShow = 70;

			fieldOp.Items.AddRange(operators);
			fieldOp.SelectedIndex = 0;

			arg1.Tag = btnSaveArg1.Tag = btnLoadArg1.Tag = C.arg1;
			arg2.Tag = btnSaveArg2.Tag = btnLoadArg2.Tag = C.arg2;
			res1.Tag = btnSaveRes1.Tag = C.res1;
			res2.Tag = btnSaveRes2.Tag = C.res2;

			arg1.displayRangeChanged += new EventHandler(displayRangeChanged);
			arg2.displayRangeChanged += new EventHandler(displayRangeChanged);
			res1.displayRangeChanged += new EventHandler(displayRangeChanged);
			res2.displayRangeChanged += new EventHandler(displayRangeChanged);
		}

		void displayRangeChanged(object sender, EventArgs e) {
			PagedText source = (PagedText)sender;
			int indexRelativeToDot = source.DotPosition - source.IndexToShow;
			foreach (PagedText pt in pts) {
				if (pt == source) {
					continue;
				}
				pt.IndexToShow = pt.DotPosition - indexRelativeToDot;
				pt.CharsToShow = source.CharsToShow;
			}
		}

		void align() {
			displayRangeChanged(arg1, null);
		}

		void saveHelper(string file, StringBuilder sb) {
			using (StreamWriter sw = new StreamWriter(file, false, Encoding.ASCII)) {
				for (int i = 0; i < sb.Length; i++) {
					sw.Write(sb[i]);
				}
			}
		}

		void readHelperBignum(string file, StringBuilder sb) {
			uint mb = 1048576;
			byte[] buffer = new byte[mb]; //1MB

			Bignum b = new Bignum(file);
			b.Open();
			int start = 0;
			int read = 0;
			do {
				read = b.getDigits(buffer, (uint)start, mb);
				for (int i = 0; i < read; i++) {
					sb.Append((char)buffer[i]);
				}
				start += read;
			} while (read > 0);
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

			res2.Buffer = new StringBuilder();

			try {
				if (s == "+") {
					saveHelper("arg1", arg1.Buffer);
					saveHelper("arg2", arg2.Buffer);
					res = PiLibrary.add();
				} else if (s == "-") {
					saveHelper("arg1", arg1.Buffer);
					saveHelper("arg2", arg2.Buffer);
					res = PiLibrary.sub();
				} else if (s == "*") {
					saveHelper("arg1", arg1.Buffer);
					saveHelper("arg2", arg2.Buffer);
                    res = PiLibrary.mul();
				} else if (s == "/") {
					saveHelper("arg1", arg1.Buffer);
					saveHelper("arg2", arg2.Buffer);
					res = PiLibrary.divDouble();
				} else if (s == "/ (ca³kowite)") {
					saveHelper("arg1", arg1.Buffer);
					saveHelper("arg2", arg2.Buffer);
					res = PiLibrary.divInt();
					StringBuilder sb = new StringBuilder();
					readHelper("res2", sb);
					res2.Buffer = sb;
				} else if (s == "=") {
					saveHelper("arg1", arg1.Buffer);
					saveHelper("arg2", arg2.Buffer);
					res = PiLibrary.equ();
				} else if (s == "2^2^n+1") {
					uint n;
					if (!uint.TryParse(arg1.Buffer.ToString(), out n)) {
						MessageBox.Show("To big n!");
						return;
					}
					res = PiLibrary.fancy(n);
				} else if (s == "2^n-1") {
					uint n;
					if (!uint.TryParse(arg1.Buffer.ToString(), out n)) {
						MessageBox.Show("To big n!");
						return;
					}
					res = PiLibrary.mersenne(n);
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

				align();
			} catch (Exception exc) {
				MessageBox.Show("Ooops... Error: " + exc.Message);
			}
		}

		/// <summary>
		/// Wczytywanie plików bignum
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLoad_Click(object sender, EventArgs e) {
			Button btn = sender as Button;
			C c = (C)btn.Tag;

			if (openFileDialog.ShowDialog() != DialogResult.OK) {
				return;
			}

			StringBuilder sb = new StringBuilder();
			try {
				readHelperBignum(openFileDialog.FileName, sb);
				pts[(int)c].Buffer = sb;
			} catch (Exception exc) {
				MessageBox.Show("Unexpected error occured: " + exc.Message);
			}
		}

		/// <summary>
		/// Zapisywanie jako zwyk³y plik
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

		private void fieldOp_SelectedIndexChanged(object sender, EventArgs e) {
			Operators selected = (Operators)fieldOp.SelectedIndex;
			switch (selected) {
				case Operators.add:
					panelArg2.Visible = true;
					panelRes2.Visible = false;
					fieldOpInfo.Text = "Please insert arguments into rows above. The result will be shown below.";
					break;
				case Operators.sub:
					panelArg2.Visible = true;
					panelRes2.Visible = false;
					fieldOpInfo.Text = "Please insert arguments into rows above. The result will be shown below.";
					break;
				case Operators.mul:
					panelArg2.Visible = true;
					panelRes2.Visible = false;
					fieldOpInfo.Text = "Please insert arguments into rows above. The result will be shown below.";
					break;
				case Operators.div:
					panelArg2.Visible = true;
					panelRes2.Visible = false;
					fieldOpInfo.Text = "Please insert arguments into rows above. The result will be shown below.";
					break;
				case Operators.divInt:
					panelArg2.Visible = true;
					panelRes2.Visible = true;
					fieldOpInfo.Text = "Please insert arguments into rows above. Quotient will be in the first row, remainder - in the second, below.";
					break;
				case Operators.eq:
					panelArg2.Visible = true;
					panelRes2.Visible = false;
					fieldOpInfo.Text = "Please insert arguments into rows above. The resul will be shown below: 1 for equal, otherwise 0.";
					break;
				case Operators.fancy:
					panelArg2.Visible = false;
					panelRes2.Visible = false;
					fieldOpInfo.Text = "Please insert argument into row above. The resul will be shown below.";
					break;
				case Operators.mersenne:
					panelArg2.Visible = false;
					panelRes2.Visible = false;
					fieldOpInfo.Text = "Please insert argument into row above. The resul will be shown below.";
					break;
				default:
					break;
			}
		}

		private void Calculator_FormClosing(object sender, FormClosingEventArgs e) {
			if (e.CloseReason == CloseReason.UserClosing) {
				this.Visible = false;
				e.Cancel = true;
			}
		}
	}
}
