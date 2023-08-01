namespace SDIFrontEnd
{
    partial class PrefixListSheet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPrefixes = new System.Windows.Forms.DataGridView();
            this.chPrefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chPrefixName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chProductType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chRelatedPrefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chComments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chInactive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvRanges = new System.Windows.Forms.DataGridView();
            this.chLower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chUpper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chRangeDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.formViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrefixes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanges)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPrefixes
            // 
            this.dgvPrefixes.AllowUserToAddRows = false;
            this.dgvPrefixes.AllowUserToDeleteRows = false;
            this.dgvPrefixes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvPrefixes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrefixes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chPrefix,
            this.chPrefixName,
            this.chProductType,
            this.chRelatedPrefix,
            this.chDescription,
            this.chComments,
            this.chInactive});
            this.dgvPrefixes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrefixes.Location = new System.Drawing.Point(0, 0);
            this.dgvPrefixes.Name = "dgvPrefixes";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrefixes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrefixes.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPrefixes.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dgvPrefixes.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrefixes.Size = new System.Drawing.Size(1000, 541);
            this.dgvPrefixes.TabIndex = 0;
            this.dgvPrefixes.VirtualMode = true;
            this.dgvPrefixes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrefixes_RowEnter);
            // 
            // chPrefix
            // 
            this.chPrefix.HeaderText = "Prefix";
            this.chPrefix.Name = "chPrefix";
            this.chPrefix.Width = 50;
            // 
            // chPrefixName
            // 
            this.chPrefixName.HeaderText = "Prefix Name";
            this.chPrefixName.Name = "chPrefixName";
            // 
            // chProductType
            // 
            this.chProductType.HeaderText = "Product Type";
            this.chProductType.Name = "chProductType";
            this.chProductType.Width = 90;
            // 
            // chRelatedPrefix
            // 
            this.chRelatedPrefix.HeaderText = "See Also";
            this.chRelatedPrefix.Name = "chRelatedPrefix";
            this.chRelatedPrefix.Width = 80;
            // 
            // chDescription
            // 
            this.chDescription.HeaderText = "Description";
            this.chDescription.Name = "chDescription";
            this.chDescription.Width = 200;
            // 
            // chComments
            // 
            this.chComments.HeaderText = "Comments";
            this.chComments.Name = "chComments";
            this.chComments.Width = 200;
            // 
            // chInactive
            // 
            this.chInactive.HeaderText = "Inactive?";
            this.chInactive.Name = "chInactive";
            this.chInactive.Width = 75;
            // 
            // dgvRanges
            // 
            this.dgvRanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRanges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chLower,
            this.chUpper,
            this.chRangeDescription});
            this.dgvRanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRanges.Location = new System.Drawing.Point(0, 0);
            this.dgvRanges.Name = "dgvRanges";
            this.dgvRanges.Size = new System.Drawing.Size(345, 541);
            this.dgvRanges.TabIndex = 1;
            this.dgvRanges.VirtualMode = true;
            // 
            // chLower
            // 
            this.chLower.HeaderText = "Lower";
            this.chLower.Name = "chLower";
            // 
            // chUpper
            // 
            this.chUpper.HeaderText = "Upper";
            this.chUpper.Name = "chUpper";
            // 
            // chRangeDescription
            // 
            this.chRangeDescription.HeaderText = "Description";
            this.chRangeDescription.Name = "chRangeDescription";
            this.chRangeDescription.Width = 200;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.formViewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1347, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvPrefixes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvRanges);
            this.splitContainer1.Size = new System.Drawing.Size(1347, 541);
            this.splitContainer1.SplitterDistance = 1000;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 3;
            // 
            // formViewToolStripMenuItem
            // 
            this.formViewToolStripMenuItem.Name = "formViewToolStripMenuItem";
            this.formViewToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.formViewToolStripMenuItem.Text = "Form View";
            this.formViewToolStripMenuItem.Click += new System.EventHandler(this.formViewToolStripMenuItem_Click);
            // 
            // PrefixListSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1347, 565);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PrefixListSheet";
            this.Text = "Prefix List (Datasheet)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PrefixListSheet_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrefixes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanges)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPrefixes;
        private System.Windows.Forms.DataGridView dgvRanges;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn chPrefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn chPrefixName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chProductType;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRelatedPrefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn chComments;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chInactive;
        private System.Windows.Forms.DataGridViewTextBoxColumn chLower;
        private System.Windows.Forms.DataGridViewTextBoxColumn chUpper;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRangeDescription;
        private System.Windows.Forms.ToolStripMenuItem formViewToolStripMenuItem;
    }
}