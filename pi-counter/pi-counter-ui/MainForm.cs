using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using pi_counter_ui.Dialogs;

namespace pi_counter_ui {
	public partial class MainForm : Form {
		enum Modes { PiCalculation, PiSearch };
		enum State { Ready, Calculating, Searching };

		State currentState = State.Ready;

		public MainForm() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			//TODO: remove when ready
			//calculationStatus1.buttonResult.Click += new EventHandler(buttonResult_Click);

			setMode(Modes.PiCalculation);
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
		#endregion

		void setMode(Modes mode) {
			switch (mode) {
				case Modes.PiCalculation:
					this.labelInfo.Text = "Pi calculation mode.\r\nYou can specify constraints.";
					this.panelSearch.Visible = false;

					this.panelCalculationStatus.buttonStart.Click -= new EventHandler(buttonStart_Click_Calculate);
					this.panelCalculationStatus.buttonStart.Click -= new EventHandler(buttonStart_Click_Search);
					this.panelCalculationStatus.buttonStart.Click += new EventHandler(buttonStart_Click_Calculate);
					break;
				case Modes.PiSearch:
					this.labelInfo.Text = "Pi search mode.\r\nYou can specify constraints and searched numbers' range.";
					this.panelSearch.Visible = true;

					this.panelCalculationStatus.buttonStart.Click -= new EventHandler(buttonStart_Click_Calculate);
					this.panelCalculationStatus.buttonStart.Click -= new EventHandler(buttonStart_Click_Search);
					this.panelCalculationStatus.buttonStart.Click += new EventHandler(buttonStart_Click_Search);
					break;
				default:
					break;
			}
		}

		void buttonStart_Click_Search(object sender, EventArgs e) {
			
		}

		bool unconditionalStop = false;
		/// <summary>
		/// Zwraca true gdy obliczenie pi ma siê zakoñczyæ
		/// </summary>
		/// <param name="digitsPercentage"></param>
		/// <returns></returns>
		bool piListener(float digitsPercentage) {
			Console.WriteLine("Percent complete: {0}", digitsPercentage);

			if (unconditionalStop) {
				Console.WriteLine("Aborting calculations...");
				return true;
			}

			//sprawdŸ czas
			return false;
		}

		void buttonStart_Click_Calculate(object sender, EventArgs e) {
			if (currentState == State.Ready) {
				int digitsToCalculate = 1000;
				if (panelConstraints.LengthConstraintEnabled) {
					digitsToCalculate = (int)panelConstraints.LengthConstraint;
				}
				try {
					Console.WriteLine("Starting calculations for {0} digits", digitsToCalculate);
					PiLibrary.generatePi(digitsToCalculate, new PiLibrary.ListenerEmpty(piListener));
				} catch (DllNotFoundException nfe) {
					MessageBox.Show("Could not found piCounter.dll\r\n" + nfe.ToString());
				}
				Console.WriteLine("Finished");
			} else if (currentState == State.Calculating) {
				Console.WriteLine("Stopping");
				unconditionalStop = true;
			}
		}
	}
}
