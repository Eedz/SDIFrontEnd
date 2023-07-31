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
            this.dgvTempVars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTempVars.Location = new System.Drawing.Point(13, 64);
            this.dgvTempVars.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTempVars.Name = "dgvTempVars";
            this.dgvTempVars.ReadOnly = true;
            this.dgvTempVars.Size = new System.Drawing.Size(1024, 501);
            this.dgvTempVars.TabIndex = 1;
            this.dgvTempVars.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTempVars_DataBindingComplete);
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
            this.menuStrip1.Size = new System.Drawing.Size(1067, 24);
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
            this.ClientSize = new System.Drawing.Size(1067, 623);
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
    }
}