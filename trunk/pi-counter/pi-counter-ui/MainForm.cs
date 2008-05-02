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
		Modes currentMode = Modes.PiCalculation;
		String piFilename;

		bool unconditionalStop = false;

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
		About about = null;
		PiViewer piViewer = null;
		IndicesViewer indicesViewer = null;

		About getAbout() {
			if (about == null) {
				about = new About();
			}
			return about;
		}

		PiViewer getPiViewer() {
			if (piViewer == null) {
				piViewer = new PiViewer();
			}
			return piViewer;
		}

		IndicesViewer getIndicesViewer() {
			if (indicesViewer == null) {
				indicesViewer = new IndicesViewer();
			}
			return indicesViewer;
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
			currentMode = mode;
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
			switch (currentMode) {
				case Modes.PiCalculation:
					if (!threadCalculation.IsBusy) {
						if (saveFileDialog.ShowDialog() != DialogResult.OK) {
							return;
						}
						piFilename = saveFileDialog.FileName;
						panelCalculationStatus.buttonStart.Text = "Stop";
						panelConstraints.Enabled = false;						
						threadCalculation.RunWorkerAsync();
					} else {
						Console.WriteLine("Stopping");
						MessageBox.Show("The calculation will stop as soon as possible (without loosing calculation results)");
						unconditionalStop = true;
					}
					break;
				case Modes.PiSearch:
					if (!threadSearch.IsBusy) {
						if (openFileDialogSearch.ShowDialog() != DialogResult.OK) {
							return;
						}
						piFilename = openFileDialogSearch.FileName;
						panelCalculationStatus.buttonStart.Text = "Stop";
						panelConstraints.Enabled = false;
						threadSearch.RunWorkerAsync();
						Console.WriteLine("Finished");
					} else {
						Console.WriteLine("Stopping search");
						MessageBox.Show("The search will stop as soon as possible (without loosing search results)");
						unconditionalStop = true;
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
			Console.WriteLine("returning:" + unconditionalStop);

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
			return unconditionalStop;
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
				unconditionalStop = false;
				PiLibrary.generatePi(piFilename, digitsToCalculate, maxTimeMs, new PiLibrary.CoolListener(coolListener));
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
			Bignum b = new Bignum(piFilename);
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
				unconditionalStop = false;
				PiLibrary.CalculateFunction(piFilename, panelSearch.fieldFrom.Text, panelSearch.fieldTo.Text, maxTimeMs, digitsToCheck, new PiLibrary.CoolListener(coolListener));
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
	}
}
