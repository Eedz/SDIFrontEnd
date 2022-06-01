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
    public partial class NewSurveyEntry : Form
    {
        // TODO auto fill file name
        public SurveyRecord NewSurvey;
        List<StudyWaveRecord> WaveList;
        BindingSource bs;

        public NewSurveyEntry()
        {
            InitializeComponent();

            NewSurvey = new SurveyRecord();
            WaveList = Globals.AllWaves;

            bs = new BindingSource();
            bs.DataSource = NewSurvey;

            FillBoxes();

            BindProperties();
        }

        private void NewSurveyEntry_Load(object sender, EventArgs e)
        {

        }

        private void FillBoxes()
        {
            cboWaveID.DataSource = WaveList;
            cboWaveID.DisplayMember = "WaveCode";
            cboWaveID.ValueMember = "ID";

            cboMode.DataSource = DBAction.GetModeInfo();
            cboMode.DisplayMember = "ModeAbbrev";
            cboMode.ValueMember = "ID";

            cboSurveyType.DataSource = DBAction.GetCohortInfo();
            cboSurveyType.DisplayMember = "Cohort";
            cboSurveyType.ValueMember = "ID";
        }

        private void BindProperties()
        {
            // survey info
            txtID.DataBindings.Add(new Binding("Text", bs, "SID"));
            txtSurveyCode.DataBindings.Add("Text", bs, "SurveyCode");
            txtSurveyTitle.DataBindings.Add("Text", bs, "Title");

            cboMode.DataBindings.Add("SelectedValue", bs, "Mode.ID");

            cboSurveyType.DataBindings.Add("SelectedValue", bs, "Cohort.ID");

            txtFileName.DataBindings.Add("Text", bs, "WebName");

            //Binding b = new Binding("Value", bs, "CreationDate", true, DataSourceUpdateMode.OnPropertyChanged);
            //dtpCreationDate.DataBindings.Add(b);
            //b.Format += new ConvertEventHandler(dtp_Format);
            //b.Parse += new ConvertEventHandler(dtp_Parse);

            dtpCreationDate.DataBindings.Add(new Binding("Value", bs, "CreationDate", true));

            chkNCT.DataBindings.Add("Checked", bs, "NCT");
            chkHideSurvey.DataBindings.Add("Checked", bs, "HideSurvey");
            chkITCSurvey.DataBindings.Add("Checked", bs, "ITCSurvey");

            // study info
            cboWaveID.DataBindings.Add("SelectedValue", bs, "WaveID");
        }

        private void cmdNewWave_Click(object sender, EventArgs e)
        {
            NewWaveEntry frm = new NewWaveEntry();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                WaveList.Add(frm.NewWave);
                cboWaveID.DataSource = null;
                cboWaveID.DataSource = WaveList;
                cboWaveID.SelectedValue = frm.NewWave.ID;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (NewSurvey.Mode.ID ==0 )
            {
                MessageBox.Show("Please select a valid mode.");
                return;
            }

            if (NewSurvey.Cohort.ID == 0)
            {
                MessageBox.Show("Please select a valid survey type.");
                return;
            }

            if (DBAction.InsertSurvey(NewSurvey)==1)
            {
                MessageBox.Show("Error creating survey.");
                return;
            }

            var wave = Globals.AllWaves.Where(x => x.ID == NewSurvey.WaveID).First();
            NewSurvey.CountryCode = Globals.AllStudies.Where(x => x.ID == wave.StudyID).First().CountryCode.ToString("00");

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
