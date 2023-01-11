namespace SDIFrontEnd
{
    partial class HarmonyResults
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtRefVarName = new System.Windows.Forms.TextBox();
            this.txtSurveys = new System.Windows.Forms.TextBox();
            this.rtbQuestion = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataRepeater1.ItemTemplate.SuspendLayout();
            this.dataRepeater1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataRepeater1
            // 
            this.dataRepeater1.AllowUserToAddItems = false;
            this.dataRepeater1.AllowUserToDeleteItems = false;
            this.dataRepeater1.ItemHeaderVisible = false;
            // 
            // dataRepeater1.ItemTemplate
            // 
            this.dataRepeater1.ItemTemplate.AutoSize = true;
            this.dataRepeater1.ItemTemplate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dataRepeater1.ItemTemplate.Controls.Add(this.tableLayoutPanel1);
            this.dataRepeater1.ItemTemplate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataRepeater1.ItemTemplate.Size = new System.Drawing.Size(1172, 293);
            this.dataRepeater1.Location = new System.Drawing.Point(0, 63);
            this.dataRepeater1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataRepeater1.Name = "dataRepeater1";
            this.dataRepeater1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataRepeater1.Size = new System.Drawing.Size(1180, 718);
            this.dataRepeater1.TabIndex = 0;
            this.dataRepeater1.Text = "dataRepeater1";
            this.dataRepeater1.DrawItem += new Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventHandler(this.dataRepeater1_DrawItem);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.96651F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.03349F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 233F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 311F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel1.Controls.Add(this.txtRefVarName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSurveys, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.rtbQuestion, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1164, 287);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // txtRefVarName
            // 
            this.txtRefVarName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRefVarName.Location = new System.Drawing.Point(3, 4);
            this.txtRefVarName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRefVarName.Name = "txtRefVarName";
            this.txtRefVarName.Size = new System.Drawing.Size(98, 23);
            this.txtRefVarName.TabIndex = 1;
            // 
            // txtSurveys
            // 
            this.txtSurveys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSurveys.Location = new System.Drawing.Point(455, 4);
            this.txtSurveys.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSurveys.Multiline = true;
            this.txtSurveys.Name = "txtSurveys";
            this.txtSurveys.Size = new System.Drawing.Size(227, 279);
            this.txtSurveys.TabIndex = 2;
            this.txtSurveys.TextChanged += new System.EventHandler(this.txtSurveys_TextChanged);
            // 
            // rtbQuestion
            // 
            this.rtbQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbQuestion.Location = new System.Drawing.Point(107, 4);
            this.rtbQuestion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbQuestion.Name = "rtbQuestion";
            this.rtbQuestion.Size = new System.Drawing.Size(342, 279);
            this.rtbQuestion.TabIndex = 0;
            this.rtbQuestion.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Question";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(560, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Surveys";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "refVarName";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1192, 24);
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
            // HarmonyResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 753);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataRepeater1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HarmonyResults";
            this.Text = "Harmony Report";
            this.dataRepeater1.ItemTemplate.ResumeLayout(false);
            this.dataRepeater1.ResumeLayout(false);
            this.dataRepeater1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater1;
        private System.Windows.Forms.RichTextBox rtbQuestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSurveys;
        private System.Windows.Forms.TextBox txtRefVarName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}