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
    /// <summary>
    /// This form shows the details for each Survey in the database.
    /// IDEA: Create a list of all studies, which have their own waves, which have their own surveys
    /// then, each survey is listed, and the study info is listed off to the side for additional info
    /// </summary>
    public partial class SurveyDetails : Form
    {
        public MainMenu frmParent;
        public string key;
        List<Study> Studies;
        List<StudyWave> StudyWaves;
        List<Survey> Surveys;
      
        BindingSource bs;
        BindingSource StudyBS;
        BindingSource WaveBS;

        private bool _dirty;
        private bool Dirty
        {
            get
            {
                return _dirty;
            }
            set
            {
                _dirty = value;
                if (_dirty)
                {
                    lblTitle.Text = "Survey Details*";
                }
                else
                {
                    lblTitle.Text = "Survey Details";
                }
            }
        }

        public SurveyDetails()
        {
            InitializeComponent();
            this.MouseWheel += SurveyDetails_OnMouseWheel;

            Studies = DBAction.GetStudyInfo();
            StudyWaves = DBAction.GetWaveInfo();
            
            Surveys = DBAction.GetAllSurveys();
            

            // bind

            bs = new BindingSource
            {
                DataSource = Surveys
            };

            bs.ListChanged += SurveyDetails_ListChanged;

            bindingNavigator1.BindingSource = bs;
            bindingNavigator1.BindingSource.PositionChanged += SurveyBindingSource_PositionChanged;

            StudyBS = new BindingSource()
            {
                DataSource = Studies
            };
            //navStudyWave.BindingSource = StudyBS;

            WaveBS = new BindingSource()
            {
                DataSource = Studies,
                DataMember = "Waves"

            };
            navStudyWave.BindingSource = StudyBS;

            cboCountryCode.DisplayMember = "CountryCode";
            cboCountryCode.ValueMember = "StudyID";
            cboCountryCode.DataSource = DBAction.GetStudyInfo();

            cboSurveyMode.DataSource = DBAction.GetModeInfo();
            cboSurveyMode.DisplayMember = "ModeAbbrev";
            cboSurveyMode.ValueMember = "ID";

            cboUserGroup.DataSource = DBAction.GetGroupInfo();
            cboUserGroup.DisplayMember = "UserGroup";
            cboUserGroup.ValueMember = "ID";

            cboCohort.DataSource = DBAction.GetCohortInfo();
            cboCohort.DisplayMember = "Cohort";
            cboCohort.ValueMember = "ID";

            BindProperties();
        }

        private void BindProperties()
        {
            // survey info
            txtID.DataBindings.Add(new Binding("Text", bs, "SID"));
            txtSurveyCode.DataBindings.Add("Text", bs, "SurveyCode");
            txtSurveyTitle.DataBindings.Add("Text", bs, "Title");

            cboSurveyMode.DataBindings.Add("SelectedValue", bs, "Mode.ID");
            cboUserGroup.DataBindings.Add("SelectedValue", bs, "Group.ID");
            //  cboCohort.DataBindings.Add("SelectedItem", bs, "Cohort.ID");

            txtFileName.DataBindings.Add("Text", bs, "WebName");
            txtCreationDate.DataBindings.Add("Text", bs, "CreationDate");
            txtLanguages.DataBindings.Add("Text", bs, "Languages");

            chkNCT.DataBindings.Add("Checked", bs, "NCT");
            chkReRun.DataBindings.Add("Checked", bs, "ReRun");
            chkHideSurvey.DataBindings.Add("Checked", bs, "HideSurvey");
            chkLocked.DataBindings.Add("Checked", bs, "Locked");
            chkEnglishRouting.DataBindings.Add("Checked", bs, "EnglishRouting");


            // study info
            txtStudyName.DataBindings.Add("Text", StudyBS, "StudyName");
            cboCountryCode.DataBindings.Add("SelectedValue", StudyBS, "StudyID");
            txtStudyWave.DataBindings.Add("Text", WaveBS, "Wave");
        }

        private void SurveyDetails_ListChanged(object sender, ListChangedEventArgs e)
        {
            Dirty = true;
        }

        private void SurveyDetails_Load(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SurveyDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmParent.CloseTab(key);
        }

        private void cboCountryCode_Format(object sender, ListControlConvertEventArgs e)
        {
            Study r = ((Study)e.ListItem);
            e.Value = r.CountryCode.ToString("00") + " - " + r.StudyName + " - " + r.ISO_Code;
        }

        protected void SurveyDetails_OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == -120)
                bs.MoveNext();
            else if (e.Delta == 120)
            {
                bs.MovePrevious();
            }

        }

        private void SurveyBindingSource_PositionChanged(object sender, EventArgs e)
        {
            bindingNavigator1.Validate();

            BindingSource bs = (BindingSource)sender;
            Survey s = (Survey)bs.Current;
            int studyLoc = 0;
            int waveLoc = 0;
            bool found = false;
          
            //for (int i = 0; i < Studies.Count; i++)
            //{
            //    waveLoc = 0;
            //    for (int w = 0; w < Studies[i].Waves.Count; w++)
            //    {
            //        if (s.WaveID == Studies[i].Waves[w].WaveID)
            //        {
                        
            //            found = true;
            //            break;
            //        }
            //        else
            //            waveLoc++;

            //    }
            //    if (found)
            //        break;
            //    else
            //        studyLoc++;

            //}

            StudyBS.Position = studyLoc;
            WaveBS.Position = waveLoc;
        }


        

    }
}
