using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using pi_counter_ui.Dialogs;

namespace pi_counter_ui {
	public partial class MainForm : Form {

		About about = null;
		PiViewer piViewer = null;
		IndicesViewer indicesViewer = null;

		public MainForm() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			calculationStatus1.buttonResult.Click += new EventHandler(buttonResult_Click);
		}

		void buttonResult_Click(object sender, EventArgs e) {
			IndicesViewer i = getIndicesViewer();
			i.Show();
		}		

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
			About about = getAbout();
			about.ShowDialog();
		}

		About getAbout() {
			if (about == null) {
				about = new About();
			}
			return about;
		}

		PiViewer getPiViewer() {
			if (piViewer == null) {
				piViewer = new PiViewer();
			}
			return piViewer;
		}

		IndicesViewer getIndicesViewer() {
			if (indicesViewer == null) {
				indicesViewer = new IndicesViewer();
			}
			return indicesViewer;
		}

		private void viewToolStripMenuItem_Click(object sender, EventArgs e) {
			PiViewer p = getPiViewer();
			p.Show();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}
	}
}