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
        BindingList<StudyWaveRecord> WaveList;
        List<StudyRecord> StudyList;
        BindingSource bs;

        public WaveManager()
        {
            InitializeComponent();

            this.MouseWheel += WaveManager_MouseWheel;
            cboProject.MouseWheel += ComboBox_MouseWheel;

            WaveList = new BindingList<StudyWaveRecord>(Globals.AllWaves);
            StudyList = new List<StudyRecord>(Globals.AllStudies);

            bs = new BindingSource();
            bs.DataSource = WaveList;
            bs.PositionChanged += Bs_PositionChanged;
            bindingNavigator1.BindingSource = bs;

            FillBoxes();

            BindProperties();

            SetupGrid();

            RefreshCurrentWave();
        }

        

        public WaveManager(int waveid)
        {
            InitializeComponent();

            this.MouseWheel += WaveManager_MouseWheel;
            cboProject.MouseWheel += ComboBox_MouseWheel;

            WaveList = new BindingList<StudyWaveRecord>(Globals.AllWaves);
            StudyList = new List<StudyRecord>(Globals.AllStudies);

            bs = new BindingSource();
            bs.DataSource = WaveList;
            bs.PositionChanged += Bs_PositionChanged;
            bs.ListChanged += Bs_ListChanged;
            bindingNavigator1.BindingSource = bs;

            FillBoxes();

            BindProperties();

            SetupGrid();

            GoToWave(waveid);

            RefreshCurrentWave();
        }

       

        #region Events

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FM.FormManager.Remove(this);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

            NewWaveEntry frm = new NewWaveEntry();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                bs.Add(frm.NewWave);
                GoToWave(frm.NewWave.ID);
            }
        }

        private void toolbuttonStudies_Click(object sender, EventArgs e)
        {
            StudyManager frm = new StudyManager();
            frm.Show();
        }

        private void toolStripGoTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripGoTo.SelectedItem == null)
                return;

            GoToWave(((StudyWaveRecord)toolStripGoTo.SelectedItem).ID);
        }

        private void listViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WaveList frm = new WaveList(new List<StudyWaveRecord>(WaveList));
            frm.ShowDialog();
        }

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ComboBox control = (ComboBox)sender;

            if (!control.DroppedDown)
                ((HandledMouseEventArgs)e).Handled = true;
        }

        private void WaveManager_MouseWheel(object sender, MouseEventArgs e)
        {
            if (CurrentRecord.SaveRecord() == 1)
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
        


        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            RefreshCurrentWave();
        }

        private void Bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.PropertyDescriptor == null) return;

            int index = e.NewIndex; // index of the changed item

            switch (e.PropertyDescriptor.Name)
            {
                default:
                    ((StudyWaveRecord)bs[index]).Dirty = true;
                    break;
            }
        }

        private void cmdAddStudy_Click(object sender, EventArgs e)
        {
            NewStudyEntry frm = new NewStudyEntry();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                StudyList.Add(frm.NewStudy);
                cboProject.DataSource = null;
                cboProject.DataSource = StudyList;
                cboProject.SelectedItem = frm.NewStudy;
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (CurrentRecord.Surveys.Count > 1)
            {
                MessageBox.Show("This wave has 1 or more surveys. Unable to delete. If you really want to delete this wave, contact the ITC Programmer.");
                return;
            }


            if (MessageBox.Show("Are you sure you want to delete this wave?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                DBAction.DeleteRecord(CurrentRecord);
                WaveList.Remove(CurrentRecord);
                toolStripGoTo.ComboBox.DataSource = new List<StudyWaveRecord>(WaveList);
                bs.RemoveCurrent();
                RefreshCurrentWave();

            }

        }

        private void Control_Validated(object sender, EventArgs e)
        {
           // CurrentRecord.Dirty = true;
        }

        #endregion

        private void RefreshCurrentWave()
        {
            CurrentRecord = (StudyWaveRecord)bs.Current;
        }

        
        private void FillBoxes()
        {
            toolStripGoTo.ComboBox.DataSource = new List<StudyWaveRecord>(WaveList);
            toolStripGoTo.ComboBox.ValueMember = "ID";
            toolStripGoTo.ComboBox.DisplayMember = "WaveCode";

            cboProject.DataSource = StudyList;
            cboProject.DisplayMember = "StudyName";
            cboProject.ValueMember = "ID";
        }

        private void BindProperties()
        {
            txtID.DataBindings.Add(new Binding("Text", bs, "ID"));
            txtWaveNumber.DataBindings.Add(new Binding("Text", bs, "Wave"));
            chkEnglishRouting.DataBindings.Add(new Binding("Checked", bs, "EnglishRouting"));
            txtCountries.DataBindings.Add(new Binding("Text", bs, "Countries"));
            txtWaveCode.DataBindings.Add(new Binding("Text", bs, "WaveCode"));
            cboProject.DataBindings.Add(new Binding("SelectedValue", bs, "StudyID"));
        }

        private void SetupGrid()
        {
            dgvSurveys.AutoGenerateColumns = false;
            dgvSurveys.DataSource = bs;
            dgvSurveys.DataMember = "Surveys";

            chSurveyCode.DataPropertyName = "SurveyCode";

            dgvFieldwork.AutoGenerateColumns = false;
            dgvFieldwork.DataSource = bs;
            dgvFieldwork.DataMember = "FieldworkDates";

            chCountry.DataPropertyName = "CountryName";
            chFWStart.DataPropertyName = "Start";
            chFWEnd.DataPropertyName = "End";
        }

        

        private void GoToWave(int waveid)
        {
            for (int i = 0; i < WaveList.Count(); i++)
            {
                if (WaveList[i].ID == waveid)
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

        #region Navigation Bar events
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this issue.");
                return;
            }

            MoveRecord(1);
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this issue.");
                return;
            }

            MoveRecord(-1);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this issue.");
                return;
            }

            bs.MoveLast();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this issue.");
                return;
            }

            bs.MoveFirst();
        }

        #endregion
    }
}
