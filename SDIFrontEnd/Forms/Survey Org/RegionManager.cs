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
    public partial class RegionManager : Form
    {
        List<RegionRecord> RegionList;

        RegionRecord CurrentRecord;

        BindingSource bs;

        public RegionManager()
        {
            InitializeComponent();
            this.MouseWheel += RegionManager_MouseWheel;

            RegionList = Globals.AllRegions;

            bs = new BindingSource();
            bs.DataSource = RegionList;
            bs.PositionChanged += Bs_PositionChanged;

            bindingNavigator1.BindingSource = bs;

            toolStripGoTo.ComboBox.DataSource = new List<RegionRecord> (RegionList);
            toolStripGoTo.ComboBox.ValueMember = "ID";
            toolStripGoTo.ComboBox.DisplayMember = "RegionName";

            BindProperties();

            SetupGrid();
            CurrentRecord = (RegionRecord)bs.Current;
        }

        #region Events 
        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            CurrentRecord = (RegionRecord)bs.Current;
        }

        private void RegionManager_MouseWheel(object sender, MouseEventArgs e)
        {
            bs.EndEdit();
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

        private void Control_Validated(object sender, EventArgs e)
        {
            CurrentRecord.Dirty = true;
        }

        private void toolStripGoTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripGoTo.SelectedItem == null)
                return;

            GoToRegion(((RegionRecord)toolStripGoTo.SelectedItem).ID);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FM.FormManager.Remove(this);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewRegionEntry frm = new NewRegionEntry();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                bs.Add(frm.NewRegion);
                GoToRegion(frm.NewRegion.ID);
            }
        }

        private void listViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegionList frm = new RegionList(new List<RegionRecord>(RegionList));
            frm.ShowDialog();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (cmdDelete.Text.Equals("Delete"))
            {
                MessageBox.Show("Deleting Regions is not allowed.");
                return;
            }
        }

        #endregion

        private void BindProperties()
        {
            txtID.DataBindings.Add("Text", bs, "ID");
            txtRegionName.DataBindings.Add("Text", bs, "RegionName");
            txtTempVarPrefix.DataBindings.Add("Text", bs, "TempVarPrefix");
        }

        private void SetupGrid()
        {
            chStudy.DataPropertyName = "StudyName";
            chCode.DataPropertyName = "ISO_Code";
            dgvStudies.AutoGenerateColumns = false;
            dgvStudies.DataSource = bs;
            dgvStudies.DataMember = "Studies";
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
            this.Validate();
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

        /// <summary>
        /// Navigate the bindingsource to the specified region ID.
        /// </summary>
        /// <param name="regionID"></param>
        private void GoToRegion(int regionID)
        {
            for (int i = 0; i < RegionList.Count(); i++)
            {
                if (RegionList[i].ID == regionID)
                {
                    bs.Position = i;
                    return;
                }
            }
        }
    }
}
