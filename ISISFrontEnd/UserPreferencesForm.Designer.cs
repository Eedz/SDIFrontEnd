namespace ISISFrontEnd
{
    partial class UserPreferencesForm
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
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtReportDestination = new System.Windows.Forms.TextBox();
            this.cboAccessLevel = new System.Windows.Forms.ComboBox();
            this.chkReportPrompt = new System.Windows.Forms.CheckBox();
            this.chkWordingNumbers = new System.Windows.Forms.CheckBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cboCommentDetails = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(189, 65);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 0;
            // 
            // txtReportDestination
            // 
            this.txtReportDestination.Location = new System.Drawing.Point(189, 109);
            this.txtReportDestination.Name = "txtReportDestination";
            this.txtReportDestination.Size = new System.Drawing.Size(100, 20);
            this.txtReportDestination.TabIndex = 1;
            // 
            // cboAccessLevel
            // 
            this.cboAccessLevel.FormattingEnabled = true;
            this.cboAccessLevel.Location = new System.Drawing.Point(393, 64);
            this.cboAccessLevel.Name = "cboAccessLevel";
            this.cboAccessLevel.Size = new System.Drawing.Size(85, 21);
            this.cboAccessLevel.TabIndex = 2;
            // 
            // chkReportPrompt
            // 
            this.chkReportPrompt.AutoSize = true;
            this.chkReportPrompt.Location = new System.Drawing.Point(357, 112);
            this.chkReportPrompt.Name = "chkReportPrompt";
            this.chkReportPrompt.Size = new System.Drawing.Size(94, 17);
            this.chkReportPrompt.TabIndex = 3;
            this.chkReportPrompt.Text = "Report Prompt";
            this.chkReportPrompt.UseVisualStyleBackColor = true;
            // 
            // chkWordingNumbers
            // 
            this.chkWordingNumbers.AutoSize = true;
            this.chkWordingNumbers.Location = new System.Drawing.Point(357, 135);
            this.chkWordingNumbers.Name = "chkWordingNumbers";
            this.chkWordingNumbers.Size = new System.Drawing.Size(111, 17);
            this.chkWordingNumbers.TabIndex = 4;
            this.chkWordingNumbers.Text = "Wording Numbers";
            this.chkWordingNumbers.UseVisualStyleBackColor = true;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(95, 68);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(55, 13);
            this.lblUserName.TabIndex = 5;
            this.lblUserName.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Report Destination";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Access Level";
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(540, 12);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(58, 30);
            this.cmdSave.TabIndex = 8;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(7, 6);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(53, 26);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cboCommentDetails
            // 
            this.cboCommentDetails.FormattingEnabled = true;
            this.cboCommentDetails.Location = new System.Drawing.Point(188, 143);
            this.cboCommentDetails.Name = "cboCommentDetails";
            this.cboCommentDetails.Size = new System.Drawing.Size(101, 21);
            this.cboCommentDetails.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Comment Details";
            // 
            // UserPreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 171);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCommentDetails);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.chkWordingNumbers);
            this.Controls.Add(this.chkReportPrompt);
            this.Controls.Add(this.cboAccessLevel);
            this.Controls.Add(this.txtReportDestination);
            this.Controls.Add(this.txtUserName);
            this.Name = "UserPreferencesForm";
            this.Text = "UserPreferencesForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserPreferencesForm_FormClosed);
            this.Load += new System.EventHandler(this.UserPreferencesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtReportDestination;
        private System.Windows.Forms.ComboBox cboAccessLevel;
        private System.Windows.Forms.CheckBox chkReportPrompt;
        private System.Windows.Forms.CheckBox chkWordingNumbers;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ComboBox cboCommentDetails;
        private System.Windows.Forms.Label label1;
    }
}