namespace SDIFrontEnd
{
    partial class SurveyLanguages
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.chLangID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chSurvID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitle = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chLangID,
            this.chID,
            this.chSurvID});
            this.dgv.Location = new System.Drawing.Point(14, 76);
            this.dgv.Margin = new System.Windows.Forms.Padding(4);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(276, 273);
            this.dgv.TabIndex = 0;
            this.dgv.VirtualMode = true;
            // 
            // chLangID
            // 
            this.chLangID.HeaderText = "Language";
            this.chLangID.Name = "chLangID";
            this.chLangID.Width = 68;
            // 
            // chID
            // 
            this.chID.HeaderText = "ID";
            this.chID.Name = "chID";
            this.chID.Visible = false;
            this.chID.Width = 43;
            // 
            // chSurvID
            // 
            this.chSurvID.HeaderText = "SurvID";
            this.chSurvID.Name = "chSurvID";
            this.chSurvID.Visible = false;
            this.chSurvID.Width = 65;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(14, 30);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(230, 33);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Survey Languages";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.newLanguageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(303, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // newLanguageToolStripMenuItem
            // 
            this.newLanguageToolStripMenuItem.Name = "newLanguageToolStripMenuItem";
            this.newLanguageToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.newLanguageToolStripMenuItem.Text = "New Language...";
            this.newLanguageToolStripMenuItem.Click += new System.EventHandler(this.newLanguageToolStripMenuItem_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 43;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "SurvID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 65;
            // 
            // SurveyLanguages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 366);
            this.ControlBox = false;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SurveyLanguages";
            this.Text = "Survey Languages";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newLanguageToolStripMenuItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn chLangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn chID;
        private System.Windows.Forms.DataGridViewTextBoxColumn chSurvID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}