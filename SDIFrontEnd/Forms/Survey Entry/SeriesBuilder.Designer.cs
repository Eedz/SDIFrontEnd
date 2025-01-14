namespace SDIFrontEnd
{
    partial class SeriesBuilder
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
            this.lstSeries = new System.Windows.Forms.ListView();
            this.chSeriesQnum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSeriesVarName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSeriesLitQ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtRO = new System.Windows.Forms.TextBox();
            this.txtNR = new System.Windows.Forms.TextBox();
            this.txtPstI = new System.Windows.Forms.TextBox();
            this.txtPstP = new System.Windows.Forms.TextBox();
            this.txtPreP = new System.Windows.Forms.TextBox();
            this.txtPreI = new System.Windows.Forms.TextBox();
            this.txtPreA = new System.Windows.Forms.TextBox();
            this.txtLitQ = new System.Windows.Forms.TextBox();
            this.txtSeriesPreA = new System.Windows.Forms.TextBox();
            this.txtSeriesPreI = new System.Windows.Forms.TextBox();
            this.txtSeriesPreP = new System.Windows.Forms.TextBox();
            this.txtSeriesPstP = new System.Windows.Forms.TextBox();
            this.txtSeriesPstI = new System.Windows.Forms.TextBox();
            this.txtSeriesNR = new System.Windows.Forms.TextBox();
            this.txtSeriesRO = new System.Windows.Forms.TextBox();
            this.txtNewVarName = new System.Windows.Forms.TextBox();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rtbSeriesText = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.cboDomain = new System.Windows.Forms.ComboBox();
            this.cboTopic = new System.Windows.Forms.ComboBox();
            this.cboContent = new System.Windows.Forms.ComboBox();
            this.txtVarLabel = new System.Windows.Forms.TextBox();
            this.rtbMemberText = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cboFieldName = new System.Windows.Forms.ComboBox();
            this.rtbWordingText = new System.Windows.Forms.RichTextBox();
            this.cmdApplyWording = new System.Windows.Forms.Button();
            this.cboWording = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstSeries
            // 
            this.lstSeries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSeriesQnum,
            this.chSeriesVarName,
            this.chSeriesLitQ});
            this.lstSeries.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSeries.FullRowSelect = true;
            this.lstSeries.HideSelection = false;
            this.lstSeries.Location = new System.Drawing.Point(12, 88);
            this.lstSeries.Name = "lstSeries";
            this.lstSeries.Size = new System.Drawing.Size(452, 224);
            this.lstSeries.TabIndex = 0;
            this.lstSeries.UseCompatibleStateImageBehavior = false;
            this.lstSeries.View = System.Windows.Forms.View.Details;
            this.lstSeries.SelectedIndexChanged += new System.EventHandler(this.lstSeries_SelectedIndexChanged);
            // 
            // chSeriesQnum
            // 
            this.chSeriesQnum.Text = "Q#";
            this.chSeriesQnum.Width = 40;
            // 
            // chSeriesVarName
            // 
            this.chSeriesVarName.Text = "VarName";
            this.chSeriesVarName.Width = 100;
            // 
            // chSeriesLitQ
            // 
            this.chSeriesLitQ.Text = "LitQ";
            this.chSeriesLitQ.Width = 300;
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(766, 484);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 13;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(685, 484);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtRO
            // 
            this.txtRO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRO.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRO.Location = new System.Drawing.Point(43, 153);
            this.txtRO.Multiline = true;
            this.txtRO.Name = "txtRO";
            this.txtRO.Size = new System.Drawing.Size(54, 24);
            this.txtRO.TabIndex = 15;
            this.txtRO.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtRO_MouseDoubleClick);
            this.txtRO.Validating += new System.ComponentModel.CancelEventHandler(this.MemberResponse_Validating);
            this.txtRO.Validated += new System.EventHandler(this.MemberWording_Validated);
            // 
            // txtNR
            // 
            this.txtNR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNR.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNR.Location = new System.Drawing.Point(43, 183);
            this.txtNR.Multiline = true;
            this.txtNR.Name = "txtNR";
            this.txtNR.Size = new System.Drawing.Size(54, 24);
            this.txtNR.TabIndex = 16;
            this.txtNR.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtNR_MouseDoubleClick);
            this.txtNR.Validating += new System.ComponentModel.CancelEventHandler(this.MemberResponse_Validating);
            this.txtNR.Validated += new System.EventHandler(this.MemberWording_Validated);
            // 
            // txtPstI
            // 
            this.txtPstI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPstI.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPstI.Location = new System.Drawing.Point(43, 213);
            this.txtPstI.Multiline = true;
            this.txtPstI.Name = "txtPstI";
            this.txtPstI.Size = new System.Drawing.Size(54, 24);
            this.txtPstI.TabIndex = 17;
            this.txtPstI.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPstI_MouseDoubleClick);
            this.txtPstI.Validating += new System.ComponentModel.CancelEventHandler(this.MemberWording_Validating);
            this.txtPstI.Validated += new System.EventHandler(this.MemberWording_Validated);
            // 
            // txtPstP
            // 
            this.txtPstP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPstP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPstP.Location = new System.Drawing.Point(43, 243);
            this.txtPstP.Multiline = true;
            this.txtPstP.Name = "txtPstP";
            this.txtPstP.Size = new System.Drawing.Size(54, 24);
            this.txtPstP.TabIndex = 18;
            this.txtPstP.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPstP_MouseDoubleClick);
            this.txtPstP.Validating += new System.ComponentModel.CancelEventHandler(this.MemberWording_Validating);
            this.txtPstP.Validated += new System.EventHandler(this.MemberWording_Validated);
            // 
            // txtPreP
            // 
            this.txtPreP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPreP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreP.Location = new System.Drawing.Point(43, 33);
            this.txtPreP.Multiline = true;
            this.txtPreP.Name = "txtPreP";
            this.txtPreP.Size = new System.Drawing.Size(54, 24);
            this.txtPreP.TabIndex = 19;
            this.txtPreP.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPreP_MouseDoubleClick);
            this.txtPreP.Validating += new System.ComponentModel.CancelEventHandler(this.MemberWording_Validating);
            this.txtPreP.Validated += new System.EventHandler(this.MemberWording_Validated);
            // 
            // txtPreI
            // 
            this.txtPreI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPreI.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreI.Location = new System.Drawing.Point(43, 63);
            this.txtPreI.Multiline = true;
            this.txtPreI.Name = "txtPreI";
            this.txtPreI.Size = new System.Drawing.Size(54, 24);
            this.txtPreI.TabIndex = 20;
            this.txtPreI.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPreI_MouseDoubleClick);
            this.txtPreI.Validating += new System.ComponentModel.CancelEventHandler(this.MemberWording_Validating);
            this.txtPreI.Validated += new System.EventHandler(this.MemberWording_Validated);
            // 
            // txtPreA
            // 
            this.txtPreA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPreA.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreA.Location = new System.Drawing.Point(43, 93);
            this.txtPreA.Multiline = true;
            this.txtPreA.Name = "txtPreA";
            this.txtPreA.Size = new System.Drawing.Size(54, 24);
            this.txtPreA.TabIndex = 21;
            this.txtPreA.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPreA_MouseDoubleClick);
            this.txtPreA.Validating += new System.ComponentModel.CancelEventHandler(this.MemberWording_Validating);
            this.txtPreA.Validated += new System.EventHandler(this.MemberWording_Validated);
            // 
            // txtLitQ
            // 
            this.txtLitQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLitQ.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLitQ.Location = new System.Drawing.Point(43, 123);
            this.txtLitQ.Multiline = true;
            this.txtLitQ.Name = "txtLitQ";
            this.txtLitQ.Size = new System.Drawing.Size(54, 24);
            this.txtLitQ.TabIndex = 22;
            this.txtLitQ.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtLitQ_MouseDoubleClick);
            this.txtLitQ.Validating += new System.ComponentModel.CancelEventHandler(this.MemberWording_Validating);
            this.txtLitQ.Validated += new System.EventHandler(this.MemberWording_Validated);
            // 
            // txtSeriesPreA
            // 
            this.txtSeriesPreA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSeriesPreA.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeriesPreA.Location = new System.Drawing.Point(373, 93);
            this.txtSeriesPreA.Multiline = true;
            this.txtSeriesPreA.Name = "txtSeriesPreA";
            this.txtSeriesPreA.Size = new System.Drawing.Size(1, 24);
            this.txtSeriesPreA.TabIndex = 29;
            // 
            // txtSeriesPreI
            // 
            this.txtSeriesPreI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSeriesPreI.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeriesPreI.Location = new System.Drawing.Point(373, 63);
            this.txtSeriesPreI.Multiline = true;
            this.txtSeriesPreI.Name = "txtSeriesPreI";
            this.txtSeriesPreI.Size = new System.Drawing.Size(1, 24);
            this.txtSeriesPreI.TabIndex = 28;
            // 
            // txtSeriesPreP
            // 
            this.txtSeriesPreP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSeriesPreP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeriesPreP.Location = new System.Drawing.Point(373, 33);
            this.txtSeriesPreP.Multiline = true;
            this.txtSeriesPreP.Name = "txtSeriesPreP";
            this.txtSeriesPreP.Size = new System.Drawing.Size(1, 24);
            this.txtSeriesPreP.TabIndex = 27;
            // 
            // txtSeriesPstP
            // 
            this.txtSeriesPstP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSeriesPstP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeriesPstP.Location = new System.Drawing.Point(373, 243);
            this.txtSeriesPstP.Multiline = true;
            this.txtSeriesPstP.Name = "txtSeriesPstP";
            this.txtSeriesPstP.Size = new System.Drawing.Size(1, 24);
            this.txtSeriesPstP.TabIndex = 26;
            // 
            // txtSeriesPstI
            // 
            this.txtSeriesPstI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSeriesPstI.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeriesPstI.Location = new System.Drawing.Point(373, 213);
            this.txtSeriesPstI.Multiline = true;
            this.txtSeriesPstI.Name = "txtSeriesPstI";
            this.txtSeriesPstI.Size = new System.Drawing.Size(1, 24);
            this.txtSeriesPstI.TabIndex = 25;
            // 
            // txtSeriesNR
            // 
            this.txtSeriesNR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSeriesNR.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeriesNR.Location = new System.Drawing.Point(373, 183);
            this.txtSeriesNR.Multiline = true;
            this.txtSeriesNR.Name = "txtSeriesNR";
            this.txtSeriesNR.Size = new System.Drawing.Size(1, 24);
            this.txtSeriesNR.TabIndex = 24;
            // 
            // txtSeriesRO
            // 
            this.txtSeriesRO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSeriesRO.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeriesRO.Location = new System.Drawing.Point(373, 153);
            this.txtSeriesRO.Multiline = true;
            this.txtSeriesRO.Name = "txtSeriesRO";
            this.txtSeriesRO.Size = new System.Drawing.Size(1, 24);
            this.txtSeriesRO.TabIndex = 23;
            // 
            // txtNewVarName
            // 
            this.txtNewVarName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewVarName.Location = new System.Drawing.Point(151, 59);
            this.txtNewVarName.Name = "txtNewVarName";
            this.txtNewVarName.Size = new System.Drawing.Size(100, 23);
            this.txtNewVarName.TabIndex = 30;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdd.Location = new System.Drawing.Point(257, 59);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(26, 23);
            this.cmdAdd.TabIndex = 31;
            this.cmdAdd.Text = "+";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(145, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 33);
            this.label1.TabIndex = 32;
            this.label1.Text = "Series Builder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Enter VarName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(373, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1, 30);
            this.label3.TabIndex = 34;
            this.label3.Text = "Series Wordings";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 3);
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(364, 30);
            this.label4.TabIndex = 35;
            this.label4.Text = "Member Wordings";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.Controls.Add(this.rtbSeriesText, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.rtbMemberText, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSeriesPstP, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtSeriesPreA, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtSeriesPstI, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtSeriesNR, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtSeriesPreI, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSeriesRO, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtPreP, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSeriesPreP, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPreI, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPreA, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtLitQ, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPstI, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtRO, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtPstP, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtNR, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label18, 0, 8);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(474, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(370, 450);
            this.tableLayoutPanel1.TabIndex = 36;
            // 
            // rtbSeriesText
            // 
            this.rtbSeriesText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSeriesText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSeriesText.Location = new System.Drawing.Point(373, 33);
            this.rtbSeriesText.Name = "rtbSeriesText";
            this.tableLayoutPanel1.SetRowSpan(this.rtbSeriesText, 8);
            this.rtbSeriesText.Size = new System.Drawing.Size(1, 234);
            this.rtbSeriesText.TabIndex = 41;
            this.rtbSeriesText.Text = "";
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboProduct);
            this.panel1.Controls.Add(this.cboDomain);
            this.panel1.Controls.Add(this.cboTopic);
            this.panel1.Controls.Add(this.cboContent);
            this.panel1.Controls.Add(this.txtVarLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 273);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 174);
            this.panel1.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "Product";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Domain";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Topic";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Content";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "VarLabel";
            // 
            // cboProduct
            // 
            this.cboProduct.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(64, 123);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(292, 24);
            this.cboProduct.TabIndex = 4;
            // 
            // cboDomain
            // 
            this.cboDomain.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDomain.FormattingEnabled = true;
            this.cboDomain.Location = new System.Drawing.Point(64, 96);
            this.cboDomain.Name = "cboDomain";
            this.cboDomain.Size = new System.Drawing.Size(292, 24);
            this.cboDomain.TabIndex = 3;
            // 
            // cboTopic
            // 
            this.cboTopic.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTopic.FormattingEnabled = true;
            this.cboTopic.Location = new System.Drawing.Point(64, 69);
            this.cboTopic.Name = "cboTopic";
            this.cboTopic.Size = new System.Drawing.Size(292, 24);
            this.cboTopic.TabIndex = 2;
            // 
            // cboContent
            // 
            this.cboContent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboContent.FormattingEnabled = true;
            this.cboContent.Location = new System.Drawing.Point(64, 42);
            this.cboContent.Name = "cboContent";
            this.cboContent.Size = new System.Drawing.Size(292, 24);
            this.cboContent.TabIndex = 1;
            // 
            // txtVarLabel
            // 
            this.txtVarLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVarLabel.Location = new System.Drawing.Point(64, 17);
            this.txtVarLabel.Name = "txtVarLabel";
            this.txtVarLabel.Size = new System.Drawing.Size(292, 23);
            this.txtVarLabel.TabIndex = 0;
            // 
            // rtbMemberText
            // 
            this.rtbMemberText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMemberText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMemberText.Location = new System.Drawing.Point(103, 33);
            this.rtbMemberText.Name = "rtbMemberText";
            this.tableLayoutPanel1.SetRowSpan(this.rtbMemberText, 8);
            this.rtbMemberText.Size = new System.Drawing.Size(264, 234);
            this.rtbMemberText.TabIndex = 41;
            this.rtbMemberText.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 30);
            this.label11.TabIndex = 42;
            this.label11.Text = "PreP";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 30);
            this.label12.TabIndex = 43;
            this.label12.Text = "PreI";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 30);
            this.label13.TabIndex = 44;
            this.label13.Text = "PreA";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(3, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 30);
            this.label14.TabIndex = 45;
            this.label14.Text = "LitQ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(3, 150);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 30);
            this.label15.TabIndex = 46;
            this.label15.Text = "ROs";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(3, 180);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 30);
            this.label16.TabIndex = 47;
            this.label16.Text = "NRs";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(3, 210);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 30);
            this.label17.TabIndex = 48;
            this.label17.Text = "PstI";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(3, 240);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(34, 30);
            this.label18.TabIndex = 49;
            this.label18.Text = "PstP";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboFieldName
            // 
            this.cboFieldName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFieldName.FormattingEnabled = true;
            this.cboFieldName.Location = new System.Drawing.Point(12, 35);
            this.cboFieldName.Name = "cboFieldName";
            this.cboFieldName.Size = new System.Drawing.Size(121, 24);
            this.cboFieldName.TabIndex = 37;
            this.cboFieldName.SelectedIndexChanged += new System.EventHandler(this.cboFieldName_SelectedIndexChanged);
            // 
            // rtbWordingText
            // 
            this.rtbWordingText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbWordingText.Location = new System.Drawing.Point(186, 35);
            this.rtbWordingText.Name = "rtbWordingText";
            this.rtbWordingText.Size = new System.Drawing.Size(265, 79);
            this.rtbWordingText.TabIndex = 38;
            this.rtbWordingText.Text = "";
            // 
            // cmdApplyWording
            // 
            this.cmdApplyWording.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdApplyWording.Location = new System.Drawing.Point(395, 120);
            this.cmdApplyWording.Name = "cmdApplyWording";
            this.cmdApplyWording.Size = new System.Drawing.Size(56, 28);
            this.cmdApplyWording.TabIndex = 39;
            this.cmdApplyWording.Text = "Apply";
            this.cmdApplyWording.UseVisualStyleBackColor = true;
            this.cmdApplyWording.Click += new System.EventHandler(this.cmdApplyWording_Click);
            // 
            // cboWording
            // 
            this.cboWording.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWording.FormattingEnabled = true;
            this.cboWording.Location = new System.Drawing.Point(186, 11);
            this.cboWording.Name = "cboWording";
            this.cboWording.Size = new System.Drawing.Size(104, 24);
            this.cboWording.TabIndex = 40;
            this.cboWording.SelectedIndexChanged += new System.EventHandler(this.cboWording_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 16);
            this.label10.TabIndex = 41;
            this.label10.Text = "Set wording for all members";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.cboWording);
            this.panel2.Controls.Add(this.cmdApplyWording);
            this.panel2.Controls.Add(this.rtbWordingText);
            this.panel2.Controls.Add(this.cboFieldName);
            this.panel2.Location = new System.Drawing.Point(13, 325);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(454, 153);
            this.panel2.TabIndex = 42;
            // 
            // SeriesBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 516);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtNewVarName);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstSeries);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SeriesBuilder";
            this.Text = "Series Builder";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstSeries;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TextBox txtRO;
        private System.Windows.Forms.ColumnHeader chSeriesVarName;
        private System.Windows.Forms.ColumnHeader chSeriesLitQ;
        private System.Windows.Forms.TextBox txtNR;
        private System.Windows.Forms.TextBox txtPstI;
        private System.Windows.Forms.TextBox txtPstP;
        private System.Windows.Forms.TextBox txtPreP;
        private System.Windows.Forms.TextBox txtPreI;
        private System.Windows.Forms.TextBox txtPreA;
        private System.Windows.Forms.TextBox txtLitQ;
        private System.Windows.Forms.TextBox txtSeriesPreA;
        private System.Windows.Forms.TextBox txtSeriesPreI;
        private System.Windows.Forms.TextBox txtSeriesPreP;
        private System.Windows.Forms.TextBox txtSeriesPstP;
        private System.Windows.Forms.TextBox txtSeriesPstI;
        private System.Windows.Forms.TextBox txtSeriesNR;
        private System.Windows.Forms.TextBox txtSeriesRO;
        private System.Windows.Forms.TextBox txtNewVarName;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ColumnHeader chSeriesQnum;
        private System.Windows.Forms.ComboBox cboFieldName;
        private System.Windows.Forms.RichTextBox rtbWordingText;
        private System.Windows.Forms.Button cmdApplyWording;
        private System.Windows.Forms.ComboBox cboWording;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.ComboBox cboDomain;
        private System.Windows.Forms.ComboBox cboTopic;
        private System.Windows.Forms.ComboBox cboContent;
        private System.Windows.Forms.TextBox txtVarLabel;
        private System.Windows.Forms.RichTextBox rtbMemberText;
        private System.Windows.Forms.RichTextBox rtbSeriesText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
    }
}