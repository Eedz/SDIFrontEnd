namespace SDIFrontEnd
{
    partial class ResponseSetReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboSets = new System.Windows.Forms.ComboBox();
            this.cmdAddSet = new System.Windows.Forms.Button();
            this.cmdRemoveSet = new System.Windows.Forms.Button();
            this.lstSelectedSets = new System.Windows.Forms.ListBox();
            this.cmdAddSurvey = new System.Windows.Forms.Button();
            this.cboSurveys = new System.Windows.Forms.ComboBox();
            this.lstSelectedSurveys = new System.Windows.Forms.ListBox();
            this.cmdRemoveSurvey = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cboVars = new System.Windows.Forms.ComboBox();
            this.cmdAddVar = new System.Windows.Forms.Button();
            this.cmdRemoveVar = new System.Windows.Forms.Button();
            this.lstSelectedVars = new System.Windows.Forms.ListBox();
            this.dgvResponseSets = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResponseSets)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboSets
            // 
            this.cboSets.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSets.FormattingEnabled = true;
            this.cboSets.Location = new System.Drawing.Point(18, 381);
            this.cboSets.Name = "cboSets";
            this.cboSets.Size = new System.Drawing.Size(101, 24);
            this.cboSets.TabIndex = 0;
            // 
            // cmdAddSet
            // 
            this.cmdAddSet.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddSet.Location = new System.Drawing.Point(124, 379);
            this.cmdAddSet.Name = "cmdAddSet";
            this.cmdAddSet.Size = new System.Drawing.Size(75, 23);
            this.cmdAddSet.TabIndex = 1;
            this.cmdAddSet.Text = "-->";
            this.cmdAddSet.UseVisualStyleBackColor = true;
            this.cmdAddSet.Click += new System.EventHandler(this.cmdAddSet_Click);
            // 
            // cmdRemoveSet
            // 
            this.cmdRemoveSet.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoveSet.Location = new System.Drawing.Point(124, 403);
            this.cmdRemoveSet.Name = "cmdRemoveSet";
            this.cmdRemoveSet.Size = new System.Drawing.Size(75, 23);
            this.cmdRemoveSet.TabIndex = 2;
            this.cmdRemoveSet.Text = "<--";
            this.cmdRemoveSet.UseVisualStyleBackColor = true;
            this.cmdRemoveSet.Click += new System.EventHandler(this.cmdRemoveSet_Click);
            // 
            // lstSelectedSets
            // 
            this.lstSelectedSets.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSelectedSets.FormattingEnabled = true;
            this.lstSelectedSets.ItemHeight = 16;
            this.lstSelectedSets.Location = new System.Drawing.Point(206, 379);
            this.lstSelectedSets.Name = "lstSelectedSets";
            this.lstSelectedSets.Size = new System.Drawing.Size(120, 148);
            this.lstSelectedSets.TabIndex = 3;
            // 
            // cmdAddSurvey
            // 
            this.cmdAddSurvey.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddSurvey.Location = new System.Drawing.Point(124, 75);
            this.cmdAddSurvey.Name = "cmdAddSurvey";
            this.cmdAddSurvey.Size = new System.Drawing.Size(75, 23);
            this.cmdAddSurvey.TabIndex = 4;
            this.cmdAddSurvey.Text = "-->";
            this.cmdAddSurvey.UseVisualStyleBackColor = true;
            this.cmdAddSurvey.Click += new System.EventHandler(this.cmdAddSurvey_Click);
            // 
            // cboSurveys
            // 
            this.cboSurveys.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSurveys.FormattingEnabled = true;
            this.cboSurveys.Location = new System.Drawing.Point(18, 77);
            this.cboSurveys.Name = "cboSurveys";
            this.cboSurveys.Size = new System.Drawing.Size(101, 24);
            this.cboSurveys.TabIndex = 5;
            // 
            // lstSelectedSurveys
            // 
            this.lstSelectedSurveys.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSelectedSurveys.FormattingEnabled = true;
            this.lstSelectedSurveys.ItemHeight = 16;
            this.lstSelectedSurveys.Location = new System.Drawing.Point(206, 75);
            this.lstSelectedSurveys.Name = "lstSelectedSurveys";
            this.lstSelectedSurveys.Size = new System.Drawing.Size(120, 148);
            this.lstSelectedSurveys.TabIndex = 6;
            // 
            // cmdRemoveSurvey
            // 
            this.cmdRemoveSurvey.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoveSurvey.Location = new System.Drawing.Point(124, 104);
            this.cmdRemoveSurvey.Name = "cmdRemoveSurvey";
            this.cmdRemoveSurvey.Size = new System.Drawing.Size(75, 23);
            this.cmdRemoveSurvey.TabIndex = 7;
            this.cmdRemoveSurvey.Text = "<--";
            this.cmdRemoveSurvey.UseVisualStyleBackColor = true;
            this.cmdRemoveSurvey.Click += new System.EventHandler(this.cmdRemoveSurvey_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(44, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(263, 33);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Response Set Report";
            // 
            // cboVars
            // 
            this.cboVars.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVars.FormattingEnabled = true;
            this.cboVars.Location = new System.Drawing.Point(18, 227);
            this.cboVars.Name = "cboVars";
            this.cboVars.Size = new System.Drawing.Size(101, 24);
            this.cboVars.TabIndex = 10;
            // 
            // cmdAddVar
            // 
            this.cmdAddVar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddVar.Location = new System.Drawing.Point(124, 225);
            this.cmdAddVar.Name = "cmdAddVar";
            this.cmdAddVar.Size = new System.Drawing.Size(75, 23);
            this.cmdAddVar.TabIndex = 11;
            this.cmdAddVar.Text = "-->";
            this.cmdAddVar.UseVisualStyleBackColor = true;
            this.cmdAddVar.Click += new System.EventHandler(this.cmdAddVar_Click);
            // 
            // cmdRemoveVar
            // 
            this.cmdRemoveVar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoveVar.Location = new System.Drawing.Point(124, 254);
            this.cmdRemoveVar.Name = "cmdRemoveVar";
            this.cmdRemoveVar.Size = new System.Drawing.Size(75, 23);
            this.cmdRemoveVar.TabIndex = 12;
            this.cmdRemoveVar.Text = "<--";
            this.cmdRemoveVar.UseVisualStyleBackColor = true;
            this.cmdRemoveVar.Click += new System.EventHandler(this.cmdRemoveVar_Click);
            // 
            // lstSelectedVars
            // 
            this.lstSelectedVars.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSelectedVars.FormattingEnabled = true;
            this.lstSelectedVars.ItemHeight = 16;
            this.lstSelectedVars.Location = new System.Drawing.Point(206, 227);
            this.lstSelectedVars.Name = "lstSelectedVars";
            this.lstSelectedVars.Size = new System.Drawing.Size(120, 148);
            this.lstSelectedVars.TabIndex = 13;
            // 
            // dgvResponseSets
            // 
            this.dgvResponseSets.AllowUserToAddRows = false;
            this.dgvResponseSets.AllowUserToDeleteRows = false;
            this.dgvResponseSets.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvResponseSets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResponseSets.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResponseSets.Location = new System.Drawing.Point(332, 75);
            this.dgvResponseSets.Name = "dgvResponseSets";
            this.dgvResponseSets.RowHeadersVisible = false;
            this.dgvResponseSets.Size = new System.Drawing.Size(1106, 453);
            this.dgvResponseSets.TabIndex = 14;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.printToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1448, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.printToolStripMenuItem.Text = "Print...";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // ResponseSetReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 525);
            this.Controls.Add(this.dgvResponseSets);
            this.Controls.Add(this.lstSelectedVars);
            this.Controls.Add(this.cmdRemoveVar);
            this.Controls.Add(this.cmdAddVar);
            this.Controls.Add(this.cboVars);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmdRemoveSurvey);
            this.Controls.Add(this.lstSelectedSurveys);
            this.Controls.Add(this.cboSurveys);
            this.Controls.Add(this.cmdAddSurvey);
            this.Controls.Add(this.lstSelectedSets);
            this.Controls.Add(this.cmdRemoveSet);
            this.Controls.Add(this.cmdAddSet);
            this.Controls.Add(this.cboSets);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ResponseSetReport";
            this.Text = "Response Set Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ResponseSetReport_FormClosed);
            this.Load += new System.EventHandler(this.ResponseSetReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResponseSets)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSets;
        private System.Windows.Forms.Button cmdAddSet;
        private System.Windows.Forms.Button cmdRemoveSet;
        private System.Windows.Forms.ListBox lstSelectedSets;
        private System.Windows.Forms.Button cmdAddSurvey;
        private System.Windows.Forms.ComboBox cboSurveys;
        private System.Windows.Forms.ListBox lstSelectedSurveys;
        private System.Windows.Forms.Button cmdRemoveSurvey;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cboVars;
        private System.Windows.Forms.Button cmdAddVar;
        private System.Windows.Forms.Button cmdRemoveVar;
        private System.Windows.Forms.ListBox lstSelectedVars;
        private System.Windows.Forms.DataGridView dgvResponseSets;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
    }
}