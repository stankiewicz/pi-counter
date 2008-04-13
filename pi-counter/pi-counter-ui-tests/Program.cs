using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace pi_counter_ui_tests {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new TestsForm());
		}
	}
}