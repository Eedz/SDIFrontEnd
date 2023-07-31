namespace SDIFrontEnd
{
    partial class SurveyProcessingEntry
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SurveyProcessingEntry));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboSurvey = new System.Windows.Forms.ComboBox();
            this.txtSurvey = new System.Windows.Forms.TextBox();
            this.dataRepeater1 = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.cmdDeleteDate = new System.Windows.Forms.Button();
            this.cboContact = new System.Windows.Forms.ComboBox();
            this.cboEnteredBy = new System.Windows.Forms.ComboBox();
            this.dtpEntryDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStageDate = new System.Windows.Forms.DateTimePicker();
            this.dataRepeater2 = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.cmdDeleteNote = new System.Windows.Forms.Button();
            this.cboNoteAuthor = new System.Windows.Forms.ComboBox();
            this.dtpNoteDate = new System.Windows.Forms.DateTimePicker();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.dataRepeater3 = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.lblEntries = new System.Windows.Forms.Label();
            this.chkDone = new System.Windows.Forms.CheckBox();
            this.chkNA = new System.Windows.Forms.CheckBox();
            this.txtStageName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStageNameDates = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.cmdAddDate = new System.Windows.Forms.Button();
            this.cmdAddNote = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.dataRepeater1.ItemTemplate.SuspendLayout();
            this.dataRepeater1.SuspendLayout();
            this.dataRepeater2.ItemTemplate.SuspendLayout();
            this.dataRepeater2.SuspendLayout();
            this.dataRepeater3.ItemTemplate.SuspendLayout();
            this.dataRepeater3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1126, 24);
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
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.reportToolStripMenuItem.Text = "Report...";
            this.reportToolStripMenuItem.Click += new System.EventHandler(this.reportToolStripMenuItem_Click);
            // 
            // cboSurvey
            // 
            this.cboSurvey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboSurvey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSurvey.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSurvey.FormattingEnabled = true;
            this.cboSurvey.Location = new System.Drawing.Point(498, 94);
            this.cboSurvey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboSurvey.Name = "cboSurvey";
            this.cboSurvey.Size = new System.Drawing.Size(140, 24);
            this.cboSurvey.TabIndex = 1;
            // 
            // txtSurvey
            // 
            this.txtSurvey.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSurvey.Location = new System.Drawing.Point(121, 144);
            this.txtSurvey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSurvey.Name = "txtSurvey";
            this.txtSurvey.Size = new System.Drawing.Size(116, 23);
            this.txtSurvey.TabIndex = 2;
            // 
            // dataRepeater1
            // 
            this.dataRepeater1.AllowUserToDeleteItems = false;
            // 
            // dataRepeater1.ItemTemplate
            // 
            this.dataRepeater1.ItemTemplate.Controls.Add(this.cmdDeleteDate);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.cboContact);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.cboEnteredBy);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.dtpEntryDate);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.dtpStageDate);
            this.dataRepeater1.ItemTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataRepeater1.ItemTemplate.Size = new System.Drawing.Size(584, 36);
            this.dataRepeater1.Location = new System.Drawing.Point(4, 4);
            this.dataRepeater1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataRepeater1.Name = "dataRepeater1";
            this.dataRepeater1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataRepeater1.Size = new System.Drawing.Size(594, 224);
            this.dataRepeater1.TabIndex = 4;
            this.dataRepeater1.Text = "dataRepeater1";
            this.dataRepeater1.ItemCloned += new Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventHandler(this.dataRepeater1_ItemCloned);
            this.dataRepeater1.DrawItem += new Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventHandler(this.dataRepeater1_DrawItem);
            // 
            // cmdDeleteDate
            // 
            this.cmdDeleteDate.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDeleteDate.ForeColor = System.Drawing.Color.Red;
            this.cmdDeleteDate.Location = new System.Drawing.Point(511, 4);
            this.cmdDeleteDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdDeleteDate.Name = "cmdDeleteDate";
            this.cmdDeleteDate.Size = new System.Drawing.Size(34, 28);
            this.cmdDeleteDate.TabIndex = 4;
            this.cmdDeleteDate.Text = "X";
            this.cmdDeleteDate.UseCompatibleTextRendering = true;
            this.cmdDeleteDate.UseVisualStyleBackColor = true;
            this.cmdDeleteDate.Click += new System.EventHandler(this.cmdDeleteDate_Click);
            // 
            // cboContact
            // 
            this.cboContact.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboContact.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboContact.FormattingEnabled = true;
            this.cboContact.Location = new System.Drawing.Point(394, 4);
            this.cboContact.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboContact.Name = "cboContact";
            this.cboContact.Size = new System.Drawing.Size(110, 24);
            this.cboContact.TabIndex = 3;
            this.cboContact.SelectedIndexChanged += new System.EventHandler(this.cboContact_SelectedIndexChanged);
            this.cboContact.Validated += new System.EventHandler(this.DateControl_Validated);
            // 
            // cboEnteredBy
            // 
            this.cboEnteredBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboEnteredBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEnteredBy.FormattingEnabled = true;
            this.cboEnteredBy.Location = new System.Drawing.Point(265, 4);
            this.cboEnteredBy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboEnteredBy.Name = "cboEnteredBy";
            this.cboEnteredBy.Size = new System.Drawing.Size(124, 24);
            this.cboEnteredBy.TabIndex = 2;
            this.cboEnteredBy.SelectedIndexChanged += new System.EventHandler(this.cboEnteredBy_SelectedIndexChanged);
            this.cboEnteredBy.Validated += new System.EventHandler(this.DateControl_Validated);
            // 
            // dtpEntryDate
            // 
            this.dtpEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntryDate.Location = new System.Drawing.Point(139, 4);
            this.dtpEntryDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpEntryDate.Name = "dtpEntryDate";
            this.dtpEntryDate.ShowCheckBox = true;
            this.dtpEntryDate.Size = new System.Drawing.Size(118, 23);
            this.dtpEntryDate.TabIndex = 1;
            this.dtpEntryDate.Validated += new System.EventHandler(this.DateControl_Validated);
            // 
            // dtpStageDate
            // 
            this.dtpStageDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStageDate.Location = new System.Drawing.Point(13, 4);
            this.dtpStageDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpStageDate.Name = "dtpStageDate";
            this.dtpStageDate.ShowCheckBox = true;
            this.dtpStageDate.Size = new System.Drawing.Size(118, 23);
            this.dtpStageDate.TabIndex = 0;
            this.dtpStageDate.Validated += new System.EventHandler(this.DateControl_Validated);
            // 
            // dataRepeater2
            // 
            // 
            // dataRepeater2.ItemTemplate
            // 
            this.dataRepeater2.ItemTemplate.Controls.Add(this.cmdDeleteNote);
            this.dataRepeater2.ItemTemplate.Controls.Add(this.cboNoteAuthor);
            this.dataRepeater2.ItemTemplate.Controls.Add(this.dtpNoteDate);
            this.dataRepeater2.ItemTemplate.Controls.Add(this.txtNotes);
            this.dataRepeater2.ItemTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataRepeater2.ItemTemplate.Size = new System.Drawing.Size(584, 76);
            this.dataRepeater2.Location = new System.Drawing.Point(4, 4);
            this.dataRepeater2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataRepeater2.Name = "dataRepeater2";
            this.dataRepeater2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataRepeater2.Size = new System.Drawing.Size(594, 251);
            this.dataRepeater2.TabIndex = 5;
            this.dataRepeater2.Text = "dataRepeater2";
            this.dataRepeater2.ItemCloned += new Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventHandler(this.dataRepeater2_ItemCloned);
            this.dataRepeater2.DrawItem += new Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventHandler(this.dataRepeater2_DrawItem);
            // 
            // cmdDeleteNote
            // 
            this.cmdDeleteNote.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDeleteNote.ForeColor = System.Drawing.Color.Red;
            this.cmdDeleteNote.Location = new System.Drawing.Point(509, 7);
            this.cmdDeleteNote.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdDeleteNote.Name = "cmdDeleteNote";
            this.cmdDeleteNote.Size = new System.Drawing.Size(34, 28);
            this.cmdDeleteNote.TabIndex = 3;
            this.cmdDeleteNote.Text = "X";
            this.cmdDeleteNote.UseCompatibleTextRendering = true;
            this.cmdDeleteNote.UseVisualStyleBackColor = true;
            this.cmdDeleteNote.Click += new System.EventHandler(this.cmdDeleteNote_Click);
            // 
            // cboNoteAuthor
            // 
            this.cboNoteAuthor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboNoteAuthor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboNoteAuthor.FormattingEnabled = true;
            this.cboNoteAuthor.Location = new System.Drawing.Point(364, 39);
            this.cboNoteAuthor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboNoteAuthor.Name = "cboNoteAuthor";
            this.cboNoteAuthor.Size = new System.Drawing.Size(140, 24);
            this.cboNoteAuthor.TabIndex = 2;
            this.cboNoteAuthor.SelectedIndexChanged += new System.EventHandler(this.cboNoteAuthor_SelectedIndexChanged);
            this.cboNoteAuthor.Validated += new System.EventHandler(this.NoteControl_Validated);
            // 
            // dtpNoteDate
            // 
            this.dtpNoteDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNoteDate.Location = new System.Drawing.Point(364, 7);
            this.dtpNoteDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpNoteDate.Name = "dtpNoteDate";
            this.dtpNoteDate.Size = new System.Drawing.Size(140, 23);
            this.dtpNoteDate.TabIndex = 1;
            this.dtpNoteDate.Validated += new System.EventHandler(this.NoteControl_Validated);
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(13, 7);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(344, 57);
            this.txtNotes.TabIndex = 0;
            this.txtNotes.Validated += new System.EventHandler(this.NoteControl_Validated);
            // 
            // dataRepeater3
            // 
            this.dataRepeater3.AllowUserToAddItems = false;
            this.dataRepeater3.AllowUserToDeleteItems = false;
            // 
            // dataRepeater3.ItemTemplate
            // 
            this.dataRepeater3.ItemTemplate.Controls.Add(this.lblEntries);
            this.dataRepeater3.ItemTemplate.Controls.Add(this.chkDone);
            this.dataRepeater3.ItemTemplate.Controls.Add(this.chkNA);
            this.dataRepeater3.ItemTemplate.Controls.Add(this.txtStageName);
            this.dataRepeater3.ItemTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataRepeater3.ItemTemplate.Size = new System.Drawing.Size(442, 37);
            this.dataRepeater3.ItemTemplate.Enter += new System.EventHandler(this.dataRepeater3_ItemTemplate_Enter);
            this.dataRepeater3.ItemTemplate.Leave += new System.EventHandler(this.dataRepeater3_ItemTemplate_Leave);
            this.dataRepeater3.Location = new System.Drawing.Point(14, 198);
            this.dataRepeater3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataRepeater3.Name = "dataRepeater3";
            this.dataRepeater3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataRepeater3.Size = new System.Drawing.Size(452, 577);
            this.dataRepeater3.TabIndex = 6;
            this.dataRepeater3.Text = "dataRepeater3";
            this.dataRepeater3.DrawItem += new Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventHandler(this.dataRepeater3_DrawItem);
            // 
            // lblEntries
            // 
            this.lblEntries.AutoSize = true;
            this.lblEntries.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntries.Location = new System.Drawing.Point(326, 5);
            this.lblEntries.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEntries.Name = "lblEntries";
            this.lblEntries.Size = new System.Drawing.Size(46, 16);
            this.lblEntries.TabIndex = 3;
            this.lblEntries.Text = "Entries";
            // 
            // chkDone
            // 
            this.chkDone.AutoSize = true;
            this.chkDone.Location = new System.Drawing.Point(306, 7);
            this.chkDone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDone.Name = "chkDone";
            this.chkDone.Size = new System.Drawing.Size(15, 14);
            this.chkDone.TabIndex = 2;
            this.chkDone.UseVisualStyleBackColor = true;
            this.chkDone.Click += new System.EventHandler(this.chkDone_Click);
            this.chkDone.Leave += new System.EventHandler(this.chkDone_Leave);
            this.chkDone.Validated += new System.EventHandler(this.StageControl_Validated);
            // 
            // chkNA
            // 
            this.chkNA.AutoSize = true;
            this.chkNA.Location = new System.Drawing.Point(255, 7);
            this.chkNA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkNA.Name = "chkNA";
            this.chkNA.Size = new System.Drawing.Size(15, 14);
            this.chkNA.TabIndex = 1;
            this.chkNA.UseVisualStyleBackColor = true;
            this.chkNA.Click += new System.EventHandler(this.chkNA_Click);
            this.chkNA.Leave += new System.EventHandler(this.chkNA_Leave);
            this.chkNA.Validated += new System.EventHandler(this.StageControl_Validated);
            // 
            // txtStageName
            // 
            this.txtStageName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStageName.Location = new System.Drawing.Point(4, 1);
            this.txtStageName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStageName.Name = "txtStageName";
            this.txtStageName.ReadOnly = true;
            this.txtStageName.Size = new System.Drawing.Size(244, 23);
            this.txtStageName.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataRepeater1);
            this.panel1.Location = new System.Drawing.Point(474, 250);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 231);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataRepeater2);
            this.panel2.Location = new System.Drawing.Point(474, 521);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(607, 258);
            this.panel2.TabIndex = 8;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 813);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1126, 25);
            this.bindingNavigator1.TabIndex = 9;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(58, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(150, 176);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Stage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(281, 176);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(328, 176);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Done";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(392, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Go To Survey";
            // 
            // lblStageNameDates
            // 
            this.lblStageNameDates.AutoSize = true;
            this.lblStageNameDates.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStageNameDates.Location = new System.Drawing.Point(477, 197);
            this.lblStageNameDates.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStageNameDates.Name = "lblStageNameDates";
            this.lblStageNameDates.Size = new System.Drawing.Size(126, 16);
            this.lblStageNameDates.TabIndex = 14;
            this.lblStageNameDates.Text = "Stage Name Dates";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(477, 491);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(44, 16);
            this.lblNotes.TabIndex = 15;
            this.lblNotes.Text = "Notes";
            // 
            // cmdAddDate
            // 
            this.cmdAddDate.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddDate.ForeColor = System.Drawing.Color.Green;
            this.cmdAddDate.Location = new System.Drawing.Point(1010, 218);
            this.cmdAddDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdAddDate.Name = "cmdAddDate";
            this.cmdAddDate.Size = new System.Drawing.Size(34, 28);
            this.cmdAddDate.TabIndex = 16;
            this.cmdAddDate.Text = "+";
            this.cmdAddDate.UseCompatibleTextRendering = true;
            this.cmdAddDate.UseVisualStyleBackColor = true;
            this.cmdAddDate.Click += new System.EventHandler(this.cmdAddDate_Click);
            // 
            // cmdAddNote
            // 
            this.cmdAddNote.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddNote.ForeColor = System.Drawing.Color.Green;
            this.cmdAddNote.Location = new System.Drawing.Point(1008, 487);
            this.cmdAddNote.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdAddNote.Name = "cmdAddNote";
            this.cmdAddNote.Size = new System.Drawing.Size(34, 28);
            this.cmdAddNote.TabIndex = 17;
            this.cmdAddNote.Text = "+";
            this.cmdAddNote.UseCompatibleTextRendering = true;
            this.cmdAddNote.UseVisualStyleBackColor = true;
            this.cmdAddNote.Click += new System.EventHandler(this.cmdAddNote_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(388, 49);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(229, 33);
            this.lblTitle.TabIndex = 18;
            this.lblTitle.Text = "Survey Processing";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(530, 226);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Stage Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(657, 226);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Entry Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(790, 226);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "Entered By";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(920, 226);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Contact";
            // 
            // SurveyProcessingEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1126, 838);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmdAddNote);
            this.Controls.Add(this.cmdAddDate);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblStageNameDates);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataRepeater3);
            this.Controls.Add(this.txtSurvey);
            this.Controls.Add(this.cboSurvey);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SurveyProcessingEntry";
            this.Text = "Survey Processing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SurveyProcessingEntry_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SurveyProcessingEntry_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.dataRepeater1.ItemTemplate.ResumeLayout(false);
            this.dataRepeater1.ResumeLayout(false);
            this.dataRepeater2.ItemTemplate.ResumeLayout(false);
            this.dataRepeater2.ItemTemplate.PerformLayout();
            this.dataRepeater2.ResumeLayout(false);
            this.dataRepeater3.ItemTemplate.ResumeLayout(false);
            this.dataRepeater3.ItemTemplate.PerformLayout();
            this.dataRepeater3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboSurvey;
        private System.Windows.Forms.TextBox txtSurvey;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater1;
        private System.Windows.Forms.ComboBox cboContact;
        private System.Windows.Forms.ComboBox cboEnteredBy;
        private System.Windows.Forms.DateTimePicker dtpEntryDate;
        private System.Windows.Forms.DateTimePicker dtpStageDate;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater2;
        private System.Windows.Forms.ComboBox cboNoteAuthor;
        private System.Windows.Forms.DateTimePicker dtpNoteDate;
        private System.Windows.Forms.TextBox txtNotes;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater3;
        private System.Windows.Forms.Label lblEntries;
        private System.Windows.Forms.CheckBox chkDone;
        private System.Windows.Forms.CheckBox chkNA;
        private System.Windows.Forms.TextBox txtStageName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStageNameDates;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Button cmdDeleteDate;
        private System.Windows.Forms.Button cmdDeleteNote;
        private System.Windows.Forms.Button cmdAddDate;
        private System.Windows.Forms.Button cmdAddNote;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

