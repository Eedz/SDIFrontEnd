namespace SDIFrontEnd
{
    partial class frmLabelLibrary
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
            this.grpLabelType = new System.Windows.Forms.GroupBox();
            this.rbKeyword = new System.Windows.Forms.RadioButton();
            this.rbProduct = new System.Windows.Forms.RadioButton();
            this.rbContent = new System.Windows.Forms.RadioButton();
            this.rbTopic = new System.Windows.Forms.RadioButton();
            this.rbDomain = new System.Windows.Forms.RadioButton();
            this.dgvLabels = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showUsesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpLabelType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabels)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLabelType
            // 
            this.grpLabelType.Controls.Add(this.rbKeyword);
            this.grpLabelType.Controls.Add(this.rbProduct);
            this.grpLabelType.Controls.Add(this.rbContent);
            this.grpLabelType.Controls.Add(this.rbTopic);
            this.grpLabelType.Controls.Add(this.rbDomain);
            this.grpLabelType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLabelType.Location = new System.Drawing.Point(6, 36);
            this.grpLabelType.Name = "grpLabelType";
            this.grpLabelType.Size = new System.Drawing.Size(93, 137);
            this.grpLabelType.TabIndex = 3;
            this.grpLabelType.TabStop = false;
            this.grpLabelType.Text = "Label Type";
            // 
            // rbKeyword
            // 
            this.rbKeyword.AutoSize = true;
            this.rbKeyword.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbKeyword.Location = new System.Drawing.Point(8, 111);
            this.rbKeyword.Name = "rbKeyword";
            this.rbKeyword.Size = new System.Drawing.Size(75, 20);
            this.rbKeyword.TabIndex = 4;
            this.rbKeyword.TabStop = true;
            this.rbKeyword.Tag = "5";
            this.rbKeyword.Text = "Keyword";
            this.rbKeyword.UseVisualStyleBackColor = true;
            this.rbKeyword.CheckedChanged += new System.EventHandler(this.LabelTypeChanged);
            // 
            // rbProduct
            // 
            this.rbProduct.AutoSize = true;
            this.rbProduct.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbProduct.Location = new System.Drawing.Point(8, 88);
            this.rbProduct.Name = "rbProduct";
            this.rbProduct.Size = new System.Drawing.Size(69, 20);
            this.rbProduct.TabIndex = 3;
            this.rbProduct.TabStop = true;
            this.rbProduct.Tag = "4";
            this.rbProduct.Text = "Product";
            this.rbProduct.UseVisualStyleBackColor = true;
            this.rbProduct.CheckedChanged += new System.EventHandler(this.LabelTypeChanged);
            // 
            // rbContent
            // 
            this.rbContent.AutoSize = true;
            this.rbContent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbContent.Location = new System.Drawing.Point(8, 65);
            this.rbContent.Name = "rbContent";
            this.rbContent.Size = new System.Drawing.Size(70, 20);
            this.rbContent.TabIndex = 2;
            this.rbContent.TabStop = true;
            this.rbContent.Tag = "3";
            this.rbContent.Text = "Content";
            this.rbContent.UseVisualStyleBackColor = true;
            this.rbContent.CheckedChanged += new System.EventHandler(this.LabelTypeChanged);
            // 
            // rbTopic
            // 
            this.rbTopic.AutoSize = true;
            this.rbTopic.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTopic.Location = new System.Drawing.Point(8, 42);
            this.rbTopic.Name = "rbTopic";
            this.rbTopic.Size = new System.Drawing.Size(57, 20);
            this.rbTopic.TabIndex = 1;
            this.rbTopic.TabStop = true;
            this.rbTopic.Tag = "2";
            this.rbTopic.Text = "Topic";
            this.rbTopic.UseVisualStyleBackColor = true;
            this.rbTopic.CheckedChanged += new System.EventHandler(this.LabelTypeChanged);
            // 
            // rbDomain
            // 
            this.rbDomain.AutoSize = true;
            this.rbDomain.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDomain.Location = new System.Drawing.Point(8, 19);
            this.rbDomain.Name = "rbDomain";
            this.rbDomain.Size = new System.Drawing.Size(69, 20);
            this.rbDomain.TabIndex = 0;
            this.rbDomain.TabStop = true;
            this.rbDomain.Tag = "1";
            this.rbDomain.Text = "Domain";
            this.rbDomain.UseVisualStyleBackColor = true;
            this.rbDomain.CheckedChanged += new System.EventHandler(this.LabelTypeChanged);
            // 
            // dgvLabels
            // 
            this.dgvLabels.AllowUserToAddRows = false;
            this.dgvLabels.AllowUserToDeleteRows = false;
            this.dgvLabels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLabels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chID,
            this.chLabel,
            this.chCount});
            this.dgvLabels.Location = new System.Drawing.Point(105, 36);
            this.dgvLabels.MultiSelect = false;
            this.dgvLabels.Name = "dgvLabels";
            this.dgvLabels.ReadOnly = true;
            this.dgvLabels.RowHeadersVisible = false;
            this.dgvLabels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLabels.Size = new System.Drawing.Size(251, 275);
            this.dgvLabels.TabIndex = 4;
            this.dgvLabels.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLabels_CellDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.showUsesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(368, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.newToolStripMenuItem.Text = "New...";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // showUsesToolStripMenuItem
            // 
            this.showUsesToolStripMenuItem.Name = "showUsesToolStripMenuItem";
            this.showUsesToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.showUsesToolStripMenuItem.Text = "Show Uses...";
            this.showUsesToolStripMenuItem.Click += new System.EventHandler(this.showUsesToolStripMenuItem_Click);
            // 
            // chID
            // 
            this.chID.HeaderText = "ID";
            this.chID.Name = "chID";
            this.chID.ReadOnly = true;
            this.chID.Visible = false;
            // 
            // chLabel
            // 
            this.chLabel.HeaderText = "Label";
            this.chLabel.Name = "chLabel";
            this.chLabel.ReadOnly = true;
            this.chLabel.Width = 170;
            // 
            // chCount
            // 
            this.chCount.HeaderText = "Uses";
            this.chCount.Name = "chCount";
            this.chCount.ReadOnly = true;
            this.chCount.Width = 60;
            // 
            // frmLabelLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(236)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(368, 323);
            this.Controls.Add(this.dgvLabels);
            this.Controls.Add(this.grpLabelType);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmLabelLibrary";
            this.Text = "Label Library";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.grpLabelType.ResumeLayout(false);
            this.grpLabelType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabels)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpLabelType;
        private System.Windows.Forms.RadioButton rbKeyword;
        private System.Windows.Forms.RadioButton rbProduct;
        private System.Windows.Forms.RadioButton rbContent;
        private System.Windows.Forms.RadioButton rbTopic;
        private System.Windows.Forms.RadioButton rbDomain;
        private System.Windows.Forms.DataGridView dgvLabels;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showUsesToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn chID;
        private System.Windows.Forms.DataGridViewTextBoxColumn chLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCount;
    }
}

