namespace SDIFrontEnd
{
    partial class HeadingReportForm
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
            this.cboSurvey = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstSelected = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.chkIncludeQnum = new System.Windows.Forms.CheckBox();
            this.chkIncludeVarNames = new System.Windows.Forms.CheckBox();
            this.cmdOpenFolder = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboSurvey
            // 
            this.cboSurvey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSurvey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSurvey.FormattingEnabled = true;
            this.cboSurvey.Location = new System.Drawing.Point(58, 92);
            this.cboSurvey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSurvey.Name = "cboSurvey";
            this.cboSurvey.Size = new System.Drawing.Size(109, 24);
            this.cboSurvey.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Survey";
            // 
            // lstSelected
            // 
            this.lstSelected.FormattingEnabled = true;
            this.lstSelected.ItemHeight = 16;
            this.lstSelected.Location = new System.Drawing.Point(243, 92);
            this.lstSelected.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstSelected.Name = "lstSelected";
            this.lstSelected.Size = new System.Drawing.Size(112, 132);
            this.lstSelected.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Survey Sections Report";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(365, 24);
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
            // cmdRemove
            // 
            this.cmdRemove.Location = new System.Drawing.Point(169, 92);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(30, 23);
            this.cmdRemove.TabIndex = 5;
            this.cmdRemove.Text = "<-";
            this.cmdRemove.UseCompatibleTextRendering = true;
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(205, 92);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(32, 23);
            this.cmdAdd.TabIndex = 6;
            this.cmdAdd.Text = "->";
            this.cmdAdd.UseCompatibleTextRendering = true;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Location = new System.Drawing.Point(243, 231);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(112, 28);
            this.cmdGenerate.TabIndex = 7;
            this.cmdGenerate.Text = "Generate";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // chkIncludeQnum
            // 
            this.chkIncludeQnum.AutoSize = true;
            this.chkIncludeQnum.Location = new System.Drawing.Point(13, 133);
            this.chkIncludeQnum.Name = "chkIncludeQnum";
            this.chkIncludeQnum.Size = new System.Drawing.Size(111, 20);
            this.chkIncludeQnum.TabIndex = 8;
            this.chkIncludeQnum.Text = "Include Qnums";
            this.chkIncludeQnum.UseVisualStyleBackColor = true;
            // 
            // chkIncludeVarNames
            // 
            this.chkIncludeVarNames.AutoSize = true;
            this.chkIncludeVarNames.Location = new System.Drawing.Point(13, 159);
            this.chkIncludeVarNames.Name = "chkIncludeVarNames";
            this.chkIncludeVarNames.Size = new System.Drawing.Size(187, 20);
            this.chkIncludeVarNames.TabIndex = 9;
            this.chkIncludeVarNames.Text = "Include First/Last VarNames";
            this.chkIncludeVarNames.UseVisualStyleBackColor = true;
            // 
            // cmdOpenFolder
            // 
            this.cmdOpenFolder.Image = global::SDIFrontEnd.Properties.Resources.FolderOpened;
            this.cmdOpenFolder.Location = new System.Drawing.Point(206, 231);
            this.cmdOpenFolder.Name = "cmdOpenFolder";
            this.cmdOpenFolder.Size = new System.Drawing.Size(31, 28);
            this.cmdOpenFolder.TabIndex = 15;
            this.cmdOpenFolder.UseVisualStyleBackColor = true;
            this.cmdOpenFolder.Click += new System.EventHandler(this.cmdOpenFolder_Click);
            // 
            // HeadingReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(365, 262);
            this.ControlBox = false;
            this.Controls.Add(this.cmdOpenFolder);
            this.Controls.Add(this.chkIncludeVarNames);
            this.Controls.Add(this.chkIncludeQnum);
            this.Controls.Add(this.cmdGenerate);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstSelected);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSurvey);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HeadingReportForm";
            this.Text = "Sections Report";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSurvey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstSelected;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.CheckBox chkIncludeQnum;
        private System.Windows.Forms.CheckBox chkIncludeVarNames;
        private System.Windows.Forms.Button cmdOpenFolder;
    }
}