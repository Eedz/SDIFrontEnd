namespace SDIFrontEnd
{
    partial class AssignLabelsFilter
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
            this.optVarName = new System.Windows.Forms.RadioButton();
            this.optRefVar = new System.Windows.Forms.RadioButton();
            this.cboVarList = new System.Windows.Forms.ComboBox();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.lstSelectedVars = new System.Windows.Forms.ListBox();
            this.cmdApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // optVarName
            // 
            this.optVarName.AutoSize = true;
            this.optVarName.Location = new System.Drawing.Point(14, 15);
            this.optVarName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optVarName.Name = "optVarName";
            this.optVarName.Size = new System.Drawing.Size(78, 20);
            this.optVarName.TabIndex = 0;
            this.optVarName.TabStop = true;
            this.optVarName.Text = "VarName";
            this.optVarName.UseVisualStyleBackColor = true;
            this.optVarName.CheckedChanged += new System.EventHandler(this.optVarName_CheckedChanged);
            // 
            // optRefVar
            // 
            this.optRefVar.AutoSize = true;
            this.optRefVar.Location = new System.Drawing.Point(14, 43);
            this.optRefVar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optRefVar.Name = "optRefVar";
            this.optRefVar.Size = new System.Drawing.Size(94, 20);
            this.optRefVar.TabIndex = 1;
            this.optRefVar.TabStop = true;
            this.optRefVar.Text = "refVarName";
            this.optRefVar.UseVisualStyleBackColor = true;
            this.optRefVar.CheckedChanged += new System.EventHandler(this.optVarName_CheckedChanged);
            // 
            // cboVarList
            // 
            this.cboVarList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboVarList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVarList.FormattingEnabled = true;
            this.cboVarList.Location = new System.Drawing.Point(13, 68);
            this.cboVarList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboVarList.Name = "cboVarList";
            this.cboVarList.Size = new System.Drawing.Size(111, 24);
            this.cboVarList.TabIndex = 2;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(130, 68);
            this.cmdAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(39, 28);
            this.cmdAdd.TabIndex = 3;
            this.cmdAdd.Text = "-->";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Location = new System.Drawing.Point(130, 104);
            this.cmdRemove.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(39, 28);
            this.cmdRemove.TabIndex = 4;
            this.cmdRemove.Text = "<--";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // lstSelectedVars
            // 
            this.lstSelectedVars.FormattingEnabled = true;
            this.lstSelectedVars.ItemHeight = 16;
            this.lstSelectedVars.Location = new System.Drawing.Point(175, 68);
            this.lstSelectedVars.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstSelectedVars.Name = "lstSelectedVars";
            this.lstSelectedVars.Size = new System.Drawing.Size(106, 116);
            this.lstSelectedVars.TabIndex = 5;
            // 
            // cmdApply
            // 
            this.cmdApply.Location = new System.Drawing.Point(175, 192);
            this.cmdApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(106, 28);
            this.cmdApply.TabIndex = 6;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // AssignLabelsFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(196)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(290, 226);
            this.Controls.Add(this.cmdApply);
            this.Controls.Add(this.lstSelectedVars);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cboVarList);
            this.Controls.Add(this.optRefVar);
            this.Controls.Add(this.optVarName);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssignLabelsFilter";
            this.Text = "VarName Filter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton optVarName;
        private System.Windows.Forms.RadioButton optRefVar;
        private System.Windows.Forms.ComboBox cboVarList;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.ListBox lstSelectedVars;
        private System.Windows.Forms.Button cmdApply;
    }
}