namespace SDIFrontEnd
{
    partial class SurveyList
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chSurveyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chUserState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chProducts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chLanguages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chReRun = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chHide = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chSurveyCode,
            this.chTitle,
            this.chType,
            this.chMode,
            this.chUserState,
            this.chProducts,
            this.chLanguages,
            this.chFileName,
            this.chReRun,
            this.chHide,
            this.chLocked});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv.Location = new System.Drawing.Point(0, 24);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.Size = new System.Drawing.Size(1300, 461);
            this.dgv.TabIndex = 0;
            this.dgv.VirtualMode = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1300, 24);
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
            // chSurveyCode
            // 
            this.chSurveyCode.HeaderText = "Survey Code";
            this.chSurveyCode.Name = "chSurveyCode";
            // 
            // chTitle
            // 
            this.chTitle.HeaderText = "Title";
            this.chTitle.Name = "chTitle";
            this.chTitle.Width = 200;
            // 
            // chType
            // 
            this.chType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chType.HeaderText = "Type";
            this.chType.Name = "chType";
            this.chType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // chMode
            // 
            this.chMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chMode.HeaderText = "Mode";
            this.chMode.Name = "chMode";
            this.chMode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chMode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chMode.Width = 75;
            // 
            // chUserState
            // 
            this.chUserState.HeaderText = "User States";
            this.chUserState.Name = "chUserState";
            this.chUserState.ReadOnly = true;
            this.chUserState.Width = 150;
            // 
            // chProducts
            // 
            this.chProducts.HeaderText = "Products";
            this.chProducts.Name = "chProducts";
            this.chProducts.ReadOnly = true;
            this.chProducts.Width = 150;
            // 
            // chLanguages
            // 
            this.chLanguages.HeaderText = "Languages";
            this.chLanguages.Name = "chLanguages";
            this.chLanguages.ReadOnly = true;
            this.chLanguages.Width = 150;
            // 
            // chFileName
            // 
            this.chFileName.HeaderText = "File Name";
            this.chFileName.Name = "chFileName";
            this.chFileName.Width = 200;
            // 
            // chReRun
            // 
            this.chReRun.HeaderText = "ReRun";
            this.chReRun.Name = "chReRun";
            this.chReRun.Width = 50;
            // 
            // chHide
            // 
            this.chHide.HeaderText = "Hide";
            this.chHide.Name = "chHide";
            this.chHide.Width = 50;
            // 
            // chLocked
            // 
            this.chLocked.HeaderText = "Locked";
            this.chLocked.Name = "chLocked";
            this.chLocked.ReadOnly = true;
            this.chLocked.Width = 50;
            // 
            // SurveyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 485);
            this.ControlBox = false;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SurveyList";
            this.Text = "Survey Details";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn chSurveyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn chTitle;
        private System.Windows.Forms.DataGridViewComboBoxColumn chType;
        private System.Windows.Forms.DataGridViewComboBoxColumn chMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn chUserState;
        private System.Windows.Forms.DataGridViewTextBoxColumn chProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn chLanguages;
        private System.Windows.Forms.DataGridViewTextBoxColumn chFileName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chReRun;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chHide;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chLocked;
    }
}