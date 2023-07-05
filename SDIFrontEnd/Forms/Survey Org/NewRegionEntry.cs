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
            InitializeComponent();

            NewRegion = new RegionRecord();

            SetupBindingSources();

            BindProperties();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (SaveRecord() == 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SetupBindingSources()
        {
            bs = new BindingSource();
            bs.DataSource = NewRegion.Item;
        }

        private void BindProperties()
        {
            txtID.DataBindings.Add(new Binding("Text", bs, "ID"));
            txtRegionName.DataBindings.Add(new Binding("Text", bs, "RegionName"));
            txtTempVarPrefix.DataBindings.Add(new Binding("Text", bs, "TempVarPrefix"));
        }

        private int SaveRecord()
        {
            if (DBAction.InsertRegion(NewRegion.Item) == 1)
            {
                MessageBox.Show("Error creating new region.");
                return 1;
            }
            Globals.AllRegions.Add(NewRegion.Item);
            return 0;
        }
    }
}
