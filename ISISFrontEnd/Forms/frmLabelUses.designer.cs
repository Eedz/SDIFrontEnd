namespace ISISFrontEnd
{
    partial class frmLabelUses
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chSurvey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chrefVarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chVarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chVarLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chDomain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chTopic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chSurvey,
            this.chrefVarName,
            this.chVarName,
            this.chVarLabel,
            this.chDomain,
            this.chTopic,
            this.chContent,
            this.chProduct});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1038, 462);
            this.dataGridView1.TabIndex = 0;
            // 
            // chSurvey
            // 
            this.chSurvey.HeaderText = "Survey";
            this.chSurvey.Name = "chSurvey";
            this.chSurvey.ReadOnly = true;
            this.chSurvey.Width = 65;
            // 
            // chrefVarName
            // 
            this.chrefVarName.HeaderText = "refVarName";
            this.chrefVarName.Name = "chrefVarName";
            this.chrefVarName.ReadOnly = true;
            this.chrefVarName.Width = 88;
            // 
            // chVarName
            // 
            this.chVarName.HeaderText = "VarName";
            this.chVarName.Name = "chVarName";
            this.chVarName.ReadOnly = true;
            this.chVarName.Width = 76;
            // 
            // chVarLabel
            // 
            this.chVarLabel.HeaderText = "VarLabel";
            this.chVarLabel.Name = "chVarLabel";
            this.chVarLabel.ReadOnly = true;
            this.chVarLabel.Width = 74;
            // 
            // chDomain
            // 
            this.chDomain.HeaderText = "Domain";
            this.chDomain.Name = "chDomain";
            this.chDomain.ReadOnly = true;
            this.chDomain.Width = 68;
            // 
            // chTopic
            // 
            this.chTopic.HeaderText = "Topic";
            this.chTopic.Name = "chTopic";
            this.chTopic.ReadOnly = true;
            this.chTopic.Width = 59;
            // 
            // chContent
            // 
            this.chContent.HeaderText = "Content";
            this.chContent.Name = "chContent";
            this.chContent.ReadOnly = true;
            this.chContent.Width = 69;
            // 
            // chProduct
            // 
            this.chProduct.HeaderText = "Product";
            this.chProduct.Name = "chProduct";
            this.chProduct.ReadOnly = true;
            this.chProduct.Width = 69;
            // 
            // frmLabelUses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 462);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmLabelUses";
            this.Text = "Label Uses";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn chSurvey;
        private System.Windows.Forms.DataGridViewTextBoxColumn chrefVarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chVarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chVarLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDomain;
        private System.Windows.Forms.DataGridViewTextBoxColumn chTopic;
        private System.Windows.Forms.DataGridViewTextBoxColumn chContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn chProduct;
    }
}