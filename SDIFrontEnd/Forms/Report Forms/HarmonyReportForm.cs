using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITCLib;

namespace SDIFrontEnd
{
    enum HarmonyType { RefVarList, WaveVarList }


    // TODO translation odd character
    // TODO translation colors (on hold)
    // TODO on screen view (on hold)
    // TODO last wave only
    public partial class HarmonyReportForm : Form
    {
        HarmonyReport HR;

        public HarmonyReportForm()
        {
            InitializeComponent();

            HR = new HarmonyReport();

            // varname lists
            var vars = Globals.AllVarNames.GroupBy(x => x.RefVarName).Select(grp => grp.ToList()).ToList();
            List<VariableName> unique = new List<VariableName>();
            foreach (var grp in vars)
            {
                unique.Add(grp[0]);
            }
            
            cboVarNames.DataSource = unique;
            cboVarNames.ValueMember = "RefVarName";
            cboVarNames.DisplayMember = "RefVarName";
            cboVarNames.SelectedItem = null;

            lstPrefixes.DataSource = DBAction.GetVariablePrefixes();

            lstSelVar.Items.Clear();
            lstSelVar.DisplayMember = "RefVarName";

            // wave tab
            cboWaves.DataSource = new List<StudyWaveRecord>( Globals.AllWaves);
            cboWaves.DisplayMember = "WaveCode";
            cboWaves.ValueMember = "ID";
            cboWaves.SelectedItem = null;

            // survey lists
            FillLists();

            lstStudies.SelectedIndexChanged += lstStudies_SelectedIndexChanged;
            lstWaves.SelectedIndexChanged += lstWaves_SelectedIndexChanged;

            lstGroupOn.SetSelected(2, true);
            lstGroupOn.SetSelected(3, true);
            lstGroupOn.SetSelected(4, true);

            chkShowGroupOn.DataBindings.Add("Checked", HR, "ShowGroupOn");
            chkShowAllSurveys.DataBindings.Add("Checked", HR, "ShowAllSurveys");
            chkSeparateLabels.DataBindings.Add("Checked", HR, "SeparateLabels");
            chkRecentWaves.DataBindings.Add("Checked", HR, "LastWaveOnly");
            txtFileName.DataBindings.Add("Text", HR, "CustomFileName");

        }
        
        public HarmonyReportForm (RefVariableName refvarname) : this()
        {
            AddVar(refvarname);
        }

        private void HarmonyReportForm_Load(object sender, EventArgs e)
        {
            optRefVarName.Checked = true;
        }

        #region Menu Items

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstSelVar.Items.Clear();
        }
        #endregion

        #region Events 
        private void HarmonyScope_CheckedChanged(object sender, EventArgs e)
        {
            if (optRefVarName.Checked)
            {
                if (!tabControl1.TabPages.Contains(tabVarNames))
                    tabControl1.TabPages.Insert(0, tabVarNames);

                tabControl1.SelectTab(tabVarNames);           
                chkIncludeTranslation.Checked = false;
                tabControl1.TabPages.Remove(tabWaves);
            }
            else if (optWave.Checked)
            {
                if (!tabControl1.TabPages.Contains(tabWaves))
                    tabControl1.TabPages.Insert(0, tabWaves);

                tabControl1.SelectTab(tabWaves);

                tabControl1.TabPages.Remove(tabVarNames);
            }

            UpdateGroupOnFields(optWave.Checked);

            lstStudies.Enabled = optRefVarName.Checked;
            lstWaves.Enabled = optRefVarName.Checked;
            lstSurveys.Enabled = optRefVarName.Checked;

            chkShowAllSurveys.Checked = false;
            chkShowAllSurveys.Enabled = optRefVarName.Checked;


            chkRecentWaves.Checked = false;
            chkRecentWaves.Enabled = optRefVarName.Checked;


            optDisplaySurveys.Checked = true;
            optDisplaySurveys.Enabled = optRefVarName.Checked;
            optDisplayProjects.Enabled = optRefVarName.Checked;

            
        }

