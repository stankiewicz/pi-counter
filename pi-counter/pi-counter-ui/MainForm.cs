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
			if (currentState == State.Ready) {
				int maxTimeMs = 0;
				if (panelConstraints.TimeConstraintEnabled) {
					maxTimeMs = (int)(panelConstraints.TimeConstraint) * 60 * 1000;
				}

				try {
					Console.WriteLine("Starting search");
					unconditionalStop = false;
					panelCalculationStatus.setState(pi_counter_ui.Controls.CalculationStatus.CalculationState.Stop);
					PiLibrary.CalculateFunction("result.warfun", panelSearch.fieldFrom.Text, panelSearch.fieldTo.Text, maxTimeMs, 4294967295, null);
				} catch (DllNotFoundException nfe) {
					MessageBox.Show("Could not found piCounter.dll\r\n" + nfe.ToString());
				} finally {
					panelCalculationStatus.setState(pi_counter_ui.Controls.CalculationStatus.CalculationState.Start);
				}
				Console.WriteLine("Finished");
			} else if (currentState == State.Searching) {
				Console.WriteLine("Stopping search");
				unconditionalStop = true;
			}
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

		void voidListener() {
			Console.WriteLine("Listener called.");
		}

		void buttonStart_Click_Calculate(object sender, EventArgs e) {
			if (currentState == State.Ready) {
				int digitsToCalculate = 1000;
				if (panelConstraints.LengthConstraintEnabled) {
					digitsToCalculate = (int)panelConstraints.LengthConstraint;
				}
				try {
					Console.WriteLine("Starting calculations for {0} digits", digitsToCalculate);
					unconditionalStop = false;
					panelCalculationStatus.setState(pi_counter_ui.Controls.CalculationStatus.CalculationState.Stop);
					PiLibrary.generatePi(digitsToCalculate, new PiLibrary.ListenerEmpty(voidListener));
				} catch (DllNotFoundException nfe) {
					MessageBox.Show("Could not found piCounter.dll\r\n" + nfe.ToString());
				} finally {
					panelCalculationStatus.setState(pi_counter_ui.Controls.CalculationStatus.CalculationState.Start);
				}
				Console.WriteLine("Finished");
			} else if (currentState == State.Calculating) {
				Console.WriteLine("Stopping");
				unconditionalStop = true;
			}
		}

		private void searchToolStripMenuItem_Click_1(object sender, EventArgs e) {
			setMode(Modes.PiSearch);
		}
	}
}
