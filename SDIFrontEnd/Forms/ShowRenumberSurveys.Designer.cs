namespace SDIFrontEnd
{
    partial class ShowRenumberSurveys
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
            this.txtSurvey = new System.Windows.Forms.TextBox();
            this.cmdOpenEditor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.dataRepeater1.ItemTemplate.SuspendLayout();
            this.dataRepeater1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataRepeater1
            // 
            // 
            // dataRepeater1.ItemTemplate
            // 
            this.dataRepeater1.ItemTemplate.Controls.Add(this.txtSurvey);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.cmdOpenEditor);
            this.dataRepeater1.ItemTemplate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataRepeater1.ItemTemplate.Size = new System.Drawing.Size(284, 37);
            this.dataRepeater1.Location = new System.Drawing.Point(14, 60);
            this.dataRepeater1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataRepeater1.Name = "dataRepeater1";
            this.dataRepeater1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataRepeater1.Size = new System.Drawing.Size(292, 226);
            this.dataRepeater1.TabIndex = 0;
            this.dataRepeater1.Text = "dataRepeater1";
            // 
            // txtSurvey
            // 
            this.txtSurvey.Location = new System.Drawing.Point(3, 4);
            this.txtSurvey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSurvey.Name = "txtSurvey";
            this.txtSurvey.Size = new System.Drawing.Size(140, 23);
            this.txtSurvey.TabIndex = 2;
            // 
            // cmdOpenEditor
            // 
            this.cmdOpenEditor.Location = new System.Drawing.Point(152, 4);
            this.cmdOpenEditor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOpenEditor.Name = "cmdOpenEditor";
            this.cmdOpenEditor.Size = new System.Drawing.Size(87, 28);
            this.cmdOpenEditor.TabIndex = 1;
            this.cmdOpenEditor.Text = "Open Editor";
            this.cmdOpenEditor.UseVisualStyleBackColor = true;
            this.cmdOpenEditor.Click += new System.EventHandler(this.cmdOpenEditor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "To Be Renumbered";
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Location = new System.Drawing.Point(3, 299);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(303, 2);
            this.label14.TabIndex = 14;
            this.label14.Text = "label14";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(208, 311);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(87, 28);
            this.cmdClose.TabIndex = 13;
            this.cmdClose.Text = "OK";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // ShowRenumberSurveys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(241)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(321, 351);
            this.ControlBox = false;
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataRepeater1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShowRenumberSurveys";
            this.Text = "Renumber Surveys";
            this.dataRepeater1.ItemTemplate.ResumeLayout(false);
            this.dataRepeater1.ItemTemplate.PerformLayout();
            this.dataRepeater1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater1;
        private System.Windows.Forms.Button cmdOpenEditor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.TextBox txtSurvey;
    }
}