namespace SDIFrontEnd
{
    partial class HarmonyReportForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabVarNames = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.lstSelVar = new System.Windows.Forms.ListBox();
            this.lstPrefixes = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdAddVar = new System.Windows.Forms.Button();
            this.cmdRemoveVar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboVarNames = new System.Windows.Forms.ComboBox();
            this.tabWaves = new System.Windows.Forms.TabPage();
            this.chkColorTranslations = new System.Windows.Forms.CheckBox();
            this.chkColorWordings = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboLanguage = new System.Windows.Forms.ComboBox();
            this.chkMultipleWordingsOnly = new System.Windows.Forms.CheckBox();
            this.chkIncludeTranslation = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboWaves = new System.Windows.Forms.ComboBox();
            this.tabSurveys = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lstSurveys = new System.Windows.Forms.ListBox();
            this.lstWaves = new System.Windows.Forms.ListBox();
            this.lstStudies = new System.Windows.Forms.ListBox();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.chkShowFieldwork = new System.Windows.Forms.CheckBox();
            this.chkSeparateLabels = new System.Windows.Forms.CheckBox();
            this.chkRecentWaves = new System.Windows.Forms.CheckBox();
            this.chkShowAllSurveys = new System.Windows.Forms.CheckBox();
            this.chkShowGroupOn = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.optDisplayProjects = new System.Windows.Forms.RadioButton();
            this.optDisplaySurveys = new System.Windows.Forms.RadioButton();
            this.lstGroupOn = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.optWave = new System.Windows.Forms.RadioButton();
            this.optRefVarName = new System.Windows.Forms.RadioButton();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.cmdOnscreen = new System.Windows.Forms.Button();
            this.cmdWordDocument = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSeparateDoc = new System.Windows.Forms.Button();
            this.cmdLast5Years = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabVarNames.SuspendLayout();
            this.tabWaves.SuspendLayout();
            this.tabSurveys.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabVarNames);
            this.tabControl1.Controls.Add(this.tabWaves);
            this.tabControl1.Controls.Add(this.tabSurveys);
            this.tabControl1.Controls.Add(this.tabOptions);
            this.tabControl1.Location = new System.Drawing.Point(0, 144);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(433, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabVarNames
            // 
            this.tabVarNames.Controls.Add(this.label4);
            this.tabVarNames.Controls.Add(this.lstSelVar);
            this.tabVarNames.Controls.Add(this.lstPrefixes);
            this.tabVarNames.Controls.Add(this.label3);
            this.tabVarNames.Controls.Add(this.cmdAddVar);
            this.tabVarNames.Controls.Add(this.cmdRemoveVar);
            this.tabVarNames.Controls.Add(this.label2);
            this.tabVarNames.Controls.Add(this.cboVarNames);
            this.tabVarNames.Location = new System.Drawing.Point(4, 25);
            this.tabVarNames.Name = "tabVarNames";
            this.tabVarNames.Padding = new System.Windows.Forms.Padding(3);
            this.tabVarNames.Size = new System.Drawing.Size(425, 421);
            this.tabVarNames.TabIndex = 0;
            this.tabVarNames.Text = "By VarNames (Classic)";
            this.tabVarNames.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Selected Vars";
            // 
            // lstSelVar
            // 
            this.lstSelVar.FormattingEnabled = true;
            this.lstSelVar.ItemHeight = 16;
            this.lstSelVar.Location = new System.Drawing.Point(177, 45);
            this.lstSelVar.Name = "lstSelVar";
            this.lstSelVar.Size = new System.Drawing.Size(186, 340);
            this.lstSelVar.TabIndex = 6;
            // 
            // lstPrefixes
            // 
            this.lstPrefixes.FormattingEnabled = true;
            this.lstPrefixes.ItemHeight = 16;
            this.lstPrefixes.Location = new System.Drawing.Point(29, 146);
            this.lstPrefixes.Name = "lstPrefixes";
            this.lstPrefixes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstPrefixes.Size = new System.Drawing.Size(94, 244);
            this.lstPrefixes.TabIndex = 5;
            this.lstPrefixes.SelectedIndexChanged += new System.EventHandler(this.lstPrefixes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Prefixes:";
            // 
            // cmdAddVar
            // 
            this.cmdAddVar.Location = new System.Drawing.Point(101, 80);
            this.cmdAddVar.Name = "cmdAddVar";
            this.cmdAddVar.Size = new System.Drawing.Size(65, 28);
            this.cmdAddVar.TabIndex = 3;
            this.cmdAddVar.Text = "-->";
            this.cmdAddVar.UseVisualStyleBackColor = true;
            this.cmdAddVar.Click += new System.EventHandler(this.cmdAddVar_Click);
            // 
            // cmdRemoveVar
            // 
            this.cmdRemoveVar.Location = new System.Drawing.Point(24, 80);
            this.cmdRemoveVar.Name = "cmdRemoveVar";
            this.cmdRemoveVar.Size = new System.Drawing.Size(65, 28);
            this.cmdRemoveVar.TabIndex = 2;
            this.cmdRemoveVar.Text = "<--";
            this.cmdRemoveVar.UseVisualStyleBackColor = true;
            this.cmdRemoveVar.Click += new System.EventHandler(this.cmdRemoveVar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vars:";
            // 
            // cboVarNames
            // 
            this.cboVarNames.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboVarNames.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVarNames.FormattingEnabled = true;
            this.cboVarNames.Location = new System.Drawing.Point(26, 47);
            this.cboVarNames.Name = "cboVarNames";
            this.cboVarNames.Size = new System.Drawing.Size(140, 24);
            this.cboVarNames.TabIndex = 0;
            // 
            // tabWaves
            // 
            this.tabWaves.Controls.Add(this.chkColorTranslations);
            this.tabWaves.Controls.Add(this.chkColorWordings);
            this.tabWaves.Controls.Add(this.label7);
            this.tabWaves.Controls.Add(this.cboLanguage);
            this.tabWaves.Controls.Add(this.chkMultipleWordingsOnly);
            this.tabWaves.Controls.Add(this.chkIncludeTranslation);
            this.tabWaves.Controls.Add(this.label6);
            this.tabWaves.Controls.Add(this.cboWaves);
            this.tabWaves.Location = new System.Drawing.Point(4, 25);
            this.tabWaves.Name = "tabWaves";
            this.tabWaves.Padding = new System.Windows.Forms.Padding(3);
            this.tabWaves.Size = new System.Drawing.Size(425, 421);
            this.tabWaves.TabIndex = 1;
            this.tabWaves.Text = "By Wave (Unique Questions)";
            this.tabWaves.UseVisualStyleBackColor = true;
            // 
            // chkColorTranslations
            // 
            this.chkColorTranslations.AutoSize = true;
            this.chkColorTranslations.Location = new System.Drawing.Point(50, 187);
            this.chkColorTranslations.Name = "chkColorTranslations";
            this.chkColorTranslations.Size = new System.Drawing.Size(162, 20);
            this.chkColorTranslations.TabIndex = 7;
            this.chkColorTranslations.Text = "Color-code Translations";
            this.chkColorTranslations.UseVisualStyleBackColor = true;
            this.chkColorTranslations.Visible = false;
            // 
            // chkColorWordings
            // 
            this.chkColorWordings.AutoSize = true;
            this.chkColorWordings.Location = new System.Drawing.Point(50, 159);
            this.chkColorWordings.Name = "chkColorWordings";
            this.chkColorWordings.Size = new System.Drawing.Size(192, 20);
            this.chkColorWordings.TabIndex = 6;
            this.chkColorWordings.Text = "Color-code wording numbers";
            this.chkColorWordings.UseVisualStyleBackColor = true;
            this.chkColorWordings.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Language:";
            // 
            // cboLanguage
            // 
            this.cboLanguage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboLanguage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboLanguage.FormattingEnabled = true;
            this.cboLanguage.Location = new System.Drawing.Point(108, 95);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.Size = new System.Drawing.Size(140, 24);
            this.cboLanguage.TabIndex = 4;
            // 
            // chkMultipleWordingsOnly
            // 
            this.chkMultipleWordingsOnly.AutoSize = true;
            this.chkMultipleWordingsOnly.Location = new System.Drawing.Point(51, 130);
            this.chkMultipleWordingsOnly.Name = "chkMultipleWordingsOnly";
            this.chkMultipleWordingsOnly.Size = new System.Drawing.Size(248, 20);
            this.chkMultipleWordingsOnly.TabIndex = 3;
            this.chkMultipleWordingsOnly.Text = "Show only Vars with multiple wordings";
            this.chkMultipleWordingsOnly.UseVisualStyleBackColor = true;
            // 
            // chkIncludeTranslation
            // 
            this.chkIncludeTranslation.AutoSize = true;
            this.chkIncludeTranslation.Location = new System.Drawing.Point(50, 65);
            this.chkIncludeTranslation.Name = "chkIncludeTranslation";
            this.chkIncludeTranslation.Size = new System.Drawing.Size(135, 20);
            this.chkIncludeTranslation.TabIndex = 2;
            this.chkIncludeTranslation.Text = "Include Translation";
            this.chkIncludeTranslation.UseVisualStyleBackColor = true;
            this.chkIncludeTranslation.CheckedChanged += new System.EventHandler(this.chkIncludeTranslation_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Wave:";
            // 
            // cboWaves
            // 
            this.cboWaves.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboWaves.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboWaves.FormattingEnabled = true;
            this.cboWaves.Location = new System.Drawing.Point(83, 22);
            this.cboWaves.Name = "cboWaves";
            this.cboWaves.Size = new System.Drawing.Size(140, 24);
            this.cboWaves.TabIndex = 0;
            this.cboWaves.SelectedIndexChanged += new System.EventHandler(this.cboWaves_SelectedIndexChanged);
            // 
            // tabSurveys
            // 
            this.tabSurveys.Controls.Add(this.cmdLast5Years);
            this.tabSurveys.Controls.Add(this.label10);
            this.tabSurveys.Controls.Add(this.label9);
            this.tabSurveys.Controls.Add(this.label8);
            this.tabSurveys.Controls.Add(this.lstSurveys);
            this.tabSurveys.Controls.Add(this.lstWaves);
            this.tabSurveys.Controls.Add(this.lstStudies);
            this.tabSurveys.Location = new System.Drawing.Point(4, 25);
            this.tabSurveys.Name = "tabSurveys";
            this.tabSurveys.Padding = new System.Windows.Forms.Padding(3);
            this.tabSurveys.Size = new System.Drawing.Size(425, 421);
            this.tabSurveys.TabIndex = 2;
            this.tabSurveys.Text = "Surveys";
            this.tabSurveys.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(184, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "Surveys:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(97, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Waves:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Studies:";
            // 
            // lstSurveys
            // 
            this.lstSurveys.FormattingEnabled = true;
            this.lstSurveys.ItemHeight = 16;
            this.lstSurveys.Location = new System.Drawing.Point(188, 51);
            this.lstSurveys.Name = "lstSurveys";
            this.lstSurveys.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstSurveys.Size = new System.Drawing.Size(119, 324);
            this.lstSurveys.TabIndex = 2;
            this.lstSurveys.Tag = "";
            this.lstSurveys.SelectedIndexChanged += new System.EventHandler(this.lstSurveys_SelectedIndexChanged);
            // 
            // lstWaves
            // 
            this.lstWaves.FormattingEnabled = true;
            this.lstWaves.ItemHeight = 16;
            this.lstWaves.Location = new System.Drawing.Point(100, 51);
            this.lstWaves.Name = "lstWaves";
            this.lstWaves.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstWaves.Size = new System.Drawing.Size(70, 324);
            this.lstWaves.TabIndex = 1;
            this.lstWaves.Tag = "";
            // 
            // lstStudies
            // 
            this.lstStudies.FormattingEnabled = true;
            this.lstStudies.ItemHeight = 16;
            this.lstStudies.Location = new System.Drawing.Point(16, 51);
            this.lstStudies.Name = "lstStudies";
            this.lstStudies.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstStudies.Size = new System.Drawing.Size(70, 324);
            this.lstStudies.TabIndex = 0;
            this.lstStudies.Tag = "";
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.chkShowFieldwork);
            this.tabOptions.Controls.Add(this.chkSeparateLabels);
            this.tabOptions.Controls.Add(this.chkRecentWaves);
            this.tabOptions.Controls.Add(this.chkShowAllSurveys);
            this.tabOptions.Controls.Add(this.chkShowGroupOn);
            this.tabOptions.Controls.Add(this.panel2);
            this.tabOptions.Controls.Add(this.lstGroupOn);
            this.tabOptions.Controls.Add(this.label11);
            this.tabOptions.Location = new System.Drawing.Point(4, 25);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(425, 421);
            this.tabOptions.TabIndex = 3;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // chkShowFieldwork
            // 
            this.chkShowFieldwork.AutoSize = true;
            this.chkShowFieldwork.Enabled = false;
            this.chkShowFieldwork.Location = new System.Drawing.Point(175, 125);
            this.chkShowFieldwork.Name = "chkShowFieldwork";
            this.chkShowFieldwork.Size = new System.Drawing.Size(153, 20);
            this.chkShowFieldwork.TabIndex = 7;
            this.chkShowFieldwork.Text = "Show Fieldwork Years";
            this.chkShowFieldwork.UseVisualStyleBackColor = true;
            // 
            // chkSeparateLabels
            // 
            this.chkSeparateLabels.AutoSize = true;
            this.chkSeparateLabels.Location = new System.Drawing.Point(175, 206);
            this.chkSeparateLabels.Name = "chkSeparateLabels";
            this.chkSeparateLabels.Size = new System.Drawing.Size(118, 20);
            this.chkSeparateLabels.TabIndex = 6;
            this.chkSeparateLabels.Text = "Separate Labels";
            this.chkSeparateLabels.UseVisualStyleBackColor = true;
            // 
            // chkRecentWaves
            // 
            this.chkRecentWaves.AutoSize = true;
            this.chkRecentWaves.Location = new System.Drawing.Point(175, 232);
            this.chkRecentWaves.Name = "chkRecentWaves";
            this.chkRecentWaves.Size = new System.Drawing.Size(114, 20);
            this.chkRecentWaves.TabIndex = 5;
            this.chkRecentWaves.Text = "Last Wave Only";
            this.chkRecentWaves.UseVisualStyleBackColor = true;
            this.chkRecentWaves.Visible = false;
            // 
            // chkShowAllSurveys
            // 
            this.chkShowAllSurveys.AutoSize = true;
            this.chkShowAllSurveys.Location = new System.Drawing.Point(175, 180);
            this.chkShowAllSurveys.Name = "chkShowAllSurveys";
            this.chkShowAllSurveys.Size = new System.Drawing.Size(125, 20);
            this.chkShowAllSurveys.TabIndex = 4;
            this.chkShowAllSurveys.Text = "Show All Surveys";
            this.chkShowAllSurveys.UseVisualStyleBackColor = true;
            // 
            // chkShowGroupOn
            // 
            this.chkShowGroupOn.AutoSize = true;
            this.chkShowGroupOn.Location = new System.Drawing.Point(175, 151);
            this.chkShowGroupOn.Name = "chkShowGroupOn";
            this.chkShowGroupOn.Size = new System.Drawing.Size(163, 20);
            this.chkShowGroupOn.TabIndex = 3;
            this.chkShowGroupOn.Text = "Show Group On Column";
            this.chkShowGroupOn.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.optDisplayProjects);
            this.panel2.Controls.Add(this.optDisplaySurveys);
            this.panel2.Location = new System.Drawing.Point(175, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(114, 69);
            this.panel2.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "Display";
            // 
            // optDisplayProjects
            // 
            this.optDisplayProjects.AutoSize = true;
            this.optDisplayProjects.Location = new System.Drawing.Point(9, 43);
            this.optDisplayProjects.Name = "optDisplayProjects";
            this.optDisplayProjects.Size = new System.Drawing.Size(71, 20);
            this.optDisplayProjects.TabIndex = 1;
            this.optDisplayProjects.TabStop = true;
            this.optDisplayProjects.Text = "Projects";
            this.optDisplayProjects.UseVisualStyleBackColor = true;
            this.optDisplayProjects.CheckedChanged += new System.EventHandler(this.DisplayMode_CheckedChanged);
            // 
            // optDisplaySurveys
            // 
            this.optDisplaySurveys.AutoSize = true;
            this.optDisplaySurveys.Checked = true;
            this.optDisplaySurveys.Location = new System.Drawing.Point(9, 17);
            this.optDisplaySurveys.Name = "optDisplaySurveys";
            this.optDisplaySurveys.Size = new System.Drawing.Size(70, 20);
            this.optDisplaySurveys.TabIndex = 0;
            this.optDisplaySurveys.TabStop = true;
            this.optDisplaySurveys.Text = "Surveys";
            this.optDisplaySurveys.UseVisualStyleBackColor = true;
            this.optDisplaySurveys.CheckedChanged += new System.EventHandler(this.DisplayMode_CheckedChanged);
            // 
            // lstGroupOn
            // 
            this.lstGroupOn.FormattingEnabled = true;
            this.lstGroupOn.ItemHeight = 16;
            this.lstGroupOn.Items.AddRange(new object[] {
            "PreP",
            "PreI",
            "PreA",
            "LitQ",
            "RespOptions",
            "NRCodes",
            "PstI",
            "PstP",
            "VarLabel",
            "Domain",
            "Topic",
            "Content",
            "Product",
            "Translation"});
            this.lstGroupOn.Location = new System.Drawing.Point(24, 67);
            this.lstGroupOn.Name = "lstGroupOn";
            this.lstGroupOn.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstGroupOn.Size = new System.Drawing.Size(125, 244);
            this.lstGroupOn.TabIndex = 1;
            this.lstGroupOn.SelectedIndexChanged += new System.EventHandler(this.lstGroupOn_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Group On";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Harmony Report";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.optWave);
            this.panel1.Controls.Add(this.optRefVarName);
            this.panel1.Location = new System.Drawing.Point(128, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 79);
            this.panel1.TabIndex = 4;
            // 
            // optWave
            // 
            this.optWave.AutoSize = true;
            this.optWave.Location = new System.Drawing.Point(17, 45);
            this.optWave.Name = "optWave";
            this.optWave.Size = new System.Drawing.Size(187, 20);
            this.optWave.TabIndex = 1;
            this.optWave.TabStop = true;
            this.optWave.Text = "By Wave (Unique Questions)";
            this.optWave.UseVisualStyleBackColor = true;
            // 
            // optRefVarName
            // 
            this.optRefVarName.AutoSize = true;
            this.optRefVarName.Location = new System.Drawing.Point(17, 16);
            this.optRefVarName.Name = "optRefVarName";
            this.optRefVarName.Size = new System.Drawing.Size(111, 20);
            this.optRefVarName.TabIndex = 0;
            this.optRefVarName.TabStop = true;
            this.optRefVarName.Text = "By refVarName";
            this.optRefVarName.UseVisualStyleBackColor = true;
            this.optRefVarName.CheckedChanged += new System.EventHandler(this.HarmonyScope_CheckedChanged);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(185, 600);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(248, 23);
            this.txtFileName.TabIndex = 5;
            // 
            // cmdOnscreen
            // 
            this.cmdOnscreen.Location = new System.Drawing.Point(185, 632);
            this.cmdOnscreen.Name = "cmdOnscreen";
            this.cmdOnscreen.Size = new System.Drawing.Size(125, 29);
            this.cmdOnscreen.TabIndex = 6;
            this.cmdOnscreen.Text = "On-Screen";
            this.cmdOnscreen.UseVisualStyleBackColor = true;
            this.cmdOnscreen.Visible = false;
            this.cmdOnscreen.Click += new System.EventHandler(this.cmdOnscreen_Click);
            // 
            // cmdWordDocument
            // 
            this.cmdWordDocument.Location = new System.Drawing.Point(310, 632);
            this.cmdWordDocument.Name = "cmdWordDocument";
            this.cmdWordDocument.Size = new System.Drawing.Size(125, 29);
            this.cmdWordDocument.TabIndex = 7;
            this.cmdWordDocument.Text = "Word Document";
            this.cmdWordDocument.UseVisualStyleBackColor = true;
            this.cmdWordDocument.Click += new System.EventHandler(this.cmdWordDocument_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 603);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "File Name:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(451, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // cmdSeparateDoc
            // 
            this.cmdSeparateDoc.Location = new System.Drawing.Point(310, 662);
            this.cmdSeparateDoc.Name = "cmdSeparateDoc";
            this.cmdSeparateDoc.Size = new System.Drawing.Size(125, 29);
            this.cmdSeparateDoc.TabIndex = 10;
            this.cmdSeparateDoc.Text = "Separate Docs";
            this.cmdSeparateDoc.UseVisualStyleBackColor = true;
            this.cmdSeparateDoc.Click += new System.EventHandler(this.cmdSeparateDoc_Click);
            // 
            // cmdLast5Years
            // 
            this.cmdLast5Years.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLast5Years.Location = new System.Drawing.Point(313, 51);
            this.cmdLast5Years.Name = "cmdLast5Years";
            this.cmdLast5Years.Size = new System.Drawing.Size(91, 26);
            this.cmdLast5Years.TabIndex = 6;
            this.cmdLast5Years.Text = "<5 Years Ago";
            this.cmdLast5Years.UseVisualStyleBackColor = true;
            this.cmdLast5Years.Click += new System.EventHandler(this.cmdLast5Years_Click);
            // 
            // HarmonyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 699);
            this.Controls.Add(this.cmdSeparateDoc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdWordDocument);
            this.Controls.Add(this.cmdOnscreen);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HarmonyReportForm";
            this.Text = "Harmony Report";
            this.Load += new System.EventHandler(this.HarmonyReportForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabVarNames.ResumeLayout(false);
            this.tabVarNames.PerformLayout();
            this.tabWaves.ResumeLayout(false);
            this.tabWaves.PerformLayout();
            this.tabSurveys.ResumeLayout(false);
            this.tabSurveys.PerformLayout();
            this.tabOptions.ResumeLayout(false);
            this.tabOptions.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabVarNames;
        private System.Windows.Forms.TabPage tabWaves;
        private System.Windows.Forms.TabPage tabSurveys;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstSelVar;
        private System.Windows.Forms.ListBox lstPrefixes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdAddVar;
        private System.Windows.Forms.Button cmdRemoveVar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboVarNames;
        private System.Windows.Forms.CheckBox chkColorTranslations;
        private System.Windows.Forms.CheckBox chkColorWordings;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboLanguage;
        private System.Windows.Forms.CheckBox chkMultipleWordingsOnly;
        private System.Windows.Forms.CheckBox chkIncludeTranslation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboWaves;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstSurveys;
        private System.Windows.Forms.ListBox lstWaves;
        private System.Windows.Forms.ListBox lstStudies;
        private System.Windows.Forms.CheckBox chkSeparateLabels;
        private System.Windows.Forms.CheckBox chkRecentWaves;
        private System.Windows.Forms.CheckBox chkShowAllSurveys;
        private System.Windows.Forms.CheckBox chkShowGroupOn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton optDisplayProjects;
        private System.Windows.Forms.RadioButton optDisplaySurveys;
        private System.Windows.Forms.ListBox lstGroupOn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton optWave;
        private System.Windows.Forms.RadioButton optRefVarName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button cmdOnscreen;
        private System.Windows.Forms.Button cmdWordDocument;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.Button cmdSeparateDoc;
        private System.Windows.Forms.CheckBox chkShowFieldwork;
        private System.Windows.Forms.Button cmdLast5Years;
    }
}