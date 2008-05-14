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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
			this.fieldOp = new System.Windows.Forms.ComboBox();
			this.btnLoadArg1 = new System.Windows.Forms.Button();
			this.btnSaveArg1 = new System.Windows.Forms.Button();
			this.btnLoadArg2 = new System.Windows.Forms.Button();
			this.btnSaveArg2 = new System.Windows.Forms.Button();
			this.btnSaveRes1 = new System.Windows.Forms.Button();
			this.btnSaveRes2 = new System.Windows.Forms.Button();
			this.panelRes2 = new System.Windows.Forms.Panel();
			this.res2 = new pi_counter_ui.Controls.PagedText();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.btnCalculate = new System.Windows.Forms.Button();
			this.res1 = new pi_counter_ui.Controls.PagedText();
			this.arg2 = new pi_counter_ui.Controls.PagedText();
			this.arg1 = new pi_counter_ui.Controls.PagedText();
			this.panelRes2.SuspendLayout();
			this.SuspendLayout();
			// 
			// fieldOp
			// 
			this.fieldOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.fieldOp.FormattingEnabled = true;
			this.fieldOp.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/",
            "/ (ca³kowite)",
            "=",
            "2^2^n+1",
            "2^n-1"});
			this.fieldOp.Location = new System.Drawing.Point(12, 70);
			this.fieldOp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.fieldOp.Name = "fieldOp";
			this.fieldOp.Size = new System.Drawing.Size(122, 21);
			this.fieldOp.TabIndex = 4;
			// 
			// btnLoadArg1
			// 
			this.btnLoadArg1.Location = new System.Drawing.Point(763, 9);
			this.btnLoadArg1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnLoadArg1.Name = "btnLoadArg1";
			this.btnLoadArg1.Size = new System.Drawing.Size(25, 23);
			this.btnLoadArg1.TabIndex = 11;
			this.btnLoadArg1.Tag = "";
			this.btnLoadArg1.Text = "L";
			this.btnLoadArg1.UseVisualStyleBackColor = true;
			this.btnLoadArg1.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnSaveArg1
			// 
			this.btnSaveArg1.Location = new System.Drawing.Point(793, 9);
			this.btnSaveArg1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnSaveArg1.Name = "btnSaveArg1";
			this.btnSaveArg1.Size = new System.Drawing.Size(25, 23);
			this.btnSaveArg1.TabIndex = 12;
			this.btnSaveArg1.Text = "S";
			this.btnSaveArg1.UseVisualStyleBackColor = true;
			this.btnSaveArg1.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnLoadArg2
			// 
			this.btnLoadArg2.Location = new System.Drawing.Point(763, 42);
			this.btnLoadArg2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnLoadArg2.Name = "btnLoadArg2";
			this.btnLoadArg2.Size = new System.Drawing.Size(25, 23);
			this.btnLoadArg2.TabIndex = 13;
			this.btnLoadArg2.Text = "L";
			this.btnLoadArg2.UseVisualStyleBackColor = true;
			this.btnLoadArg2.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnSaveArg2
			// 
			this.btnSaveArg2.Location = new System.Drawing.Point(793, 42);
			this.btnSaveArg2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnSaveArg2.Name = "btnSaveArg2";
			this.btnSaveArg2.Size = new System.Drawing.Size(25, 23);
			this.btnSaveArg2.TabIndex = 14;
			this.btnSaveArg2.Text = "S";
			this.btnSaveArg2.UseVisualStyleBackColor = true;
			// 
			// btnSaveRes1
			// 
			this.btnSaveRes1.Location = new System.Drawing.Point(763, 97);
			this.btnSaveRes1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnSaveRes1.Name = "btnSaveRes1";
			this.btnSaveRes1.Size = new System.Drawing.Size(25, 23);
			this.btnSaveRes1.TabIndex = 16;
			this.btnSaveRes1.Text = "S";
			this.btnSaveRes1.UseVisualStyleBackColor = true;
			// 
			// btnSaveRes2
			// 
			this.btnSaveRes2.Location = new System.Drawing.Point(751, 1);
			this.btnSaveRes2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnSaveRes2.Name = "btnSaveRes2";
			this.btnSaveRes2.Size = new System.Drawing.Size(25, 23);
			this.btnSaveRes2.TabIndex = 18;
			this.btnSaveRes2.Text = "S";
			this.btnSaveRes2.UseVisualStyleBackColor = true;
			// 
			// panelRes2
			// 
			this.panelRes2.Controls.Add(this.res2);
			this.panelRes2.Controls.Add(this.btnSaveRes2);
			this.panelRes2.Location = new System.Drawing.Point(12, 127);
			this.panelRes2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panelRes2.Name = "panelRes2";
			this.panelRes2.Size = new System.Drawing.Size(775, 29);
			this.panelRes2.TabIndex = 19;
			// 
			// res2
			// 
			this.res2.Buffer = ((System.Text.StringBuilder)(resources.GetObject("res2.Buffer")));
			this.res2.CharsPerPage = 10;
			this.res2.Location = new System.Drawing.Point(0, 0);
			this.res2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.res2.Name = "res2";
			this.res2.Size = new System.Drawing.Size(745, 23);
			this.res2.TabIndex = 24;
			// 
			// btnCalculate
			// 
			this.btnCalculate.Location = new System.Drawing.Point(12, 162);
			this.btnCalculate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnCalculate.Name = "btnCalculate";
			this.btnCalculate.Size = new System.Drawing.Size(74, 23);
			this.btnCalculate.TabIndex = 20;
			this.btnCalculate.Text = "Calculate";
			this.btnCalculate.UseVisualStyleBackColor = true;
			this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
			// 
			// res1
			// 
			this.res1.Buffer = ((System.Text.StringBuilder)(resources.GetObject("res1.Buffer")));
			this.res1.CharsPerPage = 10;
			this.res1.Location = new System.Drawing.Point(12, 96);
			this.res1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.res1.Name = "res1";
			this.res1.Size = new System.Drawing.Size(745, 23);
			this.res1.TabIndex = 23;
			// 
			// arg2
			// 
			this.arg2.Buffer = ((System.Text.StringBuilder)(resources.GetObject("arg2.Buffer")));
			this.arg2.CharsPerPage = 10;
			this.arg2.Location = new System.Drawing.Point(12, 40);
			this.arg2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.arg2.Name = "arg2";
			this.arg2.Size = new System.Drawing.Size(745, 23);
			this.arg2.TabIndex = 22;
			// 
			// arg1
			// 
			this.arg1.Buffer = ((System.Text.StringBuilder)(resources.GetObject("arg1.Buffer")));
			this.arg1.CharsPerPage = 10;
			this.arg1.Location = new System.Drawing.Point(12, 8);
			this.arg1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.arg1.Name = "arg1";
			this.arg1.Size = new System.Drawing.Size(745, 23);
			this.arg1.TabIndex = 21;
			// 
			// Calculator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(826, 194);
			this.Controls.Add(this.res1);
			this.Controls.Add(this.arg2);
			this.Controls.Add(this.arg1);
			this.Controls.Add(this.btnCalculate);
			this.Controls.Add(this.panelRes2);
			this.Controls.Add(this.btnSaveArg2);
			this.Controls.Add(this.btnLoadArg2);
			this.Controls.Add(this.btnSaveArg1);
			this.Controls.Add(this.btnSaveRes1);
			this.Controls.Add(this.btnLoadArg1);
			this.Controls.Add(this.fieldOp);
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.Name = "Calculator";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Calculator";
			this.Load += new System.EventHandler(this.Calculator_Load);
			this.panelRes2.ResumeLayout(false);
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
		private System.Windows.Forms.Panel panelRes2;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Button btnCalculate;
		private pi_counter_ui.Controls.PagedText res2;
		private pi_counter_ui.Controls.PagedText arg1;
		private pi_counter_ui.Controls.PagedText arg2;
		private pi_counter_ui.Controls.PagedText res1;
	}
}