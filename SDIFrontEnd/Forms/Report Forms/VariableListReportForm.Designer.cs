namespace ISISFrontEnd
{
    partial class VariableListReportForm
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
            this.lstStudy = new System.Windows.Forms.ListBox();
            this.lstStudyWave = new System.Windows.Forms.ListBox();
            this.lstSurvey = new System.Windows.Forms.ListBox();
            this.lstVarName = new System.Windows.Forms.ListBox();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.gpScope = new System.Windows.Forms.GroupBox();
            this.rbByWave = new System.Windows.Forms.RadioButton();
            this.rbBySurvey = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstInclusions = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstExclusions = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboVarNameBox = new System.Windows.Forms.ComboBox();
            this.cmdAddVar = new System.Windows.Forms.Button();
            this.cmdRemoveVar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.gpScope.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstStudy
            // 
            this.lstStudy.FormattingEnabled = true;
            this.lstStudy.ItemHeight = 16;
            this.lstStudy.Location = new System.Drawing.Point(164, 105);
            this.lstStudy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstStudy.Name = "lstStudy";
            this.lstStudy.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstStudy.Size = new System.Drawing.Size(64, 244);
            this.lstStudy.TabIndex = 0;
            // 
            // lstStudyWave
            // 
            this.lstStudyWave.FormattingEnabled = true;
            this.lstStudyWave.ItemHeight = 16;
            this.lstStudyWave.Location = new System.Drawing.Point(234, 105);
            this.lstStudyWave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstStudyWave.Name = "lstStudyWave";
            this.lstStudyWave.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstStudyWave.Size = new System.Drawing.Size(66, 244);
            this.lstStudyWave.TabIndex = 1;
            // 
            // lstSurvey
            // 
            this.lstSurvey.FormattingEnabled = true;
            this.lstSurvey.ItemHeight = 16;
            this.lstSurvey.Location = new System.Drawing.Point(306, 105);
            this.lstSurvey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstSurvey.Name = "lstSurvey";
            this.lstSurvey.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstSurvey.Size = new System.Drawing.Size(124, 244);
            this.lstSurvey.TabIndex = 2;
            // 
            // lstVarName
            // 
            this.lstVarName.FormattingEnabled = true;
            this.lstVarName.ItemHeight = 16;
            this.lstVarName.Location = new System.Drawing.Point(435, 137);
            this.lstVarName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstVarName.Name = "lstVarName";
            this.lstVarName.Size = new System.Drawing.Size(122, 212);
            this.lstVarName.TabIndex = 3;
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Location = new System.Drawing.Point(472, 374);
            this.cmdGenerate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(85, 39);
            this.cmdGenerate.TabIndex = 4;
            this.cmdGenerate.Text = "Generate";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // gpScope
            // 
            this.gpScope.Controls.Add(this.rbByWave);
            this.gpScope.Controls.Add(this.rbBySurvey);
            this.gpScope.Location = new System.Drawing.Point(15, 81);
            this.gpScope.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gpScope.Name = "gpScope";
            this.gpScope.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gpScope.Size = new System.Drawing.Size(143, 80);
            this.gpScope.TabIndex = 6;
            this.gpScope.TabStop = false;
            this.gpScope.Text = "Report Type";
            // 
            // rbByWave
            // 
            this.rbByWave.AutoSize = true;
            this.rbByWave.Location = new System.Drawing.Point(32, 52);
            this.rbByWave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbByWave.Name = "rbByWave";
            this.rbByWave.Size = new System.Drawing.Size(75, 20);
            this.rbByWave.TabIndex = 1;
            this.rbByWave.Text = "By Wave";
            this.rbByWave.UseVisualStyleBackColor = true;
            this.rbByWave.Click += new System.EventHandler(this.TypeChanged_Click);
            // 
            // rbBySurvey
            // 
            this.rbBySurvey.AutoSize = true;
            this.rbBySurvey.Checked = true;
            this.rbBySurvey.Location = new System.Drawing.Point(32, 24);
            this.rbBySurvey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbBySurvey.Name = "rbBySurvey";
            this.rbBySurvey.Size = new System.Drawing.Size(82, 20);
            this.rbBySurvey.TabIndex = 0;
            this.rbBySurvey.TabStop = true;
            this.rbBySurvey.Text = "By Survey";
            this.rbBySurvey.UseVisualStyleBackColor = true;
            this.rbBySurvey.Click += new System.EventHandler(this.TypeChanged_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Studies";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Waves";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Surveys";
            // 
            // lstInclusions
            // 
            this.lstInclusions.FormattingEnabled = true;
            this.lstInclusions.ItemHeight = 16;
            this.lstInclusions.Location = new System.Drawing.Point(9, 129);
            this.lstInclusions.Name = "lstInclusions";
            this.lstInclusions.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstInclusions.Size = new System.Drawing.Size(120, 116);
            this.lstInclusions.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Include:";
            // 
            // lstExclusions
            // 
            this.lstExclusions.FormattingEnabled = true;
            this.lstExclusions.ItemHeight = 16;
            this.lstExclusions.Location = new System.Drawing.Point(9, 33);
            this.lstExclusions.Name = "lstExclusions";
            this.lstExclusions.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstExclusions.Size = new System.Drawing.Size(120, 68);
            this.lstExclusions.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Exclude:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(228, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 33);
            this.label6.TabIndex = 17;
            this.label6.Text = "Variable List";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(583, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lstExclusions);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lstInclusions);
            this.panel1.Location = new System.Drawing.Point(15, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 261);
            this.panel1.TabIndex = 19;
            // 
            // cboVarNameBox
            // 
            this.cboVarNameBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboVarNameBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVarNameBox.DropDownWidth = 125;
            this.cboVarNameBox.FormattingEnabled = true;
            this.cboVarNameBox.Location = new System.Drawing.Point(435, 105);
            this.cboVarNameBox.Name = "cboVarNameBox";
            this.cboVarNameBox.Size = new System.Drawing.Size(87, 24);
            this.cboVarNameBox.TabIndex = 20;
            // 
            // cmdAddVar
            // 
            this.cmdAddVar.Location = new System.Drawing.Point(525, 105);
            this.cmdAddVar.Name = "cmdAddVar";
            this.cmdAddVar.Size = new System.Drawing.Size(17, 23);
            this.cmdAddVar.TabIndex = 21;
            this.cmdAddVar.Text = "+";
            this.cmdAddVar.UseCompatibleTextRendering = true;
            this.cmdAddVar.UseVisualStyleBackColor = true;
            this.cmdAddVar.Click += new System.EventHandler(this.cmdAddVar_Click);
            // 
            // cmdRemoveVar
            // 
            this.cmdRemoveVar.Location = new System.Drawing.Point(541, 105);
            this.cmdRemoveVar.Name = "cmdRemoveVar";
            this.cmdRemoveVar.Size = new System.Drawing.Size(17, 23);
            this.cmdRemoveVar.TabIndex = 22;
            this.cmdRemoveVar.Text = "-";
            this.cmdRemoveVar.UseCompatibleTextRendering = true;
            this.cmdRemoveVar.UseVisualStyleBackColor = true;
            this.cmdRemoveVar.Click += new System.EventHandler(this.cmdRemoveVar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(469, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "VarNames";
            // 
            // VariableListReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(583, 435);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmdRemoveVar);
            this.Controls.Add(this.cmdAddVar);
            this.Controls.Add(this.cboVarNameBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gpScope);
            this.Controls.Add(this.cmdGenerate);
            this.Controls.Add(this.lstVarName);
            this.Controls.Add(this.lstSurvey);
            this.Controls.Add(this.lstStudyWave);
            this.Controls.Add(this.lstStudy);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VariableListReportForm";
            this.Text = "Variable List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VariableListReportForm_FormClosing);
            this.gpScope.ResumeLayout(false);
            this.gpScope.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstStudy;
        private System.Windows.Forms.ListBox lstStudyWave;
        private System.Windows.Forms.ListBox lstSurvey;
        private System.Windows.Forms.ListBox lstVarName;
        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.GroupBox gpScope;
        private System.Windows.Forms.RadioButton rbByWave;
        private System.Windows.Forms.RadioButton rbBySurvey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstInclusions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstExclusions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboVarNameBox;
        private System.Windows.Forms.Button cmdAddVar;
        private System.Windows.Forms.Button cmdRemoveVar;
        private System.Windows.Forms.Label label7;
    }
}