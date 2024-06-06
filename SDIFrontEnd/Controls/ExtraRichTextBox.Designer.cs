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
            this.chkStrike = new System.Windows.Forms.CheckBox();
            this.chkHighlight = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmbFontFamily
            // 
            this.cmbFontFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFontFamily.FormattingEnabled = true;
            this.cmbFontFamily.Location = new System.Drawing.Point(126, 1);
            this.cmbFontFamily.Name = "cmbFontFamily";
            this.cmbFontFamily.Size = new System.Drawing.Size(110, 21);
            this.cmbFontFamily.TabIndex = 0;
            this.cmbFontFamily.SelectedIndexChanged += new System.EventHandler(this.cmbFontFamily_SelectedIndexChanged);
            // 
            // cmbFontSize
            // 
            this.cmbFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFontSize.FormattingEnabled = true;
            this.cmbFontSize.Location = new System.Drawing.Point(242, 1);
            this.cmbFontSize.Name = "cmbFontSize";
            this.cmbFontSize.Size = new System.Drawing.Size(46, 21);
            this.cmbFontSize.TabIndex = 1;
            this.cmbFontSize.SelectedIndexChanged += new System.EventHandler(this.cmbFontSize_SelectedIndexChanged);
            // 
            // txtFunctionality
            // 
            this.txtFunctionality.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFunctionality.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFunctionality.Location = new System.Drawing.Point(1, 25);
            this.txtFunctionality.Name = "txtFunctionality";
            this.txtFunctionality.Size = new System.Drawing.Size(288, 320);
            this.txtFunctionality.TabIndex = 5;
            this.txtFunctionality.Text = "";
            this.txtFunctionality.SelectionChanged += new System.EventHandler(this.txtFunctionality_SelectionChanged);
            // 
            // ckbUnderline
            // 
            this.ckbUnderline.Appearance = System.Windows.Forms.Appearance.Button;
            this.ckbUnderline.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbUnderline.Location = new System.Drawing.Point(50, 0);
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
            this.ckbItalic.Location = new System.Drawing.Point(25, 0);
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
            this.ckbBold.Location = new System.Drawing.Point(0, 0);
            this.ckbBold.Name = "ckbBold";
            this.ckbBold.Size = new System.Drawing.Size(22, 25);
            this.ckbBold.TabIndex = 2;
            this.ckbBold.Text = "B";
            this.ckbBold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbBold.UseCompatibleTextRendering = true;
            this.ckbBold.UseVisualStyleBackColor = true;
            this.ckbBold.CheckedChanged += new System.EventHandler(this.ckbBold_CheckedChanged);
            // 
            // chkStrike
            // 
            this.chkStrike.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkStrike.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStrike.Location = new System.Drawing.Point(74, 0);
            this.chkStrike.Name = "chkStrike";
            this.chkStrike.Size = new System.Drawing.Size(22, 25);
            this.chkStrike.TabIndex = 6;
            this.chkStrike.Text = "S";
            this.chkStrike.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkStrike.UseCompatibleTextRendering = true;
            this.chkStrike.UseVisualStyleBackColor = true;
            this.chkStrike.CheckedChanged += new System.EventHandler(this.chkStrike_CheckedChanged);
            // 
            // chkHighlight
            // 
            this.chkHighlight.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkHighlight.BackColor = System.Drawing.Color.Yellow;
            this.chkHighlight.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHighlight.Location = new System.Drawing.Point(98, 0);
            this.chkHighlight.Name = "chkHighlight";
            this.chkHighlight.Size = new System.Drawing.Size(22, 25);
            this.chkHighlight.TabIndex = 7;
            this.chkHighlight.Text = "H";
            this.chkHighlight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkHighlight.UseCompatibleTextRendering = true;
            this.chkHighlight.UseVisualStyleBackColor = false;
            this.chkHighlight.CheckedChanged += new System.EventHandler(this.chkHighlight_CheckedChanged);
            // 
            // ExtraRichTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.Controls.Add(this.chkHighlight);
            this.Controls.Add(this.chkStrike);
            this.Controls.Add(this.txtFunctionality);
            this.Controls.Add(this.ckbUnderline);
            this.Controls.Add(this.ckbItalic);
            this.Controls.Add(this.ckbBold);
            this.Controls.Add(this.cmbFontSize);
            this.Controls.Add(this.cmbFontFamily);
            this.Name = "ExtraRichTextBox";
            this.Size = new System.Drawing.Size(292, 348);
            this.Load += new System.EventHandler(this.ExtraRichTextBox_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFontFamily;
        private System.Windows.Forms.ComboBox cmbFontSize;
        private System.Windows.Forms.RichTextBox txtFunctionality;
        private System.Windows.Forms.CheckBox ckbUnderline;
        private System.Windows.Forms.CheckBox ckbItalic;
        private System.Windows.Forms.CheckBox ckbBold;
        private System.Windows.Forms.CheckBox chkStrike;
        private System.Windows.Forms.CheckBox chkHighlight;
    }
}
