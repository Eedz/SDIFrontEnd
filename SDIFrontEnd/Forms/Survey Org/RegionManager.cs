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
    public partial class RegionManager : Form
    {
        List<RegionRecord> Records;

        RegionRecord CurrentRecord;

        BindingSource bs;
        BindingSource bsCurrent;

        public RegionManager()
        {
            InitializeComponent();

            SetupMouseWheel();

            FillLists();

            SetupBindingSources();

            FillBoxes();

            BindProperties();

            SetupGrid();
        }

        #region Events 

        private void RegionManager_Load(object sender, EventArgs e)
        {
            UpdateCurrentRecord();
        }

        private void RegionManager_FormClosed(object sender, FormClosedEventArgs e)
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
                Region modifiedRegion = (Region)bsCurrent[e.NewIndex];
                RegionRecord modifiedRecord = Records.Where(x => x.Item == modifiedRegion).FirstOrDefault();

                if (modifiedRecord == null)
                    return;

                switch (e.PropertyDescriptor.Name)
                {
                    case "Studies":
                        break;
                    default:
                        modifiedRecord.Dirty = true;
                        break;
                }
                //if (CurrentRecord.Dirty)
                //lblStatus.Text = "*";
            }
        }

        private void RegionManager_MouseWheel(object sender, MouseEventArgs e)
        {
            SaveRecord();

            if (e.Delta == -120)
                MoveRecord(1);
            else if (e.Delta == 120)
            {
                MoveRecord(-1);
            }
        }

        private void txtTempVarPrefix_Validating(object sender, CancelEventArgs e)
        {
            if (txtTempVarPrefix.Text.Length > 2)
            {
                MessageBox.Show("Temp Var Prefix must be 2 characters long.");
                e.Cancel = true;
            }
        }

        private void toolStripGoTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripGoTo.SelectedItem == null)
                return;

            SaveRecord();
            GoToRegion(((Region)toolStripGoTo.SelectedItem).ID);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            AddRegion();
        }

        private void listViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenListView();
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
            this.MouseWheel += RegionManager_MouseWheel;
        }

        private void UpdateCurrentRecord()
        {
            CurrentRecord = (RegionRecord)bs.Current;
        }

        private void FillLists()
        {
            Records = new List<RegionRecord>();

            foreach (Region region in Globals.AllRegions)
            {
                Records.Add(new RegionRecord(region));
            }
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
            txtID.DataBindings.Add("Text", bsCurrent, "ID");
            txtRegionName.DataBindings.Add("Text", bsCurrent, "RegionName");
            txtTempVarPrefix.DataBindings.Add("Text", bsCurrent, "TempVarPrefix");
        }

        private void FillBoxes()
        {
            toolStripGoTo.ComboBox.DataSource = new List<Region>(Globals.AllRegions);
            toolStripGoTo.ComboBox.ValueMember = "ID";
            toolStripGoTo.ComboBox.DisplayMember = "RegionName";
            toolStripGoTo.SelectedItem = null;
            toolStripGoTo.SelectedIndexChanged += toolStripGoTo_SelectedIndexChanged;
        }

        private void SetupGrid()
        {
            chStudy.DataPropertyName = "StudyName";
            chCode.DataPropertyName = "ISO_Code";
            dgvStudies.AutoGenerateColumns = false;
            dgvStudies.DataSource = bsCurrent;
            dgvStudies.DataMember = "Studies";
        }

        private void AddRegion()
        {
            NewRegionEntry frm = new NewRegionEntry();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                bs.Add(frm.NewRegion);
                GoToRegion(frm.NewRegion.Item.ID);
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
                    Globals.AllRegions.Add(CurrentRecord.Item);
            }
            else
            {
                MessageBox.Show("Unable to save record.");
            }
        }

        private void OpenListView()
        {
            RegionList frm = new RegionList(new List<RegionRecord>(Records));
            frm.ShowDialog();
        }

        private void DeleteRecord()
        {
            MessageBox.Show("Deleting Regions is not allowed.");
        }

        /// <summary>
        /// Navigate the bindingsource to the specified region ID.
        /// </summary>
        /// <param name="regionID"></param>
        private void GoToRegion(int regionID)
        {
            for (int i = 0; i < Records.Count(); i++)
            {
                if (Records[i].Item.ID == regionID)
                {
                    bs.Position = i;
                    return;
                }
            }
        }       
    }
}
