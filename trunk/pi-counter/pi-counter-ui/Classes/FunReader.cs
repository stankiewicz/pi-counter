using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace pi_counter_ui.Classes {
	class FunReader {
        public const String libPath = "pi-counter.dll";

        [DllImport(libPath, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetResultValues(out string[] arguments, out UInt32[] values, string filename, ulong startIndex, uint count);

        [DllImport(libPath, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CleanAfterGettingResultValues();
        /*
		public static extern void getValues(out string[] arguments, out UInt32[] values, string filename, ulong startIndex, uint count) 
        {
			//TODO: Tomek - zaimplementuj tê funkcjê w bibliotece C i j¹ tu wywo³aj
			Random rnd = new Random();
			arguments = new string[count];
			values = new uint[count];
			for (int i = 0; i < count; i++) {
				arguments[i] = i.ToString();
				values[i] = (uint)rnd.Next();
			}
		}*/
        
	}
}
