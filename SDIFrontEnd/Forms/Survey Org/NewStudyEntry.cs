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
    public partial class NewStudyEntry : Form
    {
        public StudyRecord NewStudy;
        List<RegionRecord> RegionList;
        BindingSource bs;

        public NewStudyEntry()
        {
            InitializeComponent();

            NewStudy = new StudyRecord();
            bs = new BindingSource();
            bs.DataSource = NewStudy;

            RegionList = Globals.AllRegions;

            FillBoxes();
            BindProperties();
        }

        public NewStudyEntry(List<RegionRecord> regions)
        {
            InitializeComponent();

            NewStudy = new StudyRecord();
            bs = new BindingSource();
            bs.DataSource = NewStudy;

            RegionList = regions;

            FillBoxes();
            BindProperties();
        }

        private void FillBoxes()
        {
            cboRegion.DataSource = RegionList;
            cboRegion.DisplayMember = "RegionName";
            cboRegion.ValueMember = "ID";

            cboAgeGroup.Items.Add("");
            cboAgeGroup.Items.Add("Adult");
            cboAgeGroup.Items.Add("Mixed");
            cboAgeGroup.Items.Add("Youth");
        }

        private void BindProperties()
        {
            // survey info
            txtID.DataBindings.Add(new Binding("Text", bs, "ID"));
            cboRegion.DataBindings.Add("SelectedValue", bs, "RegionID");
            txtStudyName.DataBindings.Add("Text", bs, "StudyName");
            txtCountry.DataBindings.Add("Text", bs, "CountryName");

            txtISOCode.DataBindings.Add("Text", bs, "ISO_Code");
            txtCC.DataBindings.Add("Text", bs, "CountryCode");
            txtCohort.DataBindings.Add("Text", bs, "Cohort");

            cboAgeGroup.DataBindings.Add("SelectedItem", bs, "AgeGroup");

            txtLanguages.DataBindings.Add(new Binding("Text", bs, "Languages"));


        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (DBAction.InsertCountry(NewStudy) == 1)
            {
                MessageBox.Show("Error creating new wave.");
                return;
            }
            Globals.AllStudies.Add(NewStudy);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmdAddRegion_Click(object sender, EventArgs e)
        {
            AddRegion();
        }

        private void AddRegion()
        {
            NewRegionEntry frm = new NewRegionEntry();

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                cboRegion.DataSource = null;
                cboRegion.DataSource = new List<RegionRecord>( Globals.AllRegions);
                cboRegion.DisplayMember = "RegionName";
                cboRegion.ValueMember = "ID";
                cboRegion.SelectedItem = frm.NewRegion;
            }


        }
    }
}
