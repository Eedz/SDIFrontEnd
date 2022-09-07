namespace SDIFrontEnd
{
    partial class TranslationViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TranslationViewer));
            this.txtVarName = new System.Windows.Forms.TextBox();
            this.txtSurvey = new System.Windows.Forms.TextBox();
            this.rtbTranslationText = new System.Windows.Forms.RichTextBox();
            this.txtLanguage = new System.Windows.Forms.TextBox();
            this.navTranslations = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.rtbPreP = new System.Windows.Forms.RichTextBox();
            this.rtbPstP = new System.Windows.Forms.RichTextBox();
            this.cmdItalic = new System.Windows.Forms.Button();
            this.cmdBold = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.navTranslations)).BeginInit();
            this.navTranslations.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtVarName
            // 
            this.txtVarName.BackColor = System.Drawing.Color.White;
            this.txtVarName.Location = new System.Drawing.Point(128, 4);
            this.txtVarName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVarName.Name = "txtVarName";
            this.txtVarName.ReadOnly = true;
            this.txtVarName.Size = new System.Drawing.Size(116, 23);
            this.txtVarName.TabIndex = 0;
            // 
            // txtSurvey
            // 
            this.txtSurvey.BackColor = System.Drawing.Color.White;
            this.txtSurvey.Location = new System.Drawing.Point(6, 4);
            this.txtSurvey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSurvey.Name = "txtSurvey";
            this.txtSurvey.ReadOnly = true;
            this.txtSurvey.Size = new System.Drawing.Size(116, 23);
            this.txtSurvey.TabIndex = 1;
            // 
            // rtbTranslationText
            // 
            this.rtbTranslationText.BackColor = System.Drawing.Color.White;
            this.rtbTranslationText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbTranslationText.Location = new System.Drawing.Point(5, 116);
            this.rtbTranslationText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbTranslationText.Name = "rtbTranslationText";
            this.rtbTranslationText.Size = new System.Drawing.Size(493, 292);
            this.rtbTranslationText.TabIndex = 2;
            this.rtbTranslationText.Text = "";
            // 
            // txtLanguage
            // 
            this.txtLanguage.BackColor = System.Drawing.Color.White;
            this.txtLanguage.Location = new System.Drawing.Point(250, 4);
            this.txtLanguage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.ReadOnly = true;
            this.txtLanguage.Size = new System.Drawing.Size(116, 23);
            this.txtLanguage.TabIndex = 3;
            // 
            // navTranslations
            // 
            this.navTranslations.AddNewItem = null;
            this.navTranslations.CountItem = this.bindingNavigatorCountItem;
            this.navTranslations.DeleteItem = null;
            this.navTranslations.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navTranslations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.navTranslations.Location = new System.Drawing.Point(0, 493);
            this.navTranslations.MoveFirstItem = null;
            this.navTranslations.MoveLastItem = null;
            this.navTranslations.MoveNextItem = null;
            this.navTranslations.MovePreviousItem = null;
            this.navTranslations.Name = "navTranslations";
            this.navTranslations.PositionItem = this.bindingNavigatorPositionItem;
            this.navTranslations.Size = new System.Drawing.Size(505, 25);
            this.navTranslations.TabIndex = 4;
            this.navTranslations.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(58, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // rtbPreP
            // 
            this.rtbPreP.BackColor = System.Drawing.Color.White;
            this.rtbPreP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbPreP.Location = new System.Drawing.Point(5, 32);
            this.rtbPreP.Name = "rtbPreP";
            this.rtbPreP.ReadOnly = true;
            this.rtbPreP.Size = new System.Drawing.Size(493, 57);
            this.rtbPreP.TabIndex = 7;
            this.rtbPreP.Text = "";
            // 
            // rtbPstP
            // 
            this.rtbPstP.BackColor = System.Drawing.Color.White;
            this.rtbPstP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbPstP.Location = new System.Drawing.Point(5, 411);
            this.rtbPstP.Name = "rtbPstP";
            this.rtbPstP.ReadOnly = true;
            this.rtbPstP.Size = new System.Drawing.Size(493, 74);
            this.rtbPstP.TabIndex = 8;
            this.rtbPstP.Text = "";
            // 
            // cmdItalic
            // 
            this.cmdItalic.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdItalic.Location = new System.Drawing.Point(33, 92);
            this.cmdItalic.Name = "cmdItalic";
            this.cmdItalic.Size = new System.Drawing.Size(27, 23);
            this.cmdItalic.TabIndex = 16;
            this.cmdItalic.Text = "I";
            this.cmdItalic.UseCompatibleTextRendering = true;
            this.cmdItalic.UseVisualStyleBackColor = true;
            this.cmdItalic.Click += new System.EventHandler(this.cmdItalic_Click);
            // 
            // cmdBold
            // 
            this.cmdBold.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBold.Location = new System.Drawing.Point(6, 92);
            this.cmdBold.Name = "cmdBold";
            this.cmdBold.Size = new System.Drawing.Size(27, 23);
            this.cmdBold.TabIndex = 15;
            this.cmdBold.Text = "B";
            this.cmdBold.UseCompatibleTextRendering = true;
            this.cmdBold.UseVisualStyleBackColor = true;
            this.cmdBold.Click += new System.EventHandler(this.cmdBold_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(423, 4);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 18;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // TranslationViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(196)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(505, 518);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdItalic);
            this.Controls.Add(this.cmdBold);
            this.Controls.Add(this.rtbPstP);
            this.Controls.Add(this.rtbPreP);
            this.Controls.Add(this.navTranslations);
            this.Controls.Add(this.txtLanguage);
            this.Controls.Add(this.rtbTranslationText);
            this.Controls.Add(this.txtSurvey);
            this.Controls.Add(this.txtVarName);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TranslationViewer";
            this.Text = "Translations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TranslationViewer_FormClosing);
            this.Load += new System.EventHandler(this.TranslationViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navTranslations)).EndInit();
            this.navTranslations.ResumeLayout(false);
            this.navTranslations.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVarName;
        private System.Windows.Forms.TextBox txtSurvey;
        private System.Windows.Forms.RichTextBox rtbTranslationText;
        private System.Windows.Forms.TextBox txtLanguage;
        private System.Windows.Forms.BindingNavigator navTranslations;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.RichTextBox rtbPreP;
        private System.Windows.Forms.RichTextBox rtbPstP;
        private System.Windows.Forms.Button cmdItalic;
        private System.Windows.Forms.Button cmdBold;
        private System.Windows.Forms.Button cmdSave;
    }
}