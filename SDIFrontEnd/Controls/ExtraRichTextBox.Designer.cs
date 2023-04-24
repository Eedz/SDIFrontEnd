namespace SDIFrontEnd
{
    partial class ExtraRichTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbFontFamily = new System.Windows.Forms.ComboBox();
            this.cmbFontSize = new System.Windows.Forms.ComboBox();
            this.txtFunctionality = new System.Windows.Forms.RichTextBox();
            this.ckbUnderline = new System.Windows.Forms.CheckBox();
            this.ckbItalic = new System.Windows.Forms.CheckBox();
            this.ckbBold = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmbFontFamily
            // 
            this.cmbFontFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFontFamily.FormattingEnabled = true;
            this.cmbFontFamily.Location = new System.Drawing.Point(250, 7);
            this.cmbFontFamily.Name = "cmbFontFamily";
            this.cmbFontFamily.Size = new System.Drawing.Size(121, 21);
            this.cmbFontFamily.TabIndex = 0;
            this.cmbFontFamily.SelectedIndexChanged += new System.EventHandler(this.cmbFontFamily_SelectedIndexChanged);
            // 
            // cmbFontSize
            // 
            this.cmbFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFontSize.FormattingEnabled = true;
            this.cmbFontSize.Location = new System.Drawing.Point(377, 7);
            this.cmbFontSize.Name = "cmbFontSize";
            this.cmbFontSize.Size = new System.Drawing.Size(46, 21);
            this.cmbFontSize.TabIndex = 1;
            this.cmbFontSize.SelectedIndexChanged += new System.EventHandler(this.cmbFontSize_SelectedIndexChanged);
            // 
            // txtFunctionality
            // 
            this.txtFunctionality.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFunctionality.Location = new System.Drawing.Point(0, 32);
            this.txtFunctionality.Name = "txtFunctionality";
            this.txtFunctionality.Size = new System.Drawing.Size(426, 303);
            this.txtFunctionality.TabIndex = 5;
            this.txtFunctionality.Text = "";
            this.txtFunctionality.SelectionChanged += new System.EventHandler(this.txtFunctionality_SelectionChanged);
            // 
            // ckbUnderline
            // 
            this.ckbUnderline.Appearance = System.Windows.Forms.Appearance.Button;
            this.ckbUnderline.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbUnderline.Location = new System.Drawing.Point(60, 3);
            this.ckbUnderline.Name = "ckbUnderline";
            this.ckbUnderline.Size = new System.Drawing.Size(22, 25);
            this.ckbUnderline.TabIndex = 4;
            this.ckbUnderline.Text = "U";
            this.ckbUnderline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbUnderline.UseCompatibleTextRendering = true;
            this.ckbUnderline.UseVisualStyleBackColor = true;
            this.ckbUnderline.CheckedChanged += new System.EventHandler(this.ckbUnderline_CheckedChanged);
            // 
            // ckbItalic
            // 
            this.ckbItalic.Appearance = System.Windows.Forms.Appearance.Button;
            this.ckbItalic.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbItalic.Location = new System.Drawing.Point(32, 3);
            this.ckbItalic.Name = "ckbItalic";
            this.ckbItalic.Size = new System.Drawing.Size(22, 25);
            this.ckbItalic.TabIndex = 3;
            this.ckbItalic.Text = "I";
            this.ckbItalic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbItalic.UseVisualStyleBackColor = true;
            this.ckbItalic.CheckedChanged += new System.EventHandler(this.ckbItalic_CheckedChanged);
            // 
            // ckbBold
            // 
            this.ckbBold.Appearance = System.Windows.Forms.Appearance.Button;
            this.ckbBold.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbBold.Location = new System.Drawing.Point(3, 3);
            this.ckbBold.Name = "ckbBold";
            this.ckbBold.Size = new System.Drawing.Size(22, 23);
            this.ckbBold.TabIndex = 2;
            this.ckbBold.Text = "B";
            this.ckbBold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbBold.UseCompatibleTextRendering = true;
            this.ckbBold.UseVisualStyleBackColor = true;
            this.ckbBold.CheckedChanged += new System.EventHandler(this.ckbBold_CheckedChanged);
            // 
            // ExtraRichTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtFunctionality);
            this.Controls.Add(this.ckbUnderline);
            this.Controls.Add(this.ckbItalic);
            this.Controls.Add(this.ckbBold);
            this.Controls.Add(this.cmbFontSize);
            this.Controls.Add(this.cmbFontFamily);
            this.Name = "ExtraRichTextBox";
            this.Size = new System.Drawing.Size(432, 340);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFontFamily;
        private System.Windows.Forms.ComboBox cmbFontSize;
        private System.Windows.Forms.RichTextBox txtFunctionality;
        private System.Windows.Forms.CheckBox ckbUnderline;
        private System.Windows.Forms.CheckBox ckbItalic;
        private System.Windows.Forms.CheckBox ckbBold;
    }
}
