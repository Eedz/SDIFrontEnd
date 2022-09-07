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
    public partial class UnlockSurvey : Form
    {
        List<LockedSurveyRecord> Records;

        public UnlockSurvey()
        {
            InitializeComponent();

            SetupForm();

            // get locked surveys
            dgvLockedSurveys.AutoGenerateColumns = false;
            LoadRecords();

            Timer timer = new Timer();
            timer.Interval = (60 * 1000); // 60 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        #region Events

        /// <summary>
        /// We won't actually close the form. It will remain open and continue checking for surveys to lock again.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
            foreach (LockedSurveyRecord record in Records)
            {
                if (record.UnlockedForMin <= 0)
                {
                    DBAction.LockSurvey(new Survey(record.SurveyCode));
                    (Globals.AllSurveys.First(x => x.SurveyCode.Equals(record.SurveyCode))).Locked = true;
                }
            }
            IEnumerable<LockedSurveyRecord> toRemove = Records.Where(x => x.UnlockedForMin <= 0);
            foreach (LockedSurveyRecord record in toRemove)
                Records.Remove(record);
            
            dgvLockedSurveys.Refresh();
        }

        

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (rbSurvey.Checked)
            {
                foreach (Survey s in lstAllSurveys.SelectedItems)
                    lstSelected.Items.Add(s);
            }
            else if (rbWave.Checked)
            {
                foreach (StudyWaveRecord w in lstAllSurveys.SelectedItems)
                    foreach (SurveyRecord s in w.Surveys)
                        lstSelected.Items.Add(s);
            }
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {

            if (lstSelected.SelectedItem == null)
                return;

            int index = lstSelected.SelectedIndex;

            lstSelected.Items.Remove(lstSelected.SelectedItem);

            if (lstSelected.Items.Count == 0)
                return;
            else if (index >= lstSelected.Items.Count)
                lstSelected.SelectedIndex = lstSelected.Items.Count - 1;
            else
                lstSelected.SelectedIndex = index;

        }

        private void cmdUnlock_Click(object sender, EventArgs e)
        {
            if (lstSelected.Items.Count == 0)
                return;

            int interval = GetInterval();
            
            UnlockSurveys(lstSelected.Items.Cast<Survey>().ToList(), interval);

            LoadRecords();   
        }

        private void rbSurvey_Click(object sender, EventArgs e)
        {
            lstAllSurveys.DataSource = null;
            lstAllSurveys.DisplayMember = "SurveyCode";
            lstAllSurveys.ValueMember = "SID";
            lstAllSurveys.DataSource = new List<Survey>(Globals.AllSurveys);
        }

        private void rbWave_Click(object sender, EventArgs e)
        {
            lstAllSurveys.DataSource = null;
            lstAllSurveys.DisplayMember = "WaveCode";
            lstAllSurveys.ValueMember = "ID";
            lstAllSurveys.DataSource = new List<StudyWaveRecord>(Globals.AllWaves);
        }
        #endregion

        #region Methods 
        private void LoadRecords()
        {
            Records = DBAction.GetUserLockedSurveys();
            dgvLockedSurveys.DataSource = Records;
        }

        private void UnlockSurveys(List<Survey> surveys, int interval)
        {
            foreach (Survey s in lstSelected.Items)
            {
                DBAction.UnlockSurvey(s.SurveyCode, interval);
                s.Locked = false;
            }


        }

        private int GetInterval()
        {
            if (rb1Hour.Checked)
            {
                return 60;
            }
            else if (rb4Hours.Checked)
            {
                return 240;
            }
            else if (rb8Hours.Checked)
            {
                return 480;
            }
            else
            {
                return 60;
            }
        }

        private void SetupForm()
        {
            lstAllSurveys.DisplayMember = "SurveyCode";
            lstAllSurveys.ValueMember = "SID";
            lstAllSurveys.DataSource = Globals.AllSurveys;

            lstSelected.DisplayMember = "SurveyCode";
            lstSelected.ValueMember = "SID";


            chSurvey.DataPropertyName = "SurveyCode";
            chTime.DataPropertyName = "UnlockedForMin";
            chName.DataPropertyName = "Name";
        }
        #endregion
    }
}
