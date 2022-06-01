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
    // TODO test 

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

            RefVarNameList = Globals.AllRefVarNames;
            Failed = new List<string>();

            optRefVarName.Checked = true;

            cboSource.DataSource = new List<RefVariableName>(RefVarNameList);
            cboSource.DisplayMember = "RefVarName";
            cboSource.ValueMember = "RefVarName";

            //cboDest.DataSource = new List<RefVariableName>(RefVarNameList);
            foreach (RefVariableName refVar in RefVarNameList)
                cboDest.Items.Add(refVar);

            cboDest.DisplayMember = "RefVarName";
            cboDest.ValueMember = "RefVarName";

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
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
        }
        #endregion

        #region Events

        private void Scope_CheckedChanged(object sender, EventArgs e)
        {
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
            PerformRename();
        }

        #endregion

        #region Method

        private void PerformRename()
        {
            RefVariableName source = (RefVariableName)cboSource.SelectedItem;
            RefVariableName dest = (RefVariableName)cboDest.SelectedItem;
            List<Survey> surveyList = (List<Survey>)lstSurveyList.SelectedItems.Cast<Survey>();

            // create a list of change objects
            List<VarNameChangeRecord> changes = new List<VarNameChangeRecord>();
            foreach (VarNameChangeSurveyRecord s in surveyList)
            {
                s.NewRecord = true;
                VariableName oldname = new VariableName();
                oldname.VarName = Utilities.ChangeCC(source.RefVarName, s.CountryCode);
                VariableName newname = new VariableName();
                newname.VarName = Utilities.ChangeCC(source.RefVarName, s.CountryCode);

                var existingChange = changes.FirstOrDefault(x => x.NewName.VarName.Equals(newname.VarName));
                if (existingChange != null)
                {
                    existingChange.SurveysAffected.Add(s);
                    continue;
                }
                VarNameChangeRecord change = new VarNameChangeRecord();
                change.NewRecord = true;
                change.OldName = oldname;
                change.NewName = newname;
                change.ChangeDate = DateTime.Now;
                change.ChangedBy = (Person)Globals.AllPeople.Where(x => x.ID == Globals.CurrentUser.userid);

                foreach (Person autoNotify in Globals.AllPeople.Where(x => x.VarNameChangeNotify))
                {
                    change.Notifications.Add(new VarNameChangeNotificationRecord(autoNotify, "Auto-email"));
                }

                change.SurveysAffected.Add(s);

                changes.Add(change);
            }

            // rename vars in surveys
            foreach (Survey s in surveyList)
            {

                RenameVariable(source, dest, s.SurveyCode);
            }
            // rename in wordings
            var successes = surveyList.Where(x => !Failed.Contains(x.SurveyCode));

            foreach (Survey s in successes)
            {
                UpdatePreP(source, dest, s.SurveyCode);
                UpdatePreI(source, dest, s.SurveyCode);
                UpdatePreA(source, dest, s.SurveyCode);
                UpdateLitQ(source, dest, s.SurveyCode);
                UpdatePstI(source, dest, s.SurveyCode);
                UpdatePstP(source, dest, s.SurveyCode);
            }

            // document rename


            VarNameChangeQuickEntry frm = new VarNameChangeQuickEntry(changes);
            frm.ShowDialog();

            // delete var?
            foreach (Survey s in successes)
            {

            }

            // check for failures
            if (Failed.Count > 0)
            {
                MessageBox.Show("Some VarNames were not changed.");
                // TODO show list of surveys that failed.
            }
        }

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
            
            lstSurveyList.DataSource = Globals.AllSurveys.Where(x => surveyNames.Contains(x.SurveyCode)).ToList();
            lstSurveyList.DisplayMember = "SurveyCode";
            lstSurveyList.ValueMember = "SID";
        }

        private void UpdateStatus()
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

            string infoMessages = GetInfo(source, dest);


            txtStatus.Text = infoMessages;


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

        private void UpdatePreP(RefVariableName oldname, RefVariableName newname, string survey)
        {
            // get a list of PrePs in this survey that contain the old name
            List<Wording> preps = DBAction.GetSurveyPreP(oldname.RefVarName, survey);

            foreach (Wording w in preps)
            {
                int oldID = w.WordID; // save the old ID
                // upsert the wording
                DBAction.UpdatePreP(w, oldname.RefVarName, newname.RefVarName, false); // potentially get a new ID

                if (oldID != w.WordID)
                {
                    DBAction.UpdateSurveyPreP(survey, oldID, w.WordID);
                }
            }
        }

        private void UpdatePreI(RefVariableName oldname, RefVariableName newname, string survey)
        {
            // get a list of PreIs in this survey that contain the old name
            List<Wording> preis = DBAction.GetSurveyPreI(oldname.RefVarName, survey);

            foreach (Wording w in preis)
            {
                int oldID = w.WordID; // save the old ID
                                      // upsert the wording
                    DBAction.UpdatePreI(w, oldname.RefVarName, newname.RefVarName, false); // potentially get a new ID
                if (oldID != w.WordID)
                {
                    DBAction.UpdateSurveyPreI(survey, oldID, w.WordID);
                }
            }
        }

        private void UpdatePreA(RefVariableName oldname, RefVariableName newname, string survey)
        {
            // get a list of PreAs in this survey that contain the old name
            List<Wording> preas = DBAction.GetSurveyPreI(oldname.RefVarName, survey);

            foreach (Wording w in preas)
            {
                int oldID = w.WordID; // save the old ID
                                      // upsert the wording
                DBAction.UpdatePreA(w, oldname.RefVarName, newname.RefVarName, false); // potentially get a new ID
                if (oldID != w.WordID)
                {
                    DBAction.UpdateSurveyPreA(survey, oldID, w.WordID);
                }
            }
        }

        private void UpdateLitQ(RefVariableName oldname, RefVariableName newname, string survey)
        {
            // get a list of LitQs in this survey that contain the old name
            List<Wording> litqs = DBAction.GetSurveyPreI(oldname.RefVarName, survey);

            foreach (Wording w in litqs)
            {
                int oldID = w.WordID; // save the old ID
                                      // upsert the wording
                DBAction.UpdateLitQ(w, oldname.RefVarName, newname.RefVarName, false); // potentially get a new ID
                if (oldID != w.WordID)
                {
                    DBAction.UpdateSurveyLitQ(survey, oldID, w.WordID);
                }
            }
        }

        private void UpdatePstI(RefVariableName oldname, RefVariableName newname, string survey)
        {
            // get a list of PstIs in this survey that contain the old name
            List<Wording> pstis = DBAction.GetSurveyPreI(oldname.RefVarName, survey);

            foreach (Wording w in pstis)
            {
                int oldID = w.WordID; // save the old ID
                                      // upsert the wording
                DBAction.UpdatePstI(w, oldname.RefVarName, newname.RefVarName, false); // potentially get a new ID
                if (oldID != w.WordID)
                {
                    DBAction.UpdateSurveyPstI(survey, oldID, w.WordID);
                }
            }
        }

        private void UpdatePstP(RefVariableName oldname, RefVariableName newname, string survey)
        {
            // get a list of PstPs in this survey that contain the old name
            List<Wording> pstps = DBAction.GetSurveyPreI(oldname.RefVarName, survey);

            foreach (Wording w in pstps)
            {
                int oldID = w.WordID; // save the old ID
                                      // upsert the wording
                DBAction.UpdatePstP(w, oldname.RefVarName, newname.RefVarName, false); // potentially get a new ID
                if (oldID != w.WordID)
                {
                    DBAction.UpdateSurveyPstP(survey, oldID, w.WordID);
                }
            }
        }

        private void RenameVariable (RefVariableName oldname, RefVariableName newname, string survey)
        {
            Failed.Clear();

            if (DBAction.RenameVariableName(oldname, newname, survey) == 1)
            {
                Failed.Add(survey);
            }
        }

        private void RenameVariable(List<VarNameChange> changes)
        {
            Failed.Clear();
            foreach (VarNameChange change in changes)
            {
                foreach (Survey s in change.SurveysAffected)
                {
                    if (DBAction.RenameVariableName(change.OldName, change.NewName, s.SurveyCode) == 1)
                    {
                        Failed.Add(s.SurveyCode);
                    }
                }
                
            }
            
        }

        #endregion

    }
}
