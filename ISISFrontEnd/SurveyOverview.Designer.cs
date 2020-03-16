namespace ISISFrontEnd
{
    partial class SurveyOverview
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
            this.components = new System.ComponentModel.Container();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.cboSurvey = new System.Windows.Forms.ComboBox();
            this.lblSurvey = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.qrySurveyQuestionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmdClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qrySurveyQuestionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Location = new System.Drawing.Point(67, 109);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(81, 24);
            this.cmdGenerate.TabIndex = 0;
            this.cmdGenerate.Text = "Generate";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // cboSurvey
            // 
            this.cboSurvey.FormattingEnabled = true;
            this.cboSurvey.Location = new System.Drawing.Point(83, 71);
            this.cboSurvey.Name = "cboSurvey";
            this.cboSurvey.Size = new System.Drawing.Size(91, 21);
            this.cboSurvey.TabIndex = 1;
            // 
            // lblSurvey
            // 
            this.lblSurvey.AutoSize = true;
            this.lblSurvey.Location = new System.Drawing.Point(28, 70);
            this.lblSurvey.Name = "lblSurvey";
            this.lblSurvey.Size = new System.Drawing.Size(40, 13);
            this.lblSurvey.TabIndex = 2;
            this.lblSurvey.Text = "Survey";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(25, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 31);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Survey Overview";
            // 
            // qrySurveyQuestionsBindingSource
            // 
            this.qrySurveyQuestionsBindingSource.DataMember = "qrySurveyQuestions";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(251, 10);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(46, 29);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // SurveyOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 168);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSurvey);
            this.Controls.Add(this.cboSurvey);
            this.Controls.Add(this.cmdGenerate);
            this.Name = "SurveyOverview";
            this.Text = "Survey Overview";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SurveyOverview_FormClosed);
            this.Load += new System.EventHandler(this.SurveyOverview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qrySurveyQuestionsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.ComboBox cboSurvey;
        private System.Windows.Forms.Label lblSurvey;
        private System.Windows.Forms.Label lblTitle;
        
        private System.Windows.Forms.BindingSource qrySurveyQuestionsBindingSource;
       
        private System.Windows.Forms.Button cmdClose;
    }
}

