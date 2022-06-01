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
    public partial class VarNameChangeQuickEntry : Form
    {
        List<VarNameChangeRecord> records;
        VarNameChangeRecord CurrentRecord;
        BindingSource bs;

        public VarNameChangeQuickEntry(List<VarNameChangeRecord> list)
        {

            InitializeComponent();

            records = list;
            bs = new BindingSource()
            {
                DataSource = bs
            };

            bs.PositionChanged += Bs_PositionChanged;

            dgvSurveys.DataSource = bs;
            dgvSurveys.DataMember = "SurveysAffected";

            dgvNotifications.DataSource = bs;
            dgvNotifications.DataMember = "Notifications";

            bindingNavigator1.BindingSource = bs;

            BindProperties();
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            CurrentRecord = (VarNameChangeRecord)bs.Current;
        }

        private void BindProperties()
        {
            txtOldName.DataBindings.Add("Text", bs, "OldName");
            txtNewName.DataBindings.Add("Text", bs, "NewName");
            dtpChangeDate.DataBindings.Add("Value", bs, "ChangeDate", true);
            cboChangedBy.DataBindings.Add("SelectedItem", bs, "ChangedBy");
            txtAuthorization.DataBindings.Add("Text", bs, "Authorization");
            txtRationale.DataBindings.Add("Text", bs, "Rationale");
            txtSource.DataBindings.Add("Text", bs, "Source");
            chkPreFWS.DataBindings.Add("Checked", bs, "HiddenChange");

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveAll()
        {
            foreach(VarNameChangeRecord r in records)
            {
                r.SaveRecord();
            }
        }

        private void dgvSurveys_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            VarNameChangeSurveyRecord theRow = (VarNameChangeSurveyRecord)e.Row.DataBoundItem;
            theRow.ChangeID = CurrentRecord.ID;
        }

        private void dgvNotifications_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            VarNameChangeNotificationRecord theRow = (VarNameChangeNotificationRecord)e.Row.DataBoundItem;
            theRow.ChangeID = CurrentRecord.ID;
        }

        private void dgvSurveys_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSurveys.IsCurrentRowDirty)
            {
                VarNameChangeSurveyRecord theRow = (VarNameChangeSurveyRecord)dgvSurveys.Rows[e.RowIndex].DataBoundItem;
                theRow.Dirty = true;
            }
        }

        private void dgvNotifications_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNotifications.IsCurrentRowDirty)
            {
                VarNameChangeNotificationRecord theRow = (VarNameChangeNotificationRecord)dgvNotifications.Rows[e.RowIndex].DataBoundItem;
                theRow.Dirty = true;
            }
        }

        private void dgvSurveys_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvNotifications_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
