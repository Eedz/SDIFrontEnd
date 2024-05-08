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
using FM = FormManager;

namespace SDIFrontEnd
{
    // TODO OR within fields
    public partial class QuestionSearch : Form
    {
        enum SearchType { QuickSearch, GlobalSearch }
        enum VarNameSearchType { VarName, refVarName }

        List<SurveyQuestion> SearchResults;
        VarNameSearchType varSearchType;
        int wordingFieldLeft = 64;
    
        int wordingFieldLinkedH = 95;
        int wordingFieldW = 243;

        int activePanelL = 12;
        int activePanelT = 245;

        public QuestionSearch()
        {
            InitializeComponent();

            cboProduct.DataSource = new List<ProductLabel>(Globals.AllProductLabels);
            cboProduct.DisplayMember = "LabelText";
            cboProduct.ValueMember = "ID";
            cboProduct.SelectedItem = null;
        }

        #region Menu Events

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clear quick search

            // clear Survey/VarName panel
            txtSurvey.Text = "";
            txtVarName.Text = "";

            // clear general fields
            foreach (Control c in panelGeneral.Controls)
            {
                if (c is TextBox)
                    c.Text = "";
            }
            foreach (Control c in panelWordingFields.Controls)
            {
                if (c is TextBox)
                    c.Text = "";
            }

            cboProduct.SelectedItem = null;

            // clear global fields
            txtGlobalCriteria.Text = "";
            lstGlobalFields.SelectedIndex = -1;

            // clear exlcusions
            dgvExclusions.Rows.Clear();

            // clear advanced
            //dgvAdvancedSearch.Clear();
        }


        #endregion

        #region Events
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            SearchType stype;
            
            if (rbBasic.Checked)
                stype = SearchType.QuickSearch;
            else if (rbGlobal.Checked)
            {
                stype = SearchType.GlobalSearch;
            }
            else
                return;

