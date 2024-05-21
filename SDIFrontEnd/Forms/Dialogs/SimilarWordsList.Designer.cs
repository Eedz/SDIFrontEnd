namespace SDIFrontEnd
{
    partial class SimilarWordsList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimilarWordsList));
            this.cmdClose = new System.Windows.Forms.Button();
            this.dgvWordList = new System.Windows.Forms.DataGridView();
            this.chID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chWords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripAdd = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWordList)).BeginInit();
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
            // dgvWordList
            // 
            this.dgvWordList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvWordList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWordList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chID,
            this.chWords});
            this.dgvWordList.Location = new System.Drawing.Point(0, 28);
            this.dgvWordList.Name = "dgvWordList";
            this.dgvWordList.Size = new System.Drawing.Size(407, 282);
            this.dgvWordList.TabIndex = 11;
            this.dgvWordList.VirtualMode = true;
            this.dgvWordList.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.dgvWordList_CancelRowEdit);
            this.dgvWordList.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvWordList_CellValueNeeded);
            this.dgvWordList.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvWordList_CellValuePushed);
            this.dgvWordList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvWordList_DataError);
            this.dgvWordList.NewRowNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvWordList_NewRowNeeded);
            this.dgvWordList.RowDirtyStateNeeded += new System.Windows.Forms.QuestionEventHandler(this.dgvWordList_RowDirtyStateNeeded);
            this.dgvWordList.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWordList_RowValidated);
            this.dgvWordList.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvWordList_UserDeletingRow);
            // 
            // chID
            // 
            this.chID.HeaderText = "ID";
            this.chID.Name = "chID";
            this.chID.Width = 43;
            // 
            // chWords
            // 
            this.chWords.HeaderText = "Words";
            this.chWords.Name = "chWords";
            this.chWords.Width = 63;
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
            // SimilarWordsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 368);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvWordList);
            this.Controls.Add(this.cmdClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SimilarWordsList";
            this.ShowIcon = false;
            this.Text = "Similar Words";
            ((System.ComponentModel.ISupportInitialize)(this.dgvWordList)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.DataGridView dgvWordList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn chID;
        private System.Windows.Forms.DataGridViewTextBoxColumn chWords;
    }
}