namespace ISISFrontEnd
{
    partial class RenameVarsBulk
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameVarsBulk));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.groupScope = new System.Windows.Forms.GroupBox();
            this.optRefVarName = new System.Windows.Forms.RadioButton();
            this.optVarName = new System.Windows.Forms.RadioButton();
            this.groupSource = new System.Windows.Forms.GroupBox();
            this.optManual = new System.Windows.Forms.RadioButton();
            this.optFile = new System.Windows.Forms.RadioButton();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.cmdImport = new System.Windows.Forms.Button();
            this.dgvRenames = new System.Windows.Forms.DataGridView();
            this.chOldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chNewName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chVarLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chSurveysAffected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chBoth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chLocked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboChangedBy = new System.Windows.Forms.ComboBox();
            this.txtAuthorization = new System.Windows.Forms.TextBox();
            this.txtRationale = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.dgvNotifications = new System.Windows.Forms.DataGridView();
            this.chName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chkHidden = new System.Windows.Forms.CheckBox();
            this.chkPreFW = new System.Windows.Forms.CheckBox();
            this.chkDoNotDoc = new System.Windows.Forms.CheckBox();
            this.cmdRename = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFileInstructions = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupScope.SuspendLayout();
            this.groupSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRenames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotifications)).BeginInit();
            this.panelDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1363, 24);
            this.menuStrip1.TabIndex = 0;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bulk Variable Rename";
            // 
            // groupScope
            // 
            this.groupScope.Controls.Add(this.optRefVarName);
            this.groupScope.Controls.Add(this.optVarName);
            this.groupScope.Location = new System.Drawing.Point(11, 76);
            this.groupScope.Name = "groupScope";
            this.groupScope.Size = new System.Drawing.Size(188, 59);
            this.groupScope.TabIndex = 2;
            this.groupScope.TabStop = false;
            this.groupScope.Text = "Rename by...";
            // 
            // optRefVarName
            // 
            this.optRefVarName.AutoSize = true;
            this.optRefVarName.Location = new System.Drawing.Point(91, 28);
            this.optRefVarName.Name = "optRefVarName";
            this.optRefVarName.Size = new System.Drawing.Size(95, 20);
            this.optRefVarName.TabIndex = 1;
            this.optRefVarName.TabStop = true;
            this.optRefVarName.Text = "refVarName";
            this.optRefVarName.UseVisualStyleBackColor = true;
            this.optRefVarName.Click += new System.EventHandler(this.Scope_Click);
            // 
            // optVarName
            // 
            this.optVarName.AutoSize = true;
            this.optVarName.Location = new System.Drawing.Point(6, 28);
            this.optVarName.Name = "optVarName";
            this.optVarName.Size = new System.Drawing.Size(79, 20);
            this.optVarName.TabIndex = 0;
            this.optVarName.TabStop = true;
            this.optVarName.Text = "VarName";
            this.optVarName.UseVisualStyleBackColor = true;
            this.optVarName.Click += new System.EventHandler(this.Scope_Click);
            // 
            // groupSource
            // 
            this.groupSource.Controls.Add(this.optManual);
            this.groupSource.Controls.Add(this.optFile);
            this.groupSource.Location = new System.Drawing.Point(205, 76);
            this.groupSource.Name = "groupSource";
            this.groupSource.Size = new System.Drawing.Size(189, 59);
            this.groupSource.TabIndex = 3;
            this.groupSource.TabStop = false;
            this.groupSource.Text = "VarName Source";
            // 
            // optManual
            // 
            this.optManual.AutoSize = true;
            this.optManual.Location = new System.Drawing.Point(95, 28);
            this.optManual.Name = "optManual";
            this.optManual.Size = new System.Drawing.Size(87, 20);
            this.optManual.TabIndex = 1;
            this.optManual.Text = "Manual list";
            this.optManual.UseVisualStyleBackColor = true;
            this.optManual.Click += new System.EventHandler(this.Source_Click);
            // 
            // optFile
            // 
            this.optFile.AutoSize = true;
            this.optFile.Location = new System.Drawing.Point(12, 28);
            this.optFile.Name = "optFile";
            this.optFile.Size = new System.Drawing.Size(77, 20);
            this.optFile.TabIndex = 0;
            this.optFile.Text = "From file";
            this.optFile.UseVisualStyleBackColor = true;
            this.optFile.Click += new System.EventHandler(this.Source_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(11, 161);
            this.txtPath.Multiline = true;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(215, 36);
            this.txtPath.TabIndex = 4;
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Location = new System.Drawing.Point(232, 161);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(87, 36);
            this.cmdBrowse.TabIndex = 5;
            this.cmdBrowse.Text = "Browse...";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // cmdImport
            // 
            this.cmdImport.Location = new System.Drawing.Point(232, 203);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(87, 31);
            this.cmdImport.TabIndex = 6;
            this.cmdImport.Text = "Import List";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // dgvRenames
            // 
            this.dgvRenames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRenames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chOldName,
            this.chNewName,
            this.chVarLabel,
            this.chSurveysAffected,
            this.chBoth,
            this.chLocked});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRenames.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRenames.Location = new System.Drawing.Point(6, 24);
            this.dgvRenames.Name = "dgvRenames";
            this.dgvRenames.RowHeadersWidth = 25;
            this.dgvRenames.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRenames.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRenames.Size = new System.Drawing.Size(1257, 381);
            this.dgvRenames.TabIndex = 7;
            this.dgvRenames.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRenames_CellValidated);
            // 
            // chOldName
            // 
            this.chOldName.HeaderText = "Old Name";
            this.chOldName.Name = "chOldName";
            this.chOldName.Width = 80;
            // 
            // chNewName
            // 
            this.chNewName.HeaderText = "New Name";
            this.chNewName.Name = "chNewName";
            this.chNewName.Width = 80;
            // 
            // chVarLabel
            // 
            this.chVarLabel.HeaderText = "VarLabel";
            this.chVarLabel.Name = "chVarLabel";
            this.chVarLabel.ReadOnly = true;
            this.chVarLabel.Width = 150;
            // 
            // chSurveysAffected
            // 
            this.chSurveysAffected.HeaderText = "Surveys Affected";
            this.chSurveysAffected.Name = "chSurveysAffected";
            this.chSurveysAffected.Width = 200;
            // 
            // chBoth
            // 
            this.chBoth.HeaderText = "Surveys Containing Both";
            this.chBoth.Name = "chBoth";
            this.chBoth.ReadOnly = true;
            this.chBoth.Width = 200;
            // 
            // chLocked
            // 
            this.chLocked.HeaderText = "Locked Surveys";
            this.chLocked.Name = "chLocked";
            this.chLocked.ReadOnly = true;
            this.chLocked.Width = 200;
            // 
            // cboChangedBy
            // 
            this.cboChangedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboChangedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboChangedBy.FormattingEnabled = true;
            this.cboChangedBy.Location = new System.Drawing.Point(6, 433);
            this.cboChangedBy.Name = "cboChangedBy";
            this.cboChangedBy.Size = new System.Drawing.Size(121, 24);
            this.cboChangedBy.TabIndex = 8;
            // 
            // txtAuthorization
            // 
            this.txtAuthorization.Location = new System.Drawing.Point(133, 434);
            this.txtAuthorization.Name = "txtAuthorization";
            this.txtAuthorization.Size = new System.Drawing.Size(691, 23);
            this.txtAuthorization.TabIndex = 9;
            // 
            // txtRationale
            // 
            this.txtRationale.Location = new System.Drawing.Point(6, 479);
            this.txtRationale.Multiline = true;
            this.txtRationale.Name = "txtRationale";
            this.txtRationale.Size = new System.Drawing.Size(818, 63);
            this.txtRationale.TabIndex = 10;
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(6, 561);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(818, 45);
            this.txtSource.TabIndex = 11;
            // 
            // dgvNotifications
            // 
            this.dgvNotifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotifications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chName,
            this.chType});
            this.dgvNotifications.Location = new System.Drawing.Point(847, 433);
            this.dgvNotifications.Name = "dgvNotifications";
            this.dgvNotifications.RowHeadersWidth = 25;
            this.dgvNotifications.Size = new System.Drawing.Size(227, 254);
            this.dgvNotifications.TabIndex = 12;
            // 
            // chName
            // 
            this.chName.HeaderText = "Name";
            this.chName.Name = "chName";
            // 
            // chType
            // 
            this.chType.HeaderText = "Type";
            this.chType.Name = "chType";
            // 
            // chkHidden
            // 
            this.chkHidden.AutoSize = true;
            this.chkHidden.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHidden.Location = new System.Drawing.Point(138, 616);
            this.chkHidden.Name = "chkHidden";
            this.chkHidden.Size = new System.Drawing.Size(123, 20);
            this.chkHidden.TabIndex = 13;
            this.chkHidden.Text = "Hidden Change";
            this.chkHidden.UseVisualStyleBackColor = true;
            // 
            // chkPreFW
            // 
            this.chkPreFW.AutoSize = true;
            this.chkPreFW.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPreFW.Location = new System.Drawing.Point(6, 616);
            this.chkPreFW.Name = "chkPreFW";
            this.chkPreFW.Size = new System.Drawing.Size(126, 20);
            this.chkPreFW.TabIndex = 14;
            this.chkPreFW.Text = "Pre-FW Change";
            this.chkPreFW.UseVisualStyleBackColor = true;
            // 
            // chkDoNotDoc
            // 
            this.chkDoNotDoc.AutoSize = true;
            this.chkDoNotDoc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDoNotDoc.Location = new System.Drawing.Point(1115, 454);
            this.chkDoNotDoc.Name = "chkDoNotDoc";
            this.chkDoNotDoc.Size = new System.Drawing.Size(139, 20);
            this.chkDoNotDoc.TabIndex = 15;
            this.chkDoNotDoc.Text = "Do Not Document";
            this.chkDoNotDoc.UseVisualStyleBackColor = true;
            // 
            // cmdRename
            // 
            this.cmdRename.Location = new System.Drawing.Point(1115, 480);
            this.cmdRename.Name = "cmdRename";
            this.cmdRename.Size = new System.Drawing.Size(126, 40);
            this.cmdRename.TabIndex = 16;
            this.cmdRename.Text = "Rename";
            this.cmdRename.UseVisualStyleBackColor = true;
            this.cmdRename.Click += new System.EventHandler(this.cmdRename_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Source File";
            // 
            // lblFileInstructions
            // 
            this.lblFileInstructions.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileInstructions.Location = new System.Drawing.Point(326, 163);
            this.lblFileInstructions.Name = "lblFileInstructions";
            this.lblFileInstructions.Size = new System.Drawing.Size(468, 71);
            this.lblFileInstructions.TabIndex = 18;
            this.lblFileInstructions.Text = resources.GetString("lblFileInstructions.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Renames to perform";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(844, 414);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Notifications";
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.label9);
            this.panelDetails.Controls.Add(this.label8);
            this.panelDetails.Controls.Add(this.label7);
            this.panelDetails.Controls.Add(this.label6);
            this.panelDetails.Controls.Add(this.label5);
            this.panelDetails.Controls.Add(this.label4);
            this.panelDetails.Controls.Add(this.cmdRename);
            this.panelDetails.Controls.Add(this.chkDoNotDoc);
            this.panelDetails.Controls.Add(this.chkPreFW);
            this.panelDetails.Controls.Add(this.chkHidden);
            this.panelDetails.Controls.Add(this.dgvNotifications);
            this.panelDetails.Controls.Add(this.txtSource);
            this.panelDetails.Controls.Add(this.txtRationale);
            this.panelDetails.Controls.Add(this.txtAuthorization);
            this.panelDetails.Controls.Add(this.cboChangedBy);
            this.panelDetails.Controls.Add(this.dgvRenames);
            this.panelDetails.Location = new System.Drawing.Point(12, 240);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(1275, 690);
            this.panelDetails.TabIndex = 21;
            this.panelDetails.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 545);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "Source";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 458);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "Rationale";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(144, 415);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Authorization";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 414);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Changed By";
            // 
            // RenameVarsBulk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(177)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(1363, 942);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.lblFileInstructions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdImport);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.groupSource);
            this.Controls.Add(this.groupScope);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RenameVarsBulk";
            this.Text = "Bulk Rename";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupScope.ResumeLayout(false);
            this.groupScope.PerformLayout();
            this.groupSource.ResumeLayout(false);
            this.groupSource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRenames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotifications)).EndInit();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupScope;
        private System.Windows.Forms.RadioButton optRefVarName;
        private System.Windows.Forms.RadioButton optVarName;
        private System.Windows.Forms.GroupBox groupSource;
        private System.Windows.Forms.RadioButton optManual;
        private System.Windows.Forms.RadioButton optFile;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.DataGridView dgvRenames;
        private System.Windows.Forms.ComboBox cboChangedBy;
        private System.Windows.Forms.TextBox txtAuthorization;
        private System.Windows.Forms.TextBox txtRationale;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.DataGridView dgvNotifications;
        private System.Windows.Forms.CheckBox chkHidden;
        private System.Windows.Forms.CheckBox chkPreFW;
        private System.Windows.Forms.CheckBox chkDoNotDoc;
        private System.Windows.Forms.Button cmdRename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFileInstructions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewComboBoxColumn chName;
        private System.Windows.Forms.DataGridViewComboBoxColumn chType;
        private System.Windows.Forms.DataGridViewTextBoxColumn chOldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chNewName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chVarLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn chSurveysAffected;
        private System.Windows.Forms.DataGridViewTextBoxColumn chBoth;
        private System.Windows.Forms.DataGridViewTextBoxColumn chLocked;
    }
}