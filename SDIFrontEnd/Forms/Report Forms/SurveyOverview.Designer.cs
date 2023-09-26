namespace SDIFrontEnd
{
    partial class SurveyOverview
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
            this.components = new System.ComponentModel.Container();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.cboSurvey = new System.Windows.Forms.ComboBox();
            this.lblSurvey = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.qrySurveyQuestionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chkTC = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdOpenFolder = new System.Windows.Forms.Button();
            this.cmdAddSurvey = new System.Windows.Forms.Button();
            this.lstSelected = new System.Windows.Forms.ListBox();
            this.cmdRemoveSurvey = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qrySurveyQuestionsBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGenerate.Location = new System.Drawing.Point(90, 128);
            this.cmdGenerate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(99, 30);
            this.cmdGenerate.TabIndex = 0;
            this.cmdGenerate.Text = "Generate";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // cboSurvey
            // 
            this.cboSurvey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboSurvey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSurvey.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSurvey.FormattingEnabled = true;
            this.cboSurvey.Location = new System.Drawing.Point(90, 91);
            this.cboSurvey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboSurvey.Name = "cboSurvey";
            this.cboSurvey.Size = new System.Drawing.Size(131, 24);
            this.cboSurvey.TabIndex = 1;
            // 
            // lblSurvey
            // 
            this.lblSurvey.AutoSize = true;
            this.lblSurvey.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurvey.Location = new System.Drawing.Point(33, 91);
            this.lblSurvey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSurvey.Name = "lblSurvey";
            this.lblSurvey.Size = new System.Drawing.Size(46, 16);
            this.lblSurvey.TabIndex = 2;
            this.lblSurvey.Text = "Survey";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(29, 34);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(212, 33);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Survey Overview";
            // 
            // qrySurveyQuestionsBindingSource
            // 
            this.qrySurveyQuestionsBindingSource.DataMember = "qrySurveyQuestions";
            // 
            // chkTC
            // 
            this.chkTC.AutoSize = true;
            this.chkTC.Checked = true;
            this.chkTC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTC.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTC.Location = new System.Drawing.Point(403, 91);
            this.chkTC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkTC.Name = "chkTC";
            this.chkTC.Size = new System.Drawing.Size(151, 20);
            this.chkTC.TabIndex = 5;
            this.chkTC.Text = "Include Topic/Content";
            this.chkTC.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(565, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // cmdOpenFolder
            // 
            this.cmdOpenFolder.Image = global::SDIFrontEnd.Properties.Resources.FolderOpened;
            this.cmdOpenFolder.Location = new System.Drawing.Point(191, 128);
            this.cmdOpenFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdOpenFolder.Name = "cmdOpenFolder";
            this.cmdOpenFolder.Size = new System.Drawing.Size(30, 30);
            this.cmdOpenFolder.TabIndex = 8;
            this.cmdOpenFolder.UseVisualStyleBackColor = true;
            this.cmdOpenFolder.Click += new System.EventHandler(this.cmdOpenFolder_Click);
            // 
            // cmdAddSurvey
            // 
            this.cmdAddSurvey.Location = new System.Drawing.Point(229, 91);
            this.cmdAddSurvey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdAddSurvey.Name = "cmdAddSurvey";
            this.cmdAddSurvey.Size = new System.Drawing.Size(33, 24);
            this.cmdAddSurvey.TabIndex = 9;
            this.cmdAddSurvey.Text = "->";
            this.cmdAddSurvey.UseVisualStyleBackColor = true;
            this.cmdAddSurvey.Click += new System.EventHandler(this.cmdAddSurvey_Click);
            // 
            // lstSelected
            // 
            this.lstSelected.FormattingEnabled = true;
            this.lstSelected.ItemHeight = 16;
            this.lstSelected.Location = new System.Drawing.Point(269, 91);
            this.lstSelected.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstSelected.Name = "lstSelected";
            this.lstSelected.Size = new System.Drawing.Size(126, 116);
            this.lstSelected.TabIndex = 10;
            // 
            // cmdRemoveSurvey
            // 
            this.cmdRemoveSurvey.Location = new System.Drawing.Point(229, 116);
            this.cmdRemoveSurvey.Name = "cmdRemoveSurvey";
            this.cmdRemoveSurvey.Size = new System.Drawing.Size(33, 24);
            this.cmdRemoveSurvey.TabIndex = 11;
            this.cmdRemoveSurvey.Text = "<-";
            this.cmdRemoveSurvey.UseVisualStyleBackColor = true;
            this.cmdRemoveSurvey.Click += new System.EventHandler(this.cmdRemoveSurvey_Click);
            // 
            // SurveyOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(205)))), ((int)(((byte)(170)))));
            this.ClientSize = new System.Drawing.Size(565, 218);
            this.ControlBox = false;
            this.Controls.Add(this.cmdRemoveSurvey);
            this.Controls.Add(this.lstSelected);
            this.Controls.Add(this.cmdAddSurvey);
            this.Controls.Add(this.cmdOpenFolder);
            this.Controls.Add(this.chkTC);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSurvey);
            this.Controls.Add(this.cboSurvey);
            this.Controls.Add(this.cmdGenerate);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SurveyOverview";
            this.Text = "Survey Overview";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SurveyOverview_FormClosed);
            this.Load += new System.EventHandler(this.SurveyOverview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qrySurveyQuestionsBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.ComboBox cboSurvey;
        private System.Windows.Forms.Label lblSurvey;
        private System.Windows.Forms.Label lblTitle;
        
        private System.Windows.Forms.BindingSource qrySurveyQuestionsBindingSource;
        private System.Windows.Forms.CheckBox chkTC;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button cmdOpenFolder;
        private System.Windows.Forms.Button cmdAddSurvey;
        private System.Windows.Forms.ListBox lstSelected;
        private System.Windows.Forms.Button cmdRemoveSurvey;
    }
}

