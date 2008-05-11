using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using pi_counter_ui.Dialogs;
using pi_counter_ui.Classes;

namespace pi_counter_ui {
	public partial class MainForm : Form {
		enum Modes { PiCalculation, PiSearch };
		Modes _currentMode = Modes.PiCalculation;
		String _piFilename;
		String _warfun;
		ulong _numberOfFoundIndices;
		uint _numberOfDigitsChecked;
		ulong _numberOfSearchedIndices;

		bool _unconditionalStop = false;

		public MainForm() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			setMode(Modes.PiCalculation);

			this.panelCalculationStatus.buttonStart.Click += new EventHandler(buttonStart_Click);
		}

		void buttonResult_Click(object sender, EventArgs e) {
			IndicesViewer i = getIndicesViewer();
			i.Show();
		}		

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
			About about = getAbout();
			about.ShowDialog();
		}

		#region forms
		About _about = null;
		PiViewer _piViewer = null;
		IndicesViewer _indicesViewer = null;
		Calculator _calc = null;

		About getAbout() {
			if (_about == null) {
				_about = new About();
			}
			return _about;
		}

		PiViewer getPiViewer() {
			if (_piViewer == null) {
				_piViewer = new PiViewer();
			}
			return _piViewer;
		}

		IndicesViewer getIndicesViewer() {
			if (_indicesViewer == null) {
				_indicesViewer = new IndicesViewer();
			}
			return _indicesViewer;
		}

		Calculator getCalculator() {
			if (_calc == null) {
				_calc = new Calculator();
			}
			return _calc;
		}
		#endregion

		#region menu handlers
		private void viewToolStripMenuItem_Click(object sender, EventArgs e) {
			PiViewer p = getPiViewer();
			p.ShowDialog();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void calculateToolStripMenuItem_Click(object sender, EventArgs e) {
			setMode(Modes.PiCalculation);
		}

		private void searchToolStripMenuItem_Click_1(object sender, EventArgs e) {
			setMode(Modes.PiSearch);
		}
		#endregion

		void setMode(Modes mode) {
			_currentMode = mode;
			switch (mode) {
				case Modes.PiCalculation:
					this.labelInfo.Text = "Pi calculation mode.\r\nYou can specify constraints.";
					this.panelSearch.Visible = false;
					break;
				case Modes.PiSearch:
					this.labelInfo.Text = "Pi search mode.\r\nYou can specify constraints and searched numbers' range.";
					this.panelSearch.Visible = true;
					break;
				default:
					break;
			}
		}

		void buttonStart_Click(object sender, EventArgs e) {
			switch (_currentMode) {
				case Modes.PiCalculation:
					if (!threadCalculation.IsBusy) {
						if (saveFileDialog.ShowDialog() != DialogResult.OK) {
							return;
						}
						_piFilename = saveFileDialog.FileName;
						panelCalculationStatus.buttonStart.Text = "Stop";
						panelConstraints.Enabled = false;						
						threadCalculation.RunWorkerAsync();
					} else {
						Console.WriteLine("Stopping");
						MessageBox.Show("The calculation will stop as soon as possible (without loosing calculation results)");
						_unconditionalStop = true;
					}
					break;
				case Modes.PiSearch:
					if (!threadSearch.IsBusy) {
						if (openFileDialog.ShowDialog() != DialogResult.OK) {
							return;
						}
						if (saveFileDialogSearch.ShowDialog() != DialogResult.OK) {
							return;
						}
						_piFilename = openFileDialog.FileName;
						_warfun = saveFileDialogSearch.FileName;
						panelCalculationStatus.buttonStart.Text = "Stop";
						panelConstraints.Enabled = false;
						threadSearch.RunWorkerAsync();
						Console.WriteLine("Finished");
					} else {
						Console.WriteLine("Stopping search");
						MessageBox.Show("The search will stop as soon as possible (without loosing search results)");
						_unconditionalStop = true;
					}
					break;
				default:
					break;
			}
		}

		#region listeners
		void voidListener() {
			Console.WriteLine("Listener called.");
		}

		bool coolListener(Int32 timePercent, Int32 lengthPercent) {
			Console.WriteLine("coolListenerCalled, time=" + timePercent + ", length=" + lengthPercent);
			Console.WriteLine("returning:" + _unconditionalStop);

			timePercent = Math.Max(Math.Min(100, timePercent), 0);
			lengthPercent = Math.Max(Math.Min(100, lengthPercent), 0);
			if (panelCalculationStatus.InvokeRequired) {
				panelCalculationStatus.Invoke(new MethodInvoker(
					delegate() {
						panelCalculationStatus.ConstraintTime = timePercent;
						panelCalculationStatus.ConstraintLength = lengthPercent;
					}));
			} else {
				panelCalculationStatus.ConstraintLength = lengthPercent;
				panelCalculationStatus.ConstraintTime = timePercent;
			}
			return _unconditionalStop;
		}
		#endregion

		private void threadCalculation_DoWork(object sender, DoWorkEventArgs e) {
			int digitsToCalculate = 1000;
			int maxTimeMs = 0;
			if (panelConstraints.TimeConstraintEnabled) {
				maxTimeMs = (int)(panelConstraints.TimeConstraint) * 60 * 1000;
			}
			if (panelConstraints.LengthConstraintEnabled) {
				digitsToCalculate = (int)panelConstraints.LengthConstraint;
			}
			try {
				Console.WriteLine("Starting calculations for {0} digits", digitsToCalculate);
				_unconditionalStop = false;
				PiLibrary.generatePi(_piFilename, digitsToCalculate, maxTimeMs, new PiLibrary.CoolListener(coolListener));
			} catch (DllNotFoundException nfe) {
				MessageBox.Show("Could not found piCounter.dll\r\n" + nfe.ToString());
			}
		}

		private void threadCalculation_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			panelCalculationStatus.buttonStart.Text = "Start";
			Console.WriteLine("Finished");
			MessageBox.Show("Calculation finished");
			panelConstraints.Enabled = true;
			panelCalculationStatus.Enabled = true;
			panelCalculationStatus.ConstraintLength = panelCalculationStatus.ConstraintTime = 0;

			//open pi viewer
			Bignum b = new Bignum(_piFilename);
			if (!b.Open()) {
				MessageBox.Show("Load failed :(");
				return;
			}

			PiViewer pV = getPiViewer();
			pV.Bignum = b;
			pV.ShowDialog();
		}

		private void threadSearch_DoWork(object sender, DoWorkEventArgs e) {
			int maxTimeMs = 0;
			uint digitsToCheck = 2000000000;
			if (panelConstraints.TimeConstraintEnabled) {
				maxTimeMs = (int)(panelConstraints.TimeConstraint) * 60 * 1000;
			}
			if (panelConstraints.LengthConstraintEnabled) {
				digitsToCheck = (uint)panelConstraints.LengthConstraint;
			}

			try {
				Console.WriteLine("Starting search");
				_unconditionalStop = false;
				PiLibrary.CalculateFunction(new PiLibrary.CoolListener(coolListener), _piFilename, _warfun, panelSearch.fieldFrom.Text, panelSearch.fieldTo.Text, maxTimeMs, digitsToCheck, ref _numberOfFoundIndices, ref _numberOfDigitsChecked, ref _numberOfSearchedIndices);
			} catch (DllNotFoundException nfe) {
				MessageBox.Show("Could not found piCounter.dll\r\n" + nfe.ToString());
			}
		}		

		private void threadSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			panelCalculationStatus.buttonStart.Text = "Start";
			Console.WriteLine("Finished");
			MessageBox.Show("Search finished");
			panelConstraints.Enabled = true;
			panelCalculationStatus.Enabled = true;
			panelCalculationStatus.ConstraintLength = panelCalculationStatus.ConstraintTime = 0;

			//todo: poka¿ wynik
			MessageBox.Show(String.Format("Found: {0}, Checked: {1}", _numberOfFoundIndices, _numberOfDigitsChecked));
			IndicesViewer iv = getIndicesViewer();
			iv.init(_warfun, _numberOfSearchedIndices);
			iv.ShowDialog();
		}

		private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
			if (openFileDialog.ShowDialog() != DialogResult.OK) {
				return;
			}

			string filepath = openFileDialog.FileName;
			Bignum b = new Bignum(filepath);
			if (!b.Open()) {
				MessageBox.Show("Load failed :(");
				return;
			}

			PiViewer pV = getPiViewer();
			pV.Bignum = b;
			pV.ShowDialog();
		}

		private void calculatorToolStripMenuItem_Click(object sender, EventArgs e) {
			Calculator calc = getCalculator();
			calc.ShowDialog();
		}
	}
}
