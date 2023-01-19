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
    // TODO test documentation and failed renames
    // TODO test new renamer

    public partial class RenameVars : Form
    {

        List<VariableName> VarNameList;
        List<RefVariableName> RefVarNameList;
        List<VarNameChange> Changes;
        List<string> Failed;

        int Scope = 1;
        

        public RenameVars()
        {
            InitializeComponent();

            VarNameList = new List<VariableName>(Globals.AllVarNames);
            RefVarNameList = new List<RefVariableName>(Globals.AllRefVarNames);

            Failed = new List<string>();

            optRefVarName.Checked = true;

            UpdateVarList();

            Changes = new List<VarNameChange>();
        }

        public RenameVars(VariableName var) : this()
        {
            cboSource.SelectedItem = var;
        }

        public RenameVars(RefVariableName refvar) : this()
        {
            cboSource.SelectedItem = refvar;
        }

        #region Menu Bar
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FormManager.RemovePopup(this);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
        }
        #endregion

        #region Events

        private void Scope_Click(object sender, EventArgs e)
        {
            lstSurveyList.DataSource = null;
            UpdateVarList();
            UpdateStatus();
        }

        private void cboSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillSurveyList((RefVariableName)cboSource.SelectedItem);
            UpdateStatus();
        }

        private void cboDest_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void cboDest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                lstSurveyList.Focus();
            }
        }

        /// <summary>
        /// If a user entered a custom varname, add it to the list and select it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDest_Leave(object sender, EventArgs e)
        {
            if (cboDest.Text == null)
                return;

            string enteredValue = cboDest.Text;
            RefVariableName newVar = new RefVariableName(enteredValue);
            if (!cboDest.Items.Contains(newVar))
                cboDest.Items.Add(newVar);

            cboDest.SelectedItem = newVar;
        }

        private void lstSurveyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void cmdRename_Click(object sender, EventArgs e)
        {
            
            RefVariableName source = (RefVariableName)cboSource.SelectedItem;
            RefVariableName dest = (RefVariableName)cboDest.SelectedItem;
            List<Survey> surveyList = lstSurveyList.SelectedItems.Cast<Survey>().ToList();
            VarRenamer renamer = new VarRenamer(source, dest, surveyList);
            
            renamer.PerformRefRename();

            if (renamer.FailedRenames.Count > 0)
            {
                MessageBox.Show("Some renames were not performed: " + string.Join(", ", renamer.FailedRenames));
            }

            // if no documentation, we are done
            if (chkDoNotDocument.Checked)
                return;

            // document rename, fill in 'changed by' name and notifications
            foreach (VarNameChangeRecord change in renamer.Changes)
            {
                change.PreFWChange = chkPreFWS.Checked;
                change.ChangedBy = Globals.AllPeople.Where(x => x.ID == Globals.CurrentUser.userid).First(); 
                foreach (Person autoNotify in Globals.AllPeople.Where(x => x.VarNameChangeNotify && x.Active).ToList())
                {
                    change.Notifications.Add(new VarNameChangeNotificationRecord() { PersonID = autoNotify.ID, Name = autoNotify.Name, NotifyType = "Auto-email" });
                }
            }

            VarChangeTracking frm = new VarChangeTracking(renamer.Changes, true);
            frm.ShowDialog();            
        }

        #endregion

        #region Methods

      

        private void Reset()
        {
            cboSource.SelectedItem = null;
            cboDest.SelectedItem = null;
            
        }

        private void FillSurveyList(RefVariableName refvar)
        {
            if (refvar == null)
            {
                lstSurveyList.Items.Clear();
                return;
            }
            List<string> surveyNames = DBAction.GetRefVarNameSurveys(refvar.RefVarName);

            lstSurveyList.DisplayMember = "SurveyCode";
            lstSurveyList.ValueMember = "SID";
            lstSurveyList.DataSource = Globals.AllSurveys.Where(x => surveyNames.Contains(x.SurveyCode)).ToList();
            
        }

        private void UpdateStatus()
        {
            string infoMessages;
            if (optVarName.Checked)
            {
                VariableName source = (VariableName)cboSource.SelectedItem;
                VariableName dest = (VariableName)cboDest.SelectedItem;

                string errorMessages = ErrorsExist(source, dest, out bool error);
                cmdRename.Enabled = !error;

                if (error)
                {
                    txtStatus.Text = errorMessages;
                    return;
                }

                infoMessages = GetInfo(source, dest);
            }
            else
            {
                RefVariableName source = (RefVariableName)cboSource.SelectedItem;
                RefVariableName dest = (RefVariableName)cboDest.SelectedItem;

                string errorMessages = ErrorsExist(source, dest, out bool error);
                cmdRename.Enabled = !error;

                if (error)
                {
                    txtStatus.Text = errorMessages;
                    return;
                }

                infoMessages = GetInfo(source, dest);
            }
            


            txtStatus.Text = infoMessages;


        }

        private void UpdateVarList()
        {
            cboSource.SelectedIndexChanged -= cboSource_SelectedIndexChanged;
            cboDest.SelectedIndexChanged -= cboDest_SelectedIndexChanged;

            cboSource.DataSource = null;
            cboDest.Items.Clear();
            if (optRefVarName.Checked)
            {
                cboSource.DisplayMember = "RefVarName";
                cboSource.ValueMember = "RefVarName";
                cboSource.DataSource = RefVarNameList;

                cboDest.DisplayMember = "RefVarName";
                cboDest.ValueMember = "RefVarName";

                foreach (RefVariableName refVar in RefVarNameList)
                    cboDest.Items.Add(refVar);

                
            }
            else if (optVarName.Checked)
            {
                cboSource.DisplayMember = "VarName";
                cboSource.ValueMember = "VarName";
                cboSource.DataSource = VarNameList;

                cboDest.DisplayMember = "VarName";
                cboDest.ValueMember = "VarName";
                foreach (VariableName refVar in VarNameList)
                    cboDest.Items.Add(refVar);

                
            }

            cboSource.SelectedItem = null;
            cboDest.SelectedItem = null;

            cboSource.SelectedIndexChanged += cboSource_SelectedIndexChanged;
            cboDest.SelectedIndexChanged += cboDest_SelectedIndexChanged;
        }




        private string GetInfo(RefVariableName source, RefVariableName dest)
        {
            StringBuilder msg = new StringBuilder();

            // check if destination exists
            if (!DestinationExists(dest))
            {
                msg.AppendLine("Info: " + dest.RefVarName + " doesn't exist and will be created.");
            }


            if (lstSurveyList.SelectedIndices.Count > 0)
            {
                msg.AppendLine("Renames to be performed:");
                // list all coded varnames that will be created
                foreach (Survey s in lstSurveyList.SelectedItems)
                {
                    string fullSource = Utilities.ChangeCC(source.RefVarName, s.CountryCode);
                    string fullDest = Utilities.ChangeCC(dest.RefVarName, s.CountryCode);
                    msg.AppendLine(s.SurveyCode + ": " + fullSource + " -> " + fullDest);
                }
            }


            return msg.ToString();
        }

        private string GetInfo(VariableName source, VariableName dest)
        {
            StringBuilder msg = new StringBuilder();

            // check if destination exists
            if (!DestinationExists(dest))
            {
                msg.AppendLine("Info: " + dest.RefVarName + " doesn't exist and will be created.");
            }

            if (lstSurveyList.SelectedIndices.Count > 0)
            {
                msg.AppendLine("Renames to be performed:");
                // list all coded varnames that will be created
                foreach (Survey s in lstSurveyList.SelectedItems)
                {
                    msg.AppendLine(s.SurveyCode + ": " + source.VarName + " -> " + dest.VarName);
                }
            }


            return msg.ToString();
        }

        private string ErrorsExist(RefVariableName source, RefVariableName dest, out bool error)
        {
            StringBuilder msg = new StringBuilder();
            error = false;

            // check for blank
            if (source == null)
            {
                error = true;
                msg.AppendLine("Error: source is empty.");
            }
            if (dest == null)
            {
                error = true;
                msg.AppendLine("Error: destination is empty.");
            }
            if (source == null || dest == null)
                return msg.ToString();

            // check if destination and source are the same
            if (source.Equals(dest))
            {
                error = true;
                msg.AppendLine("Error: source and destination are the same.");
            }

            // check if destination is already in one of the surveys
            if (ExistsInSurveys(dest.RefVarName))
            {
                error = true;
                msg.AppendLine("Error: destination already exists in one or more selected surveys.");
            }

            // check if destination is a temp var
            if (Globals.AllTempPrefixes.Contains(dest.Prefix))
            {
                error = true;
                msg.AppendLine("Error: destination is a temporary varname.");
            }

            return msg.ToString();
        }

        private string ErrorsExist(VariableName source, VariableName dest, out bool error)
        {
            StringBuilder msg = new StringBuilder();
            error = false;

            // check for blank
            if (source == null)
            {
                error = true;
                msg.AppendLine("Error: source is empty.");
            }
            if (dest == null)
            {
                error = true;
                msg.AppendLine("Error: destination is empty.");
            }
            if (source == null || dest == null)
                return msg.ToString();

            // check if destination and source are the same
            if (source.Equals(dest))
            {
                error = true;
                msg.AppendLine("Error: source and destination are the same.");
            }

            // check if destination is already in one of the surveys
            if (ExistsInSurveys(dest.RefVarName))
            {
                error = true;
                msg.AppendLine("Error: destination already exists in one or more selected surveys.");
            }

            return msg.ToString();
        }

        private bool ExistsInSurveys(string dest)
        {
            foreach (Survey s in lstSurveyList.SelectedItems)
            {
                
                if (DBAction.GetQuestionIDRef(s.SurveyCode, dest)!=0)
                {
                    return true;
                }
            }

            return false;
        }

        private bool DestinationExists(RefVariableName var)
        {
            return Globals.AllRefVarNames.Contains(var);
        }

        private bool DestinationExists(VariableName var)
        {
            return Globals.AllVarNames.Contains(var);
        }

        

        #endregion

        
    }
}
