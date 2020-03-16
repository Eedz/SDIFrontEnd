namespace ISISFrontEnd
{
    partial class AssignLabels
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
            this.dgvVars = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVars)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVars
            // 
            this.dgvVars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVars.Location = new System.Drawing.Point(86, 139);
            this.dgvVars.Name = "dgvVars";
            this.dgvVars.Size = new System.Drawing.Size(971, 356);
            this.dgvVars.TabIndex = 0;
            this.dgvVars.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvVars_DataBindingComplete);
            // 
            // AssignLabels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 609);
            this.Controls.Add(this.dgvVars);
            this.Name = "AssignLabels";
            this.Text = "AssignLabels";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVars)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVars;
    }
}