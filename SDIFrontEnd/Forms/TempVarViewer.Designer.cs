namespace SDIFrontEnd
{
    partial class TempVarViewer
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
            this.cboSurveyFilter = new System.Windows.Forms.ComboBox();
            this.dgvTempVars = new System.Windows.Forms.DataGridView();
            this.chSurveyList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chVarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chVarLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chTopic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chDomain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdClearFilter = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempVars)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboSurveyFilter
            // 
            this.cboSurveyFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboSurveyFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSurveyFilter.FormattingEnabled = true;
            this.cboSurveyFilter.Location = new System.Drawing.Point(81, 30);
            this.cboSurveyFilter.Margin = new System.Windows.Forms.Padding(4);
            this.cboSurveyFilter.Name = "cboSurveyFilter";
            this.cboSurveyFilter.Size = new System.Drawing.Size(115, 26);
            this.cboSurveyFilter.TabIndex = 0;
            // 
            // dgvTempVars
            // 
            this.dgvTempVars.AllowUserToAddRows = false;
            this.dgvTempVars.AllowUserToDeleteRows = false;
            this.dgvTempVars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTempVars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTempVars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chSurveyList,
            this.chVarName,
            this.chVarLabel,
            this.chContent,
            this.chTopic,
            this.chDomain,
            this.chProduct});
            this.dgvTempVars.Location = new System.Drawing.Point(13, 64);
            this.dgvTempVars.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTempVars.Name = "dgvTempVars";
            this.dgvTempVars.ReadOnly = true;
            this.dgvTempVars.RowHeadersVisible = false;
            this.dgvTempVars.Size = new System.Drawing.Size(1410, 565);
            this.dgvTempVars.TabIndex = 1;
            // 
            // chSurveyList
            // 
            this.chSurveyList.HeaderText = "Surveys";
            this.chSurveyList.Name = "chSurveyList";
            this.chSurveyList.ReadOnly = true;
            this.chSurveyList.Width = 85;
            // 
            // chVarName
            // 
            this.chVarName.HeaderText = "VarName";
            this.chVarName.Name = "chVarName";
            this.chVarName.ReadOnly = true;
            this.chVarName.Width = 94;
            // 
            // chVarLabel
            // 
            this.chVarLabel.HeaderText = "VarLabel";
            this.chVarLabel.Name = "chVarLabel";
            this.chVarLabel.ReadOnly = true;
            this.chVarLabel.Width = 88;
            // 
            // chContent
            // 
            this.chContent.HeaderText = "Content";
            this.chContent.Name = "chContent";
            this.chContent.ReadOnly = true;
            this.chContent.Width = 84;
            // 
            // chTopic
            // 
            this.chTopic.HeaderText = "Topic";
            this.chTopic.Name = "chTopic";
            this.chTopic.ReadOnly = true;
            this.chTopic.Width = 68;
            // 
            // chDomain
            // 
            this.chDomain.HeaderText = "Domain";
            this.chDomain.Name = "chDomain";
            this.chDomain.ReadOnly = true;
            this.chDomain.Width = 82;
            // 
            // chProduct
            // 
            this.chProduct.HeaderText = "Product";
            this.chProduct.Name = "chProduct";
            this.chProduct.ReadOnly = true;
            this.chProduct.Width = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Survey";
            // 
            // cmdClearFilter
            // 
            this.cmdClearFilter.Location = new System.Drawing.Point(203, 29);
            this.cmdClearFilter.Name = "cmdClearFilter";
            this.cmdClearFilter.Size = new System.Drawing.Size(33, 27);
            this.cmdClearFilter.TabIndex = 3;
            this.cmdClearFilter.Text = "X";
            this.cmdClearFilter.UseVisualStyleBackColor = true;
            this.cmdClearFilter.Click += new System.EventHandler(this.cmdClearFilter_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1436, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // TempVarViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 642);
            this.Controls.Add(this.cmdClearFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTempVars);
            this.Controls.Add(this.cboSurveyFilter);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TempVarViewer";
            this.Text = "TempVar Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempVars)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSurveyFilter;
        private System.Windows.Forms.DataGridView dgvTempVars;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdClearFilter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn chSurveyList;
        private System.Windows.Forms.DataGridViewTextBoxColumn chVarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chVarLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn chContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn chTopic;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDomain;
        private System.Windows.Forms.DataGridViewTextBoxColumn chProduct;
    }
}