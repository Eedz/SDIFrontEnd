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
    public partial class CanonVarsEntry : Form
    {
        private List<CanonicalVariableRecord> Records;
        BindingSource bs;

        public CanonVarsEntry(List<CanonicalVariableRecord> records)
        {
            InitializeComponent();

            Records = records;
            bs = new BindingSource()
            {
                DataSource = Records
            };
            
            repeaterRecords.DataSource = bs;

            txtRefVarName.DataBindings.Add("Text", bs, "RefVarName");
            txtNotes.DataBindings.Add("Text", bs, "Notes");
            chkActive.DataBindings.Add("Checked", bs, "Active");
            chkAnySuffix.DataBindings.Add("Checked", bs, "AnySuffix");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            FormManager.Remove(this);
        }

        

        private void Control_Validated(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            Microsoft.VisualBasic.PowerPacks.DataRepeaterItem item = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)c.Parent;

            var datasource = ((BindingSource)repeaterRecords.DataSource);
            int index = repeaterRecords.CurrentItemIndex;
            CanonicalVariableRecord itemRecord = (CanonicalVariableRecord)datasource[index];
                           
            
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
                DBAction.DeleteRecord(itemRecord);
                
            }
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
