namespace SDIFrontEnd
{
    partial class NewRegionEntry
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtTempVarPrefix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRegionName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Temp Var Prefix";
            // 
            // txtTempVarPrefix
            // 
            this.txtTempVarPrefix.Location = new System.Drawing.Point(121, 129);
            this.txtTempVarPrefix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTempVarPrefix.Name = "txtTempVarPrefix";
            this.txtTempVarPrefix.Size = new System.Drawing.Size(116, 23);
            this.txtTempVarPrefix.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Region Name";
            // 
            // txtRegionName
            // 
            this.txtRegionName.Location = new System.Drawing.Point(121, 97);
            this.txtRegionName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRegionName.Name = "txtRegionName";
            this.txtRegionName.Size = new System.Drawing.Size(116, 23);
            this.txtRegionName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(121, 65);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(116, 23);
            this.txtID.TabIndex = 6;
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(160, 198);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(70, 42);
            this.cmdSave.TabIndex = 46;
            this.cmdSave.Text = "OK";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(31, 175);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(292, 2);
            this.label10.TabIndex = 45;
            this.label10.Text = "label10";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(237, 198);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(70, 42);
            this.cmdCancel.TabIndex = 44;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(90, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 33);
            this.label6.TabIndex = 47;
            this.label6.Text = "New Region";
            // 
            // NewRegionEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(219)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(356, 261);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTempVarPrefix);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRegionName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtID);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "NewRegionEntry";
            this.Text = "New Region";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTempVarPrefix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRegionName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label6;
    }
}