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

        [DllImport(libPath, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void generatePi([MarshalAs(UnmanagedType.LPWStr)] String fileName, Int32 digits, Int32 maxTimeMs, CoolListener listener);

        [DllImport(libPath, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CalculateFunction(CoolListener listener, [MarshalAs(UnmanagedType.LPWStr)] String piFileName, [MarshalAs(UnmanagedType.LPWStr)] String resultFileName, [MarshalAs(UnmanagedType.LPStr)] String a, [MarshalAs(UnmanagedType.LPStr)] String b, Int32 maxTimeMs, UInt32 numberOfDigitsToCheck, ref UInt64 numberOfFound, ref UInt32 digitsChecked, ref UInt64 resultLength);

        [DllImport(libPath, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetResultValues([In][Out][MarshalAsAttribute(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] arguments, [In][Out][MarshalAsAttribute(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4)] UInt32[] values, [MarshalAs(UnmanagedType.LPWStr)]string filename, ulong startIndex, uint count);

        [DllImport(libPath, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CleanAfterGettingResultValues();
        [DllImport(libPath, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int add();
        [DllImport(libPath, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int sub();
        [DllImport(libPath, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int mul();
        [DllImport(libPath, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int divDouble();
        [DllImport(libPath, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int equ();
        [DllImport(libPath, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int divInt();
		[DllImport(libPath, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
		public static extern int fancy(uint n);
		[DllImport(libPath, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
		public static extern int mersenne(uint n);
	}
}
