namespace SDIFrontEnd
{
    partial class SurveyEditorSearch
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
            this.cboField = new System.Windows.Forms.ComboBox();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.cmdPrev = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboField
            // 
            this.cboField.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboField.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboField.FormattingEnabled = true;
            this.cboField.Items.AddRange(new object[] {
            "<All>",
            "PreP",
            "PreI",
            "PreA",
            "LitQ",
            "RespOptions",
            "NRCodes",
            "PstI",
            "PstP"});
            this.cboField.Location = new System.Drawing.Point(85, 6);
            this.cboField.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(140, 24);
            this.cboField.TabIndex = 0;
            this.cboField.SelectedIndexChanged += new System.EventHandler(this.cboField_SelectedIndexChanged);
            // 
            // txtSearchText
            // 
            this.txtSearchText.Location = new System.Drawing.Point(85, 37);
            this.txtSearchText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchText.Multiline = true;
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(140, 102);
            this.txtSearchText.TabIndex = 1;
            // 
            // cmdPrev
            // 
            this.cmdPrev.Location = new System.Drawing.Point(230, 6);
            this.cmdPrev.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdPrev.Name = "cmdPrev";
            this.cmdPrev.Size = new System.Drawing.Size(50, 25);
            this.cmdPrev.TabIndex = 2;
            this.cmdPrev.Text = "Prev";
            this.cmdPrev.UseVisualStyleBackColor = true;
            this.cmdPrev.Click += new System.EventHandler(this.cmdPrev_Click);
            // 
            // cmdNext
            // 
            this.cmdNext.Location = new System.Drawing.Point(284, 6);
            this.cmdNext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(50, 25);
            this.cmdNext.TabIndex = 3;
            this.cmdNext.Text = "Next";
            this.cmdNext.UseVisualStyleBackColor = true;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(230, 75);
            this.cmdClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(104, 28);
            this.cmdClear.TabIndex = 4;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(230, 111);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(104, 28);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Field";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Search Text";
            // 
            // SurveyEditorSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(214)))), ((int)(((byte)(155)))));
            this.ClientSize = new System.Drawing.Size(339, 143);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.cmdNext);
            this.Controls.Add(this.cmdPrev);
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.cboField);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SurveyEditorSearch";
            this.Text = "Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Button cmdPrev;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}