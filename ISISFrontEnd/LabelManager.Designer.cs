namespace ISISFrontEnd
{
    partial class LabelManager
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
            this.cmdClose = new System.Windows.Forms.Button();
            this.groupLabelType = new System.Windows.Forms.GroupBox();
            this.optProduct = new System.Windows.Forms.RadioButton();
            this.optContent = new System.Windows.Forms.RadioButton();
            this.optTopic = new System.Windows.Forms.RadioButton();
            this.optDomain = new System.Windows.Forms.RadioButton();
            this.gridLabels = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdNewLabel = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupLabelType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLabels)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(4, 2);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(68, 29);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // groupLabelType
            // 
            this.groupLabelType.Controls.Add(this.optProduct);
            this.groupLabelType.Controls.Add(this.optContent);
            this.groupLabelType.Controls.Add(this.optTopic);
            this.groupLabelType.Controls.Add(this.optDomain);
            this.groupLabelType.Location = new System.Drawing.Point(4, 48);
            this.groupLabelType.Name = "groupLabelType";
            this.groupLabelType.Size = new System.Drawing.Size(185, 84);
            this.groupLabelType.TabIndex = 1;
            this.groupLabelType.TabStop = false;
            this.groupLabelType.Text = "Label Type";
            // 
            // optProduct
            // 
            this.optProduct.AutoSize = true;
            this.optProduct.Location = new System.Drawing.Point(105, 47);
            this.optProduct.Name = "optProduct";
            this.optProduct.Size = new System.Drawing.Size(62, 17);
            this.optProduct.TabIndex = 3;
            this.optProduct.TabStop = true;
            this.optProduct.Tag = "product";
            this.optProduct.Text = "Product";
            this.optProduct.UseVisualStyleBackColor = true;
            this.optProduct.CheckedChanged += new System.EventHandler(this.LabelType_CheckedChanged);
            // 
            // optContent
            // 
            this.optContent.AutoSize = true;
            this.optContent.Location = new System.Drawing.Point(105, 24);
            this.optContent.Name = "optContent";
            this.optContent.Size = new System.Drawing.Size(62, 17);
            this.optContent.TabIndex = 2;
            this.optContent.TabStop = true;
            this.optContent.Tag = "content";
            this.optContent.Text = "Content";
            this.optContent.UseVisualStyleBackColor = true;
            this.optContent.CheckedChanged += new System.EventHandler(this.LabelType_CheckedChanged);
            // 
            // optTopic
            // 
            this.optTopic.AutoSize = true;
            this.optTopic.Location = new System.Drawing.Point(19, 47);
            this.optTopic.Name = "optTopic";
            this.optTopic.Size = new System.Drawing.Size(52, 17);
            this.optTopic.TabIndex = 1;
            this.optTopic.TabStop = true;
            this.optTopic.Tag = "topic";
            this.optTopic.Text = "Topic";
            this.optTopic.UseVisualStyleBackColor = true;
            this.optTopic.CheckedChanged += new System.EventHandler(this.LabelType_CheckedChanged);
            // 
            // optDomain
            // 
            this.optDomain.AutoSize = true;
            this.optDomain.Location = new System.Drawing.Point(19, 24);
            this.optDomain.Name = "optDomain";
            this.optDomain.Size = new System.Drawing.Size(61, 17);
            this.optDomain.TabIndex = 0;
            this.optDomain.TabStop = true;
            this.optDomain.Tag = "domain";
            this.optDomain.Text = "Domain";
            this.optDomain.UseVisualStyleBackColor = true;
            this.optDomain.CheckedChanged += new System.EventHandler(this.LabelType_CheckedChanged);
            // 
            // gridLabels
            // 
            this.gridLabels.AllowUserToAddRows = false;
            this.gridLabels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLabels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Label,
            this.Uses});
            this.gridLabels.Location = new System.Drawing.Point(4, 138);
            this.gridLabels.Name = "gridLabels";
            this.gridLabels.RowHeadersVisible = false;
            this.gridLabels.Size = new System.Drawing.Size(248, 278);
            this.gridLabels.TabIndex = 2;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Label
            // 
            this.Label.HeaderText = "Label";
            this.Label.Name = "Label";
            // 
            // Uses
            // 
            this.Uses.HeaderText = "Uses";
            this.Uses.Name = "Uses";
            this.Uses.ReadOnly = true;
            // 
            // cmdNewLabel
            // 
            this.cmdNewLabel.Location = new System.Drawing.Point(226, 20);
            this.cmdNewLabel.Name = "cmdNewLabel";
            this.cmdNewLabel.Size = new System.Drawing.Size(54, 28);
            this.cmdNewLabel.TabIndex = 3;
            this.cmdNewLabel.Text = "New";
            this.cmdNewLabel.UseVisualStyleBackColor = true;
            this.cmdNewLabel.Click += new System.EventHandler(this.cmdNewLabel_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(228, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // LabelManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 440);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmdNewLabel);
            this.Controls.Add(this.gridLabels);
            this.Controls.Add(this.groupLabelType);
            this.Controls.Add(this.cmdClose);
            this.Name = "LabelManager";
            this.Text = "LabelManager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LabelManager_FormClosed);
            this.groupLabelType.ResumeLayout(false);
            this.groupLabelType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLabels)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.GroupBox groupLabelType;
        private System.Windows.Forms.RadioButton optProduct;
        private System.Windows.Forms.RadioButton optContent;
        private System.Windows.Forms.RadioButton optTopic;
        private System.Windows.Forms.RadioButton optDomain;
        private System.Windows.Forms.DataGridView gridLabels;
        private System.Windows.Forms.Button cmdNewLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uses;
    }
}