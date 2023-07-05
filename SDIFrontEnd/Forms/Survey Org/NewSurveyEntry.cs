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
    public partial class NewSurveyEntry : Form
    {
        
        public SurveyRecord NewSurvey;
        List<StudyWave> WaveList;
        BindingSource bs;

        public NewSurveyEntry()
        {
            InitializeComponent();

            NewSurvey = new SurveyRecord();
            WaveList = new List<StudyWave>(Globals.AllWaves);

            SetupBindingSources();

            FillBoxes();

            BindProperties();
        }

        private void cmdNewWave_Click(object sender, EventArgs e)
        {
            AddWave();
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
            bs.DataSource = NewSurvey;
            bs.DataMember = "Item";
        }

        private void FillBoxes()
        {
            cboWaveID.DisplayMember = "WaveCode";
            cboWaveID.ValueMember = "ID";
            cboWaveID.DataSource = WaveList;

            var modes = new List<SurveyMode>(DBAction.GetModeInfo());
            modes.Insert(0, new SurveyMode());
            cboMode.DisplayMember = "ModeAbbrev";
            cboMode.ValueMember = "ID";
            cboMode.DataSource = modes;

            cboSurveyType.DisplayMember = "Cohort";
            cboSurveyType.ValueMember = "ID";
            cboSurveyType.DataSource = new List<SurveyCohortRecord>(Globals.AllCohorts);
            
            cboCopyQuestions.ValueMember = "SID";
            cboCopyQuestions.DisplayMember = "SurveyCode";
            cboCopyQuestions.DataSource = new List<Survey>(Globals.AllSurveys);
            cboCopyQuestions.SelectedItem = null;
        }

        private void BindProperties()
        {
            txtID.DataBindings.Add(new Binding("Text", bs, "SID"));
            txtSurveyCode.DataBindings.Add("Text", bs, "SurveyCode");
            txtSurveyTitle.DataBindings.Add("Text", bs, "Title");

            cboMode.DataBindings.Add("SelectedItem", bs, "Mode");

            cboSurveyType.DataBindings.Add("SelectedItem", bs, "Cohort");

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

        private void AddWave()
        {
            NewWaveEntry frm = new NewWaveEntry();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                WaveList.Add(frm.NewWave.Item);
                cboWaveID.DataSource = null;
                cboWaveID.DataSource = WaveList;
                cboWaveID.SelectedValue = frm.NewWave.Item.ID;
            }
        }

        private int SaveRecord()
        {
            if (NewSurvey.Item.Mode.ID == 0)
            {
                MessageBox.Show("Please select a valid mode.");
                return 1;
            }

            if (NewSurvey.Item.Cohort.ID == 0)
            {
                MessageBox.Show("Please select a valid survey type.");
                return 1;
            }

            if (DBAction.InsertSurvey(NewSurvey.Item) == 1)
            {
                MessageBox.Show("Error creating survey.");
                return 1;
            }

            var wave = Globals.AllWaves.Where(x => x.ID == NewSurvey.Item.WaveID).First();
            NewSurvey.Item.CountryCode = Globals.AllStudies.Where(x => x.ID == wave.StudyID).First().CountryCode.ToString("00");
            Globals.AllSurveys.Add(NewSurvey.Item);

            if (cboCopyQuestions.SelectedItem != null)
                DBAction.CopySurvey(((Survey)cboCopyQuestions.SelectedItem).SurveyCode, NewSurvey.Item.SurveyCode);

            return 0;
        }

        
    }
}
