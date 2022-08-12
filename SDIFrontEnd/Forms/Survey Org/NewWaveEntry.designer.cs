namespace ISISFrontEnd
{
    partial class NewWaveEntry
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
            this.txtWaveCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCountries = new System.Windows.Forms.TextBox();
            this.chkEnglishRouting = new System.Windows.Forms.CheckBox();
            this.cboProject = new System.Windows.Forms.ComboBox();
            this.txtWaveNumber = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdNewStudy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtWaveCode
            // 
            this.txtWaveCode.Location = new System.Drawing.Point(91, 124);
            this.txtWaveCode.Name = "txtWaveCode";
            this.txtWaveCode.Size = new System.Drawing.Size(100, 20);
            this.txtWaveCode.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 33);
            this.label6.TabIndex = 26;
            this.label6.Text = "New Survey Wave";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Countries";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(53, 127);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(32, 13);
            this.lblCode.TabIndex = 24;
            this.lblCode.Text = "Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Wave #";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Project";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "ID";
            // 
            // txtCountries
            // 
            this.txtCountries.Location = new System.Drawing.Point(91, 173);
            this.txtCountries.Multiline = true;
            this.txtCountries.Name = "txtCountries";
            this.txtCountries.Size = new System.Drawing.Size(100, 54);
            this.txtCountries.TabIndex = 20;
            // 
            // chkEnglishRouting
            // 
            this.chkEnglishRouting.AutoSize = true;
            this.chkEnglishRouting.Location = new System.Drawing.Point(5, 150);
            this.chkEnglishRouting.Name = "chkEnglishRouting";
            this.chkEnglishRouting.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkEnglishRouting.Size = new System.Drawing.Size(100, 17);
            this.chkEnglishRouting.TabIndex = 19;
            this.chkEnglishRouting.Text = "English Routing";
            this.chkEnglishRouting.UseVisualStyleBackColor = true;
            // 
            // cboProject
            // 
            this.cboProject.FormattingEnabled = true;
            this.cboProject.Location = new System.Drawing.Point(91, 71);
            this.cboProject.Name = "cboProject";
            this.cboProject.Size = new System.Drawing.Size(100, 21);
            this.cboProject.TabIndex = 18;
            this.cboProject.SelectedIndexChanged += new System.EventHandler(this.cboProject_SelectedIndexChanged);
            // 
            // txtWaveNumber
            // 
            this.txtWaveNumber.Location = new System.Drawing.Point(91, 98);
            this.txtWaveNumber.Name = "txtWaveNumber";
            this.txtWaveNumber.Size = new System.Drawing.Size(100, 20);
            this.txtWaveNumber.TabIndex = 17;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(91, 45);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 16;
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(114, 261);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(60, 34);
            this.cmdSave.TabIndex = 30;
            this.cmdSave.Text = "OK";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(4, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 2);
            this.label4.TabIndex = 29;
            this.label4.Text = "label4";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(180, 261);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(60, 34);
            this.cmdCancel.TabIndex = 28;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdNewStudy
            // 
            this.cmdNewStudy.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewStudy.Location = new System.Drawing.Point(197, 71);
            this.cmdNewStudy.Name = "cmdNewStudy";
            this.cmdNewStudy.Size = new System.Drawing.Size(32, 21);
            this.cmdNewStudy.TabIndex = 31;
            this.cmdNewStudy.Text = "+";
            this.cmdNewStudy.UseCompatibleTextRendering = true;
            this.cmdNewStudy.UseVisualStyleBackColor = true;
            this.cmdNewStudy.Click += new System.EventHandler(this.cmdNewStudy_Click);
            // 
            // NewWaveEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(219)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(272, 307);
            this.ControlBox = false;
            this.Controls.Add(this.cmdNewStudy);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.txtWaveCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCountries);
            this.Controls.Add(this.chkEnglishRouting);
            this.Controls.Add(this.cboProject);
            this.Controls.Add(this.txtWaveNumber);
            this.Controls.Add(this.txtID);
            this.Name = "NewWaveEntry";
            this.Text = "New Wave";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWaveCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCountries;
        private System.Windows.Forms.CheckBox chkEnglishRouting;
        private System.Windows.Forms.ComboBox cboProject;
        private System.Windows.Forms.TextBox txtWaveNumber;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdNewStudy;
    }
}