namespace SDIFrontEnd
{
    partial class BrowseIssues
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
            this.txtVarNameCriteria = new System.Windows.Forms.TextBox();
            this.cboToCriteria = new System.Windows.Forms.ComboBox();
            this.dataRepeater1 = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSelectIssue = new System.Windows.Forms.Button();
            this.dtpIssueDate = new System.Windows.Forms.DateTimePicker();
            this.txtVarNames = new System.Windows.Forms.TextBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.txtIssueNo = new System.Windows.Forms.TextBox();
            this.cmdCheckForIssues = new System.Windows.Forms.Button();
            this.cmdCreateNew = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSurvey = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataRepeater1.ItemTemplate.SuspendLayout();
            this.dataRepeater1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtVarNameCriteria
            // 
            this.txtVarNameCriteria.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVarNameCriteria.Location = new System.Drawing.Point(178, 115);
            this.txtVarNameCriteria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVarNameCriteria.Name = "txtVarNameCriteria";
            this.txtVarNameCriteria.Size = new System.Drawing.Size(116, 23);
            this.txtVarNameCriteria.TabIndex = 1;
            // 
            // cboToCriteria
            // 
            this.cboToCriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboToCriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboToCriteria.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboToCriteria.FormattingEnabled = true;
            this.cboToCriteria.Location = new System.Drawing.Point(178, 147);
            this.cboToCriteria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboToCriteria.Name = "cboToCriteria";
            this.cboToCriteria.Size = new System.Drawing.Size(116, 24);
            this.cboToCriteria.TabIndex = 2;
            // 
            // dataRepeater1
            // 
            this.dataRepeater1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // dataRepeater1.ItemTemplate
            // 
            this.dataRepeater1.ItemTemplate.Controls.Add(this.txtTo);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.txtFrom);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.label5);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.label4);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.label3);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.label2);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.label1);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.cmdSelectIssue);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.dtpIssueDate);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.txtVarNames);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.rtbDescription);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.txtIssueNo);
            this.dataRepeater1.ItemTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataRepeater1.ItemTemplate.Size = new System.Drawing.Size(895, 246);
            this.dataRepeater1.Location = new System.Drawing.Point(15, 189);
            this.dataRepeater1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataRepeater1.Name = "dataRepeater1";
            this.dataRepeater1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataRepeater1.Size = new System.Drawing.Size(905, 646);
            this.dataRepeater1.TabIndex = 3;
            this.dataRepeater1.Text = "dataRepeater1";
            this.dataRepeater1.DrawItem += new Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventHandler(this.dataRepeater1_DrawItem);
            // 
            // txtTo
            // 
            this.txtTo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTo.Location = new System.Drawing.Point(307, 63);
            this.txtTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(116, 23);
            this.txtTo.TabIndex = 13;
            // 
            // txtFrom
            // 
            this.txtFrom.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrom.Location = new System.Drawing.Point(307, 31);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(116, 23);
            this.txtFrom.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(439, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(267, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(255, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "VarNames";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Issue No";
            // 
            // cmdSelectIssue
            // 
            this.cmdSelectIssue.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmdSelectIssue.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelectIssue.Location = new System.Drawing.Point(773, 4);
            this.cmdSelectIssue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSelectIssue.Name = "cmdSelectIssue";
            this.cmdSelectIssue.Size = new System.Drawing.Size(88, 28);
            this.cmdSelectIssue.TabIndex = 6;
            this.cmdSelectIssue.Text = "Select";
            this.cmdSelectIssue.UseVisualStyleBackColor = false;
            this.cmdSelectIssue.Click += new System.EventHandler(this.cmdSelectIssue_Click);
            // 
            // dtpIssueDate
            // 
            this.dtpIssueDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIssueDate.Location = new System.Drawing.Point(481, 31);
            this.dtpIssueDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpIssueDate.Name = "dtpIssueDate";
            this.dtpIssueDate.Size = new System.Drawing.Size(125, 23);
            this.dtpIssueDate.TabIndex = 4;
            // 
            // txtVarNames
            // 
            this.txtVarNames.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVarNames.Location = new System.Drawing.Point(86, 34);
            this.txtVarNames.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVarNames.Multiline = true;
            this.txtVarNames.Name = "txtVarNames";
            this.txtVarNames.Size = new System.Drawing.Size(156, 56);
            this.txtVarNames.TabIndex = 2;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDescription.Location = new System.Drawing.Point(8, 95);
            this.rtbDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(733, 143);
            this.rtbDescription.TabIndex = 1;
            this.rtbDescription.Text = "";
            // 
            // txtIssueNo
            // 
            this.txtIssueNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIssueNo.Location = new System.Drawing.Point(86, 2);
            this.txtIssueNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIssueNo.Name = "txtIssueNo";
            this.txtIssueNo.Size = new System.Drawing.Size(41, 23);
            this.txtIssueNo.TabIndex = 0;
            // 
            // cmdCheckForIssues
            // 
            this.cmdCheckForIssues.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCheckForIssues.Location = new System.Drawing.Point(343, 89);
            this.cmdCheckForIssues.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdCheckForIssues.Name = "cmdCheckForIssues";
            this.cmdCheckForIssues.Size = new System.Drawing.Size(131, 28);
            this.cmdCheckForIssues.TabIndex = 4;
            this.cmdCheckForIssues.Text = "Check for Issues";
            this.cmdCheckForIssues.UseVisualStyleBackColor = true;
            this.cmdCheckForIssues.Click += new System.EventHandler(this.cmdCheckForIssues_Click);
            // 
            // cmdCreateNew
            // 
            this.cmdCreateNew.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCreateNew.Location = new System.Drawing.Point(343, 131);
            this.cmdCreateNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdCreateNew.Name = "cmdCreateNew";
            this.cmdCreateNew.Size = new System.Drawing.Size(131, 28);
            this.cmdCreateNew.TabIndex = 5;
            this.cmdCreateNew.Text = "Create New";
            this.cmdCreateNew.UseVisualStyleBackColor = true;
            this.cmdCreateNew.Click += new System.EventHandler(this.cmdCreateNew_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(496, 89);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(400, 58);
            this.label6.TabIndex = 6;
            this.label6.Text = "Enter the variable name and intended recipient on the left and check if the issue" +
    " has laready been submitted below. You can go to any of the issues by clicking t" +
    "he Select button.";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(496, 147);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(400, 38);
            this.label7.TabIndex = 7;
            this.label7.Text = "If the issue is not found below, click Create New to start a new issue.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(117, 89);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Survey";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(97, 118);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "VarNames";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(25, 150);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 16);
            this.label10.TabIndex = 10;
            this.label10.Text = "Intended recipient/firm";
            // 
            // txtSurvey
            // 
            this.txtSurvey.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSurvey.Location = new System.Drawing.Point(178, 86);
            this.txtSurvey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSurvey.Name = "txtSurvey";
            this.txtSurvey.Size = new System.Drawing.Size(116, 23);
            this.txtSurvey.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(261, 35);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(441, 33);
            this.label11.TabIndex = 12;
            this.label11.Text = "Praccing Issues Pre-submittal Check";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(933, 24);
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
            // BrowseIssues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(933, 848);
            this.ControlBox = false;
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtSurvey);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdCreateNew);
            this.Controls.Add(this.cmdCheckForIssues);
            this.Controls.Add(this.dataRepeater1);
            this.Controls.Add(this.cboToCriteria);
            this.Controls.Add(this.txtVarNameCriteria);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BrowseIssues";
            this.Text = "Browse Issues";
            this.dataRepeater1.ItemTemplate.ResumeLayout(false);
            this.dataRepeater1.ItemTemplate.PerformLayout();
            this.dataRepeater1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtVarNameCriteria;
        private System.Windows.Forms.ComboBox cboToCriteria;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSelectIssue;
        private System.Windows.Forms.DateTimePicker dtpIssueDate;
        private System.Windows.Forms.TextBox txtVarNames;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.TextBox txtIssueNo;
        private System.Windows.Forms.Button cmdCheckForIssues;
        private System.Windows.Forms.Button cmdCreateNew;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSurvey;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}