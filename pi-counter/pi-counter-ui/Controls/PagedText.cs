using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace pi_counter_ui.Controls {
	public partial class PagedText : UserControl {
		
		StringBuilder _buffer = new StringBuilder();
		int _beg = 0, _len = 0;

		private int _charsPerPage = 80;

		[Browsable(true)]
		public int CharsPerPage {
			get { return _charsPerPage; }
			set {
				if (value <= 0) {
					throw new ArgumentOutOfRangeException("value", "value must be greater than 0");
				}
				_charsPerPage = value;
			}
		}

		public StringBuilder Buffer {
			get { return _buffer; }
			set {
				_buffer = value;
				updateAll();
			}
		}

		public PagedText() {
			InitializeComponent();

			indexer.IndexUpdated += new EventHandler(indexer_IndexUpdated);
		}

		void indexer_IndexUpdated(object sender, EventArgs e) {
			updateText();
		}

		private void textBox1_Validating(object sender, CancelEventArgs e) {
			TextBox tb = sender as TextBox;
			string text = tb.Text;
			if (!isValid(text)) {
				e.Cancel = true;
				return;
			}
			//zamiana
			_buffer.Remove(_beg, _len); //usuniecie starego tekstu
			_buffer.Insert(_beg, text); //wstawienie nowego
			_len = text.Length; //uaktualnienie zakresu wyswietlanego tekstu

			updateAll();

			Console.Out.WriteLine("validating");
		}

		bool isValid(string text) {
			//TODO
			return true;
		}

		void updateAll() {
			indexer.PagesCount = (ulong)Math.Max(Math.Ceiling((double)_buffer.Length / (double)CharsPerPage), 1);

			updateText();
		}

		private void updateText() {
			_beg = Math.Max(0, Math.Min(((int)indexer.PageCurrent - 1) * CharsPerPage, _buffer.Length - 1));
			_len = Math.Max(0, Math.Min(CharsPerPage, _buffer.Length - _beg));

			fieldText.Text = _buffer.ToString(_beg, _len);
		}
	}
}
