using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace pi_counter_ui.Controls {
	public partial class PagedText : UserControl {

		public event EventHandler displayRangeChanged;
		
		StringBuilder _buffer = new StringBuilder();

		int _dotPosition = 0;

		[Browsable(true)]
		public int CharsToShow {
			get { return (int)fieldLength.Value; }
			set {
				if (value <= 0) {
					throw new ArgumentOutOfRangeException("value", "value must be greater than 0");
				}
				fieldLength.Value = value;
			}
		}

		[Browsable(true)]
		public int IndexToShow {
			get { return (int)fieldIndex.Value; }
			set { fieldIndex.Value = value; }
		}

		public int DotPosition {
			get { return _dotPosition; }
		}

		public StringBuilder Buffer {
			get { return _buffer; }
			set {
				_buffer = value;
				update();
			}
		}

		public PagedText() {
			InitializeComponent();

			fieldIndex.ValueChanged += new EventHandler(onDisplayRangeChanged);
			fieldLength.ValueChanged += new EventHandler(onDisplayRangeChanged);
		}

		void onDisplayRangeChanged(object sender, EventArgs e) {
			UpdateText();

			if (displayRangeChanged != null) {
				displayRangeChanged(this, null);
			}
		}

		private void textBox1_Validating(object sender, CancelEventArgs e) {
			TextBox tb = sender as TextBox;
			string text = tb.Text;
			
			if (!isValid(text)) {
				e.Cancel = true;
				return;
			}

			//zamiana
			int startIndex = (int)fieldIndex.Value;
			int length = (int)fieldLength.Value;
			
			//zakres do usuniêcia z bufora
			int len = Math.Min(startIndex + length, _buffer.Length - Math.Max(startIndex, 0));
			if (len > 0) {
				_buffer.Remove(Math.Max(startIndex,0), len);
			}
			//dodanie nowego tekstu
			text = text.Trim();
			if (startIndex < _buffer.Length) {
				_buffer.Insert(Math.Max(startIndex, 0), text);
			} else {
				_buffer.Append(text);
			}

			// usun¹æ nadmiarowe znaki +-.
			if (_buffer.Length != 0 && _buffer[0] == '.') {
				_buffer.Remove(0, 1);
			}
			bool hasDot = false;
			for (int i = 1; i < _buffer.Length; i++) {
				char c = _buffer[i];
				if (c == '.') {
					if (hasDot) {
						_buffer.Remove(i, 1);
					} else {
						hasDot = true;
					}
				}else if (c == '+' || c == '-') {
					_buffer.Remove(i, 1);
					i--;
				}
			}
			update();
		}

		bool isValid(string text) {

			//do³¹czamy znak na lewo i na prawo od ci¹gu znaków
			StringBuilder sb = new StringBuilder(text);
			sb.Insert(0, getText((int)fieldIndex.Value - 1, 1));
			sb.Append(getText((int)fieldIndex.Value + (int)fieldLength.Value, 1));

			//usuwamy spacje na pocz¹tku i na koñcu
			text = sb.ToString().Trim();
			//jeœli zawiera spacje to Ÿle
			if (text.Contains(" ")) {
				MessageBox.Show("Number cannot contain spaces between digits");
				return false;
			}
			//sprawdzamy czy znak jest na pocz¹tku
			//int sign = text.IndexOf("+");
			//if (sign != -1 && getText(sign-1,1) != " ") {
			//    this.errorProvider1.SetError(this, "Sign can only be the leftmost character");
			//    return false;
			//}
			//sign = text.IndexOf("-");
			//if (sign != -1 && getText(sign-1,1) != " ") {
			//    this.errorProvider1.SetError(this, "Sign can only be the leftmost character");
			//    return false;
			//}
			//todo sprawdziæ iloœæ + oraz .
			//int signCounter = 0;
			//int dotCounter = 0;
			//bool newTextHasDot = text.Contains(".");
			//bool newTextHasSign = text.Contains("+") || text.Contains("-");
			//for (int i = 0; i < _buffer.Length; i++) {
			//    if (_buffer[i] == '.') {
			//        dotCounter++;
			//    } else if (_buffer[i] == '+' || _buffer[i] == '-') {
			//        signCounter++;
			//    }
			//    if (dotCounter > 0 && newTextHasDot) {
			//        this.errorProvider1.SetError(this, "Only one dot allowed");
			//        return false;
			//    }
			//    if (signCounter > 0 && newTextHasSign) {
			//        this.errorProvider1.SetError(this, "Only one sign allowed");
			//        return false;
			//    }
			//}
			return true;
		}

		void update() {
			_dotPosition = 0;
			while (_dotPosition < _buffer.Length) {
				if (_buffer[_dotPosition] == '.') {
					break;
				}
				_dotPosition++;
			}
			UpdateText();
		}

		public void UpdateText() {
			int startIndex = (int)fieldIndex.Value;
			int length = (int)fieldLength.Value;

			fieldText.Text = getText(startIndex, length);
			fieldDotPos.Text = (_dotPosition + 1).ToString();
			fieldBufferLength.Text = _buffer.Length.ToString();

			if (displayRangeChanged != null) {
				displayRangeChanged(this, null);
			}
		}

		string getText(int index, int len) {
			StringBuilder sb = new StringBuilder();
			for (int i = index; i < index + len; i++) {
				if (i < 0 || i >= _buffer.Length) {
					sb.Append(' ');
				} else  {
					sb.Append(_buffer[i]);
				}
			}
			return sb.ToString();
		}

		//private static string allowedChars = "+-.0123456789";
		private static string allowedChars = "-.0123456789";

		private void fieldText_KeyPress(object sender, KeyPressEventArgs e) {
			if (allowedChars.IndexOf(e.KeyChar) == -1 && e.KeyChar != '\b') {
				e.Handled = true;
			}
		}

		private void btnClear_Click(object sender, EventArgs e) {
			if (_buffer.Length > 0) {
				_buffer.Remove(0, _buffer.Length);
			}
			this.update();
		}
	}
}
