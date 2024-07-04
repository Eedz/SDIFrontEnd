namespace SDIFrontEnd
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
            this.navQuestions = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
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
            this.NewQnum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Qnum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AltQnum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VarName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VarLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RespName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Corrected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelQuestion = new System.Windows.Forms.Panel();
            this.lstImages = new System.Windows.Forms.ListBox();
            this.cmdDeleteImage = new System.Windows.Forms.Button();
            this.cmdAddImage = new System.Windows.Forms.Button();
            this.txtPstP = new System.Windows.Forms.TextBox();
            this.txtPstI = new System.Windows.Forms.TextBox();
            this.txtNR = new System.Windows.Forms.TextBox();
            this.txtRO = new System.Windows.Forms.TextBox();
            this.txtLitQ = new System.Windows.Forms.TextBox();
            this.txtPreA = new System.Windows.Forms.TextBox();
            this.txtPreI = new System.Windows.Forms.TextBox();
            this.txtPreP = new System.Windows.Forms.TextBox();
            this.rtbPlainFilter = new SDIFrontEnd.ExtraRichTextBox();
            this.dgvTimeFrames = new System.Windows.Forms.DataGridView();
            this.chTimeFrame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdOpenPstP = new System.Windows.Forms.Button();
            this.cmdOpenPstI = new System.Windows.Forms.Button();
            this.cmdOpenNonResp = new System.Windows.Forms.Button();
            this.cmdOpenResp = new System.Windows.Forms.Button();
            this.cmdOpenLitQ = new System.Windows.Forms.Button();
            this.cmdOpenPreA = new System.Windows.Forms.Button();
            this.cmdOpenPreI = new System.Windows.Forms.Button();
            this.cmdOpenPreP = new System.Windows.Forms.Button();
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
            this.rtbQuestionText = new System.Windows.Forms.RichTextBox();
            this.txtVarName = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.questionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.harmonyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prefixListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unusedVarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameVarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboSurvey = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripExport = new System.Windows.Forms.ToolStrip();
            this.toolStripDisplayBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripExportBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripQ = new System.Windows.Forms.ToolStripButton();
            this.toolStripT = new System.Windows.Forms.ToolStripButton();
            this.toolStripC = new System.Windows.Forms.ToolStripButton();
            this.toolStripF = new System.Windows.Forms.ToolStripButton();
            this.toolStripRelatedData = new System.Windows.Forms.ToolStrip();
            this.toolStripAddTranslation = new System.Windows.Forms.ToolStripButton();
            this.toolStripTranslation = new System.Windows.Forms.ToolStripButton();
            this.toolStripLanguage = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripViewComments = new System.Windows.Forms.ToolStripButton();
            this.toolStripDeleted = new System.Windows.Forms.ToolStripButton();
            this.toolStripCorrected = new System.Windows.Forms.ToolStripButton();
            this.toolStripRelated = new System.Windows.Forms.ToolStripButton();
            this.toolStripFunctions = new System.Windows.Forms.ToolStrip();
            this.toolStripAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripCopyPrev = new System.Windows.Forms.ToolStripButton();
            this.cmdUnlock = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmdSaveSurvey = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSearchQs = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEdited = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboMoveTo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.navQuestions)).BeginInit();
            this.navQuestions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelQuestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeFrames)).BeginInit();
            this.panelRelated.SuspendLayout();
            this.panelQnum.SuspendLayout();
            this.panelLabels.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.toolStripExport.SuspendLayout();
            this.toolStripRelatedData.SuspendLayout();
            this.toolStripFunctions.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(572, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 16);
            this.label7.TabIndex = 30;
            this.label7.Text = "Go To";
            // 
            // cboGoToVar
            // 
            this.cboGoToVar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboGoToVar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGoToVar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGoToVar.FormattingEnabled = true;
            this.cboGoToVar.Location = new System.Drawing.Point(622, 156);
            this.cboGoToVar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboGoToVar.Name = "cboGoToVar";
            this.cboGoToVar.Size = new System.Drawing.Size(95, 24);
            this.cboGoToVar.TabIndex = 24;
            this.cboGoToVar.SelectedIndexChanged += new System.EventHandler(this.cboGoToVar_SelectedIndexChanged);
            this.cboGoToVar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboGoToVar_KeyUp);
            // 
            // navQuestions
            // 
            this.navQuestions.AddNewItem = null;
            this.navQuestions.CountItem = this.bindingNavigatorCountItem;
            this.navQuestions.DeleteItem = null;
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
            this.bindingNavigatorSeparator2});
            this.navQuestions.Location = new System.Drawing.Point(0, 882);
            this.navQuestions.MoveFirstItem = null;
            this.navQuestions.MoveLastItem = null;
            this.navQuestions.MoveNextItem = null;
            this.navQuestions.MovePreviousItem = null;
            this.navQuestions.Name = "navQuestions";
            this.navQuestions.PositionItem = this.bindingNavigatorPositionItem;
            this.navQuestions.Size = new System.Drawing.Size(1653, 25);
            this.navQuestions.TabIndex = 34;
            this.navQuestions.Text = "bindingNavigator1";
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
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
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
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(58, 23);
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
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(10, 193);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.lstQuestionList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.panelQuestion);
            this.splitContainer1.Size = new System.Drawing.Size(1500, 685);
            this.splitContainer1.SplitterDistance = 543;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 37;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // lstQuestionList
            // 
            this.lstQuestionList.AllowDrop = true;
            this.lstQuestionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NewQnum,
            this.Qnum,
            this.AltQnum,
            this.VarName,
            this.VarLabel,
            this.RespName,
            this.Corrected,
            this.QType});
            this.lstQuestionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstQuestionList.FullRowSelect = true;
            this.lstQuestionList.HideSelection = false;
            this.lstQuestionList.Location = new System.Drawing.Point(0, 0);
            this.lstQuestionList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstQuestionList.Name = "lstQuestionList";
            this.lstQuestionList.Size = new System.Drawing.Size(539, 681);
            this.lstQuestionList.TabIndex = 36;
            this.lstQuestionList.UseCompatibleStateImageBehavior = false;
            this.lstQuestionList.View = System.Windows.Forms.View.Details;
            this.lstQuestionList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lstQuestionList_ItemDrag);
            this.lstQuestionList.SelectedIndexChanged += new System.EventHandler(this.lstQuestionList_SelectedIndexChanged);
            this.lstQuestionList.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstQuestionList_DragDrop);
            this.lstQuestionList.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstQuestionList_DragEnter);
            this.lstQuestionList.DragOver += new System.Windows.Forms.DragEventHandler(this.lstQuestionList_DragOver);
            this.lstQuestionList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstQuestionList_MouseDoubleClick);
            // 
            // NewQnum
            // 
            this.NewQnum.Text = "New Q#";
            // 
            // Qnum
            // 
            this.Qnum.Text = "Q#";
            this.Qnum.Width = 52;
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
            // Corrected
            // 
            this.Corrected.Text = "Corr";
            this.Corrected.Width = 40;
            // 
            // QType
            // 
            this.QType.Text = "Question Type";
            this.QType.Width = 0;
            // 
            // panelQuestion
            // 
            this.panelQuestion.AutoScroll = true;
            this.panelQuestion.Controls.Add(this.lstImages);
            this.panelQuestion.Controls.Add(this.cmdDeleteImage);
            this.panelQuestion.Controls.Add(this.cmdAddImage);
            this.panelQuestion.Controls.Add(this.txtPstP);
            this.panelQuestion.Controls.Add(this.txtPstI);
            this.panelQuestion.Controls.Add(this.txtNR);
            this.panelQuestion.Controls.Add(this.txtRO);
            this.panelQuestion.Controls.Add(this.txtLitQ);
            this.panelQuestion.Controls.Add(this.txtPreA);
            this.panelQuestion.Controls.Add(this.txtPreI);
            this.panelQuestion.Controls.Add(this.txtPreP);
            this.panelQuestion.Controls.Add(this.rtbPlainFilter);
            this.panelQuestion.Controls.Add(this.dgvTimeFrames);
            this.panelQuestion.Controls.Add(this.cmdOpenPstP);
            this.panelQuestion.Controls.Add(this.cmdOpenPstI);
            this.panelQuestion.Controls.Add(this.cmdOpenNonResp);
            this.panelQuestion.Controls.Add(this.cmdOpenResp);
            this.panelQuestion.Controls.Add(this.cmdOpenLitQ);
            this.panelQuestion.Controls.Add(this.cmdOpenPreA);
            this.panelQuestion.Controls.Add(this.cmdOpenPreI);
            this.panelQuestion.Controls.Add(this.cmdOpenPreP);
            this.panelQuestion.Controls.Add(this.panelRelated);
            this.panelQuestion.Controls.Add(this.panelQnum);
            this.panelQuestion.Controls.Add(this.panelLabels);
            this.panelQuestion.Controls.Add(this.rtbQuestionText);
            this.panelQuestion.Controls.Add(this.txtVarName);
            this.panelQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelQuestion.Location = new System.Drawing.Point(0, 0);
            this.panelQuestion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelQuestion.Name = "panelQuestion";
            this.panelQuestion.Size = new System.Drawing.Size(948, 681);
            this.panelQuestion.TabIndex = 34;
            // 
            // lstImages
            // 
            this.lstImages.FormattingEnabled = true;
            this.lstImages.ItemHeight = 16;
            this.lstImages.Location = new System.Drawing.Point(641, 517);
            this.lstImages.Name = "lstImages";
            this.lstImages.Size = new System.Drawing.Size(269, 132);
            this.lstImages.TabIndex = 93;
            // 
            // cmdDeleteImage
            // 
            this.cmdDeleteImage.Location = new System.Drawing.Point(912, 541);
            this.cmdDeleteImage.Name = "cmdDeleteImage";
            this.cmdDeleteImage.Size = new System.Drawing.Size(26, 24);
            this.cmdDeleteImage.TabIndex = 92;
            this.cmdDeleteImage.Text = "X";
            this.cmdDeleteImage.UseVisualStyleBackColor = true;
            this.cmdDeleteImage.Click += new System.EventHandler(this.cmdDeleteImage_Click);
            // 
            // cmdAddImage
            // 
            this.cmdAddImage.Location = new System.Drawing.Point(912, 517);
            this.cmdAddImage.Name = "cmdAddImage";
            this.cmdAddImage.Size = new System.Drawing.Size(26, 24);
            this.cmdAddImage.TabIndex = 91;
            this.cmdAddImage.Text = "+";
            this.cmdAddImage.UseVisualStyleBackColor = true;
            this.cmdAddImage.Click += new System.EventHandler(this.cmdAddImage_Click);
            // 
            // txtPstP
            // 
            this.txtPstP.Location = new System.Drawing.Point(89, 293);
            this.txtPstP.Name = "txtPstP";
            this.txtPstP.Size = new System.Drawing.Size(74, 23);
            this.txtPstP.TabIndex = 90;
            this.txtPstP.Validating += new System.ComponentModel.CancelEventHandler(this.WordID_Validating);
            // 
            // txtPstI
            // 
            this.txtPstI.Location = new System.Drawing.Point(89, 258);
            this.txtPstI.Name = "txtPstI";
            this.txtPstI.Size = new System.Drawing.Size(74, 23);
            this.txtPstI.TabIndex = 89;
            this.txtPstI.Validating += new System.ComponentModel.CancelEventHandler(this.WordID_Validating);
            // 
            // txtNR
            // 
            this.txtNR.Location = new System.Drawing.Point(89, 224);
            this.txtNR.Name = "txtNR";
            this.txtNR.Size = new System.Drawing.Size(74, 23);
            this.txtNR.TabIndex = 88;
            this.txtNR.Validating += new System.ComponentModel.CancelEventHandler(this.RespSetName_Validating);
            // 
            // txtRO
            // 
            this.txtRO.Location = new System.Drawing.Point(89, 192);
            this.txtRO.Name = "txtRO";
            this.txtRO.Size = new System.Drawing.Size(74, 23);
            this.txtRO.TabIndex = 87;
            this.txtRO.Validating += new System.ComponentModel.CancelEventHandler(this.RespSetName_Validating);
            // 
            // txtLitQ
            // 
            this.txtLitQ.Location = new System.Drawing.Point(89, 158);
            this.txtLitQ.Name = "txtLitQ";
            this.txtLitQ.Size = new System.Drawing.Size(74, 23);
            this.txtLitQ.TabIndex = 86;
            this.txtLitQ.Validating += new System.ComponentModel.CancelEventHandler(this.WordID_Validating);
            // 
            // txtPreA
            // 
            this.txtPreA.Location = new System.Drawing.Point(89, 124);
            this.txtPreA.Name = "txtPreA";
            this.txtPreA.Size = new System.Drawing.Size(74, 23);
            this.txtPreA.TabIndex = 85;
            this.txtPreA.Validating += new System.ComponentModel.CancelEventHandler(this.WordID_Validating);
            // 
            // txtPreI
            // 
            this.txtPreI.Location = new System.Drawing.Point(89, 90);
            this.txtPreI.Name = "txtPreI";
            this.txtPreI.Size = new System.Drawing.Size(74, 23);
            this.txtPreI.TabIndex = 84;
            this.txtPreI.Validating += new System.ComponentModel.CancelEventHandler(this.WordID_Validating);
            // 
            // txtPreP
            // 
            this.txtPreP.Location = new System.Drawing.Point(89, 56);
            this.txtPreP.Name = "txtPreP";
            this.txtPreP.Size = new System.Drawing.Size(74, 23);
            this.txtPreP.TabIndex = 83;
            this.txtPreP.Validating += new System.ComponentModel.CancelEventHandler(this.WordID_Validating);
            // 
            // rtbPlainFilter
            // 
            this.rtbPlainFilter.AutoScroll = true;
            this.rtbPlainFilter.Location = new System.Drawing.Point(638, 54);
            this.rtbPlainFilter.Margin = new System.Windows.Forms.Padding(4);
            this.rtbPlainFilter.Name = "rtbPlainFilter";
            this.rtbPlainFilter.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 " +
    "Tahoma;}}\r\n{\\*\\generator Riched20 10.0.19041}\\viewkind4\\uc1 \r\n\\pard\\f0\\fs20\\par\r" +
    "\n}\r\n";
            this.rtbPlainFilter.ShowFamilies = false;
            this.rtbPlainFilter.ShowHighlight = false;
            this.rtbPlainFilter.ShowSize = false;
            this.rtbPlainFilter.ShowStrike = false;
            this.rtbPlainFilter.Size = new System.Drawing.Size(300, 459);
            this.rtbPlainFilter.TabIndex = 72;
            this.rtbPlainFilter.Validated += new System.EventHandler(this.rtbPlainFilter_Validated);
            // 
            // dgvTimeFrames
            // 
            this.dgvTimeFrames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeFrames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chTimeFrame});
            this.dgvTimeFrames.Location = new System.Drawing.Point(3, 517);
            this.dgvTimeFrames.Name = "dgvTimeFrames";
            this.dgvTimeFrames.RowHeadersWidth = 30;
            this.dgvTimeFrames.Size = new System.Drawing.Size(160, 140);
            this.dgvTimeFrames.TabIndex = 70;
            this.dgvTimeFrames.VirtualMode = true;
            this.dgvTimeFrames.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.dgvTimeFrames_CancelRowEdit);
            this.dgvTimeFrames.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvTimeFrames_CellValueNeeded);
            this.dgvTimeFrames.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvTimeFrames_CellValuePushed);
            this.dgvTimeFrames.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvTimeFrames_DataError);
            this.dgvTimeFrames.NewRowNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvTimeFrames_NewRowNeeded);
            this.dgvTimeFrames.RowDirtyStateNeeded += new System.Windows.Forms.QuestionEventHandler(this.dgvTimeFrames_RowDirtyStateNeeded);
            this.dgvTimeFrames.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimeFrames_RowValidated);
            this.dgvTimeFrames.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvTimeFrames_UserDeletingRow);
            // 
            // chTimeFrame
            // 
            this.chTimeFrame.HeaderText = "Time Frames";
            this.chTimeFrame.Name = "chTimeFrame";
            this.chTimeFrame.Width = 110;
            // 
            // cmdOpenPstP
            // 
            this.cmdOpenPstP.BackColor = System.Drawing.Color.Black;
            this.cmdOpenPstP.FlatAppearance.BorderSize = 0;
            this.cmdOpenPstP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpenPstP.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenPstP.ForeColor = System.Drawing.Color.White;
            this.cmdOpenPstP.Location = new System.Drawing.Point(3, 290);
            this.cmdOpenPstP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOpenPstP.Name = "cmdOpenPstP";
            this.cmdOpenPstP.Size = new System.Drawing.Size(83, 28);
            this.cmdOpenPstP.TabIndex = 60;
            this.cmdOpenPstP.Text = "PstP";
            this.cmdOpenPstP.UseVisualStyleBackColor = false;
            this.cmdOpenPstP.Click += new System.EventHandler(this.cmdOpenPstP_Click);
            // 
            // cmdOpenPstI
            // 
            this.cmdOpenPstI.BackColor = System.Drawing.Color.Black;
            this.cmdOpenPstI.FlatAppearance.BorderSize = 0;
            this.cmdOpenPstI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpenPstI.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenPstI.ForeColor = System.Drawing.Color.White;
            this.cmdOpenPstI.Location = new System.Drawing.Point(3, 255);
            this.cmdOpenPstI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOpenPstI.Name = "cmdOpenPstI";
            this.cmdOpenPstI.Size = new System.Drawing.Size(83, 28);
            this.cmdOpenPstI.TabIndex = 59;
            this.cmdOpenPstI.Text = "PstI";
            this.cmdOpenPstI.UseVisualStyleBackColor = false;
            this.cmdOpenPstI.Click += new System.EventHandler(this.cmdOpenPstI_Click);
            // 
            // cmdOpenNonResp
            // 
            this.cmdOpenNonResp.BackColor = System.Drawing.Color.Black;
            this.cmdOpenNonResp.FlatAppearance.BorderSize = 0;
            this.cmdOpenNonResp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpenNonResp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenNonResp.ForeColor = System.Drawing.Color.White;
            this.cmdOpenNonResp.Location = new System.Drawing.Point(3, 223);
            this.cmdOpenNonResp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOpenNonResp.Name = "cmdOpenNonResp";
            this.cmdOpenNonResp.Size = new System.Drawing.Size(83, 25);
            this.cmdOpenNonResp.TabIndex = 58;
            this.cmdOpenNonResp.Text = "NRs";
            this.cmdOpenNonResp.UseVisualStyleBackColor = false;
            this.cmdOpenNonResp.Click += new System.EventHandler(this.cmdOpenNonResp_Click);
            // 
            // cmdOpenResp
            // 
            this.cmdOpenResp.BackColor = System.Drawing.Color.Black;
            this.cmdOpenResp.FlatAppearance.BorderSize = 0;
            this.cmdOpenResp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpenResp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenResp.ForeColor = System.Drawing.Color.White;
            this.cmdOpenResp.Location = new System.Drawing.Point(3, 190);
            this.cmdOpenResp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOpenResp.Name = "cmdOpenResp";
            this.cmdOpenResp.Size = new System.Drawing.Size(83, 26);
            this.cmdOpenResp.TabIndex = 57;
            this.cmdOpenResp.Text = "ROs";
            this.cmdOpenResp.UseVisualStyleBackColor = false;
            this.cmdOpenResp.Click += new System.EventHandler(this.cmdOpenResp_Click);
            // 
            // cmdOpenLitQ
            // 
            this.cmdOpenLitQ.BackColor = System.Drawing.Color.DodgerBlue;
            this.cmdOpenLitQ.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdOpenLitQ.FlatAppearance.BorderSize = 0;
            this.cmdOpenLitQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpenLitQ.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenLitQ.ForeColor = System.Drawing.Color.White;
            this.cmdOpenLitQ.Location = new System.Drawing.Point(3, 156);
            this.cmdOpenLitQ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOpenLitQ.Name = "cmdOpenLitQ";
            this.cmdOpenLitQ.Size = new System.Drawing.Size(83, 26);
            this.cmdOpenLitQ.TabIndex = 36;
            this.cmdOpenLitQ.Text = "LitQ";
            this.cmdOpenLitQ.UseVisualStyleBackColor = false;
            this.cmdOpenLitQ.Click += new System.EventHandler(this.cmdOpenLitQ_Click);
            // 
            // cmdOpenPreA
            // 
            this.cmdOpenPreA.BackColor = System.Drawing.Color.Black;
            this.cmdOpenPreA.FlatAppearance.BorderSize = 0;
            this.cmdOpenPreA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpenPreA.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenPreA.ForeColor = System.Drawing.Color.White;
            this.cmdOpenPreA.Location = new System.Drawing.Point(3, 121);
            this.cmdOpenPreA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOpenPreA.Name = "cmdOpenPreA";
            this.cmdOpenPreA.Size = new System.Drawing.Size(83, 28);
            this.cmdOpenPreA.TabIndex = 35;
            this.cmdOpenPreA.Text = "PreA";
            this.cmdOpenPreA.UseVisualStyleBackColor = false;
            this.cmdOpenPreA.Click += new System.EventHandler(this.cmdOpenPreA_Click);
            // 
            // cmdOpenPreI
            // 
            this.cmdOpenPreI.BackColor = System.Drawing.Color.Black;
            this.cmdOpenPreI.FlatAppearance.BorderSize = 0;
            this.cmdOpenPreI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpenPreI.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenPreI.ForeColor = System.Drawing.Color.White;
            this.cmdOpenPreI.Location = new System.Drawing.Point(3, 89);
            this.cmdOpenPreI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOpenPreI.Name = "cmdOpenPreI";
            this.cmdOpenPreI.Size = new System.Drawing.Size(83, 25);
            this.cmdOpenPreI.TabIndex = 34;
            this.cmdOpenPreI.Text = "PreI";
            this.cmdOpenPreI.UseVisualStyleBackColor = false;
            this.cmdOpenPreI.Click += new System.EventHandler(this.cmdOpenPreI_Click);
            // 
            // cmdOpenPreP
            // 
            this.cmdOpenPreP.BackColor = System.Drawing.Color.Black;
            this.cmdOpenPreP.FlatAppearance.BorderSize = 0;
            this.cmdOpenPreP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpenPreP.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenPreP.ForeColor = System.Drawing.Color.White;
            this.cmdOpenPreP.Location = new System.Drawing.Point(3, 53);
            this.cmdOpenPreP.Margin = new System.Windows.Forms.Padding(0);
            this.cmdOpenPreP.Name = "cmdOpenPreP";
            this.cmdOpenPreP.Size = new System.Drawing.Size(83, 28);
            this.cmdOpenPreP.TabIndex = 33;
            this.cmdOpenPreP.Text = "PreP";
            this.cmdOpenPreP.UseVisualStyleBackColor = false;
            this.cmdOpenPreP.Click += new System.EventHandler(this.cmdOpenPreP_Click);
            // 
            // panelRelated
            // 
            this.panelRelated.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelRelated.Controls.Add(this.lblTranslationCount);
            this.panelRelated.Controls.Add(this.lblCommentCount);
            this.panelRelated.Controls.Add(this.lblCorrectCount);
            this.panelRelated.Location = new System.Drawing.Point(3, 325);
            this.panelRelated.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelRelated.Name = "panelRelated";
            this.panelRelated.Size = new System.Drawing.Size(160, 73);
            this.panelRelated.TabIndex = 32;
            // 
            // lblTranslationCount
            // 
            this.lblTranslationCount.AutoSize = true;
            this.lblTranslationCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTranslationCount.Location = new System.Drawing.Point(6, 27);
            this.lblTranslationCount.Name = "lblTranslationCount";
            this.lblTranslationCount.Size = new System.Drawing.Size(84, 13);
            this.lblTranslationCount.TabIndex = 11;
            this.lblTranslationCount.Text = "0 translation(s).";
            // 
            // lblCommentCount
            // 
            this.lblCommentCount.AutoSize = true;
            this.lblCommentCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentCount.Location = new System.Drawing.Point(6, 6);
            this.lblCommentCount.Name = "lblCommentCount";
            this.lblCommentCount.Size = new System.Drawing.Size(78, 13);
            this.lblCommentCount.TabIndex = 10;
            this.lblCommentCount.Text = "0 Comment(s).";
            // 
            // lblCorrectCount
            // 
            this.lblCorrectCount.AutoSize = true;
            this.lblCorrectCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorrectCount.Location = new System.Drawing.Point(6, 50);
            this.lblCorrectCount.Name = "lblCorrectCount";
            this.lblCorrectCount.Size = new System.Drawing.Size(114, 13);
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
            this.panelQnum.Location = new System.Drawing.Point(3, 402);
            this.panelQnum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelQnum.Name = "panelQnum";
            this.panelQnum.Size = new System.Drawing.Size(160, 111);
            this.panelQnum.TabIndex = 29;
            // 
            // lblAltQnum3
            // 
            this.lblAltQnum3.AutoSize = true;
            this.lblAltQnum3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltQnum3.Location = new System.Drawing.Point(3, 83);
            this.lblAltQnum3.Name = "lblAltQnum3";
            this.lblAltQnum3.Size = new System.Drawing.Size(54, 13);
            this.lblAltQnum3.TabIndex = 19;
            this.lblAltQnum3.Text = "AltQnum3";
            // 
            // lblAltQnum2
            // 
            this.lblAltQnum2.AutoSize = true;
            this.lblAltQnum2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltQnum2.Location = new System.Drawing.Point(5, 58);
            this.lblAltQnum2.Name = "lblAltQnum2";
            this.lblAltQnum2.Size = new System.Drawing.Size(54, 13);
            this.lblAltQnum2.TabIndex = 18;
            this.lblAltQnum2.Text = "AltQnum2";
            // 
            // lblQnum
            // 
            this.lblQnum.AutoSize = true;
            this.lblQnum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQnum.Location = new System.Drawing.Point(38, 11);
            this.lblQnum.Name = "lblQnum";
            this.lblQnum.Size = new System.Drawing.Size(23, 13);
            this.lblQnum.TabIndex = 16;
            this.lblQnum.Text = "Q#";
            // 
            // lblAltQnum
            // 
            this.lblAltQnum.AutoSize = true;
            this.lblAltQnum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltQnum.Location = new System.Drawing.Point(12, 35);
            this.lblAltQnum.Name = "lblAltQnum";
            this.lblAltQnum.Size = new System.Drawing.Size(48, 13);
            this.lblAltQnum.TabIndex = 17;
            this.lblAltQnum.Text = "AltQnum";
            // 
            // txtAltQnum3
            // 
            this.txtAltQnum3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAltQnum3.Location = new System.Drawing.Point(73, 79);
            this.txtAltQnum3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAltQnum3.Name = "txtAltQnum3";
            this.txtAltQnum3.Size = new System.Drawing.Size(59, 21);
            this.txtAltQnum3.TabIndex = 6;
            // 
            // txtAltQnum2
            // 
            this.txtAltQnum2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAltQnum2.Location = new System.Drawing.Point(73, 55);
            this.txtAltQnum2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAltQnum2.Name = "txtAltQnum2";
            this.txtAltQnum2.Size = new System.Drawing.Size(59, 21);
            this.txtAltQnum2.TabIndex = 5;
            // 
            // txtAltQnum
            // 
            this.txtAltQnum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAltQnum.Location = new System.Drawing.Point(73, 31);
            this.txtAltQnum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAltQnum.Name = "txtAltQnum";
            this.txtAltQnum.Size = new System.Drawing.Size(59, 21);
            this.txtAltQnum.TabIndex = 4;
            // 
            // txtQnum
            // 
            this.txtQnum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQnum.Location = new System.Drawing.Point(73, 7);
            this.txtQnum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQnum.Name = "txtQnum";
            this.txtQnum.ReadOnly = true;
            this.txtQnum.Size = new System.Drawing.Size(59, 21);
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
            this.panelLabels.Location = new System.Drawing.Point(168, 517);
            this.panelLabels.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelLabels.Name = "panelLabels";
            this.panelLabels.Size = new System.Drawing.Size(467, 140);
            this.panelLabels.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "Product";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Content";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(33, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Topic";
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomain.Location = new System.Drawing.Point(19, 33);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(50, 16);
            this.lblDomain.TabIndex = 6;
            this.lblDomain.Text = "Domain";
            // 
            // lblVarLabel
            // 
            this.lblVarLabel.AutoSize = true;
            this.lblVarLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVarLabel.Location = new System.Drawing.Point(10, 7);
            this.lblVarLabel.Name = "lblVarLabel";
            this.lblVarLabel.Size = new System.Drawing.Size(57, 16);
            this.lblVarLabel.TabIndex = 5;
            this.lblVarLabel.Text = "VarLabel";
            // 
            // cboProductLabel
            // 
            this.cboProductLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductLabel.FormattingEnabled = true;
            this.cboProductLabel.Location = new System.Drawing.Point(84, 106);
            this.cboProductLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboProductLabel.Name = "cboProductLabel";
            this.cboProductLabel.Size = new System.Drawing.Size(375, 24);
            this.cboProductLabel.TabIndex = 4;
            this.cboProductLabel.Validating += new System.ComponentModel.CancelEventHandler(this.ComboBox_Validating);
            // 
            // cboContentLabel
            // 
            this.cboContentLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboContentLabel.FormattingEnabled = true;
            this.cboContentLabel.Location = new System.Drawing.Point(84, 80);
            this.cboContentLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboContentLabel.Name = "cboContentLabel";
            this.cboContentLabel.Size = new System.Drawing.Size(375, 24);
            this.cboContentLabel.TabIndex = 3;
            this.cboContentLabel.Validating += new System.ComponentModel.CancelEventHandler(this.ComboBox_Validating);
            // 
            // cboTopicLabel
            // 
            this.cboTopicLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTopicLabel.FormattingEnabled = true;
            this.cboTopicLabel.Location = new System.Drawing.Point(84, 54);
            this.cboTopicLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTopicLabel.Name = "cboTopicLabel";
            this.cboTopicLabel.Size = new System.Drawing.Size(375, 24);
            this.cboTopicLabel.TabIndex = 2;
            this.cboTopicLabel.Validating += new System.ComponentModel.CancelEventHandler(this.ComboBox_Validating);
            // 
            // cboDomainLabel
            // 
            this.cboDomainLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDomainLabel.FormattingEnabled = true;
            this.cboDomainLabel.Location = new System.Drawing.Point(84, 29);
            this.cboDomainLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDomainLabel.Name = "cboDomainLabel";
            this.cboDomainLabel.Size = new System.Drawing.Size(375, 24);
            this.cboDomainLabel.TabIndex = 1;
            this.cboDomainLabel.Validating += new System.ComponentModel.CancelEventHandler(this.ComboBox_Validating);
            // 
            // txtVarLabel
            // 
            this.txtVarLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVarLabel.Location = new System.Drawing.Point(84, 4);
            this.txtVarLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVarLabel.Name = "txtVarLabel";
            this.txtVarLabel.Size = new System.Drawing.Size(375, 23);
            this.txtVarLabel.TabIndex = 0;
            // 
            // rtbQuestionText
            // 
            this.rtbQuestionText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbQuestionText.Location = new System.Drawing.Point(169, 53);
            this.rtbQuestionText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbQuestionText.Name = "rtbQuestionText";
            this.rtbQuestionText.ReadOnly = true;
            this.rtbQuestionText.Size = new System.Drawing.Size(467, 460);
            this.rtbQuestionText.TabIndex = 25;
            this.rtbQuestionText.Text = "";
            // 
            // txtVarName
            // 
            this.txtVarName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVarName.Location = new System.Drawing.Point(169, 21);
            this.txtVarName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVarName.Name = "txtVarName";
            this.txtVarName.Size = new System.Drawing.Size(467, 23);
            this.txtVarName.TabIndex = 23;
            this.txtVarName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(482, 102);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(173, 33);
            this.lblTitle.TabIndex = 38;
            this.lblTitle.Text = "Survey Editor";
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem1,
            this.questionsToolStripMenuItem,
            this.goToToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuMain.Size = new System.Drawing.Size(1653, 24);
            this.menuMain.TabIndex = 41;
            this.menuMain.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem1.Text = "Close";
            this.closeToolStripMenuItem1.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // questionsToolStripMenuItem
            // 
            this.questionsToolStripMenuItem.Checked = true;
            this.questionsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.questionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToolStripMenuItem});
            this.questionsToolStripMenuItem.Name = "questionsToolStripMenuItem";
            this.questionsToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.questionsToolStripMenuItem.Text = "Questions";
            this.questionsToolStripMenuItem.Visible = false;
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.moveToolStripMenuItem.Text = "Move...";
            // 
            // goToToolStripMenuItem
            // 
            this.goToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assignLabelsToolStripMenuItem,
            this.harmonyToolStripMenuItem,
            this.prefixListToolStripMenuItem,
            this.unusedVarsToolStripMenuItem,
            this.renameVarToolStripMenuItem});
            this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
            this.goToToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.goToToolStripMenuItem.Text = "Go To";
            // 
            // assignLabelsToolStripMenuItem
            // 
            this.assignLabelsToolStripMenuItem.Name = "assignLabelsToolStripMenuItem";
            this.assignLabelsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.assignLabelsToolStripMenuItem.Text = "Labels";
            this.assignLabelsToolStripMenuItem.Click += new System.EventHandler(this.assignLabelsToolStripMenuItem_Click);
            // 
            // harmonyToolStripMenuItem
            // 
            this.harmonyToolStripMenuItem.Name = "harmonyToolStripMenuItem";
            this.harmonyToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.harmonyToolStripMenuItem.Text = "Harmony";
            this.harmonyToolStripMenuItem.Click += new System.EventHandler(this.harmonyToolStripMenuItem_Click);
            // 
            // prefixListToolStripMenuItem
            // 
            this.prefixListToolStripMenuItem.Name = "prefixListToolStripMenuItem";
            this.prefixListToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.prefixListToolStripMenuItem.Text = "Prefix List";
            this.prefixListToolStripMenuItem.Click += new System.EventHandler(this.prefixListToolStripMenuItem_Click);
            // 
            // unusedVarsToolStripMenuItem
            // 
            this.unusedVarsToolStripMenuItem.Name = "unusedVarsToolStripMenuItem";
            this.unusedVarsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.unusedVarsToolStripMenuItem.Text = "Unused Vars";
            this.unusedVarsToolStripMenuItem.Click += new System.EventHandler(this.unusedVarsToolStripMenuItem_Click);
            // 
            // renameVarToolStripMenuItem
            // 
            this.renameVarToolStripMenuItem.Name = "renameVarToolStripMenuItem";
            this.renameVarToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.renameVarToolStripMenuItem.Text = "Rename Var";
            this.renameVarToolStripMenuItem.Visible = false;
            this.renameVarToolStripMenuItem.Click += new System.EventHandler(this.renameVarToolStripMenuItem_Click);
            // 
            // cboSurvey
            // 
            this.cboSurvey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboSurvey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSurvey.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSurvey.FormattingEnabled = true;
            this.cboSurvey.Location = new System.Drawing.Point(435, 156);
            this.cboSurvey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSurvey.Name = "cboSurvey";
            this.cboSurvey.Size = new System.Drawing.Size(119, 24);
            this.cboSurvey.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(373, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 43;
            this.label1.Text = "Survey";
            // 
            // toolStripExport
            // 
            this.toolStripExport.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDisplayBtn,
            this.toolStripExportBtn,
            this.toolStripSeparator1,
            this.toolStripQ,
            this.toolStripT,
            this.toolStripC,
            this.toolStripF});
            this.toolStripExport.Location = new System.Drawing.Point(0, 74);
            this.toolStripExport.Name = "toolStripExport";
            this.toolStripExport.Size = new System.Drawing.Size(204, 25);
            this.toolStripExport.TabIndex = 44;
            this.toolStripExport.Text = "toolStrip1";
            // 
            // toolStripDisplayBtn
            // 
            this.toolStripDisplayBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDisplayBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDisplayBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDisplayBtn.Image")));
            this.toolStripDisplayBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDisplayBtn.Name = "toolStripDisplayBtn";
            this.toolStripDisplayBtn.Size = new System.Drawing.Size(47, 22);
            this.toolStripDisplayBtn.Text = "Display";
            this.toolStripDisplayBtn.Click += new System.EventHandler(this.toolStripDisplay_Click);
            // 
            // toolStripExportBtn
            // 
            this.toolStripExportBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripExportBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripExportBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripExportBtn.Image")));
            this.toolStripExportBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExportBtn.Name = "toolStripExportBtn";
            this.toolStripExportBtn.Size = new System.Drawing.Size(47, 22);
            this.toolStripExportBtn.Text = "Export";
            this.toolStripExportBtn.Click += new System.EventHandler(this.toolStripExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripQ
            // 
            this.toolStripQ.Checked = true;
            this.toolStripQ.CheckOnClick = true;
            this.toolStripQ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripQ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripQ.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripQ.Image = ((System.Drawing.Image)(resources.GetObject("toolStripQ.Image")));
            this.toolStripQ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripQ.Name = "toolStripQ";
            this.toolStripQ.Size = new System.Drawing.Size(23, 22);
            this.toolStripQ.Text = "Q";
            // 
            // toolStripT
            // 
            this.toolStripT.CheckOnClick = true;
            this.toolStripT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripT.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripT.Image = ((System.Drawing.Image)(resources.GetObject("toolStripT.Image")));
            this.toolStripT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripT.Name = "toolStripT";
            this.toolStripT.Size = new System.Drawing.Size(23, 22);
            this.toolStripT.Text = "T";
            // 
            // toolStripC
            // 
            this.toolStripC.CheckOnClick = true;
            this.toolStripC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripC.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripC.Image = ((System.Drawing.Image)(resources.GetObject("toolStripC.Image")));
            this.toolStripC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripC.Name = "toolStripC";
            this.toolStripC.Size = new System.Drawing.Size(23, 22);
            this.toolStripC.Text = "C";
            // 
            // toolStripF
            // 
            this.toolStripF.CheckOnClick = true;
            this.toolStripF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripF.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripF.Image = ((System.Drawing.Image)(resources.GetObject("toolStripF.Image")));
            this.toolStripF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripF.Name = "toolStripF";
            this.toolStripF.Size = new System.Drawing.Size(23, 22);
            this.toolStripF.Text = "F";
            // 
            // toolStripRelatedData
            // 
            this.toolStripRelatedData.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripRelatedData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAddTranslation,
            this.toolStripTranslation,
            this.toolStripLanguage,
            this.toolStripViewComments,
            this.toolStripDeleted,
            this.toolStripCorrected,
            this.toolStripRelated});
            this.toolStripRelatedData.Location = new System.Drawing.Point(0, 49);
            this.toolStripRelatedData.Name = "toolStripRelatedData";
            this.toolStripRelatedData.Size = new System.Drawing.Size(573, 25);
            this.toolStripRelatedData.TabIndex = 45;
            this.toolStripRelatedData.Text = "toolStrip2";
            // 
            // toolStripAddTranslation
            // 
            this.toolStripAddTranslation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripAddTranslation.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAddTranslation.Image")));
            this.toolStripAddTranslation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAddTranslation.Name = "toolStripAddTranslation";
            this.toolStripAddTranslation.Size = new System.Drawing.Size(23, 22);
            this.toolStripAddTranslation.Text = "Add Translation";
            this.toolStripAddTranslation.Click += new System.EventHandler(this.toolStripAddTranslation_Click);
            // 
            // toolStripTranslation
            // 
            this.toolStripTranslation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripTranslation.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTranslation.Image = ((System.Drawing.Image)(resources.GetObject("toolStripTranslation.Image")));
            this.toolStripTranslation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTranslation.Name = "toolStripTranslation";
            this.toolStripTranslation.Size = new System.Drawing.Size(75, 22);
            this.toolStripTranslation.Text = "Translations";
            this.toolStripTranslation.Click += new System.EventHandler(this.toolStripTranslation_Click);
            // 
            // toolStripLanguage
            // 
            this.toolStripLanguage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLanguage.Name = "toolStripLanguage";
            this.toolStripLanguage.Size = new System.Drawing.Size(140, 25);
            this.toolStripLanguage.SelectedIndexChanged += new System.EventHandler(this.toolStripLanguage_SelectedIndexChanged);
            // 
            // toolStripViewComments
            // 
            this.toolStripViewComments.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripViewComments.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripViewComments.Image = ((System.Drawing.Image)(resources.GetObject("toolStripViewComments.Image")));
            this.toolStripViewComments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripViewComments.Name = "toolStripViewComments";
            this.toolStripViewComments.Size = new System.Drawing.Size(65, 22);
            this.toolStripViewComments.Text = "Var Notes";
            this.toolStripViewComments.Click += new System.EventHandler(this.toolStripViewComments_Click);
            // 
            // toolStripDeleted
            // 
            this.toolStripDeleted.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDeleted.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDeleted.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDeleted.Image")));
            this.toolStripDeleted.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDeleted.Name = "toolStripDeleted";
            this.toolStripDeleted.Size = new System.Drawing.Size(81, 22);
            this.toolStripDeleted.Text = "Deleted Vars";
            this.toolStripDeleted.Click += new System.EventHandler(this.toolStripDeleted_Click);
            // 
            // toolStripCorrected
            // 
            this.toolStripCorrected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripCorrected.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripCorrected.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCorrected.Image")));
            this.toolStripCorrected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCorrected.Name = "toolStripCorrected";
            this.toolStripCorrected.Size = new System.Drawing.Size(65, 22);
            this.toolStripCorrected.Text = "Corrected";
            this.toolStripCorrected.Click += new System.EventHandler(this.toolStripCorrected_Click);
            // 
            // toolStripRelated
            // 
            this.toolStripRelated.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripRelated.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripRelated.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRelated.Image")));
            this.toolStripRelated.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRelated.Name = "toolStripRelated";
            this.toolStripRelated.Size = new System.Drawing.Size(110, 22);
            this.toolStripRelated.Text = "Related Questions";
            this.toolStripRelated.Click += new System.EventHandler(this.toolStripRelated_Click);
            // 
            // toolStripFunctions
            // 
            this.toolStripFunctions.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripFunctions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAdd,
            this.toolStripDelete,
            this.toolStripCopyPrev});
            this.toolStripFunctions.Location = new System.Drawing.Point(0, 24);
            this.toolStripFunctions.Name = "toolStripFunctions";
            this.toolStripFunctions.Size = new System.Drawing.Size(182, 25);
            this.toolStripFunctions.TabIndex = 46;
            this.toolStripFunctions.Text = "toolStrip1";
            // 
            // toolStripAdd
            // 
            this.toolStripAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAdd.Image")));
            this.toolStripAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAdd.Name = "toolStripAdd";
            this.toolStripAdd.Size = new System.Drawing.Size(45, 22);
            this.toolStripAdd.Text = "Add...";
            this.toolStripAdd.ToolTipText = "Add Question";
            this.toolStripAdd.Click += new System.EventHandler(this.toolStripAdd_Click);
            // 
            // toolStripDelete
            // 
            this.toolStripDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDelete.Image")));
            this.toolStripDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDelete.Name = "toolStripDelete";
            this.toolStripDelete.Size = new System.Drawing.Size(59, 22);
            this.toolStripDelete.Text = "Delete...";
            this.toolStripDelete.ToolTipText = "Delete Question";
            this.toolStripDelete.Click += new System.EventHandler(this.toolStripDelete_Click);
            // 
            // toolStripCopyPrev
            // 
            this.toolStripCopyPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripCopyPrev.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripCopyPrev.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCopyPrev.Image")));
            this.toolStripCopyPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCopyPrev.Name = "toolStripCopyPrev";
            this.toolStripCopyPrev.Size = new System.Drawing.Size(66, 22);
            this.toolStripCopyPrev.Text = "Copy Prev";
            this.toolStripCopyPrev.Click += new System.EventHandler(this.toolStripCopyPrev_Click);
            // 
            // cmdUnlock
            // 
            this.cmdUnlock.Location = new System.Drawing.Point(926, 37);
            this.cmdUnlock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdUnlock.Name = "cmdUnlock";
            this.cmdUnlock.Size = new System.Drawing.Size(269, 28);
            this.cmdUnlock.TabIndex = 47;
            this.cmdUnlock.Text = "This survey is locked. Click here to unlock it.";
            this.cmdUnlock.UseVisualStyleBackColor = true;
            this.cmdUnlock.Click += new System.EventHandler(this.cmdUnlock_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(951, 69);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(203, 16);
            this.lblStatus.TabIndex = 48;
            this.lblStatus.Text = "This survey has unsaved changes:";
            // 
            // cmdSaveSurvey
            // 
            this.cmdSaveSurvey.Location = new System.Drawing.Point(1110, 157);
            this.cmdSaveSurvey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSaveSurvey.Name = "cmdSaveSurvey";
            this.cmdSaveSurvey.Size = new System.Drawing.Size(87, 28);
            this.cmdSaveSurvey.TabIndex = 49;
            this.cmdSaveSurvey.Text = "Save";
            this.cmdSaveSurvey.UseVisualStyleBackColor = true;
            this.cmdSaveSurvey.Click += new System.EventHandler(this.cmdSaveSurvey_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSearchQs});
            this.toolStrip1.Location = new System.Drawing.Point(182, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(75, 25);
            this.toolStrip1.TabIndex = 50;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSearchQs
            // 
            this.toolStripSearchQs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSearchQs.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSearchQs.Image")));
            this.toolStripSearchQs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSearchQs.Name = "toolStripSearchQs";
            this.toolStripSearchQs.Size = new System.Drawing.Size(63, 22);
            this.toolStripSearchQs.Text = "Search Qs";
            this.toolStripSearchQs.Click += new System.EventHandler(this.toolStripSearchQs_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(12, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 51;
            this.label2.Text = "New";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(51, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 52;
            this.label3.Text = "Deleted";
            // 
            // lblEdited
            // 
            this.lblEdited.AutoSize = true;
            this.lblEdited.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblEdited.Location = new System.Drawing.Point(108, 173);
            this.lblEdited.Name = "lblEdited";
            this.lblEdited.Size = new System.Drawing.Size(42, 16);
            this.lblEdited.TabIndex = 53;
            this.lblEdited.Text = "Edited";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Time Frames";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 110;
            // 
            // cboMoveTo
            // 
            this.cboMoveTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboMoveTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMoveTo.FormattingEnabled = true;
            this.cboMoveTo.Location = new System.Drawing.Point(242, 170);
            this.cboMoveTo.Name = "cboMoveTo";
            this.cboMoveTo.Size = new System.Drawing.Size(80, 24);
            this.cboMoveTo.TabIndex = 55;
            this.cboMoveTo.SelectionChangeCommitted += new System.EventHandler(this.cboMoveTo_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Move to:";
            // 
            // SurveyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(196)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(1653, 907);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboMoveTo);
            this.Controls.Add(this.lblEdited);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStripExport);
            this.Controls.Add(this.cmdSaveSurvey);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmdUnlock);
            this.Controls.Add(this.toolStripFunctions);
            this.Controls.Add(this.toolStripRelatedData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSurvey);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cboGoToVar);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.navQuestions);
            this.Controls.Add(this.menuMain);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuMain;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SurveyEditor";
            this.Text = "SurveyEditor";
            this.Activated += new System.EventHandler(this.SurveyEditor_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SurveyEditor_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SurveyEditor_FormClosed);
            this.Load += new System.EventHandler(this.SurveyEditor_Load);
            this.Enter += new System.EventHandler(this.SurveyEditor_Enter);
            this.Leave += new System.EventHandler(this.SurveyEditor_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.navQuestions)).EndInit();
            this.navQuestions.ResumeLayout(false);
            this.navQuestions.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelQuestion.ResumeLayout(false);
            this.panelQuestion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeFrames)).EndInit();
            this.panelRelated.ResumeLayout(false);
            this.panelRelated.PerformLayout();
            this.panelQnum.ResumeLayout(false);
            this.panelQnum.PerformLayout();
            this.panelLabels.ResumeLayout(false);
            this.panelLabels.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.toolStripExport.ResumeLayout(false);
            this.toolStripExport.PerformLayout();
            this.toolStripRelatedData.ResumeLayout(false);
            this.toolStripRelatedData.PerformLayout();
            this.toolStripFunctions.ResumeLayout(false);
            this.toolStripFunctions.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboGoToVar;
        private System.Windows.Forms.BindingNavigator navQuestions;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
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
        private System.Windows.Forms.RichTextBox rtbQuestionText;
        private System.Windows.Forms.TextBox txtVarName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem questionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboSurvey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdOpenPstP;
        private System.Windows.Forms.Button cmdOpenPstI;
        private System.Windows.Forms.Button cmdOpenNonResp;
        private System.Windows.Forms.Button cmdOpenResp;
        private System.Windows.Forms.Button cmdOpenLitQ;
        private System.Windows.Forms.Button cmdOpenPreA;
        private System.Windows.Forms.Button cmdOpenPreI;
        private System.Windows.Forms.Button cmdOpenPreP;
        private System.Windows.Forms.ToolStripMenuItem goToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignLabelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem harmonyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prefixListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unusedVarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameVarToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripExport;
        private System.Windows.Forms.ToolStripButton toolStripDisplayBtn;
        private System.Windows.Forms.ToolStripButton toolStripExportBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripQ;
        private System.Windows.Forms.ToolStripButton toolStripT;
        private System.Windows.Forms.ToolStripButton toolStripC;
        private System.Windows.Forms.ToolStripButton toolStripF;
        private System.Windows.Forms.ToolStrip toolStripRelatedData;
        private System.Windows.Forms.ToolStripButton toolStripTranslation;
        private System.Windows.Forms.ToolStripComboBox toolStripLanguage;
        private System.Windows.Forms.ToolStripButton toolStripViewComments;
        private System.Windows.Forms.ToolStripButton toolStripDeleted;
        private System.Windows.Forms.ToolStripButton toolStripCorrected;
        private System.Windows.Forms.ToolStripButton toolStripRelated;
        private System.Windows.Forms.ToolStrip toolStripFunctions;
        private System.Windows.Forms.ToolStripButton toolStripAdd;
        private System.Windows.Forms.ToolStripButton toolStripDelete;
        private System.Windows.Forms.ToolStripButton toolStripCopyPrev;
        private System.Windows.Forms.Button cmdUnlock;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ColumnHeader NewQnum;
        private System.Windows.Forms.Button cmdSaveSurvey;
        private System.Windows.Forms.ColumnHeader QType;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripSearchQs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEdited;
        private System.Windows.Forms.DataGridView dgvTimeFrames;
        private System.Windows.Forms.DataGridViewTextBoxColumn chTimeFrame;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private ExtraRichTextBox rtbPlainFilter;
        private System.Windows.Forms.ToolStripButton toolStripAddTranslation;
        private System.Windows.Forms.ComboBox cboMoveTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPstP;
        private System.Windows.Forms.TextBox txtPstI;
        private System.Windows.Forms.TextBox txtNR;
        private System.Windows.Forms.TextBox txtRO;
        private System.Windows.Forms.TextBox txtLitQ;
        private System.Windows.Forms.TextBox txtPreA;
        private System.Windows.Forms.TextBox txtPreI;
        private System.Windows.Forms.TextBox txtPreP;
        private System.Windows.Forms.Button cmdAddImage;
        private System.Windows.Forms.Button cmdDeleteImage;
        private System.Windows.Forms.ListBox lstImages;
    }
}