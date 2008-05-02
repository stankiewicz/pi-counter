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
						panelCalculationStatus.buttonStart.Text = "Stop";
						panelConstraints.Enabled = false;
						threadCalculation.RunWorkerAsync();
					} else {
						Console.WriteLine("Stopping");
						unconditionalStop = true;
					}
					break;
				case Modes.PiSearch:
					if (!threadSearch.IsBusy) {
						panelCalculationStatus.buttonStart.Text = "Stop";
						panelConstraints.Enabled = false;
						threadSearch.RunWorkerAsync();
						Console.WriteLine("Finished");
					} else {
						Console.WriteLine("Stopping search");
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
			return unconditionalStop;
		}
		#endregion

		private void threadCalculation_DoWork(object sender, DoWorkEventArgs e) {
			int digitsToCalculate = 1000;
			if (panelConstraints.LengthConstraintEnabled) {
				digitsToCalculate = (int)panelConstraints.LengthConstraint;
			}
			try {
				Console.WriteLine("Starting calculations for {0} digits", digitsToCalculate);
				unconditionalStop = false;
				PiLibrary.generatePi(null, digitsToCalculate, new PiLibrary.CoolListener(coolListener));
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

			//open pi viewer
			Bignum b = new Bignum("pi.bignum");
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
			if (panelConstraints.TimeConstraintEnabled) {
				maxTimeMs = (int)(panelConstraints.TimeConstraint) * 60 * 1000;
			}

			try {
				Console.WriteLine("Starting search");
				unconditionalStop = false;
				PiLibrary.CalculateFunction("result.warfun", panelSearch.fieldFrom.Text, panelSearch.fieldTo.Text, maxTimeMs, 4294967295, new PiLibrary.CoolListener(coolListener));
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
