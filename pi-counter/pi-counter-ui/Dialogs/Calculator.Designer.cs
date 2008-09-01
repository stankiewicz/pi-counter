namespace pi_counter_ui.Dialogs {
	partial class Calculator {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
			this.fieldOp = new System.Windows.Forms.ComboBox();
			this.btnLoadArg1 = new System.Windows.Forms.Button();
			this.btnSaveArg1 = new System.Windows.Forms.Button();
			this.btnLoadArg2 = new System.Windows.Forms.Button();
			this.btnSaveArg2 = new System.Windows.Forms.Button();
			this.btnSaveRes1 = new System.Windows.Forms.Button();
			this.btnSaveRes2 = new System.Windows.Forms.Button();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.btnCalculate = new System.Windows.Forms.Button();
			this.panelArg1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panelArg2 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panelOp = new System.Windows.Forms.FlowLayoutPanel();
			this.fieldOpInfo = new System.Windows.Forms.Label();
			this.panelRes1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panelRes2 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.checkBoxCompare = new System.Windows.Forms.CheckBox();
			this.arg1 = new pi_counter_ui.Controls.PagedText();
			this.arg2 = new pi_counter_ui.Controls.PagedText();
			this.res1 = new pi_counter_ui.Controls.PagedText();
			this.res2 = new pi_counter_ui.Controls.PagedText();
			this.panelArg1.SuspendLayout();
			this.panelArg2.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.panelOp.SuspendLayout();
			this.panelRes1.SuspendLayout();
			this.panelRes2.SuspendLayout();
			this.SuspendLayout();
			// 
			// fieldOp
			// 
			this.fieldOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.fieldOp.FormattingEnabled = true;
			this.fieldOp.Location = new System.Drawing.Point(2, 3);
			this.fieldOp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.fieldOp.Name = "fieldOp";
			this.fieldOp.Size = new System.Drawing.Size(122, 21);
			this.fieldOp.TabIndex = 4;
			this.toolTip1.SetToolTip(this.fieldOp, "Choose operation");
			this.fieldOp.SelectedIndexChanged += new System.EventHandler(this.fieldOp_SelectedIndexChanged);
			// 
			// btnLoadArg1
			// 
			this.btnLoadArg1.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnLoadArg1.Location = new System.Drawing.Point(833, 3);
			this.btnLoadArg1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnLoadArg1.Name = "btnLoadArg1";
			this.btnLoadArg1.Size = new System.Drawing.Size(15, 38);
			this.btnLoadArg1.TabIndex = 11;
			this.btnLoadArg1.Tag = "0";
			this.btnLoadArg1.Text = "L";
			this.toolTip1.SetToolTip(this.btnLoadArg1, "Load bignum");
			this.btnLoadArg1.UseVisualStyleBackColor = true;
			this.btnLoadArg1.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnSaveArg1
			// 
			this.btnSaveArg1.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSaveArg1.Location = new System.Drawing.Point(852, 3);
			this.btnSaveArg1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnSaveArg1.Name = "btnSaveArg1";
			this.btnSaveArg1.Size = new System.Drawing.Size(15, 38);
			this.btnSaveArg1.TabIndex = 12;
			this.btnSaveArg1.Tag = "0";
			this.btnSaveArg1.Text = "S";
			this.toolTip1.SetToolTip(this.btnSaveArg1, "Save as plain file");
			this.btnSaveArg1.UseVisualStyleBackColor = true;
			this.btnSaveArg1.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnLoadArg2
			// 
			this.btnLoadArg2.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnLoadArg2.Location = new System.Drawing.Point(833, 3);
			this.btnLoadArg2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnLoadArg2.Name = "btnLoadArg2";
			this.btnLoadArg2.Size = new System.Drawing.Size(15, 38);
			this.btnLoadArg2.TabIndex = 13;
			this.btnLoadArg2.Tag = "1";
			this.btnLoadArg2.Text = "L";
			this.toolTip1.SetToolTip(this.btnLoadArg2, "Load bignum");
			this.btnLoadArg2.UseVisualStyleBackColor = true;
			this.btnLoadArg2.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnSaveArg2
			// 
			this.btnSaveArg2.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSaveArg2.Location = new System.Drawing.Point(852, 3);
			this.btnSaveArg2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnSaveArg2.Name = "btnSaveArg2";
			this.btnSaveArg2.Size = new System.Drawing.Size(15, 38);
			this.btnSaveArg2.TabIndex = 14;
			this.btnSaveArg2.Tag = "1";
			this.btnSaveArg2.Text = "S";
			this.toolTip1.SetToolTip(this.btnSaveArg2, "Save as plain file");
			this.btnSaveArg2.UseVisualStyleBackColor = true;
			this.btnSaveArg2.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnSaveRes1
			// 
			this.btnSaveRes1.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSaveRes1.Location = new System.Drawing.Point(833, 3);
			this.btnSaveRes1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnSaveRes1.Name = "btnSaveRes1";
			this.btnSaveRes1.Size = new System.Drawing.Size(15, 38);
			this.btnSaveRes1.TabIndex = 16;
			this.btnSaveRes1.Tag = "2";
			this.btnSaveRes1.Text = "S";
			this.toolTip1.SetToolTip(this.btnSaveRes1, "Save as plain file");
			this.btnSaveRes1.UseVisualStyleBackColor = true;
			this.btnSaveRes1.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnSaveRes2
			// 
			this.btnSaveRes2.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSaveRes2.Location = new System.Drawing.Point(833, 3);
			this.btnSaveRes2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnSaveRes2.Name = "btnSaveRes2";
			this.btnSaveRes2.Size = new System.Drawing.Size(15, 38);
			this.btnSaveRes2.TabIndex = 18;
			this.btnSaveRes2.Tag = "3";
			this.btnSaveRes2.Text = "S";
			this.toolTip1.SetToolTip(this.btnSaveRes2, "Save as plain file");
			this.btnSaveRes2.UseVisualStyleBackColor = true;
			this.btnSaveRes2.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.RestoreDirectory = true;
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Bignum files|*.bignum";
			this.openFileDialog.RestoreDirectory = true;
			// 
			// btnCalculate
			// 
			this.btnCalculate.Location = new System.Drawing.Point(2, 236);
			this.btnCalculate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnCalculate.Name = "btnCalculate";
			this.btnCalculate.Size = new System.Drawing.Size(74, 23);
			this.btnCalculate.TabIndex = 20;
			this.btnCalculate.Text = "Calculate";
			this.btnCalculate.UseVisualStyleBackColor = true;
			this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
			// 
			// panelArg1
			// 
			this.panelArg1.AutoSize = true;
			this.panelArg1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelArg1.Controls.Add(this.arg1);
			this.panelArg1.Controls.Add(this.btnLoadArg1);
			this.panelArg1.Controls.Add(this.btnSaveArg1);
			this.panelArg1.Location = new System.Drawing.Point(3, 3);
			this.panelArg1.Name = "panelArg1";
			this.panelArg1.Size = new System.Drawing.Size(869, 44);
			this.panelArg1.TabIndex = 0;
			// 
			// panelArg2
			// 
			this.panelArg2.AutoSize = true;
			this.panelArg2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelArg2.Controls.Add(this.arg2);
			this.panelArg2.Controls.Add(this.btnLoadArg2);
			this.panelArg2.Controls.Add(this.btnSaveArg2);
			this.panelArg2.Location = new System.Drawing.Point(3, 53);
			this.panelArg2.Name = "panelArg2";
			this.panelArg2.Size = new System.Drawing.Size(869, 44);
			this.panelArg2.TabIndex = 24;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.panelArg1);
			this.flowLayoutPanel1.Controls.Add(this.panelArg2);
			this.flowLayoutPanel1.Controls.Add(this.panelOp);
			this.flowLayoutPanel1.Controls.Add(this.panelRes1);
			this.flowLayoutPanel1.Controls.Add(this.panelRes2);
			this.flowLayoutPanel1.Controls.Add(this.btnCalculate);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(933, 275);
			this.flowLayoutPanel1.TabIndex = 25;
			// 
			// panelOp
			// 
			this.panelOp.AutoSize = true;
			this.panelOp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelOp.Controls.Add(this.fieldOp);
			this.panelOp.Controls.Add(this.checkBoxCompare);
			this.panelOp.Controls.Add(this.fieldOpInfo);
			this.panelOp.Location = new System.Drawing.Point(3, 103);
			this.panelOp.Name = "panelOp";
			this.panelOp.Size = new System.Drawing.Size(246, 27);
			this.panelOp.TabIndex = 27;
			// 
			// fieldOpInfo
			// 
			this.fieldOpInfo.AutoSize = true;
			this.fieldOpInfo.Dock = System.Windows.Forms.DockStyle.Left;
			this.fieldOpInfo.Location = new System.Drawing.Point(208, 0);
			this.fieldOpInfo.Name = "fieldOpInfo";
			this.fieldOpInfo.Size = new System.Drawing.Size(35, 27);
			this.fieldOpInfo.TabIndex = 5;
			this.fieldOpInfo.Text = "label1";
			this.fieldOpInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panelRes1
			// 
			this.panelRes1.AutoSize = true;
			this.panelRes1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelRes1.Controls.Add(this.res1);
			this.panelRes1.Controls.Add(this.btnSaveRes1);
			this.panelRes1.Location = new System.Drawing.Point(3, 136);
			this.panelRes1.Name = "panelRes1";
			this.panelRes1.Size = new System.Drawing.Size(850, 44);
			this.panelRes1.TabIndex = 26;
			// 
			// panelRes2
			// 
			this.panelRes2.AutoSize = true;
			this.panelRes2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelRes2.Controls.Add(this.res2);
			this.panelRes2.Controls.Add(this.btnSaveRes2);
			this.panelRes2.Location = new System.Drawing.Point(3, 186);
			this.panelRes2.Name = "panelRes2";
			this.panelRes2.Size = new System.Drawing.Size(850, 44);
			this.panelRes2.TabIndex = 26;
			// 
			// checkBoxCompare
			// 
			this.checkBoxCompare.AutoSize = true;
			this.checkBoxCompare.Location = new System.Drawing.Point(129, 3);
			this.checkBoxCompare.Name = "checkBoxCompare";
			this.checkBoxCompare.Size = new System.Drawing.Size(73, 17);
			this.checkBoxCompare.TabIndex = 6;
			this.checkBoxCompare.Text = "Show diff.";
			this.toolTip1.SetToolTip(this.checkBoxCompare, "Check to visually compare arg1 and arg2");
			this.checkBoxCompare.UseVisualStyleBackColor = true;
			this.checkBoxCompare.CheckedChanged += new System.EventHandler(this.checkBoxCompare_CheckedChanged);
			// 
			// arg1
			// 
			this.arg1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.arg1.AutoSize = true;
			this.arg1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.arg1.Buffer = ((System.Text.StringBuilder)(resources.GetObject("arg1.Buffer")));
			this.arg1.CharsToShow = 10;
			this.arg1.IndexToShow = 0;
			this.arg1.Location = new System.Drawing.Point(2, 3);
			this.arg1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.arg1.Name = "arg1";
			this.arg1.Size = new System.Drawing.Size(827, 38);
			this.arg1.TabIndex = 21;
			// 
			// arg2
			// 
			this.arg2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.arg2.AutoSize = true;
			this.arg2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.arg2.Buffer = ((System.Text.StringBuilder)(resources.GetObject("arg2.Buffer")));
			this.arg2.CharsToShow = 10;
			this.arg2.IndexToShow = 0;
			this.arg2.Location = new System.Drawing.Point(2, 3);
			this.arg2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.arg2.Name = "arg2";
			this.arg2.Size = new System.Drawing.Size(827, 38);
			this.arg2.TabIndex = 22;
			// 
			// res1
			// 
			this.res1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.res1.AutoSize = true;
			this.res1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.res1.Buffer = ((System.Text.StringBuilder)(resources.GetObject("res1.Buffer")));
			this.res1.CharsToShow = 10;
			this.res1.IndexToShow = 0;
			this.res1.Location = new System.Drawing.Point(2, 3);
			this.res1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.res1.Name = "res1";
			this.res1.Size = new System.Drawing.Size(827, 38);
			this.res1.TabIndex = 23;
			// 
			// res2
			// 
			this.res2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.res2.AutoSize = true;
			this.res2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.res2.Buffer = ((System.Text.StringBuilder)(resources.GetObject("res2.Buffer")));
			this.res2.CharsToShow = 10;
			this.res2.IndexToShow = 0;
			this.res2.Location = new System.Drawing.Point(2, 3);
			this.res2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.res2.Name = "res2";
			this.res2.Size = new System.Drawing.Size(827, 38);
			this.res2.TabIndex = 24;
			// 
			// Calculator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(933, 275);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.Name = "Calculator";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Calculator";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Calculator_FormClosing);
			this.panelArg1.ResumeLayout(false);
			this.panelArg1.PerformLayout();
			this.panelArg2.ResumeLayout(false);
			this.panelArg2.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.panelOp.ResumeLayout(false);
			this.panelOp.PerformLayout();
			this.panelRes1.ResumeLayout(false);
			this.panelRes1.PerformLayout();
			this.panelRes2.ResumeLayout(false);
			this.panelRes2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox fieldOp;
		private System.Windows.Forms.Button btnLoadArg1;
		private System.Windows.Forms.Button btnSaveArg1;
		private System.Windows.Forms.Button btnLoadArg2;
		private System.Windows.Forms.Button btnSaveArg2;
		private System.Windows.Forms.Button btnSaveRes1;
		private System.Windows.Forms.Button btnSaveRes2;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Button btnCalculate;
		private pi_counter_ui.Controls.PagedText res2;
		private pi_counter_ui.Controls.PagedText arg1;
		private pi_counter_ui.Controls.PagedText arg2;
		private pi_counter_ui.Controls.PagedText res1;
		private System.Windows.Forms.FlowLayoutPanel panelArg1;
		private System.Windows.Forms.FlowLayoutPanel panelArg2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel panelRes2;
		private System.Windows.Forms.FlowLayoutPanel panelRes1;
		private System.Windows.Forms.FlowLayoutPanel panelOp;
		private System.Windows.Forms.Label fieldOpInfo;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox checkBoxCompare;
	}
}