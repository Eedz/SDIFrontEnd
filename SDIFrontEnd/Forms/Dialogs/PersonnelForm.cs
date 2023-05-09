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
    public partial class PersonnelForm : Form
    {
        List<PersonRecord> Records;
        PersonRecord CurrentRecord;

        BindingSource bs;
        BindingSource bsStudies;
        BindingSource bsComments;

        public PersonnelForm() 
        {
            InitializeComponent();

            this.MouseWheel += PersonnelForm_MouseWheel;

            Records = Globals.AllPeople;

            bs = new BindingSource();
            bs.DataSource = Records;
            bs.PositionChanged += Bs_PositionChanged;

            bindingNavigator1.BindingSource = bs;

            bsStudies = new BindingSource()
            {
                DataSource = bs,
                DataMember = "AssociatedStudies"
            };

            dgvStudies.AutoGenerateColumns = false;
            dgvStudies.DataSource = bsStudies;

            
            chStudyName.DisplayMember = "StudyNameISO";
            chStudyName.ValueMember = "ID";
            chStudyName.DataSource = new List<StudyRecord>(Globals.AllStudies);
            chStudyName.DataPropertyName = "StudyID";


            bsComments = new BindingSource()
            {
                DataSource = bs,
                DataMember = "PersonnelComments"
            };

            dgvComments.AutoGenerateColumns = false;
            dgvComments.DataSource = bsComments;

            chCommentType.DataPropertyName = "CommentType";
            chComment.DataPropertyName = "Comment";

            
            

            BindProperties();
            CurrentRecord = (PersonRecord)bs.Current;
        }

        #region Events
        private void PersonnelForm_Load(object sender, EventArgs e)
        {
            CurrentRecord = (PersonRecord)bs.Current;

            if (CurrentRecord.ID == 0)
                Lock(true);
            else
                Lock(false);
        }

        private void PersonnelForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (SaveRecord()==1)
                return;

            if (e.Delta == -120)
                bs.MoveNext();
            else if (e.Delta == 120)
                bs.MovePrevious();
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            CurrentRecord = (PersonRecord)bs.Current;

            if (CurrentRecord.ID == 0 && !CurrentRecord.NewRecord)
                Lock(true);
            else
                Lock(false);

            lblPraccID.Visible = CurrentRecord.Praccer;
            txtPraccID.Visible = CurrentRecord.Praccer;

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {

            Search(txtSearchCriteria.Text);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddPersonnel();
        }

        private void chkShowInactive_CheckedChanged(object sender, EventArgs e)
        {
            ToggleInactive(chkShowInactive.Checked);
        }

        private void Control_Validated(object sender, EventArgs e)
        {
            CurrentRecord.Dirty = true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
            {
                if (MessageBox.Show("This record could not be saved. Do you want to close this form and lose any changes to this record?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
             
            Close();
        }

        #endregion


        #region Methods
        private void BindProperties()
        {
            txtID.DataBindings.Add("Text", bs, "ID");
            txtFirstName.DataBindings.Add("Text", bs, "FirstName");
            txtLastName.DataBindings.Add("Text", bs, "LastName");
            txtEmail.DataBindings.Add("Text", bs, "Email");
            txtWorkPhone.DataBindings.Add("Text", bs, "WorkPhone");
            txtHomePhone.DataBindings.Add("Text", bs, "HomePhone");
            txtOfficeNo.DataBindings.Add("Text", bs, "OfficeNo");
            txtUsername.DataBindings.Add("Text", bs, "Username");
            txtInstitution.DataBindings.Add("Text", bs, "Institution");

            chkActive.DataBindings.Add("Checked", bs, "Active");
            chkSMG.DataBindings.Add("Checked", bs, "SMG");
            chkAnalyst.DataBindings.Add("Checked", bs, "Analyst");
            chkPraccer.DataBindings.Add("Checked", bs, "Praccer");
            chkProgrammer.DataBindings.Add("Checked", bs, "Programmer");
            chkFirm.DataBindings.Add("Checked", bs, "Firm");
            chkCountryTeam.DataBindings.Add("Checked", bs, "CountryTeam");
            chkAdmin.DataBindings.Add("Checked", bs, "Admin");
            chkRA.DataBindings.Add("Checked", bs, "ResearchAssistant");
            chkDissemination.DataBindings.Add("Checked", bs, "Dissemination");
            chkInvestigator.DataBindings.Add("Checked", bs, "Investigator");
            chkStatistician.DataBindings.Add("Checked", bs, "Statistician");
            chkPM.DataBindings.Add("Checked", bs, "ProjectManager");
            chkChangeNotify.DataBindings.Add("Checked", bs, "VarNameChangeNotify");
            chkPraccEntry.DataBindings.Add("Checked", bs, "PraccEntry");
            chkEntry.DataBindings.Add("Checked", bs, "Entry");
        }

        private void Search(string criteria)
        {
            if (string.IsNullOrEmpty(criteria))
                return;

            int currentindex = bs.Position;
            int foundindex = SearchFrom(criteria, currentindex);
            if (foundindex == -1)
                foundindex = SearchFrom(criteria, 0);

            if (foundindex != -1)
                bs.Position = foundindex;
        }

        private int SearchFrom(string criteria, int startAt)
        {
            for (int i = startAt; i < bs.Count; i++)
            {
                PersonRecord p = ((PersonRecord)bs[i]);
                if (p.FirstName.ToLower().Contains(criteria.ToLower()) || p.LastName.Contains(criteria.ToLower()))
                {
                    return i;
                }
            }
            return -1;
        }

        private int SaveRecord()
        {
            bs.EndEdit();

            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this record.");
                return 1;
            }

            lblNewID.Visible = false;
            return 0;
        }

        private void AddPersonnel()
        {
            bs.AddNew();
            lblNewID.Visible = true;
            lblNewID.Left = txtID.Left;
            lblNewID.Top = txtID.Top;

            CurrentRecord.NewRecord = true;
        }

        private void ToggleInactive(bool show)
        {
            if (SaveRecord() == 1)
                return;

            if (show)
            {
                bs.DataSource = Records;
            }
            else
            {
                bs.DataSource = Records.Where(x => x.Active).ToList();
            }
            bs.ResetBindings(false);
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

        private void Lock(bool locked)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox) ((TextBox)c).ReadOnly = locked;
                if (c is CheckBox) ((CheckBox)c).Enabled = !locked;
                if (c is DataGridView) ((DataGridView)c).ReadOnly = locked;
            }

            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox) ((TextBox)c).ReadOnly = locked;
                if (c is CheckBox) ((CheckBox)c).Enabled = !locked;
                if (c is DataGridView) ((DataGridView)c).ReadOnly = locked;
            }

            txtSearchCriteria.ReadOnly = false;
        }

        #endregion


        #region Binding Navigator Events
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            MoveRecord(1);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            bs.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            MoveRecord(-1);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 1)
                return;

            bs.MoveFirst();
        }




        #endregion



        #region Associated Studies Grid

        private void dgvStudies_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            PersonnelStudyRecord record = (PersonnelStudyRecord)dgv.Rows[e.RowIndex].DataBoundItem;
            if (dgv.IsCurrentRowDirty)
                record.Dirty = true;
        }

        private void dgvStudies_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            PersonnelStudyRecord record = (PersonnelStudyRecord)dgv.Rows[e.RowIndex].DataBoundItem;


        }

        private void dgvStudies_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            PersonnelStudyRecord record = (PersonnelStudyRecord)dgv.Rows[e.RowIndex].DataBoundItem;
            if (record == null)
                return;
            if (record.NewRecord)
            {
                record.PersonnelID = CurrentRecord.ID;
                record.StudyID = (int)dgv.Rows[e.RowIndex].Cells[0].Value;
                CurrentRecord.Dirty = true;
            }
            else
                record.SaveRecord();
        }

        private void dgvStudies_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PersonnelStudyRecord newStudy = (PersonnelStudyRecord)e.Row.DataBoundItem;
                DBAction.DeleteRecord(newStudy);

            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dgvStudies_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        #region Comments Grid
        private void dgvComments_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            PersonnelCommentRecord record = (PersonnelCommentRecord)dgv.Rows[e.RowIndex].DataBoundItem;
            if (dgv.IsCurrentRowDirty)
                record.Dirty = true;
        }

        private void dgvComments_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            PersonnelCommentRecord record = (PersonnelCommentRecord)dgv.Rows[e.RowIndex].DataBoundItem;
            if (record == null)
                return;
            if (record.NewRecord)
            {
                record.PersonnelID = CurrentRecord.ID;
                CurrentRecord.Dirty = true;
            }
            else
                record.SaveRecord();
        }

        private void dgvComments_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PersonnelCommentRecord newComment = (PersonnelCommentRecord)e.Row.DataBoundItem;
                DBAction.DeleteRecord(newComment);

            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dgvComments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }


        #endregion

        
    }
}
