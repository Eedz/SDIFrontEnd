namespace SDIFrontEnd
{
    partial class CohortList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CohortList));
            this.cmdClose = new System.Windows.Forms.Button();
            this.dgvCohort = new System.Windows.Forms.DataGridView();
            this.chID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chCohort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chWebName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripAdd = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCohort)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(335, 322);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(60, 34);
            this.cmdClose.TabIndex = 10;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // dgvCohort
            // 
            this.dgvCohort.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCohort.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCohort.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chID,
            this.chCohort,
            this.chCode,
            this.chWebName});
            this.dgvCohort.Location = new System.Drawing.Point(0, 28);
            this.dgvCohort.Name = "dgvCohort";
            this.dgvCohort.Size = new System.Drawing.Size(407, 282);
            this.dgvCohort.TabIndex = 11;
            this.dgvCohort.VirtualMode = true;
            this.dgvCohort.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.dgvCohort_CancelRowEdit);
            this.dgvCohort.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvCohort_CellValueNeeded);
            this.dgvCohort.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvCohort_CellValuePushed);
            this.dgvCohort.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvCohort_DataError);
            this.dgvCohort.NewRowNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvCohort_NewRowNeeded);
            this.dgvCohort.RowDirtyStateNeeded += new System.Windows.Forms.QuestionEventHandler(this.dgvCohort_RowDirtyStateNeeded);
            this.dgvCohort.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCohort_RowValidated);
            this.dgvCohort.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvCohort_UserDeletingRow);
            // 
            // chID
            // 
            this.chID.HeaderText = "ID";
            this.chID.Name = "chID";
            this.chID.Width = 43;
            // 
            // chCohort
            // 
            this.chCohort.HeaderText = "Cohort";
            this.chCohort.Name = "chCohort";
            this.chCohort.Width = 63;
            // 
            // chCode
            // 
            this.chCode.HeaderText = "Code";
            this.chCode.Name = "chCode";
            this.chCode.Width = 57;
            // 
            // chWebName
            // 
            this.chWebName.HeaderText = "Web Name";
            this.chWebName.Name = "chWebName";
            this.chWebName.Width = 86;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(7, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(395, 2);
            this.label5.TabIndex = 12;
            this.label5.Text = "label5";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAdd});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(407, 25);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripAdd
            // 
            this.toolStripAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAdd.Image")));
            this.toolStripAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAdd.Name = "toolStripAdd";
            this.toolStripAdd.Size = new System.Drawing.Size(42, 22);
            this.toolStripAdd.Text = "Add...";
            this.toolStripAdd.Click += new System.EventHandler(this.toolStripAdd_Click);
            // 
            // CohortList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 368);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvCohort);
            this.Controls.Add(this.cmdClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CohortList";
            this.ShowIcon = false;
            this.Text = "Cohort List";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCohort)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.DataGridView dgvCohort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn chID;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCohort;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn chWebName;
    }
}