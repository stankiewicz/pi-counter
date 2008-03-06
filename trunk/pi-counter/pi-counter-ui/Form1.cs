using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pi_counter_ui {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			try {
				int idx = PiLibrary.findNumber1("1234");
				System.Console.Out.WriteLine(idx.ToString());
				int count = 10000;
				int[] tab = new int[count];
				string[] n1 = new string[count];
				for (int i = 0; i < count; ++i) n1[i] = i.ToString();
				PiLibrary.findNumbers2Managed(n1, tab, new PiLibrary.listener(Test));
				foreach (int t in tab) {
					System.Console.Out.WriteLine(t.ToString());
				}
				//PiLibrary.findNumbers2Managed(n1, tab, null);
			} catch (DllNotFoundException nfe) {
				MessageBox.Show("Brak biblioteki dll:" + nfe.Message);
			}
		}

		static void Test(int idxTab, int idxPi) {
			System.Console.Out.WriteLine(idxTab.ToString() + " " + idxPi.ToString());
			System.Console.Out.WriteLine("hello");
		}
	}
}