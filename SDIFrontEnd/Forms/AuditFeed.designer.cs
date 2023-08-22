namespace SDIFrontEnd
{
    partial class AuditFeed
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
            this.dgvFeed = new System.Windows.Forms.DataGridView();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.lblLastUpdate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeed)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFeed
            // 
            this.dgvFeed.AllowUserToAddRows = false;
            this.dgvFeed.AllowUserToDeleteRows = false;
            this.dgvFeed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeed.Location = new System.Drawing.Point(12, 12);
            this.dgvFeed.Name = "dgvFeed";
            this.dgvFeed.ReadOnly = true;
            this.dgvFeed.Size = new System.Drawing.Size(1264, 449);
            this.dgvFeed.TabIndex = 0;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 30000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.Location = new System.Drawing.Point(12, 478);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(74, 13);
            this.lblLastUpdate.TabIndex = 2;
            this.lblLastUpdate.Text = "Last Updated:";
            // 
            // AuditFeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 500);
            this.Controls.Add(this.lblLastUpdate);
            this.Controls.Add(this.dgvFeed);
            this.Name = "AuditFeed";
            this.Text = "AuditFeed";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFeed;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Label lblLastUpdate;
    }
}