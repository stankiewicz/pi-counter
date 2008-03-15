using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace pi_counter_ui {
    public class PiLibrary {

		public const String libPath = "pi-counter.dll";

		public delegate void Listener(Int32 idxInTable, Int32 idxInPi);
		public delegate void ListenerEmpty();

		[DllImport(libPath, CharSet = CharSet.Auto)]
		public static extern int findNumber1([MarshalAs(UnmanagedType.LPStr)] String number);

		[DllImport(libPath, CharSet = CharSet.Auto)]
		public static extern void findNumbersFT( [MarshalAs(UnmanagedType.LPStr)] String from, [MarshalAs(UnmanagedType.LPStr)]String to, Int32[] outTable, Listener listner);

		[DllImport(libPath, CharSet = CharSet.Auto)]
		public static extern void findNumbers2([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)]String[] numbers, Int32 count, Int32[] outTable, Listener listner);

		[DllImport(libPath, CharSet = CharSet.Auto)]
		public static extern void generateNewPi(Int32 digits, Int32 algorithm, ListenerEmpty listner);
    }
}
