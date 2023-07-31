namespace SDIFrontEnd
{
    partial class ResponseSetSearch
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
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCriteria = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.repeaterResults = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.cmdViewUsage = new System.Windows.Forms.Button();
            this.txtRespOptions = new System.Windows.Forms.TextBox();
            this.txtRespName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboResponseType = new System.Windows.Forms.ComboBox();
            this.lblResultCount = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbMatchExact = new System.Windows.Forms.RadioButton();
            this.rbMatchAny = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.repeaterResults.ItemTemplate.SuspendLayout();
            this.repeaterResults.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(730, 24);
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
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // txtCriteria
            // 
            this.txtCriteria.Location = new System.Drawing.Point(14, 90);
            this.txtCriteria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCriteria.Multiline = true;
            this.txtCriteria.Name = "txtCriteria";
            this.txtCriteria.Size = new System.Drawing.Size(578, 120);
            this.txtCriteria.TabIndex = 1;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(598, 181);
            this.cmdSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(87, 28);
            this.cmdSearch.TabIndex = 2;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // repeaterResults
            // 
            this.repeaterResults.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            // 
            // repeaterResults.ItemTemplate
            // 
            this.repeaterResults.ItemTemplate.Controls.Add(this.cmdViewUsage);
            this.repeaterResults.ItemTemplate.Controls.Add(this.txtRespOptions);
            this.repeaterResults.ItemTemplate.Controls.Add(this.txtRespName);
            this.repeaterResults.ItemTemplate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.repeaterResults.ItemTemplate.Size = new System.Drawing.Size(699, 168);
            this.repeaterResults.Location = new System.Drawing.Point(14, 234);
            this.repeaterResults.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.repeaterResults.Name = "repeaterResults";
            this.repeaterResults.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.repeaterResults.Size = new System.Drawing.Size(707, 668);
            this.repeaterResults.TabIndex = 3;
            this.repeaterResults.Text = "dataRepeater1";
            this.repeaterResults.Visible = false;
            // 
            // cmdViewUsage
            // 
            this.cmdViewUsage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmdViewUsage.Location = new System.Drawing.Point(565, 4);
            this.cmdViewUsage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdViewUsage.Name = "cmdViewUsage";
            this.cmdViewUsage.Size = new System.Drawing.Size(87, 31);
            this.cmdViewUsage.TabIndex = 2;
            this.cmdViewUsage.Text = "Usage";
            this.cmdViewUsage.UseVisualStyleBackColor = false;
            this.cmdViewUsage.Click += new System.EventHandler(this.cmdViewUsage_Click);
            // 
            // txtRespOptions
            // 
            this.txtRespOptions.Location = new System.Drawing.Point(3, 35);
            this.txtRespOptions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRespOptions.Multiline = true;
            this.txtRespOptions.Name = "txtRespOptions";
            this.txtRespOptions.Size = new System.Drawing.Size(556, 120);
            this.txtRespOptions.TabIndex = 1;
            // 
            // txtRespName
            // 
            this.txtRespName.Location = new System.Drawing.Point(3, 4);
            this.txtRespName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRespName.Name = "txtRespName";
            this.txtRespName.Size = new System.Drawing.Size(116, 23);
            this.txtRespName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(195, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 33);
            this.label1.TabIndex = 4;
            this.label1.Text = "Response Set Search";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Search:";
            // 
            // cboResponseType
            // 
            this.cboResponseType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboResponseType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboResponseType.FormattingEnabled = true;
            this.cboResponseType.Items.AddRange(new object[] {
            "RespOptions",
            "NonRespOptions"});
            this.cboResponseType.Location = new System.Drawing.Point(79, 61);
            this.cboResponseType.Name = "cboResponseType";
            this.cboResponseType.Size = new System.Drawing.Size(121, 24);
            this.cboResponseType.TabIndex = 6;
            // 
            // lblResultCount
            // 
            this.lblResultCount.AutoSize = true;
            this.lblResultCount.Location = new System.Drawing.Point(16, 215);
            this.lblResultCount.Name = "lblResultCount";
            this.lblResultCount.Size = new System.Drawing.Size(85, 16);
            this.lblResultCount.TabIndex = 7;
            this.lblResultCount.Text = "results found.";
            this.lblResultCount.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbMatchExact);
            this.groupBox1.Controls.Add(this.rbMatchAny);
            this.groupBox1.Location = new System.Drawing.Point(598, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(87, 83);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Match";
            // 
            // rbMatchExact
            // 
            this.rbMatchExact.AutoSize = true;
            this.rbMatchExact.Location = new System.Drawing.Point(15, 47);
            this.rbMatchExact.Name = "rbMatchExact";
            this.rbMatchExact.Size = new System.Drawing.Size(55, 20);
            this.rbMatchExact.TabIndex = 1;
            this.rbMatchExact.TabStop = true;
            this.rbMatchExact.Text = "Exact";
            this.rbMatchExact.UseVisualStyleBackColor = true;
            // 
            // rbMatchAny
            // 
            this.rbMatchAny.AutoSize = true;
            this.rbMatchAny.Checked = true;
            this.rbMatchAny.Location = new System.Drawing.Point(14, 22);
            this.rbMatchAny.Name = "rbMatchAny";
            this.rbMatchAny.Size = new System.Drawing.Size(46, 20);
            this.rbMatchAny.TabIndex = 0;
            this.rbMatchAny.TabStop = true;
            this.rbMatchAny.Text = "Any";
            this.rbMatchAny.UseVisualStyleBackColor = true;
            // 
            // ResponseSetSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(730, 915);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblResultCount);
            this.Controls.Add(this.cboResponseType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.repeaterResults);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtCriteria);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ResponseSetSearch";
            this.Text = "Response Set Search";
            this.Load += new System.EventHandler(this.ResponseSetSearch_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.repeaterResults.ItemTemplate.ResumeLayout(false);
            this.repeaterResults.ItemTemplate.PerformLayout();
            this.repeaterResults.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.TextBox txtCriteria;
        private System.Windows.Forms.Button cmdSearch;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater repeaterResults;
        private System.Windows.Forms.Button cmdViewUsage;
        private System.Windows.Forms.TextBox txtRespOptions;
        private System.Windows.Forms.TextBox txtRespName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboResponseType;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.Label lblResultCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbMatchExact;
        private System.Windows.Forms.RadioButton rbMatchAny;
    }
}