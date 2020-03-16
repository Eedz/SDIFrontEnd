namespace ISISFrontEnd
{
    partial class CreateSurvey
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
            this.lstReport = new System.Windows.Forms.ListView();
            this.NewQ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OldQ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AltQnum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VarName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VarLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Source = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RespName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TableFormat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Corrected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cboSurvey = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.chkHighlightCorrected = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lstReport
            // 
            this.lstReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NewQ,
            this.OldQ,
            this.AltQnum,
            this.VarName,
            this.VarLabel,
            this.Source,
            this.RespName,
            this.TableFormat,
            this.Corrected});
            this.lstReport.FullRowSelect = true;
            this.lstReport.Location = new System.Drawing.Point(12, 130);
            this.lstReport.Name = "lstReport";
            this.lstReport.Size = new System.Drawing.Size(733, 435);
            this.lstReport.TabIndex = 0;
            this.lstReport.UseCompatibleStateImageBehavior = false;
            this.lstReport.View = System.Windows.Forms.View.List;
            this.lstReport.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstReport_MouseDoubleClick);
            // 
            // NewQ
            // 
            this.NewQ.Text = "New Q#";
            // 
            // OldQ
            // 
            this.OldQ.Text = "Old Q#";
            // 
            // AltQnum
            // 
            this.AltQnum.Text = "AltQnum";
            // 
            // VarName
            // 
            this.VarName.Text = "VarName";
            // 
            // VarLabel
            // 
            this.VarLabel.Text = "VarLabel";
            this.VarLabel.Width = 240;
            // 
            // Source
            // 
            this.Source.Text = "IN";
            // 
            // RespName
            // 
            this.RespName.Text = "RespName";
            // 
            // TableFormat
            // 
            this.TableFormat.Text = "TableFormat";
            // 
            // Corrected
            // 
            this.Corrected.Text = "Corrected";
            // 
            // cboSurvey
            // 
            this.cboSurvey.FormattingEnabled = true;
            this.cboSurvey.Location = new System.Drawing.Point(12, 59);
            this.cboSurvey.Name = "cboSurvey";
            this.cboSurvey.Size = new System.Drawing.Size(77, 21);
            this.cboSurvey.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(687, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Create/Edit Survey";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(688, 10);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(56, 28);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // chkHighlightCorrected
            // 
            this.chkHighlightCorrected.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkHighlightCorrected.AutoSize = true;
            this.chkHighlightCorrected.Location = new System.Drawing.Point(435, 58);
            this.chkHighlightCorrected.Name = "chkHighlightCorrected";
            this.chkHighlightCorrected.Size = new System.Drawing.Size(107, 23);
            this.chkHighlightCorrected.TabIndex = 5;
            this.chkHighlightCorrected.Text = "Highlight Corrected";
            this.chkHighlightCorrected.UseVisualStyleBackColor = true;
            this.chkHighlightCorrected.CheckedChanged += new System.EventHandler(this.chkHighlightCorrected_CheckedChanged);
            // 
            // CreateSurvey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 577);
            this.Controls.Add(this.chkHighlightCorrected);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboSurvey);
            this.Controls.Add(this.lstReport);
            this.Name = "CreateSurvey";
            this.Text = "CreateSurvey";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CreateSurvey_FormClosed);
            this.Load += new System.EventHandler(this.CreateSurvey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstReport;
        private System.Windows.Forms.ColumnHeader NewQ;
        private System.Windows.Forms.ColumnHeader OldQ;
        private System.Windows.Forms.ColumnHeader VarName;
        private System.Windows.Forms.ColumnHeader VarLabel;
        private System.Windows.Forms.ColumnHeader Source;
        private System.Windows.Forms.ColumnHeader RespName;
        private System.Windows.Forms.ColumnHeader TableFormat;
        private System.Windows.Forms.ColumnHeader Corrected;
        private System.Windows.Forms.ComboBox cboSurvey;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader AltQnum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.CheckBox chkHighlightCorrected;
    }
}