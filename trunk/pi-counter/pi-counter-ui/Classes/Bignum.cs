using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace pi_counter_ui.Classes {
	public sealed class Bignum {
		string _filepath;
		public string Filename {
			get { return _filepath; }
		}

		ushort _filesCount;
		ulong _digitsBeforeDot;
		ulong _digitsAfterDot;
		string[] dataFiles;
		long[] dataFilesLength;
		bool opened = false;

		public Bignum(string filepath) {
			_filepath = filepath;
		}

		public bool Open() {
			StreamReader sr = null;
			string bignumInfo;
			try {
				sr = new StreamReader(_filepath);
				
				bignumInfo = sr.ReadToEnd();
				sr.Close();
			} catch {
				return false;
			} finally {
				if (sr != null) {
					sr.Close();
				}
			}
			
			string[] strValues = bignumInfo.Split(' ');
			if (strValues.Length != 3) {
				Debug.WriteLine("Invalid file format");
				return false;
			}

			_filesCount = ushort.Parse(strValues[0]);
			_digitsBeforeDot = ulong.Parse(strValues[1]);
			_digitsAfterDot = ulong.Parse(strValues[2]);

			dataFiles = new string[_filesCount];
			dataFilesLength = new long[_filesCount];
			for (int i = 0; i < _filesCount; i++) {
				string dataFile = _filepath + String.Format("{0:00000}", i);
				dataFiles[i] = dataFile;
				FileStream fs = null;
				try {
					fs = File.OpenRead(dataFile);
					dataFilesLength[i] = fs.Length;
				} catch {
					return false;
				} finally {
					if (fs != null) {
						fs.Close();
					}
				}
			}

			opened = true;
			return true;			
		}

		public uint getMaxDigits() {
			if (!opened) {
				Debug.WriteLine("Bignum not opened");
				return 0;
			}
			uint res = 0;
			foreach (uint count in dataFilesLength) {
				res += count;
			}
			return res;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="destArray"></param>
		/// <param name="startIndex"></param>
		/// <param name="digitsCount"></param>
		/// <returns>digits left</returns>
		public int getDigits(byte[] destArray, uint startIndex, int digitsCount) {
			if (!opened) {
				Debug.WriteLine("Bignum not opened");
				return -1;
			}

			if (destArray.Length != digitsCount) {
				Debug.WriteLine("Bad array size");
				return -1;
			}

			if (startIndex /* + digitsCount */ >= getMaxDigits()) {
				Debug.WriteLine("StartIndex after EOF");
				return -1;
			}

			int fileIndex = 0;
			long offset = startIndex;
			while (offset >= dataFilesLength[fileIndex]) {
				offset -= dataFilesLength[fileIndex];
				fileIndex++;
			}
			int digitsLeft = digitsCount;
			int arrayOffset = 0;
			while (digitsLeft > 0 && fileIndex < dataFiles.Length) {
				FileStream fs = File.OpenRead(dataFiles[fileIndex]);
				fs.Seek(offset, SeekOrigin.Begin);
				int bytesRead = fs.Read(destArray, arrayOffset, digitsLeft);
				fs.Close();
				arrayOffset += bytesRead;
				digitsLeft -= bytesRead;
				fileIndex++; //we either read all digits and finish 'while' or there are digits left, and we need to read next file
			}
			return digitsCount - digitsLeft; //digits read
		}
	}
}
