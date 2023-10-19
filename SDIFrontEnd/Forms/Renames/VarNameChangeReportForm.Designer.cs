namespace SDIFrontEnd
{
    partial class VarNameChangeReportForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lstSelected = new System.Windows.Forms.ListBox();
            this.cboSurveyOrWave = new System.Windows.Forms.ComboBox();
            this.rbWave = new System.Windows.Forms.RadioButton();
            this.rbSurvey = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkIncludeAllSurveys = new System.Windows.Forms.CheckBox();
            this.chkExcludePreFW = new System.Windows.Forms.CheckBox();
            this.chkExcludeHidden = new System.Windows.Forms.CheckBox();
            this.chkExcludeHeadings = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.rbRefVarName = new System.Windows.Forms.RadioButton();
            this.rbVarName = new System.Windows.Forms.RadioButton();
            this.chkIncludeWordings = new System.Windows.Forms.CheckBox();
            this.chkIncludeVarLabel = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpUpper = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpLower = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(418, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdRemove);
            this.groupBox1.Controls.Add(this.cmdAdd);
            this.groupBox1.Controls.Add(this.lstSelected);
            this.groupBox1.Controls.Add(this.cboSurveyOrWave);
            this.groupBox1.Controls.Add(this.rbWave);
            this.groupBox1.Controls.Add(this.rbSurvey);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 75);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(390, 134);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report scope";
            // 
            // cmdRemove
            // 
            this.cmdRemove.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemove.Location = new System.Drawing.Point(218, 59);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(40, 28);
            this.cmdRemove.TabIndex = 7;
            this.cmdRemove.Text = "<-";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdd.Location = new System.Drawing.Point(218, 25);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(40, 28);
            this.cmdAdd.TabIndex = 6;
            this.cmdAdd.Text = "->";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lstSelected
            // 
            this.lstSelected.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSelected.FormattingEnabled = true;
            this.lstSelected.ItemHeight = 16;
            this.lstSelected.Location = new System.Drawing.Point(264, 25);
            this.lstSelected.Name = "lstSelected";
            this.lstSelected.Size = new System.Drawing.Size(123, 100);
            this.lstSelected.TabIndex = 5;
            // 
            // cboSurveyOrWave
            // 
            this.cboSurveyOrWave.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboSurveyOrWave.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSurveyOrWave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSurveyOrWave.FormattingEnabled = true;
            this.cboSurveyOrWave.Location = new System.Drawing.Point(89, 25);
            this.cboSurveyOrWave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSurveyOrWave.Name = "cboSurveyOrWave";
            this.cboSurveyOrWave.Size = new System.Drawing.Size(123, 24);
            this.cboSurveyOrWave.TabIndex = 2;
            // 
            // rbWave
            // 
            this.rbWave.AutoSize = true;
            this.rbWave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWave.Location = new System.Drawing.Point(15, 46);
            this.rbWave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbWave.Name = "rbWave";
            this.rbWave.Size = new System.Drawing.Size(57, 20);
            this.rbWave.TabIndex = 1;
            this.rbWave.TabStop = true;
            this.rbWave.Text = "Wave";
            this.rbWave.UseVisualStyleBackColor = true;
            this.rbWave.Click += new System.EventHandler(this.rbWave_Click);
            // 
            // rbSurvey
            // 
            this.rbSurvey.AutoSize = true;
            this.rbSurvey.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSurvey.Location = new System.Drawing.Point(15, 25);
            this.rbSurvey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbSurvey.Name = "rbSurvey";
            this.rbSurvey.Size = new System.Drawing.Size(64, 20);
            this.rbSurvey.TabIndex = 0;
            this.rbSurvey.TabStop = true;
            this.rbSurvey.Text = "Survey";
            this.rbSurvey.UseVisualStyleBackColor = true;
            this.rbSurvey.Click += new System.EventHandler(this.rbSurvey_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkIncludeAllSurveys);
            this.panel1.Controls.Add(this.chkExcludePreFW);
            this.panel1.Controls.Add(this.chkExcludeHidden);
            this.panel1.Controls.Add(this.chkExcludeHeadings);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.chkIncludeWordings);
            this.panel1.Controls.Add(this.chkIncludeVarLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpUpper);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpLower);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(19, 212);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 269);
            this.panel1.TabIndex = 2;
            // 
            // chkIncludeAllSurveys
            // 
            this.chkIncludeAllSurveys.AutoSize = true;
            this.chkIncludeAllSurveys.Location = new System.Drawing.Point(181, 183);
            this.chkIncludeAllSurveys.Name = "chkIncludeAllSurveys";
            this.chkIncludeAllSurveys.Size = new System.Drawing.Size(134, 20);
            this.chkIncludeAllSurveys.TabIndex = 11;
            this.chkIncludeAllSurveys.Text = "Include All Surveys";
            this.chkIncludeAllSurveys.UseVisualStyleBackColor = true;
            // 
            // chkExcludePreFW
            // 
            this.chkExcludePreFW.AutoSize = true;
            this.chkExcludePreFW.Checked = true;
            this.chkExcludePreFW.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludePreFW.Location = new System.Drawing.Point(181, 157);
            this.chkExcludePreFW.Name = "chkExcludePreFW";
            this.chkExcludePreFW.Size = new System.Drawing.Size(169, 20);
            this.chkExcludePreFW.TabIndex = 10;
            this.chkExcludePreFW.Text = "Exclude Pre-FW Changes";
            this.chkExcludePreFW.UseVisualStyleBackColor = true;
            // 
            // chkExcludeHidden
            // 
            this.chkExcludeHidden.AutoSize = true;
            this.chkExcludeHidden.Checked = true;
            this.chkExcludeHidden.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeHidden.Location = new System.Drawing.Point(181, 131);
            this.chkExcludeHidden.Name = "chkExcludeHidden";
            this.chkExcludeHidden.Size = new System.Drawing.Size(165, 20);
            this.chkExcludeHidden.TabIndex = 9;
            this.chkExcludeHidden.Text = "Exclude Hidden Changes";
            this.chkExcludeHidden.UseVisualStyleBackColor = true;
            // 
            // chkExcludeHeadings
            // 
            this.chkExcludeHeadings.AutoSize = true;
            this.chkExcludeHeadings.Checked = true;
            this.chkExcludeHeadings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeHeadings.Location = new System.Drawing.Point(181, 105);
            this.chkExcludeHeadings.Name = "chkExcludeHeadings";
            this.chkExcludeHeadings.Size = new System.Drawing.Size(125, 20);
            this.chkExcludeHeadings.TabIndex = 8;
            this.chkExcludeHeadings.Text = "Exclude Headings";
            this.chkExcludeHeadings.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbBoth);
            this.groupBox2.Controls.Add(this.rbRefVarName);
            this.groupBox2.Controls.Add(this.rbVarName);
            this.groupBox2.Location = new System.Drawing.Point(38, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 96);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Include VarName";
            // 
            // rbBoth
            // 
            this.rbBoth.AutoSize = true;
            this.rbBoth.Location = new System.Drawing.Point(18, 71);
            this.rbBoth.Name = "rbBoth";
            this.rbBoth.Size = new System.Drawing.Size(50, 20);
            this.rbBoth.TabIndex = 2;
            this.rbBoth.Text = "Both";
            this.rbBoth.UseVisualStyleBackColor = true;
            // 
            // rbRefVarName
            // 
            this.rbRefVarName.AutoSize = true;
            this.rbRefVarName.Location = new System.Drawing.Point(18, 45);
            this.rbRefVarName.Name = "rbRefVarName";
            this.rbRefVarName.Size = new System.Drawing.Size(94, 20);
            this.rbRefVarName.TabIndex = 1;
            this.rbRefVarName.Text = "refVarName";
            this.rbRefVarName.UseVisualStyleBackColor = true;
            // 
            // rbVarName
            // 
            this.rbVarName.AutoSize = true;
            this.rbVarName.Checked = true;
            this.rbVarName.Location = new System.Drawing.Point(18, 19);
            this.rbVarName.Name = "rbVarName";
            this.rbVarName.Size = new System.Drawing.Size(78, 20);
            this.rbVarName.TabIndex = 0;
            this.rbVarName.TabStop = true;
            this.rbVarName.Text = "VarName";
            this.rbVarName.UseVisualStyleBackColor = true;
            // 
            // chkIncludeWordings
            // 
            this.chkIncludeWordings.AutoSize = true;
            this.chkIncludeWordings.Location = new System.Drawing.Point(39, 131);
            this.chkIncludeWordings.Name = "chkIncludeWordings";
            this.chkIncludeWordings.Size = new System.Drawing.Size(125, 20);
            this.chkIncludeWordings.TabIndex = 6;
            this.chkIncludeWordings.Text = "Include Wordings";
            this.chkIncludeWordings.UseVisualStyleBackColor = true;
            // 
            // chkIncludeVarLabel
            // 
            this.chkIncludeVarLabel.AutoSize = true;
            this.chkIncludeVarLabel.Location = new System.Drawing.Point(39, 105);
            this.chkIncludeVarLabel.Name = "chkIncludeVarLabel";
            this.chkIncludeVarLabel.Size = new System.Drawing.Size(121, 20);
            this.chkIncludeVarLabel.TabIndex = 5;
            this.chkIncludeVarLabel.Text = "Include VarLabel";
            this.chkIncludeVarLabel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "-";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // dtpUpper
            // 
            this.dtpUpper.Checked = false;
            this.dtpUpper.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpUpper.Location = new System.Drawing.Point(182, 67);
            this.dtpUpper.Name = "dtpUpper";
            this.dtpUpper.ShowCheckBox = true;
            this.dtpUpper.Size = new System.Drawing.Size(120, 23);
            this.dtpUpper.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date Range";
            // 
            // dtpLower
            // 
            this.dtpLower.Checked = false;
            this.dtpLower.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLower.Location = new System.Drawing.Point(39, 67);
            this.dtpLower.Name = "dtpLower";
            this.dtpLower.ShowCheckBox = true;
            this.dtpLower.Size = new System.Drawing.Size(120, 23);
            this.dtpLower.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Report Options";
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Location = new System.Drawing.Point(319, 487);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(90, 28);
            this.cmdGenerate.TabIndex = 3;
            this.cmdGenerate.Text = "Generate";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(321, 33);
            this.label4.TabIndex = 4;
            this.label4.Text = "VarName Changes Report";
            // 
            // VarNameChangeReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(221)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(418, 520);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdGenerate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VarNameChangeReportForm";
            this.Text = "VarName Changes Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VarNameChangeReportForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboSurveyOrWave;
        private System.Windows.Forms.RadioButton rbWave;
        private System.Windows.Forms.RadioButton rbSurvey;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkExcludePreFW;
        private System.Windows.Forms.CheckBox chkExcludeHidden;
        private System.Windows.Forms.CheckBox chkExcludeHeadings;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbBoth;
        private System.Windows.Forms.RadioButton rbRefVarName;
        private System.Windows.Forms.RadioButton rbVarName;
        private System.Windows.Forms.CheckBox chkIncludeWordings;
        private System.Windows.Forms.CheckBox chkIncludeVarLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpUpper;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpLower;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.ListBox lstSelected;
        private System.Windows.Forms.CheckBox chkIncludeAllSurveys;
    }
}