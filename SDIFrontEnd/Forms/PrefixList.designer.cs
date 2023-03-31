namespace SDIFrontEnd
{
    partial class PrefixList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrefixList));
            this.cboGoTo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dgvParallelPrefixes = new System.Windows.Forms.DataGridView();
            this.chParallelPrefix = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.txtRelatedPrefixes = new System.Windows.Forms.TextBox();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.txtPrefixName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkInactive = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvVarNameRanges = new System.Windows.Forms.DataGridView();
            this.chLower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chUpper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvVariableInfo = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.chkFilterByRange = new System.Windows.Forms.CheckBox();
            this.chkShowWordings = new System.Windows.Forms.CheckBox();
            this.panelReport = new System.Windows.Forms.Panel();
            this.cmdGenerateReport = new System.Windows.Forms.Button();
            this.lstColumns = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lstInclude = new System.Windows.Forms.ListBox();
            this.cmdClearReport = new System.Windows.Forms.Button();
            this.cmdIncludeAll = new System.Windows.Forms.Button();
            this.cmdAddPrefix = new System.Windows.Forms.Button();
            this.cboRemovePrefix = new System.Windows.Forms.Button();
            this.cboInclude = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.toggleLock = new System.Windows.Forms.CheckBox();
            this.navPrefixes = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripDatasheet = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParallelPrefixes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVarNameRanges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVariableInfo)).BeginInit();
            this.panelReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navPrefixes)).BeginInit();
            this.navPrefixes.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboGoTo
            // 
            this.cboGoTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboGoTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGoTo.FormattingEnabled = true;
            this.cboGoTo.Location = new System.Drawing.Point(100, 80);
            this.cboGoTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboGoTo.Name = "cboGoTo";
            this.cboGoTo.Size = new System.Drawing.Size(90, 24);
            this.cboGoTo.TabIndex = 2;
            this.cboGoTo.SelectedIndexChanged += new System.EventHandler(this.cboGoTo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Go to:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(347, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "Prefix List";
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.txtDescription);
            this.panelMain.Controls.Add(this.dgvParallelPrefixes);
            this.panelMain.Controls.Add(this.txtComments);
            this.panelMain.Controls.Add(this.txtRelatedPrefixes);
            this.panelMain.Controls.Add(this.txtProductType);
            this.panelMain.Controls.Add(this.txtPrefixName);
            this.panelMain.Controls.Add(this.label8);
            this.panelMain.Controls.Add(this.chkInactive);
            this.panelMain.Controls.Add(this.label7);
            this.panelMain.Controls.Add(this.label6);
            this.panelMain.Controls.Add(this.label5);
            this.panelMain.Controls.Add(this.label4);
            this.panelMain.Controls.Add(this.txtPrefix);
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Location = new System.Drawing.Point(6, 114);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(703, 234);
            this.panelMain.TabIndex = 9;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(94, 101);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(598, 23);
            this.txtDescription.TabIndex = 13;
            this.txtDescription.Validated += new System.EventHandler(this.Control_Validated);
            // 
            // dgvParallelPrefixes
            // 
            this.dgvParallelPrefixes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParallelPrefixes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chParallelPrefix});
            this.dgvParallelPrefixes.Location = new System.Drawing.Point(545, 18);
            this.dgvParallelPrefixes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvParallelPrefixes.Name = "dgvParallelPrefixes";
            this.dgvParallelPrefixes.Size = new System.Drawing.Size(147, 80);
            this.dgvParallelPrefixes.TabIndex = 12;
            this.dgvParallelPrefixes.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParallelPrefixes_CellValidated);
            this.dgvParallelPrefixes.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvParallelPrefixes_DataError);
            this.dgvParallelPrefixes.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParallelPrefixes_RowValidated);
            this.dgvParallelPrefixes.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvParallelPrefixes_UserDeletingRow);
            // 
            // chParallelPrefix
            // 
            this.chParallelPrefix.HeaderText = "Parallel Prefix";
            this.chParallelPrefix.Name = "chParallelPrefix";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(94, 130);
            this.txtComments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(598, 68);
            this.txtComments.TabIndex = 11;
            this.txtComments.Validated += new System.EventHandler(this.Control_Validated);
            // 
            // txtRelatedPrefixes
            // 
            this.txtRelatedPrefixes.Location = new System.Drawing.Point(94, 74);
            this.txtRelatedPrefixes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRelatedPrefixes.Name = "txtRelatedPrefixes";
            this.txtRelatedPrefixes.Size = new System.Drawing.Size(445, 23);
            this.txtRelatedPrefixes.TabIndex = 10;
            this.txtRelatedPrefixes.Validated += new System.EventHandler(this.Control_Validated);
            // 
            // txtProductType
            // 
            this.txtProductType.Location = new System.Drawing.Point(94, 46);
            this.txtProductType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(445, 23);
            this.txtProductType.TabIndex = 9;
            this.txtProductType.Validated += new System.EventHandler(this.Control_Validated);
            // 
            // txtPrefixName
            // 
            this.txtPrefixName.Location = new System.Drawing.Point(283, 18);
            this.txtPrefixName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrefixName.Name = "txtPrefixName";
            this.txtPrefixName.Size = new System.Drawing.Size(256, 23);
            this.txtPrefixName.TabIndex = 8;
            this.txtPrefixName.Validated += new System.EventHandler(this.Control_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(236, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Name";
            // 
            // chkInactive
            // 
            this.chkInactive.AutoSize = true;
            this.chkInactive.Location = new System.Drawing.Point(8, 205);
            this.chkInactive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkInactive.Name = "chkInactive";
            this.chkInactive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkInactive.Size = new System.Drawing.Size(70, 20);
            this.chkInactive.TabIndex = 6;
            this.chkInactive.Text = "Inactive";
            this.chkInactive.UseVisualStyleBackColor = true;
            this.chkInactive.Validated += new System.EventHandler(this.Control_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Comment";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "See also";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Product Type";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(94, 18);
            this.txtPrefix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(89, 23);
            this.txtPrefix.TabIndex = 1;
            this.txtPrefix.Validated += new System.EventHandler(this.Control_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Prefix";
            // 
            // dgvVarNameRanges
            // 
            this.dgvVarNameRanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVarNameRanges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chLower,
            this.chUpper,
            this.chDescription});
            this.dgvVarNameRanges.Location = new System.Drawing.Point(12, 383);
            this.dgvVarNameRanges.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvVarNameRanges.Name = "dgvVarNameRanges";
            this.dgvVarNameRanges.RowHeadersWidth = 25;
            this.dgvVarNameRanges.Size = new System.Drawing.Size(335, 390);
            this.dgvVarNameRanges.TabIndex = 10;
            this.dgvVarNameRanges.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVarNameRanges_CellValidated);
            this.dgvVarNameRanges.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvVarNameRanges_DataError);
            this.dgvVarNameRanges.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVarNameRanges_RowEnter);
            this.dgvVarNameRanges.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVarNameRanges_RowValidated);
            this.dgvVarNameRanges.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvVarNameRanges_UserDeletingRow);
            // 
            // chLower
            // 
            this.chLower.HeaderText = "Lower";
            this.chLower.Name = "chLower";
            this.chLower.Width = 60;
            // 
            // chUpper
            // 
            this.chUpper.HeaderText = "Upper";
            this.chUpper.Name = "chUpper";
            this.chUpper.Width = 60;
            // 
            // chDescription
            // 
            this.chDescription.HeaderText = "Description";
            this.chDescription.Name = "chDescription";
            this.chDescription.Width = 200;
            // 
            // dgvVariableInfo
            // 
            this.dgvVariableInfo.AllowUserToAddRows = false;
            this.dgvVariableInfo.AllowUserToDeleteRows = false;
            this.dgvVariableInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVariableInfo.Location = new System.Drawing.Point(353, 384);
            this.dgvVariableInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvVariableInfo.Name = "dgvVariableInfo";
            this.dgvVariableInfo.ReadOnly = true;
            this.dgvVariableInfo.RowHeadersVisible = false;
            this.dgvVariableInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvVariableInfo.Size = new System.Drawing.Size(1372, 388);
            this.dgvVariableInfo.TabIndex = 11;
            this.dgvVariableInfo.VirtualMode = true;
            this.dgvVariableInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVariableInfo_CellDoubleClick);
            this.dgvVariableInfo.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvVariableInfo_CellValueNeeded);
            this.dgvVariableInfo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvVariableInfo_DataError);
            this.dgvVariableInfo.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVariableInfo_RowEnter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 360);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "VarName Ranges";
            // 
            // chkFilterByRange
            // 
            this.chkFilterByRange.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFilterByRange.AutoSize = true;
            this.chkFilterByRange.Location = new System.Drawing.Point(243, 353);
            this.chkFilterByRange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkFilterByRange.Name = "chkFilterByRange";
            this.chkFilterByRange.Size = new System.Drawing.Size(103, 26);
            this.chkFilterByRange.TabIndex = 13;
            this.chkFilterByRange.Text = "Filter By Range";
            this.chkFilterByRange.UseVisualStyleBackColor = true;
            this.chkFilterByRange.Click += new System.EventHandler(this.chkFilterByRange_Click);
            // 
            // chkShowWordings
            // 
            this.chkShowWordings.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowWordings.AutoSize = true;
            this.chkShowWordings.Location = new System.Drawing.Point(353, 353);
            this.chkShowWordings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowWordings.Name = "chkShowWordings";
            this.chkShowWordings.Size = new System.Drawing.Size(107, 26);
            this.chkShowWordings.TabIndex = 14;
            this.chkShowWordings.Text = "Show Wordings";
            this.chkShowWordings.UseVisualStyleBackColor = true;
            this.chkShowWordings.CheckedChanged += new System.EventHandler(this.chkShowWordings_CheckedChanged);
            // 
            // panelReport
            // 
            this.panelReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReport.Controls.Add(this.cmdGenerateReport);
            this.panelReport.Controls.Add(this.lstColumns);
            this.panelReport.Controls.Add(this.label11);
            this.panelReport.Controls.Add(this.lstInclude);
            this.panelReport.Controls.Add(this.cmdClearReport);
            this.panelReport.Controls.Add(this.cmdIncludeAll);
            this.panelReport.Controls.Add(this.cmdAddPrefix);
            this.panelReport.Controls.Add(this.cboRemovePrefix);
            this.panelReport.Controls.Add(this.cboInclude);
            this.panelReport.Controls.Add(this.label10);
            this.panelReport.Location = new System.Drawing.Point(731, 114);
            this.panelReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelReport.Name = "panelReport";
            this.panelReport.Size = new System.Drawing.Size(342, 234);
            this.panelReport.TabIndex = 15;
            this.panelReport.Visible = false;
            // 
            // cmdGenerateReport
            // 
            this.cmdGenerateReport.Location = new System.Drawing.Point(209, 197);
            this.cmdGenerateReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdGenerateReport.Name = "cmdGenerateReport";
            this.cmdGenerateReport.Size = new System.Drawing.Size(110, 28);
            this.cmdGenerateReport.TabIndex = 9;
            this.cmdGenerateReport.Text = "View as Report";
            this.cmdGenerateReport.UseVisualStyleBackColor = true;
            // 
            // lstColumns
            // 
            this.lstColumns.FormattingEnabled = true;
            this.lstColumns.ItemHeight = 16;
            this.lstColumns.Items.AddRange(new object[] {
            "Prefix",
            "Prefix Name",
            "Product Type",
            "Related Prefix",
            "Include Ranges",
            "Domain Desc.",
            "Comments",
            "Inactive?"});
            this.lstColumns.Location = new System.Drawing.Point(209, 41);
            this.lstColumns.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstColumns.Name = "lstColumns";
            this.lstColumns.Size = new System.Drawing.Size(109, 148);
            this.lstColumns.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(205, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 16);
            this.label11.TabIndex = 7;
            this.label11.Text = "Columns to Include";
            // 
            // lstInclude
            // 
            this.lstInclude.FormattingEnabled = true;
            this.lstInclude.ItemHeight = 16;
            this.lstInclude.Location = new System.Drawing.Point(131, 41);
            this.lstInclude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstInclude.Name = "lstInclude";
            this.lstInclude.Size = new System.Drawing.Size(70, 148);
            this.lstInclude.TabIndex = 6;
            // 
            // cmdClearReport
            // 
            this.cmdClearReport.Location = new System.Drawing.Point(19, 144);
            this.cmdClearReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdClearReport.Name = "cmdClearReport";
            this.cmdClearReport.Size = new System.Drawing.Size(83, 28);
            this.cmdClearReport.TabIndex = 5;
            this.cmdClearReport.Text = "Clear";
            this.cmdClearReport.UseVisualStyleBackColor = true;
            // 
            // cmdIncludeAll
            // 
            this.cmdIncludeAll.Location = new System.Drawing.Point(19, 112);
            this.cmdIncludeAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdIncludeAll.Name = "cmdIncludeAll";
            this.cmdIncludeAll.Size = new System.Drawing.Size(83, 25);
            this.cmdIncludeAll.TabIndex = 4;
            this.cmdIncludeAll.Text = "Include All";
            this.cmdIncludeAll.UseVisualStyleBackColor = true;
            // 
            // cmdAddPrefix
            // 
            this.cmdAddPrefix.Location = new System.Drawing.Point(58, 76);
            this.cmdAddPrefix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdAddPrefix.Name = "cmdAddPrefix";
            this.cmdAddPrefix.Size = new System.Drawing.Size(43, 28);
            this.cmdAddPrefix.TabIndex = 3;
            this.cmdAddPrefix.Text = "-->";
            this.cmdAddPrefix.UseVisualStyleBackColor = true;
            // 
            // cboRemovePrefix
            // 
            this.cboRemovePrefix.Location = new System.Drawing.Point(19, 76);
            this.cboRemovePrefix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboRemovePrefix.Name = "cboRemovePrefix";
            this.cboRemovePrefix.Size = new System.Drawing.Size(41, 28);
            this.cboRemovePrefix.TabIndex = 2;
            this.cboRemovePrefix.Text = "<--";
            this.cboRemovePrefix.UseVisualStyleBackColor = true;
            // 
            // cboInclude
            // 
            this.cboInclude.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboInclude.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboInclude.FormattingEnabled = true;
            this.cboInclude.Location = new System.Drawing.Point(20, 43);
            this.cboInclude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboInclude.Name = "cboInclude";
            this.cboInclude.Size = new System.Drawing.Size(81, 24);
            this.cboInclude.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Prefixes to Include";
            // 
            // toggleLock
            // 
            this.toggleLock.Appearance = System.Windows.Forms.Appearance.Button;
            this.toggleLock.AutoSize = true;
            this.toggleLock.Location = new System.Drawing.Point(652, 80);
            this.toggleLock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toggleLock.Name = "toggleLock";
            this.toggleLock.Size = new System.Drawing.Size(56, 26);
            this.toggleLock.TabIndex = 16;
            this.toggleLock.Text = "Locked";
            this.toggleLock.UseVisualStyleBackColor = true;
            this.toggleLock.Visible = false;
            // 
            // navPrefixes
            // 
            this.navPrefixes.AddNewItem = null;
            this.navPrefixes.CountItem = this.bindingNavigatorCountItem;
            this.navPrefixes.DeleteItem = null;
            this.navPrefixes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navPrefixes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.navPrefixes.Location = new System.Drawing.Point(0, 783);
            this.navPrefixes.MoveFirstItem = null;
            this.navPrefixes.MoveLastItem = null;
            this.navPrefixes.MoveNextItem = null;
            this.navPrefixes.MovePreviousItem = null;
            this.navPrefixes.Name = "navPrefixes";
            this.navPrefixes.PositionItem = this.bindingNavigatorPositionItem;
            this.navPrefixes.Size = new System.Drawing.Size(1866, 25);
            this.navPrefixes.TabIndex = 17;
            this.navPrefixes.Text = "bindingNavigator1";
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1866, 24);
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAdd,
            this.toolStripDelete,
            this.toolStripDatasheet});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1866, 25);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripAdd
            // 
            this.toolStripAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAdd.Image")));
            this.toolStripAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAdd.Name = "toolStripAdd";
            this.toolStripAdd.Size = new System.Drawing.Size(42, 22);
            this.toolStripAdd.Text = "Add...";
            this.toolStripAdd.Click += new System.EventHandler(this.toolStripAdd_Click);
            // 
            // toolStripDelete
            // 
            this.toolStripDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDelete.Image")));
            this.toolStripDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDelete.Name = "toolStripDelete";
            this.toolStripDelete.Size = new System.Drawing.Size(53, 22);
            this.toolStripDelete.Text = "Delete...";
            this.toolStripDelete.Click += new System.EventHandler(this.toolStripDelete_Click);
            // 
            // toolStripDatasheet
            // 
            this.toolStripDatasheet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDatasheet.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDatasheet.Image")));
            this.toolStripDatasheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDatasheet.Name = "toolStripDatasheet";
            this.toolStripDatasheet.Size = new System.Drawing.Size(107, 22);
            this.toolStripDatasheet.Text = "View As Datasheet";
            this.toolStripDatasheet.Click += new System.EventHandler(this.toolStripDatasheet_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Lower";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Upper";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Description";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // PrefixList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1866, 808);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.navPrefixes);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.toggleLock);
            this.Controls.Add(this.panelReport);
            this.Controls.Add(this.chkShowWordings);
            this.Controls.Add(this.chkFilterByRange);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgvVariableInfo);
            this.Controls.Add(this.dgvVarNameRanges);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboGoTo);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PrefixList";
            this.Text = "Prefix List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PrefixList_FormClosed);
            this.Load += new System.EventHandler(this.PrefixList_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParallelPrefixes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVarNameRanges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVariableInfo)).EndInit();
            this.panelReport.ResumeLayout(false);
            this.panelReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navPrefixes)).EndInit();
            this.navPrefixes.ResumeLayout(false);
            this.navPrefixes.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboGoTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dgvParallelPrefixes;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.TextBox txtRelatedPrefixes;
        private System.Windows.Forms.TextBox txtProductType;
        private System.Windows.Forms.TextBox txtPrefixName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkInactive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvVarNameRanges;
        private System.Windows.Forms.DataGridView dgvVariableInfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkFilterByRange;
        private System.Windows.Forms.CheckBox chkShowWordings;
        private System.Windows.Forms.Panel panelReport;
        private System.Windows.Forms.Button cmdGenerateReport;
        private System.Windows.Forms.ListBox lstColumns;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox lstInclude;
        private System.Windows.Forms.Button cmdClearReport;
        private System.Windows.Forms.Button cmdIncludeAll;
        private System.Windows.Forms.Button cmdAddPrefix;
        private System.Windows.Forms.Button cboRemovePrefix;
        private System.Windows.Forms.ComboBox cboInclude;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox toggleLock;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.BindingNavigator navPrefixes;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripAdd;
        private System.Windows.Forms.ToolStripButton toolStripDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn chLower;
        private System.Windows.Forms.DataGridViewTextBoxColumn chUpper;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDescription;
        private System.Windows.Forms.DataGridViewComboBoxColumn chParallelPrefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ToolStripButton toolStripDatasheet;
    }
}