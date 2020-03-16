namespace ISISFrontEnd
{
    partial class MainMenu
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
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectWaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.surveyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cohortListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userGroupListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iSISHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageMain = new System.Windows.Forms.TabPage();
            this.cmdOpenCreateSurvey = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdOpenSurveyEntry = new System.Windows.Forms.Button();
            this.cmdOpenSurveyEntry3 = new System.Windows.Forms.Button();
            this.cmdOpenSurveyEntry2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmdOpenSurveyChecks = new System.Windows.Forms.Button();
            this.cmdOpenStudyAttributes = new System.Windows.Forms.Button();
            this.cmdOpenWaveInfo = new System.Windows.Forms.Button();
            this.cmdOpenStudyInfo = new System.Windows.Forms.Button();
            this.cmdOpenRegionInfo = new System.Windows.Forms.Button();
            this.cmdOpenSurveyOverview = new System.Windows.Forms.Button();
            this.cmdOpenCommentUsage = new System.Windows.Forms.Button();
            this.cmdOpenAssignLabels = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.cmdOpenSurveyEditor = new System.Windows.Forms.Button();
            this.MainMenuStrip.SuspendLayout();
            this.pageMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(1340, 24);
            this.MainMenuStrip.TabIndex = 6;
            this.MainMenuStrip.Text = "MainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countryToolStripMenuItem,
            this.projectWaveToolStripMenuItem,
            this.surveyToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // countryToolStripMenuItem
            // 
            this.countryToolStripMenuItem.Name = "countryToolStripMenuItem";
            this.countryToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.countryToolStripMenuItem.Text = "Country/Study...";
            this.countryToolStripMenuItem.Click += new System.EventHandler(this.CountryToolStripMenuItem_Click);
            // 
            // projectWaveToolStripMenuItem
            // 
            this.projectWaveToolStripMenuItem.Name = "projectWaveToolStripMenuItem";
            this.projectWaveToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.projectWaveToolStripMenuItem.Text = "Project Wave...";
            this.projectWaveToolStripMenuItem.Click += new System.EventHandler(this.ProjectWaveToolStripMenuItem_Click);
            // 
            // surveyToolStripMenuItem
            // 
            this.surveyToolStripMenuItem.Name = "surveyToolStripMenuItem";
            this.surveyToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.surveyToolStripMenuItem.Text = "Survey...";
            this.surveyToolStripMenuItem.Click += new System.EventHandler(this.SurveyToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem,
            this.labelsToolStripMenuItem,
            this.cohortListToolStripMenuItem,
            this.userGroupListToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences...";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.PreferencesToolStripMenuItem_Click);
            // 
            // labelsToolStripMenuItem
            // 
            this.labelsToolStripMenuItem.Name = "labelsToolStripMenuItem";
            this.labelsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.labelsToolStripMenuItem.Text = "Labels...";
            this.labelsToolStripMenuItem.Click += new System.EventHandler(this.LabelsToolStripMenuItem_Click);
            // 
            // cohortListToolStripMenuItem
            // 
            this.cohortListToolStripMenuItem.Name = "cohortListToolStripMenuItem";
            this.cohortListToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.cohortListToolStripMenuItem.Text = "Cohort List...";
            this.cohortListToolStripMenuItem.Click += new System.EventHandler(this.CohortListToolStripMenuItem_Click);
            // 
            // userGroupListToolStripMenuItem
            // 
            this.userGroupListToolStripMenuItem.Name = "userGroupListToolStripMenuItem";
            this.userGroupListToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.userGroupListToolStripMenuItem.Text = "User Group List...";
            this.userGroupListToolStripMenuItem.Click += new System.EventHandler(this.UserGroupListToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iSISHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // iSISHelpToolStripMenuItem
            // 
            this.iSISHelpToolStripMenuItem.Name = "iSISHelpToolStripMenuItem";
            this.iSISHelpToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.iSISHelpToolStripMenuItem.Text = "ISIS Help...";
            this.iSISHelpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.cmdOpenSurveyEditor);
            this.pageMain.Controls.Add(this.cmdOpenCreateSurvey);
            this.pageMain.Controls.Add(this.label1);
            this.pageMain.Controls.Add(this.cmdOpenSurveyEntry);
            this.pageMain.Controls.Add(this.cmdOpenSurveyEntry3);
            this.pageMain.Controls.Add(this.cmdOpenSurveyEntry2);
            this.pageMain.Controls.Add(this.tableLayoutPanel1);
            this.pageMain.Location = new System.Drawing.Point(4, 22);
            this.pageMain.Name = "pageMain";
            this.pageMain.Padding = new System.Windows.Forms.Padding(3);
            this.pageMain.Size = new System.Drawing.Size(1332, 952);
            this.pageMain.TabIndex = 0;
            this.pageMain.Text = "Main Menu";
            this.pageMain.UseVisualStyleBackColor = true;
            // 
            // cmdOpenCreateSurvey
            // 
            this.cmdOpenCreateSurvey.Location = new System.Drawing.Point(470, 29);
            this.cmdOpenCreateSurvey.Name = "cmdOpenCreateSurvey";
            this.cmdOpenCreateSurvey.Size = new System.Drawing.Size(111, 22);
            this.cmdOpenCreateSurvey.TabIndex = 1;
            this.cmdOpenCreateSurvey.Text = "Create/Edit Survey";
            this.cmdOpenCreateSurvey.UseVisualStyleBackColor = true;
            this.cmdOpenCreateSurvey.Click += new System.EventHandler(this.cmdOpenCreateSurvey_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(485, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "General Info";
            // 
            // cmdOpenSurveyEntry
            // 
            this.cmdOpenSurveyEntry.Location = new System.Drawing.Point(9, 6);
            this.cmdOpenSurveyEntry.Name = "cmdOpenSurveyEntry";
            this.cmdOpenSurveyEntry.Size = new System.Drawing.Size(111, 25);
            this.cmdOpenSurveyEntry.TabIndex = 2;
            this.cmdOpenSurveyEntry.Text = "Survey Entry";
            this.cmdOpenSurveyEntry.UseVisualStyleBackColor = true;
            this.cmdOpenSurveyEntry.Click += new System.EventHandler(this.cmdOpenSurveyEntry_Click);
            // 
            // cmdOpenSurveyEntry3
            // 
            this.cmdOpenSurveyEntry3.Location = new System.Drawing.Point(243, 6);
            this.cmdOpenSurveyEntry3.Name = "cmdOpenSurveyEntry3";
            this.cmdOpenSurveyEntry3.Size = new System.Drawing.Size(111, 25);
            this.cmdOpenSurveyEntry3.TabIndex = 6;
            this.cmdOpenSurveyEntry3.Text = "Survey Entry 3";
            this.cmdOpenSurveyEntry3.UseVisualStyleBackColor = true;
            this.cmdOpenSurveyEntry3.Click += new System.EventHandler(this.cmdOpenSurveyEntry3_Click);
            // 
            // cmdOpenSurveyEntry2
            // 
            this.cmdOpenSurveyEntry2.Location = new System.Drawing.Point(126, 6);
            this.cmdOpenSurveyEntry2.Name = "cmdOpenSurveyEntry2";
            this.cmdOpenSurveyEntry2.Size = new System.Drawing.Size(111, 25);
            this.cmdOpenSurveyEntry2.TabIndex = 7;
            this.cmdOpenSurveyEntry2.Text = "Survey Entry 2";
            this.cmdOpenSurveyEntry2.UseVisualStyleBackColor = true;
            this.cmdOpenSurveyEntry2.Click += new System.EventHandler(this.cmdOpenSurveyEntry2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.cmdOpenSurveyChecks, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cmdOpenStudyAttributes, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.cmdOpenWaveInfo, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.cmdOpenStudyInfo, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmdOpenRegionInfo, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmdOpenSurveyOverview, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmdOpenCommentUsage, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.cmdOpenAssignLabels, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 112);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(703, 363);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // cmdOpenSurveyChecks
            // 
            this.cmdOpenSurveyChecks.Location = new System.Drawing.Point(3, 64);
            this.cmdOpenSurveyChecks.Name = "cmdOpenSurveyChecks";
            this.cmdOpenSurveyChecks.Size = new System.Drawing.Size(108, 23);
            this.cmdOpenSurveyChecks.TabIndex = 9;
            this.cmdOpenSurveyChecks.Text = "Survey Checks";
            this.cmdOpenSurveyChecks.UseVisualStyleBackColor = true;
            this.cmdOpenSurveyChecks.Click += new System.EventHandler(this.cmdOpenSurveyChecks_Click);
            // 
            // cmdOpenStudyAttributes
            // 
            this.cmdOpenStudyAttributes.Location = new System.Drawing.Point(471, 96);
            this.cmdOpenStudyAttributes.Name = "cmdOpenStudyAttributes";
            this.cmdOpenStudyAttributes.Size = new System.Drawing.Size(111, 26);
            this.cmdOpenStudyAttributes.TabIndex = 3;
            this.cmdOpenStudyAttributes.Text = "Survey Info";
            this.cmdOpenStudyAttributes.UseVisualStyleBackColor = true;
            this.cmdOpenStudyAttributes.Click += new System.EventHandler(this.cmdOpenStudyAttributes_Click);
            // 
            // cmdOpenWaveInfo
            // 
            this.cmdOpenWaveInfo.Location = new System.Drawing.Point(471, 64);
            this.cmdOpenWaveInfo.Name = "cmdOpenWaveInfo";
            this.cmdOpenWaveInfo.Size = new System.Drawing.Size(111, 24);
            this.cmdOpenWaveInfo.TabIndex = 5;
            this.cmdOpenWaveInfo.Text = "Wave Info";
            this.cmdOpenWaveInfo.UseVisualStyleBackColor = true;
            this.cmdOpenWaveInfo.Click += new System.EventHandler(this.cmdOpenWaveInfo_Click);
            // 
            // cmdOpenStudyInfo
            // 
            this.cmdOpenStudyInfo.Location = new System.Drawing.Point(471, 33);
            this.cmdOpenStudyInfo.Name = "cmdOpenStudyInfo";
            this.cmdOpenStudyInfo.Size = new System.Drawing.Size(111, 25);
            this.cmdOpenStudyInfo.TabIndex = 4;
            this.cmdOpenStudyInfo.Text = "Study Info";
            this.cmdOpenStudyInfo.UseVisualStyleBackColor = true;
            this.cmdOpenStudyInfo.Click += new System.EventHandler(this.cmdOpenStudyInfo_Click);
            // 
            // cmdOpenRegionInfo
            // 
            this.cmdOpenRegionInfo.Location = new System.Drawing.Point(471, 3);
            this.cmdOpenRegionInfo.Name = "cmdOpenRegionInfo";
            this.cmdOpenRegionInfo.Size = new System.Drawing.Size(111, 23);
            this.cmdOpenRegionInfo.TabIndex = 7;
            this.cmdOpenRegionInfo.Text = "Region Info";
            this.cmdOpenRegionInfo.UseVisualStyleBackColor = true;
            this.cmdOpenRegionInfo.Click += new System.EventHandler(this.cmdOpenRegionInfo_Click);
            // 
            // cmdOpenSurveyOverview
            // 
            this.cmdOpenSurveyOverview.Location = new System.Drawing.Point(354, 3);
            this.cmdOpenSurveyOverview.Name = "cmdOpenSurveyOverview";
            this.cmdOpenSurveyOverview.Size = new System.Drawing.Size(111, 24);
            this.cmdOpenSurveyOverview.TabIndex = 0;
            this.cmdOpenSurveyOverview.Text = "Survey Overview";
            this.cmdOpenSurveyOverview.UseVisualStyleBackColor = true;
            this.cmdOpenSurveyOverview.Click += new System.EventHandler(this.cmdOpenSurveyOverview_Click);
            // 
            // cmdOpenCommentUsage
            // 
            this.cmdOpenCommentUsage.Location = new System.Drawing.Point(237, 96);
            this.cmdOpenCommentUsage.Name = "cmdOpenCommentUsage";
            this.cmdOpenCommentUsage.Size = new System.Drawing.Size(75, 23);
            this.cmdOpenCommentUsage.TabIndex = 8;
            this.cmdOpenCommentUsage.Text = "Comments";
            this.cmdOpenCommentUsage.UseVisualStyleBackColor = true;
            this.cmdOpenCommentUsage.Click += new System.EventHandler(this.cmdOpenCommentUsage_Click);
            // 
            // cmdOpenAssignLabels
            // 
            this.cmdOpenAssignLabels.Location = new System.Drawing.Point(120, 33);
            this.cmdOpenAssignLabels.Name = "cmdOpenAssignLabels";
            this.cmdOpenAssignLabels.Size = new System.Drawing.Size(75, 23);
            this.cmdOpenAssignLabels.TabIndex = 9;
            this.cmdOpenAssignLabels.Text = "Assign Labels";
            this.cmdOpenAssignLabels.UseVisualStyleBackColor = true;
            this.cmdOpenAssignLabels.Click += new System.EventHandler(this.cmdOpenAssignLabels_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pageMain);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1340, 978);
            this.tabControl1.TabIndex = 7;
            // 
            // cmdOpenSurveyEditor
            // 
            this.cmdOpenSurveyEditor.Location = new System.Drawing.Point(16, 58);
            this.cmdOpenSurveyEditor.Name = "cmdOpenSurveyEditor";
            this.cmdOpenSurveyEditor.Size = new System.Drawing.Size(104, 23);
            this.cmdOpenSurveyEditor.TabIndex = 9;
            this.cmdOpenSurveyEditor.Text = "Survey Editor";
            this.cmdOpenSurveyEditor.UseVisualStyleBackColor = true;
            this.cmdOpenSurveyEditor.Click += new System.EventHandler(this.cmdOpenSurveyEditor_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 1002);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.MainMenuStrip);
            this.Name = "MainMenu";
            this.Text = "ISIS FrontEnd ver. 4.0";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.pageMain.ResumeLayout(false);
            this.pageMain.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.TabPage pageMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button cmdOpenSurveyEntry;
        private System.Windows.Forms.Button cmdOpenSurveyOverview;
        private System.Windows.Forms.Button cmdOpenStudyInfo;
        private System.Windows.Forms.Button cmdOpenCreateSurvey;
        private System.Windows.Forms.Button cmdOpenStudyAttributes;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.Button cmdOpenWaveInfo;
        private System.Windows.Forms.ToolStripMenuItem labelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cohortListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userGroupListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectWaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem surveyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iSISHelpToolStripMenuItem;
        private System.Windows.Forms.Button cmdOpenSurveyEntry3;
        private System.Windows.Forms.Button cmdOpenSurveyEntry2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdOpenRegionInfo;
        private System.Windows.Forms.Button cmdOpenCommentUsage;
        private System.Windows.Forms.Button cmdOpenAssignLabels;
        private System.Windows.Forms.Button cmdOpenSurveyChecks;
        private System.Windows.Forms.Button cmdOpenSurveyEditor;
    }
}

