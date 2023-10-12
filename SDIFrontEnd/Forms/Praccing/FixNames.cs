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
    public partial class FixNames : Form
    {
        List<StringPair> Names;
        public FixNames(List<StringPair> toFix)
        {
            InitializeComponent();

            Names = toFix;

            FillBoxes();

            SetupGrid();
        }

        #region Form Setup
        private void FillBoxes()
        {
            chValid.ValueMember = "Name";
            chValid.DisplayMember = "Name";
            chValid.DataSource = new List<Person>(Globals.AllPeople);
        }

        private void SetupGrid()
        {
            chValid.DataPropertyName = "String2";
            chInvalid.DataPropertyName = "String1";
            dgvNames.AutoGenerateColumns = false;
            dgvNames.DataSource = Names;
        }
        #endregion

        #region Events
        private void cmdDone_Click(object sender, EventArgs e)
        {
            //foreach (StringPair sp in Names)
            //{
            //    if (string.IsNullOrEmpty(sp.Valid))
            //    {
            //        MessageBox.Show("Some names are not blank.");
            //        return;
            //    }
            //}
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion
    }
}
