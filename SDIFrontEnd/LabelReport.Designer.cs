namespace SDIFrontEnd
{
    partial class LabelReport
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
            this.cboSurveys = new System.Windows.Forms.ComboBox();
            this.lstSelectedSurveys = new System.Windows.Forms.ListBox();
            this.grpLabels = new System.Windows.Forms.GroupBox();
            this.optTCP = new System.Windows.Forms.RadioButton();
            this.optTC = new System.Windows.Forms.RadioButton();
            this.chkIncludePlainFilters = new System.Windows.Forms.CheckBox();
            this.cmdAddSurvey = new System.Windows.Forms.Button();
            this.cmdRemoveSurvey = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdOpenReportFolder = new System.Windows.Forms.Button();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.grpLabels.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboSurveys
            // 
            this.cboSurveys.FormattingEnabled = true;
            this.cboSurveys.Location = new System.Drawing.Point(11, 100);
            this.cboSurveys.Margin = new System.Windows.Forms.Padding(4);
            this.cboSurveys.Name = "cboSurveys";
            this.cboSurveys.Size = new System.Drawing.Size(140, 24);
            this.cboSurveys.TabIndex = 0;
            // 
            // lstSelectedSurveys
            // 
            this.lstSelectedSurveys.FormattingEnabled = true;
            this.lstSelectedSurveys.ItemHeight = 16;
            this.lstSelectedSurveys.Location = new System.Drawing.Point(234, 100);
            this.lstSelectedSurveys.Margin = new System.Windows.Forms.Padding(4);
            this.lstSelectedSurveys.Name = "lstSelectedSurveys";
            this.lstSelectedSurveys.Size = new System.Drawing.Size(139, 116);
            this.lstSelectedSurveys.TabIndex = 1;
            // 
            // grpLabels
            // 
            this.grpLabels.Controls.Add(this.optTCP);
            this.grpLabels.Controls.Add(this.optTC);
            this.grpLabels.Location = new System.Drawing.Point(381, 100);
            this.grpLabels.Margin = new System.Windows.Forms.Padding(4);
            this.grpLabels.Name = "grpLabels";
            this.grpLabels.Padding = new System.Windows.Forms.Padding(4);
            this.grpLabels.Size = new System.Drawing.Size(175, 79);
            this.grpLabels.TabIndex = 2;
            this.grpLabels.TabStop = false;
            this.grpLabels.Text = "Labels to Include";
            // 
            // optTCP
            // 
            this.optTCP.AutoSize = true;
            this.optTCP.Location = new System.Drawing.Point(8, 52);
            this.optTCP.Margin = new System.Windows.Forms.Padding(4);
            this.optTCP.Name = "optTCP";
            this.optTCP.Size = new System.Drawing.Size(153, 20);
            this.optTCP.TabIndex = 1;
            this.optTCP.TabStop = true;
            this.optTCP.Text = "Topic/Content/Product";
            this.optTCP.UseVisualStyleBackColor = true;
            // 
            // optTC
            // 
            this.optTC.AutoSize = true;
            this.optTC.Location = new System.Drawing.Point(8, 24);
            this.optTC.Margin = new System.Windows.Forms.Padding(4);
            this.optTC.Name = "optTC";
            this.optTC.Size = new System.Drawing.Size(105, 20);
            this.optTC.TabIndex = 0;
            this.optTC.TabStop = true;
            this.optTC.Text = "Topic/Content";
            this.optTC.UseVisualStyleBackColor = true;
            // 
            // chkIncludePlainFilters
            // 
            this.chkIncludePlainFilters.AutoSize = true;
            this.chkIncludePlainFilters.Location = new System.Drawing.Point(381, 187);
            this.chkIncludePlainFilters.Margin = new System.Windows.Forms.Padding(4);
            this.chkIncludePlainFilters.Name = "chkIncludePlainFilters";
            this.chkIncludePlainFilters.Size = new System.Drawing.Size(137, 20);
            this.chkIncludePlainFilters.TabIndex = 3;
            this.chkIncludePlainFilters.Text = "Include Plain Filters";
            this.chkIncludePlainFilters.UseVisualStyleBackColor = true;
            // 
            // cmdAddSurvey
            // 
            this.cmdAddSurvey.Location = new System.Drawing.Point(194, 100);
            this.cmdAddSurvey.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAddSurvey.Name = "cmdAddSurvey";
            this.cmdAddSurvey.Size = new System.Drawing.Size(36, 26);
            this.cmdAddSurvey.TabIndex = 5;
            this.cmdAddSurvey.Text = "->";
            this.cmdAddSurvey.UseVisualStyleBackColor = true;
            this.cmdAddSurvey.Click += new System.EventHandler(this.AddSurvey_Click);
            // 
            // cmdRemoveSurvey
            // 
            this.cmdRemoveSurvey.Location = new System.Drawing.Point(157, 100);
            this.cmdRemoveSurvey.Margin = new System.Windows.Forms.Padding(4);
            this.cmdRemoveSurvey.Name = "cmdRemoveSurvey";
            this.cmdRemoveSurvey.Size = new System.Drawing.Size(36, 26);
            this.cmdRemoveSurvey.TabIndex = 6;
            this.cmdRemoveSurvey.Text = "<-";
            this.cmdRemoveSurvey.UseVisualStyleBackColor = true;
            this.cmdRemoveSurvey.Click += new System.EventHandler(this.RemoveSurvey_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 33);
            this.label1.TabIndex = 7;
            this.label1.Text = "Topic/Content Report";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(573, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // cmdOpenReportFolder
            // 
            this.cmdOpenReportFolder.Image = global::SDIFrontEnd.Properties.Resources.FolderOpened;
            this.cmdOpenReportFolder.Location = new System.Drawing.Point(487, 238);
            this.cmdOpenReportFolder.Name = "cmdOpenReportFolder";
            this.cmdOpenReportFolder.Size = new System.Drawing.Size(31, 23);
            this.cmdOpenReportFolder.TabIndex = 9;
            this.cmdOpenReportFolder.UseVisualStyleBackColor = true;
            this.cmdOpenReportFolder.Click += new System.EventHandler(this.cmdOpenReportFolder_Click);
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Location = new System.Drawing.Point(381, 238);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(100, 23);
            this.cmdGenerate.TabIndex = 10;
            this.cmdGenerate.Text = "Generate";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Select survey(s)";
            // 
            // LabelReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 274);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdGenerate);
            this.Controls.Add(this.cmdOpenReportFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdRemoveSurvey);
            this.Controls.Add(this.cmdAddSurvey);
            this.Controls.Add(this.chkIncludePlainFilters);
            this.Controls.Add(this.grpLabels);
            this.Controls.Add(this.lstSelectedSurveys);
            this.Controls.Add(this.cboSurveys);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LabelReport";
            this.Text = "Label Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LabelReport_FormClosing);
            this.grpLabels.ResumeLayout(false);
            this.grpLabels.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSurveys;
        private System.Windows.Forms.ListBox lstSelectedSurveys;
        private System.Windows.Forms.GroupBox grpLabels;
        private System.Windows.Forms.RadioButton optTCP;
        private System.Windows.Forms.RadioButton optTC;
        private System.Windows.Forms.CheckBox chkIncludePlainFilters;
        private System.Windows.Forms.Button cmdAddSurvey;
        private System.Windows.Forms.Button cmdRemoveSurvey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button cmdOpenReportFolder;
        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.Label label2;
    }
}