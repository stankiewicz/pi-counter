using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using pi_counter_ui.Classes;
using System.IO;

namespace pi_counter_ui.Dialogs {
	public partial class IndicesViewer : Form {
		String _warFun;
		ulong _searchedIndices;
		string[] args = null;
		uint[] values = null;
		Label[] labels = null;

		Font f = new Font(new Label().Font.FontFamily, 12f);

		private uint _resultsPerPage;

		public uint ResultsPerPage {
			get { return _resultsPerPage; }
			set {
				_resultsPerPage = value;
				args = new string[_resultsPerPage];
				values = new uint[_resultsPerPage];

				flowLayoutPanel1.SuspendLayout();
				flowLayoutPanel1.Controls.Clear();
				labels = new Label[_resultsPerPage];
				for (int i = (int)(_resultsPerPage - 1); i >= 0; i--) {
					Label l = new Label();
					l.Font = f;
					l.AutoSize = true;
					labels[i] = l;
				}
				flowLayoutPanel1.Controls.AddRange(labels);
				flowLayoutPanel1.ResumeLayout();
				setPageCount();
			}
		}

		public IndicesViewer() {
			InitializeComponent();

			ResultsPerPage = 100;
			indexer.IndexUpdated += new EventHandler(indexer_IndexUpdated);
		}

		public void init(String warfunFile, ulong searchedIndices) {
			_warFun = warfunFile;
			_searchedIndices = searchedIndices;

			setPageCount();
		}

		private void setPageCount() {
			ulong pagecount = (_searchedIndices / ResultsPerPage) + ((_searchedIndices % ResultsPerPage > 0) ? 1ul : 0ul);
			indexer.PagesCount = Math.Max(1, pagecount);
			indexer.PageCurrent = Math.Max(Math.Min(indexer.PageCurrent, indexer.PagesCount), 1);
		}

		void indexer_IndexUpdated(object sender, EventArgs e) {
			updatePage();
		}

		private void IndicesViewer_Load(object sender, EventArgs e) {
			getDrawer().Show();
			updatePage();
		}

		private void IndicesViewer_FormClosing(object sender, FormClosingEventArgs e) {
			if (e.CloseReason == CloseReason.UserClosing) {
				e.Cancel = true;
				this.Hide();
			}
		}

		public bool updatePage() {
			ulong start = (indexer.PageCurrent-1) * ResultsPerPage;
			ulong left = _searchedIndices - start;
			uint count = (uint)Math.Min(left, ResultsPerPage);
			PiLibrary.GetResultValues(args, values, _warFun, start, count);
			//PiLibrary.GetResultValues(args, values, _warFun, start, ResultsPerPage);
			
			flowLayoutPanel1.SuspendLayout();
			for (uint i = 0; i < count; i++) {
				Label l = labels[i];
				l.Text = "       " + args[i] + " : " + values[i];
			}
			for (uint i = count; i < labels.Length; i++) {
				labels[i].Text = null;
			}
			flowLayoutPanel1.ResumeLayout();

			getDrawer().update(args, values, count);
			//getDrawer().update(args, values, ResultsPerPage);
            //PiLibrary.CleanAfterGettingResultValues();
			return true;
		}

		Drawer _drawer = null;
		Drawer getDrawer() {
			if (_drawer == null) {
				_drawer = new Drawer();
			}
			return _drawer;
		}

		internal void init(string p) {
			_warFun = p;
			
			using (StreamReader sr = new StreamReader(_warFun + "00000")) { //always a first file
				String s = sr.ReadToEnd();
				String[] sa = s.Split(';');
				//ulong a = ulong.Parse(sa[0]);
				ulong b = ulong.Parse(sa[1]);
				//_searchedIndices = a + b - 1;
				_searchedIndices = b;
			}

			setPageCount();
		}

		private void IndicesViewer_VisibleChanged(object sender, EventArgs e) {
			getDrawer().Visible = this.Visible;
		}
	}
}