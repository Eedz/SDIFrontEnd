namespace SDIFrontEnd
{
    partial class SavedSources
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
            this.dataRepeater1 = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.cmdUse = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.dataRepeater1.ItemTemplate.SuspendLayout();
            this.dataRepeater1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataRepeater1
            // 
            this.dataRepeater1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // dataRepeater1.ItemTemplate
            // 
            this.dataRepeater1.ItemTemplate.Controls.Add(this.cmdUse);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.txtSource);
            this.dataRepeater1.ItemTemplate.Size = new System.Drawing.Size(315, 51);
            this.dataRepeater1.Location = new System.Drawing.Point(0, 0);
            this.dataRepeater1.Name = "dataRepeater1";
            this.dataRepeater1.Size = new System.Drawing.Size(323, 288);
            this.dataRepeater1.TabIndex = 0;
            this.dataRepeater1.Text = "dataRepeater1";
            // 
            // cmdUse
            // 
            this.cmdUse.Location = new System.Drawing.Point(224, 3);
            this.cmdUse.Name = "cmdUse";
            this.cmdUse.Size = new System.Drawing.Size(69, 43);
            this.cmdUse.TabIndex = 1;
            this.cmdUse.Text = "Use";
            this.cmdUse.UseVisualStyleBackColor = true;
            this.cmdUse.Click += new System.EventHandler(this.cmdUse_Click);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(3, 3);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(215, 43);
            this.txtSource.TabIndex = 0;
            this.txtSource.Validated += new System.EventHandler(this.txtSource_Validated);
            // 
            // SavedSources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 288);
            this.Controls.Add(this.dataRepeater1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SavedSources";
            this.Text = "Saved Sources";
            this.dataRepeater1.ItemTemplate.ResumeLayout(false);
            this.dataRepeater1.ItemTemplate.PerformLayout();
            this.dataRepeater1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater1;
        private System.Windows.Forms.Button cmdUse;
        private System.Windows.Forms.TextBox txtSource;
    }
}