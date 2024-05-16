namespace SDIFrontEnd
{
    partial class UserStateList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserStateList));
            this.cmdClose = new System.Windows.Forms.Button();
            this.dgvUserStates = new System.Windows.Forms.DataGridView();
            this.chID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chUserState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripAdd = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserStates)).BeginInit();
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
            // dgvUserStates
            // 
            this.dgvUserStates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUserStates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserStates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chID,
            this.chUserState});
            this.dgvUserStates.Location = new System.Drawing.Point(0, 28);
            this.dgvUserStates.Name = "dgvUserStates";
            this.dgvUserStates.Size = new System.Drawing.Size(407, 282);
            this.dgvUserStates.TabIndex = 11;
            this.dgvUserStates.VirtualMode = true;
            this.dgvUserStates.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.dgvUserStates_CancelRowEdit);
            this.dgvUserStates.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvUserStates_CellValueNeeded);
            this.dgvUserStates.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvUserStates_CellValuePushed);
            this.dgvUserStates.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvUserStates_DataError);
            this.dgvUserStates.NewRowNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvUserStates_NewRowNeeded);
            this.dgvUserStates.RowDirtyStateNeeded += new System.Windows.Forms.QuestionEventHandler(this.dgvUserStates_RowDirtyStateNeeded);
            this.dgvUserStates.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserStates_RowValidated);
            this.dgvUserStates.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvUserStates_UserDeletingRow);
            // 
            // chID
            // 
            this.chID.HeaderText = "ID";
            this.chID.Name = "chID";
            this.chID.Width = 43;
            // 
            // chUserState
            // 
            this.chUserState.HeaderText = "User State";
            this.chUserState.Name = "chUserState";
            this.chUserState.Width = 82;
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
            // UserStateList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 368);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvUserStates);
            this.Controls.Add(this.cmdClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UserStateList";
            this.ShowIcon = false;
            this.Text = "User States";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserStates)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.DataGridView dgvUserStates;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn chID;
        private System.Windows.Forms.DataGridViewTextBoxColumn chUserState;
    }
}