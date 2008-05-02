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
		public delegate bool CoolListener(Int32 timePercentCompleted, Int32 lengthPercentCompleted);

		[DllImport(libPath, CharSet = CharSet.Auto, CallingConvention=CallingConvention.Cdecl)]
		public static extern void generatePi([MarshalAs(UnmanagedType.LPWStr)] String fileName, Int32 digits, Int32 maxTimeMs, CoolListener listener);

		[DllImport(libPath, CharSet = CharSet.Auto, CallingConvention=CallingConvention.Cdecl)]
		public static extern void CalculateFunction([MarshalAs(UnmanagedType.LPWStr)] String filename, [MarshalAs(UnmanagedType.LPStr)] String a, [MarshalAs(UnmanagedType.LPStr)] String b, Int32 maxTimeMs, UInt32 numberOfDigitsToCheck, CoolListener listener);
    }
}
