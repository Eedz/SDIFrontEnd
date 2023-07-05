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
using FM = FormManager;

namespace SDIFrontEnd
{
    public partial class WaveManager : Form
    {
        StudyWaveRecord CurrentRecord;
        List<StudyWaveRecord> Records;
        List<Study> StudyList;

        BindingSource bs;
        BindingSource bsCurrent;

        public WaveManager()
        {
            InitializeComponent();

            SetupMouseWheel();

            FillLists();

            SetupBindingSources();
            
            FillBoxes();

            BindProperties();

            SetupGrid();
        }

        public WaveManager(int waveid) : base()
        {
            GoToWave(waveid);
        }

        #region Events

        private void WaveManager_Load(object sender, EventArgs e)
        {
            UpdateCurrentRecord();
        }

        private void WaveManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            UpdateCurrentRecord();
        }

        private void Bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            // item: bs[e.NewIndex]
            // property name: e.PropertyDescriptor.Name
            if (e.PropertyDescriptor != null)
            {
                // get the paper record that was modified
                StudyWave modifiedRegion = (StudyWave)bsCurrent[e.NewIndex];
                StudyWaveRecord modifiedRecord = Records.Where(x => x.Item == modifiedRegion).FirstOrDefault();

                if (modifiedRecord == null)
                    return;

                switch (e.PropertyDescriptor.Name)
                {
                    case "Surveys":
                    case "FieldworkDates":
                        break;
                    default:
                        modifiedRecord.Dirty = true;
                        break;
                }
                //if (CurrentRecord.Dirty)
                //lblStatus.Text = "*";
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddWave();
        }

        private void toolbuttonStudies_Click(object sender, EventArgs e)
        {
            ViewStudies();
        }

        private void toolStripGoTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripGoTo.SelectedItem == null)
                return;

            SaveRecord();
            GoToWave(((StudyWave)toolStripGoTo.SelectedItem).ID);
        }

        private void listViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenListView();
        }

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ComboBox control = (ComboBox)sender;

            if (!control.DroppedDown)
                ((HandledMouseEventArgs)e).Handled = true;
        }

        private void WaveManager_MouseWheel(object sender, MouseEventArgs e)
        {
            SaveRecord();

            if (e.Delta == -120)
                MoveRecord(1);
            else if (e.Delta == 120)
            {
                MoveRecord(-1);
            }
        }

        private void cmdAddStudy_Click(object sender, EventArgs e)
        {
            AddStudy();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
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
            this.MouseWheel += WaveManager_MouseWheel;
            cboProject.MouseWheel += ComboBox_MouseWheel;
        }

        private void FillLists()
        {
            Records = new List<StudyWaveRecord>();
            foreach (StudyWave wave in Globals.AllWaves)
            {
                Records.Add(new StudyWaveRecord(wave));
            }

            StudyList = new List<Study>(Globals.AllStudies);
        }

        private void SetupBindingSources()
        {
            bs = new BindingSource();
            bs.DataSource = Records;
            bs.PositionChanged += Bs_PositionChanged;

            bsCurrent = new BindingSource();
            bsCurrent.DataSource = bs;
            bsCurrent.DataMember = "Item";

            bindingNavigator1.BindingSource = bs;
        }

        private void FillBoxes()
        {
            toolStripGoTo.ComboBox.DataSource = new List<StudyWave>(Globals.AllWaves);
            toolStripGoTo.ComboBox.ValueMember = "ID";
            toolStripGoTo.ComboBox.DisplayMember = "WaveCode";
            toolStripGoTo.ComboBox.SelectedItem = null;
            toolStripGoTo.ComboBox.SelectedIndexChanged += toolStripGoTo_SelectedIndexChanged;

            cboProject.DisplayMember = "StudyName";
            cboProject.ValueMember = "ID";
            cboProject.DataSource = StudyList;
        }

        private void BindProperties()
        {
            txtID.DataBindings.Add(new Binding("Text", bsCurrent, "ID"));
            txtWaveNumber.DataBindings.Add(new Binding("Text", bsCurrent, "Wave"));
            chkEnglishRouting.DataBindings.Add(new Binding("Checked", bsCurrent, "EnglishRouting"));
            txtCountries.DataBindings.Add(new Binding("Text", bsCurrent, "Countries"));
            txtWaveCode.DataBindings.Add(new Binding("Text", bsCurrent, "WaveCode"));
            cboProject.DataBindings.Add(new Binding("SelectedValue", bsCurrent, "StudyID"));
        }

        private void SetupGrid()
        {
            dgvSurveys.AutoGenerateColumns = false;
            dgvSurveys.DataSource = bsCurrent;
            dgvSurveys.DataMember = "Surveys";

            chSurveyCode.DataPropertyName = "SurveyCode";

            dgvFieldwork.AutoGenerateColumns = false;
            dgvFieldwork.DataSource = bsCurrent;
            dgvFieldwork.DataMember = "FieldworkDates";

            chCountry.DataPropertyName = "CountryName";
            chFWStart.DataPropertyName = "Start";
            chFWEnd.DataPropertyName = "End";
        }

        private void UpdateCurrentRecord()
        {
            CurrentRecord = (StudyWaveRecord)bs.Current;
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
                    Globals.AllWaves.Add(CurrentRecord.Item);
            }
        }

        private void GoToWave(int waveid)
        {
            for (int i = 0; i < Records.Count(); i++)
            {
                if (Records[i].Item.ID == waveid)
                {
                    bs.Position = i;
                    return;
                }
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

        private void AddWave()
        {
            NewWaveEntry frm = new NewWaveEntry();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                bs.Add(frm.NewWave);
                GoToWave(frm.NewWave.Item.ID);
            }
        }

        private void AddStudy()
        {
            NewStudyEntry frm = new NewStudyEntry();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                StudyList.Add(frm.NewStudy.Item);
                cboProject.DataSource = null;
                cboProject.DataSource = StudyList;
                cboProject.SelectedItem = frm.NewStudy;
            }
        }

        // TODO use form manager, new instance?
        private void ViewStudies()
        {
            StudyManager frm = new StudyManager();
            frm.Show();
        }

        private void OpenListView()
        {
            WaveList frm = new WaveList(new List<StudyWaveRecord>(Records));
            frm.ShowDialog();
        }

        private void DeleteRecord()
        {
            if (CurrentRecord.Item.Surveys.Count > 1)
            {
                MessageBox.Show("This wave has 1 or more surveys. Unable to delete. If you really want to delete this wave, contact the ITC Programmer.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this wave?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DBAction.DeleteRecord(CurrentRecord);
                Records.Remove(CurrentRecord);
                toolStripGoTo.ComboBox.DataSource = new List<StudyWaveRecord>(Records);
                bs.RemoveCurrent();
                UpdateCurrentRecord();
            }
        }
        
    }
}
