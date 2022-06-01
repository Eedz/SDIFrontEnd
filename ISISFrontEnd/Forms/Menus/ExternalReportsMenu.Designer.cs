namespace ISISFrontEnd
{
    partial class ExternalReportsMenu
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
            this.cmdOpenVariableList = new System.Windows.Forms.Button();
            this.cmdOpenSectionsTable = new System.Windows.Forms.Button();
            this.cmdOpenSurveyOverview = new System.Windows.Forms.Button();
            this.cmdOpenSyntaxForm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOpenVariableList
            // 
            this.cmdOpenVariableList.Enabled = false;
            this.cmdOpenVariableList.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenVariableList.Location = new System.Drawing.Point(54, 91);
            this.cmdOpenVariableList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOpenVariableList.Name = "cmdOpenVariableList";
            this.cmdOpenVariableList.Size = new System.Drawing.Size(169, 28);
            this.cmdOpenVariableList.TabIndex = 0;
            this.cmdOpenVariableList.Text = "Variable List";
            this.cmdOpenVariableList.UseVisualStyleBackColor = true;
            this.cmdOpenVariableList.Click += new System.EventHandler(this.cmdOpenVariableList_Click);
            // 
            // cmdOpenSectionsTable
            // 
            this.cmdOpenSectionsTable.Enabled = false;
            this.cmdOpenSectionsTable.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenSectionsTable.Location = new System.Drawing.Point(54, 127);
            this.cmdOpenSectionsTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOpenSectionsTable.Name = "cmdOpenSectionsTable";
            this.cmdOpenSectionsTable.Size = new System.Drawing.Size(169, 28);
            this.cmdOpenSectionsTable.TabIndex = 1;
            this.cmdOpenSectionsTable.Text = "Sections Table";
            this.cmdOpenSectionsTable.UseVisualStyleBackColor = true;
            this.cmdOpenSectionsTable.Click += new System.EventHandler(this.cmdOpenSectionsTable_Click);
            // 
            // cmdOpenSurveyOverview
            // 
            this.cmdOpenSurveyOverview.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenSurveyOverview.Location = new System.Drawing.Point(54, 163);
            this.cmdOpenSurveyOverview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOpenSurveyOverview.Name = "cmdOpenSurveyOverview";
            this.cmdOpenSurveyOverview.Size = new System.Drawing.Size(169, 28);
            this.cmdOpenSurveyOverview.TabIndex = 2;
            this.cmdOpenSurveyOverview.Text = "Survey Overview";
            this.cmdOpenSurveyOverview.UseVisualStyleBackColor = true;
            this.cmdOpenSurveyOverview.Click += new System.EventHandler(this.cmdOpenSurveyOverview_Click);
            // 
            // cmdOpenSyntaxForm
            // 
            this.cmdOpenSyntaxForm.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenSyntaxForm.Location = new System.Drawing.Point(54, 199);
            this.cmdOpenSyntaxForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOpenSyntaxForm.Name = "cmdOpenSyntaxForm";
            this.cmdOpenSyntaxForm.Size = new System.Drawing.Size(169, 28);
            this.cmdOpenSyntaxForm.TabIndex = 3;
            this.cmdOpenSyntaxForm.Text = "Syntax Generator";
            this.cmdOpenSyntaxForm.UseVisualStyleBackColor = true;
            this.cmdOpenSyntaxForm.Click += new System.EventHandler(this.cmdOpenSyntaxForm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 33);
            this.label1.TabIndex = 4;
            this.label1.Text = "External Reports";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(933, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // ExternalReportsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(205)))), ((int)(((byte)(170)))));
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdOpenSyntaxForm);
            this.Controls.Add(this.cmdOpenSurveyOverview);
            this.Controls.Add(this.cmdOpenSectionsTable);
            this.Controls.Add(this.cmdOpenVariableList);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ExternalReportsMenu";
            this.Text = "External Reports Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExternalReportsMenu_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOpenVariableList;
        private System.Windows.Forms.Button cmdOpenSectionsTable;
        private System.Windows.Forms.Button cmdOpenSurveyOverview;
        private System.Windows.Forms.Button cmdOpenSyntaxForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}