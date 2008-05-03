using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace pi_counter_ui.Controls {
	public partial class Indexer : UserControl {
		public event EventHandler IndexUpdated;

		private uint _pageCurrent;

		public uint PageCurrent {
			get { return _pageCurrent; }
			set {
				_pageCurrent = Math.Min(Math.Max(value, 0), PagesCount); 
				fieldPage.Text = _pageCurrent.ToString();
			}
		}

		private uint _pagesCount;

		public uint PagesCount {
			get { return _pagesCount; }
			set {
				_pagesCount = value;
				this.fieldMaxPage.Text = _pagesCount.ToString();
				this.fieldPage.Maximum = _pagesCount;
			}
		}

		public Indexer() {
			InitializeComponent();
		}

		private void buttonPrev_Click(object sender, EventArgs e) {
			PageCurrent--;
			fireIndexUpdated();
		}

		private void buttonNext_Click(object sender, EventArgs e) {
			PageCurrent++;
			fireIndexUpdated();
		}

		void fireIndexUpdated() {
			if (IndexUpdated != null) {
				IndexUpdated(this, EventArgs.Empty);
			}
		}

		private void fieldPage_ValueChanged(object sender, EventArgs e) {
			PageCurrent = (uint)this.fieldPage.Value;
			fireIndexUpdated();
		}
	}
}
