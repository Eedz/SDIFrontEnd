namespace SDIFrontEnd
{
    partial class PersonnelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonnelForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtSearchCriteria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.chkShowInactive = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.chRole = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lblNewID = new System.Windows.Forms.Label();
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
            this.lblPraccID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkChangeNotify = new System.Windows.Forms.CheckBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtPraccID = new System.Windows.Forms.TextBox();
            this.txtInstitution = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtOfficeNo = new System.Windows.Forms.TextBox();
            this.txtHomePhone = new System.Windows.Forms.TextBox();
            this.txtWorkPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.chkPraccEntry = new System.Windows.Forms.CheckBox();
            this.chkEntry = new System.Windows.Forms.CheckBox();
            this.dgvStudies = new System.Windows.Forms.DataGridView();
            this.chStudyName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvComments = new System.Windows.Forms.DataGridView();
            this.chCommentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(216, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(232, 33);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Manage Personnel";
            // 
            // txtSearchCriteria
            // 
            this.txtSearchCriteria.Location = new System.Drawing.Point(103, 67);
            this.txtSearchCriteria.Name = "txtSearchCriteria";
            this.txtSearchCriteria.Size = new System.Drawing.Size(100, 23);
            this.txtSearchCriteria.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Name";
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(222, 66);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(75, 23);
            this.cmdSearch.TabIndex = 3;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(546, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(33, 22);
            this.toolStripButton1.Text = "Add";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton2.Text = "Delete";
            this.toolStripButton2.Visible = false;
            // 
            // chkShowInactive
            // 
            this.chkShowInactive.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowInactive.AutoSize = true;
            this.chkShowInactive.Location = new System.Drawing.Point(264, 6);
            this.chkShowInactive.Name = "chkShowInactive";
            this.chkShowInactive.Size = new System.Drawing.Size(106, 26);
            this.chkShowInactive.TabIndex = 5;
            this.chkShowInactive.Text = "Include Inactive";
            this.chkShowInactive.UseVisualStyleBackColor = true;
            this.chkShowInactive.Visible = false;
            this.chkShowInactive.CheckedChanged += new System.EventHandler(this.chkShowInactive_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvRoles);
            this.panel1.Controls.Add(this.chkShowInactive);
            this.panel1.Controls.Add(this.chkPraccEntry);
            this.panel1.Controls.Add(this.lblNewID);
            this.panel1.Controls.Add(this.bindingNavigator1);
            this.panel1.Controls.Add(this.lblPraccID);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkEntry);
            this.panel1.Controls.Add(this.chkChangeNotify);
            this.panel1.Controls.Add(this.chkActive);
            this.panel1.Controls.Add(this.txtPraccID);
            this.panel1.Controls.Add(this.txtInstitution);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.Controls.Add(this.txtOfficeNo);
            this.panel1.Controls.Add(this.txtHomePhone);
            this.panel1.Controls.Add(this.txtWorkPhone);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtLastName);
            this.panel1.Controls.Add(this.txtFirstName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Location = new System.Drawing.Point(8, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 306);
            this.panel1.TabIndex = 6;
            // 
            // dgvRoles
            // 
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chRole});
            this.dgvRoles.Location = new System.Drawing.Point(267, 119);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.Size = new System.Drawing.Size(219, 150);
            this.dgvRoles.TabIndex = 13;
            this.dgvRoles.VirtualMode = true;
            this.dgvRoles.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.dgvRoles_CancelRowEdit);
            this.dgvRoles.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvRoles_CellValueNeeded);
            this.dgvRoles.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvRoles_CellValuePushed);
            this.dgvRoles.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvRoles_DataError);
            this.dgvRoles.NewRowNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvRoles_NewRowNeeded);
            this.dgvRoles.RowDirtyStateNeeded += new System.Windows.Forms.QuestionEventHandler(this.dgvRoles_RowDirtyStateNeeded);
            this.dgvRoles.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoles_RowValidated);
            this.dgvRoles.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvRoles_UserDeletingRow);
            // 
            // chRole
            // 
            this.chRole.HeaderText = "Role";
            this.chRole.Name = "chRole";
            // 
            // lblNewID
            // 
            this.lblNewID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNewID.Location = new System.Drawing.Point(93, 9);
            this.lblNewID.Name = "lblNewID";
            this.lblNewID.Size = new System.Drawing.Size(159, 23);
            this.lblNewID.TabIndex = 37;
            this.lblNewID.Text = "(New)";
            this.lblNewID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNewID.Visible = false;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 281);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(519, 25);
            this.bindingNavigator1.TabIndex = 36;
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
            // lblPraccID
            // 
            this.lblPraccID.AutoSize = true;
            this.lblPraccID.Location = new System.Drawing.Point(262, 91);
            this.lblPraccID.Name = "lblPraccID";
            this.lblPraccID.Size = new System.Drawing.Size(54, 16);
            this.lblPraccID.TabIndex = 34;
            this.lblPraccID.Text = "Pracc ID";
            this.lblPraccID.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 249);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 16);
            this.label10.TabIndex = 33;
            this.label10.Text = "Institution";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 16);
            this.label9.TabIndex = 32;
            this.label9.Text = "Username";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 16);
            this.label8.TabIndex = 31;
            this.label8.Text = "Office No";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 16);
            this.label7.TabIndex = 30;
            this.label7.Text = "Home Phone";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "Work Phone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "First Name";
            // 
            // chkChangeNotify
            // 
            this.chkChangeNotify.AutoSize = true;
            this.chkChangeNotify.Location = new System.Drawing.Point(264, 60);
            this.chkChangeNotify.Name = "chkChangeNotify";
            this.chkChangeNotify.Size = new System.Drawing.Size(162, 20);
            this.chkChangeNotify.TabIndex = 22;
            this.chkChangeNotify.Text = "VarName Change Notify";
            this.chkChangeNotify.UseVisualStyleBackColor = true;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(264, 38);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(60, 20);
            this.chkActive.TabIndex = 11;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtPraccID
            // 
            this.txtPraccID.Location = new System.Drawing.Point(322, 88);
            this.txtPraccID.Name = "txtPraccID";
            this.txtPraccID.Size = new System.Drawing.Size(88, 23);
            this.txtPraccID.TabIndex = 10;
            this.txtPraccID.Visible = false;
            // 
            // txtInstitution
            // 
            this.txtInstitution.Location = new System.Drawing.Point(93, 246);
            this.txtInstitution.Name = "txtInstitution";
            this.txtInstitution.Size = new System.Drawing.Size(159, 23);
            this.txtInstitution.TabIndex = 9;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(93, 217);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(159, 23);
            this.txtUsername.TabIndex = 8;
            // 
            // txtOfficeNo
            // 
            this.txtOfficeNo.Location = new System.Drawing.Point(93, 189);
            this.txtOfficeNo.Name = "txtOfficeNo";
            this.txtOfficeNo.Size = new System.Drawing.Size(159, 23);
            this.txtOfficeNo.TabIndex = 7;
            // 
            // txtHomePhone
            // 
            this.txtHomePhone.Location = new System.Drawing.Point(93, 163);
            this.txtHomePhone.Name = "txtHomePhone";
            this.txtHomePhone.Size = new System.Drawing.Size(159, 23);
            this.txtHomePhone.TabIndex = 6;
            // 
            // txtWorkPhone
            // 
            this.txtWorkPhone.Location = new System.Drawing.Point(93, 137);
            this.txtWorkPhone.Name = "txtWorkPhone";
            this.txtWorkPhone.Size = new System.Drawing.Size(159, 23);
            this.txtWorkPhone.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(93, 111);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(159, 23);
            this.txtEmail.TabIndex = 4;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(93, 85);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(159, 23);
            this.txtLastName.TabIndex = 3;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(93, 60);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(159, 23);
            this.txtFirstName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(93, 35);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(159, 23);
            this.txtID.TabIndex = 0;
            // 
            // chkPraccEntry
            // 
            this.chkPraccEntry.AutoSize = true;
            this.chkPraccEntry.Location = new System.Drawing.Point(428, 59);
            this.chkPraccEntry.Name = "chkPraccEntry";
            this.chkPraccEntry.Size = new System.Drawing.Size(90, 20);
            this.chkPraccEntry.TabIndex = 35;
            this.chkPraccEntry.Text = "Pracc Entry";
            this.chkPraccEntry.UseVisualStyleBackColor = true;
            // 
            // chkEntry
            // 
            this.chkEntry.AutoSize = true;
            this.chkEntry.Location = new System.Drawing.Point(428, 38);
            this.chkEntry.Name = "chkEntry";
            this.chkEntry.Size = new System.Drawing.Size(55, 20);
            this.chkEntry.TabIndex = 15;
            this.chkEntry.Text = "Entry";
            this.chkEntry.UseVisualStyleBackColor = true;
            // 
            // dgvStudies
            // 
            this.dgvStudies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chStudyName});
            this.dgvStudies.Location = new System.Drawing.Point(8, 433);
            this.dgvStudies.Name = "dgvStudies";
            this.dgvStudies.RowHeadersWidth = 30;
            this.dgvStudies.Size = new System.Drawing.Size(240, 150);
            this.dgvStudies.TabIndex = 7;
            this.dgvStudies.VirtualMode = true;
            this.dgvStudies.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.dgvStudies_CancelRowEdit);
            this.dgvStudies.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvStudies_CellValueNeeded);
            this.dgvStudies.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvStudies_CellValuePushed);
            this.dgvStudies.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvStudies_DataError);
            this.dgvStudies.NewRowNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvStudies_NewRowNeeded);
            this.dgvStudies.RowDirtyStateNeeded += new System.Windows.Forms.QuestionEventHandler(this.dgvStudies_RowDirtyStateNeeded);
            this.dgvStudies.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudies_RowValidated);
            this.dgvStudies.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvStudies_UserDeletingRow);
            // 
            // chStudyName
            // 
            this.chStudyName.HeaderText = "Study";
            this.chStudyName.Name = "chStudyName";
            this.chStudyName.Width = 200;
            // 
            // dgvComments
            // 
            this.dgvComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chCommentType,
            this.chComment});
            this.dgvComments.Location = new System.Drawing.Point(254, 433);
            this.dgvComments.Name = "dgvComments";
            this.dgvComments.RowHeadersWidth = 30;
            this.dgvComments.Size = new System.Drawing.Size(240, 150);
            this.dgvComments.TabIndex = 8;
            this.dgvComments.VirtualMode = true;
            this.dgvComments.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.dgvComments_CancelRowEdit);
            this.dgvComments.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvComments_CellValueNeeded);
            this.dgvComments.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvComments_CellValuePushed);
            this.dgvComments.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvComments_DataError);
            this.dgvComments.NewRowNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvComments_NewRowNeeded);
            this.dgvComments.RowDirtyStateNeeded += new System.Windows.Forms.QuestionEventHandler(this.dgvComments_RowDirtyStateNeeded);
            this.dgvComments.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComments_RowValidated);
            this.dgvComments.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvComments_UserDeletingRow);
            // 
            // chCommentType
            // 
            this.chCommentType.HeaderText = "Type";
            this.chCommentType.Name = "chCommentType";
            // 
            // chComment
            // 
            this.chComment.HeaderText = "Comment";
            this.chComment.Name = "chComment";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 411);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 16);
            this.label12.TabIndex = 9;
            this.label12.Text = "Associated Studies";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(259, 411);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 16);
            this.label13.TabIndex = 10;
            this.label13.Text = "Comments";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(451, 607);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 11;
            this.cmdClose.Text = "OK";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Location = new System.Drawing.Point(6, 595);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(530, 2);
            this.label14.TabIndex = 12;
            this.label14.Text = "label14";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 25;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Study";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Person ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "PersonnelID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Type";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Comment";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // PersonnelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(238)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(546, 635);
            this.ControlBox = false;
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dgvComments);
            this.Controls.Add(this.dgvStudies);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearchCriteria);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PersonnelForm";
            this.Text = "Manage Personnel";
            this.Load += new System.EventHandler(this.PersonnelForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSearchCriteria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.CheckBox chkShowInactive;
        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.CheckBox chkPraccEntry;
        private System.Windows.Forms.Label lblPraccID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkChangeNotify;
        private System.Windows.Forms.CheckBox chkEntry;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.TextBox txtPraccID;
        private System.Windows.Forms.TextBox txtInstitution;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtOfficeNo;
        private System.Windows.Forms.TextBox txtHomePhone;
        private System.Windows.Forms.TextBox txtWorkPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.DataGridView dgvStudies;
        private System.Windows.Forms.DataGridView dgvComments;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Label lblNewID;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCommentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn chComment;
        private System.Windows.Forms.DataGridViewComboBoxColumn chStudyName;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.DataGridViewComboBoxColumn chRole;
    }
}