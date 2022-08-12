namespace ISISFrontEnd
{
    partial class UnlockSurvey
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
            this.lstAllSurveys = new System.Windows.Forms.ListBox();
            this.lstSelected = new System.Windows.Forms.ListBox();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.grpTimeInterval = new System.Windows.Forms.GroupBox();
            this.rb8Hours = new System.Windows.Forms.RadioButton();
            this.rb4Hours = new System.Windows.Forms.RadioButton();
            this.rb1Hour = new System.Windows.Forms.RadioButton();
            this.dgvLockedSurveys = new System.Windows.Forms.DataGridView();
            this.cmdUnlock = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbWave = new System.Windows.Forms.RadioButton();
            this.rbSurvey = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.chSurvey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.grpTimeInterval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLockedSurveys)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(805, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // lstAllSurveys
            // 
            this.lstAllSurveys.FormattingEnabled = true;
            this.lstAllSurveys.ItemHeight = 16;
            this.lstAllSurveys.Location = new System.Drawing.Point(14, 70);
            this.lstAllSurveys.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstAllSurveys.Name = "lstAllSurveys";
            this.lstAllSurveys.Size = new System.Drawing.Size(130, 244);
            this.lstAllSurveys.TabIndex = 2;
            // 
            // lstSelected
            // 
            this.lstSelected.FormattingEnabled = true;
            this.lstSelected.ItemHeight = 16;
            this.lstSelected.Location = new System.Drawing.Point(189, 70);
            this.lstSelected.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstSelected.Name = "lstSelected";
            this.lstSelected.Size = new System.Drawing.Size(130, 244);
            this.lstSelected.TabIndex = 3;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(151, 70);
            this.cmdAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(32, 32);
            this.cmdAdd.TabIndex = 4;
            this.cmdAdd.Text = "->";
            this.cmdAdd.UseCompatibleTextRendering = true;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Location = new System.Drawing.Point(151, 106);
            this.cmdRemove.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(32, 32);
            this.cmdRemove.TabIndex = 5;
            this.cmdRemove.Text = "<-";
            this.cmdRemove.UseCompatibleTextRendering = true;
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // grpTimeInterval
            // 
            this.grpTimeInterval.Controls.Add(this.rb8Hours);
            this.grpTimeInterval.Controls.Add(this.rb4Hours);
            this.grpTimeInterval.Controls.Add(this.rb1Hour);
            this.grpTimeInterval.Location = new System.Drawing.Point(353, 95);
            this.grpTimeInterval.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTimeInterval.Name = "grpTimeInterval";
            this.grpTimeInterval.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTimeInterval.Size = new System.Drawing.Size(93, 89);
            this.grpTimeInterval.TabIndex = 6;
            this.grpTimeInterval.TabStop = false;
            this.grpTimeInterval.Text = "Unlock for...";
            // 
            // rb8Hours
            // 
            this.rb8Hours.AutoSize = true;
            this.rb8Hours.Location = new System.Drawing.Point(6, 62);
            this.rb8Hours.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rb8Hours.Name = "rb8Hours";
            this.rb8Hours.Size = new System.Drawing.Size(69, 20);
            this.rb8Hours.TabIndex = 2;
            this.rb8Hours.TabStop = true;
            this.rb8Hours.Text = "8 hours";
            this.rb8Hours.UseVisualStyleBackColor = true;
            // 
            // rb4Hours
            // 
            this.rb4Hours.AutoSize = true;
            this.rb4Hours.Location = new System.Drawing.Point(6, 43);
            this.rb4Hours.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rb4Hours.Name = "rb4Hours";
            this.rb4Hours.Size = new System.Drawing.Size(69, 20);
            this.rb4Hours.TabIndex = 1;
            this.rb4Hours.TabStop = true;
            this.rb4Hours.Text = "4 hours";
            this.rb4Hours.UseVisualStyleBackColor = true;
            // 
            // rb1Hour
            // 
            this.rb1Hour.AutoSize = true;
            this.rb1Hour.Location = new System.Drawing.Point(6, 24);
            this.rb1Hour.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rb1Hour.Name = "rb1Hour";
            this.rb1Hour.Size = new System.Drawing.Size(63, 20);
            this.rb1Hour.TabIndex = 0;
            this.rb1Hour.TabStop = true;
            this.rb1Hour.Text = "1 hour";
            this.rb1Hour.UseVisualStyleBackColor = true;
            // 
            // dgvLockedSurveys
            // 
            this.dgvLockedSurveys.AllowUserToAddRows = false;
            this.dgvLockedSurveys.AllowUserToDeleteRows = false;
            this.dgvLockedSurveys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLockedSurveys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chSurvey,
            this.chTime,
            this.chName});
            this.dgvLockedSurveys.Location = new System.Drawing.Point(452, 95);
            this.dgvLockedSurveys.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvLockedSurveys.Name = "dgvLockedSurveys";
            this.dgvLockedSurveys.ReadOnly = true;
            this.dgvLockedSurveys.RowHeadersVisible = false;
            this.dgvLockedSurveys.Size = new System.Drawing.Size(335, 314);
            this.dgvLockedSurveys.TabIndex = 7;
            // 
            // cmdUnlock
            // 
            this.cmdUnlock.Location = new System.Drawing.Point(353, 264);
            this.cmdUnlock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdUnlock.Name = "cmdUnlock";
            this.cmdUnlock.Size = new System.Drawing.Size(87, 28);
            this.cmdUnlock.TabIndex = 8;
            this.cmdUnlock.Text = "Unlock";
            this.cmdUnlock.UseVisualStyleBackColor = true;
            this.cmdUnlock.Click += new System.EventHandler(this.cmdUnlock_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbWave);
            this.panel1.Controls.Add(this.rbSurvey);
            this.panel1.Controls.Add(this.cmdRemove);
            this.panel1.Controls.Add(this.cmdAdd);
            this.panel1.Controls.Add(this.lstSelected);
            this.panel1.Controls.Add(this.lstAllSurveys);
            this.panel1.Location = new System.Drawing.Point(12, 95);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 321);
            this.panel1.TabIndex = 9;
            // 
            // rbWave
            // 
            this.rbWave.AutoSize = true;
            this.rbWave.Location = new System.Drawing.Point(14, 42);
            this.rbWave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbWave.Name = "rbWave";
            this.rbWave.Size = new System.Drawing.Size(101, 20);
            this.rbWave.TabIndex = 7;
            this.rbWave.TabStop = true;
            this.rbWave.Text = "Add by Wave";
            this.rbWave.UseVisualStyleBackColor = true;
            this.rbWave.Click += new System.EventHandler(this.rbWave_Click);
            // 
            // rbSurvey
            // 
            this.rbSurvey.AutoSize = true;
            this.rbSurvey.Checked = true;
            this.rbSurvey.Location = new System.Drawing.Point(14, 14);
            this.rbSurvey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbSurvey.Name = "rbSurvey";
            this.rbSurvey.Size = new System.Drawing.Size(108, 20);
            this.rbSurvey.TabIndex = 6;
            this.rbSurvey.TabStop = true;
            this.rbSurvey.Text = "Add by Survey";
            this.rbSurvey.UseVisualStyleBackColor = true;
            this.rbSurvey.Click += new System.EventHandler(this.rbSurvey_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 33);
            this.label1.TabIndex = 10;
            this.label1.Text = "Unlock Surveys";
            // 
            // chSurvey
            // 
            this.chSurvey.HeaderText = "Survey";
            this.chSurvey.Name = "chSurvey";
            this.chSurvey.ReadOnly = true;
            this.chSurvey.Width = 75;
            // 
            // chTime
            // 
            this.chTime.HeaderText = "Time Remaining (mins)";
            this.chTime.Name = "chTime";
            this.chTime.ReadOnly = true;
            this.chTime.Width = 120;
            // 
            // chName
            // 
            this.chName.HeaderText = "Unlocked By";
            this.chName.Name = "chName";
            this.chName.ReadOnly = true;
            this.chName.Width = 80;
            // 
            // UnlockSurvey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 429);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdUnlock);
            this.Controls.Add(this.dgvLockedSurveys);
            this.Controls.Add(this.grpTimeInterval);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UnlockSurvey";
            this.Text = "Unlock Surveys";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpTimeInterval.ResumeLayout(false);
            this.grpTimeInterval.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLockedSurveys)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ListBox lstAllSurveys;
        private System.Windows.Forms.ListBox lstSelected;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.GroupBox grpTimeInterval;
        private System.Windows.Forms.RadioButton rb8Hours;
        private System.Windows.Forms.RadioButton rb4Hours;
        private System.Windows.Forms.RadioButton rb1Hour;
        private System.Windows.Forms.DataGridView dgvLockedSurveys;
        private System.Windows.Forms.Button cmdUnlock;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbWave;
        private System.Windows.Forms.RadioButton rbSurvey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn chSurvey;
        private System.Windows.Forms.DataGridViewTextBoxColumn chTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn chName;
    }
}