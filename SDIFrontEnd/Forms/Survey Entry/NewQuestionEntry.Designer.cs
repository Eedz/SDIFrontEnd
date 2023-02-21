namespace SDIFrontEnd
{
    partial class NewQuestionEntry
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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lstToCopy = new System.Windows.Forms.ListView();
            this.chNewQnum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNewVarName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNewVarLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNewRespName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstQuestionSource = new System.Windows.Forms.ListView();
            this.chQnum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVarName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVarLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRespName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCorr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dgvRelatedVars = new System.Windows.Forms.DataGridView();
            this.chRefVarname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chRelatedVarLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chRelatedContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chRelatedTopic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chRelatedDomain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chRelatedProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewVarName = new System.Windows.Forms.TextBox();
            this.optCopy = new System.Windows.Forms.RadioButton();
            this.optNew = new System.Windows.Forms.RadioButton();
            this.cboDomain = new System.Windows.Forms.ComboBox();
            this.cboTopic = new System.Windows.Forms.ComboBox();
            this.cboContent = new System.Windows.Forms.ComboBox();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.txtVarLabel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelNew = new System.Windows.Forms.Panel();
            this.lblTempPrefix = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panelCopy = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.cboVarName = new System.Windows.Forms.ComboBox();
            this.lblCopyToNewInfo = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboSurveySource = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedVars)).BeginInit();
            this.panelNew.SuspendLayout();
            this.panelCopy.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(1044, 596);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(87, 28);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(1138, 596);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 28);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(12, 583);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1231, 2);
            this.label5.TabIndex = 13;
            this.label5.Text = "label5";
            // 
            // cmdRemove
            // 
            this.cmdRemove.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemove.Location = new System.Drawing.Point(629, 138);
            this.cmdRemove.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(57, 28);
            this.cmdRemove.TabIndex = 3;
            this.cmdRemove.Text = "<-";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdd.Location = new System.Drawing.Point(629, 105);
            this.cmdAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(57, 28);
            this.cmdAdd.TabIndex = 2;
            this.cmdAdd.Text = "->";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lstToCopy
            // 
            this.lstToCopy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNewQnum,
            this.chNewVarName,
            this.chNewVarLabel,
            this.chNewRespName});
            this.lstToCopy.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstToCopy.FullRowSelect = true;
            this.lstToCopy.HideSelection = false;
            this.lstToCopy.Location = new System.Drawing.Point(693, 89);
            this.lstToCopy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstToCopy.Name = "lstToCopy";
            this.lstToCopy.Size = new System.Drawing.Size(495, 398);
            this.lstToCopy.TabIndex = 1;
            this.lstToCopy.UseCompatibleStateImageBehavior = false;
            this.lstToCopy.View = System.Windows.Forms.View.Details;
            this.lstToCopy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstToCopy_MouseClick);
            // 
            // chNewQnum
            // 
            this.chNewQnum.Width = 0;
            // 
            // chNewVarName
            // 
            this.chNewVarName.Text = "VarName";
            this.chNewVarName.Width = 65;
            // 
            // chNewVarLabel
            // 
            this.chNewVarLabel.Text = "VarLabel";
            this.chNewVarLabel.Width = 280;
            // 
            // chNewRespName
            // 
            this.chNewRespName.Text = "RespName";
            this.chNewRespName.Width = 75;
            // 
            // lstQuestionSource
            // 
            this.lstQuestionSource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chQnum,
            this.chVarName,
            this.chVarLabel,
            this.chRespName,
            this.chCorr});
            this.lstQuestionSource.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstQuestionSource.FullRowSelect = true;
            this.lstQuestionSource.HideSelection = false;
            this.lstQuestionSource.Location = new System.Drawing.Point(3, 89);
            this.lstQuestionSource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstQuestionSource.Name = "lstQuestionSource";
            this.lstQuestionSource.Size = new System.Drawing.Size(620, 398);
            this.lstQuestionSource.TabIndex = 0;
            this.lstQuestionSource.UseCompatibleStateImageBehavior = false;
            this.lstQuestionSource.View = System.Windows.Forms.View.Details;
            this.lstQuestionSource.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstQuestionSource_MouseDoubleClick);
            // 
            // chQnum
            // 
            this.chQnum.Text = "Q#";
            // 
            // chVarName
            // 
            this.chVarName.Text = "VarName";
            this.chVarName.Width = 65;
            // 
            // chVarLabel
            // 
            this.chVarLabel.Text = "VarLabel";
            this.chVarLabel.Width = 280;
            // 
            // chRespName
            // 
            this.chRespName.Text = "RespName";
            this.chRespName.Width = 75;
            // 
            // chCorr
            // 
            this.chCorr.Text = "Corrected";
            this.chCorr.Width = 75;
            // 
            // dgvRelatedVars
            // 
            this.dgvRelatedVars.AllowUserToAddRows = false;
            this.dgvRelatedVars.AllowUserToDeleteRows = false;
            this.dgvRelatedVars.AllowUserToResizeRows = false;
            this.dgvRelatedVars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvRelatedVars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatedVars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chRefVarname,
            this.chRelatedVarLabel,
            this.chRelatedContent,
            this.chRelatedTopic,
            this.chRelatedDomain,
            this.chRelatedProduct});
            this.dgvRelatedVars.Location = new System.Drawing.Point(3, 223);
            this.dgvRelatedVars.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvRelatedVars.Name = "dgvRelatedVars";
            this.dgvRelatedVars.ReadOnly = true;
            this.dgvRelatedVars.RowHeadersVisible = false;
            this.dgvRelatedVars.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRelatedVars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRelatedVars.Size = new System.Drawing.Size(807, 236);
            this.dgvRelatedVars.TabIndex = 2;
            this.dgvRelatedVars.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRelatedVars_CellMouseDoubleClick);
            this.dgvRelatedVars.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvRelatedVars_DataBindingComplete);
            this.dgvRelatedVars.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvRelatedVars_DataError);
            // 
            // chRefVarname
            // 
            this.chRefVarname.HeaderText = "refVarName";
            this.chRefVarname.Name = "chRefVarname";
            this.chRefVarname.ReadOnly = true;
            this.chRefVarname.Width = 101;
            // 
            // chRelatedVarLabel
            // 
            this.chRelatedVarLabel.HeaderText = "VarLabel";
            this.chRelatedVarLabel.Name = "chRelatedVarLabel";
            this.chRelatedVarLabel.ReadOnly = true;
            this.chRelatedVarLabel.Width = 82;
            // 
            // chRelatedContent
            // 
            this.chRelatedContent.HeaderText = "Content";
            this.chRelatedContent.Name = "chRelatedContent";
            this.chRelatedContent.ReadOnly = true;
            this.chRelatedContent.Width = 76;
            // 
            // chRelatedTopic
            // 
            this.chRelatedTopic.HeaderText = "Topic";
            this.chRelatedTopic.Name = "chRelatedTopic";
            this.chRelatedTopic.ReadOnly = true;
            this.chRelatedTopic.Width = 63;
            // 
            // chRelatedDomain
            // 
            this.chRelatedDomain.HeaderText = "Domain";
            this.chRelatedDomain.Name = "chRelatedDomain";
            this.chRelatedDomain.ReadOnly = true;
            this.chRelatedDomain.Width = 75;
            // 
            // chRelatedProduct
            // 
            this.chRelatedProduct.HeaderText = "Product";
            this.chRelatedProduct.Name = "chRelatedProduct";
            this.chRelatedProduct.ReadOnly = true;
            this.chRelatedProduct.Width = 75;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter New VarName";
            // 
            // txtNewVarName
            // 
            this.txtNewVarName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewVarName.Location = new System.Drawing.Point(169, 56);
            this.txtNewVarName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNewVarName.Name = "txtNewVarName";
            this.txtNewVarName.Size = new System.Drawing.Size(116, 23);
            this.txtNewVarName.TabIndex = 0;
            // 
            // optCopy
            // 
            this.optCopy.AutoSize = true;
            this.optCopy.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optCopy.Location = new System.Drawing.Point(60, 52);
            this.optCopy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optCopy.Name = "optCopy";
            this.optCopy.Size = new System.Drawing.Size(170, 20);
            this.optCopy.TabIndex = 15;
            this.optCopy.TabStop = true;
            this.optCopy.Text = "Copy Existing Question(s)";
            this.optCopy.UseVisualStyleBackColor = true;
            this.optCopy.CheckedChanged += new System.EventHandler(this.EnterMode_CheckedChanged);
            // 
            // optNew
            // 
            this.optNew.AutoSize = true;
            this.optNew.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optNew.Location = new System.Drawing.Point(291, 52);
            this.optNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optNew.Name = "optNew";
            this.optNew.Size = new System.Drawing.Size(146, 20);
            this.optNew.TabIndex = 16;
            this.optNew.TabStop = true;
            this.optNew.Text = "Create New Question";
            this.optNew.UseVisualStyleBackColor = true;
            this.optNew.CheckedChanged += new System.EventHandler(this.EnterMode_CheckedChanged);
            // 
            // cboDomain
            // 
            this.cboDomain.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDomain.FormattingEnabled = true;
            this.cboDomain.Location = new System.Drawing.Point(372, 84);
            this.cboDomain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDomain.Name = "cboDomain";
            this.cboDomain.Size = new System.Drawing.Size(368, 24);
            this.cboDomain.TabIndex = 3;
            // 
            // cboTopic
            // 
            this.cboTopic.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTopic.FormattingEnabled = true;
            this.cboTopic.Location = new System.Drawing.Point(372, 114);
            this.cboTopic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTopic.Name = "cboTopic";
            this.cboTopic.Size = new System.Drawing.Size(368, 24);
            this.cboTopic.TabIndex = 4;
            // 
            // cboContent
            // 
            this.cboContent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboContent.FormattingEnabled = true;
            this.cboContent.Location = new System.Drawing.Point(372, 142);
            this.cboContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboContent.Name = "cboContent";
            this.cboContent.Size = new System.Drawing.Size(368, 24);
            this.cboContent.TabIndex = 5;
            // 
            // cboProduct
            // 
            this.cboProduct.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(372, 172);
            this.cboProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(368, 24);
            this.cboProduct.TabIndex = 6;
            // 
            // txtVarLabel
            // 
            this.txtVarLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVarLabel.Location = new System.Drawing.Point(372, 56);
            this.txtVarLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVarLabel.Name = "txtVarLabel";
            this.txtVarLabel.Size = new System.Drawing.Size(368, 23);
            this.txtVarLabel.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(397, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Choose or enter labels";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(304, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "VarLabel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(311, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Domain";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(322, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Topic";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(310, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Content";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(310, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Product";
            // 
            // panelNew
            // 
            this.panelNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNew.Controls.Add(this.lblTempPrefix);
            this.panelNew.Controls.Add(this.label13);
            this.panelNew.Controls.Add(this.txtFilter);
            this.panelNew.Controls.Add(this.label9);
            this.panelNew.Controls.Add(this.label8);
            this.panelNew.Controls.Add(this.dgvRelatedVars);
            this.panelNew.Controls.Add(this.label7);
            this.panelNew.Controls.Add(this.txtNewVarName);
            this.panelNew.Controls.Add(this.label6);
            this.panelNew.Controls.Add(this.label1);
            this.panelNew.Controls.Add(this.label4);
            this.panelNew.Controls.Add(this.cboDomain);
            this.panelNew.Controls.Add(this.label3);
            this.panelNew.Controls.Add(this.cboTopic);
            this.panelNew.Controls.Add(this.label2);
            this.panelNew.Controls.Add(this.cboContent);
            this.panelNew.Controls.Add(this.txtVarLabel);
            this.panelNew.Controls.Add(this.cboProduct);
            this.panelNew.Location = new System.Drawing.Point(530, 80);
            this.panelNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelNew.Name = "panelNew";
            this.panelNew.Size = new System.Drawing.Size(605, 428);
            this.panelNew.TabIndex = 17;
            this.panelNew.Visible = false;
            // 
            // lblTempPrefix
            // 
            this.lblTempPrefix.AutoSize = true;
            this.lblTempPrefix.Location = new System.Drawing.Point(9, 7);
            this.lblTempPrefix.Name = "lblTempPrefix";
            this.lblTempPrefix.Size = new System.Drawing.Size(208, 16);
            this.lblTempPrefix.TabIndex = 17;
            this.lblTempPrefix.Text = "Temp Prefix for [Survey] is [Prefix]";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 134);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 14);
            this.label13.TabIndex = 16;
            this.label13.Text = "Find similar VarNames";
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(9, 164);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(116, 22);
            this.txtFilter.TabIndex = 15;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(297, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Double click a row to copy those labels to this new VarName.";
            // 
            // panelCopy
            // 
            this.panelCopy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCopy.Controls.Add(this.label14);
            this.panelCopy.Controls.Add(this.cboVarName);
            this.panelCopy.Controls.Add(this.lblCopyToNewInfo);
            this.panelCopy.Controls.Add(this.label12);
            this.panelCopy.Controls.Add(this.cboSurveySource);
            this.panelCopy.Controls.Add(this.label11);
            this.panelCopy.Controls.Add(this.label10);
            this.panelCopy.Controls.Add(this.cmdRemove);
            this.panelCopy.Controls.Add(this.lstToCopy);
            this.panelCopy.Controls.Add(this.cmdAdd);
            this.panelCopy.Controls.Add(this.lstQuestionSource);
            this.panelCopy.Location = new System.Drawing.Point(14, 80);
            this.panelCopy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelCopy.Name = "panelCopy";
            this.panelCopy.Size = new System.Drawing.Size(510, 366);
            this.panelCopy.TabIndex = 18;
            this.panelCopy.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(285, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 16);
            this.label14.TabIndex = 10;
            this.label14.Text = "Find Var";
            // 
            // cboVarName
            // 
            this.cboVarName.FormattingEnabled = true;
            this.cboVarName.Location = new System.Drawing.Point(346, 56);
            this.cboVarName.Name = "cboVarName";
            this.cboVarName.Size = new System.Drawing.Size(121, 24);
            this.cboVarName.TabIndex = 9;
            this.cboVarName.SelectedIndexChanged += new System.EventHandler(this.cboVarName_SelectedIndexChanged);
            // 
            // lblCopyToNewInfo
            // 
            this.lblCopyToNewInfo.AutoSize = true;
            this.lblCopyToNewInfo.Location = new System.Drawing.Point(788, 63);
            this.lblCopyToNewInfo.Name = "lblCopyToNewInfo";
            this.lblCopyToNewInfo.Size = new System.Drawing.Size(267, 16);
            this.lblCopyToNewInfo.TabIndex = 8;
            this.lblCopyToNewInfo.Text = "These VarNames will be added to the survey.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(49, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 16);
            this.label12.TabIndex = 7;
            this.label12.Text = "Survey";
            // 
            // cboSurveySource
            // 
            this.cboSurveySource.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSurveySource.FormattingEnabled = true;
            this.cboSurveySource.Location = new System.Drawing.Point(111, 55);
            this.cboSurveySource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSurveySource.Name = "cboSurveySource";
            this.cboSurveySource.Size = new System.Drawing.Size(140, 24);
            this.cboSurveySource.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(468, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Use the arrows or double click the left list to add, or right-click the right lis" +
    "t to remove questions.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(440, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Choose a survey and add questions to the list on the right to import them into th" +
    "is survey.";
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestination.Location = new System.Drawing.Point(11, 9);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(294, 25);
            this.lblDestination.TabIndex = 19;
            this.lblDestination.Text = "Adding to [Survey] at [Qnum]";
            // 
            // NewQuestionEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 637);
            this.ControlBox = false;
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.panelCopy);
            this.Controls.Add(this.panelNew);
            this.Controls.Add(this.optNew);
            this.Controls.Add(this.optCopy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NewQuestionEntry";
            this.Text = "Add New Question(s)";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedVars)).EndInit();
            this.panelNew.ResumeLayout(false);
            this.panelNew.PerformLayout();
            this.panelCopy.ResumeLayout(false);
            this.panelCopy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton optCopy;
        private System.Windows.Forms.RadioButton optNew;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.ListView lstToCopy;
        private System.Windows.Forms.ListView lstQuestionSource;
        private System.Windows.Forms.DataGridView dgvRelatedVars;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewVarName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVarLabel;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.ComboBox cboContent;
        private System.Windows.Forms.ComboBox cboTopic;
        private System.Windows.Forms.ComboBox cboDomain;
        private System.Windows.Forms.Panel panelNew;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelCopy;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboSurveySource;
        private System.Windows.Forms.ColumnHeader chQnum;
        private System.Windows.Forms.ColumnHeader chVarName;
        private System.Windows.Forms.ColumnHeader chVarLabel;
        private System.Windows.Forms.ColumnHeader chRespName;
        private System.Windows.Forms.ColumnHeader chCorr;
        private System.Windows.Forms.ColumnHeader chNewVarName;
        private System.Windows.Forms.ColumnHeader chNewVarLabel;
        private System.Windows.Forms.ColumnHeader chNewRespName;
        private System.Windows.Forms.ColumnHeader chNewQnum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Label lblTempPrefix;
        private System.Windows.Forms.Label lblCopyToNewInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRefVarname;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRelatedVarLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRelatedContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRelatedTopic;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRelatedDomain;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRelatedProduct;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboVarName;
    }
}