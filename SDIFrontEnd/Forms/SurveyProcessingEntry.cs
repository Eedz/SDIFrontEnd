using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITCLib;

namespace SDIFrontEnd
{
    
    public partial class SurveyProcessingEntry : Form
    {

        List<SurveyProcessingRecord> Records;
        BindingSource bs;
        BindingSource bsStages;
        BindingSource bsDates;
        BindingSource bsNotes;

        List<Person> PeopleList;
        List<SurveyRecord> SurveyList;

        Survey CurrentSurvey;
        SurveyProcessingRecord CurrentStage;
        SurveyProcessingDate CurrentDate;
        SurveyProcessingNote CurrentNote;

        private bool DirtyStage { get; set; }
        private bool DirtyDate { get; set; }
        private bool DirtyNote { get; set; }
        private bool NewDateRecord { get; set; }
        private bool NewNoteRecord { get; set; }

        public SurveyProcessingEntry()
        {
            InitializeComponent();
            this.MouseWheel += SurveyProcessingEntry_MouseWheel;

            PeopleList = new List<Person>(DBAction.GetPeople());
            SurveyList = Globals.AllSurveys;
            CurrentSurvey = new Survey();
            Records = new List<SurveyProcessingRecord>();

            cboSurvey.DisplayMember = "SurveyCode";
            cboSurvey.ValueMember = "SID";
            cboSurvey.DataSource = SurveyList;
            cboSurvey.SelectedIndexChanged += cboSurvey_SelectedIndexChanged;
            cboSurvey.MouseWheel += ComboBox_MouseWheel;

            bs = new BindingSource()
            {
                DataSource = SurveyList
            };
            bs.PositionChanged += Bs_PositionChanged;
            

            bsStages = new BindingSource();
            bsStages.DataSource = Records;
            bsStages.PositionChanged += BsStages_PositionChanged;

            bsDates = new BindingSource();
            bsDates.PositionChanged += BsDates_PositionChanged;

            bsNotes = new BindingSource();
            bsNotes.PositionChanged += BsNotes_PositionChanged;

            bindingNavigator1.BindingSource = bs;

            dataRepeater3.DataSource = bsStages;
            dataRepeater1.DataSource = bsDates;
            dataRepeater2.DataSource = bsNotes;

            chkNA.DataBindings.Add(new Binding("Checked", bsStages, "NotApplicable", true));
            chkDone.DataBindings.Add(new Binding("Checked", bsStages, "Done", true));

            txtSurvey.DataBindings.Add(new Binding("Text", bs, "SurveyCode"));
        
            dtpStageDate.DataBindings.Add(new Binding("Value", bsDates, "StageDate", true));      
            dtpEntryDate.DataBindings.Add(new Binding("Value", bsDates, "EntryDate", true));

            txtNotes.DataBindings.Add(new Binding("Text", bsNotes, "Note"));
            dtpNoteDate.DataBindings.Add(new Binding("Value", bsNotes, "NoteDate", true));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshStages();
            RefreshDates();
            RefreshNotes();
        }

        #region Menu Strip
        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveCurrent() == 1)
            {
                MessageBox.Show("Error saving record.");
                return;
            }

