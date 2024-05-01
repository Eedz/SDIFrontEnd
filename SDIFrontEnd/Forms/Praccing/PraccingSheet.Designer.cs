namespace SDIFrontEnd
{
    partial class PraccingSheet
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
            this.cmdOK = new System.Windows.Forms.Button();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSurvey = new System.Windows.Forms.ComboBox();
            this.rbWord = new System.Windows.Forms.RadioButton();
            this.rbExcel = new System.Windows.Forms.RadioButton();
            this.chkIncludeLegend = new System.Windows.Forms.CheckBox();
            this.dgvHighlightingRanges = new System.Windows.Forms.DataGridView();
            this.chLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chVarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chRange1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chRange2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chRange3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighlightingRanges)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(71, 137);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(87, 28);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lblSeparator
            // 
            this.lblSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeparator.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeparator.Location = new System.Drawing.Point(15, 125);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(204, 2);
            this.lblSeparator.TabIndex = 7;
            this.lblSeparator.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Survey";
            // 
            // cboSurvey
            // 
            this.cboSurvey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboSurvey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSurvey.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSurvey.FormattingEnabled = true;
            this.cboSurvey.Location = new System.Drawing.Point(77, 29);
            this.cboSurvey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSurvey.Name = "cboSurvey";
            this.cboSurvey.Size = new System.Drawing.Size(140, 24);
            this.cboSurvey.TabIndex = 5;
            // 
            // rbWord
            // 
            this.rbWord.AutoSize = true;
            this.rbWord.Checked = true;
            this.rbWord.Location = new System.Drawing.Point(71, 74);
            this.rbWord.Name = "rbWord";
            this.rbWord.Size = new System.Drawing.Size(56, 20);
            this.rbWord.TabIndex = 10;
            this.rbWord.TabStop = true;
            this.rbWord.Text = "Word";
            this.rbWord.UseVisualStyleBackColor = true;
            // 
            // rbExcel
            // 
            this.rbExcel.AutoSize = true;
            this.rbExcel.Location = new System.Drawing.Point(71, 100);
            this.rbExcel.Name = "rbExcel";
            this.rbExcel.Size = new System.Drawing.Size(54, 20);
            this.rbExcel.TabIndex = 11;
            this.rbExcel.Text = "Excel";
            this.rbExcel.UseVisualStyleBackColor = true;
            // 
            // chkIncludeLegend
            // 
            this.chkIncludeLegend.AutoSize = true;
            this.chkIncludeLegend.Location = new System.Drawing.Point(237, 30);
            this.chkIncludeLegend.Name = "chkIncludeLegend";
            this.chkIncludeLegend.Size = new System.Drawing.Size(112, 20);
            this.chkIncludeLegend.TabIndex = 12;
            this.chkIncludeLegend.Text = "Include Legend";
            this.chkIncludeLegend.UseVisualStyleBackColor = true;
            this.chkIncludeLegend.CheckedChanged += new System.EventHandler(this.chkIncludeLegend_CheckedChanged);
            // 
            // dgvHighlightingRanges
            // 
            this.dgvHighlightingRanges.AllowUserToAddRows = false;
            this.dgvHighlightingRanges.AllowUserToDeleteRows = false;
            this.dgvHighlightingRanges.AllowUserToResizeRows = false;
            this.dgvHighlightingRanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHighlightingRanges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chLabel,
            this.chVarName,
            this.chRange1,
            this.chRange2,
            this.chRange3});
            this.dgvHighlightingRanges.Enabled = false;
            this.dgvHighlightingRanges.Location = new System.Drawing.Point(237, 61);
            this.dgvHighlightingRanges.Name = "dgvHighlightingRanges";
            this.dgvHighlightingRanges.RowHeadersVisible = false;
            this.dgvHighlightingRanges.Size = new System.Drawing.Size(506, 113);
            this.dgvHighlightingRanges.TabIndex = 13;
            this.dgvHighlightingRanges.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvHighlightingRanges_CellValidating);
            // 
            // chLabel
            // 
            this.chLabel.HeaderText = "Label";
            this.chLabel.Name = "chLabel";
            // 
            // chVarName
            // 
            this.chVarName.HeaderText = "VarName";
            this.chVarName.Name = "chVarName";
            // 
            // chRange1
            // 
            this.chRange1.HeaderText = "Range 1";
            this.chRange1.Name = "chRange1";
            // 
            // chRange2
            // 
            this.chRange2.HeaderText = "Range 2";
            this.chRange2.Name = "chRange2";
            // 
            // chRange3
            // 
            this.chRange3.HeaderText = "Range 3";
            this.chRange3.Name = "chRange3";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(752, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // PraccingSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(222)))), ((int)(((byte)(116)))));
            this.ClientSize = new System.Drawing.Size(752, 182);
            this.ControlBox = false;
            this.Controls.Add(this.dgvHighlightingRanges);
            this.Controls.Add(this.chkIncludeLegend);
            this.Controls.Add(this.rbExcel);
            this.Controls.Add(this.rbWord);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.lblSeparator);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSurvey);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PraccingSheet";
            this.Text = "Praccing Sheet";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighlightingRanges)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label lblSeparator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSurvey;
        private System.Windows.Forms.RadioButton rbWord;
        private System.Windows.Forms.RadioButton rbExcel;
        private System.Windows.Forms.CheckBox chkIncludeLegend;
        private System.Windows.Forms.DataGridView dgvHighlightingRanges;
        private System.Windows.Forms.DataGridViewTextBoxColumn chLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn chVarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRange1;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRange2;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRange3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}