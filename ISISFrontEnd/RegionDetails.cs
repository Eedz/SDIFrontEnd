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
    // IDEA: consider disabling ability to delete a region 
    /// <summary>
    /// Displays the list of Regions (records in tblRegion).
    /// </summary>
    public partial class RegionDetails : Form
    {
        #region Properties
        public MainMenu frmParent;
        public string key;

        private BindingList<ITCLib.Region> Regions;
        private ITCLib.Region CurrentRegion;
        private BindingSource bs;

        private bool _dirty;
        private bool Dirty
        {
            get
            {
                return _dirty;
            }
            set
            {
                _dirty = value;
                if (_dirty)
                {
                    lblID.Text = "ID*";
                }
                else
                {
                    lblID.Text = "ID";
                }
            }
        }

        private bool NewRecord { get; set; }
        #endregion

        #region Constructors
        public RegionDetails()
        {
            InitializeComponent();

            Regions = new BindingList<ITCLib.Region>(DBAction.GetRegionInfo());
            this.MouseWheel += RegionDetails_MouseWheel;
            bs = new BindingSource()
            {
                DataSource = Regions
            };
            bs.PositionChanged += Bs_PositionChanged; 
            bs.ListChanged += Bs_ListChanged;

            navRegions.BindingSource = bs;

            BindProperties();
         
        }

        #endregion

        #region Event Handlers
        private void RegionDetails_Load(object sender, EventArgs e)
        {
            CurrentRegion = (ITCLib.Region)bs.Current;
        }


        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            CurrentRegion = (ITCLib.Region)bs.Current;
            PopulateTree();
        }

        private void Bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            Dirty = true;
        }

        /// <summary>
        /// When moving to the next/previous item, check if there are changes, save them and then move to the next record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegionDetails_MouseWheel(object sender, MouseEventArgs e)
        {
            bs.EndEdit();

            if (IsEmptyRecord(CurrentRegion))
            {
                bs.RemoveCurrent();
                return;
            }

            if (SaveRecord() == 1)
            {
                MessageBox.Show("Unable to save current record. Ensure all fields are filled.");
                return;
            }

            if (e.Delta == -120)
                MoveRecord(1);
            else if (e.Delta == 120)
                MoveRecord(-1);

        }

        /// <summary>
        /// Closes the form. Saves changes before closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseForm(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (IsEmptyRecord(CurrentRegion))
            {
                bs.RemoveCurrent();
                return;
            }

            if (SaveRecord() == 1)
            {
                MessageBox.Show("Unable to save current record. Ensure all fields are filled.");
                return;
            }

            Close();
        }

        /// <summary>
        /// After the form is closed, remove the tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegionDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmParent.CloseTab(key);
        }

        /// <summary>
        /// Cancel a new record with the escape key.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegionDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && NewRecord)
            {
                CancelRecord();
            }
        }
        #endregion

        #region Methods
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
        /// Tries to save the current item to the database, either by inserting or updating. An ID of 0 means it is a new, unsaved record.
        /// </summary>
        /// <returns></returns>
        private int SaveRecord()
        {

            if (NewRecord) // new study created by this form
            {
                // insert into table
                if (DBAction.InsertRegion(CurrentRegion) == 1)
                    return 1;

                Dirty = false;
                NewRecord = false;
                RefreshList(); // need to refresh to get the new ID
            }
            else if (Dirty) // existing study edited
            {
                if (DBAction.UpdateRegion(CurrentRegion) == 1)
                    return 1;

                Dirty = false;
            }

            return 0;

        }

        /// <summary>
        /// Gets the full list of regions from the database.
        /// </summary>
        private void RefreshList()
        {
            Regions = new BindingList<ITCLib.Region>(DBAction.GetRegionInfo());
            bs.DataSource = Regions;
        }

        /// <summary>
        /// Set data binding between the form's controls and the underlying list.
        /// </summary>
        private void BindProperties()
        {
            txtID.DataBindings.Add("Text", bs, "RegionID");
            txtRegionName.DataBindings.Add("Text", bs, "RegionName");
        }

        /// <summary>
        /// The Study Tree shows the studies for each region.
        /// </summary>
        private void PopulateTree()
        {
            treeStudies.Nodes.Clear();

            if (CurrentRegion.Studies.Count == 1)
                lblStudyList.Text = CurrentRegion.RegionName + " has " + CurrentRegion.Studies.Count + " study.";
            else
                lblStudyList.Text = CurrentRegion.RegionName + " has " + CurrentRegion.Studies.Count + " studies.";

            foreach (Study s in CurrentRegion.Studies)
            {
                treeStudies.Nodes.Add(s.ISO_Code);
            }
        }

        /// <summary>
        /// Returns true if all fields (other than ID) are empty.
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        private bool IsEmptyRecord(ITCLib.Region r)
        {
            if (string.IsNullOrEmpty(r.RegionName) && (r.RegionID == 0 && NewRecord))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Removes the current item from the list and clear the dirty flag.
        /// </summary>
        private void CancelRecord()
        {
            if (NewRecord)
            {
                bs.RemoveCurrent();
                NewRecord = false;
                Dirty = false;
            }
        }
        #endregion

        #region Navigator button events
        /// <summary>
        /// When moving to the next item, check if there are changes, save them and then move to the next record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (IsEmptyRecord(CurrentRegion))
            {
                bs.RemoveCurrent();
                return;
            }

            if (SaveRecord() == 1)
            {
                MessageBox.Show("Unable to save current record. Ensure all fields are filled.");
                return;
            }

            MoveRecord(1);
            PopulateTree();
        }

        /// <summary>
        /// When moving to the next item, check if there are changes, save them and then move to the next record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (IsEmptyRecord(CurrentRegion))
            {
                bs.RemoveCurrent();
                return;
            }

            if (SaveRecord() == 1)
            {
                MessageBox.Show("Unable to save current record. Ensure all fields are filled.");
                return;
            }

            MoveRecord(-1);
            PopulateTree();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (IsEmptyRecord(CurrentRegion))
            {
                bs.RemoveCurrent();
                return;
            }

            if (SaveRecord() == 1)
            {
                MessageBox.Show("Unable to save current record. Ensure all fields are filled.");
                return;
            }

            bs.MoveLast();
            PopulateTree();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (IsEmptyRecord(CurrentRegion))
            {
                bs.RemoveCurrent();
                return;
            }

            if (SaveRecord() == 1)
            {
                MessageBox.Show("Unable to save current record. Ensure all fields are filled.");
                return;
            }

            bs.MoveFirst();
            PopulateTree();
        }


        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (IsEmptyRecord(CurrentRegion))
            {
                bs.RemoveCurrent();
                return;
            }

            if (SaveRecord() == 1)
            {
                MessageBox.Show("Unable to save current record. Ensure all fields are filled.");
                return;
            }

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            NewRecord = true;
            Dirty = true;
            bs.AddNew();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Warning: This will delete the region: '" + CurrentRegion.RegionName +
                "' and any studies belonging to it. Are you sure you want to delete this region?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            // delete from database
            if (DBAction.DeleteRegion(CurrentRegion.RegionID) == 1)
            {
                MessageBox.Show("Error deleting this region.");
                return;
            }
            else
            {
                // remove from list after successful deletion from database
                bs.RemoveCurrent();
            }


        }

        #endregion
    }
}
