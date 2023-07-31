namespace SDIFrontEnd
{
    partial class ParallelVarReport
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
            this.cboPrefixes = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            this.chInclude = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chHundred = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRangeLower = new System.Windows.Forms.TextBox();
            this.txtRangeUpper = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkRangeInfo = new System.Windows.Forms.CheckBox();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdOpenFolder = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPrefixes
            // 
            this.cboPrefixes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboPrefixes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPrefixes.FormattingEnabled = true;
            this.cboPrefixes.Location = new System.Drawing.Point(72, 80);
            this.cboPrefixes.Margin = new System.Windows.Forms.Padding(4);
            this.cboPrefixes.Name = "cboPrefixes";
            this.cboPrefixes.Size = new System.Drawing.Size(51, 24);
            this.cboPrefixes.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(376, 24);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Prefix";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 113);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Columns";
            // 
            // dgvColumns
            // 
            this.dgvColumns.AllowUserToAddRows = false;
            this.dgvColumns.AllowUserToDeleteRows = false;
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chInclude,
            this.chHundred,
            this.chDescription});
            this.dgvColumns.Location = new System.Drawing.Point(72, 113);
            this.dgvColumns.Margin = new System.Windows.Forms.Padding(4);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.RowHeadersVisible = false;
            this.dgvColumns.Size = new System.Drawing.Size(287, 250);
            this.dgvColumns.TabIndex = 6;
            // 
            // chInclude
            // 
            this.chInclude.HeaderText = "";
            this.chInclude.Name = "chInclude";
            this.chInclude.Width = 30;
            // 
            // chHundred
            // 
            this.chHundred.HeaderText = "";
            this.chHundred.Name = "chHundred";
            this.chHundred.Width = 50;
            // 
            // chDescription
            // 
            this.chDescription.HeaderText = "Description";
            this.chDescription.Name = "chDescription";
            this.chDescription.Width = 200;
            // 
            // txtRangeLower
            // 
            this.txtRangeLower.Location = new System.Drawing.Point(72, 380);
            this.txtRangeLower.Margin = new System.Windows.Forms.Padding(4);
            this.txtRangeLower.Name = "txtRangeLower";
            this.txtRangeLower.Size = new System.Drawing.Size(36, 23);
            this.txtRangeLower.TabIndex = 7;
            this.txtRangeLower.Text = "0";
            this.txtRangeLower.Visible = false;
            // 
            // txtRangeUpper
            // 
            this.txtRangeUpper.Location = new System.Drawing.Point(126, 380);
            this.txtRangeUpper.Margin = new System.Windows.Forms.Padding(4);
            this.txtRangeUpper.Name = "txtRangeUpper";
            this.txtRangeUpper.Size = new System.Drawing.Size(33, 23);
            this.txtRangeUpper.TabIndex = 8;
            this.txtRangeUpper.Text = "100";
            this.txtRangeUpper.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 383);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "-";
            this.label1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 383);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Range";
            this.label4.Visible = false;
            // 
            // chkRangeInfo
            // 
            this.chkRangeInfo.AutoSize = true;
            this.chkRangeInfo.Location = new System.Drawing.Point(27, 411);
            this.chkRangeInfo.Margin = new System.Windows.Forms.Padding(4);
            this.chkRangeInfo.Name = "chkRangeInfo";
            this.chkRangeInfo.Size = new System.Drawing.Size(133, 20);
            this.chkRangeInfo.TabIndex = 11;
            this.chkRangeInfo.Text = "Include Range Info";
            this.chkRangeInfo.UseVisualStyleBackColor = true;
            this.chkRangeInfo.Visible = false;
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Location = new System.Drawing.Point(271, 371);
            this.cmdGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(88, 28);
            this.cmdGenerate.TabIndex = 12;
            this.cmdGenerate.Text = "Generate";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(66, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 33);
            this.label5.TabIndex = 13;
            this.label5.Text = "Parallel VarNames";
            // 
            // cmdOpenFolder
            // 
            this.cmdOpenFolder.Image = global::SDIFrontEnd.Properties.Resources.FolderOpened;
            this.cmdOpenFolder.Location = new System.Drawing.Point(233, 371);
            this.cmdOpenFolder.Name = "cmdOpenFolder";
            this.cmdOpenFolder.Size = new System.Drawing.Size(31, 28);
            this.cmdOpenFolder.TabIndex = 14;
            this.cmdOpenFolder.UseVisualStyleBackColor = true;
            this.cmdOpenFolder.Click += new System.EventHandler(this.cmdOpenFolder_Click);
            // 
            // ParallelVarReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 413);
            this.ControlBox = false;
            this.Controls.Add(this.cmdOpenFolder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdGenerate);
            this.Controls.Add(this.chkRangeInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRangeUpper);
            this.Controls.Add(this.txtRangeLower);
            this.Controls.Add(this.dgvColumns);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboPrefixes);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ParallelVarReport";
            this.Text = "Parallel VarName Report";
            this.Load += new System.EventHandler(this.ParallelVarReport_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPrefixes;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvColumns;
        private System.Windows.Forms.TextBox txtRangeLower;
        private System.Windows.Forms.TextBox txtRangeUpper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkRangeInfo;
        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chInclude;
        private System.Windows.Forms.DataGridViewTextBoxColumn chHundred;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDescription;
        private System.Windows.Forms.Button cmdOpenFolder;
    }
}