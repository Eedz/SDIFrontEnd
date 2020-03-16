namespace ISISFrontEnd
{
    partial class SurveyEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SurveyEditor));
            this.label7 = new System.Windows.Forms.Label();
            this.cboGoToVar = new System.Windows.Forms.ComboBox();
            this.txtSurvey = new System.Windows.Forms.TextBox();
            this.navQuestions = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstQuestionList = new System.Windows.Forms.ListView();
            this.Qnum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AltQnum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VarName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VarLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RespName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TableFormat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Corrected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelQuestion = new System.Windows.Forms.Panel();
            this.panelRelated = new System.Windows.Forms.Panel();
            this.lblTranslationCount = new System.Windows.Forms.Label();
            this.lblCommentCount = new System.Windows.Forms.Label();
            this.lblCorrectCount = new System.Windows.Forms.Label();
            this.panelQnum = new System.Windows.Forms.Panel();
            this.lblAltQnum3 = new System.Windows.Forms.Label();
            this.lblAltQnum2 = new System.Windows.Forms.Label();
            this.lblQnum = new System.Windows.Forms.Label();
            this.lblAltQnum = new System.Windows.Forms.Label();
            this.txtAltQnum3 = new System.Windows.Forms.TextBox();
            this.txtAltQnum2 = new System.Windows.Forms.TextBox();
            this.txtAltQnum = new System.Windows.Forms.TextBox();
            this.txtQnum = new System.Windows.Forms.TextBox();
            this.panelLabels = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDomain = new System.Windows.Forms.Label();
            this.lblVarLabel = new System.Windows.Forms.Label();
            this.cboProductLabel = new System.Windows.Forms.ComboBox();
            this.cboContentLabel = new System.Windows.Forms.ComboBox();
            this.cboTopicLabel = new System.Windows.Forms.ComboBox();
            this.cboDomainLabel = new System.Windows.Forms.ComboBox();
            this.txtVarLabel = new System.Windows.Forms.TextBox();
            this.panelFieldInfo = new System.Windows.Forms.Panel();
            this.numDec = new System.Windows.Forms.NumericUpDown();
            this.numCols = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVarType = new System.Windows.Forms.TextBox();
            this.chkScriptOnly = new System.Windows.Forms.CheckBox();
            this.chkTableFormat = new System.Windows.Forms.CheckBox();
            this.cmdToggleFieldInfo = new System.Windows.Forms.Button();
            this.rtbQuestionText = new System.Windows.Forms.RichTextBox();
            this.txtVarName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkHighlightDiffs = new System.Windows.Forms.CheckBox();
            this.cmdOpenRelatedQs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.navQuestions)).BeginInit();
            this.navQuestions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelQuestion.SuspendLayout();
            this.panelRelated.SuspendLayout();
            this.panelQnum.SuspendLayout();
            this.panelLabels.SuspendLayout();
            this.panelFieldInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCols)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(610, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Go To";
            // 
            // cboGoToVar
            // 
            this.cboGoToVar.FormattingEnabled = true;
            this.cboGoToVar.Location = new System.Drawing.Point(653, 85);
            this.cboGoToVar.Name = "cboGoToVar";
            this.cboGoToVar.Size = new System.Drawing.Size(82, 21);
            this.cboGoToVar.TabIndex = 24;
            this.cboGoToVar.SelectedIndexChanged += new System.EventHandler(this.cboGoToVar_SelectedIndexChanged);
            // 
            // txtSurvey
            // 
            this.txtSurvey.Location = new System.Drawing.Point(451, 86);
            this.txtSurvey.Name = "txtSurvey";
            this.txtSurvey.Size = new System.Drawing.Size(106, 20);
            this.txtSurvey.TabIndex = 22;
            // 
            // navQuestions
            // 
            this.navQuestions.AddNewItem = this.bindingNavigatorAddNewItem;
            this.navQuestions.CountItem = this.bindingNavigatorCountItem;
            this.navQuestions.DeleteItem = this.bindingNavigatorDeleteItem;
            this.navQuestions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navQuestions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.navQuestions.Location = new System.Drawing.Point(0, 713);
            this.navQuestions.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.navQuestions.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.navQuestions.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.navQuestions.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.navQuestions.Name = "navQuestions";
            this.navQuestions.PositionItem = this.bindingNavigatorPositionItem;
            this.navQuestions.Size = new System.Drawing.Size(1273, 25);
            this.navQuestions.TabIndex = 34;
            this.navQuestions.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
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
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(12, 121);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstQuestionList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelQuestion);
            this.splitContainer1.Size = new System.Drawing.Size(1199, 580);
            this.splitContainer1.SplitterDistance = 548;
            this.splitContainer1.TabIndex = 37;
            // 
            // lstQuestionList
            // 
            this.lstQuestionList.AllowDrop = true;
            this.lstQuestionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Qnum,
            this.AltQnum,
            this.VarName,
            this.VarLabel,
            this.RespName,
            this.TableFormat,
            this.Corrected});
            this.lstQuestionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstQuestionList.FullRowSelect = true;
            this.lstQuestionList.HideSelection = false;
            this.lstQuestionList.Location = new System.Drawing.Point(0, 0);
            this.lstQuestionList.Name = "lstQuestionList";
            this.lstQuestionList.Size = new System.Drawing.Size(544, 576);
            this.lstQuestionList.TabIndex = 36;
            this.lstQuestionList.UseCompatibleStateImageBehavior = false;
            this.lstQuestionList.View = System.Windows.Forms.View.List;
            this.lstQuestionList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstQuestionList_MouseDoubleClick);
            // 
            // Qnum
            // 
            this.Qnum.Text = "Qnum";
            // 
            // AltQnum
            // 
            this.AltQnum.Text = "AltQnum";
            this.AltQnum.Width = 0;
            // 
            // VarName
            // 
            this.VarName.Text = "VarName";
            this.VarName.Width = 70;
            // 
            // VarLabel
            // 
            this.VarLabel.Text = "VarLabel";
            this.VarLabel.Width = 240;
            // 
            // RespName
            // 
            this.RespName.Text = "RespName";
            // 
            // TableFormat
            // 
            this.TableFormat.Text = "TblFmt";
            this.TableFormat.Width = 40;
            // 
            // Corrected
            // 
            this.Corrected.Text = "Corr";
            this.Corrected.Width = 40;
            // 
            // panelQuestion
            // 
            this.panelQuestion.Controls.Add(this.panelRelated);
            this.panelQuestion.Controls.Add(this.panelQnum);
            this.panelQuestion.Controls.Add(this.panelLabels);
            this.panelQuestion.Controls.Add(this.panelFieldInfo);
            this.panelQuestion.Controls.Add(this.cmdToggleFieldInfo);
            this.panelQuestion.Controls.Add(this.rtbQuestionText);
            this.panelQuestion.Controls.Add(this.txtVarName);
            this.panelQuestion.Location = new System.Drawing.Point(3, 3);
            this.panelQuestion.Name = "panelQuestion";
            this.panelQuestion.Size = new System.Drawing.Size(544, 566);
            this.panelQuestion.TabIndex = 34;
            // 
            // panelRelated
            // 
            this.panelRelated.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelRelated.Controls.Add(this.lblTranslationCount);
            this.panelRelated.Controls.Add(this.lblCommentCount);
            this.panelRelated.Controls.Add(this.lblCorrectCount);
            this.panelRelated.Location = new System.Drawing.Point(6, 338);
            this.panelRelated.Name = "panelRelated";
            this.panelRelated.Size = new System.Drawing.Size(125, 67);
            this.panelRelated.TabIndex = 32;
            // 
            // lblTranslationCount
            // 
            this.lblTranslationCount.AutoSize = true;
            this.lblTranslationCount.Location = new System.Drawing.Point(5, 22);
            this.lblTranslationCount.Name = "lblTranslationCount";
            this.lblTranslationCount.Size = new System.Drawing.Size(78, 13);
            this.lblTranslationCount.TabIndex = 11;
            this.lblTranslationCount.Text = "0 translation(s).";
            // 
            // lblCommentCount
            // 
            this.lblCommentCount.AutoSize = true;
            this.lblCommentCount.Location = new System.Drawing.Point(5, 5);
            this.lblCommentCount.Name = "lblCommentCount";
            this.lblCommentCount.Size = new System.Drawing.Size(74, 13);
            this.lblCommentCount.TabIndex = 10;
            this.lblCommentCount.Text = "0 Comment(s).";
            // 
            // lblCorrectCount
            // 
            this.lblCorrectCount.AutoSize = true;
            this.lblCorrectCount.Location = new System.Drawing.Point(5, 41);
            this.lblCorrectCount.Name = "lblCorrectCount";
            this.lblCorrectCount.Size = new System.Drawing.Size(112, 13);
            this.lblCorrectCount.TabIndex = 12;
            this.lblCorrectCount.Text = "No corrected wording.";
            // 
            // panelQnum
            // 
            this.panelQnum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelQnum.Controls.Add(this.lblAltQnum3);
            this.panelQnum.Controls.Add(this.lblAltQnum2);
            this.panelQnum.Controls.Add(this.lblQnum);
            this.panelQnum.Controls.Add(this.lblAltQnum);
            this.panelQnum.Controls.Add(this.txtAltQnum3);
            this.panelQnum.Controls.Add(this.txtAltQnum2);
            this.panelQnum.Controls.Add(this.txtAltQnum);
            this.panelQnum.Controls.Add(this.txtQnum);
            this.panelQnum.Location = new System.Drawing.Point(6, 43);
            this.panelQnum.Name = "panelQnum";
            this.panelQnum.Size = new System.Drawing.Size(125, 121);
            this.panelQnum.TabIndex = 29;
            // 
            // lblAltQnum3
            // 
            this.lblAltQnum3.AutoSize = true;
            this.lblAltQnum3.Location = new System.Drawing.Point(2, 91);
            this.lblAltQnum3.Name = "lblAltQnum3";
            this.lblAltQnum3.Size = new System.Drawing.Size(53, 13);
            this.lblAltQnum3.TabIndex = 19;
            this.lblAltQnum3.Text = "AltQnum3";
            // 
            // lblAltQnum2
            // 
            this.lblAltQnum2.AutoSize = true;
            this.lblAltQnum2.Location = new System.Drawing.Point(2, 62);
            this.lblAltQnum2.Name = "lblAltQnum2";
            this.lblAltQnum2.Size = new System.Drawing.Size(53, 13);
            this.lblAltQnum2.TabIndex = 18;
            this.lblAltQnum2.Text = "AltQnum2";
            // 
            // lblQnum
            // 
            this.lblQnum.AutoSize = true;
            this.lblQnum.Location = new System.Drawing.Point(33, 13);
            this.lblQnum.Name = "lblQnum";
            this.lblQnum.Size = new System.Drawing.Size(22, 13);
            this.lblQnum.TabIndex = 16;
            this.lblQnum.Text = "Q#";
            // 
            // lblAltQnum
            // 
            this.lblAltQnum.AutoSize = true;
            this.lblAltQnum.Location = new System.Drawing.Point(8, 39);
            this.lblAltQnum.Name = "lblAltQnum";
            this.lblAltQnum.Size = new System.Drawing.Size(47, 13);
            this.lblAltQnum.TabIndex = 17;
            this.lblAltQnum.Text = "AltQnum";
            // 
            // txtAltQnum3
            // 
            this.txtAltQnum3.Location = new System.Drawing.Point(63, 88);
            this.txtAltQnum3.Name = "txtAltQnum3";
            this.txtAltQnum3.Size = new System.Drawing.Size(51, 20);
            this.txtAltQnum3.TabIndex = 6;
            // 
            // txtAltQnum2
            // 
            this.txtAltQnum2.Location = new System.Drawing.Point(63, 62);
            this.txtAltQnum2.Name = "txtAltQnum2";
            this.txtAltQnum2.Size = new System.Drawing.Size(51, 20);
            this.txtAltQnum2.TabIndex = 5;
            // 
            // txtAltQnum
            // 
            this.txtAltQnum.Location = new System.Drawing.Point(63, 36);
            this.txtAltQnum.Name = "txtAltQnum";
            this.txtAltQnum.Size = new System.Drawing.Size(51, 20);
            this.txtAltQnum.TabIndex = 4;
            // 
            // txtQnum
            // 
            this.txtQnum.Location = new System.Drawing.Point(63, 10);
            this.txtQnum.Name = "txtQnum";
            this.txtQnum.Size = new System.Drawing.Size(51, 20);
            this.txtQnum.TabIndex = 3;
            // 
            // panelLabels
            // 
            this.panelLabels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLabels.Controls.Add(this.label10);
            this.panelLabels.Controls.Add(this.label9);
            this.panelLabels.Controls.Add(this.label8);
            this.panelLabels.Controls.Add(this.lblDomain);
            this.panelLabels.Controls.Add(this.lblVarLabel);
            this.panelLabels.Controls.Add(this.cboProductLabel);
            this.panelLabels.Controls.Add(this.cboContentLabel);
            this.panelLabels.Controls.Add(this.cboTopicLabel);
            this.panelLabels.Controls.Add(this.cboDomainLabel);
            this.panelLabels.Controls.Add(this.txtVarLabel);
            this.panelLabels.Location = new System.Drawing.Point(137, 409);
            this.panelLabels.Name = "panelLabels";
            this.panelLabels.Size = new System.Drawing.Size(365, 138);
            this.panelLabels.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Product";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Content";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Topic";
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Location = new System.Drawing.Point(34, 30);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(43, 13);
            this.lblDomain.TabIndex = 6;
            this.lblDomain.Text = "Domain";
            // 
            // lblVarLabel
            // 
            this.lblVarLabel.AutoSize = true;
            this.lblVarLabel.Location = new System.Drawing.Point(28, 6);
            this.lblVarLabel.Name = "lblVarLabel";
            this.lblVarLabel.Size = new System.Drawing.Size(49, 13);
            this.lblVarLabel.TabIndex = 5;
            this.lblVarLabel.Text = "VarLabel";
            // 
            // cboProductLabel
            // 
            this.cboProductLabel.FormattingEnabled = true;
            this.cboProductLabel.Location = new System.Drawing.Point(86, 108);
            this.cboProductLabel.Name = "cboProductLabel";
            this.cboProductLabel.Size = new System.Drawing.Size(245, 21);
            this.cboProductLabel.TabIndex = 4;
            // 
            // cboContentLabel
            // 
            this.cboContentLabel.FormattingEnabled = true;
            this.cboContentLabel.Location = new System.Drawing.Point(86, 81);
            this.cboContentLabel.Name = "cboContentLabel";
            this.cboContentLabel.Size = new System.Drawing.Size(245, 21);
            this.cboContentLabel.TabIndex = 3;
            // 
            // cboTopicLabel
            // 
            this.cboTopicLabel.FormattingEnabled = true;
            this.cboTopicLabel.Location = new System.Drawing.Point(86, 54);
            this.cboTopicLabel.Name = "cboTopicLabel";
            this.cboTopicLabel.Size = new System.Drawing.Size(245, 21);
            this.cboTopicLabel.TabIndex = 2;
            // 
            // cboDomainLabel
            // 
            this.cboDomainLabel.FormattingEnabled = true;
            this.cboDomainLabel.Location = new System.Drawing.Point(86, 27);
            this.cboDomainLabel.Name = "cboDomainLabel";
            this.cboDomainLabel.Size = new System.Drawing.Size(245, 21);
            this.cboDomainLabel.TabIndex = 1;
            // 
            // txtVarLabel
            // 
            this.txtVarLabel.Location = new System.Drawing.Point(86, 3);
            this.txtVarLabel.Name = "txtVarLabel";
            this.txtVarLabel.Size = new System.Drawing.Size(245, 20);
            this.txtVarLabel.TabIndex = 0;
            // 
            // panelFieldInfo
            // 
            this.panelFieldInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelFieldInfo.Controls.Add(this.numDec);
            this.panelFieldInfo.Controls.Add(this.numCols);
            this.panelFieldInfo.Controls.Add(this.label3);
            this.panelFieldInfo.Controls.Add(this.label2);
            this.panelFieldInfo.Controls.Add(this.label1);
            this.panelFieldInfo.Controls.Add(this.txtVarType);
            this.panelFieldInfo.Controls.Add(this.chkScriptOnly);
            this.panelFieldInfo.Controls.Add(this.chkTableFormat);
            this.panelFieldInfo.Location = new System.Drawing.Point(6, 199);
            this.panelFieldInfo.Name = "panelFieldInfo";
            this.panelFieldInfo.Size = new System.Drawing.Size(125, 133);
            this.panelFieldInfo.TabIndex = 27;
            this.panelFieldInfo.Visible = false;
            // 
            // numDec
            // 
            this.numDec.Location = new System.Drawing.Point(66, 75);
            this.numDec.Name = "numDec";
            this.numDec.Size = new System.Drawing.Size(42, 20);
            this.numDec.TabIndex = 9;
            // 
            // numCols
            // 
            this.numCols.Location = new System.Drawing.Point(66, 49);
            this.numCols.Name = "numCols";
            this.numCols.Size = new System.Drawing.Size(42, 20);
            this.numCols.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Dec";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cols";
            // 
            // txtVarType
            // 
            this.txtVarType.Location = new System.Drawing.Point(66, 101);
            this.txtVarType.Name = "txtVarType";
            this.txtVarType.Size = new System.Drawing.Size(42, 20);
            this.txtVarType.TabIndex = 4;
            // 
            // chkScriptOnly
            // 
            this.chkScriptOnly.AutoSize = true;
            this.chkScriptOnly.Location = new System.Drawing.Point(29, 26);
            this.chkScriptOnly.Name = "chkScriptOnly";
            this.chkScriptOnly.Size = new System.Drawing.Size(77, 17);
            this.chkScriptOnly.TabIndex = 1;
            this.chkScriptOnly.Text = "Script Only";
            this.chkScriptOnly.UseVisualStyleBackColor = true;
            // 
            // chkTableFormat
            // 
            this.chkTableFormat.AutoSize = true;
            this.chkTableFormat.Location = new System.Drawing.Point(29, 3);
            this.chkTableFormat.Name = "chkTableFormat";
            this.chkTableFormat.Size = new System.Drawing.Size(88, 17);
            this.chkTableFormat.TabIndex = 0;
            this.chkTableFormat.Text = "Table Format";
            this.chkTableFormat.UseVisualStyleBackColor = true;
            // 
            // cmdToggleFieldInfo
            // 
            this.cmdToggleFieldInfo.Location = new System.Drawing.Point(53, 174);
            this.cmdToggleFieldInfo.Name = "cmdToggleFieldInfo";
            this.cmdToggleFieldInfo.Size = new System.Drawing.Size(30, 19);
            this.cmdToggleFieldInfo.TabIndex = 26;
            this.cmdToggleFieldInfo.Text = "v";
            this.cmdToggleFieldInfo.UseVisualStyleBackColor = true;
            // 
            // rtbQuestionText
            // 
            this.rtbQuestionText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbQuestionText.Location = new System.Drawing.Point(137, 43);
            this.rtbQuestionText.Name = "rtbQuestionText";
            this.rtbQuestionText.Size = new System.Drawing.Size(365, 360);
            this.rtbQuestionText.TabIndex = 25;
            this.rtbQuestionText.Text = "";
            // 
            // txtVarName
            // 
            this.txtVarName.Location = new System.Drawing.Point(137, 17);
            this.txtVarName.Name = "txtVarName";
            this.txtVarName.Size = new System.Drawing.Size(365, 20);
            this.txtVarName.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(515, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 33);
            this.label4.TabIndex = 38;
            this.label4.Text = "Survey Editor";
            // 
            // chkHighlightDiffs
            // 
            this.chkHighlightDiffs.AutoSize = true;
            this.chkHighlightDiffs.Location = new System.Drawing.Point(813, 85);
            this.chkHighlightDiffs.Name = "chkHighlightDiffs";
            this.chkHighlightDiffs.Size = new System.Drawing.Size(112, 17);
            this.chkHighlightDiffs.TabIndex = 39;
            this.chkHighlightDiffs.Text = "Highlight Changes";
            this.chkHighlightDiffs.UseVisualStyleBackColor = true;
            this.chkHighlightDiffs.CheckedChanged += new System.EventHandler(this.chkHighlightDiffs_CheckedChanged);
            // 
            // cmdOpenRelatedQs
            // 
            this.cmdOpenRelatedQs.Location = new System.Drawing.Point(134, 28);
            this.cmdOpenRelatedQs.Name = "cmdOpenRelatedQs";
            this.cmdOpenRelatedQs.Size = new System.Drawing.Size(105, 23);
            this.cmdOpenRelatedQs.TabIndex = 40;
            this.cmdOpenRelatedQs.Text = "Related Questions";
            this.cmdOpenRelatedQs.UseVisualStyleBackColor = true;
            this.cmdOpenRelatedQs.Click += new System.EventHandler(this.cmdOpenRelatedQs_Click);
            // 
            // SurveyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 738);
            this.Controls.Add(this.cmdOpenRelatedQs);
            this.Controls.Add(this.chkHighlightDiffs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboGoToVar);
            this.Controls.Add(this.txtSurvey);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.navQuestions);
            this.Controls.Add(this.label7);
            this.Name = "SurveyEditor";
            this.Text = "SurveyEditor";
            ((System.ComponentModel.ISupportInitialize)(this.navQuestions)).EndInit();
            this.navQuestions.ResumeLayout(false);
            this.navQuestions.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelQuestion.ResumeLayout(false);
            this.panelQuestion.PerformLayout();
            this.panelRelated.ResumeLayout(false);
            this.panelRelated.PerformLayout();
            this.panelQnum.ResumeLayout(false);
            this.panelQnum.PerformLayout();
            this.panelLabels.ResumeLayout(false);
            this.panelLabels.PerformLayout();
            this.panelFieldInfo.ResumeLayout(false);
            this.panelFieldInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboGoToVar;
        private System.Windows.Forms.TextBox txtSurvey;
        private System.Windows.Forms.BindingNavigator navQuestions;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lstQuestionList;
        private System.Windows.Forms.ColumnHeader Qnum;
        private System.Windows.Forms.ColumnHeader AltQnum;
        private System.Windows.Forms.ColumnHeader VarName;
        private System.Windows.Forms.ColumnHeader VarLabel;
        private System.Windows.Forms.ColumnHeader RespName;
        private System.Windows.Forms.ColumnHeader TableFormat;
        private System.Windows.Forms.ColumnHeader Corrected;
        private System.Windows.Forms.Panel panelQuestion;
        private System.Windows.Forms.Panel panelRelated;
        private System.Windows.Forms.Label lblTranslationCount;
        private System.Windows.Forms.Label lblCommentCount;
        private System.Windows.Forms.Label lblCorrectCount;
        private System.Windows.Forms.Panel panelQnum;
        private System.Windows.Forms.Label lblAltQnum3;
        private System.Windows.Forms.Label lblAltQnum2;
        private System.Windows.Forms.Label lblQnum;
        private System.Windows.Forms.Label lblAltQnum;
        private System.Windows.Forms.TextBox txtAltQnum3;
        private System.Windows.Forms.TextBox txtAltQnum2;
        private System.Windows.Forms.TextBox txtAltQnum;
        private System.Windows.Forms.TextBox txtQnum;
        private System.Windows.Forms.Panel panelLabels;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDomain;
        private System.Windows.Forms.Label lblVarLabel;
        private System.Windows.Forms.ComboBox cboProductLabel;
        private System.Windows.Forms.ComboBox cboContentLabel;
        private System.Windows.Forms.ComboBox cboTopicLabel;
        private System.Windows.Forms.ComboBox cboDomainLabel;
        private System.Windows.Forms.TextBox txtVarLabel;
        private System.Windows.Forms.Panel panelFieldInfo;
        private System.Windows.Forms.NumericUpDown numDec;
        private System.Windows.Forms.NumericUpDown numCols;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVarType;
        private System.Windows.Forms.CheckBox chkScriptOnly;
        private System.Windows.Forms.CheckBox chkTableFormat;
        private System.Windows.Forms.Button cmdToggleFieldInfo;
        private System.Windows.Forms.RichTextBox rtbQuestionText;
        private System.Windows.Forms.TextBox txtVarName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkHighlightDiffs;
        private System.Windows.Forms.Button cmdOpenRelatedQs;
    }
}