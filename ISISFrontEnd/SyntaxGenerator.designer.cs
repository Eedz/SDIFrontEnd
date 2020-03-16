namespace ISISFrontEnd
{
    partial class Form1
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
            this.lstSurveys = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstSurveys
            // 
            this.lstSurveys.DisplayMember = "Survey";
            this.lstSurveys.FormattingEnabled = true;
            this.lstSurveys.Location = new System.Drawing.Point(94, 48);
            this.lstSurveys.Name = "lstSurveys";
            this.lstSurveys.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstSurveys.Size = new System.Drawing.Size(127, 212);
            this.lstSurveys.TabIndex = 0;
            this.lstSurveys.ValueMember = "Survey";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(341, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "cmdGenerate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Generate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstSurveys);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstSurveys;
        private System.Windows.Forms.Button button1;
    }
}

