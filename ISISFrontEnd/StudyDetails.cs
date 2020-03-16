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
    // IDEA: consider disabling the ability to delete a study
    /// <summary>
    /// Displays the list of Studies (records in tblCountryCode).
    /// </summary>
    public partial class StudyDetails : Form
    {
        #region Properties
        public MainMenu frmParent;
        public string key;

        private BindingList<Study> Studies;
        private Study CurrentStudy;
        private BindingSource bs;

        private bool _dirty;
        private bool Dirty {
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
        public StudyDetails()
        {
            InitializeComponent();

            Studies = new BindingList<Study>(DBAction.GetStudyInfo());
            this.MouseWheel += StudyDetails_MouseWheel;
            bs = new BindingSource()
            {
                DataSource = Studies
            };
            bs.PositionChanged += Bs_PositionChanged;
            bs.ListChanged += Bs_ListChanged;

            navStudies.BindingSource = bs;
            
            BindProperties();

        }

        #endregion

        #region Event Handlers
        private void StudyDetails_Load(object sender, EventArgs e)
        {
            CurrentStudy = (Study)bs.Current;
            PopulateTree();
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            CurrentStudy = (Study)bs.Current;
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
        private void StudyDetails_MouseWheel(object sender, MouseEventArgs e)
        {
            bs.EndEdit();

            if (IsEmptyRecord(CurrentStudy))
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

            if (IsEmptyRecord(CurrentStudy))
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
        private void StudyDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmParent.CloseTab(key);
        }

        /// <summary>
        /// Cancel a new record with the escape key.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudyDetails_KeyDown(object sender, KeyEventArgs e)
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
                if (DBAction.InsertCountry(CurrentStudy) == 1)
                    return 1;

                NewRecord = false;
                Dirty = false;
                RefreshList(); // need to refresh to get the new ID
            }
            else if (Dirty) // existing study edited
            {
                if (DBAction.UpdateStudy(CurrentStudy) == 1)
                    return 1;

                Dirty = false;
            }

            return 0;
            
        }

        /// <summary>
        /// Gets the full list of studies from the database.
        /// </summary>
        private void RefreshList()
        {
            Studies = new BindingList<Study>(DBAction.GetStudyInfo());
            bs.DataSource = Studies;
        }

        /// <summary>
        /// Set data binding between the form's controls and the underlying list.
        /// </summary>
        private void BindProperties()
        {
            txtID.DataBindings.Add("Text", bs, "StudyID");
            txtStudyName.DataBindings.Add("Text", bs, "StudyName");
            txtCountryName.DataBindings.Add("Text", bs, "CountryName");
            txtCountryCode.DataBindings.Add("Text", bs, "CountryCode");
            txtISOCode.DataBindings.Add("Text", bs, "ISO_Code");
            txtAgeGroup.DataBindings.Add("Text", bs, "AgeGroup");
        }

        /// <summary>
        /// The Wave Tree shows the waves and surveys for each study.
        /// </summary>
        private void PopulateTree()
        {
            treeWaves.Nodes.Clear();

            if (CurrentStudy.Waves.Count == 1)
                lblWaveList.Text = CurrentStudy.StudyName + " has " + CurrentStudy.Waves.Count + " wave.";
            else
                lblWaveList.Text = CurrentStudy.StudyName + " has " + CurrentStudy.Waves.Count + " waves.";

            foreach (StudyWave w in CurrentStudy.Waves)
            {
                treeWaves.Nodes.Add(w.ISO_Code + w.Wave);

                if (w.Surveys.Count > 0)
                    foreach (Survey s in w.Surveys)
                    {
                        treeWaves.Nodes[CurrentStudy.Waves.IndexOf(w)].Nodes.Add(s.SurveyCode);
                    }
            }


        }

        /// <summary>
        /// Returns true if all fields (other than ID and Country Code) are empty.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool IsEmptyRecord(Study s)
        {
            if (string.IsNullOrEmpty(s.AgeGroup) && string.IsNullOrEmpty(s.CountryName) && string.IsNullOrEmpty(s.ISO_Code) && string.IsNullOrEmpty(s.StudyName))
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

            if (IsEmptyRecord(CurrentStudy))
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
        }

        /// <summary>
        /// When moving to the next item, check if there are changes, save them and then move to the next record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (IsEmptyRecord(CurrentStudy))
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
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (IsEmptyRecord(CurrentStudy))
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
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (IsEmptyRecord(CurrentStudy))
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
        }


        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            if (IsEmptyRecord(CurrentStudy))
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
            if (MessageBox.Show("Warning: This will delete the study: '" + CurrentStudy.StudyName + 
                "' and any surveys belonging to it. Are you sure you want to delete this study?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            
            // delete from database
            if (DBAction.DeleteStudy(CurrentStudy.StudyID) == 1)
            {
                MessageBox.Show("Error deleting this study.");
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
