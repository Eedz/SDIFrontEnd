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
    public partial class CanonVarsEntry : Form
    {
        private List<CanonicalVariableRecord> Records;
        BindingSource bs;

        public CanonVarsEntry(List<CanonicalRefVarName> records)
        {
            InitializeComponent();

            Records = new List<CanonicalVariableRecord>();
            foreach (CanonicalRefVarName record in records)
            {
                Records.Add(new CanonicalVariableRecord(record));
            }

            bs = new BindingSource()
            {
                DataSource = Records                
            };
           
            repeaterRecords.DataSource = bs;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FM.FormManager.Remove(this);
        }

        

        private void Control_Validated(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            Microsoft.VisualBasic.PowerPacks.DataRepeaterItem item = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)c.Parent;

            var datasource = ((BindingSource)repeaterRecords.DataSource);
            int index = repeaterRecords.CurrentItemIndex;
            CanonicalVariableRecord itemRecord = (CanonicalVariableRecord)datasource[index];

            var refvarname = (TextBox)item.Controls.Find("txtRefVarName", false)[0];
            itemRecord.Item.RefVarName = refvarname.Text;

            var active = (CheckBox)item.Controls.Find("chkActive", false)[0];
            itemRecord.Item.Active = active.Checked;

            var anysuffix = (CheckBox)item.Controls.Find("chkAnySuffix", false)[0];
            itemRecord.Item.AnySuffix = anysuffix.Checked;

            var notes = (TextBox)item.Controls.Find("txtNotes", false)[0];
            itemRecord.Item.Notes = notes.Text;

            itemRecord.Dirty = true;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            repeaterRecords.AddNew();

            var datasource = ((BindingSource)repeaterRecords.DataSource);
            int index = repeaterRecords.CurrentItemIndex;
            CanonicalVariableRecord itemRecord = (CanonicalVariableRecord)datasource[index];

            itemRecord.NewRecord = true;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var datasource = ((BindingSource)repeaterRecords.DataSource);
                int index = repeaterRecords.CurrentItemIndex;
                CanonicalVariableRecord itemRecord = (CanonicalVariableRecord)datasource[index];
                bs.RemoveAt(index);
                DBAction.DeleteRecord(itemRecord.Item);                
            }
        }

        private void repeaterRecords_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)sender;
            var datasource = ((BindingSource)dataRepeater.DataSource);
            var currentRecord = ((CanonicalVariableRecord)datasource[e.DataRepeaterItem.ItemIndex]);

            var refvarname = (TextBox)e.DataRepeaterItem.Controls.Find("txtRefVarName", false)[0];
            refvarname.Text = currentRecord.Item.RefVarName;

            var active = (CheckBox)e.DataRepeaterItem.Controls.Find("chkActive", false)[0];
            active.Checked = currentRecord.Item.Active;

            var anysuffix = (CheckBox)e.DataRepeaterItem.Controls.Find("chkAnySuffix", false)[0];
            anysuffix.Checked = currentRecord.Item.AnySuffix;

            var notes = (TextBox)e.DataRepeaterItem.Controls.Find("txtNotes", false)[0];
            notes.Text = currentRecord.Item.Notes;
        }

        private void repeaterRecords_ItemTemplate_Leave(object sender, EventArgs e)
        {
            var item = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)sender;
            var datasource = ((BindingSource)repeaterRecords.DataSource);
            int index = repeaterRecords.CurrentItemIndex;
            CanonicalVariableRecord itemRecord = (CanonicalVariableRecord)datasource[index];

            if (item.IsDirty) itemRecord.Dirty = true;

            item.BackColor = SystemColors.Control;           
        }

        private void repeaterRecords_ItemTemplate_Enter(object sender, EventArgs e)
        {
            var item = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)sender;
            item.BackColor = Color.AliceBlue;
        }

        private void repeaterRecords_ItemTemplate_Validated(object sender, EventArgs e)
        {
            var item = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)sender;
            var datasource = ((BindingSource)repeaterRecords.DataSource);
            int index = repeaterRecords.CurrentItemIndex;
            CanonicalVariableRecord itemRecord = (CanonicalVariableRecord)datasource[index];

            if (itemRecord.SaveRecord() == 1)
            {
                MessageBox.Show("Error saving this record. Ensure that at least the refVarName value is not empty.");
                return;
            }
        }

        
    }
}
