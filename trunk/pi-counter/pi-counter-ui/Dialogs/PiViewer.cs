using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using pi_counter_ui.Properties;
using pi_counter_ui.Classes;

namespace pi_counter_ui.Dialogs {
	public partial class PiViewer : Form {
		byte[] _digits;

		public enum ViewStyle { Decimal, Hexadecimal };

		private ViewStyle _view;

		public ViewStyle View {
			get { return _view; }
			set {
				_view = value;
				if (_view == ViewStyle.Decimal) {
					fieldDecimal.Checked = true;
				} else {
					fieldHexadecimal.Checked = true;
				}
				updatePage();
			}
		}

		private uint _digitsPerPage;

		public uint DigitsPerPage {
			get { return _digitsPerPage; }
			set {
				_digitsPerPage = value;
				_digits = new byte[_digitsPerPage];
			}
		}
		
		private Bignum _bignum;

		public Bignum Bignum {
			get { return _bignum; }
			set {
				_bignum = value;
				updateForDecimal();
			}
		}

		private void updateForDecimal() {
			if (_bignum == null) {
				return;
			}
			indexer.PagesCount = (uint)(_bignum.getMaxDigits() / DigitsPerPage) + 1;
			updatePage();
		}

		private Bignum _bignumHex;

		public Bignum BignumHex {
			get { return _bignumHex; }
			set {
				_bignumHex = value;
				updateForHex();
			}
		}

		private void updateForHex() {
			if (_bignumHex == null) {
				return;
			}
			indexer.PagesCount = (uint)(_bignumHex.getMaxDigits() / DigitsPerPage) + 1;
			updatePage();
		}

		public PiViewer() {
			InitializeComponent();

			DigitsPerPage = Settings.Default.PiViewer_DigitsPerPage;
			indexer.IndexUpdated += new EventHandler(indexer_IndexUpdated);

			fieldDecimal.Tag = ViewStyle.Decimal;
			fieldHexadecimal.Tag = ViewStyle.Hexadecimal;

			View = ViewStyle.Decimal;
		}

		void indexer_IndexUpdated(object sender, EventArgs e) {
			updatePage();
		}

		private void PiViewer_FormClosing(object sender, FormClosingEventArgs e) {
			if (e.CloseReason == CloseReason.UserClosing) {
				e.Cancel = true;
				this.Hide();
			}
		}

		public bool updatePage() {
			textBoxPiView.Text = (View == ViewStyle.Decimal) ? getDecimalView() : getHexadecimalView();
			return true;
		}

		string getDecimalView() {
			if (Bignum == null) {
				return null;
			}

			int read;
			if ((read = Bignum.getDigits(_digits, (uint)((indexer.PageCurrent - 1) * DigitsPerPage), DigitsPerPage)) == -1) {
				return null;
			}
			StringBuilder sb = new StringBuilder();

			const int maxCharsInLine = 12 * 3;
			int charsInLine = 0;
			for (int i = 0; i < read; i++) {
				if (_digits[i] == '+') { //nie pokazujemy +
					continue;
				} else if (_digits[i] == '-') {
					sb.AppendLine("-");
					charsInLine = 0;
					continue;
				} else if (_digits[i] == '.') {
					sb.AppendLine().AppendLine(".");
					charsInLine = 0;
					continue;
				}
				sb.Append((char)_digits[i]);
				charsInLine++;
				if (charsInLine == maxCharsInLine) {
					sb.AppendLine();
					charsInLine = 0;
				} else if (charsInLine % 6 == 0) {
					sb.Append("  ");
				} else if (charsInLine % 3 == 0) {
					sb.Append(" ");
				}
			}
			return sb.ToString();
		}

		string getHexadecimalView() {
			if (BignumHex == null) {
				return null;
			}

			int read;
			if ((read = BignumHex.getDigits(_digits, (uint)((indexer.PageCurrent - 1) * DigitsPerPage), DigitsPerPage)) == -1) {
				return null;
			}
			StringBuilder sb = new StringBuilder();

			const int maxCharsInLine = 10 * 4;
			int charsInLine = 0;
			for (int i = 0; i < read; i++) {
				if (_digits[i] == '+') { //nie pokazujemy +
					continue;
				} else if (_digits[i] == '-') {
					sb.AppendLine("-");
					charsInLine = 0;
					continue;
				} else if (_digits[i] == '.') {
					sb.AppendLine().AppendLine(".");
					charsInLine = 0;
					continue;
				}
				sb.Append((char)_digits[i]);
				charsInLine++;
				if (charsInLine == maxCharsInLine) {
					sb.AppendLine();
					charsInLine = 0;
				} else if (charsInLine % 8 == 0) {
					sb.Append("  ");
				} else if (charsInLine % 4 == 0) {
					sb.Append(" ");
				}
			}



			return sb.ToString();
		}

		private void viewStyleChanged(object sender, EventArgs e) {
			RadioButton rb = sender as RadioButton;
			if (rb.Checked == false) {
				return;
			}

			ViewStyle vw = (ViewStyle)rb.Tag;
			View = vw;
		}

		private void textBoxPiView_MouseMove(object sender, MouseEventArgs e) {
			String text = textBoxPiView.Text;
			Bignum b = null;
			if (this._view == ViewStyle.Decimal) {
				b = Bignum;
			} else {
				b = BignumHex;
			}

			ulong charIndex = (ulong)textBoxPiView.GetCharIndexFromPosition(e.Location);
			int t = (int)charIndex;
			for (int i = 0; i <= t; i++) {
				char c = text[(int)i];
				if (Char.IsWhiteSpace(c)) {
					charIndex--;
				}
			}

			//ale nadal nie wiadomo czy jest to indeks z uwzglêdnieniem +,- lub .

			//jeœli to jest pierwsza strona to mo¿na sprawdziæ
			if (this.indexer.PageCurrent == 1) {
				if ((text[0] == '+' || text[0] == '-') && charIndex > 0) {
					charIndex--;
				}
				if (b.getDotPosition() < charIndex) {
					charIndex--;
				}
			} else {
				charIndex += (this.indexer.PageCurrent - 1) * DigitsPerPage;

				if (b.hasSign) {
					charIndex--;
				}

				if (b.getDotPosition() < charIndex) {
					charIndex--;
				}
			}

			charIndex++; //bo liczymy od 1
			this.labelPositionValue.Text = charIndex.ToString();
		}

	}
}
