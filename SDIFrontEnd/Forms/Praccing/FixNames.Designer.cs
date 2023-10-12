namespace SDIFrontEnd
{
    partial class FixNames
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
            this.cmdDone = new System.Windows.Forms.Button();
            this.dgvNames = new System.Windows.Forms.DataGridView();
            this.chInvalid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chValid = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cmdCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNames)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter a valid name in the New Name column.";
            // 
            // cmdDone
            // 
            this.cmdDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDone.Location = new System.Drawing.Point(191, 277);
            this.cmdDone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdDone.Name = "cmdDone";
            this.cmdDone.Size = new System.Drawing.Size(88, 28);
            this.cmdDone.TabIndex = 4;
            this.cmdDone.Text = "Done";
            this.cmdDone.UseVisualStyleBackColor = true;
            this.cmdDone.Click += new System.EventHandler(this.cmdDone_Click);
            // 
            // dgvNames
            // 
            this.dgvNames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chInvalid,
            this.chValid});
            this.dgvNames.Location = new System.Drawing.Point(1, 30);
            this.dgvNames.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvNames.Name = "dgvNames";
            this.dgvNames.RowHeadersVisible = false;
            this.dgvNames.Size = new System.Drawing.Size(278, 240);
            this.dgvNames.TabIndex = 3;
            // 
            // chInvalid
            // 
            this.chInvalid.HeaderText = "Invalid";
            this.chInvalid.Name = "chInvalid";
            // 
            // chValid
            // 
            this.chValid.HeaderText = "Valid";
            this.chValid.Name = "chValid";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCancel.Location = new System.Drawing.Point(1, 277);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(88, 28);
            this.cmdCancel.TabIndex = 6;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // FixNames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 310);
            this.ControlBox = false;
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdDone);
            this.Controls.Add(this.dgvNames);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FixNames";
            this.Text = "Fix Names";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdDone;
        private System.Windows.Forms.DataGridView dgvNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn chInvalid;
        private System.Windows.Forms.DataGridViewComboBoxColumn chValid;
        private System.Windows.Forms.Button cmdCancel;
    }
}