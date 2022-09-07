namespace SDIFrontEnd
{
    partial class ViewQuestionComments
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
            this.dataRepeater1 = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboAuthor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNoteDate = new System.Windows.Forms.DateTimePicker();
            this.cmdOpenCommentUsage = new System.Windows.Forms.Button();
            this.cboNoteType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtNoteSource = new System.Windows.Forms.TextBox();
            this.txtNoteAuthority = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.dataRepeater1.ItemTemplate.SuspendLayout();
            this.dataRepeater1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataRepeater1
            // 
            this.dataRepeater1.AllowUserToAddItems = false;
            this.dataRepeater1.AllowUserToDeleteItems = false;
            // 
            // dataRepeater1.ItemTemplate
            // 
            this.dataRepeater1.ItemTemplate.Controls.Add(this.panel1);
            this.dataRepeater1.ItemTemplate.Size = new System.Drawing.Size(773, 154);
            this.dataRepeater1.Location = new System.Drawing.Point(19, 48);
            this.dataRepeater1.Name = "dataRepeater1";
            this.dataRepeater1.Size = new System.Drawing.Size(781, 468);
            this.dataRepeater1.TabIndex = 0;
            this.dataRepeater1.Text = "dataRepeater1";
            this.dataRepeater1.ItemCloned += new Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventHandler(this.dataRepeater1_ItemCloned);
            this.dataRepeater1.DrawItem += new Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventHandler(this.dataRepeater1_DrawItem);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboAuthor);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpNoteDate);
            this.panel1.Controls.Add(this.cmdOpenCommentUsage);
            this.panel1.Controls.Add(this.cboNoteType);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtComment);
            this.panel1.Controls.Add(this.txtNoteSource);
            this.panel1.Controls.Add(this.txtNoteAuthority);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 153);
            this.panel1.TabIndex = 15;
            this.panel1.Leave += new System.EventHandler(this.panel1_Leave);
            // 
            // cboAuthor
            // 
            this.cboAuthor.FormattingEnabled = true;
            this.cboAuthor.Location = new System.Drawing.Point(83, 56);
            this.cboAuthor.Name = "cboAuthor";
            this.cboAuthor.Size = new System.Drawing.Size(117, 21);
            this.cboAuthor.TabIndex = 14;
            this.cboAuthor.SelectedIndexChanged += new System.EventHandler(this.cboAuthor_SelectedIndexChanged);
            this.cboAuthor.SelectionChangeCommitted += new System.EventHandler(this.cboAuthor_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Authority";
            // 
            // dtpNoteDate
            // 
            this.dtpNoteDate.Location = new System.Drawing.Point(83, 28);
            this.dtpNoteDate.Name = "dtpNoteDate";
            this.dtpNoteDate.Size = new System.Drawing.Size(117, 21);
            this.dtpNoteDate.TabIndex = 13;
            // 
            // cmdOpenCommentUsage
            // 
            this.cmdOpenCommentUsage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenCommentUsage.Location = new System.Drawing.Point(696, 4);
            this.cmdOpenCommentUsage.Name = "cmdOpenCommentUsage";
            this.cmdOpenCommentUsage.Size = new System.Drawing.Size(39, 23);
            this.cmdOpenCommentUsage.TabIndex = 2;
            this.cmdOpenCommentUsage.Text = "Edit";
            this.cmdOpenCommentUsage.UseVisualStyleBackColor = true;
            this.cmdOpenCommentUsage.Click += new System.EventHandler(this.cmdOpenCommentUsage_Click);
            // 
            // cboNoteType
            // 
            this.cboNoteType.FormattingEnabled = true;
            this.cboNoteType.Location = new System.Drawing.Point(83, 3);
            this.cboNoteType.Name = "cboNoteType";
            this.cboNoteType.Size = new System.Drawing.Size(117, 21);
            this.cboNoteType.TabIndex = 12;
            this.cboNoteType.SelectionChangeCommitted += new System.EventHandler(this.cboNoteType_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(152, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Source";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Author";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Type";
            // 
            // txtComment
            // 
            this.txtComment.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtComment.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.Location = new System.Drawing.Point(206, 3);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(484, 103);
            this.txtComment.TabIndex = 6;
            // 
            // txtNoteSource
            // 
            this.txtNoteSource.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoteSource.Location = new System.Drawing.Point(206, 111);
            this.txtNoteSource.Multiline = true;
            this.txtNoteSource.Name = "txtNoteSource";
            this.txtNoteSource.Size = new System.Drawing.Size(484, 39);
            this.txtNoteSource.TabIndex = 5;
            // 
            // txtNoteAuthority
            // 
            this.txtNoteAuthority.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoteAuthority.Location = new System.Drawing.Point(83, 83);
            this.txtNoteAuthority.Name = "txtNoteAuthority";
            this.txtNoteAuthority.Size = new System.Drawing.Size(117, 23);
            this.txtNoteAuthority.TabIndex = 4;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(13, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(429, 33);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Comments for [Survey].[VarName]";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdd.Location = new System.Drawing.Point(734, 20);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(39, 23);
            this.cmdAdd.TabIndex = 2;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(677, 522);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "OK";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // ViewQuestionComments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 556);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dataRepeater1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ViewQuestionComments";
            this.Text = "Comment Viewer";
            this.Load += new System.EventHandler(this.ViewQuestionComments_Load);
            this.dataRepeater1.ItemTemplate.ResumeLayout(false);
            this.dataRepeater1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater1;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtNoteSource;
        private System.Windows.Forms.TextBox txtNoteAuthority;
        private System.Windows.Forms.Button cmdOpenCommentUsage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ComboBox cboAuthor;
        private System.Windows.Forms.DateTimePicker dtpNoteDate;
        private System.Windows.Forms.ComboBox cboNoteType;
        private System.Windows.Forms.Panel panel1;
    }
}