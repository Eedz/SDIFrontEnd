namespace SDIFrontEnd
{
    partial class VarChangeTracking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VarChangeTracking));
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblNewID = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.chkHiddenChange = new System.Windows.Forms.CheckBox();
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
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkPreFWS = new System.Windows.Forms.CheckBox();
            this.dgvNotifications = new System.Windows.Forms.DataGridView();
            this.chNotifyName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chNotifyType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSurveys = new System.Windows.Forms.DataGridView();
            this.chSurvey = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtRationale = new System.Windows.Forms.TextBox();
            this.txtAuthorization = new System.Windows.Forms.TextBox();
            this.cboChangedBy = new System.Windows.Forms.ComboBox();
            this.dtpChangeDate = new System.Windows.Forms.DateTimePicker();
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.txtOldName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSurvey = new System.Windows.Forms.ComboBox();
            this.lblSurvey = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEmail = new System.Windows.Forms.ToolStripButton();
            this.dataRepeater1 = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.label11 = new System.Windows.Forms.Label();
            this.txtHistoryOldName = new System.Windows.Forms.TextBox();
            this.txtHistoryNewName = new System.Windows.Forms.TextBox();
            this.txtHistoryChangeDate = new System.Windows.Forms.TextBox();
            this.chkToggleHistory = new System.Windows.Forms.CheckBox();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotifications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurveys)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.dataRepeater1.ItemTemplate.SuspendLayout();
            this.dataRepeater1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.lblNewID);
            this.panelMain.Controls.Add(this.lblID);
            this.panelMain.Controls.Add(this.txtID);
            this.panelMain.Controls.Add(this.chkHiddenChange);
            this.panelMain.Controls.Add(this.bindingNavigator1);
            this.panelMain.Controls.Add(this.label10);
            this.panelMain.Controls.Add(this.label9);
            this.panelMain.Controls.Add(this.label8);
            this.panelMain.Controls.Add(this.label7);
            this.panelMain.Controls.Add(this.label6);
            this.panelMain.Controls.Add(this.label5);
            this.panelMain.Controls.Add(this.label4);
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.chkPreFWS);
            this.panelMain.Controls.Add(this.dgvNotifications);
            this.panelMain.Controls.Add(this.dgvSurveys);
            this.panelMain.Controls.Add(this.txtSource);
            this.panelMain.Controls.Add(this.txtRationale);
            this.panelMain.Controls.Add(this.txtAuthorization);
            this.panelMain.Controls.Add(this.cboChangedBy);
            this.panelMain.Controls.Add(this.dtpChangeDate);
            this.panelMain.Controls.Add(this.txtNewName);
            this.panelMain.Controls.Add(this.txtOldName);
            this.panelMain.Location = new System.Drawing.Point(12, 127);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(767, 408);
            this.panelMain.TabIndex = 25;
            this.panelMain.Visible = false;
            // 
            // lblNewID
            // 
            this.lblNewID.BackColor = System.Drawing.Color.White;
            this.lblNewID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNewID.Location = new System.Drawing.Point(219, 16);
            this.lblNewID.Name = "lblNewID";
            this.lblNewID.Size = new System.Drawing.Size(90, 23);
            this.lblNewID.TabIndex = 24;
            this.lblNewID.Text = "(New)";
            this.lblNewID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNewID.Visible = false;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(68, 19);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(19, 16);
            this.lblID.TabIndex = 23;
            this.lblID.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(94, 16);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(90, 23);
            this.txtID.TabIndex = 22;
            // 
            // chkHiddenChange
            // 
            this.chkHiddenChange.AutoSize = true;
            this.chkHiddenChange.Location = new System.Drawing.Point(219, 100);
            this.chkHiddenChange.Name = "chkHiddenChange";
            this.chkHiddenChange.Size = new System.Drawing.Size(112, 20);
            this.chkHiddenChange.TabIndex = 21;
            this.chkHiddenChange.Text = "Hidden Change";
            this.chkHiddenChange.UseVisualStyleBackColor = true;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 381);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(765, 25);
            this.bindingNavigator1.TabIndex = 20;
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(514, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Notifications";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(376, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Surveys Affected";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Source";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Rationale";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Authorization";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Changed By";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "->";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "VarName";
            // 
            // chkPreFWS
            // 
            this.chkPreFWS.AutoSize = true;
            this.chkPreFWS.Location = new System.Drawing.Point(219, 76);
            this.chkPreFWS.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.chkPreFWS.Name = "chkPreFWS";
            this.chkPreFWS.Size = new System.Drawing.Size(124, 20);
            this.chkPreFWS.TabIndex = 10;
            this.chkPreFWS.Text = "Pre-FWS Change";
            this.chkPreFWS.UseVisualStyleBackColor = true;
            // 
            // dgvNotifications
            // 
            this.dgvNotifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotifications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chNotifyName,
            this.chNotifyType});
            this.dgvNotifications.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvNotifications.Location = new System.Drawing.Point(507, 34);
            this.dgvNotifications.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgvNotifications.Name = "dgvNotifications";
            this.dgvNotifications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotifications.Size = new System.Drawing.Size(246, 344);
            this.dgvNotifications.TabIndex = 9;
            this.dgvNotifications.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNotifications_CellValidated);
            this.dgvNotifications.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvNotifications_DataError);
            this.dgvNotifications.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNotifications_RowValidated);
            this.dgvNotifications.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvNotifications_UserDeletingRow);
            // 
            // chNotifyName
            // 
            this.chNotifyName.HeaderText = "Name";
            this.chNotifyName.Name = "chNotifyName";
            // 
            // chNotifyType
            // 
            this.chNotifyType.HeaderText = "Type";
            this.chNotifyType.Name = "chNotifyType";
            // 
            // dgvSurveys
            // 
            this.dgvSurveys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSurveys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chSurvey});
            this.dgvSurveys.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvSurveys.Location = new System.Drawing.Point(371, 34);
            this.dgvSurveys.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgvSurveys.Name = "dgvSurveys";
            this.dgvSurveys.RowHeadersWidth = 25;
            this.dgvSurveys.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSurveys.Size = new System.Drawing.Size(130, 344);
            this.dgvSurveys.TabIndex = 8;
            this.dgvSurveys.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSurveys_CellValidated);
            this.dgvSurveys.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvSurveys_DataError);
            this.dgvSurveys.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSurveys_RowValidated);
            this.dgvSurveys.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvSurveys_UserDeletingRow);
            // 
            // chSurvey
            // 
            this.chSurvey.HeaderText = "Survey";
            this.chSurvey.Name = "chSurvey";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(93, 300);
            this.txtSource.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(271, 79);
            this.txtSource.TabIndex = 7;
            // 
            // txtRationale
            // 
            this.txtRationale.Location = new System.Drawing.Point(93, 188);
            this.txtRationale.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtRationale.Multiline = true;
            this.txtRationale.Name = "txtRationale";
            this.txtRationale.Size = new System.Drawing.Size(271, 110);
            this.txtRationale.TabIndex = 6;
            // 
            // txtAuthorization
            // 
            this.txtAuthorization.Location = new System.Drawing.Point(93, 124);
            this.txtAuthorization.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtAuthorization.Multiline = true;
            this.txtAuthorization.Name = "txtAuthorization";
            this.txtAuthorization.Size = new System.Drawing.Size(271, 62);
            this.txtAuthorization.TabIndex = 5;
            // 
            // cboChangedBy
            // 
            this.cboChangedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboChangedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboChangedBy.FormattingEnabled = true;
            this.cboChangedBy.Location = new System.Drawing.Point(93, 98);
            this.cboChangedBy.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboChangedBy.Name = "cboChangedBy";
            this.cboChangedBy.Size = new System.Drawing.Size(120, 24);
            this.cboChangedBy.TabIndex = 4;
            // 
            // dtpChangeDate
            // 
            this.dtpChangeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpChangeDate.Location = new System.Drawing.Point(94, 73);
            this.dtpChangeDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtpChangeDate.Name = "dtpChangeDate";
            this.dtpChangeDate.Size = new System.Drawing.Size(119, 23);
            this.dtpChangeDate.TabIndex = 3;
            // 
            // txtNewName
            // 
            this.txtNewName.Location = new System.Drawing.Point(219, 49);
            this.txtNewName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.Size = new System.Drawing.Size(90, 23);
            this.txtNewName.TabIndex = 2;
            // 
            // txtOldName
            // 
            this.txtOldName.Location = new System.Drawing.Point(94, 48);
            this.txtOldName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtOldName.Name = "txtOldName";
            this.txtOldName.Size = new System.Drawing.Size(90, 23);
            this.txtOldName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 33);
            this.label1.TabIndex = 24;
            this.label1.Text = "VarName Change Tracking";
            // 
            // cboSurvey
            // 
            this.cboSurvey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSurvey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSurvey.FormattingEnabled = true;
            this.cboSurvey.Location = new System.Drawing.Point(332, 96);
            this.cboSurvey.Name = "cboSurvey";
            this.cboSurvey.Size = new System.Drawing.Size(119, 24);
            this.cboSurvey.TabIndex = 26;
            // 
            // lblSurvey
            // 
            this.lblSurvey.AutoSize = true;
            this.lblSurvey.Location = new System.Drawing.Point(246, 99);
            this.lblSurvey.Name = "lblSurvey";
            this.lblSurvey.Size = new System.Drawing.Size(79, 16);
            this.lblSurvey.TabIndex = 27;
            this.lblSurvey.Text = "Survey Filter";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1169, 24);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdd,
            this.toolStripButtonDelete,
            this.toolStripButtonEmail});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1169, 25);
            this.toolStrip1.TabIndex = 29;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAdd.Image")));
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(33, 22);
            this.toolStripButtonAdd.Text = "Add";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelete.Image")));
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(44, 22);
            this.toolStripButtonDelete.Text = "Delete";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // toolStripButtonEmail
            // 
            this.toolStripButtonEmail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonEmail.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEmail.Image")));
            this.toolStripButtonEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEmail.Name = "toolStripButtonEmail";
            this.toolStripButtonEmail.Size = new System.Drawing.Size(40, 22);
            this.toolStripButtonEmail.Text = "Email";
            this.toolStripButtonEmail.Click += new System.EventHandler(this.toolStripButtonEmail_Click);
            // 
            // dataRepeater1
            // 
            this.dataRepeater1.CausesValidation = false;
            // 
            // dataRepeater1.ItemTemplate
            // 
            this.dataRepeater1.ItemTemplate.Controls.Add(this.label11);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.txtHistoryOldName);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.txtHistoryNewName);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.txtHistoryChangeDate);
            this.dataRepeater1.ItemTemplate.Size = new System.Drawing.Size(365, 36);
            this.dataRepeater1.Location = new System.Drawing.Point(785, 127);
            this.dataRepeater1.Name = "dataRepeater1";
            this.dataRepeater1.Size = new System.Drawing.Size(373, 407);
            this.dataRepeater1.TabIndex = 31;
            this.dataRepeater1.Text = "dataRepeater1";
            this.dataRepeater1.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(217, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "->";
            // 
            // txtHistoryOldName
            // 
            this.txtHistoryOldName.Location = new System.Drawing.Point(109, 3);
            this.txtHistoryOldName.Name = "txtHistoryOldName";
            this.txtHistoryOldName.Size = new System.Drawing.Size(100, 23);
            this.txtHistoryOldName.TabIndex = 2;
            // 
            // txtHistoryNewName
            // 
            this.txtHistoryNewName.Location = new System.Drawing.Point(245, 3);
            this.txtHistoryNewName.Name = "txtHistoryNewName";
            this.txtHistoryNewName.Size = new System.Drawing.Size(100, 23);
            this.txtHistoryNewName.TabIndex = 1;
            // 
            // txtHistoryChangeDate
            // 
            this.txtHistoryChangeDate.Location = new System.Drawing.Point(3, 3);
            this.txtHistoryChangeDate.Name = "txtHistoryChangeDate";
            this.txtHistoryChangeDate.Size = new System.Drawing.Size(100, 23);
            this.txtHistoryChangeDate.TabIndex = 0;
            // 
            // chkToggleHistory
            // 
            this.chkToggleHistory.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkToggleHistory.AutoSize = true;
            this.chkToggleHistory.Location = new System.Drawing.Point(679, 96);
            this.chkToggleHistory.Name = "chkToggleHistory";
            this.chkToggleHistory.Size = new System.Drawing.Size(99, 26);
            this.chkToggleHistory.TabIndex = 32;
            this.chkToggleHistory.Text = "Toggle History";
            this.chkToggleHistory.UseVisualStyleBackColor = true;
            this.chkToggleHistory.Visible = false;
            this.chkToggleHistory.CheckedChanged += new System.EventHandler(this.chkToggleHistory_CheckedChanged);
            // 
            // VarChangeTracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(226)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1169, 542);
            this.Controls.Add(this.chkToggleHistory);
            this.Controls.Add(this.dataRepeater1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblSurvey);
            this.Controls.Add(this.cboSurvey);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VarChangeTracking";
            this.Text = "VarName Change Tracking";
            this.Load += new System.EventHandler(this.VarChangeTracking_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotifications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurveys)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.dataRepeater1.ItemTemplate.ResumeLayout(false);
            this.dataRepeater1.ItemTemplate.PerformLayout();
            this.dataRepeater1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkPreFWS;
        private System.Windows.Forms.DataGridView dgvNotifications;
        private System.Windows.Forms.DataGridView dgvSurveys;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtRationale;
        private System.Windows.Forms.TextBox txtAuthorization;
        private System.Windows.Forms.ComboBox cboChangedBy;
        private System.Windows.Forms.DateTimePicker dtpChangeDate;
        private System.Windows.Forms.TextBox txtNewName;
        private System.Windows.Forms.TextBox txtOldName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSurvey;
        private System.Windows.Forms.Label lblSurvey;
        private System.Windows.Forms.DataGridViewComboBoxColumn chSurvey;
        private System.Windows.Forms.DataGridViewComboBoxColumn chNotifyName;
        private System.Windows.Forms.DataGridViewComboBoxColumn chNotifyType;
        private System.Windows.Forms.CheckBox chkHiddenChange;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label lblNewID;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonEmail;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtHistoryOldName;
        private System.Windows.Forms.TextBox txtHistoryNewName;
        private System.Windows.Forms.TextBox txtHistoryChangeDate;
        private System.Windows.Forms.CheckBox chkToggleHistory;
    }
}