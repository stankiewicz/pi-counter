using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace pi_counter_ui.Classes {
	class FunReader {
		public static string[] getValues(string filename, ulong startIndex, uint count) {
			//TODO: Tomek - zaimplementuj tê funkcjê w bibliotece C i j¹ tu wywo³aj
			Random rnd = new Random();
			string[] res = new string[count];
			for (int i = 0; i < count; i++) {
				res[i] = rnd.Next().ToString();
			}
			return res;
		}
	}
}
