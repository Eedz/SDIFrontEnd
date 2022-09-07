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
    public partial class NewRegionEntry : Form
    {
        public RegionRecord NewRegion;
        BindingSource bs;

        public NewRegionEntry()
        {
            NewRegion = new RegionRecord();
            InitializeComponent();
            bs = new BindingSource();
            bs.DataSource = NewRegion;

            txtID.DataBindings.Add(new Binding("Text", bs, "ID"));
            txtRegionName.DataBindings.Add(new Binding("Text", bs, "RegionName"));
            txtTempVarPrefix.DataBindings.Add(new Binding("Text", bs, "TempVarPrefix"));
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (DBAction.InsertRegion(NewRegion) == 1)
            {
                MessageBox.Show("Error creating new region.");
                return;
            }
            Globals.AllRegions.Add(NewRegion);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
