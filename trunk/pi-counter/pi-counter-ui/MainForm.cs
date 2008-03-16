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

			//TODO: remove when ready
			test2();
		}

		void buttonResult_Click(object sender, EventArgs e) {
			IndicesViewer i = getIndicesViewer();
			i.Show();
		}

		static void Test(int idxTab, int idxPi) {
			System.Console.Out.WriteLine(idxTab.ToString() + " " + idxPi.ToString());
			System.Console.Out.WriteLine("hello");
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

		private void test() {
			try {
				int idx = PiLibrary.findNumber1("1234");
				System.Console.Out.WriteLine(idx.ToString());
				int count = 10000;
				int[] tab = new int[count];
				PiLibrary.Listener listener = new PiLibrary.Listener(Test);
				PiLibrary.findNumbersFT("10000", "11000", tab, listener);

				String[] n1 = new string[count];
				for (int i = 0; i < count; ++i) n1[i] = i.ToString();

				PiLibrary.findNumbers2(n1, count, tab, listener);
				//foreach (int t in tab) {
				//    System.Console.Out.WriteLine(t.ToString());
				//}
			} catch (DllNotFoundException nfe) {
				MessageBox.Show("Brak biblioteki dll:" + nfe.Message);
			}
		}

		private void test2() {
			try {
				PiLibrary.generateNewPi(10000, 0, new PiLibrary.ListenerEmpty(showMessage));
			} catch (DllNotFoundException nfe) {
				MessageBox.Show("Brak biblioteki dll:" + nfe.Message);
			}
		}

		void showMessage() {
			Console.WriteLine("OK!");
		}

		private void viewToolStripMenuItem_Click(object sender, EventArgs e) {
			PiViewer p = getPiViewer();
			p.Show();
		}

		private void test2ToolStripMenuItem_Click(object sender, EventArgs e) {
			test2();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}
	}
}