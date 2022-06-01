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
            this.separator = new System.Windows.Forms.Label();
            this.dgvSurveys = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurveys)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(129, 12);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(116, 23);
            this.txtUserName.TabIndex = 0;
            // 
            // txtReportDestination
            // 
            this.txtReportDestination.Location = new System.Drawing.Point(129, 78);
            this.txtReportDestination.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtReportDestination.Name = "txtReportDestination";
            this.txtReportDestination.Size = new System.Drawing.Size(289, 23);
            this.txtReportDestination.TabIndex = 1;
            // 
            // cboAccessLevel
            // 
            this.cboAccessLevel.FormattingEnabled = true;
            this.cboAccessLevel.Location = new System.Drawing.Point(129, 44);
            this.cboAccessLevel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboAccessLevel.Name = "cboAccessLevel";
            this.cboAccessLevel.Size = new System.Drawing.Size(116, 24);
            this.cboAccessLevel.TabIndex = 2;
            // 
            // chkReportPrompt
            // 
            this.chkReportPrompt.AutoSize = true;
            this.chkReportPrompt.Location = new System.Drawing.Point(440, 15);
            this.chkReportPrompt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkReportPrompt.Name = "chkReportPrompt";
            this.chkReportPrompt.Size = new System.Drawing.Size(110, 20);
            this.chkReportPrompt.TabIndex = 3;
            this.chkReportPrompt.Text = "Report Prompt";
            this.chkReportPrompt.UseVisualStyleBackColor = true;
            // 
            // chkWordingNumbers
            // 
            this.chkWordingNumbers.AutoSize = true;
            this.chkWordingNumbers.Location = new System.Drawing.Point(440, 43);
            this.chkWordingNumbers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkWordingNumbers.Name = "chkWordingNumbers";
            this.chkWordingNumbers.Size = new System.Drawing.Size(130, 20);
            this.chkWordingNumbers.TabIndex = 4;
            this.chkWordingNumbers.Text = "Wording Numbers";
            this.chkWordingNumbers.UseVisualStyleBackColor = true;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(58, 16);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(66, 16);
            this.lblUserName.TabIndex = 5;
            this.lblUserName.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Report Destination";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Access Level";
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(440, 354);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(68, 39);
            this.cmdSave.TabIndex = 8;
            this.cmdSave.Text = "OK";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Location = new System.Drawing.Point(514, 354);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(62, 39);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "Cancel";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cboCommentDetails
            // 
            this.cboCommentDetails.FormattingEnabled = true;
            this.cboCommentDetails.Location = new System.Drawing.Point(128, 110);
            this.cboCommentDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboCommentDetails.Name = "cboCommentDetails";
            this.cboCommentDetails.Size = new System.Drawing.Size(117, 24);
            this.cboCommentDetails.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Comment Details";
            // 
            // separator
            // 
            this.separator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separator.Location = new System.Drawing.Point(7, 350);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(583, 2);
            this.separator.TabIndex = 12;
            this.separator.Text = "label4";
            // 
            // dgvSurveys
            // 
            this.dgvSurveys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSurveys.Location = new System.Drawing.Point(129, 143);
            this.dgvSurveys.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSurveys.Name = "dgvSurveys";
            this.dgvSurveys.Size = new System.Drawing.Size(289, 203);
            this.dgvSurveys.TabIndex = 13;
            this.dgvSurveys.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSurveys_DataBindingComplete);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Last Edited Surveys";
            // 
            // UserPreferencesForm
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(594, 413);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvSurveys);
            this.Controls.Add(this.separator);
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
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UserPreferencesForm";
            this.ShowIcon = false;
            this.Text = "User Preferences";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserPreferencesForm_FormClosed);
            this.Load += new System.EventHandler(this.UserPreferencesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurveys)).EndInit();
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
        private System.Windows.Forms.Label separator;
        private System.Windows.Forms.DataGridView dgvSurveys;
        private System.Windows.Forms.Label label4;
    }
}