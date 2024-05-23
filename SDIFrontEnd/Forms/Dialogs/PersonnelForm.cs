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

        PersonnelStudy editedStudy;
        int studyRow = -1;

        PersonnelComment editedComment;
        int commentRow = -1;

        PersonnelRole editedRole;
        int roleRow = -1;

        bool rowCommit = true;

        BindingSource bs;
        BindingSource bsCurrent;

        public PersonnelForm() 
        {
            InitializeComponent();

            this.MouseWheel += PersonnelForm_MouseWheel;

            Records = new List<PersonRecord>();
            foreach (Person p in Globals.AllPeople)
            {
                Records.Add(new PersonRecord(p));
            }

            bs = new BindingSource();
            bs.DataSource = Records;
            bs.PositionChanged += Bs_PositionChanged;
            bs.AddingNew += Bs_AddingNew;

            bindingNavigator1.BindingSource = bs;

            bsCurrent = new BindingSource()
            {
                DataSource = bs,
                DataMember = "Item"
            };

            bsCurrent.ListChanged += BsCurrent_ListChanged;

            chStudyName.DisplayMember = "StudyNameISO";
            chStudyName.ValueMember = "ID";
            chStudyName.DataSource = Globals.AllStudies;

            chRole.DisplayMember = "RoleName";
            chRole.ValueMember = "ID";
            chRole.DataSource = Globals.AllRoles;

            BindProperties();
            CurrentRecord = (PersonRecord)bs.Current;
        }

        #region Events
        private void PersonnelForm_Load(object sender, EventArgs e)
        {
            CurrentRecord = (PersonRecord)bs.Current;

            if (CurrentRecord.Item.ID == 0)
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

        private void Bs_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new PersonRecord() { NewRecord = true };
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            CurrentRecord = (PersonRecord)bs.Current;

            if (CurrentRecord.Item.ID == 0 && !CurrentRecord.NewRecord)
                Lock(true);
            else
                Lock(false);

            lblPraccID.Visible = CurrentRecord.Item.Roles.Any(x => x.RoleName.RoleName.Equals("Pracc"));
            txtPraccID.Visible = CurrentRecord.Item.Roles.Any(x => x.RoleName.RoleName.Equals("Pracc"));

            dgvRoles.SetVirtualGridRows(CurrentRecord.Item.Roles.Count + 1);
            dgvStudies.SetVirtualGridRows(CurrentRecord.Item.AssociatedStudies.Count + 1);
            dgvComments.SetVirtualGridRows(CurrentRecord.Item.PersonnelComments.Count + 1);
        }

        private void BsCurrent_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.PropertyDescriptor == null)
                return;

            CurrentRecord.Dirty = true;
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
            txtID.DataBindings.Add("Text", bsCurrent, "ID");
            txtFirstName.DataBindings.Add("Text", bsCurrent, "FirstName");
            txtLastName.DataBindings.Add("Text", bsCurrent, "LastName");
            txtEmail.DataBindings.Add("Text", bsCurrent, "Email");
            txtWorkPhone.DataBindings.Add("Text", bsCurrent, "WorkPhone");
            txtHomePhone.DataBindings.Add("Text", bsCurrent, "HomePhone");
            txtOfficeNo.DataBindings.Add("Text", bsCurrent, "OfficeNo");
            txtUsername.DataBindings.Add("Text", bsCurrent, "Username");
            txtInstitution.DataBindings.Add("Text", bsCurrent, "Institution");
            chkActive.DataBindings.Add("Checked", bsCurrent, "Active");
            chkChangeNotify.DataBindings.Add("Checked", bsCurrent, "VarNameChangeNotify");
            chkPraccEntry.DataBindings.Add("Checked", bsCurrent, "PraccEntry");
            chkEntry.DataBindings.Add("Checked", bsCurrent, "Entry");
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
                if (p.Item.FirstName.ToLower().Contains(criteria.ToLower()) || p.Item.LastName.Contains(criteria.ToLower()))
                {
                    return i;
                }
            }
            return -1;
        }

        private int SaveRecord()
        {
            bsCurrent.EndEdit();

            bool newRec = CurrentRecord.NewRecord;

            if (CurrentRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this record.");
                return 1;
            }

            if (newRec)
                Globals.AllPeople.Add(CurrentRecord.Item);

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
                bs.DataSource = Records.Where(x => x.Item.Active).ToList();
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

        #region Roles grid
        private void dgvRoles_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            // Create a new object when the user edits the row for new records.
            this.editedRole = new PersonnelRole();
            this.roleRow = this.dgvRoles.Rows.Count - 1;
        }

        private void dgvRoles_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If this is the row for new records, no values are needed.
            if (e.RowIndex == dgv.RowCount - 1) return;
            // If the current record has no items, no values are needed.
            if (CurrentRecord.Item.Roles.Count == 0) return;

            PersonnelRole tmp = null;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == roleRow)
            {
                tmp = editedRole;
            }
            else
            {
                tmp = CurrentRecord.Item.Roles[e.RowIndex];
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chRole":
                    e.Value = tmp.RoleName.ID;
                    break;
            }
        }

        private void dgvRoles_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            PersonnelRole tmp = null;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < CurrentRecord.Item.Roles.Count)
            {
                // If the user is editing a new row, create a new object.
                if (editedRole == null)
                    editedRole = new PersonnelRole()
                    {
                        ID = CurrentRecord.Item.Roles[e.RowIndex].ID,
                        PersonnelID = CurrentRecord.Item.Roles[e.RowIndex].PersonnelID,
                        RoleName = CurrentRecord.Item.Roles[e.RowIndex].RoleName
                    };

                tmp = this.editedRole;
                this.roleRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedRole;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chRole":
                    PersonnelRole newValue = new PersonnelRole();
                    tmp.ID = newValue.ID;
                    tmp.PersonnelID = CurrentRecord.Item.ID;
                    tmp.RoleName.ID = (int)e.Value;
                    break;
            }
        }

        private void dgvRoles_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedRole != null && e.RowIndex >= CurrentRecord.Item.Roles.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                CurrentRecord.Item.Roles.Add(editedRole);
                CurrentRecord.AddedRoles.Add(editedRole);
                editedRole = null;
                roleRow = -1;
            }
            else if (editedRole != null && e.RowIndex < CurrentRecord.Item.Roles.Count)
            {
                // ignore edits 
                editedRole = null;
                roleRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedRole = null;
                roleRow = -1;
            }
        }

        private void dgvRoles_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void dgvRoles_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (roleRow == dgv.Rows.Count - 2 && roleRow == CurrentRecord.Item.Roles.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedRole = new PersonnelRole();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedRole = null;
                roleRow = -1;
            }
        }

        private void dgvRoles_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.CurrentRecord.Item.Roles.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this role?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PersonnelRole record = CurrentRecord.Item.Roles[e.Row.Index];
                    // If the user has deleted an existing row, remove the
                    // corresponding object from the data store.
                    this.CurrentRecord.Item.Roles.RemoveAt(e.Row.Index);
                    CurrentRecord.DeletedRoles.Add(record);
                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (e.Row.Index == this.roleRow)
            {
                // If the user has deleted a newly created row, release
                // the corresponding object.
                this.roleRow = -1;
                this.editedRole = null;
            }
        }

        private void dgvRoles_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        #region Associated Studies Grid

        private void dgvStudies_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            // Create a new object when the user edits the row for new records.
            this.editedStudy = new PersonnelStudy();
            this.studyRow = this.dgvStudies.Rows.Count - 1;
        }

        private void dgvStudies_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If this is the row for new records, no values are needed.
            if (e.RowIndex == dgv.RowCount - 1) return;
            // If the current record has no items, no values are needed.
            if (CurrentRecord.Item.AssociatedStudies.Count == 0) return;

            PersonnelStudy tmp = null;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == studyRow)
            {
                tmp = editedStudy;
            }
            else
            {
                tmp = CurrentRecord.Item.AssociatedStudies[e.RowIndex];
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chStudyName":
                    e.Value = tmp.StudyName.ID;
                    break;
            }
        }

        private void dgvStudies_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            PersonnelStudy tmp = null;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < CurrentRecord.Item.AssociatedStudies.Count)
            {
                // If the user is editing a new row, create a new object.
                if (editedStudy == null)
                    editedStudy = new PersonnelStudy()
                    {
                        ID = CurrentRecord.Item.AssociatedStudies[e.RowIndex].ID,
                        PersonnelID = CurrentRecord.Item.AssociatedStudies[e.RowIndex].PersonnelID,
                        StudyName = CurrentRecord.Item.AssociatedStudies[e.RowIndex].StudyName
                    };

                tmp = this.editedStudy;
                this.studyRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedStudy;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chStudyName":
                    PersonnelStudy newValue = new PersonnelStudy();
                    tmp.ID = newValue.ID;
                    tmp.PersonnelID = CurrentRecord.Item.ID;
                    tmp.StudyName.ID = (int)e.Value;
                    break;
            }
        }

        private void dgvStudies_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedStudy != null && e.RowIndex >= CurrentRecord.Item.AssociatedStudies.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                CurrentRecord.Item.AssociatedStudies.Add(editedStudy);
                CurrentRecord.AddedStudies.Add(editedStudy);
                editedStudy = null;
                studyRow = -1;
            }
            else if (editedStudy != null && e.RowIndex < CurrentRecord.Item.AssociatedStudies.Count)
            {
                // ignore edits 
                editedStudy = null;
                studyRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedStudy = null;
                studyRow = -1;
            }
        }

        private void dgvStudies_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void dgvStudies_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (studyRow == dgv.Rows.Count - 2 && studyRow == CurrentRecord.Item.AssociatedStudies.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedStudy = new PersonnelStudy();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedStudy = null;
                studyRow = -1;
            }
        }

        private void dgvStudies_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.CurrentRecord.Item.AssociatedStudies.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this study?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PersonnelStudy record = CurrentRecord.Item.AssociatedStudies[e.Row.Index];
                    // If the user has deleted an existing row, remove the
                    // corresponding object from the data store.
                    this.CurrentRecord.Item.AssociatedStudies.RemoveAt(e.Row.Index);
                    CurrentRecord.DeletedStudies.Add(record);
                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (e.Row.Index == this.studyRow)
            {
                // If the user has deleted a newly created row, release the corresponding object.
                this.studyRow = -1;
                this.editedStudy = null;
            }
        }

        private void dgvStudies_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        #region Comments Grid
        private void dgvComments_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            // Create a new object when the user edits the row for new records.
            this.editedComment = new PersonnelComment();
            this.commentRow = this.dgvComments.Rows.Count - 1;
        }

        private void dgvComments_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // If this is the row for new records, no values are needed.
            if (e.RowIndex == dgv.RowCount - 1) return;
            // If the current record has no items, no values are needed.
            if (CurrentRecord.Item.PersonnelComments.Count == 0) return;

            PersonnelComment tmp = null;

            // Store a reference to the object for the row being painted.
            if (e.RowIndex == commentRow)
            {
                tmp = editedComment;
            }
            else
            {
                tmp = CurrentRecord.Item.PersonnelComments[e.RowIndex];
            }

            if (tmp == null) return;

            // Set the cell value to paint using the object retrieved.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chCommentType":
                    e.Value = tmp.CommentType;
                    break;
                case "chComment":
                    e.Value = tmp.Comment;
                    break;
            }
        }

        private void dgvComments_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            PersonnelComment tmp = null;
            // Store a reference to the object for the row being edited.
            if (e.RowIndex < CurrentRecord.Item.PersonnelComments.Count)
            {
                // If the user is editing a new row, create a new object.
                if (editedComment == null)
                    editedComment = new PersonnelComment()
                    {
                        ID = CurrentRecord.Item.PersonnelComments[e.RowIndex].ID,
                        PersonnelID = CurrentRecord.Item.PersonnelComments[e.RowIndex].PersonnelID,
                        CommentType = CurrentRecord.Item.PersonnelComments[e.RowIndex].CommentType,
                        Comment = CurrentRecord.Item.PersonnelComments[e.RowIndex].CommentType
                    };

                tmp = this.editedComment;
                this.commentRow = e.RowIndex;
            }
            else
            {
                tmp = this.editedComment;
            }

            // Set the appropriate property to the cell value entered.
            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "chCommentType":
                    tmp.CommentType = (string)e.Value;
                    break;
                case "chComment":
                    tmp.Comment = (string)e.Value;
                    break;
            }
        }

        private void dgvComments_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // Save row changes if any were made and release the edited object if there is one.
            if (editedComment != null && e.RowIndex >= CurrentRecord.Item.PersonnelComments.Count && e.RowIndex != dgv.Rows.Count - 1)
            {
                // Add the new object to the data store.
                CurrentRecord.Item.PersonnelComments.Add(editedComment);
                CurrentRecord.AddedComment.Add(editedComment);
                editedComment = null;
                commentRow = -1;
            }
            else if (editedComment != null && e.RowIndex < CurrentRecord.Item.PersonnelComments.Count)
            {
                CurrentRecord.Item.PersonnelComments[e.RowIndex] = editedComment;
                CurrentRecord.EditedComment.Add(editedComment);
                
                editedComment = null;
                commentRow = -1;
            }
            else if (dgv.ContainsFocus)
            {
                editedComment = null;
                commentRow = -1;
            }
        }

        private void dgvComments_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            if (!rowCommit)
            {
                DataGridView dgv = (DataGridView)sender;
                // In cell-level commit scope, indicate whether the value of the current cell has been modified.
                e.Response = dgv.IsCurrentCellDirty;
            }
        }

        private void dgvComments_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (commentRow == dgv.Rows.Count - 2 && commentRow == CurrentRecord.Item.PersonnelComments.Count)
            {
                // If the user has canceled the edit of a newly created row,
                // replace the corresponding object with a new, empty one.
                editedComment = new PersonnelComment();
            }
            else
            {
                // If the user has canceled the edit of an existing row, release the corresponding object.
                editedComment = null;
                commentRow = -1;
            }
        }

        private void dgvComments_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.CurrentRecord.Item.PersonnelComments.Count)
            {
                if (MessageBox.Show("Are you sure you want to delete this comment?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PersonnelComment record = CurrentRecord.Item.PersonnelComments[e.Row.Index];
                    // If the user has deleted an existing row, remove the
                    // corresponding object from the data store.
                    this.CurrentRecord.Item.PersonnelComments.RemoveAt(e.Row.Index);
                    CurrentRecord.DeletedComment.Add(record);
                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (e.Row.Index == this.commentRow)
            {
                // If the user has deleted a newly created row, release the corresponding object.
                this.commentRow = -1;
                this.editedComment = null;
            }
        }

        private void dgvComments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        
    }
}
