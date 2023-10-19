namespace SDIFrontEnd
{
    partial class CodeGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lstSurveys = new System.Windows.Forms.ListBox();
            this.cboJump = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbEpi = new System.Windows.Forms.RadioButton();
            this.rbSPSS = new System.Windows.Forms.RadioButton();
            this.rbSAS = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbAltQnum = new System.Windows.Forms.RadioButton();
            this.rbQnum = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.chkShowVarName = new System.Windows.Forms.CheckBox();
            this.chkShowQnum = new System.Windows.Forms.CheckBox();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdOpenFolder = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(221, 33);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Syntax Generator";
            // 
            // lstSurveys
            // 
            this.lstSurveys.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSurveys.FormattingEnabled = true;
            this.lstSurveys.ItemHeight = 16;
            this.lstSurveys.Location = new System.Drawing.Point(12, 81);
            this.lstSurveys.Name = "lstSurveys";
            this.lstSurveys.Size = new System.Drawing.Size(120, 292);
            this.lstSurveys.TabIndex = 1;
            // 
            // cboJump
            // 
            this.cboJump.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboJump.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboJump.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboJump.FormattingEnabled = true;
            this.cboJump.Location = new System.Drawing.Point(53, 50);
            this.cboJump.Name = "cboJump";
            this.cboJump.Size = new System.Drawing.Size(79, 24);
            this.cboJump.TabIndex = 2;
            this.cboJump.SelectedIndexChanged += new System.EventHandler(this.cboJump_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbEpi);
            this.groupBox1.Controls.Add(this.rbSPSS);
            this.groupBox1.Controls.Add(this.rbSAS);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(138, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(92, 85);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Syntax";
            // 
            // rbEpi
            // 
            this.rbEpi.AutoSize = true;
            this.rbEpi.Location = new System.Drawing.Point(7, 62);
            this.rbEpi.Name = "rbEpi";
            this.rbEpi.Size = new System.Drawing.Size(68, 20);
            this.rbEpi.TabIndex = 2;
            this.rbEpi.TabStop = true;
            this.rbEpi.Text = "EpiData";
            this.rbEpi.UseVisualStyleBackColor = true;
            // 
            // rbSPSS
            // 
            this.rbSPSS.AutoSize = true;
            this.rbSPSS.Location = new System.Drawing.Point(7, 42);
            this.rbSPSS.Name = "rbSPSS";
            this.rbSPSS.Size = new System.Drawing.Size(56, 20);
            this.rbSPSS.TabIndex = 1;
            this.rbSPSS.TabStop = true;
            this.rbSPSS.Text = "SPSS";
            this.rbSPSS.UseVisualStyleBackColor = true;
            // 
            // rbSAS
            // 
            this.rbSAS.AutoSize = true;
            this.rbSAS.Checked = true;
            this.rbSAS.Location = new System.Drawing.Point(7, 19);
            this.rbSAS.Name = "rbSAS";
            this.rbSAS.Size = new System.Drawing.Size(49, 20);
            this.rbSAS.TabIndex = 0;
            this.rbSAS.TabStop = true;
            this.rbSAS.Text = "SAS";
            this.rbSAS.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbAltQnum);
            this.groupBox2.Controls.Add(this.rbQnum);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(138, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(92, 66);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Read";
            // 
            // rbAltQnum
            // 
            this.rbAltQnum.AutoSize = true;
            this.rbAltQnum.Location = new System.Drawing.Point(7, 42);
            this.rbAltQnum.Name = "rbAltQnum";
            this.rbAltQnum.Size = new System.Drawing.Size(58, 20);
            this.rbAltQnum.TabIndex = 1;
            this.rbAltQnum.TabStop = true;
            this.rbAltQnum.Text = "AltQ#";
            this.rbAltQnum.UseVisualStyleBackColor = true;
            // 
            // rbQnum
            // 
            this.rbQnum.AutoSize = true;
            this.rbQnum.Checked = true;
            this.rbQnum.Location = new System.Drawing.Point(7, 19);
            this.rbQnum.Name = "rbQnum";
            this.rbQnum.Size = new System.Drawing.Size(43, 20);
            this.rbQnum.TabIndex = 0;
            this.rbQnum.TabStop = true;
            this.rbQnum.Text = "Q#";
            this.rbQnum.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(142, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Show in label:";
            // 
            // chkShowVarName
            // 
            this.chkShowVarName.AutoSize = true;
            this.chkShowVarName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowVarName.Location = new System.Drawing.Point(145, 256);
            this.chkShowVarName.Name = "chkShowVarName";
            this.chkShowVarName.Size = new System.Drawing.Size(79, 20);
            this.chkShowVarName.TabIndex = 6;
            this.chkShowVarName.Text = "VarName";
            this.chkShowVarName.UseVisualStyleBackColor = true;
            // 
            // chkShowQnum
            // 
            this.chkShowQnum.AutoSize = true;
            this.chkShowQnum.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowQnum.Location = new System.Drawing.Point(145, 279);
            this.chkShowQnum.Name = "chkShowQnum";
            this.chkShowQnum.Size = new System.Drawing.Size(60, 20);
            this.chkShowQnum.TabIndex = 7;
            this.chkShowQnum.Text = "Qnum";
            this.chkShowQnum.UseVisualStyleBackColor = true;
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGenerate.Location = new System.Drawing.Point(138, 305);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(80, 41);
            this.cmdGenerate.TabIndex = 8;
            this.cmdGenerate.Text = "Generate";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Location = new System.Drawing.Point(138, 350);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(110, 23);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 385);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Save Location:";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSavePath.Location = new System.Drawing.Point(12, 404);
            this.txtSavePath.Multiline = true;
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(213, 47);
            this.txtSavePath.TabIndex = 11;
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBrowse.Location = new System.Drawing.Point(12, 452);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowse.TabIndex = 12;
            this.cmdBrowse.Text = "Browse...";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Jump";
            // 
            // cmdOpenFolder
            // 
            this.cmdOpenFolder.Image = global::SDIFrontEnd.Properties.Resources.FolderOpened;
            this.cmdOpenFolder.Location = new System.Drawing.Point(218, 305);
            this.cmdOpenFolder.Name = "cmdOpenFolder";
            this.cmdOpenFolder.Size = new System.Drawing.Size(30, 41);
            this.cmdOpenFolder.TabIndex = 20;
            this.cmdOpenFolder.UseVisualStyleBackColor = true;
            this.cmdOpenFolder.Click += new System.EventHandler(this.cmdOpenFolder_Click);
            // 
            // frmCodeGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(181)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(252, 482);
            this.ControlBox = false;
            this.Controls.Add(this.cmdOpenFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdGenerate);
            this.Controls.Add(this.chkShowQnum);
            this.Controls.Add(this.chkShowVarName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboJump);
            this.Controls.Add(this.lstSurveys);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCodeGenerator";
            this.Text = "Syntax Generator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCodeGenerator_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListBox lstSurveys;
        private System.Windows.Forms.ComboBox cboJump;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkShowVarName;
        private System.Windows.Forms.CheckBox chkShowQnum;
        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.RadioButton rbEpi;
        private System.Windows.Forms.RadioButton rbSPSS;
        private System.Windows.Forms.RadioButton rbSAS;
        private System.Windows.Forms.RadioButton rbAltQnum;
        private System.Windows.Forms.RadioButton rbQnum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdOpenFolder;
    }
}

