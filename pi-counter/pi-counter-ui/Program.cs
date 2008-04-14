using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace pi_counter_ui {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
			//Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
        }
	}
}