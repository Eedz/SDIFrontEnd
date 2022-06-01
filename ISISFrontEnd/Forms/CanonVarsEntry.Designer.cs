namespace ISISFrontEnd
{
    partial class CanonVarsEntry
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repeaterRecords = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAnySuffixDesc = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.chkAnySuffix = new System.Windows.Forms.CheckBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRefVarName = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.repeaterRecords.ItemTemplate.SuspendLayout();
            this.repeaterRecords.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(699, 24);
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
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(22, 20);
            this.toolStripMenuItem1.Text = " ";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // repeaterRecords
            // 
            this.repeaterRecords.AllowUserToDeleteItems = false;
            this.repeaterRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // repeaterRecords.ItemTemplate
            // 
            this.repeaterRecords.ItemTemplate.Controls.Add(this.label3);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.lblAnySuffixDesc);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.txtNotes);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.chkAnySuffix);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.chkActive);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.label1);
            this.repeaterRecords.ItemTemplate.Controls.Add(this.txtRefVarName);
            this.repeaterRecords.ItemTemplate.Size = new System.Drawing.Size(691, 146);
            this.repeaterRecords.ItemTemplate.Enter += new System.EventHandler(this.repeaterRecords_ItemTemplate_Enter);
            this.repeaterRecords.ItemTemplate.Leave += new System.EventHandler(this.repeaterRecords_ItemTemplate_Leave);
            this.repeaterRecords.ItemTemplate.Validated += new System.EventHandler(this.repeaterRecords_ItemTemplate_Validated);
            this.repeaterRecords.Location = new System.Drawing.Point(0, 24);
            this.repeaterRecords.Name = "repeaterRecords";
            this.repeaterRecords.Size = new System.Drawing.Size(699, 601);
            this.repeaterRecords.TabIndex = 3;
            this.repeaterRecords.Text = "dataRepeater1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Notes";
            // 
            // lblAnySuffixDesc
            // 
            this.lblAnySuffixDesc.AutoSize = true;
            this.lblAnySuffixDesc.Location = new System.Drawing.Point(105, 30);
            this.lblAnySuffixDesc.Name = "lblAnySuffixDesc";
            this.lblAnySuffixDesc.Size = new System.Drawing.Size(539, 16);
            this.lblAnySuffixDesc.TabIndex = 19;
            this.lblAnySuffixDesc.Text = "This ensures that any suffixed version of this refVarName will appear in the cano" +
    "nical report.";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(89, 55);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(555, 70);
            this.txtNotes.TabIndex = 18;
            this.txtNotes.Validated += new System.EventHandler(this.Control_Validated);
            // 
            // chkAnySuffix
            // 
            this.chkAnySuffix.AutoSize = true;
            this.chkAnySuffix.Location = new System.Drawing.Point(5, 29);
            this.chkAnySuffix.Name = "chkAnySuffix";
            this.chkAnySuffix.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkAnySuffix.Size = new System.Drawing.Size(98, 20);
            this.chkAnySuffix.TabIndex = 17;
            this.chkAnySuffix.Text = "  ?Any Suffix";
            this.chkAnySuffix.UseVisualStyleBackColor = true;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(195, 3);
            this.chkActive.Name = "chkActive";
            this.chkActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkActive.Size = new System.Drawing.Size(61, 20);
            this.chkActive.TabIndex = 16;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "refVarName";
            // 
            // txtRefVarName
            // 
            this.txtRefVarName.Location = new System.Drawing.Point(89, 1);
            this.txtRefVarName.Name = "txtRefVarName";
            this.txtRefVarName.Size = new System.Drawing.Size(100, 23);
            this.txtRefVarName.TabIndex = 14;
            // 
            // CanonVarsEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 625);
            this.Controls.Add(this.repeaterRecords);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CanonVarsEntry";
            this.Text = "Canonical VarNames";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.repeaterRecords.ItemTemplate.ResumeLayout(false);
            this.repeaterRecords.ItemTemplate.PerformLayout();
            this.repeaterRecords.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater repeaterRecords;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAnySuffixDesc;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.CheckBox chkAnySuffix;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRefVarName;
    }
}