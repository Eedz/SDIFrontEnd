namespace ISISFrontEnd
{
    partial class SurveyDevMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SurveyDevMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripClose = new System.Windows.Forms.ToolStripButton();
            this.cmdOpenDraftManager = new System.Windows.Forms.Button();
            this.cmdOpenDraftSearch = new System.Windows.Forms.Button();
            this.cmdOpenDraftReport = new System.Windows.Forms.Button();
            this.cmdOpenDraftImport = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Survey Development Menu";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(933, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripClose
            // 
            this.toolStripClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripClose.Image")));
            this.toolStripClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripClose.Name = "toolStripClose";
            this.toolStripClose.Size = new System.Drawing.Size(40, 22);
            this.toolStripClose.Text = "Close";
            this.toolStripClose.Click += new System.EventHandler(this.toolStripClose_Click);
            // 
            // cmdOpenDraftManager
            // 
            this.cmdOpenDraftManager.Location = new System.Drawing.Point(18, 84);
            this.cmdOpenDraftManager.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOpenDraftManager.Name = "cmdOpenDraftManager";
            this.cmdOpenDraftManager.Size = new System.Drawing.Size(140, 28);
            this.cmdOpenDraftManager.TabIndex = 2;
            this.cmdOpenDraftManager.Text = "Manage Drafts";
            this.cmdOpenDraftManager.UseVisualStyleBackColor = true;
            this.cmdOpenDraftManager.Click += new System.EventHandler(this.cmdOpenDraftManager_Click);
            // 
            // cmdOpenDraftSearch
            // 
            this.cmdOpenDraftSearch.Location = new System.Drawing.Point(18, 120);
            this.cmdOpenDraftSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOpenDraftSearch.Name = "cmdOpenDraftSearch";
            this.cmdOpenDraftSearch.Size = new System.Drawing.Size(140, 28);
            this.cmdOpenDraftSearch.TabIndex = 3;
            this.cmdOpenDraftSearch.Text = "Search Drafts";
            this.cmdOpenDraftSearch.UseVisualStyleBackColor = true;
            this.cmdOpenDraftSearch.Click += new System.EventHandler(this.cmdOpenDraftSearch_Click);
            // 
            // cmdOpenDraftReport
            // 
            this.cmdOpenDraftReport.Location = new System.Drawing.Point(18, 156);
            this.cmdOpenDraftReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOpenDraftReport.Name = "cmdOpenDraftReport";
            this.cmdOpenDraftReport.Size = new System.Drawing.Size(140, 28);
            this.cmdOpenDraftReport.TabIndex = 4;
            this.cmdOpenDraftReport.Text = "Draft Report";
            this.cmdOpenDraftReport.UseVisualStyleBackColor = true;
            this.cmdOpenDraftReport.Click += new System.EventHandler(this.cmdOpenDraftReport_Click);
            // 
            // cmdOpenDraftImport
            // 
            this.cmdOpenDraftImport.Location = new System.Drawing.Point(18, 192);
            this.cmdOpenDraftImport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOpenDraftImport.Name = "cmdOpenDraftImport";
            this.cmdOpenDraftImport.Size = new System.Drawing.Size(140, 28);
            this.cmdOpenDraftImport.TabIndex = 5;
            this.cmdOpenDraftImport.Text = "Import Draft";
            this.cmdOpenDraftImport.UseVisualStyleBackColor = true;
            this.cmdOpenDraftImport.Click += new System.EventHandler(this.cmdOpenDraftImport_Click);
            // 
            // SurveyDevMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(189)))));
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.ControlBox = false;
            this.Controls.Add(this.cmdOpenDraftImport);
            this.Controls.Add(this.cmdOpenDraftReport);
            this.Controls.Add(this.cmdOpenDraftSearch);
            this.Controls.Add(this.cmdOpenDraftManager);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SurveyDevMenu";
            this.Text = "Survey Dev Menu";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripClose;
        private System.Windows.Forms.Button cmdOpenDraftManager;
        private System.Windows.Forms.Button cmdOpenDraftSearch;
        private System.Windows.Forms.Button cmdOpenDraftReport;
        private System.Windows.Forms.Button cmdOpenDraftImport;
    }
}