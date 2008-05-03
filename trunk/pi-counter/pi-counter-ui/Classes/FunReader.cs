using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace pi_counter_ui.Classes {
	class FunReader {
		public static void getValues(out string[] arguments, out UInt32[] values, string filename, ulong startIndex, uint count) {
			//TODO: Tomek - zaimplementuj tê funkcjê w bibliotece C i j¹ tu wywo³aj
			Random rnd = new Random();
			arguments = new string[count];
			values = new uint[count];
			for (int i = 0; i < count; i++) {
				arguments[i] = i.ToString();
				values[i] = (uint)rnd.Next();
			}
		}
	}
}
