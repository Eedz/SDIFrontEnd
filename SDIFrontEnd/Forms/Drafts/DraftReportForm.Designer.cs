namespace SDIFrontEnd
{
    partial class DraftReportForm
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
            this.cboDraft = new System.Windows.Forms.ComboBox();
            this.dtpLower = new System.Windows.Forms.DateTimePicker();
            this.dtpUpper = new System.Windows.Forms.DateTimePicker();
            this.cboInvestigator = new System.Windows.Forms.ComboBox();
            this.txtQnumLower = new System.Windows.Forms.TextBox();
            this.txtQnumUpper = new System.Windows.Forms.TextBox();
            this.chkIncludeUpdates = new System.Windows.Forms.CheckBox();
            this.chkShading = new System.Windows.Forms.CheckBox();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbInvestigator = new System.Windows.Forms.RadioButton();
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.rbDraft = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboSurvey
            // 
            this.cboSurvey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboSurvey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSurvey.FormattingEnabled = true;
            this.cboSurvey.Location = new System.Drawing.Point(124, 79);
            this.cboSurvey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSurvey.Name = "cboSurvey";
            this.cboSurvey.Size = new System.Drawing.Size(140, 24);
            this.cboSurvey.TabIndex = 0;
            // 
            // cboDraft
            // 
            this.cboDraft.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboDraft.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDraft.DropDownWidth = 500;
            this.cboDraft.FormattingEnabled = true;
            this.cboDraft.Location = new System.Drawing.Point(116, 13);
            this.cboDraft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDraft.Name = "cboDraft";
            this.cboDraft.Size = new System.Drawing.Size(252, 24);
            this.cboDraft.TabIndex = 1;
            // 
            // dtpLower
            // 
            this.dtpLower.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLower.Location = new System.Drawing.Point(116, 44);
            this.dtpLower.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpLower.Name = "dtpLower";
            this.dtpLower.Size = new System.Drawing.Size(115, 23);
            this.dtpLower.TabIndex = 2;
            // 
            // dtpUpper
            // 
            this.dtpUpper.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpUpper.Location = new System.Drawing.Point(256, 44);
            this.dtpUpper.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpUpper.Name = "dtpUpper";
            this.dtpUpper.Size = new System.Drawing.Size(112, 23);
            this.dtpUpper.TabIndex = 3;
            // 
            // cboInvestigator
            // 
            this.cboInvestigator.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboInvestigator.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboInvestigator.FormattingEnabled = true;
            this.cboInvestigator.Location = new System.Drawing.Point(116, 74);
            this.cboInvestigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboInvestigator.Name = "cboInvestigator";
            this.cboInvestigator.Size = new System.Drawing.Size(252, 24);
            this.cboInvestigator.TabIndex = 4;
            // 
            // txtQnumLower
            // 
            this.txtQnumLower.Location = new System.Drawing.Point(124, 222);
            this.txtQnumLower.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQnumLower.Name = "txtQnumLower";
            this.txtQnumLower.Size = new System.Drawing.Size(115, 23);
            this.txtQnumLower.TabIndex = 5;
            this.txtQnumLower.Validating += new System.ComponentModel.CancelEventHandler(this.Qnum_Validating);
            // 
            // txtQnumUpper
            // 
            this.txtQnumUpper.Location = new System.Drawing.Point(264, 222);
            this.txtQnumUpper.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQnumUpper.Name = "txtQnumUpper";
            this.txtQnumUpper.Size = new System.Drawing.Size(112, 23);
            this.txtQnumUpper.TabIndex = 6;
            this.txtQnumUpper.Validating += new System.ComponentModel.CancelEventHandler(this.Qnum_Validating);
            // 
            // chkIncludeUpdates
            // 
            this.chkIncludeUpdates.AutoSize = true;
            this.chkIncludeUpdates.Location = new System.Drawing.Point(156, 266);
            this.chkIncludeUpdates.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkIncludeUpdates.Name = "chkIncludeUpdates";
            this.chkIncludeUpdates.Size = new System.Drawing.Size(117, 20);
            this.chkIncludeUpdates.TabIndex = 7;
            this.chkIncludeUpdates.Text = "Include Updates";
            this.chkIncludeUpdates.UseVisualStyleBackColor = true;
            this.chkIncludeUpdates.Visible = false;
            // 
            // chkShading
            // 
            this.chkShading.AutoSize = true;
            this.chkShading.Location = new System.Drawing.Point(21, 266);
            this.chkShading.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShading.Name = "chkShading";
            this.chkShading.Size = new System.Drawing.Size(128, 20);
            this.chkShading.TabIndex = 8;
            this.chkShading.Text = "Alternate Shading";
            this.chkShading.UseVisualStyleBackColor = true;
            this.chkShading.Visible = false;
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Location = new System.Drawing.Point(289, 261);
            this.cmdGenerate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(87, 28);
            this.cmdGenerate.TabIndex = 9;
            this.cmdGenerate.Text = "Generate";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Survey";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Qnum Range";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(118, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 33);
            this.label6.TabIndex = 15;
            this.label6.Text = "Draft Report";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(391, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rbInvestigator);
            this.groupBox1.Controls.Add(this.rbDate);
            this.groupBox1.Controls.Add(this.rbDraft);
            this.groupBox1.Controls.Add(this.cboInvestigator);
            this.groupBox1.Controls.Add(this.dtpLower);
            this.groupBox1.Controls.Add(this.cboDraft);
            this.groupBox1.Controls.Add(this.dtpUpper);
            this.groupBox1.Location = new System.Drawing.Point(8, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 106);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "-";
            // 
            // rbInvestigator
            // 
            this.rbInvestigator.AutoSize = true;
            this.rbInvestigator.Location = new System.Drawing.Point(13, 75);
            this.rbInvestigator.Name = "rbInvestigator";
            this.rbInvestigator.Size = new System.Drawing.Size(92, 20);
            this.rbInvestigator.TabIndex = 16;
            this.rbInvestigator.TabStop = true;
            this.rbInvestigator.Text = "Investigator";
            this.rbInvestigator.UseVisualStyleBackColor = true;
            this.rbInvestigator.Click += new System.EventHandler(this.FilterType_Click);
            // 
            // rbDate
            // 
            this.rbDate.AutoSize = true;
            this.rbDate.Location = new System.Drawing.Point(13, 44);
            this.rbDate.Name = "rbDate";
            this.rbDate.Size = new System.Drawing.Size(91, 20);
            this.rbDate.TabIndex = 15;
            this.rbDate.TabStop = true;
            this.rbDate.Text = "Date Range";
            this.rbDate.UseVisualStyleBackColor = true;
            this.rbDate.Click += new System.EventHandler(this.FilterType_Click);
            // 
            // rbDraft
            // 
            this.rbDraft.AutoSize = true;
            this.rbDraft.Location = new System.Drawing.Point(13, 14);
            this.rbDraft.Name = "rbDraft";
            this.rbDraft.Size = new System.Drawing.Size(53, 20);
            this.rbDraft.TabIndex = 14;
            this.rbDraft.TabStop = true;
            this.rbDraft.Text = "Draft";
            this.rbDraft.UseVisualStyleBackColor = true;
            this.rbDraft.Click += new System.EventHandler(this.FilterType_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "-";
            // 
            // DraftReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(189)))));
            this.ClientSize = new System.Drawing.Size(391, 305);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdGenerate);
            this.Controls.Add(this.chkShading);
            this.Controls.Add(this.chkIncludeUpdates);
            this.Controls.Add(this.txtQnumUpper);
            this.Controls.Add(this.txtQnumLower);
            this.Controls.Add(this.cboSurvey);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DraftReportForm";
            this.Text = "Draft Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DraftReportForm_FormClosed);
            this.Load += new System.EventHandler(this.DraftReport_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSurvey;
        private System.Windows.Forms.ComboBox cboDraft;
        private System.Windows.Forms.DateTimePicker dtpLower;
        private System.Windows.Forms.DateTimePicker dtpUpper;
        private System.Windows.Forms.ComboBox cboInvestigator;
        private System.Windows.Forms.TextBox txtQnumLower;
        private System.Windows.Forms.TextBox txtQnumUpper;
        private System.Windows.Forms.CheckBox chkIncludeUpdates;
        private System.Windows.Forms.CheckBox chkShading;
        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbInvestigator;
        private System.Windows.Forms.RadioButton rbDate;
        private System.Windows.Forms.RadioButton rbDraft;
        private System.Windows.Forms.Label label3;
    }
}