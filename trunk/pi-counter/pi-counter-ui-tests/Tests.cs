using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace pi_counter_ui {
	public static class Tests {
		public static void test() {
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

		public static void test2() {
			try {
				PiLibrary.generatePi(10000, new PiLibrary.ListenerEmpty(showMessage));
			} catch (DllNotFoundException nfe) {
				MessageBox.Show("Brak biblioteki dll:" + nfe.Message);
			}
		}

		public static void testIncrementalGeneration() {
			int digits = 1000000;
			int moreDigits = 1010000;
			try {
				int start = Environment.TickCount;
				PiLibrary.generatePi(digits, null);
				int middle1 = Environment.TickCount;
				PiLibrary.generatePi(digits, null);
				int middle2 = Environment.TickCount;
				PiLibrary.generatePi(moreDigits, null);
				int end = Environment.TickCount;

				Console.WriteLine("First, digits={0}, time={1}", digits, middle1 - start);
				Console.WriteLine("Second, digits={0}, time={1}", digits, middle2 - middle1);
				Console.WriteLine("Third, digits={0}, time{1}", moreDigits, end - middle2);
			} catch (DllNotFoundException nfe) {
				MessageBox.Show("Brak biblioteki dll:" + nfe.Message);
			}
		}

		static void Test(int idxTab, int idxPi) {
			System.Console.Out.WriteLine(idxTab.ToString() + " " + idxPi.ToString());
			System.Console.Out.WriteLine("hello");
		}

		static void showMessage() {
			Console.WriteLine("OK!");
		}
	}
}
