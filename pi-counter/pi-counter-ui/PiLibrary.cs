using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace pi_counter_ui {
    public class PiLibrary {
		public const String libPath = "pi-counter.dll";

		public delegate void ListenerEmpty();
		public delegate bool BoolListener();

		//[DllImport(libPath, CharSet = CharSet.Auto)]
		//public static extern void generateNewPi(Int32 digits, Int32 algorithm, ListenerEmpty listner);

		[DllImport(libPath, CharSet = CharSet.Auto, CallingConvention=CallingConvention.Cdecl)]
		public static extern void generatePi(Int32 digits, ListenerEmpty listener);

		[DllImport(libPath, CharSet = CharSet.Auto, CallingConvention=CallingConvention.Cdecl)]
        public static extern void CalculateFunction([MarshalAs(UnmanagedType.LPWStr)] String filename, [MarshalAs(UnmanagedType.LPStr)] String a, [MarshalAs(UnmanagedType.LPStr)] String b, Int32 maxTimeMs, UInt32 numberOfDigitsToCheck, BoolListener listener);
    }
}
