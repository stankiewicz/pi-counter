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
			this.panelArg2 = new System.Windows.Forms.Panel();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.btnCalculate = new System.Windows.Forms.Button();
			this.arg1 = new pi_counter_ui.Controls.PagedText();
			this.arg2 = new pi_counter_ui.Controls.PagedText();
			this.res1 = new pi_counter_ui.Controls.PagedText();
			this.res2 = new pi_counter_ui.Controls.PagedText();
			this.panelArg2.SuspendLayout();
			this.SuspendLayout();
			// 
			// fieldOp
			// 
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
			this.fieldOp.Name = "fieldOp";
			this.fieldOp.Size = new System.Drawing.Size(121, 21);
			this.fieldOp.TabIndex = 4;
			// 
			// btnLoadArg1
			// 
			this.btnLoadArg1.Location = new System.Drawing.Point(763, 10);
			this.btnLoadArg1.Name = "btnLoadArg1";
			this.btnLoadArg1.Size = new System.Drawing.Size(25, 23);
			this.btnLoadArg1.TabIndex = 11;
			this.btnLoadArg1.Text = "L";
			this.btnLoadArg1.UseVisualStyleBackColor = true;
			// 
			// btnSaveArg1
			// 
			this.btnSaveArg1.Location = new System.Drawing.Point(794, 9);
			this.btnSaveArg1.Name = "btnSaveArg1";
			this.btnSaveArg1.Size = new System.Drawing.Size(25, 23);
			this.btnSaveArg1.TabIndex = 12;
			this.btnSaveArg1.Text = "S";
			this.btnSaveArg1.UseVisualStyleBackColor = true;
			// 
			// btnLoadArg2
			// 
			this.btnLoadArg2.Location = new System.Drawing.Point(763, 41);
			this.btnLoadArg2.Name = "btnLoadArg2";
			this.btnLoadArg2.Size = new System.Drawing.Size(25, 23);
			this.btnLoadArg2.TabIndex = 13;
			this.btnLoadArg2.Text = "L";
			this.btnLoadArg2.UseVisualStyleBackColor = true;
			// 
			// btnSaveArg2
			// 
			this.btnSaveArg2.Location = new System.Drawing.Point(794, 41);
			this.btnSaveArg2.Name = "btnSaveArg2";
			this.btnSaveArg2.Size = new System.Drawing.Size(25, 23);
			this.btnSaveArg2.TabIndex = 14;
			this.btnSaveArg2.Text = "S";
			this.btnSaveArg2.UseVisualStyleBackColor = true;
			// 
			// btnSaveRes1
			// 
			this.btnSaveRes1.Location = new System.Drawing.Point(763, 97);
			this.btnSaveRes1.Name = "btnSaveRes1";
			this.btnSaveRes1.Size = new System.Drawing.Size(25, 23);
			this.btnSaveRes1.TabIndex = 16;
			this.btnSaveRes1.Text = "S";
			this.btnSaveRes1.UseVisualStyleBackColor = true;
			// 
			// btnSaveRes2
			// 
			this.btnSaveRes2.Location = new System.Drawing.Point(751, 1);
			this.btnSaveRes2.Name = "btnSaveRes2";
			this.btnSaveRes2.Size = new System.Drawing.Size(25, 23);
			this.btnSaveRes2.TabIndex = 18;
			this.btnSaveRes2.Text = "S";
			this.btnSaveRes2.UseVisualStyleBackColor = true;
			// 
			// panelArg2
			// 
			this.panelArg2.Controls.Add(this.res2);
			this.panelArg2.Controls.Add(this.btnSaveRes2);
			this.panelArg2.Location = new System.Drawing.Point(12, 128);
			this.panelArg2.Name = "panelArg2";
			this.panelArg2.Size = new System.Drawing.Size(776, 28);
			this.panelArg2.TabIndex = 19;
			// 
			// btnCalculate
			// 
			this.btnCalculate.Location = new System.Drawing.Point(12, 162);
			this.btnCalculate.Name = "btnCalculate";
			this.btnCalculate.Size = new System.Drawing.Size(75, 23);
			this.btnCalculate.TabIndex = 20;
			this.btnCalculate.Text = "Calculate";
			this.btnCalculate.UseVisualStyleBackColor = true;
			// 
			// arg1
			// 
			this.arg1.Buffer = ((System.Text.StringBuilder)(resources.GetObject("arg1.Buffer")));
			this.arg1.CharsPerPage = 10;
			this.arg1.Location = new System.Drawing.Point(12, 8);
			this.arg1.Name = "arg1";
			this.arg1.Size = new System.Drawing.Size(745, 24);
			this.arg1.TabIndex = 21;
			// 
			// arg2
			// 
			this.arg2.Buffer = ((System.Text.StringBuilder)(resources.GetObject("arg2.Buffer")));
			this.arg2.CharsPerPage = 10;
			this.arg2.Location = new System.Drawing.Point(12, 40);
			this.arg2.Name = "arg2";
			this.arg2.Size = new System.Drawing.Size(745, 24);
			this.arg2.TabIndex = 22;
			// 
			// res1
			// 
			this.res1.Buffer = ((System.Text.StringBuilder)(resources.GetObject("res1.Buffer")));
			this.res1.CharsPerPage = 10;
			this.res1.Location = new System.Drawing.Point(12, 96);
			this.res1.Name = "res1";
			this.res1.Size = new System.Drawing.Size(745, 24);
			this.res1.TabIndex = 23;
			// 
			// res2
			// 
			this.res2.Buffer = ((System.Text.StringBuilder)(resources.GetObject("res2.Buffer")));
			this.res2.CharsPerPage = 10;
			this.res2.Location = new System.Drawing.Point(0, 0);
			this.res2.Name = "res2";
			this.res2.Size = new System.Drawing.Size(745, 24);
			this.res2.TabIndex = 24;
			// 
			// Calculator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(825, 194);
			this.Controls.Add(this.res1);
			this.Controls.Add(this.arg2);
			this.Controls.Add(this.arg1);
			this.Controls.Add(this.btnCalculate);
			this.Controls.Add(this.panelArg2);
			this.Controls.Add(this.btnSaveArg2);
			this.Controls.Add(this.btnLoadArg2);
			this.Controls.Add(this.btnSaveArg1);
			this.Controls.Add(this.btnSaveRes1);
			this.Controls.Add(this.btnLoadArg1);
			this.Controls.Add(this.fieldOp);
			this.Name = "Calculator";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Calculator";
			this.Load += new System.EventHandler(this.Calculator_Load);
			this.panelArg2.ResumeLayout(false);
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
		private System.Windows.Forms.Panel panelArg2;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Button btnCalculate;
		private pi_counter_ui.Controls.PagedText res2;
		private pi_counter_ui.Controls.PagedText arg1;
		private pi_counter_ui.Controls.PagedText arg2;
		private pi_counter_ui.Controls.PagedText res1;
	}
}