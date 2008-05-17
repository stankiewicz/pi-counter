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
				indexer.PagesCount = (uint)(_bignum.getMaxDigits() / DigitsPerPage);
				indexer.PageCurrent = Math.Max(Math.Min(indexer.PageCurrent, indexer.PagesCount), 0); // 0 <= currPage <= maxPage
				updatePage();
			}
		}

		public PiViewer() {
			InitializeComponent();

			DigitsPerPage = 1000;
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
			if (Bignum == null) {
				return false;
			}

			int read;
			if ((read = Bignum.getDigits(_digits, (uint)(indexer.PageCurrent * DigitsPerPage), DigitsPerPage)) == -1) {
				return false;
			}

			textBoxPiView.Text = (View == ViewStyle.Decimal) ? getDecimalView(_digits, read) : getHexadecimalView(_digits, read);
			return true;
		}

		string getDecimalView(byte[] digits, int bytesRead) {
			StringBuilder sb = new StringBuilder();

			int three = 2, six = 5 /*, thirty = 29 */;
			for (int i = 0; i < bytesRead; i++, three--, six-- /*, thirty-- */) {
				sb.Append((char)digits[i]);
				if (three == 0) {
					sb.Append(" ");
					three = 3;
				}
				if (six == 0) {
					sb.Append("  ");
					six = 6;
				}
				//if (thirty==0) {
				//    sb.Append("   ");
				//    thirty = 30;
				//}
			}
			return sb.ToString();
		}

		string getHexadecimalView(byte[] digits, int bytesRead) {
			return "sorry, no hex today :)";
		}

		private void viewStyleChanged(object sender, EventArgs e) {
			RadioButton rb = sender as RadioButton;
			if (rb.Checked == false) {
				return;
			}

			ViewStyle vw = (ViewStyle)rb.Tag;
			switch (vw) {
				case ViewStyle.Decimal:
					break;
				case ViewStyle.Hexadecimal:
					MessageBox.Show("Sorry... not implemented yet...");
					View = ViewStyle.Decimal;
					break;
				default:
					break;
			}
		}
	}
}
