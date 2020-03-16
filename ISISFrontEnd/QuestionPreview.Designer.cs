namespace ISISFrontEnd
{
    partial class QuestionPreview
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkInsertQnum = new System.Windows.Forms.CheckBox();
            this.chkInsertCC = new System.Windows.Forms.CheckBox();
            this.lstStandardFields = new System.Windows.Forms.ListBox();
            this.txtBaseQuestion = new System.Windows.Forms.RichTextBox();
            this.txtFormattedQuestion = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Question Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(423, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Formatted Question";
            // 
            // chkInsertQnum
            // 
            this.chkInsertQnum.AutoSize = true;
            this.chkInsertQnum.Location = new System.Drawing.Point(468, 50);
            this.chkInsertQnum.Name = "chkInsertQnum";
            this.chkInsertQnum.Size = new System.Drawing.Size(88, 17);
            this.chkInsertQnum.TabIndex = 4;
            this.chkInsertQnum.Text = "Insert Qnums";
            this.chkInsertQnum.UseVisualStyleBackColor = true;
            // 
            // chkInsertCC
            // 
            this.chkInsertCC.AutoSize = true;
            this.chkInsertCC.Location = new System.Drawing.Point(467, 74);
            this.chkInsertCC.Name = "chkInsertCC";
            this.chkInsertCC.Size = new System.Drawing.Size(69, 17);
            this.chkInsertCC.TabIndex = 5;
            this.chkInsertCC.Text = "Insert CC";
            this.chkInsertCC.UseVisualStyleBackColor = true;
            // 
            // lstStandardFields
            // 
            this.lstStandardFields.FormattingEnabled = true;
            this.lstStandardFields.Location = new System.Drawing.Point(75, 35);
            this.lstStandardFields.Name = "lstStandardFields";
            this.lstStandardFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstStandardFields.Size = new System.Drawing.Size(82, 108);
            this.lstStandardFields.TabIndex = 6;
            this.lstStandardFields.Click += new System.EventHandler(this.lstStandardFields_Click);
            this.lstStandardFields.SelectedIndexChanged += new System.EventHandler(this.lstStandardFields_SelectedIndexChanged);
            // 
            // txtBaseQuestion
            // 
            this.txtBaseQuestion.Location = new System.Drawing.Point(75, 168);
            this.txtBaseQuestion.Name = "txtBaseQuestion";
            this.txtBaseQuestion.Size = new System.Drawing.Size(330, 270);
            this.txtBaseQuestion.TabIndex = 7;
            this.txtBaseQuestion.Text = "";
            // 
            // txtFormattedQuestion
            // 
            this.txtFormattedQuestion.Location = new System.Drawing.Point(425, 170);
            this.txtFormattedQuestion.Name = "txtFormattedQuestion";
            this.txtFormattedQuestion.Size = new System.Drawing.Size(322, 267);
            this.txtFormattedQuestion.TabIndex = 8;
            this.txtFormattedQuestion.Text = "";
            // 
            // QuestionPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtFormattedQuestion);
            this.Controls.Add(this.txtBaseQuestion);
            this.Controls.Add(this.lstStandardFields);
            this.Controls.Add(this.chkInsertCC);
            this.Controls.Add(this.chkInsertQnum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QuestionPreview";
            this.Text = "QuestionPreview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkInsertQnum;
        private System.Windows.Forms.CheckBox chkInsertCC;
        private System.Windows.Forms.ListBox lstStandardFields;
        private System.Windows.Forms.RichTextBox txtBaseQuestion;
        private System.Windows.Forms.RichTextBox txtFormattedQuestion;
    }
}