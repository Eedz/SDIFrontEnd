namespace SDIFrontEnd
{
    partial class VarNameUsage
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
            this.dgvUnused = new System.Windows.Forms.DataGridView();
            this.chVarNamesUnused = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chCountUnused = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chRenamedUnused = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUsed = new System.Windows.Forms.DataGridView();
            this.chUsedVarNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chUsedCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCriteria = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnused)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsed)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUnused
            // 
            this.dgvUnused.AllowUserToAddRows = false;
            this.dgvUnused.AllowUserToDeleteRows = false;
            this.dgvUnused.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUnused.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnused.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chVarNamesUnused,
            this.chCountUnused,
            this.chRenamedUnused});
            this.dgvUnused.Location = new System.Drawing.Point(7, 27);
            this.dgvUnused.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvUnused.Name = "dgvUnused";
            this.dgvUnused.ReadOnly = true;
            this.dgvUnused.RowHeadersVisible = false;
            this.dgvUnused.Size = new System.Drawing.Size(250, 294);
            this.dgvUnused.TabIndex = 0;
            // 
            // chVarNamesUnused
            // 
            this.chVarNamesUnused.HeaderText = "VarNames";
            this.chVarNamesUnused.Name = "chVarNamesUnused";
            this.chVarNamesUnused.ReadOnly = true;
            // 
            // chCountUnused
            // 
            this.chCountUnused.HeaderText = "Count";
            this.chCountUnused.Name = "chCountUnused";
            this.chCountUnused.ReadOnly = true;
            // 
            // chRenamedUnused
            // 
            this.chRenamedUnused.HeaderText = "Renamed";
            this.chRenamedUnused.Name = "chRenamedUnused";
            this.chRenamedUnused.ReadOnly = true;
            this.chRenamedUnused.Visible = false;
            // 
            // dgvUsed
            // 
            this.dgvUsed.AllowUserToAddRows = false;
            this.dgvUsed.AllowUserToDeleteRows = false;
            this.dgvUsed.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUsed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chUsedVarNames,
            this.chUsedCount});
            this.dgvUsed.Location = new System.Drawing.Point(6, 27);
            this.dgvUsed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvUsed.Name = "dgvUsed";
            this.dgvUsed.ReadOnly = true;
            this.dgvUsed.RowHeadersVisible = false;
            this.dgvUsed.Size = new System.Drawing.Size(250, 294);
            this.dgvUsed.TabIndex = 1;
            // 
            // chUsedVarNames
            // 
            this.chUsedVarNames.HeaderText = "VarName";
            this.chUsedVarNames.Name = "chUsedVarNames";
            this.chUsedVarNames.ReadOnly = true;
            // 
            // chUsedCount
            // 
            this.chUsedCount.HeaderText = "Count";
            this.chUsedCount.Name = "chUsedCount";
            this.chUsedCount.ReadOnly = true;
            // 
            // txtCriteria
            // 
            this.txtCriteria.Location = new System.Drawing.Point(197, 63);
            this.txtCriteria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCriteria.Name = "txtCriteria";
            this.txtCriteria.Size = new System.Drawing.Size(116, 23);
            this.txtCriteria.TabIndex = 2;
            this.txtCriteria.Validating += new System.ComponentModel.CancelEventHandler(this.txtCriteria_Validating);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(319, 63);
            this.cmdSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 3;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(210, 29);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(153, 24);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "VarName Usage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Unused Vars";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(93, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Used Vars";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dgvUnused);
            this.panel1.Location = new System.Drawing.Point(3, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 329);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(218)))), ((int)(((byte)(78)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dgvUsed);
            this.panel2.Location = new System.Drawing.Point(268, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 329);
            this.panel2.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(539, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // VarNameUsage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(539, 428);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtCriteria);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VarNameUsage";
            this.Text = "VarName Usage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VarNameUsage_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnused)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsed)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUnused;
        private System.Windows.Forms.DataGridView dgvUsed;
        private System.Windows.Forms.TextBox txtCriteria;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn chUsedVarNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn chUsedCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn chVarNamesUnused;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCountUnused;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRenamedUnused;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}