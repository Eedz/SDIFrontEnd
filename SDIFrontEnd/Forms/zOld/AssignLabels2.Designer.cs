namespace SDIFrontEnd
{
    partial class AssignLabels2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssignLabels2));
            this.dgvVars = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelLibrary = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripUnusedVars = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripFilterVars = new System.Windows.Forms.ToolStripButton();
            this.toolStripExport = new System.Windows.Forms.ToolStrip();
            this.toolStripDisplayBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripExportBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripQ = new System.Windows.Forms.ToolStripButton();
            this.toolStripT = new System.Windows.Forms.ToolStripButton();
            this.toolStripC = new System.Windows.Forms.ToolStripButton();
            this.toolStripF = new System.Windows.Forms.ToolStripButton();
            this.cboGoToVar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitle = new System.Windows.Forms.Label();
            this.chRefVarname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chVarLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chContent = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chTopic = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chDomain = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chProduct = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVars)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVars
            // 
            this.dgvVars.AllowUserToAddRows = false;
            this.dgvVars.AllowUserToDeleteRows = false;
            this.dgvVars.AllowUserToResizeRows = false;
            this.dgvVars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvVars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chRefVarname,
            this.chVarLabel,
            this.chContent,
            this.chTopic,
            this.chDomain,
            this.chProduct});
            this.dgvVars.Location = new System.Drawing.Point(14, 139);
            this.dgvVars.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvVars.Name = "dgvVars";
            this.dgvVars.RowHeadersVisible = false;
            this.dgvVars.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvVars.Size = new System.Drawing.Size(1219, 502);
            this.dgvVars.TabIndex = 0;
            this.dgvVars.VirtualMode = true;
            this.dgvVars.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvVars_DataBindingComplete);
            this.dgvVars.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvVars_DataError);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1477, 24);
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelLibrary,
            this.toolStripSeparator1,
            this.toolStripUnusedVars,
            this.toolStripSeparator2,
            this.toolStripFilterVars});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1477, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabelLibrary
            // 
            this.toolStripLabelLibrary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabelLibrary.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabelLibrary.Image")));
            this.toolStripLabelLibrary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabelLibrary.Name = "toolStripLabelLibrary";
            this.toolStripLabelLibrary.Size = new System.Drawing.Size(78, 22);
            this.toolStripLabelLibrary.Text = "Label Library";
            this.toolStripLabelLibrary.Click += new System.EventHandler(this.toolStripLabelLibrary_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripUnusedVars
            // 
            this.toolStripUnusedVars.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripUnusedVars.Image = ((System.Drawing.Image)(resources.GetObject("toolStripUnusedVars.Image")));
            this.toolStripUnusedVars.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripUnusedVars.Name = "toolStripUnusedVars";
            this.toolStripUnusedVars.Size = new System.Drawing.Size(75, 22);
            this.toolStripUnusedVars.Text = "Unused Vars";
            this.toolStripUnusedVars.Click += new System.EventHandler(this.toolStripUnusedVars_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripFilterVars
            // 
            this.toolStripFilterVars.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripFilterVars.Image = ((System.Drawing.Image)(resources.GetObject("toolStripFilterVars.Image")));
            this.toolStripFilterVars.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFilterVars.Name = "toolStripFilterVars";
            this.toolStripFilterVars.Size = new System.Drawing.Size(79, 22);
            this.toolStripFilterVars.Text = "Filter for Vars";
            this.toolStripFilterVars.Click += new System.EventHandler(this.toolStripFilterVars_Click);
            // 
            // toolStripExport
            // 
            this.toolStripExport.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDisplayBtn,
            this.toolStripExportBtn,
            this.toolStripSeparator3,
            this.toolStripQ,
            this.toolStripT,
            this.toolStripC,
            this.toolStripF});
            this.toolStripExport.Location = new System.Drawing.Point(0, 60);
            this.toolStripExport.Name = "toolStripExport";
            this.toolStripExport.Size = new System.Drawing.Size(204, 25);
            this.toolStripExport.TabIndex = 45;
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
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            // cboGoToVar
            // 
            this.cboGoToVar.FormattingEnabled = true;
            this.cboGoToVar.Location = new System.Drawing.Point(87, 108);
            this.cboGoToVar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboGoToVar.Name = "cboGoToVar";
            this.cboGoToVar.Size = new System.Drawing.Size(119, 24);
            this.cboGoToVar.TabIndex = 46;
            this.cboGoToVar.SelectedIndexChanged += new System.EventHandler(this.cboGoToVar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 47;
            this.label1.Text = "Go To Var";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "refVar";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "VarName";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "VarLabel";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "VarLabel";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Keywords";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(394, 95);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(398, 33);
            this.lblTitle.TabIndex = 48;
            this.lblTitle.Text = "Assign Topic and Content Labels";
            // 
            // chRefVarname
            // 
            this.chRefVarname.HeaderText = "refVarname";
            this.chRefVarname.Name = "chRefVarname";
            this.chRefVarname.Width = 101;
            // 
            // chVarLabel
            // 
            this.chVarLabel.HeaderText = "VarLabel";
            this.chVarLabel.Name = "chVarLabel";
            this.chVarLabel.Width = 83;
            // 
            // chContent
            // 
            this.chContent.HeaderText = "Content";
            this.chContent.Name = "chContent";
            this.chContent.Width = 58;
            // 
            // chTopic
            // 
            this.chTopic.HeaderText = "Topic";
            this.chTopic.Name = "chTopic";
            this.chTopic.Width = 45;
            // 
            // chDomain
            // 
            this.chDomain.HeaderText = "Domain";
            this.chDomain.Name = "chDomain";
            this.chDomain.Width = 57;
            // 
            // chProduct
            // 
            this.chProduct.HeaderText = "Product";
            this.chProduct.Name = "chProduct";
            this.chProduct.Width = 57;
            // 
            // AssignLabels2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1477, 750);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboGoToVar);
            this.Controls.Add(this.toolStripExport);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvVars);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AssignLabels2";
            this.Text = "AssignLabels";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AssignLabels_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVars)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripExport.ResumeLayout(false);
            this.toolStripExport.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVars;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripLabelLibrary;
        private System.Windows.Forms.ToolStripButton toolStripUnusedVars;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripFilterVars;
        private System.Windows.Forms.ToolStrip toolStripExport;
        private System.Windows.Forms.ToolStripButton toolStripDisplayBtn;
        private System.Windows.Forms.ToolStripButton toolStripExportBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripQ;
        private System.Windows.Forms.ToolStripButton toolStripT;
        private System.Windows.Forms.ToolStripButton toolStripC;
        private System.Windows.Forms.ToolStripButton toolStripF;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.ComboBox cboGoToVar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRefVarname;
        private System.Windows.Forms.DataGridViewTextBoxColumn chVarLabel;
        private System.Windows.Forms.DataGridViewComboBoxColumn chContent;
        private System.Windows.Forms.DataGridViewComboBoxColumn chTopic;
        private System.Windows.Forms.DataGridViewComboBoxColumn chDomain;
        private System.Windows.Forms.DataGridViewComboBoxColumn chProduct;
    }
}