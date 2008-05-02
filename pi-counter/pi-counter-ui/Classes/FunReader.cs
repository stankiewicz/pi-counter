using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace pi_counter_ui.Classes {
	class FunReader {
		public static ulong[] getValues(string filename, ulong startIndex, ushort count) {
			FileStream fs;
			try {
				fs = File.OpenRead(filename);
			} catch (Exception exc) {
				return null;
			}

			ulong[] res = new ulong[count];
			fs.ReadByte();
			return res;
		}
	}
}
