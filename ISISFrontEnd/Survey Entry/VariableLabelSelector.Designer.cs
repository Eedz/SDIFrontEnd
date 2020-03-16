namespace ISISFrontEnd
{
    partial class VariableLabelSelector
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
            this.cmdOpenAssignLabels = new System.Windows.Forms.Button();
            this.cmdOpenVarDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(12, 9);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(46, 25);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // cmdOpenAssignLabels
            // 
            this.cmdOpenAssignLabels.Location = new System.Drawing.Point(12, 40);
            this.cmdOpenAssignLabels.Name = "cmdOpenAssignLabels";
            this.cmdOpenAssignLabels.Size = new System.Drawing.Size(57, 28);
            this.cmdOpenAssignLabels.TabIndex = 1;
            this.cmdOpenAssignLabels.Text = "Labels";
            this.cmdOpenAssignLabels.UseVisualStyleBackColor = true;
            this.cmdOpenAssignLabels.Click += new System.EventHandler(this.cmdOpenAssignLabels_Click);
            // 
            // cmdOpenVarDetails
            // 
            this.cmdOpenVarDetails.Location = new System.Drawing.Point(78, 40);
            this.cmdOpenVarDetails.Name = "cmdOpenVarDetails";
            this.cmdOpenVarDetails.Size = new System.Drawing.Size(74, 28);
            this.cmdOpenVarDetails.TabIndex = 2;
            this.cmdOpenVarDetails.Text = "More Info...";
            this.cmdOpenVarDetails.UseVisualStyleBackColor = true;
            this.cmdOpenVarDetails.Click += new System.EventHandler(this.cmdOpenVarDetails_Click);
            // 
            // VariableLabelSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(509, 610);
            this.Controls.Add(this.cmdOpenVarDetails);
            this.Controls.Add(this.cmdOpenAssignLabels);
            this.Controls.Add(this.cmdClose);
            this.Name = "VariableLabelSelector";
            this.Text = "VariableInformation";
            this.Load += new System.EventHandler(this.VariableLabelSelector_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdOpenAssignLabels;
        private System.Windows.Forms.Button cmdOpenVarDetails;
    }
}