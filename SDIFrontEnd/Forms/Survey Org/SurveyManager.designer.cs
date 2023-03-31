namespace SDIFrontEnd
{
    partial class SurveyManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SurveyManager));
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtSurveyCode = new System.Windows.Forms.TextBox();
            this.txtSurveyTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboWaveID = new System.Windows.Forms.ComboBox();
            this.lblSurveyTitle = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSurveyType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboMode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpCreationDate = new System.Windows.Forms.DateTimePicker();
            this.chkNCT = new System.Windows.Forms.CheckBox();
            this.chkHideSurvey = new System.Windows.Forms.CheckBox();
            this.chkLocked = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
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
            this.dgvLanguages = new System.Windows.Forms.DataGridView();
            this.chLangID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chSurvIDLang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUserStates = new System.Windows.Forms.DataGridView();
            this.chUserStateID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chSurvIDState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvScreenedProducts = new System.Windows.Forms.DataGridView();
            this.chProductID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chSurvIDProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitle = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkITCSurvey = new System.Windows.Forms.CheckBox();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripGoTo = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbuttonWaves = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdAddWave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScreenedProducts)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(93, 77);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(32, 23);
            this.txtID.TabIndex = 0;
            // 
            // txtSurveyCode
            // 
            this.txtSurveyCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSurveyCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSurveyCode.Location = new System.Drawing.Point(93, 137);
            this.txtSurveyCode.Name = "txtSurveyCode";
            this.txtSurveyCode.Size = new System.Drawing.Size(146, 23);
            this.txtSurveyCode.TabIndex = 1;
            // 
            // txtSurveyTitle
            // 
            this.txtSurveyTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSurveyTitle.Location = new System.Drawing.Point(320, 137);
            this.txtSurveyTitle.Name = "txtSurveyTitle";
            this.txtSurveyTitle.Size = new System.Drawing.Size(227, 23);
            this.txtSurveyTitle.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Survey Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Wave";
            // 
            // cboWaveID
            // 
            this.cboWaveID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboWaveID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboWaveID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboWaveID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWaveID.FormattingEnabled = true;
            this.cboWaveID.Location = new System.Drawing.Point(93, 106);
            this.cboWaveID.Name = "cboWaveID";
            this.cboWaveID.Size = new System.Drawing.Size(147, 24);
            this.cboWaveID.TabIndex = 7;
            // 
            // lblSurveyTitle
            // 
            this.lblSurveyTitle.AutoSize = true;
            this.lblSurveyTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurveyTitle.Location = new System.Drawing.Point(283, 140);
            this.lblSurveyTitle.Name = "lblSurveyTitle";
            this.lblSurveyTitle.Size = new System.Drawing.Size(32, 16);
            this.lblSurveyTitle.TabIndex = 8;
            this.lblSurveyTitle.Text = "Title";
            // 
            // txtFileName
            // 
            this.txtFileName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(320, 166);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(227, 23);
            this.txtFileName.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(251, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "File Name";
            // 
            // cboSurveyType
            // 
            this.cboSurveyType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSurveyType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSurveyType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboSurveyType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSurveyType.FormattingEnabled = true;
            this.cboSurveyType.Location = new System.Drawing.Point(93, 166);
            this.cboSurveyType.Name = "cboSurveyType";
            this.cboSurveyType.Size = new System.Drawing.Size(147, 24);
            this.cboSurveyType.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Type";
            // 
            // cboMode
            // 
            this.cboMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboMode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMode.FormattingEnabled = true;
            this.cboMode.Location = new System.Drawing.Point(93, 196);
            this.cboMode.Name = "cboMode";
            this.cboMode.Size = new System.Drawing.Size(147, 24);
            this.cboMode.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(48, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Mode";
            // 
            // dtpCreationDate
            // 
            this.dtpCreationDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCreationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreationDate.Location = new System.Drawing.Point(93, 226);
            this.dtpCreationDate.Name = "dtpCreationDate";
            this.dtpCreationDate.ShowCheckBox = true;
            this.dtpCreationDate.Size = new System.Drawing.Size(147, 23);
            this.dtpCreationDate.TabIndex = 15;
            // 
            // chkNCT
            // 
            this.chkNCT.AutoSize = true;
            this.chkNCT.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNCT.Location = new System.Drawing.Point(320, 200);
            this.chkNCT.Name = "chkNCT";
            this.chkNCT.Size = new System.Drawing.Size(98, 20);
            this.chkNCT.TabIndex = 17;
            this.chkNCT.Text = "NCT Country";
            this.chkNCT.UseVisualStyleBackColor = true;
            // 
            // chkHideSurvey
            // 
            this.chkHideSurvey.AutoSize = true;
            this.chkHideSurvey.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHideSurvey.Location = new System.Drawing.Point(425, 200);
            this.chkHideSurvey.Name = "chkHideSurvey";
            this.chkHideSurvey.Size = new System.Drawing.Size(94, 20);
            this.chkHideSurvey.TabIndex = 18;
            this.chkHideSurvey.Text = "Hide Survey";
            this.chkHideSurvey.UseVisualStyleBackColor = true;
            // 
            // chkLocked
            // 
            this.chkLocked.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLocked.AutoSize = true;
            this.chkLocked.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLocked.Location = new System.Drawing.Point(320, 104);
            this.chkLocked.Name = "chkLocked";
            this.chkLocked.Size = new System.Drawing.Size(56, 26);
            this.chkLocked.TabIndex = 19;
            this.chkLocked.Text = "Locked";
            this.chkLocked.UseVisualStyleBackColor = true;
            this.chkLocked.Click += new System.EventHandler(this.chkLocked_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Created On";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(425, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "Languages";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(57, 273);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "User States";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(223, 271);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 16);
            this.label10.TabIndex = 25;
            this.label10.Text = "Screened Products";
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 505);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(563, 25);
            this.bindingNavigator1.TabIndex = 26;
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
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
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
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // dgvLanguages
            // 
            this.dgvLanguages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLanguages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chLangID,
            this.chSurvIDLang});
            this.dgvLanguages.Location = new System.Drawing.Point(376, 287);
            this.dgvLanguages.MultiSelect = false;
            this.dgvLanguages.Name = "dgvLanguages";
            this.dgvLanguages.Size = new System.Drawing.Size(171, 201);
            this.dgvLanguages.TabIndex = 27;
            this.dgvLanguages.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvLanguages_CellValidating);
            this.dgvLanguages.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvLanguages_DataError);
            this.dgvLanguages.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvLanguages_DefaultValuesNeeded);
            this.dgvLanguages.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLanguages_RowLeave);
            this.dgvLanguages.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLanguages_RowValidated);
            this.dgvLanguages.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvLanguages_UserAddedRow);
            this.dgvLanguages.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvLanguages_UserDeletingRow);
            // 
            // chLangID
            // 
            this.chLangID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chLangID.HeaderText = "Language";
            this.chLangID.Name = "chLangID";
            // 
            // chSurvIDLang
            // 
            this.chSurvIDLang.HeaderText = "Survey";
            this.chSurvIDLang.Name = "chSurvIDLang";
            this.chSurvIDLang.Visible = false;
            // 
            // dgvUserStates
            // 
            this.dgvUserStates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserStates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chUserStateID,
            this.chSurvIDState});
            this.dgvUserStates.Location = new System.Drawing.Point(10, 287);
            this.dgvUserStates.MultiSelect = false;
            this.dgvUserStates.Name = "dgvUserStates";
            this.dgvUserStates.Size = new System.Drawing.Size(171, 201);
            this.dgvUserStates.TabIndex = 28;
            this.dgvUserStates.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvUserStates_CellValidating);
            this.dgvUserStates.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvUserStates_DataError);
            this.dgvUserStates.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvUserStates_DefaultValuesNeeded);
            this.dgvUserStates.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserStates_RowLeave);
            this.dgvUserStates.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserStates_RowValidated);
            this.dgvUserStates.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvUserStates_UserAddedRow);
            this.dgvUserStates.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvUserStates_UserDeletingRow);
            // 
            // chUserStateID
            // 
            this.chUserStateID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chUserStateID.HeaderText = "User State";
            this.chUserStateID.Name = "chUserStateID";
            // 
            // chSurvIDState
            // 
            this.chSurvIDState.HeaderText = "Survey";
            this.chSurvIDState.Name = "chSurvIDState";
            this.chSurvIDState.Visible = false;
            // 
            // dgvScreenedProducts
            // 
            this.dgvScreenedProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScreenedProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chProductID,
            this.chSurvIDProduct});
            this.dgvScreenedProducts.Location = new System.Drawing.Point(193, 287);
            this.dgvScreenedProducts.MultiSelect = false;
            this.dgvScreenedProducts.Name = "dgvScreenedProducts";
            this.dgvScreenedProducts.Size = new System.Drawing.Size(171, 201);
            this.dgvScreenedProducts.TabIndex = 29;
            this.dgvScreenedProducts.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvScreenedProducts_CellValidating);
            this.dgvScreenedProducts.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvScreenedProducts_DataError);
            this.dgvScreenedProducts.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvScreenedProducts_DefaultValuesNeeded);
            this.dgvScreenedProducts.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScreenedProducts_RowLeave);
            this.dgvScreenedProducts.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScreenedProducts_RowValidated);
            this.dgvScreenedProducts.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvScreenedProducts_UserAddedRow);
            this.dgvScreenedProducts.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvScreenedProducts_UserDeletingRow);
            // 
            // chProductID
            // 
            this.chProductID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chProductID.HeaderText = "Product";
            this.chProductID.Name = "chProductID";
            // 
            // chSurvIDProduct
            // 
            this.chSurvIDProduct.HeaderText = "Survey";
            this.chSurvIDProduct.Name = "chSurvIDProduct";
            this.chSurvIDProduct.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(181, 53);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(206, 33);
            this.lblTitle.TabIndex = 30;
            this.lblTitle.Text = "Survey Manager";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.addToolStripMenuItem,
            this.goToEditorToolStripMenuItem,
            this.listViewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(563, 24);
            this.menuStrip1.TabIndex = 31;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.addToolStripMenuItem.Text = "Add...";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // goToEditorToolStripMenuItem
            // 
            this.goToEditorToolStripMenuItem.Name = "goToEditorToolStripMenuItem";
            this.goToEditorToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.goToEditorToolStripMenuItem.Text = "Go To Editor...";
            this.goToEditorToolStripMenuItem.Visible = false;
            // 
            // listViewToolStripMenuItem
            // 
            this.listViewToolStripMenuItem.Name = "listViewToolStripMenuItem";
            this.listViewToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.listViewToolStripMenuItem.Text = "List View";
            this.listViewToolStripMenuItem.Click += new System.EventHandler(this.listViewToolStripMenuItem_Click);
            // 
            // chkITCSurvey
            // 
            this.chkITCSurvey.AutoSize = true;
            this.chkITCSurvey.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkITCSurvey.Location = new System.Drawing.Point(425, 223);
            this.chkITCSurvey.Name = "chkITCSurvey";
            this.chkITCSurvey.Size = new System.Drawing.Size(89, 20);
            this.chkITCSurvey.TabIndex = 32;
            this.chkITCSurvey.Text = "ITC Survey";
            this.chkITCSurvey.UseVisualStyleBackColor = true;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(491, 60);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(56, 26);
            this.cmdDelete.TabIndex = 33;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripGoTo,
            this.toolStripSeparator1,
            this.toolbuttonWaves});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(563, 25);
            this.toolStrip1.TabIndex = 35;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabel1.Text = "Go To";
            // 
            // toolStripGoTo
            // 
            this.toolStripGoTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.toolStripGoTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.toolStripGoTo.Name = "toolStripGoTo";
            this.toolStripGoTo.Size = new System.Drawing.Size(75, 25);
            this.toolStripGoTo.SelectedIndexChanged += new System.EventHandler(this.toolStripGoTo_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolbuttonWaves
            // 
            this.toolbuttonWaves.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbuttonWaves.Image = ((System.Drawing.Image)(resources.GetObject("toolbuttonWaves.Image")));
            this.toolbuttonWaves.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbuttonWaves.Name = "toolbuttonWaves";
            this.toolbuttonWaves.Size = new System.Drawing.Size(73, 22);
            this.toolbuttonWaves.Text = "View Waves";
            this.toolbuttonWaves.Click += new System.EventHandler(this.toolbuttonWaves_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Survey";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Survey";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Survey";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // cmdAddWave
            // 
            this.cmdAddWave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddWave.Location = new System.Drawing.Point(244, 106);
            this.cmdAddWave.Name = "cmdAddWave";
            this.cmdAddWave.Size = new System.Drawing.Size(25, 24);
            this.cmdAddWave.TabIndex = 44;
            this.cmdAddWave.Text = "+";
            this.cmdAddWave.UseCompatibleTextRendering = true;
            this.cmdAddWave.UseVisualStyleBackColor = true;
            this.cmdAddWave.Click += new System.EventHandler(this.cmdAddWave_Click);
            // 
            // SurveyManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(219)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(563, 530);
            this.ControlBox = false;
            this.Controls.Add(this.cmdAddWave);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.chkITCSurvey);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvScreenedProducts);
            this.Controls.Add(this.dgvUserStates);
            this.Controls.Add(this.dgvLanguages);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkLocked);
            this.Controls.Add(this.chkHideSurvey);
            this.Controls.Add(this.chkNCT);
            this.Controls.Add(this.dtpCreationDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboMode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboSurveyType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblSurveyTitle);
            this.Controls.Add(this.cboWaveID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSurveyTitle);
            this.Controls.Add(this.txtSurveyCode);
            this.Controls.Add(this.txtID);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SurveyManager";
            this.Text = "Survey Manager";
            this.Load += new System.EventHandler(this.SurveyManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserStates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScreenedProducts)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtSurveyCode;
        private System.Windows.Forms.TextBox txtSurveyTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboWaveID;
        private System.Windows.Forms.Label lblSurveyTitle;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSurveyType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpCreationDate;
        private System.Windows.Forms.CheckBox chkNCT;
        private System.Windows.Forms.CheckBox chkHideSurvey;
        private System.Windows.Forms.CheckBox chkLocked;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
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
        private System.Windows.Forms.DataGridView dgvLanguages;
        private System.Windows.Forms.DataGridView dgvUserStates;
        private System.Windows.Forms.DataGridView dgvScreenedProducts;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkITCSurvey;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToEditorToolStripMenuItem;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.ToolStripMenuItem listViewToolStripMenuItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn chLangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn chSurvIDLang;
        private System.Windows.Forms.DataGridViewComboBoxColumn chProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn chSurvIDProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn chUserStateID;
        private System.Windows.Forms.DataGridViewTextBoxColumn chSurvIDState;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripGoTo;
        private System.Windows.Forms.ToolStripButton toolbuttonWaves;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button cmdAddWave;
    }
}

