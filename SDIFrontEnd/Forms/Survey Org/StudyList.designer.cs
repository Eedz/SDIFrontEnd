namespace SDIFrontEnd
{
    partial class StudyList
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chStudyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chAgeGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chCountryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chISOCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chLanguages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chCohort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chStudyName,
            this.chCountry,
            this.chAgeGroup,
            this.chCountryCode,
            this.chISOCode,
            this.chLanguages,
            this.chCohort});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(838, 461);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvSurveys_CellValidating);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvSurveys_DataError);
            this.dataGridView1.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSurveys_RowLeave);
            this.dataGridView1.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSurveys_RowValidated);
            // 
            // chStudyName
            // 
            this.chStudyName.HeaderText = "Study";
            this.chStudyName.Name = "chStudyName";
            this.chStudyName.Width = 150;
            // 
            // chCountry
            // 
            this.chCountry.HeaderText = "Country";
            this.chCountry.Name = "chCountry";
            this.chCountry.Width = 150;
            // 
            // chAgeGroup
            // 
            this.chAgeGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chAgeGroup.HeaderText = "Age Group";
            this.chAgeGroup.Name = "chAgeGroup";
            this.chAgeGroup.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chAgeGroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // chCountryCode
            // 
            this.chCountryCode.HeaderText = "Country Code";
            this.chCountryCode.Name = "chCountryCode";
            this.chCountryCode.ReadOnly = true;
            // 
            // chISOCode
            // 
            this.chISOCode.HeaderText = "ISO Code";
            this.chISOCode.Name = "chISOCode";
            this.chISOCode.Width = 85;
            // 
            // chLanguages
            // 
            this.chLanguages.HeaderText = "Languages";
            this.chLanguages.Name = "chLanguages";
            this.chLanguages.Width = 150;
            // 
            // chCohort
            // 
            this.chCohort.HeaderText = "Cohort";
            this.chCohort.Name = "chCohort";
            this.chCohort.Width = 75;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(838, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.backToolStripMenuItem.Text = "<- Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Survey Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Title";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "User States";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Products";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Languages";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "File Name";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // StudyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 485);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StudyList";
            this.Text = "Survey Details";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn chStudyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCountry;
        private System.Windows.Forms.DataGridViewComboBoxColumn chAgeGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCountryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn chISOCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn chLanguages;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCohort;
    }
}