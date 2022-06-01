namespace ISISFrontEnd
{
    partial class ProductCrosstab
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstSurvey = new System.Windows.Forms.ListBox();
            this.lstPrefix = new System.Windows.Forms.ListBox();
            this.lstTopic = new System.Windows.Forms.ListBox();
            this.lstContent = new System.Windows.Forms.ListBox();
            this.lstProduct = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.chkAll4C = new System.Windows.Forms.CheckBox();
            this.chkAllNCT = new System.Windows.Forms.CheckBox();
            this.chkIncludeNA = new System.Windows.Forms.CheckBox();
            this.chkExpanded = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(933, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // lstSurvey
            // 
            this.lstSurvey.FormattingEnabled = true;
            this.lstSurvey.ItemHeight = 16;
            this.lstSurvey.Location = new System.Drawing.Point(36, 94);
            this.lstSurvey.Name = "lstSurvey";
            this.lstSurvey.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstSurvey.Size = new System.Drawing.Size(105, 292);
            this.lstSurvey.TabIndex = 1;
            this.lstSurvey.SelectedIndexChanged += new System.EventHandler(this.lstSurvey_SelectedIndexChanged);
            // 
            // lstPrefix
            // 
            this.lstPrefix.FormattingEnabled = true;
            this.lstPrefix.ItemHeight = 16;
            this.lstPrefix.Location = new System.Drawing.Point(147, 94);
            this.lstPrefix.Name = "lstPrefix";
            this.lstPrefix.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstPrefix.Size = new System.Drawing.Size(67, 292);
            this.lstPrefix.TabIndex = 2;
            this.lstPrefix.SelectedIndexChanged += new System.EventHandler(this.lstPrefix_SelectedIndexChanged);
            // 
            // lstTopic
            // 
            this.lstTopic.FormattingEnabled = true;
            this.lstTopic.ItemHeight = 16;
            this.lstTopic.Location = new System.Drawing.Point(220, 94);
            this.lstTopic.Name = "lstTopic";
            this.lstTopic.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstTopic.Size = new System.Drawing.Size(196, 292);
            this.lstTopic.TabIndex = 3;
            this.lstTopic.SelectedIndexChanged += new System.EventHandler(this.lstTopic_SelectedIndexChanged);
            // 
            // lstContent
            // 
            this.lstContent.FormattingEnabled = true;
            this.lstContent.ItemHeight = 16;
            this.lstContent.Location = new System.Drawing.Point(422, 94);
            this.lstContent.Name = "lstContent";
            this.lstContent.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstContent.Size = new System.Drawing.Size(199, 292);
            this.lstContent.TabIndex = 4;
            this.lstContent.SelectedIndexChanged += new System.EventHandler(this.lstContent_SelectedIndexChanged);
            // 
            // lstProduct
            // 
            this.lstProduct.FormattingEnabled = true;
            this.lstProduct.ItemHeight = 16;
            this.lstProduct.Location = new System.Drawing.Point(627, 94);
            this.lstProduct.Name = "lstProduct";
            this.lstProduct.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstProduct.Size = new System.Drawing.Size(105, 292);
            this.lstProduct.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Survey";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Prefix";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Topic";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(483, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Content";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(650, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Product";
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Location = new System.Drawing.Point(639, 469);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(75, 23);
            this.cmdGenerate.TabIndex = 11;
            this.cmdGenerate.Text = "Generate";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // chkAll4C
            // 
            this.chkAll4C.AutoSize = true;
            this.chkAll4C.Location = new System.Drawing.Point(52, 392);
            this.chkAll4C.Name = "chkAll4C";
            this.chkAll4C.Size = new System.Drawing.Size(60, 20);
            this.chkAll4C.TabIndex = 12;
            this.chkAll4C.Text = "All 4C";
            this.chkAll4C.UseVisualStyleBackColor = true;
            this.chkAll4C.CheckedChanged += new System.EventHandler(this.chkAll4C_CheckedChanged);
            // 
            // chkAllNCT
            // 
            this.chkAllNCT.AutoSize = true;
            this.chkAllNCT.Location = new System.Drawing.Point(52, 418);
            this.chkAllNCT.Name = "chkAllNCT";
            this.chkAllNCT.Size = new System.Drawing.Size(69, 20);
            this.chkAllNCT.TabIndex = 13;
            this.chkAllNCT.Text = "All NCT";
            this.chkAllNCT.UseVisualStyleBackColor = true;
            this.chkAllNCT.CheckedChanged += new System.EventHandler(this.chkAllNCT_CheckedChanged);
            // 
            // chkIncludeNA
            // 
            this.chkIncludeNA.AutoSize = true;
            this.chkIncludeNA.Location = new System.Drawing.Point(250, 406);
            this.chkIncludeNA.Name = "chkIncludeNA";
            this.chkIncludeNA.Size = new System.Drawing.Size(88, 20);
            this.chkIncludeNA.TabIndex = 14;
            this.chkIncludeNA.Text = "Include NA";
            this.chkIncludeNA.UseVisualStyleBackColor = true;
            // 
            // chkExpanded
            // 
            this.chkExpanded.AutoSize = true;
            this.chkExpanded.Location = new System.Drawing.Point(250, 434);
            this.chkExpanded.Name = "chkExpanded";
            this.chkExpanded.Size = new System.Drawing.Size(82, 20);
            this.chkExpanded.TabIndex = 15;
            this.chkExpanded.Text = "Expanded";
            this.chkExpanded.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Product Crosstab";
            // 
            // ProductCrosstab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkExpanded);
            this.Controls.Add(this.chkIncludeNA);
            this.Controls.Add(this.chkAllNCT);
            this.Controls.Add(this.chkAll4C);
            this.Controls.Add(this.cmdGenerate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstProduct);
            this.Controls.Add(this.lstContent);
            this.Controls.Add(this.lstTopic);
            this.Controls.Add(this.lstPrefix);
            this.Controls.Add(this.lstSurvey);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProductCrosstab";
            this.Text = "ProductCrosstab";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProductCrosstab_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ListBox lstSurvey;
        private System.Windows.Forms.ListBox lstPrefix;
        private System.Windows.Forms.ListBox lstTopic;
        private System.Windows.Forms.ListBox lstContent;
        private System.Windows.Forms.ListBox lstProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.CheckBox chkAll4C;
        private System.Windows.Forms.CheckBox chkAllNCT;
        private System.Windows.Forms.CheckBox chkIncludeNA;
        private System.Windows.Forms.CheckBox chkExpanded;
        private System.Windows.Forms.Label label6;
    }
}