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
using System.Text.RegularExpressions;

namespace ISISFrontEnd
{

    public partial class VariableListReportForm : Form
    {
        enum Exclusions { Headings, BIScripts, Screeners, NonStdVars }
        enum Inclusions {  RespOptions, NRCodes , FmtNames, VarName, Topic, Content, VarLabel }

        public VariableListReportForm()
        {
            InitializeComponent();

            FillLists();

            for (int i = 0; i<lstExclusions.Items.Count; i++)
            {
                lstExclusions.SetSelected(i, true);
            }

            lstInclusions.SetSelected(0, false);
            lstInclusions.SetSelected(lstInclusions.Items.Count - 1, true);

            lstStudy.SelectedIndexChanged += lstStudy_SelectedIndexChanged;
            lstStudyWave.SelectedIndexChanged += lstStudyWave_SelectedIndexChanged;
            lstSurvey.SelectedIndexChanged += lstSurvey_SelectedIndexChanged;

            UpdateVarList();
        }

        #region Events
        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            DataTable crosstab = new DataTable();

            if (rbByWave.Checked)
            {
                // by wave
                if (lstStudy.GetSelected(0) && lstStudyWave.GetSelected(0))
                {
                    // all surveys, too many varnames and columns, cancel report
                    MessageBox.Show("Too many waves and varnames to show. Please narrow your report.");
                    return;
                }

                crosstab = GenerateWaveVarList();
            }
            else if (rbBySurvey.Checked)
            {
                // by survey
                if (lstStudy.GetSelected(0) && lstStudyWave.GetSelected(0) && lstSurvey.GetSelected(0))
                {
                    // all surveys, too many varnames and columns, cancel report
                    MessageBox.Show("Too many surveys and varnames to show. Please narrow your report.");
                    return;
                }

                crosstab = GenerateSurveyVarList();
            }

            if (crosstab.Rows.Count==0)
            {
                MessageBox.Show("Error generating the report. No records to show.");
                return;
            }

            DataTableReport rpt; 
            if (rbBySurvey.Checked)
                rpt = new DataTableReport(crosstab, "Variable List - " + string.Join(", ", GetSurveys()));
            else if (rbByWave.Checked)
                rpt = new DataTableReport(crosstab, "Variable List - " + string.Join(", ", GetWaves()));
            else
                rpt = new DataTableReport(crosstab, "Variable List");

            rpt.CreateReport();
        }

        private void TypeChanged_Click(object sender, EventArgs e)
        {
            lstSurvey.Enabled = rbBySurvey.Checked;
        }

        private void lstStudy_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListBox lst = (ListBox)sender;

            // only the <All> option is in the box
            if (lst.Items.Count == 1)
                return;

            lst.SelectedIndexChanged -= lstStudy_SelectedIndexChanged;

            if (lst.SelectedItems.Count == 0)
            {
                lst.SetSelected(0, true);
                lst.Tag = true;
            }

            int count = lst.SelectedItems.Count;

            if (count > 1 && (bool)lst.Tag)
            {
                lst.SelectedItems.Remove(lst.Items[0]);
                lst.Tag = false;
            }
            else if (count > 1 && lst.SelectedIndices.Contains(0))
            {
                lst.SelectedItems.Clear();
                lst.SelectedItems.Add(lst.Items[0]);
                lst.Tag = true;
            }

            lst.SelectedIndexChanged += lstStudy_SelectedIndexChanged;

