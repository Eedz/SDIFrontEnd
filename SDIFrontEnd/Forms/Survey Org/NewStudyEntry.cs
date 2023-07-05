using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

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
        List<Region> RegionList;
        BindingSource bs;

        public NewStudyEntry()
        {
            InitializeComponent();

            NewStudy = new StudyRecord();

            SetupBindingSources();

            RegionList = new List<Region>(Globals.AllRegions);

            FillBoxes();
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

        private void cmdAddRegion_Click(object sender, EventArgs e)
        {
            AddRegion();
        }

        private void SetupBindingSources()
        {
            bs = new BindingSource();
            bs.DataSource = NewStudy.Item;
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

        private int SaveRecord()
        {
            if (DBAction.InsertCountry(NewStudy.Item) == 1)
            {
                MessageBox.Show("Error creating new study.");
                return 1;
            }
            Globals.AllStudies.Add(NewStudy.Item);
            return 0;
        }

        private void AddRegion()
        {
            NewRegionEntry frm = new NewRegionEntry();

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                cboRegion.DataSource = null;
                cboRegion.DataSource = new List<Region>( Globals.AllRegions);
                cboRegion.DisplayMember = "RegionName";
                cboRegion.ValueMember = "ID";
                cboRegion.SelectedItem = frm.NewRegion;
            }
        }
    }
}
