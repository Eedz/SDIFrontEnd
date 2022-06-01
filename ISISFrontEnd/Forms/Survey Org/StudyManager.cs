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

namespace ISISFrontEnd
{
    public partial class StudyManager : Form
    {
        List<StudyRecord> StudyList;
        List<RegionRecord> RegionList;
        StudyRecord CurrentRecord;

        BindingSource bs;
        public StudyManager()
        {
            InitializeComponent();

            this.MouseWheel += StudyManager_MouseWheel;
            cboRegion.MouseWheel += ComboBox_MouseWheel;
            cboAgeGroup.MouseWheel += ComboBox_MouseWheel;

            StudyList = Globals.AllStudies;
            RegionList =Globals.AllRegions;

            bs = new BindingSource();
            bs.DataSource = StudyList;
            bs.PositionChanged += Bs_PositionChanged;
            bindingNavigator1.BindingSource = bs;

            FillBoxes();

            BindProperties();

            dgvWaves.AutoGenerateColumns = false;
            dgvWaves.DataSource = bs;
            dgvWaves.DataMember = "Waves";

            chWave.DataPropertyName = "WaveCode";

            CurrentRecord = (StudyRecord)bs.Current;
        }

        #region Events

        private void toolbuttonRegions_Click(object sender, EventArgs e)
        {
            RegionManager frm = new RegionManager();
            frm.Show();
        }

        private void toolStripGoTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripGoTo.SelectedItem == null)
                return;

            GoToStudy(((StudyRecord)toolStripGoTo.SelectedItem).ID);
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            CurrentRecord = (StudyRecord)bs.Current;
        }

        private void StudyManager_MouseWheel(object sender, MouseEventArgs e)
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

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ComboBox control = (ComboBox)sender;

            if (!control.DroppedDown)
                ((HandledMouseEventArgs)e).Handled = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving record.");
                return;
            }

            Close();
            FormManager.Remove(this);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudy();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Deleting studies is not allowed.");
        }

        private void cmdAddRegion_Click(object sender, EventArgs e)
        {
            AddRegion();
        }

        private void Control_Validated(object sender, EventArgs e)
        {
            CurrentRecord.Dirty = true;
        }
        #endregion


        private void FillBoxes()
        {
            toolStripGoTo.ComboBox.DataSource = StudyList;
            toolStripGoTo.ComboBox.ValueMember = "ID";
            toolStripGoTo.ComboBox.DisplayMember = "StudyName";

            cboRegion.DataSource = Globals.AllRegions;
            cboRegion.DisplayMember = "RegionName";
            cboRegion.ValueMember = "ID";

            cboAgeGroup.Items.Add("");
            cboAgeGroup.Items.Add("Adult");
            cboAgeGroup.Items.Add("Mixed");
            cboAgeGroup.Items.Add("Youth");
        }

        private void BindProperties()
        {
            // survey info
            txtID.DataBindings.Add(new Binding("Text", bs, "ID"));
            cboRegion.DataBindings.Add("SelectedValue", bs, "RegionID");
            txtStudyName.DataBindings.Add("Text", bs, "StudyName");
            txtCountry.DataBindings.Add("Text", bs, "CountryName");

            txtISOCode.DataBindings.Add("Text", bs, "ISO_Code");
            txtCC.DataBindings.Add("Text", bs, "CountryCode");
            txtCohort.DataBindings.Add("Text", bs, "Cohort");

            cboAgeGroup.DataBindings.Add("SelectedItem", bs, "AgeGroup");

            txtLanguages.DataBindings.Add(new Binding("Text", bs, "Languages"));


        }
        
        private void AddStudy()
        {
            NewStudyEntry frm = new NewStudyEntry(RegionList);

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                bs.Add(frm.NewStudy);
                GoToStudy(frm.NewStudy.ID);
            }

            
        }

        private void AddRegion()
        {
            NewRegionEntry frm = new NewRegionEntry();

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                cboRegion.DataSource = null;
                cboRegion.DataSource = Globals.AllRegions;
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
            for (int i = 0; i < StudyList.Count(); i++)
            {
                if (StudyList[i].ID == studyID)
                {
                    bs.Position = i;
                    return;
                }
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
