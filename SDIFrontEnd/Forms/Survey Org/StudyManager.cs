using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITCLib;
using FM = FormManager;

namespace SDIFrontEnd
{
    public partial class StudyManager : Form
    {
        List<StudyRecord> Records;
        List<Region> RegionList;
        StudyRecord CurrentRecord;

        BindingSource bs;
        BindingSource bsCurrent;

        public StudyManager()
        {
            InitializeComponent();

            SetupMouseWheel();

            FillLists();

            SetupBindingSources();

            FillBoxes();

            BindProperties();

            SetupGrids();
            
        }

        #region Events

        private void StudyManager_Load(object sender, EventArgs e)
        {
            UpdateCurrentRecord();
        }

        private void StudyManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            UpdateCurrentRecord();
        }

        private void bsCurrent_ListChanged(object sender, ListChangedEventArgs e)
        {
            // item: bs[e.NewIndex]
            // property name: e.PropertyDescriptor.Name
            if (e.PropertyDescriptor != null)
            {
                // get the paper record that was modified
                Study modifiedRegion = (Study)bsCurrent[e.NewIndex];
                StudyRecord modifiedRecord = Records.Where(x => x.Item == modifiedRegion).FirstOrDefault();

                if (modifiedRecord == null)
                    return;

                switch (e.PropertyDescriptor.Name)
                {
                    case "Waves":
                        break;
                    default:
                        modifiedRecord.Dirty = true;
                        break;
                }
                //if (CurrentRecord.Dirty)
                //lblStatus.Text = "*";
            }
        }

        private void StudyManager_MouseWheel(object sender, MouseEventArgs e)
        {
            SaveRecord();

            if (e.Delta == -120)
                MoveRecord(1);
            else if (e.Delta == 120)
            {
                MoveRecord(-1);
            }
        }

        private void toolbuttonRegions_Click(object sender, EventArgs e)
        {
            ViewRegions();
        }

        private void toolStripGoTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripGoTo.SelectedItem == null)
                return;

            SaveRecord();
            GoToStudy(((Study)toolStripGoTo.SelectedItem).ID);
        }

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ComboBox control = (ComboBox)sender;

            if (!control.DroppedDown)
                ((HandledMouseEventArgs)e).Handled = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudy();
        }

        private void listViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenListView();     
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        private void cmdAddRegion_Click(object sender, EventArgs e)
        {
            AddRegion();
        }
        #endregion

        #region Navigation Bar events
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            MoveRecord(1);
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            MoveRecord(-1);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            bs.MoveLast();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            bs.MoveFirst();
        }

        #endregion

        private void SetupMouseWheel()
        {
            this.MouseWheel += StudyManager_MouseWheel;
            cboRegion.MouseWheel += ComboBox_MouseWheel;
            cboAgeGroup.MouseWheel += ComboBox_MouseWheel;
        }

        private void FillLists()
        {
            Records = new List<StudyRecord>();

            foreach (Study study in Globals.AllStudies)
            {
                Records.Add(new StudyRecord(study));
            }

            RegionList = new List<Region>(Globals.AllRegions);
        }

        private void FillBoxes()
        {
            toolStripGoTo.ComboBox.DataSource = new List<Study>(Globals.AllStudies);
            toolStripGoTo.ComboBox.ValueMember = "ID";
            toolStripGoTo.ComboBox.DisplayMember = "StudyName";
            toolStripGoTo.ComboBox.SelectedItem = null;
            toolStripGoTo.ComboBox.SelectedIndexChanged += toolStripGoTo_SelectedIndexChanged;

            cboRegion.DataSource = new List<Region>(Globals.AllRegions);
            cboRegion.DisplayMember = "RegionName";
            cboRegion.ValueMember = "ID";

            cboAgeGroup.Items.Add("");
            cboAgeGroup.Items.Add("Adult");
            cboAgeGroup.Items.Add("Mixed");
            cboAgeGroup.Items.Add("Youth");
        }

        private void SetupBindingSources()
        {
            bs = new BindingSource();
            bs.DataSource = Records;
            bs.PositionChanged += Bs_PositionChanged;

            bsCurrent = new BindingSource();
            bsCurrent.DataSource = bs;
            bsCurrent.DataMember = "Item";
            bsCurrent.ListChanged += bsCurrent_ListChanged;

            bindingNavigator1.BindingSource = bs;
        }

        private void BindProperties()
        {
            txtID.DataBindings.Add(new Binding("Text", bsCurrent, "ID"));
            cboRegion.DataBindings.Add("SelectedValue", bsCurrent, "RegionID");
            txtStudyName.DataBindings.Add("Text", bsCurrent, "StudyName");
            txtCountry.DataBindings.Add("Text", bsCurrent, "CountryName");

            txtISOCode.DataBindings.Add("Text", bsCurrent, "ISO_Code");
            txtCC.DataBindings.Add("Text", bsCurrent, "CountryCode");
            txtCohort.DataBindings.Add("Text", bsCurrent, "Cohort");

            cboAgeGroup.DataBindings.Add("SelectedItem", bsCurrent, "AgeGroup");

            txtLanguages.DataBindings.Add("Text", bsCurrent, "Languages");
        }
        
        private void SetupGrids()
        {
            dgvWaves.AutoGenerateColumns = false;
            dgvWaves.DataSource = bsCurrent;
            dgvWaves.DataMember = "Waves";

            chWave.DataPropertyName = "WaveCode";
        }

        private void UpdateCurrentRecord()
        {
            CurrentRecord = (StudyRecord)bs.Current;
        }

        private void AddStudy()
        {
            NewStudyEntry frm = new NewStudyEntry();

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                bs.Add(frm.NewStudy);
                GoToStudy(frm.NewStudy.Item.ID);
            }           
        }

        private void AddRegion()
        {
            NewRegionEntry frm = new NewRegionEntry();

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                cboRegion.DataSource = null;
                cboRegion.DataSource = new List<Region>(Globals.AllRegions);
                cboRegion.DisplayMember = "RegionName";
                cboRegion.ValueMember = "ID";
                cboRegion.SelectedItem = frm.NewRegion;
            }
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

        /// <summary>
        /// Navigate the bindingsource to the specified study ID.
        /// </summary>
        /// <param name="studyID"></param>
        private void GoToStudy(int studyID)
        {
            for (int i = 0; i < Records.Count(); i++)
            {
                if (Records[i].Item.ID == studyID)
                {
                    bs.Position = i;
                    return;
                }
            }
        }

        private void SaveRecord()
        {
            bsCurrent.EndEdit();

            bool newRec = CurrentRecord.NewRecord;
            int updated = CurrentRecord.SaveRecord();

            if (updated == 0)
            {
                //lblStatus.Text = "";
                CurrentRecord.Dirty = false;

                if (newRec)
                    Globals.AllStudies.Add(CurrentRecord.Item);
            }
            else
            {
                MessageBox.Show("Unable to save record.");
            }
        }

        // TODO use form manager for this? new instance?
        private void ViewRegions()
        {
            RegionManager frm = new RegionManager();
            frm.Show();
        }

        private void OpenListView()
        {
            StudyList frm = new StudyList(new List<StudyRecord>(Records));
            frm.ShowDialog();
        }

        private void DeleteRecord()
        {
            MessageBox.Show("Deleting Studies is not allowed.");
        }

        

        
    }
}
