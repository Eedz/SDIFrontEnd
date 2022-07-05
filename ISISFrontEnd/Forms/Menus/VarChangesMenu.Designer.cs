namespace ISISFrontEnd
{
    partial class VarChangesMenu
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
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 42);
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
            this.cmdOpenRenameSingle.Location = new System.Drawing.Point(35, 95);
            this.cmdOpenRenameSingle.Name = "cmdOpenRenameSingle";
            this.cmdOpenRenameSingle.Size = new System.Drawing.Size(184, 31);
            this.cmdOpenRenameSingle.TabIndex = 2;
            this.cmdOpenRenameSingle.Text = "Rename Variable";
            this.cmdOpenRenameSingle.UseVisualStyleBackColor = true;
            this.cmdOpenRenameSingle.Click += new System.EventHandler(this.cmdOpenRenameSingle_Click);
            // 
            // cmdOpenRenameBulk
            // 
            this.cmdOpenRenameBulk.Location = new System.Drawing.Point(35, 132);
            this.cmdOpenRenameBulk.Name = "cmdOpenRenameBulk";
            this.cmdOpenRenameBulk.Size = new System.Drawing.Size(184, 42);
            this.cmdOpenRenameBulk.TabIndex = 3;
            this.cmdOpenRenameBulk.Text = "Bulk Variable Rename";
            this.cmdOpenRenameBulk.UseVisualStyleBackColor = true;
            // 
            // cmdOpenVarChangeTracking
            // 
            this.cmdOpenVarChangeTracking.Location = new System.Drawing.Point(35, 223);
            this.cmdOpenVarChangeTracking.Name = "cmdOpenVarChangeTracking";
            this.cmdOpenVarChangeTracking.Size = new System.Drawing.Size(184, 43);
            this.cmdOpenVarChangeTracking.TabIndex = 4;
            this.cmdOpenVarChangeTracking.Text = "VarName Change Tracking";
            this.cmdOpenVarChangeTracking.UseVisualStyleBackColor = true;
            this.cmdOpenVarChangeTracking.Click += new System.EventHandler(this.cmdOpenVarChangeTracking_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(35, 272);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(184, 33);
            this.button4.TabIndex = 5;
            this.button4.Text = "VarName Change Report";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(225, 311);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(173, 40);
            this.button5.TabIndex = 6;
            this.button5.Text = "Used/Unused Report";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(35, 311);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(184, 46);
            this.button6.TabIndex = 7;
            this.button6.Text = "Used/Unused VarNames";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(35, 363);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(184, 51);
            this.button8.TabIndex = 9;
            this.button8.Text = "View Temp VarNames";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // VarChangesMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.cmdOpenVarChangeTracking);
            this.Controls.Add(this.cmdOpenRenameBulk);
            this.Controls.Add(this.cmdOpenRenameSingle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VarChangesMenu";
            this.Text = "VarName Changes Menu";
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
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
    }
}