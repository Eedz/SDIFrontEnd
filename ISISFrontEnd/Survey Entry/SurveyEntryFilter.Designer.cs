namespace ISISFrontEnd
{
    partial class SurveyEntryFilter
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
            this.cboMain = new System.Windows.Forms.ComboBox();
            this.txtBrown = new System.Windows.Forms.TextBox();
            this.txtGreen = new System.Windows.Forms.TextBox();
            this.cboSurveys = new System.Windows.Forms.ComboBox();
            this.cmdAddBrown = new System.Windows.Forms.Button();
            this.cmdAddGreen = new System.Windows.Forms.Button();
            this.cmdApply = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdAddAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboMain
            // 
            this.cboMain.FormattingEnabled = true;
            this.cboMain.Location = new System.Drawing.Point(87, 12);
            this.cboMain.Name = "cboMain";
            this.cboMain.Size = new System.Drawing.Size(121, 21);
            this.cboMain.TabIndex = 0;
            // 
            // txtBrown
            // 
            this.txtBrown.Location = new System.Drawing.Point(87, 43);
            this.txtBrown.Name = "txtBrown";
            this.txtBrown.Size = new System.Drawing.Size(121, 20);
            this.txtBrown.TabIndex = 1;
            // 
            // txtGreen
            // 
            this.txtGreen.Location = new System.Drawing.Point(87, 79);
            this.txtGreen.Name = "txtGreen";
            this.txtGreen.Size = new System.Drawing.Size(121, 20);
            this.txtGreen.TabIndex = 2;
            // 
            // cboSurveys
            // 
            this.cboSurveys.FormattingEnabled = true;
            this.cboSurveys.Location = new System.Drawing.Point(255, 44);
            this.cboSurveys.Name = "cboSurveys";
            this.cboSurveys.Size = new System.Drawing.Size(121, 21);
            this.cboSurveys.TabIndex = 3;
            // 
            // cmdAddBrown
            // 
            this.cmdAddBrown.Location = new System.Drawing.Point(213, 43);
            this.cmdAddBrown.Name = "cmdAddBrown";
            this.cmdAddBrown.Size = new System.Drawing.Size(28, 20);
            this.cmdAddBrown.TabIndex = 4;
            this.cmdAddBrown.Text = "<";
            this.cmdAddBrown.UseVisualStyleBackColor = true;
            this.cmdAddBrown.Click += new System.EventHandler(this.cmdAddBrown_Click);
            // 
            // cmdAddGreen
            // 
            this.cmdAddGreen.Location = new System.Drawing.Point(214, 79);
            this.cmdAddGreen.Name = "cmdAddGreen";
            this.cmdAddGreen.Size = new System.Drawing.Size(27, 20);
            this.cmdAddGreen.TabIndex = 5;
            this.cmdAddGreen.Text = "<";
            this.cmdAddGreen.UseVisualStyleBackColor = true;
            this.cmdAddGreen.Click += new System.EventHandler(this.cmdAddGreen_Click);
            // 
            // cmdApply
            // 
            this.cmdApply.Location = new System.Drawing.Point(11, 114);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(80, 25);
            this.cmdApply.TabIndex = 6;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(97, 114);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(59, 26);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(162, 114);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(46, 26);
            this.cmdClear.TabIndex = 8;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdAddAll
            // 
            this.cmdAddAll.Location = new System.Drawing.Point(214, 114);
            this.cmdAddAll.Name = "cmdAddAll";
            this.cmdAddAll.Size = new System.Drawing.Size(27, 26);
            this.cmdAddAll.TabIndex = 9;
            this.cmdAddAll.Text = "All";
            this.cmdAddAll.UseVisualStyleBackColor = true;
            this.cmdAddAll.Click += new System.EventHandler(this.cmdAddAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Main Survey";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Brown Survey";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Green Survey";
            // 
            // SurveyEntryFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 170);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdAddAll);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdApply);
            this.Controls.Add(this.cmdAddGreen);
            this.Controls.Add(this.cmdAddBrown);
            this.Controls.Add(this.cboSurveys);
            this.Controls.Add(this.txtGreen);
            this.Controls.Add(this.txtBrown);
            this.Controls.Add(this.cboMain);
            this.Name = "SurveyEntryFilter";
            this.Text = "SurveyEntryFilter";
            this.Load += new System.EventHandler(this.SurveyEntryFilter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMain;
        private System.Windows.Forms.TextBox txtBrown;
        private System.Windows.Forms.TextBox txtGreen;
        private System.Windows.Forms.ComboBox cboSurveys;
        private System.Windows.Forms.Button cmdAddBrown;
        private System.Windows.Forms.Button cmdAddGreen;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Button cmdAddAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}