            SurveyProcessingReport report = new SurveyProcessingReport(CurrentSurvey, Records.Where(x => x.SurveyID.SID == CurrentSurvey.SID).ToList());
            report.CreateReport();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveCurrent() == 1)
            {
                MessageBox.Show("Error saving record.");
                return;
            }

            Close();
        }
        #endregion



        #region BindingSource events

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            RefreshStages();
            RefreshDates();
            RefreshNotes();
        }

        private void BsStages_PositionChanged(object sender, EventArgs e)
        {
            RefreshDates();
            RefreshNotes();
        }

        private void BsDates_PositionChanged(object sender, EventArgs e)
        {
            RefreshNotes();
        }

        private void BsNotes_PositionChanged(object sender, EventArgs e)
        {
            CurrentNote = (SurveyProcessingNote)bsNotes.Current;
        }
        #endregion

        #region Control Events
        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ComboBox control = (ComboBox)sender;

            if (!control.DroppedDown)
                ((HandledMouseEventArgs)e).Handled = true;
        }

        private void cboSurvey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSurvey.SelectedItem == null)
                return;

            if (SaveCurrent() == 1)
            {
                MessageBox.Show("Error saving record.");
                return;
            }

            Survey surv = (Survey)cboSurvey.SelectedItem;
            for (int i = 0; i < SurveyList.Count(); i++)
            {
                if (SurveyList[i].SID == surv.SID)
                {
                    bs.Position = i;
                    break;
                }
            }

        }

        private void chkDone_Leave(object sender, EventArgs e)
        {
            DirtyStage = true;
        }

        private void chkNA_Leave(object sender, EventArgs e)
        {
            DirtyStage = true;
        }

        private void DateControl_Validated(object sender, EventArgs e)
        {

            if (sender is DateTimePicker dtp)
            {
                if (!dtp.Checked)
                {
                    var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)dtp.Parent;
                    var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)dataRepeaterItem.Parent;
                    var datasource = (List<SurveyProcessingDate>)((BindingSource)dataRepeater.DataSource).DataSource;
                    if (dtp.Name == "dtpEntryDate")
                        datasource[dataRepeaterItem.ItemIndex].EntryDate = null;
                    else if (dtp.Name == "dtpStageDate")
                        datasource[dataRepeaterItem.ItemIndex].StageDate = null;
                }
            }
            DirtyDate = true;
        }

        private void NoteControl_Validated(object sender, EventArgs e)
        {

            if (sender is DateTimePicker dtp)
            {
                if (!dtp.Checked)
                {
                    var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)dtp.Parent;
                    var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)dataRepeaterItem.Parent;
                    var datasource = (List<SurveyProcessingNote>)((BindingSource)dataRepeater.DataSource).DataSource;
                    if (dtp.Name == "dtpNoteDate")
                        datasource[dataRepeaterItem.ItemIndex].NoteDate = null;

                }
            }
            DirtyNote = true;
        }

        private void StageControl_Validated(object sender, EventArgs e)
        {
            DirtyStage = true;
        }

        private void SurveyProcessingEntry_MouseWheel(object sender, MouseEventArgs e)
        {
            if (SaveCurrent() == 1)
            {
                MessageBox.Show("Error saving record.");
                return;
            }

            if (e.Delta == -120)
                MoveRecord(1);
            else if (e.Delta == 120)
            {
                MoveRecord(-1);
            }
        }

        private void cmdAddDate_Click(object sender, EventArgs e)
        {
            AddDate();
        }

        private void cmdAddNote_Click(object sender, EventArgs e)
        {
            AddNote();
        }
        #endregion

        #region Stages DataRepeater


        private void dataRepeater3_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)sender;
            var datasource = (List<SurveyProcessingRecord>)((BindingSource)dataRepeater.DataSource).DataSource;

            var text = (TextBox)e.DataRepeaterItem.Controls.Find("txtStageName", false)[0];
            text.Text = datasource[e.DataRepeaterItem.ItemIndex].Stage.StageName;

            var lbl = (Label)e.DataRepeaterItem.Controls.Find("lblEntries", false)[0];
            lbl.Text = datasource[e.DataRepeaterItem.ItemIndex].StageDates.Count() + " entries.";
        }

        private void dataRepeater3_ItemTemplate_Enter(object sender, EventArgs e)
        {
            var item = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)sender;
            item.BackColor = Color.AliceBlue;

        }

        private void dataRepeater3_ItemTemplate_Leave(object sender, EventArgs e)
        {

            if (SaveCurrent() == 1)
            {
                MessageBox.Show("Error saving stage.");
                return;
            }

            var item = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)sender;
            item.BackColor = SystemColors.GradientInactiveCaption;


        }


        private void chkNA_Click(object sender, EventArgs e)
        {
            var chk = (CheckBox)sender;
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)chk.Parent;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)chk.Parent.Parent;

            var source = (List<SurveyProcessingRecord>)((BindingSource)dataRepeater.DataSource).DataSource;
            source[dataRepeaterItem.ItemIndex].NotApplicable = chk.Checked;
        }

        private void chkDone_Click(object sender, EventArgs e)
        {
            var chk = (CheckBox)sender;
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)chk.Parent;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)chk.Parent.Parent;

            var source = (List<SurveyProcessingRecord>)((BindingSource)dataRepeater.DataSource).DataSource;
            source[dataRepeaterItem.ItemIndex].Done = chk.Checked;
        }


        #endregion

        #region Dates DataRepeater

        /// <summary>
        /// Each time an item is cloned, the new item needs to have its controls populated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataRepeater1_ItemCloned(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var combo = (ComboBox)e.DataRepeaterItem.Controls.Find("cboEnteredBy", false)[0];
            //Set the data source
            combo.DisplayMember = "Name";
            combo.ValueMember = "ID";
            combo.DataSource = new List<Person>(PeopleList);

            var combo2 = (ComboBox)e.DataRepeaterItem.Controls.Find("cboContact", false)[0];
            //Set the data source
            combo2.DisplayMember = "Name";
            combo2.ValueMember = "ID";
            combo2.DataSource = new List<Person>(PeopleList);
        }

        /// <summary>
        /// After Item is cloned, draw item. The index is now available to select the proper data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataRepeater1_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)sender;
            var datasource = (List<SurveyProcessingDate>)((BindingSource)dataRepeater.DataSource).DataSource;

            var combo = (ComboBox)e.DataRepeaterItem.Controls.Find("cboEnteredBy", false)[0];
            //Set the selected item based of the list item index
            combo.SelectedItem = datasource[e.DataRepeaterItem.ItemIndex].EnteredBy;

            var combo2 = (ComboBox)e.DataRepeaterItem.Controls.Find("cboContact", false)[0];
            //Set the selected item based of the list item index
            combo2.SelectedItem = datasource[e.DataRepeaterItem.ItemIndex].Contact;


        }

        /// <summary>
        /// Set the underlying data source's property when an item is chosen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboEnteredBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)combo.Parent;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)combo.Parent.Parent;

            var source = (List<SurveyProcessingDate>)((BindingSource)dataRepeater.DataSource).DataSource;
            source[dataRepeaterItem.ItemIndex].EnteredBy = (Person)combo.SelectedItem;

        }

        /// <summary>
        /// Set the underlying data source's property when an item is chosen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)combo.Parent;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)combo.Parent.Parent;

            var source = (List<SurveyProcessingDate>)((BindingSource)dataRepeater.DataSource).DataSource;
            source[dataRepeaterItem.ItemIndex].Contact = (Person)combo.SelectedItem;

        }

        private void cmdDeleteDate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var button = (Button)sender;
                var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)button.Parent;
                var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)dataRepeaterItem.Parent;
                var datasource = (List<SurveyProcessingDate>)((BindingSource)dataRepeater.DataSource).DataSource;
                SurveyProcessingDate item = datasource[dataRepeaterItem.ItemIndex];
                if (DBAction.DeleteRecord(item) != 1)
                    dataRepeater.RemoveAt(dataRepeaterItem.ItemIndex);
                else
                    MessageBox.Show("Error deleting this date.");
            }
            else
            {

            }
        }

        #endregion


        #region Notes DataRepeater
        private void dataRepeater2_ItemCloned(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var combo = (ComboBox)e.DataRepeaterItem.Controls.Find("cboNoteAuthor", false)[0];
            //Set the data source
            combo.DisplayMember = "Name";
            combo.ValueMember = "ID";
            combo.DataSource = new List<Person>(PeopleList);
        }

        private void dataRepeater2_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)sender;
            var datasource = (List<SurveyProcessingNote>)((BindingSource)dataRepeater.DataSource).DataSource;

            var combo = (ComboBox)e.DataRepeaterItem.Controls.Find("cboNoteAuthor", false)[0];
            combo.SelectedItem = datasource[e.DataRepeaterItem.ItemIndex].Author;
        }


        private void cboNoteAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)combo.Parent;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)combo.Parent.Parent;

            var source = (List<SurveyProcessingNote>)((BindingSource)dataRepeater.DataSource).DataSource;
            source[dataRepeaterItem.ItemIndex].Author = (Person)combo.SelectedItem;
        }

        private void cmdDeleteNote_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var button = (Button)sender;
                var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)button.Parent;
                var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)dataRepeaterItem.Parent;
                var datasource = (List<SurveyProcessingNote>)((BindingSource)dataRepeater.DataSource).DataSource;
                SurveyProcessingNote item = datasource[dataRepeaterItem.ItemIndex];
                if (DBAction.DeleteRecord(item) != 1)
                    dataRepeater.RemoveAt(dataRepeaterItem.ItemIndex);
                else
                    MessageBox.Show("Error deleting this note.");
            }
            else
            {

            }
        }




        #endregion

        #region Navigator
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (SaveCurrent() == 1)
                return;

            MoveRecord(1);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (SaveCurrent() == 1)
                return;

            bs.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (SaveCurrent() == 1)
                return;

            MoveRecord(-1);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (SaveCurrent() == 1)
                return;

            bs.MoveFirst();
        }

        #endregion

        private void RefreshStages()
        {
            CurrentSurvey = (Survey)bs.Current;
            // check Records for objects matching the current survey
            // if none, get from DB, if none, show nothing
            if (!Records.Any(x => x.SurveyID.SID == CurrentSurvey.SID))
                Records.AddRange(DBAction.GetSurveyProcessingRecords(CurrentSurvey.SID));

            

            List<SurveyProcessingRecord> stages = Records.Where(x => x.SurveyID.SID == CurrentSurvey.SID).ToList();
            bsStages.DataSource = stages;
        }

        private void RefreshDates()
        {
            CurrentStage = (SurveyProcessingRecord)bsStages.Current;
            if (CurrentStage != null)
            {
                bsDates.DataSource = CurrentStage.StageDates;
                lblStageNameDates.Text = CurrentStage.Stage.StageName + " Dates";
            }
        }

        private void RefreshNotes()
        {
            CurrentDate = (SurveyProcessingDate)bsDates.Current;
            if (CurrentDate != null)
            {
                string date = CurrentDate.StageDate == null ? "(No Date)" : "(" + CurrentDate.StageDate.Value.ToString("d") + ")";
                lblNotes.Text =CurrentStage.Stage.StageName + " " + date +  " Notes";
                bsNotes.DataSource = CurrentDate.Notes;

            }
            else
                bsNotes.DataSource = null;
                
        }

        private void AddDate()
        {
            dataRepeater1.AddNew();
            ((DateTimePicker)dataRepeater1.CurrentItem.Controls["dtpEntryDate"]).Value = DateTime.Today;


            NewDateRecord = true;
        }

        private void AddNote()
        {
            dataRepeater2.AddNew();
            ((DateTimePicker)dataRepeater2.CurrentItem.Controls["dtpNoteDate"]).Value = DateTime.Today;


            NewNoteRecord = true;
        }

        private int SaveStageRecord()
        {
            if (DirtyStage)
            {
                if (DBAction.UpdateSurveyProcessingStage(CurrentStage) == 1)
                    return 1;

                DirtyStage = false;
            }

            return 0;
        }

        private int SaveDateRecords()
        {
            if (!DirtyDate && !NewDateRecord)
                return 0;

            foreach (SurveyProcessingDate spd in CurrentStage.StageDates)
            {
                if (spd.ID > 0)
                {
                    if (DBAction.UpdateSurveyProcessingDate(spd) == 1)
                        return 1;
                }
                else
                {
                    spd.StageID = CurrentStage.ID;
                    if (DBAction.InsertSurveyProcessingDate(spd) == 1)
                        return 1;
                }
            }

            NewNoteRecord = false;
            DirtyDate = false;

            return 0;
        }

        private int SaveNoteRecords()
        {
            if (!DirtyNote && !NewNoteRecord)
                return 0;

            foreach (SurveyProcessingDate spd in CurrentStage.StageDates)
                foreach (SurveyProcessingNote spn in spd.Notes)
                {
                    if (spn.ID > 0)
                    {
                        if (DBAction.UpdateSurveyProcessingNote(spn) == 1)
                            return 1;
                    }
                    else
                    {
                        spn.DateID = spd.ID;
                        if (DBAction.InsertSurveyProcessingNote(spn) == 1)
                            return 1;
                    }
                }
        
            NewNoteRecord = false;
            DirtyNote = false;

            return 0;
        }

        private int SaveDateRecord()
        {

            if (NewDateRecord)
            {

                if (DBAction.InsertSurveyProcessingDate(CurrentDate) == 1)
                    return 1;

                NewDateRecord = false;
                DirtyDate = false;
                
            }
            else if (DirtyDate)
            {

                if (DBAction.UpdateSurveyProcessingDate(CurrentDate) == 1)
                    return 1;

                DirtyDate = false;
            }

            return 0;
        }

        private int SaveNoteRecord()
        {

            if (NewNoteRecord)
            {

                if (DBAction.InsertSurveyProcessingNote(CurrentNote) == 1)
                    return 1;

                NewNoteRecord = false;
                DirtyNote = false;

            }
            else if (DirtyNote)
            {

                if (DBAction.UpdateSurveyProcessingNote(CurrentNote) == 1)
                    return 1;

                DirtyNote = false;
            }

            return 0;
        }

        private void MoveRecord(int count)
        {

            if (count > 0)
                for (int i = 0; i < count; i++)
                {
                    bs.MoveNext();
                }
            else
                for (int i = 0; i < Math.Abs(count); i++)
                {
                    bs.MovePrevious();
                }


        }

        private int SaveCurrent()
        {
            StringBuilder errors = new StringBuilder();
            if (SaveStageRecord() == 1)
                errors.AppendLine("Error saving stage information.");

            if (SaveDateRecords() == 1)
                errors.AppendLine("Error saving date information.");

            if (SaveNoteRecords() == 1)
                errors.AppendLine("Error saving note information");

            if (errors.Length > 0) {
                MessageBox.Show(errors.ToString());
                return 1;
            }

            return 0;
        }

        

        private void SurveyProcessingEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SaveCurrent() == 1)
            {
                MessageBox.Show("Error saving record.");
                return;
            }
        }

        private void SurveyProcessingEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.Remove(this);
        }
    }
}
