using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace pi_counter_ui.Classes {
	class FunReader {
		public static string[] getValues(string filename, uint startIndex, uint count) {
			Random rnd = new Random();
			string[] res = new string[count];
			for (int i = 0; i < count; i++) {
				res[i] = rnd.Next().ToString();
			}
			return res;
		}
	}
}