            UpdateWaveList();

        }

        private void lstStudyWave_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lst = (ListBox)sender;

            // only the <All> option is in the box
            if (lst.Items.Count == 1)
                return;

            lst.SelectedIndexChanged -= lstStudyWave_SelectedIndexChanged;

            if (lst.SelectedItems.Count == 0)
            {
                lst.SetSelected(0, true);
                lst.Tag = true;
            }

            int count = lst.SelectedItems.Count;

            if (count > 1 && (bool)lst.Tag)
            {
                lst.SelectedItems.Remove(lst.Items[0]);
                lst.Tag = false;
            }
            else if (count > 1 && lst.SelectedIndices.Contains(0))
            {
                lst.SelectedItems.Clear();
                lst.SelectedItems.Add(lst.Items[0]);
                lst.Tag = true;
            }

            lst.SelectedIndexChanged += lstStudyWave_SelectedIndexChanged;

            UpdateSurveyList();
        }

        private void lstSurvey_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lst = (ListBox)sender;

            // only the <All> option is in the box
            
            if (lst.Items.Count == 1)
                return;

            lst.SelectedIndexChanged -= lstSurvey_SelectedIndexChanged;

            if (lst.SelectedItems.Count == 0)
            {
                lst.SetSelected(0, true);
                lst.Tag = true;
            }

            int count = lst.SelectedItems.Count;

            if (count > 1 && (bool)lst.Tag)
            {
                lst.SelectedItems.Remove(lst.Items[0]);
                lst.Tag = false;
            }
            else if (count > 1 && lst.SelectedIndices.Contains(0))
            {
                lst.SelectedItems.Clear();
                lst.SelectedItems.Add(lst.Items[0]);
                lst.Tag = true;
            }

            lst.SelectedIndexChanged += lstSurvey_SelectedIndexChanged;
            UpdateVarList();
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lst = (ListBox)sender;

            // only the <All> option is in the box
            if (lst.Items.Count == 1)
                return;

            lst.SelectedIndexChanged -= ListBox_SelectedIndexChanged;

            int count = lst.SelectedItems.Count;

            if (count > 1 && (bool)lst.Tag)
            {
                lst.SelectedItems.Remove(lst.Items[0]);
                lst.Tag = false;
            }
            else if (count > 1 && lst.SelectedIndices.Contains(0))
            {
                lst.SelectedItems.Clear();
                lst.SelectedItems.Add(lst.Items[0]);
                lst.Tag = true;
            }

            lst.SelectedIndexChanged += ListBox_SelectedIndexChanged;
        }

        private void cmdAddVar_Click(object sender, EventArgs e)
        {
            string var = (string)cboVarNameBox.SelectedItem;
            if (string.IsNullOrEmpty(var)) return;
            cboVarNameBox.SelectedIndex++;
            if (!lstVarName.Items.Contains(var))
                lstVarName.Items.Add(var);
        }

        private void cmdRemoveVar_Click(object sender, EventArgs e)
        {
            var item = lstVarName.SelectedItem;

            if (item == null) return;

            if (lstVarName.Items.Count == 0)
                lstVarName.SelectedIndex = -1;
            if (lstVarName.SelectedIndex == lstVarName.Items.Count - 1)
                lstVarName.SelectedIndex--;
            else
                lstVarName.SelectedIndex++;
            lstVarName.Items.Remove(item);

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void VariableListReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormManager.RemovePopup(this);
        }
        #endregion


        private DataTable GenerateSurveyVarList()
        {
            DataTable crosstab = new DataTable();

            List<string> surveys = GetSurveys();
            if (surveys.Count == 0)
                return crosstab;

            List<string> inclusions = GetInclusions();
            List<string> exclusions = GetExclusions();          
            List<string> vars = GetVars();

            crosstab = DBAction.GetSurveysVariableList(surveys, vars, inclusions, exclusions);

            

            // remove screeners from results
            foreach (KeyValuePair<int, string> item in lstExclusions.SelectedItems)
            {
                Exclusions i = (Exclusions)Enum.ToObject(typeof(Exclusions), item.Key);

                switch (i)
                {
                    case Exclusions.Screeners:

                        for (int c = crosstab.Columns.Count - 1; c >= 0; c--)
                            if (crosstab.Columns[c].ColumnName.Contains("-sc"))
                                crosstab.Columns.RemoveAt(c);
                        break;
                }
            }

            // change 0s and 1s
            foreach (DataRow r in crosstab.Rows)
            {
                foreach (DataColumn c in crosstab.Columns)
                {
                    if (surveys.Contains(c.ColumnName))
                    {
                        if (r[c].Equals("0"))
                            r[c] = string.Empty;
                    }
                }
            }

            // add totals row
            DataRow totalsRow = crosstab.NewRow();
            totalsRow[0] = "Total";
            for (int c = 0; c < crosstab.Columns.Count ;  c++)
                if (surveys.Contains(crosstab.Columns[c].ColumnName))
                {
                    int count = 0;
                    foreach(DataRow r in crosstab.Rows)
                    {
                        if (!string.IsNullOrEmpty(r[c].ToString()))
                            count++;
                    }
                    totalsRow[c] = count;
                }

            crosstab.Rows.InsertAt(totalsRow,0);

            return crosstab;
        }

        private DataTable GenerateWaveVarList()
        {
            DataTable crosstab = new DataTable();

            List<string> waves = GetWaves();
            if (waves.Count == 0)
                return crosstab;

            List<string> inclusions = GetInclusions();
            List<string> exclusions = GetExclusions();
            List<string> vars = GetVars();


            crosstab = DBAction.GetWavesVariableList(waves, vars, inclusions, exclusions);

            // change 0s and 1s
            foreach (DataRow r in crosstab.Rows)
            {
                foreach (DataColumn c in crosstab.Columns)
                {
                    if (waves.Contains(c.ColumnName))
                    {
                        if (r[c].Equals("0"))
                            r[c] = "";
                        else
                            r[c] = "\u2713";
                    }
                }
            }

            // add totals row
            DataRow totalsRow = crosstab.NewRow();
            totalsRow[0] = "Total";
            for (int c = 0; c < crosstab.Columns.Count; c++)
                if (waves.Contains(crosstab.Columns[c].ColumnName))
                {
                    int count = 0;
                    foreach (DataRow r in crosstab.Rows)
                    {
                        if (r[c].Equals("\u2713"))
                            count++;
                    }
                    totalsRow[c] = count;
                }

            crosstab.Rows.InsertAt(totalsRow, 0);

            return crosstab;
        }

        private void UpdateWaveList()
        {
            // if study = all, get all waves
            // if study <> all, get waves for selected studies

            lstStudyWave.Items.Clear();
            lstStudyWave.Items.Add("<All>");

            if (lstStudy.GetSelected(0))
            {
                foreach (StudyWave wave in Globals.AllWaves)
                {
                    lstStudyWave.Items.Add(wave.WaveCode);
                }
            }
            else
            {
                foreach (string study in lstStudy.SelectedItems)
                {
                    var theStudy = Globals.AllStudies.Where(x => x.ISO_Code.Equals(study)).FirstOrDefault();
                    var theWaves = theStudy.Waves.Select(x => x.WaveCode).ToArray();
                    lstStudyWave.Items.AddRange(theWaves);
                }

            }
            lstStudyWave.SetSelected(0, true);
            UpdateSurveyList();

        }

        private void UpdateSurveyList()
        {
            
            lstSurvey.Items.Clear();
            lstSurvey.Items.Add("<All>");

            // if wave <> all, get the selected wave surveys
            if (!lstStudyWave.GetSelected(0))
            {
                foreach (string wave in lstStudyWave.SelectedItems)
                {
                    var theWave = Globals.AllWaves.Where(x => x.WaveCode.Equals(wave)).FirstOrDefault();
                    var theSurveys = theWave.Surveys.Select(x => x.SurveyCode).ToArray();
                    lstSurvey.Items.AddRange(theSurveys);
                }
            }
            // if wave = all and study <> all then get surveys for those in the waves list
            else if (lstStudyWave.GetSelected(0) && !lstStudy.GetSelected(0))
            {
                foreach (string wave in lstStudyWave.Items)
                {
                    var theWave = Globals.AllWaves.Where(x => x.WaveCode.Equals(wave)).FirstOrDefault();
                    if (theWave == null)
                        continue; 

                    var theSurveys = theWave.Surveys.Select(x => x.SurveyCode).ToArray();
                    lstSurvey.Items.AddRange(theSurveys);
                }

            }
            // if wave = all and study = all then get all surveys
            else if (lstStudyWave.GetSelected(0) && lstStudy.GetSelected(0))
            {
                foreach (Survey survey in Globals.AllSurveys)
                {
                    lstSurvey.Items.Add(survey.SurveyCode);
                }
            }

            
            lstSurvey.SetSelected(0, true);
            lstSurvey.Tag = true;

            UpdateVarList();
        }

        private void UpdateVarList()
        {
            cboVarNameBox.DataSource = null;
            if (lstStudy.GetSelected(0) && lstStudyWave.GetSelected(0) && lstSurvey.GetSelected(0))
            {
                // all surveys, too many
                cboVarNameBox.DataSource = new List<string>() { "Too many to list." };
            } else if (lstSurvey.GetSelected(0))
            {
                // all surveys in box
                List<string> surveys = GetSurveys();
                cboVarNameBox.DataSource = DBAction.GetSurveyVarNames(surveys);
            }
            else
            {
                // selected surveys
                List<string> surveys = GetSelectedSurveys();
                cboVarNameBox.DataSource = DBAction.GetSurveyVarNames(surveys);
            }
            cboVarNameBox.SelectedItem = null;
        }

        private List<string> GetSurveys()
        {
            List<string> surveys = new List<string>();

            if (lstSurvey.GetSelected(0))
            {
                foreach (string s in lstSurvey.Items)
                {
                    if (s.Equals("<All>"))
                        continue;

                    surveys.Add(s);
                }
            }
            else 
            {
                surveys = GetSelectedSurveys();
            }
            return surveys;
        }

        private List<string> GetSelectedSurveys()
        {
            List<string> surveys = new List<string>();

            for (int i = 0; i < lstSurvey.Items.Count; i++)
            {
                if (lstSurvey.Items[i].Equals("<All>") || !lstSurvey.GetSelected(i))
                    continue;

                surveys.Add(lstSurvey.Items[i].ToString());
            }

            return surveys;
        }

        private List<string> GetWaves()
        {
            List<string> waves = new List<string>();

            if (lstStudyWave.GetSelected(0))
            {
                foreach (string s in lstStudyWave.Items)
                {
                    if (s.Equals("<All>"))
                        continue;

                    waves.Add(s);
                }
            }
            else
            {
                waves = GetSelectedWaves();
            }

            return waves;
        }

        private List<string> GetSelectedWaves()
        {
            List<string> waves = new List<string>();

            for (int i = 0; i < lstStudyWave.Items.Count; i++)
            {
                if (lstStudyWave.Items[i].Equals("<All>") || !lstStudyWave.GetSelected(i))
                    continue;

                waves.Add(lstStudyWave.Items[i].ToString());
            }

            return waves;
        }

        private List<string> GetInclusions()
        {
            List<string> inclusions = new List<string>();
            foreach (KeyValuePair<int, string> item in lstInclusions.SelectedItems)
            {
                Inclusions i = (Inclusions)Enum.ToObject(typeof(Inclusions), item.Key);

                switch (i)
                {
                    case Inclusions.RespOptions:
                        inclusions.Add("RespOptions");
                        break;
                    case Inclusions.NRCodes:
                        inclusions.Add("NRCodes");
                        break;
                    case Inclusions.FmtNames:
                        inclusions.Add("RespName + '_' + NRName AS FmtName");
                        break;
                    case Inclusions.VarName:
                        inclusions.Add("VarName");
                        break;
                    case Inclusions.VarLabel:
                        inclusions.Add("VarLabel");
                        break;
                    case Inclusions.Content:
                        inclusions.Add("Content");
                        break;
                    case Inclusions.Topic:
                        inclusions.Add("Topic");
                        break;


                }
            }

            return inclusions;
        }

        private List<string> GetExclusions()
        {
            List<string> exclusions = new List<string>();
            foreach (KeyValuePair<int, string> item in lstExclusions.SelectedItems)

            {
                Exclusions i = (Exclusions)Enum.ToObject(typeof(Exclusions), item.Key);

                switch (i)
                {
                    case Exclusions.Headings:
                        exclusions.Add("NOT refVarName LIKE 'Z%'");
                        break;
                    case Exclusions.BIScripts:
                        exclusions.Add("NOT (refVarName Like 'BI%' AND RespName = '0' AND NRName ='0')");

                        break;
                    case Exclusions.Screeners:

                        exclusions.Add("NOT Survey LIKE '%sc'");

                        break;
                    case Exclusions.NonStdVars:
                        exclusions.Add("refVarName Like '[A-Z][A-Z][0-9][0-9][0-9]%'");
                        break;
                }
            }

            return exclusions;
        }

        private List<string> GetVars()
        {
            List<string> vars = new List<string>();

            foreach (string s in lstVarName.Items)
            {
                vars.Add(s);
            }

            return vars;
        }

        private void FillLists()
        {
            lstStudy.Items.Add("<All>");
            foreach (Study study in Globals.AllStudies)
            {
                lstStudy.Items.Add(study.ISO_Code);
            }
            lstStudy.SetSelected(0, true);
            lstStudy.Tag = true;

            lstStudyWave.Items.Add("<All>");
            foreach (StudyWave wave in Globals.AllWaves)
            {
                lstStudyWave.Items.Add(wave.WaveCode);
            }
            lstStudyWave.SetSelected(0, true);
            lstStudyWave.Tag = true;

            lstSurvey.Items.Add("<All>");
            foreach (Survey survey in Globals.AllSurveys)
            {
                lstSurvey.Items.Add(survey.SurveyCode);
            }
            lstSurvey.SetSelected(0, true);
            lstSurvey.Tag = true;

            var inclusions = new List<KeyValuePair<int, string>>();
            foreach (Inclusions s in Enum.GetValues(typeof(Inclusions)))
                inclusions.Add(new KeyValuePair<int, string>((int)s, s.ToString()));

            lstInclusions.DataSource = inclusions;
            lstInclusions.DisplayMember = "Value";
            lstInclusions.ValueMember = "Key";

            var exclusions = new List<KeyValuePair<int, string>>();
            foreach (Exclusions s in Enum.GetValues(typeof(Exclusions)))
                exclusions.Add(new KeyValuePair<int, string>((int)s, s.ToString()));

            lstExclusions.DataSource = exclusions;
            lstExclusions.DisplayMember = "Value";
            lstExclusions.ValueMember = "Key";
        }

        
    }
}
