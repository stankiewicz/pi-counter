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
		byte[] digits;

		private uint _digitsPerPage;

		public uint DigitsPerPage {
			get { return _digitsPerPage; }
			set {
				_digitsPerPage = value;
				digits = new byte[_digitsPerPage];
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
		}

		void indexer_IndexUpdated(object sender, EventArgs e) {
			updatePage();
		}

		private void hexToolStripMenuItem_Click(object sender, EventArgs e) {
			MessageBox.Show("Not implemented yet!");
		}

		private void PiViewer_FormClosing(object sender, FormClosingEventArgs e) {
			if (e.CloseReason == CloseReason.UserClosing) {
				e.Cancel = true;
				this.Hide();
			}
		}

		public bool updatePage() {
			int read;
			if ((read = Bignum.getDigits(digits, (uint)(indexer.PageCurrent * DigitsPerPage), DigitsPerPage)) == -1) {
				return false;
			}

			StringBuilder sb = new StringBuilder();

			int three = 2, six = 5 /*, thirty = 29 */;
			for (int i = 0; i < read; i++, three--, six-- /*, thirty-- */) {
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
			textBoxPiView.Text = sb.ToString();
			return true;
		}

		private void PiViewer_Load(object sender, EventArgs e) {

		}
	}
}