            SearchQuestions(stype);
        }

        private void QuestionSearch_Load(object sender, EventArgs e)
        {
            SearchResults = new List<SurveyQuestion>();
            varSearchType = VarNameSearchType.refVarName;
            
            rbBasic.Checked = true;
            
            txtPreA.Width = wordingFieldW;
            txtLitQ.Width = wordingFieldW;
        }

        

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SearchQuestions(SearchType.QuickSearch);
            }
        }

        private void rbBasic_CheckedChanged(object sender, EventArgs e)
        {
            panelGeneral.Left = activePanelL;
            panelGeneral.Top = activePanelT;
            panelGeneral.Visible = rbBasic.Checked;

            panelExclusions.Top = activePanelT;
            panelExclusions.Left = activePanelL + panelGeneral.Width + 10;
        }

        private void rbGlobal_CheckedChanged(object sender, EventArgs e)
        {
            panelGlobal.Left = activePanelL;
            panelGlobal.Top = activePanelT;
            panelGlobal.Visible = rbGlobal.Checked;

            panelExclusions.Top = activePanelT;
            panelExclusions.Left = activePanelL + panelGlobal.Width + 10;
        }

        private void chkLink_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLink.Checked)
            {
                txtPreA.Visible = false;
                txtLitQ.Visible = false;
                txtPreALitQ.Visible = true;
                txtPreALitQ.Left = wordingFieldLeft;
                txtPreALitQ.Height = wordingFieldLinkedH;
                txtPreALitQ.Width = wordingFieldW;
            }
            else
            {
                txtPreA.Visible = true;
                txtPreA.Width = wordingFieldW;
                txtLitQ.Visible = true;
                txtLitQ.Width = wordingFieldW;

                txtPreALitQ.Visible = false;
                txtPreALitQ.Left = 189;
                txtPreALitQ.Height = wordingFieldLinkedH;
                txtPreALitQ.Width = 97;
            }
        }

        

        private void cmdClearGlobal_Click(object sender, EventArgs e)
        {
            txtGlobalCriteria.Text = string.Empty;
            lstGlobalFields.ClearSelected();
        }

        private void cmdClearExclusions_Click(object sender, EventArgs e)
        {
            dgvExclusions.Rows.Clear();
        }

        private void QuestionSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
        }

        #endregion

        public void SetVarName(string var)
        {
            txtVarName.Text = var;
        }

        private void SearchQuestions (SearchType searchType)
        {
       
            List<SearchCriterium> criteria = new List<SearchCriterium>();

            string translationCriteria = null;
            bool showTranslation = false;

            criteria.AddRange(GetSVCriteria());

            switch (searchType) { 
                case SearchType.QuickSearch:
                    criteria.AddRange(GetGeneralCriteria());
                    translationCriteria = txtTranslation.Text;

                    // toggle translations
                    showTranslation = chkIncludeTranslation.Checked;

                    break;
                case SearchType.GlobalSearch:
                    criteria.AddRange(GetGobalCriteria());

                    // toggle translation
                    if (lstGlobalFields.SelectedItems.Contains("Translation"))
                    {
                        showTranslation = chkIncludeTranslation.Checked;
                        translationCriteria = txtGlobalCriteria.Text;
                    }

                    break;
            }

            criteria.AddRange(GetExclusions());

            if (criteria.Count==0)
            {
                MessageBox.Show("No search criteria specified.");
                return;
            }

            SearchResults = DBAction.GetSurveyQuestions(criteria, showTranslation, translationCriteria);

            if (SearchResults.Count() == 0)
            {
                MessageBox.Show("No results found.");
                return;
            }

            if (FM.FormManager.FormOpen("QuestionSearchResults"))
            {
                FM.FormManager.Remove(FM.FormManager.GetForm("QuestionSearchResults", 1));
            }
            QuestionSearchResults frm = new QuestionSearchResults(SearchResults, showTranslation);
            frm.Tag = 1;
            FM.FormManager.Add(frm);
            

        }

        private List<SearchCriterium> GetSVCriteria()
        {
            List<SearchCriterium> crit = new List<SearchCriterium>();

            // survey
            if (!string.IsNullOrEmpty(txtSurvey.Text))
            {
                string txt = txtSurvey.Text.Replace(" ", "");
                crit.Add(new SearchCriterium("Survey", Comparity.Contains, new List<string>(txt.Split(new char[] { ',' }))));
                
             }

            // varname
            if (!string.IsNullOrEmpty(txtVarName.Text))
            {
                string txt = txtVarName.Text.Replace(" ", "");

                if (varSearchType == VarNameSearchType.VarName)
                    crit.Add(new SearchCriterium("VarName", Comparity.Contains, new List<string>(txt.Split(new char[] { ',' }))));            
                else
                    crit.Add(new SearchCriterium("refVarName", Comparity.Contains, new List<string>(txt.Split(new char[] { ',' }))));
            }

            return crit;
        }

        private List<SearchCriterium> GetGeneralCriteria()
        {
            List<SearchCriterium> criteria = new List<SearchCriterium>();
            string qnumLow, qnumHigh;

            // qnum
            if (!string.IsNullOrEmpty(txtQnum.Text))
            {
                string txt = txtQnum.Text;
                if (txt.IndexOf('-') >= 0)
                {

                    qnumLow = txt.Substring(0, txt.IndexOf('-'));
                    qnumHigh = txt.Substring(txt.IndexOf('-') + 1);
                    if (Int32.Parse(qnumLow) > Int32.Parse(qnumHigh))
                    {
                        MessageBox.Show("Qnum Range Error.");
                    }
                    else
                    {
                        criteria.Add(new SearchCriterium("Qnum", Comparity.GreaterThan, new List<string>() { qnumLow }));
                        criteria.Add(new SearchCriterium("Qnum", Comparity.LessThan, new List<string>() { qnumHigh }));
                    }
                }
                else
                {
                    criteria.Add(new SearchCriterium("Qnum", Comparity.Contains, new List<string>() { txt }));                    
                }
            }

            // text fields
            if (!string.IsNullOrEmpty(txtAltQnum.Text))
                criteria.Add(new SearchCriterium("AlQnum", Comparity.Contains, new List<string> () {txtAltQnum.Text }));
        
            // labels
            if (!string.IsNullOrEmpty(txtVarLabel.Text))
                criteria.Add(new SearchCriterium("VarLabel", Comparity.Contains, new List<string>() { txtVarLabel.Text }));
            if (!string.IsNullOrEmpty(txtDomain.Text))
                criteria.Add(new SearchCriterium("Domain", Comparity.Contains, new List<string>() { txtDomain.Text }));
            if (!string.IsNullOrEmpty(txtTopic.Text))
                criteria.Add(new SearchCriterium("Topic", Comparity.Contains, new List<string>() { txtTopic.Text }));
            if (!string.IsNullOrEmpty(txtContent.Text))
                criteria.Add(new SearchCriterium("Content", Comparity.Contains, new List<string>() { txtContent.Text }));
            if (cboProduct.SelectedItem != null)
                criteria.Add(new SearchCriterium("Product", Comparity.Contains, new List<string>() { cboProduct.SelectedItem.ToString() }));

            // wordings
            if (!string.IsNullOrEmpty(txtPreP.Text))
                criteria.Add(new SearchCriterium("PreP", Comparity.Contains, new List<string>() { txtPreP.Text }));
            if (!string.IsNullOrEmpty(txtPreI.Text))
                criteria.Add(new SearchCriterium("PreI", Comparity.Contains, new List<string>() { txtPreI.Text }));

            if (chkLink.Checked)
            {
                if (!string.IsNullOrEmpty(txtPreALitQ.Text))
                {
                    criteria.Add(new SearchCriterium(new List<string>() { "PreA", "LitQ" }, Comparity.Contains, new List<string>() { txtPreALitQ.Text } ));
                    
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtPreA.Text))
                    criteria.Add(new SearchCriterium("PreA", Comparity.Contains, new List<string>() { txtPreA.Text }));
                if (!string.IsNullOrEmpty(txtLitQ.Text))
                    criteria.Add(new SearchCriterium("LitQ", Comparity.Contains, new List<string>() { txtLitQ.Text }));
            }

            if (!string.IsNullOrEmpty(txtPstI.Text))
                criteria.Add(new SearchCriterium("PstI", Comparity.Contains, new List<string>() { txtPstI.Text}));
            if (!string.IsNullOrEmpty(txtPstP.Text))
                criteria.Add(new SearchCriterium("PstP", Comparity.Contains, new List<string>() { txtPstP.Text }));

            // response options
            if (!string.IsNullOrEmpty(txtRespOptions.Text))
            {
                string[] roA = txtRespOptions.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                SearchCriterium roCrit = new SearchCriterium();
                roCrit.Fields.Add("RespOptions");
                roCrit.Compare = Comparity.Contains;
                roCrit.Criteria.AddRange(roA);
                
                criteria.Add(roCrit);
            }

            // nrcodes
            if (!string.IsNullOrEmpty(txtNRCodes.Text))
            {
                string[] roA = txtNRCodes.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                SearchCriterium roCrit = new SearchCriterium();
                roCrit.Fields.Add("NRCodes");
                roCrit.Compare = Comparity.Contains;
                roCrit.Criteria.AddRange(roA);

                criteria.Add(roCrit);
            }         

            return criteria;
        }

        private List<SearchCriterium> GetGobalCriteria()
        {
            List<SearchCriterium> criteria = new List<SearchCriterium>();
            
            string globalText = txtGlobalCriteria.Text;

            for (int i = 0; i < lstGlobalFields.SelectedItems.Count; i++)
            {
                criteria.Add(new SearchCriterium(lstGlobalFields.Items[i].ToString(), Comparity.Contains, new List<string>(){ globalText }));
            }

            return criteria;
        }

        private List<SearchCriterium> GetExclusions()
        {
            List<SearchCriterium> criteria = new List<SearchCriterium>();
            StringBuilder crit = new StringBuilder();

            if (dgvExclusions.Rows.Count == 0) return criteria;

            foreach (DataGridViewRow r in dgvExclusions.Rows)
            {
                if (r.Cells["Terms"].Value == null || r.Cells["FieldName"].Value == null)
                    continue;

                string[] terms = r.Cells["Terms"].Value.ToString().Split(new char[] { ',' });
                string field = r.Cells["FieldName"].Value.ToString();

                for (int i = 0; i < terms.Length; i++)
                {
                    SearchCriterium c = new SearchCriterium(field, Comparity.Contains, new List<string>() { terms[i] }, true);
                    criteria.Add(c);                    
                }
            }

            return criteria;
        } 
    }
}
