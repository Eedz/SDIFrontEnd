namespace ISISFrontEnd
{
    partial class SurveyCheckTracking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SurveyCheckTracking));
            this.dgvSurveys = new System.Windows.Forms.DataGridView();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.cboCheckType = new System.Windows.Forms.ComboBox();
            this.cboCheckInit = new System.Windows.Forms.ComboBox();
            this.cboSurvey = new System.Windows.Forms.ComboBox();
            this.dgvRefSurveys = new System.Windows.Forms.DataGridView();
            this.dtpCheckDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.navRecords = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.tglLock = new System.Windows.Forms.CheckBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblRecordStatus = new System.Windows.Forms.Label();
            this.cmdClearFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurveys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefSurveys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navRecords)).BeginInit();
            this.navRecords.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(3, 2);
            // 
            // dgvSurveys
            // 
            this.dgvSurveys.AllowUserToAddRows = false;
            this.dgvSurveys.AllowUserToDeleteRows = false;
            this.dgvSurveys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSurveys.Location = new System.Drawing.Point(30, 101);
            this.dgvSurveys.Name = "dgvSurveys";
            this.dgvSurveys.ReadOnly = true;
            this.dgvSurveys.RowHeadersVisible = false;
            this.dgvSurveys.Size = new System.Drawing.Size(139, 415);
            this.dgvSurveys.TabIndex = 0;
            this.dgvSurveys.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSurveys_CellClick);
            this.dgvSurveys.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSurveys_DataBindingComplete);
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(138, 8);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(46, 23);
            this.txtID.TabIndex = 1;
            // 
            // txtComments
            // 
            this.txtComments.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComments.Location = new System.Drawing.Point(138, 303);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(226, 99);
            this.txtComments.TabIndex = 5;
            // 
            // cboCheckType
            // 
            this.cboCheckType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCheckType.FormattingEnabled = true;
            this.cboCheckType.Location = new System.Drawing.Point(138, 34);
            this.cboCheckType.Name = "cboCheckType";
            this.cboCheckType.Size = new System.Drawing.Size(164, 24);
            this.cboCheckType.TabIndex = 7;
            // 
            // cboCheckInit
            // 
            this.cboCheckInit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCheckInit.FormattingEnabled = true;
            this.cboCheckInit.Location = new System.Drawing.Point(138, 89);
            this.cboCheckInit.Name = "cboCheckInit";
            this.cboCheckInit.Size = new System.Drawing.Size(164, 24);
            this.cboCheckInit.TabIndex = 8;
            // 
            // cboSurvey
            // 
            this.cboSurvey.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSurvey.FormattingEnabled = true;
            this.cboSurvey.Location = new System.Drawing.Point(138, 118);
            this.cboSurvey.Name = "cboSurvey";
            this.cboSurvey.Size = new System.Drawing.Size(164, 24);
            this.cboSurvey.TabIndex = 11;
            // 
            // dgvRefSurveys
            // 
            this.dgvRefSurveys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefSurveys.Location = new System.Drawing.Point(138, 147);
            this.dgvRefSurveys.MultiSelect = false;
            this.dgvRefSurveys.Name = "dgvRefSurveys";
            this.dgvRefSurveys.RowHeadersWidth = 20;
            this.dgvRefSurveys.Size = new System.Drawing.Size(226, 150);
            this.dgvRefSurveys.TabIndex = 13;
            this.dgvRefSurveys.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRefSurveys_CellValueChanged);
            this.dgvRefSurveys.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvRefSurveys_DataError);
            this.dgvRefSurveys.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvRefSurveys_RowsRemoved);
            this.dgvRefSurveys.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvRefSurveys_UserDeletingRow);
            // 
            // dtpCheckDate
            // 
            this.dtpCheckDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckDate.Location = new System.Drawing.Point(138, 60);
            this.dtpCheckDate.Name = "dtpCheckDate";
            this.dtpCheckDate.Size = new System.Drawing.Size(164, 23);
            this.dtpCheckDate.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(99, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(101, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(94, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(88, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 16);
            this.label10.TabIndex = 26;
            this.label10.Text = "Survey";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 16);
            this.label11.TabIndex = 27;
            this.label11.Text = "Reference Survey(s)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(66, 303);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 16);
            this.label12.TabIndex = 28;
            this.label12.Text = "Comments";
            // 
            // navRecords
            // 
            this.navRecords.AddNewItem = null;
            this.navRecords.CountItem = this.bindingNavigatorCountItem;
            this.navRecords.DeleteItem = null;
            this.navRecords.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navRecords.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.navRecords.Location = new System.Drawing.Point(0, 546);
            this.navRecords.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.navRecords.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.navRecords.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.navRecords.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.navRecords.Name = "navRecords";
            this.navRecords.PositionItem = this.bindingNavigatorPositionItem;
            this.navRecords.Size = new System.Drawing.Size(754, 25);
            this.navRecords.TabIndex = 29;
            this.navRecords.Text = "bindingNavigator1";
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(293, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(282, 33);
            this.label13.TabIndex = 30;
            this.label13.Text = "Survey Check Tracking";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(26, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(143, 19);
            this.label14.TabIndex = 31;
            this.label14.Text = "Select Survey Filter";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(665, 39);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 33;
            this.cmdAdd.Text = "New Record";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(665, 68);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 34;
            this.cmdDelete.Text = "Delete Record";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // tglLock
            // 
            this.tglLock.Appearance = System.Windows.Forms.Appearance.Button;
            this.tglLock.AutoSize = true;
            this.tglLock.Location = new System.Drawing.Point(699, 10);
            this.tglLock.Name = "tglLock";
            this.tglLock.Size = new System.Drawing.Size(41, 23);
            this.tglLock.TabIndex = 35;
            this.tglLock.Text = "Lock";
            this.tglLock.UseVisualStyleBackColor = true;
            this.tglLock.CheckedChanged += new System.EventHandler(this.tglLock_CheckedChanged);
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMain.Controls.Add(this.label12);
            this.panelMain.Controls.Add(this.label10);
            this.panelMain.Controls.Add(this.label4);
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.dtpCheckDate);
            this.panelMain.Controls.Add(this.dgvRefSurveys);
            this.panelMain.Controls.Add(this.label11);
            this.panelMain.Controls.Add(this.cboSurvey);
            this.panelMain.Controls.Add(this.cboCheckInit);
            this.panelMain.Controls.Add(this.cboCheckType);
            this.panelMain.Controls.Add(this.txtComments);
            this.panelMain.Controls.Add(this.txtID);
            this.panelMain.Location = new System.Drawing.Point(185, 101);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(390, 415);
            this.panelMain.TabIndex = 36;
            // 
            // lblRecordStatus
            // 
            this.lblRecordStatus.AutoSize = true;
            this.lblRecordStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordStatus.Location = new System.Drawing.Point(182, 79);
            this.lblRecordStatus.Name = "lblRecordStatus";
            this.lblRecordStatus.Size = new System.Drawing.Size(88, 16);
            this.lblRecordStatus.TabIndex = 37;
            this.lblRecordStatus.Text = "Record Status";
            // 
            // cmdClearFilter
            // 
            this.cmdClearFilter.Location = new System.Drawing.Point(30, 53);
            this.cmdClearFilter.Name = "cmdClearFilter";
            this.cmdClearFilter.Size = new System.Drawing.Size(37, 23);
            this.cmdClearFilter.TabIndex = 38;
            this.cmdClearFilter.Text = "All";
            this.cmdClearFilter.UseVisualStyleBackColor = true;
            this.cmdClearFilter.Click += new System.EventHandler(this.cmdClearFilter_Click);
            // 
            // SurveyCheckTracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 571);
            this.Controls.Add(this.cmdClearFilter);
            this.Controls.Add(this.lblRecordStatus);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.tglLock);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.navRecords);
            this.Controls.Add(this.dgvSurveys);
            this.Name = "SurveyCheckTracking";
            this.Text = "SurveyCheckTracking";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SurveyCheckTracking_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SurveyCheckTracking_FormClosed);
            this.Controls.SetChildIndex(this.dgvSurveys, 0);
            this.Controls.SetChildIndex(this.navRecords, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.tglLock, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.panelMain, 0);
            this.Controls.SetChildIndex(this.lblRecordStatus, 0);
            this.Controls.SetChildIndex(this.cmdClearFilter, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurveys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefSurveys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navRecords)).EndInit();
            this.navRecords.ResumeLayout(false);
            this.navRecords.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSurveys;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.ComboBox cboCheckType;
        private System.Windows.Forms.ComboBox cboCheckInit;
        private System.Windows.Forms.ComboBox cboSurvey;
        private System.Windows.Forms.DataGridView dgvRefSurveys;
        private System.Windows.Forms.DateTimePicker dtpCheckDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.BindingNavigator navRecords;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.CheckBox tglLock;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblRecordStatus;
        private System.Windows.Forms.Button cmdClearFilter;
    }
}