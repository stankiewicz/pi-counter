using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using pi_counter_ui.Classes;

namespace pi_counter_ui.Dialogs {
	public partial class IndicesViewer : Form {
		String _warFun;
		ulong _searchedIndices;

		private uint _resultsPerPage;

		public uint ResultsPerPage {
			get { return _resultsPerPage; }
			set {
				_resultsPerPage = value;
				setPageCount();
			}
		}

		public IndicesViewer() {
			InitializeComponent();

			ResultsPerPage = 200;
			indexer.IndexUpdated += new EventHandler(indexer_IndexUpdated);
		}



		public void init(String warfunFile, ulong searchedIndices) {
			_warFun = warfunFile;
			_searchedIndices = searchedIndices;

			setPageCount();
		}

		private void setPageCount() {
			indexer.PagesCount = _searchedIndices / ResultsPerPage;
			indexer.PageCurrent = Math.Max(Math.Min(indexer.PageCurrent, indexer.PagesCount), 0);
		}

		void indexer_IndexUpdated(object sender, EventArgs e) {
			updatePage();
		}

		private void IndicesViewer_Load(object sender, EventArgs e) { }

		private void IndicesViewer_FormClosing(object sender, FormClosingEventArgs e) {
			if (e.CloseReason == CloseReason.UserClosing) {
				e.Cancel = true;
				this.Hide();
			}
		}

		public bool updatePage() {
			string[] values = FunReader.getValues(_warFun, indexer.PageCurrent * ResultsPerPage, ResultsPerPage);

			flowLayoutPanel1.SuspendLayout();
			flowLayoutPanel1.Controls.Clear();
			for (uint i = 0; i < values.Length; i++) {
				Label l = new Label();
				l.Text = i.ToString() + " : " + values[i];
				//l.Parent = this.splitContainer1.Panel1;
				flowLayoutPanel1.Controls.Add(l);
			}
			flowLayoutPanel1.ResumeLayout();

			return true;
		}
	}
}