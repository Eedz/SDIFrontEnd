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
            this.txtLanguage = new System.Windows.Forms.TextBox();
            this.rtbPreP = new System.Windows.Forms.RichTextBox();
            this.rtbPstP = new System.Windows.Forms.RichTextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.navTranslations = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.extraRichTextBox1 = new SDIFrontEnd.ExtraRichTextBox();
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
            this.rtbPstP.Location = new System.Drawing.Point(5, 507);
            this.rtbPstP.Name = "rtbPstP";
            this.rtbPstP.ReadOnly = true;
            this.rtbPstP.Size = new System.Drawing.Size(493, 74);
            this.rtbPstP.TabIndex = 8;
            this.rtbPstP.Text = "";
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
            // navTranslations
            // 
            this.navTranslations.AddNewItem = this.bindingNavigatorAddNewItem;
            this.navTranslations.CountItem = this.bindingNavigatorCountItem;
            this.navTranslations.DeleteItem = null;
            this.navTranslations.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navTranslations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5,
            this.bindingNavigatorDeleteItem,
            this.bindingNavigatorAddNewItem});
            this.navTranslations.Location = new System.Drawing.Point(0, 587);
            this.navTranslations.MoveFirstItem = null;
            this.navTranslations.MoveLastItem = null;
            this.navTranslations.MoveNextItem = null;
            this.navTranslations.MovePreviousItem = null;
            this.navTranslations.Name = "navTranslations";
            this.navTranslations.PositionItem = this.bindingNavigatorPositionItem;
            this.navTranslations.Size = new System.Drawing.Size(504, 25);
            this.navTranslations.TabIndex = 21;
            this.navTranslations.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Visible = false;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem1.Text = "Move first";
            this.bindingNavigatorMoveFirstItem1.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem1.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem1.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem1.Text = "Move next";
            this.bindingNavigatorMoveNextItem1.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem1.Text = "Move last";
            this.bindingNavigatorMoveLastItem1.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // extraRichTextBox1
            // 
            this.extraRichTextBox1.AutoScroll = true;
            this.extraRichTextBox1.Location = new System.Drawing.Point(5, 96);
            this.extraRichTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.extraRichTextBox1.Name = "extraRichTextBox1";
            this.extraRichTextBox1.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 " +
    "Tahoma;}}\r\n{\\*\\generator Riched20 10.0.19041}\\viewkind4\\uc1 \r\n\\pard\\f0\\fs20\\par\r" +
    "\n}\r\n";
            this.extraRichTextBox1.ShowFamilies = false;
            this.extraRichTextBox1.ShowHighlight = false;
            this.extraRichTextBox1.ShowSize = false;
            this.extraRichTextBox1.ShowStrike = false;
            this.extraRichTextBox1.Size = new System.Drawing.Size(493, 404);
            this.extraRichTextBox1.TabIndex = 20;
            // 
            // TranslationViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(196)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(504, 612);
            this.Controls.Add(this.navTranslations);
            this.Controls.Add(this.extraRichTextBox1);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.rtbPstP);
            this.Controls.Add(this.rtbPreP);
            this.Controls.Add(this.txtLanguage);
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
        private System.Windows.Forms.TextBox txtLanguage;
        private System.Windows.Forms.RichTextBox rtbPreP;
        private System.Windows.Forms.RichTextBox rtbPstP;
        private System.Windows.Forms.Button cmdSave;
        private ExtraRichTextBox extraRichTextBox1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.BindingNavigator navTranslations;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
    }
}