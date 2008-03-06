using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace pi_counter_ui {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Form1());

            int idx = PiLibrary.findNumber1("1234");
            //int idx = PiLibrary.foo();
            System.Console.Out.WriteLine(idx.ToString());
            int count = 100000;
            int [] tab = new int[count];
            string[] n1 = new string[count];
            for (int i = 0; i < count; ++i) n1[i] = i.ToString();
            PiLibrary.findNumbers2Managed(n1, tab, new PiLibrary.listener(Test));
            foreach (int t in tab) {
                System.Console.Out.WriteLine(t.ToString());
            }
            //PiLibrary.findNumbers2Managed(n1, tab, null);
            Thread.Sleep(1000);
        }

        static void Test(int idxTab, int idxPi) {
            System.Console.Out.WriteLine(idxTab.ToString() + " " + idxPi.ToString());
            System.Console.Out.WriteLine("hello");
        }
	}
}