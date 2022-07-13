namespace ISISFrontEnd
{
    partial class RenameVars
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.optRefVarName = new System.Windows.Forms.RadioButton();
            this.optVarName = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDest = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSource = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.cmdUnlock = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdRename = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lstSurveyList = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(443, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.optRefVarName);
            this.panel1.Controls.Add(this.optVarName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboDest);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboSource);
            this.panel1.Location = new System.Drawing.Point(12, 72);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 80);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Rename By:";
            // 
            // optRefVarName
            // 
            this.optRefVarName.AutoSize = true;
            this.optRefVarName.Location = new System.Drawing.Point(251, 45);
            this.optRefVarName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optRefVarName.Name = "optRefVarName";
            this.optRefVarName.Size = new System.Drawing.Size(95, 20);
            this.optRefVarName.TabIndex = 5;
            this.optRefVarName.TabStop = true;
            this.optRefVarName.Text = "refVarName";
            this.optRefVarName.UseVisualStyleBackColor = true;
            this.optRefVarName.Click += new System.EventHandler(this.Scope_Click);
            // 
            // optVarName
            // 
            this.optVarName.AutoSize = true;
            this.optVarName.Location = new System.Drawing.Point(155, 45);
            this.optVarName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optVarName.Name = "optVarName";
            this.optVarName.Size = new System.Drawing.Size(79, 20);
            this.optVarName.TabIndex = 4;
            this.optVarName.TabStop = true;
            this.optVarName.Text = "VarName";
            this.optVarName.UseVisualStyleBackColor = true;
            this.optVarName.Click += new System.EventHandler(this.Scope_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rename To:";
            // 
            // cboDest
            // 
            this.cboDest.FormattingEnabled = true;
            this.cboDest.Location = new System.Drawing.Point(294, 7);
            this.cboDest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDest.Name = "cboDest";
            this.cboDest.Size = new System.Drawing.Size(107, 24);
            this.cboDest.TabIndex = 2;
            this.cboDest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboDest_KeyDown);
            this.cboDest.Leave += new System.EventHandler(this.cboDest_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Var:";
            // 
            // cboSource
            // 
            this.cboSource.FormattingEnabled = true;
            this.cboSource.Location = new System.Drawing.Point(47, 7);
            this.cboSource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSource.Name = "cboSource";
            this.cboSource.Size = new System.Drawing.Size(102, 24);
            this.cboSource.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtStatus);
            this.panel2.Controls.Add(this.cmdUnlock);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cmdRename);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.lstSurveyList);
            this.panel2.Location = new System.Drawing.Point(13, 160);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(419, 325);
            this.panel2.TabIndex = 2;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(177)))), ((int)(((byte)(77)))));
            this.txtStatus.Location = new System.Drawing.Point(136, 11);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(276, 208);
            this.txtStatus.TabIndex = 7;
            // 
            // cmdUnlock
            // 
            this.cmdUnlock.Location = new System.Drawing.Point(7, 253);
            this.cmdUnlock.Name = "cmdUnlock";
            this.cmdUnlock.Size = new System.Drawing.Size(107, 42);
            this.cmdUnlock.TabIndex = 6;
            this.cmdUnlock.Text = "Unlock Surveys";
            this.cmdUnlock.UseVisualStyleBackColor = true;
            this.cmdUnlock.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Survey";
            // 
            // cmdRename
            // 
            this.cmdRename.Enabled = false;
            this.cmdRename.Location = new System.Drawing.Point(136, 273);
            this.cmdRename.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdRename.Name = "cmdRename";
            this.cmdRename.Size = new System.Drawing.Size(264, 42);
            this.cmdRename.TabIndex = 4;
            this.cmdRename.Text = "Rename";
            this.cmdRename.UseVisualStyleBackColor = true;
            this.cmdRename.Click += new System.EventHandler(this.cmdRename_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(147, 245);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(126, 20);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Do Not Document";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(147, 226);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 20);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Pre-FWS Change";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lstSurveyList
            // 
            this.lstSurveyList.FormattingEnabled = true;
            this.lstSurveyList.ItemHeight = 16;
            this.lstSurveyList.Location = new System.Drawing.Point(7, 34);
            this.lstSurveyList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstSurveyList.Name = "lstSurveyList";
            this.lstSurveyList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstSurveyList.Size = new System.Drawing.Size(107, 212);
            this.lstSurveyList.TabIndex = 0;
            this.lstSurveyList.SelectedIndexChanged += new System.EventHandler(this.lstSurveyList_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(145, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(144, 29);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Rename Var";
            // 
            // RenameVars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(177)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(443, 496);
            this.ControlBox = false;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RenameVars";
            this.Text = "Rename Vars";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton optRefVarName;
        private System.Windows.Forms.RadioButton optVarName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdRename;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListBox lstSurveyList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdUnlock;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtStatus;
    }
}