        private void cboWaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboWaves.SelectedItem == null)
                return;
            string wave = ((StudyWaveRecord)cboWaves.SelectedItem).WaveCode;
            int index = -1;
            for (int i = 0; i < lstWaves.Items.Count; i++)
            {
                if (lstWaves.Items[i].Equals(wave))
                {
                    index = i;
                    break;
                }
            }

            if (index > -1)
                lstWaves.SetSelected(index, true);

            cboLanguage.DataSource = DBAction.GetLanguages((StudyWaveRecord)cboWaves.SelectedItem);
            
        }

        private void chkIncludeTranslation_CheckedChanged(object sender, EventArgs e)
        {
            
            for(int i = 0; i <lstGroupOn.Items.Count; i++)
            {
                if (lstGroupOn.Items[i].Equals("Translation"))
                {
                    lstGroupOn.SetSelected(i, chkIncludeTranslation.Checked);
                    break;
                }
            }

            HR.HasLang = chkIncludeTranslation.Checked;
        }


        private void cmdWordDocument_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void cmdOnscreen_Click(object sender, EventArgs e)
        {
            List<string> vars = GetVarFilter();
            DataTable results = GetHarmonyResults(vars);
            HR.CreateHarmonyReportData(results);

            HarmonyResults frm = new HarmonyResults(HR.ReportTable);
            frm.Tag = 1;
            FormManager.Add(frm);
        }

        #endregion

        private void GenerateReport()
        {
            List<string> vars = GetVarFilter();
            DataTable results = GetHarmonyResults(vars);

            HR.CreateHarmonyReport(results);
        }

        private void cmdSeparateDoc_Click(object sender, EventArgs e)
        {
            List<string> vars = GetVarFilter();

            foreach(string v in vars)
            {
                //HarmonyReport hr = new HarmonyReport();
                DataTable results = GetHarmonyResults(new List<string> { v });
                HR.CustomFileName = v + " - Harmony Report";
                HR.OpenFinalReport = false;
                HR.CreateHarmonyReport(results);
            }

            MessageBox.Show(@"Done! Your reports can be found in the Reports folder.");
            Process.Start(@"\\psychfile\psych$\psych-lab-gfong\SMG\SDI\Reports\Harmony");
        }

        private DataTable GetHarmonyResults(List<string> vars)
        {
            

            bool prep = false, prei = false, prea = false, litq = false, psti = false, pstp = false, respname = false, nrname = false;
            bool varlabel = false, content = false, topic = false, domain = false, product = false, translation = false;
            bool englishRouting = false, showProjects = false, itconly = false;

            string lang = null;
            List<string> surveysFilter = GetSurveyFilter();

            foreach (var item in lstGroupOn.SelectedItems)
            {
                switch (item.ToString())
                {
                    case "PreP":
                        prep = true;
                        break;
                    case "PreI":
                        prei = true;
                        break;
                    case "PreA":
                        prea = true;
                        break;
                    case "LitQ":
                        litq = true;
                        break;
                    case "PstI":
                        psti = true;
                        break;
                    case "PstP":
                        pstp = true;
                        break;
                    case "RespOptions":
                        respname = true;
                        break;
                    case "NRCodes":
                        nrname = true;
                        break;
                    case "VarLabel":
                        varlabel = true;
                        break;
                    case "Content":
                        content = true;
                        break;
                    case "Topic":
                        topic = true;
                        break;
                    case "Domain":
                        domain = true;
                        break;
                    case "Translation":
                        translation = true;
                        break;
                }
            }

            if (cboLanguage.SelectedItem != null)
                lang = (string)cboLanguage.SelectedItem;

            showProjects = HR.ShowProjects;

            DataTable results = DBAction.GetHarmonyData(vars, prep, prei, prea, litq, psti, pstp, respname, nrname, translation, varlabel, domain, topic, content, product,
                englishRouting, lang, showProjects, surveysFilter, itconly);

            if (chkMultipleWordingsOnly.Checked)
            {
                DataTable multiples = (from r in results.AsEnumerable()
                           where (
                               from c in results.AsEnumerable()
                               group c by c.Field<string>("refVarName") into grp
                               where grp.Count() > 1
                               select grp.Key
                           ).Contains(r.Field<string>("refVarName"))
                           select r).CopyToDataTable();
               
                results = multiples;
            }

            if (chkShowFieldwork.Checked)
            {
                foreach (DataRow r in results.Rows)
                {
                    List<string> surveyList = ((string)r["Surveys"]).Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    for (int i = 0; i < surveyList.Count; i++)
                    {
                        StudyWave wave = Globals.AllWaves.Where(x => x.WaveCode.Equals(surveyList[i])).FirstOrDefault();
                        if (wave == null)
                            continue;
                        string fieldwork = wave.GetFieldworkYear();
                        if (!string.IsNullOrEmpty(fieldwork)) surveyList[i] += " (" + fieldwork + ")";
                    }

                    r["Surveys"] = string.Join(", ", surveyList);
                }
            }
            
            return results;
        }

        private List<string> GetVarFilter()
        {
            List<string> vars = new List<string>();
            foreach (VariableName r in lstSelVar.Items)
            {
                vars.Add(r.RefVarName);
            }
            return vars;
        }

        // if all studies/waves/surveys are selected, do not filter
        // other wise take the list of surveys
        private List<string> GetSurveyFilter()
        {
            List<string> surveysFilter = new List<string>();
            
            if (chkShowAllSurveys.Checked || (lstStudies.GetSelected(0) && lstWaves.GetSelected(0) && lstSurveys.GetSelected(0)))
            { 

            }
            else
            {
                if (lstSurveys.GetSelected(0))
                {
                    foreach (string s in lstSurveys.Items)
                    {
                        if (!s.Equals("<All>"))
                            surveysFilter.Add(s);
                    }
                }
                else
                    foreach (string s in lstSurveys.SelectedItems)
                    {
                        if (!s.Equals("<All>"))
                            surveysFilter.Add(s);
                    }
            }
            return surveysFilter;
        }

        private void UpdateGroupOnFields(bool t)
        {
            if (t)
                lstGroupOn.Items.Add("Translation");
            else
                lstGroupOn.Items.Remove("Translation");

        }

        private void cmdAddVar_Click(object sender, EventArgs e)
        {
            if (cboVarNames.SelectedItem == null) return;

            AddVar((RefVariableName)cboVarNames.SelectedItem);
            
        }

        public void AddVar(RefVariableName refVarName)
        {
            if (!lstSelVar.Items.Contains(refVarName))
                lstSelVar.Items.Add(refVarName);

            if (cboVarNames.SelectedIndex>=0)
                cboVarNames.SelectedIndex++;
        }

        private void cmdRemoveVar_Click(object sender, EventArgs e)
        {
            if (lstSelVar.SelectedItem == null) return;

            int sel = lstSelVar.SelectedIndex; // retain last selected index

            lstSelVar.Items.Remove(lstSelVar.SelectedItem); // remove selected item
           
            // reselect the last selected index, or the last item if we removed the last item
            if (lstSelVar.Items.Count >0)
                if (sel >= lstSelVar.Items.Count)
                    lstSelVar.SelectedIndex = lstSelVar.Items.Count-1;
                else
                    lstSelVar.SelectedIndex = sel;

        }

        private void lstGroupOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            HR.matchFields.Clear();
            //HR.matchFields = lstGroupOn.SelectedItems.OfType<string>().ToList();

            foreach (var item in lstGroupOn.SelectedItems)
                HR.matchFields.Add(item.ToString());
        }

        private void lstPrefixes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPrefixes.SelectedItems.Count == 0)
                return;

            lstSelVar.Items.Clear();

            List<RefVariableName> vars = DBAction.GetRefVarNamesPrefix(lstPrefixes.SelectedItems[0].ToString());

            foreach (RefVariableName s in vars)
                lstSelVar.Items.Add(s.RefVarName);
        }

        private void FillLists()
        {
            foreach (Study s in Globals.AllStudies)
            {
                lstStudies.Items.Add(s.ISO_Code);
            }
            lstStudies.Items.Insert(0, "<All>");
            lstStudies.SetSelected(0, true);
            lstStudies.Tag = true;

            foreach (StudyWave w in Globals.AllWaves)
            {
                lstWaves.Items.Add(w.WaveCode);
            }
            lstWaves.Items.Insert(0, "<All>");
            lstWaves.SetSelected(0, true);
            lstWaves.Tag = true;

            foreach (Survey s in Globals.AllSurveys)
            {
                lstSurveys.Items.Add(s.SurveyCode);
            }
            lstSurveys.Items.Insert(0, "<All>");
            lstSurveys.SetSelected(0, true);
            lstSurveys.Tag = true;
        }

        private void lstStudies_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lst = (ListBox)sender;

            // only the <All> option is in the box
            if (lst.Items.Count == 1)
                return;

            lst.SelectedIndexChanged -= lstStudies_SelectedIndexChanged;

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

            lst.SelectedIndexChanged += lstStudies_SelectedIndexChanged;

            UpdateWaveList();

        }


        private void lstWaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lst = (ListBox)sender;

            // only the <All> option is in the box
            if (lst.Items.Count == 1)
                return;

            lst.SelectedIndexChanged -= lstWaves_SelectedIndexChanged;

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

            lst.SelectedIndexChanged += lstWaves_SelectedIndexChanged;

            UpdateSurveyList();
        }

        private void lstSurveys_SelectedIndexChanged(object sender, EventArgs e)
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

        private void UpdateWaveList()
        {
            // if study = all, get all waves
            // if study <> all, get waves for selected studies

            lstWaves.Items.Clear();
            lstWaves.Items.Add("<All>");

            if (lstStudies.GetSelected(0))
            {
                foreach (StudyWave wave in Globals.AllWaves)
                {
                    lstWaves.Items.Add(wave.WaveCode);
                }
            }
            else
            {
                foreach (string study in lstStudies.SelectedItems)
                {
                    var theStudy = Globals.AllStudies.Where(x => x.ISO_Code.Equals(study)).FirstOrDefault();
                    var theWaves = theStudy.Waves.Select(x => x.WaveCode).ToArray();
                    lstWaves.Items.AddRange(theWaves);
                }

            }
            lstWaves.SetSelected(0, true);
            UpdateSurveyList();

        }

        private void UpdateSurveyList()
        {

            lstSurveys.Items.Clear();
            lstSurveys.Items.Add("<All>");

            // if wave <> all, get the selected wave surveys
            if (!lstWaves.GetSelected(0))
            {
                foreach (string wave in lstWaves.SelectedItems)
                {
                    var theWave = Globals.AllWaves.Where(x => x.WaveCode.Equals(wave)).FirstOrDefault();
                    var theSurveys = theWave.Surveys.Select(x => x.SurveyCode).ToArray();
                    lstSurveys.Items.AddRange(theSurveys);
                }
            }
            // if wave = all and study <> all then get surveys for those in the waves list
            else if (lstWaves.GetSelected(0) && !lstStudies.GetSelected(0))
            {
                foreach (string wave in lstWaves.Items)
                {
                    var theWave = Globals.AllWaves.Where(x => x.WaveCode.Equals(wave)).FirstOrDefault();
                    if (theWave == null)
                        continue;

                    var theSurveys = theWave.Surveys.Select(x => x.SurveyCode).ToArray();
                    lstSurveys.Items.AddRange(theSurveys);
                }

            }
            // if wave = all and study = all then get all surveys
            else if (lstWaves.GetSelected(0) && lstStudies.GetSelected(0))
            {
                foreach (Survey survey in Globals.AllSurveys)
                {
                    lstSurveys.Items.Add(survey.SurveyCode);
                }
            }


            lstSurveys.SetSelected(0, true);
            lstSurveys.Tag = true;
        }

        private void DisplayMode_CheckedChanged(object sender, EventArgs e)
        {
            HR.ShowProjects =optDisplayProjects.Checked;
            chkShowFieldwork.Enabled = optDisplayProjects.Checked;
                
        }

        #region Object based harmony report (not used right now)
        private void OLDMETHOD()
        {
            //List<VariableName> vars = new List<VariableName>();

            //// for each refVarName, get all the varnames with that refVarName
            //foreach (VariableName r in lstSelVar.Items)
            //{
            //    vars.AddRange(DBAction.GetVarNamesByRef(r.RefVarName));
            //    HR.questions.AddRange(DBAction.GetRefVarNameQuestions(r.RefVarName));
            //}

            //HR.VarNames = new BindingList<VariableName>(vars);
            //HR.CreateHarmonyReport();
        }

        private void OLDONSCREEN()
        {
            //List<VariableName> vars = new List<VariableName>();

            //// for each refVarName, get all the varnames with that refVarName
            //foreach (VariableName r in lstSelVar.Items)
            //{
            //    vars.AddRange(DBAction.GetVarNamesByRef(r.RefVarName));
            //    HR.questions.AddRange(DBAction.GetRefVarNameQuestions(r.RefVarName));
            //}

            //HR.VarNames = new BindingList<VariableName>(vars);

            //HR.CreateHarmonyData();

            //HarmonyResults frm = new HarmonyResults(HR.ReportTable);
            //frm.Tag = 1;
            //FormManager.Add(frm);
        }


        #endregion

       

        private void cmdLast5Years_Click(object sender, EventArgs e)
        {
            for(int i = 1; i < lstWaves.Items.Count;i++)
            {
                StudyWave  wave= Globals.AllWaves.Where(x => x.WaveCode.Equals((string)lstWaves.Items[i])).FirstOrDefault();
                if (wave == null)
                    continue;
                int year = wave.GetFieldworkStart();
                if (year == 0 || (DateTime.Today.Year - year) <= 5)
                    lstWaves.SetSelected(i, true);
                    
            }
        }
    }
}
