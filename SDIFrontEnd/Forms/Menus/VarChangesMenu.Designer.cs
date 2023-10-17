namespace SDIFrontEnd
{
    partial class VarNameMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdOpenRenameSingle = new System.Windows.Forms.Button();
            this.cmdOpenRenameBulk = new System.Windows.Forms.Button();
            this.cmdOpenVarChangeTracking = new System.Windows.Forms.Button();
            this.cmdOpenVarNameChangeReport = new System.Windows.Forms.Button();
            this.cmdOpenVarUsageReport = new System.Windows.Forms.Button();
            this.cmdOpenVarUsage = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "VarName Changes Menu";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(933, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // cmdOpenRenameSingle
            // 
            this.cmdOpenRenameSingle.Location = new System.Drawing.Point(404, 88);
            this.cmdOpenRenameSingle.Name = "cmdOpenRenameSingle";
            this.cmdOpenRenameSingle.Size = new System.Drawing.Size(185, 30);
            this.cmdOpenRenameSingle.TabIndex = 2;
            this.cmdOpenRenameSingle.Text = "Rename Variable";
            this.cmdOpenRenameSingle.UseVisualStyleBackColor = true;
            this.cmdOpenRenameSingle.Visible = false;
            this.cmdOpenRenameSingle.Click += new System.EventHandler(this.cmdOpenRenameSingle_Click);
            // 
            // cmdOpenRenameBulk
            // 
            this.cmdOpenRenameBulk.Location = new System.Drawing.Point(74, 87);
            this.cmdOpenRenameBulk.Name = "cmdOpenRenameBulk";
            this.cmdOpenRenameBulk.Size = new System.Drawing.Size(185, 30);
            this.cmdOpenRenameBulk.TabIndex = 3;
            this.cmdOpenRenameBulk.Text = "Rename Variables";
            this.cmdOpenRenameBulk.UseVisualStyleBackColor = true;
            this.cmdOpenRenameBulk.Click += new System.EventHandler(this.cmdOpenRenameBulk_Click);
            // 
            // cmdOpenVarChangeTracking
            // 
            this.cmdOpenVarChangeTracking.Location = new System.Drawing.Point(74, 123);
            this.cmdOpenVarChangeTracking.Name = "cmdOpenVarChangeTracking";
            this.cmdOpenVarChangeTracking.Size = new System.Drawing.Size(185, 30);
            this.cmdOpenVarChangeTracking.TabIndex = 4;
            this.cmdOpenVarChangeTracking.Text = "VarName Change Tracking";
            this.cmdOpenVarChangeTracking.UseVisualStyleBackColor = true;
            this.cmdOpenVarChangeTracking.Click += new System.EventHandler(this.cmdOpenVarChangeTracking_Click);
            // 
            // cmdOpenVarNameChangeReport
            // 
            this.cmdOpenVarNameChangeReport.Location = new System.Drawing.Point(74, 159);
            this.cmdOpenVarNameChangeReport.Name = "cmdOpenVarNameChangeReport";
            this.cmdOpenVarNameChangeReport.Size = new System.Drawing.Size(185, 30);
            this.cmdOpenVarNameChangeReport.TabIndex = 5;
            this.cmdOpenVarNameChangeReport.Text = "VarName Change Report";
            this.cmdOpenVarNameChangeReport.UseVisualStyleBackColor = true;
            this.cmdOpenVarNameChangeReport.Click += new System.EventHandler(this.cmdOpenVarNameChangeReport_Click);
            // 
            // cmdOpenVarUsageReport
            // 
            this.cmdOpenVarUsageReport.Location = new System.Drawing.Point(74, 231);
            this.cmdOpenVarUsageReport.Name = "cmdOpenVarUsageReport";
            this.cmdOpenVarUsageReport.Size = new System.Drawing.Size(185, 30);
            this.cmdOpenVarUsageReport.TabIndex = 6;
            this.cmdOpenVarUsageReport.Text = "Used/Unused Report";
            this.cmdOpenVarUsageReport.UseVisualStyleBackColor = true;
            this.cmdOpenVarUsageReport.Click += new System.EventHandler(this.cmdOpenVarUsageReport_Click);
            // 
            // cmdOpenVarUsage
            // 
            this.cmdOpenVarUsage.Location = new System.Drawing.Point(74, 195);
            this.cmdOpenVarUsage.Name = "cmdOpenVarUsage";
            this.cmdOpenVarUsage.Size = new System.Drawing.Size(185, 30);
            this.cmdOpenVarUsage.TabIndex = 7;
            this.cmdOpenVarUsage.Text = "Used/Unused VarNames";
            this.cmdOpenVarUsage.UseVisualStyleBackColor = true;
            this.cmdOpenVarUsage.Click += new System.EventHandler(this.cmdOpenVarUsage_Click);
            // 
            // VarNameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(216)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.cmdOpenVarUsage);
            this.Controls.Add(this.cmdOpenVarUsageReport);
            this.Controls.Add(this.cmdOpenVarNameChangeReport);
            this.Controls.Add(this.cmdOpenVarChangeTracking);
            this.Controls.Add(this.cmdOpenRenameBulk);
            this.Controls.Add(this.cmdOpenRenameSingle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VarNameMenu";
            this.Text = "VarName Changes Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VarNameMenu_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button cmdOpenRenameSingle;
        private System.Windows.Forms.Button cmdOpenRenameBulk;
        private System.Windows.Forms.Button cmdOpenVarChangeTracking;
        private System.Windows.Forms.Button cmdOpenVarNameChangeReport;
        private System.Windows.Forms.Button cmdOpenVarUsageReport;
        private System.Windows.Forms.Button cmdOpenVarUsage;
    }
}