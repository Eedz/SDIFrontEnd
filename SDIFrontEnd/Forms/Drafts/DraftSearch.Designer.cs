namespace ISISFrontEnd
{
    partial class DraftSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DraftSearch));
            this.repeaterRecords = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.cmdQuestions = new System.Windows.Forms.Button();
            this.cmdGoToDraft = new System.Windows.Forms.Button();
            this.lblDraftTitle = new System.Windows.Forms.Label();
            this.chkDeleted = new System.Windows.Forms.CheckBox();
            this.chkNewRow = new System.Windows.Forms.CheckBox();
            this.rtbExtra5 = new System.Windows.Forms.RichTextBox();
            this.rtbExtra4 = new System.Windows.Forms.RichTextBox();
            this.rtbExtra3 = new System.Windows.Forms.RichTextBox();
            this.rtbExtra2 = new System.Windows.Forms.RichTextBox();
            this.rtbExtra1 = new System.Windows.Forms.RichTextBox();
            this.rtbComments = new System.Windows.Forms.RichTextBox();
            this.rtbQuestionText = new System.Windows.Forms.RichTextBox();
            this.txtVarName = new System.Windows.Forms.TextBox();
            this.txtAltQnum = new System.Windows.Forms.TextBox();
            this.txtQnum = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboSurveyFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboInvestigatorFilter = new System.Windows.Forms.ComboBox();
            this.cboDateFilter = new System.Windows.Forms.ComboBox();
            this.txtRefVarFilter = new System.Windows.Forms.TextBox();
            this.txtQuestionFilter = new System.Windows.Forms.TextBox();
            this.txtCommentFilter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.panelCriteria = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblQuestionText = new System.Windows.Forms.Label();
            this.lblComments = new System.Windows.Forms.Label();
            this.panelResults = new System.Windows.Forms.Panel();
            this.lblEF5 = new System.Windows.Forms.Label();
            this.lblEF4 = new System.Windows.Forms.Label();
            this.lblEF3 = new System.Windows.Forms.Label();
            this.lblEF2 = new System.Windows.Forms.Label();
            this.lblEF1 = new System.Windows.Forms.Label();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.repeaterRecords.ItemTemplate.SuspendLayout();
            this.repeaterRecords.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelCriteria.SuspendLayout();
            this.panelResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // repeaterRecords
            // 
            // 
            // repeaterRecords.ItemTemplate
            // 
            this.repeaterRecords.ItemTemplate.Controls.Add(this.cmdQuestions);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.cmdGoToDraft);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.lblDraftTitle);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.chkDeleted);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.chkNewRow);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.rtbExtra5);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.rtbExtra4);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.rtbExtra3);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.rtbExtra2);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.rtbExtra1);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.rtbComments);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.rtbQuestionText);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.txtVarName);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.txtAltQnum);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.txtQnum);
            this.repeaterRecords.ItemTemplate.Margin = new System.Windows.Forms.Padding(4);
            this.repeaterRecords.ItemTemplate.Size = new System.Drawing.Size(1710, 282);
            this.repeaterRecords.Location = new System.Drawing.Point(4, 39);
            this.repeaterRecords.Margin = new System.Windows.Forms.Padding(4);
            this.repeaterRecords.Name = "repeaterRecords";
            this.repeaterRecords.Padding = new System.Windows.Forms.Padding(4);
            this.repeaterRecords.Size = new System.Drawing.Size(1720, 564);
            this.repeaterRecords.TabIndex = 0;
            this.repeaterRecords.Text = "dataRepeater1";
            this.repeaterRecords.DrawItem += new Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventHandler(this.repeaterRecords_DrawItem);
            // 
            // cmdQuestions
            // 
            this.cmdQuestions.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmdQuestions.Location = new System.Drawing.Point(9, 255);
            this.cmdQuestions.Name = "cmdQuestions";
            this.cmdQuestions.Size = new System.Drawing.Size(187, 23);
            this.cmdQuestions.TabIndex = 21;
            this.cmdQuestions.Text = "Question Versions";
            this.cmdQuestions.UseVisualStyleBackColor = false;
            this.cmdQuestions.Visible = false;
            this.cmdQuestions.Click += new System.EventHandler(this.cmdQuestions_Click);
            // 
            // cmdGoToDraft
            // 
            this.cmdGoToDraft.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmdGoToDraft.Location = new System.Drawing.Point(9, 226);
            this.cmdGoToDraft.Name = "cmdGoToDraft";
            this.cmdGoToDraft.Size = new System.Drawing.Size(187, 23);
            this.cmdGoToDraft.TabIndex = 20;
            this.cmdGoToDraft.Text = "Go To Draft";
            this.cmdGoToDraft.UseVisualStyleBackColor = false;
            this.cmdGoToDraft.Visible = false;
            this.cmdGoToDraft.Click += new System.EventHandler(this.cmdGoToDraft_Click);
            // 
            // lblDraftTitle
            // 
            this.lblDraftTitle.Location = new System.Drawing.Point(6, 90);
            this.lblDraftTitle.Name = "lblDraftTitle";
            this.lblDraftTitle.Size = new System.Drawing.Size(190, 133);
            this.lblDraftTitle.TabIndex = 19;
            this.lblDraftTitle.Text = "Draft Title";
            // 
            // chkDeleted
            // 
            this.chkDeleted.AutoSize = true;
            this.chkDeleted.Location = new System.Drawing.Point(3, 60);
            this.chkDeleted.Name = "chkDeleted";
            this.chkDeleted.Size = new System.Drawing.Size(70, 20);
            this.chkDeleted.TabIndex = 18;
            this.chkDeleted.Text = "Deleted";
            this.chkDeleted.UseVisualStyleBackColor = true;
            // 
            // chkNewRow
            // 
            this.chkNewRow.AutoSize = true;
            this.chkNewRow.Location = new System.Drawing.Point(3, 34);
            this.chkNewRow.Name = "chkNewRow";
            this.chkNewRow.Size = new System.Drawing.Size(81, 20);
            this.chkNewRow.TabIndex = 17;
            this.chkNewRow.Text = "New Row";
            this.chkNewRow.UseVisualStyleBackColor = true;
            // 
            // rtbExtra5
            // 
            this.rtbExtra5.Location = new System.Drawing.Point(974, 3);
            this.rtbExtra5.Name = "rtbExtra5";
            this.rtbExtra5.Size = new System.Drawing.Size(100, 275);
            this.rtbExtra5.TabIndex = 16;
            this.rtbExtra5.Text = "";
            // 
            // rtbExtra4
            // 
            this.rtbExtra4.Location = new System.Drawing.Point(868, 3);
            this.rtbExtra4.Name = "rtbExtra4";
            this.rtbExtra4.Size = new System.Drawing.Size(100, 275);
            this.rtbExtra4.TabIndex = 15;
            this.rtbExtra4.Text = "";
            // 
            // rtbExtra3
            // 
            this.rtbExtra3.Location = new System.Drawing.Point(762, 3);
            this.rtbExtra3.Name = "rtbExtra3";
            this.rtbExtra3.Size = new System.Drawing.Size(100, 275);
            this.rtbExtra3.TabIndex = 14;
            this.rtbExtra3.Text = "";
            // 
            // rtbExtra2
            // 
            this.rtbExtra2.Location = new System.Drawing.Point(656, 3);
            this.rtbExtra2.Name = "rtbExtra2";
            this.rtbExtra2.Size = new System.Drawing.Size(100, 275);
            this.rtbExtra2.TabIndex = 13;
            this.rtbExtra2.Text = "";
            // 
            // rtbExtra1
            // 
            this.rtbExtra1.Location = new System.Drawing.Point(550, 3);
            this.rtbExtra1.Name = "rtbExtra1";
            this.rtbExtra1.Size = new System.Drawing.Size(100, 275);
            this.rtbExtra1.TabIndex = 12;
            this.rtbExtra1.Text = "";
            // 
            // rtbComments
            // 
            this.rtbComments.Location = new System.Drawing.Point(444, 3);
            this.rtbComments.Name = "rtbComments";
            this.rtbComments.Size = new System.Drawing.Size(100, 275);
            this.rtbComments.TabIndex = 11;
            this.rtbComments.Text = "";
            // 
            // rtbQuestionText
            // 
            this.rtbQuestionText.Location = new System.Drawing.Point(202, 3);
            this.rtbQuestionText.Name = "rtbQuestionText";
            this.rtbQuestionText.Size = new System.Drawing.Size(236, 275);
            this.rtbQuestionText.TabIndex = 10;
            this.rtbQuestionText.Text = "";
            // 
            // txtVarName
            // 
            this.txtVarName.Location = new System.Drawing.Point(116, 5);
            this.txtVarName.Name = "txtVarName";
            this.txtVarName.Size = new System.Drawing.Size(80, 23);
            this.txtVarName.TabIndex = 2;
            // 
            // txtAltQnum
            // 
            this.txtAltQnum.Location = new System.Drawing.Point(60, 5);
            this.txtAltQnum.Name = "txtAltQnum";
            this.txtAltQnum.Size = new System.Drawing.Size(50, 23);
            this.txtAltQnum.TabIndex = 1;
            // 
            // txtQnum
            // 
            this.txtQnum.Location = new System.Drawing.Point(3, 5);
            this.txtQnum.Name = "txtQnum";
            this.txtQnum.Size = new System.Drawing.Size(50, 23);
            this.txtQnum.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1746, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // cboSurveyFilter
            // 
            this.cboSurveyFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSurveyFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSurveyFilter.FormattingEnabled = true;
            this.cboSurveyFilter.Location = new System.Drawing.Point(55, 16);
            this.cboSurveyFilter.Margin = new System.Windows.Forms.Padding(4);
            this.cboSurveyFilter.Name = "cboSurveyFilter";
            this.cboSurveyFilter.Size = new System.Drawing.Size(151, 24);
            this.cboSurveyFilter.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(493, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Draft Search";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Survey";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Investigator";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "VarName";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(402, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Question Text";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(679, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Comment Text";
            // 
            // cboInvestigatorFilter
            // 
            this.cboInvestigatorFilter.FormattingEnabled = true;
            this.cboInvestigatorFilter.Location = new System.Drawing.Point(296, 46);
            this.cboInvestigatorFilter.Name = "cboInvestigatorFilter";
            this.cboInvestigatorFilter.Size = new System.Drawing.Size(100, 24);
            this.cboInvestigatorFilter.TabIndex = 11;
            // 
            // cboDateFilter
            // 
            this.cboDateFilter.DropDownWidth = 500;
            this.cboDateFilter.FormattingEnabled = true;
            this.cboDateFilter.Location = new System.Drawing.Point(55, 46);
            this.cboDateFilter.Name = "cboDateFilter";
            this.cboDateFilter.Size = new System.Drawing.Size(151, 24);
            this.cboDateFilter.TabIndex = 12;
            // 
            // txtRefVarFilter
            // 
            this.txtRefVarFilter.Location = new System.Drawing.Point(296, 17);
            this.txtRefVarFilter.Name = "txtRefVarFilter";
            this.txtRefVarFilter.Size = new System.Drawing.Size(100, 23);
            this.txtRefVarFilter.TabIndex = 13;
            // 
            // txtQuestionFilter
            // 
            this.txtQuestionFilter.Location = new System.Drawing.Point(495, 17);
            this.txtQuestionFilter.Multiline = true;
            this.txtQuestionFilter.Name = "txtQuestionFilter";
            this.txtQuestionFilter.Size = new System.Drawing.Size(174, 53);
            this.txtQuestionFilter.TabIndex = 14;
            // 
            // txtCommentFilter
            // 
            this.txtCommentFilter.Location = new System.Drawing.Point(777, 17);
            this.txtCommentFilter.Multiline = true;
            this.txtCommentFilter.Name = "txtCommentFilter";
            this.txtCommentFilter.Size = new System.Drawing.Size(139, 53);
            this.txtCommentFilter.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Qnum";
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(961, 26);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(75, 23);
            this.cmdSearch.TabIndex = 17;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // panelCriteria
            // 
            this.panelCriteria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCriteria.Controls.Add(this.cmdSearch);
            this.panelCriteria.Controls.Add(this.txtCommentFilter);
            this.panelCriteria.Controls.Add(this.txtQuestionFilter);
            this.panelCriteria.Controls.Add(this.txtRefVarFilter);
            this.panelCriteria.Controls.Add(this.cboDateFilter);
            this.panelCriteria.Controls.Add(this.cboInvestigatorFilter);
            this.panelCriteria.Controls.Add(this.label8);
            this.panelCriteria.Controls.Add(this.label7);
            this.panelCriteria.Controls.Add(this.label6);
            this.panelCriteria.Controls.Add(this.label4);
            this.panelCriteria.Controls.Add(this.label3);
            this.panelCriteria.Controls.Add(this.label2);
            this.panelCriteria.Controls.Add(this.cboSurveyFilter);
            this.panelCriteria.Location = new System.Drawing.Point(4, 70);
            this.panelCriteria.Name = "panelCriteria";
            this.panelCriteria.Size = new System.Drawing.Size(1050, 84);
            this.panelCriteria.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(83, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "AltQ#";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(148, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "VarName";
            // 
            // lblQuestionText
            // 
            this.lblQuestionText.Location = new System.Drawing.Point(226, 0);
            this.lblQuestionText.Name = "lblQuestionText";
            this.lblQuestionText.Size = new System.Drawing.Size(236, 35);
            this.lblQuestionText.TabIndex = 21;
            this.lblQuestionText.Text = "Question Text";
            this.lblQuestionText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblComments
            // 
            this.lblComments.Location = new System.Drawing.Point(468, 0);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(100, 35);
            this.lblComments.TabIndex = 22;
            this.lblComments.Text = "Comment";
            this.lblComments.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelResults
            // 
            this.panelResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelResults.Controls.Add(this.lblEF5);
            this.panelResults.Controls.Add(this.lblEF4);
            this.panelResults.Controls.Add(this.lblEF3);
            this.panelResults.Controls.Add(this.lblEF2);
            this.panelResults.Controls.Add(this.lblEF1);
            this.panelResults.Controls.Add(this.bindingNavigator1);
            this.panelResults.Controls.Add(this.lblComments);
            this.panelResults.Controls.Add(this.lblQuestionText);
            this.panelResults.Controls.Add(this.label10);
            this.panelResults.Controls.Add(this.repeaterRecords);
            this.panelResults.Controls.Add(this.label9);
            this.panelResults.Controls.Add(this.label5);
            this.panelResults.Location = new System.Drawing.Point(4, 160);
            this.panelResults.Name = "panelResults";
            this.panelResults.Size = new System.Drawing.Size(1730, 647);
            this.panelResults.TabIndex = 23;
            // 
            // lblEF5
            // 
            this.lblEF5.Location = new System.Drawing.Point(998, 2);
            this.lblEF5.Name = "lblEF5";
            this.lblEF5.Size = new System.Drawing.Size(100, 33);
            this.lblEF5.TabIndex = 28;
            this.lblEF5.Text = "Extra Field 5";
            this.lblEF5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEF4
            // 
            this.lblEF4.Location = new System.Drawing.Point(892, 2);
            this.lblEF4.Name = "lblEF4";
            this.lblEF4.Size = new System.Drawing.Size(100, 33);
            this.lblEF4.TabIndex = 27;
            this.lblEF4.Text = "Extra Field 4";
            this.lblEF4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEF3
            // 
            this.lblEF3.Location = new System.Drawing.Point(786, 2);
            this.lblEF3.Name = "lblEF3";
            this.lblEF3.Size = new System.Drawing.Size(100, 33);
            this.lblEF3.TabIndex = 26;
            this.lblEF3.Text = "Extra Field 3";
            this.lblEF3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEF2
            // 
            this.lblEF2.Location = new System.Drawing.Point(682, 2);
            this.lblEF2.Name = "lblEF2";
            this.lblEF2.Size = new System.Drawing.Size(98, 33);
            this.lblEF2.TabIndex = 25;
            this.lblEF2.Text = "Extra Field 2";
            this.lblEF2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEF1
            // 
            this.lblEF1.Location = new System.Drawing.Point(574, 2);
            this.lblEF1.Name = "lblEF1";
            this.lblEF1.Size = new System.Drawing.Size(100, 33);
            this.lblEF1.TabIndex = 24;
            this.lblEF1.Text = "Extra Field 1";
            this.lblEF1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 620);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1728, 25);
            this.bindingNavigator1.TabIndex = 23;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // DraftSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(189)))));
            this.ClientSize = new System.Drawing.Size(1746, 1061);
            this.Controls.Add(this.panelResults);
            this.Controls.Add(this.panelCriteria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DraftSearch";
            this.Text = "Draft Search";
            this.repeaterRecords.ItemTemplate.ResumeLayout(false);
            this.repeaterRecords.ItemTemplate.PerformLayout();
            this.repeaterRecords.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelCriteria.ResumeLayout(false);
            this.panelCriteria.PerformLayout();
            this.panelResults.ResumeLayout(false);
            this.panelResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.DataRepeater repeaterRecords;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.TextBox txtVarName;
        private System.Windows.Forms.TextBox txtAltQnum;
        private System.Windows.Forms.TextBox txtQnum;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboSurveyFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboInvestigatorFilter;
        private System.Windows.Forms.ComboBox cboDateFilter;
        private System.Windows.Forms.TextBox txtRefVarFilter;
        private System.Windows.Forms.TextBox txtQuestionFilter;
        private System.Windows.Forms.TextBox txtCommentFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Panel panelCriteria;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblQuestionText;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.Panel panelResults;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.RichTextBox rtbQuestionText;
        private System.Windows.Forms.RichTextBox rtbExtra5;
        private System.Windows.Forms.RichTextBox rtbExtra4;
        private System.Windows.Forms.RichTextBox rtbExtra3;
        private System.Windows.Forms.RichTextBox rtbExtra2;
        private System.Windows.Forms.RichTextBox rtbExtra1;
        private System.Windows.Forms.RichTextBox rtbComments;
        private System.Windows.Forms.Label lblEF5;
        private System.Windows.Forms.Label lblEF4;
        private System.Windows.Forms.Label lblEF3;
        private System.Windows.Forms.Label lblEF2;
        private System.Windows.Forms.Label lblEF1;
        private System.Windows.Forms.CheckBox chkDeleted;
        private System.Windows.Forms.CheckBox chkNewRow;
        private System.Windows.Forms.Button cmdQuestions;
        private System.Windows.Forms.Button cmdGoToDraft;
        private System.Windows.Forms.Label lblDraftTitle;
    }
}