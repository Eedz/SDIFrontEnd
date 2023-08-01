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
using ITCReportLib;

using FM = FormManager;

namespace SDIFrontEnd
{
    public partial class ProductCrosstab : Form
    {
      
        // TODO expanded report
        public ProductCrosstab()
        {
            InitializeComponent();

            lstSurvey.Tag = true;
            lstSurvey.Items.Add("<All>");
            foreach (Survey s in Globals.AllSurveys)
                lstSurvey.Items.Add(s.SurveyCode);

            lstSurvey.SetSelected(0, true);
            lstSurvey.Tag = true;


            lstPrefix.Tag = true;            
        }

        #region Menu Strip Events 

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Events 
        private void ProductCrosstab_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
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

            UpdatePrefixes();
        }

        private void lstPrefix_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lst = (ListBox)sender;

            // only the <All> option is in the box
            if (lst.Items.Count == 1)
                return;

            lst.SelectedIndexChanged -= lstPrefix_SelectedIndexChanged;

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

            lst.SelectedIndexChanged += lstPrefix_SelectedIndexChanged;

            
            UpdateTopics();
            

        }

        private void lstTopic_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lst = (ListBox)sender;

            // only the <All> option is in the box
            if (lst.Items.Count == 1)
                return;

            lst.SelectedIndexChanged -= lstTopic_SelectedIndexChanged;

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

            lst.SelectedIndexChanged += lstTopic_SelectedIndexChanged;

            UpdateContent();
        }

        private void lstContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lst = (ListBox)sender;

            // only the <All> option is in the box
            if (lst.Items.Count == 1)
                return;

            lst.SelectedIndexChanged -= lstContent_SelectedIndexChanged;

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

            lst.SelectedIndexChanged += lstContent_SelectedIndexChanged;

            UpdateProducts();
        }

        private void chkAll4C_CheckedChanged(object sender, EventArgs e)
        {
            bool select = ((CheckBox)sender).Checked;


            lstSurvey.SetSelected(0, false);
            lstSurvey.SelectedIndexChanged -= lstSurvey_SelectedIndexChanged;

            for (int i = 0; i < lstSurvey.Items.Count - 1; i++)
            {
                if (lstSurvey.Items[i].ToString().StartsWith("4C"))
                    lstSurvey.SetSelected(i, select);
            }

            // select <All> if nothing else is selected, deselect if not
            bool reselectAll = lstSurvey.SelectedItems.Count == 0;

            lstSurvey.SetSelected(0, reselectAll);

            lstSurvey.SelectedIndexChanged += lstSurvey_SelectedIndexChanged;

            UpdatePrefixes();
        }

        private void chkAllNCT_CheckedChanged(object sender, EventArgs e)
        {
            bool select = ((CheckBox)sender).Checked;

            lstSurvey.SetSelected(0, false);
            lstSurvey.SelectedIndexChanged -= lstSurvey_SelectedIndexChanged;

            for (int i = 0; i < lstSurvey.Items.Count - 1; i++)
            {
                if (Globals.AllSurveys.Any(x => x.SurveyCode.Equals(lstSurvey.Items[i].ToString()) && x.NCT))
                    lstSurvey.SetSelected(i, select);
            }

            // select <All> if nothing else is selected, deselect if not
            bool reselectAll = lstSurvey.SelectedItems.Count == 0;

            lstSurvey.SetSelected(0, reselectAll);

            lstSurvey.SelectedIndexChanged += lstSurvey_SelectedIndexChanged;

            UpdatePrefixes();
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            RunReport();
        }

        private void cmdOpenFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"\\psychfile\psych$\psych-lab-gfong\SMG\SDI\Reports");
        }
        #endregion

        #region Methods
        private void UpdatePrefixes()
        {
            lstPrefix.Items.Clear();
            lstPrefix.Items.Add("<All>");

            // if <All> is not selected, get prefixes for selected surveys
            if (!lstSurvey.GetSelected(0))
            {
                var prefixes = DBAction.GetVariablePrefixes(GetSurveys());

                foreach (string s in prefixes)
                    if (!lstPrefix.Items.Contains(s)) lstPrefix.Items.Add(s);
            }

            lstPrefix.Tag = true;
            lstPrefix.SetSelected(0, true);

            UpdateTopics();
        }

        /// <summary>
        /// Fill the Topic list box with labels. The labels are those that are used by questions with the selected Prefixes.
        /// </summary>
        private void UpdateTopics()
        {
            lstTopic.Items.Clear();
            lstTopic.Items.Add("<All>");

            // if <All> prefixes are not selected, get topics 
            if (!lstPrefix.GetSelected(0))
            {
                List<SearchCriterium> criteria = new List<SearchCriterium>();

                SearchCriterium surveys = new SearchCriterium("Survey", Comparity.Equals, GetSurveys());
                criteria.Add(surveys);

                SearchCriterium prefixes = new SearchCriterium("SUBSTRING(VarName,1,2)", Comparity.Equals, GetPrefixes());
                criteria.Add(prefixes);

                var questions = DBAction.GetSurveyQuestions(criteria).GroupBy(x => x.VarName.Topic.ID).Select(grp => grp.ToList()).ToList();

                List<SurveyQuestion> topics = new List<SurveyQuestion>();
                foreach (var grp in questions)
                {
                    topics.Add(grp[0]);
                }

                
                foreach (SurveyQuestion s in topics)
                    lstTopic.Items.Add(s.VarName.Topic.LabelText);

                    //foreach (SurveyQuestion s in topics)
                    //    if (!lstTopic.Items.Contains(s.Topic.LabelText)) lstTopic.Items.Add(s.Topic.LabelText);

            }
            lstTopic.Tag = true;
            lstTopic.SetSelected(0, true);

            UpdateContent();
        }


        /// <summary>
        /// Fill the Content list box with labels. The labels are those that are used by questions with the selected Prefix and Topic labels.
        /// </summary>
        private void UpdateContent()
        {
            lstContent.Items.Clear();
            lstContent.Items.Add("<All>");

            // if the only topic is <All> don't get contents
            if (lstTopic.Items.Count > 1)
            {
                List<SearchCriterium> criteria = new List<SearchCriterium>();

                SearchCriterium surveys = new SearchCriterium("Survey", Comparity.Equals, GetSurveys());
                SearchCriterium prefixes = new SearchCriterium("SUBSTRING(VarName,1,2)", Comparity.Equals, GetPrefixes());

                List<string> topicsList = GetTopics(false);
                if (topicsList.Count == 0)
                    topicsList = GetTopics(true);

                SearchCriterium topics = new SearchCriterium("Topic", Comparity.Equals, topicsList);
                criteria.Add(surveys);
                criteria.Add(prefixes);
                criteria.Add(topics);

                var questions = DBAction.GetSurveyQuestions(criteria).GroupBy(x => x.VarName.Content.ID).Select(grp => grp.ToList()).ToList();

                List<SurveyQuestion> contents = new List<SurveyQuestion>();
                foreach (var grp in questions)
                {
                    contents.Add(grp[0]);
                }



                foreach (SurveyQuestion s in contents)
                    lstContent.Items.Add(s.VarName.Content.LabelText);

                //foreach (VariableName s in contents)
                //    if (!lstContent.Items.Contains(s.Content.LabelText)) lstContent.Items.Add(s.Content.LabelText);

            }
            lstContent.Tag = true;
            lstContent.SetSelected(0, true);

            UpdateProducts();
        }

        /// <summary>
        /// Fill the Product list box with labels. The labels are those that are used by questions with the selected Prefix, Topic and Content labels.
        /// </summary>
        private void UpdateProducts()
        {
            lstProduct.Items.Clear();
            lstProduct.Items.Add("<All>");

            if (lstContent.Items.Count ==1)
                return;

            List<SearchCriterium> criteria = new List<SearchCriterium>();

            SearchCriterium surveys = new SearchCriterium("Survey", Comparity.Equals, GetSurveys());
            SearchCriterium prefixes = new SearchCriterium("SUBSTRING(VarName,1,2)", Comparity.Equals, GetPrefixes());

            List<string> topicsList = GetTopics(false);
            if (topicsList.Count ==0)
                topicsList = GetTopics(true);

            SearchCriterium topics = new SearchCriterium("Topic", Comparity.Equals, topicsList);

            List<string>contentList = GetContents(false);
            if (contentList.Count == 0)
                contentList = GetContents(true);

            SearchCriterium contents = new SearchCriterium("Content", Comparity.Equals, contentList);

            criteria.Add(surveys);
            criteria.Add(prefixes);
            criteria.Add(topics);
            criteria.Add(contents);

            var questions = DBAction.GetSurveyQuestions(criteria).GroupBy(x => x.VarName.Product.ID).Select(grp => grp.ToList()).ToList();

            List<SurveyQuestion> products = new List<SurveyQuestion>();
            foreach (var grp in questions)
            {
                products.Add(grp[0]);
            }

            foreach (SurveyQuestion s in products)
                lstProduct.Items.Add(s.VarName.Product.LabelText);

            //foreach (VariableName s in products)
            //    if (!lstProduct.Items.Contains(s.Product.LabelText)) lstProduct.Items.Add(s.Product.LabelText);
            
            lstProduct.Tag = true;
            lstProduct.SetSelected(0, true);
        }

        /// <summary>
        /// Run the report. Create a crosstab table based on the form selections, then output it to Word.
        /// </summary>
        private void RunReport()
        {
            // get selections
            List<string> surveys = GetSurveys();
            List<string> topics;
            List<string> contents;
            
            List<string> products;
            List<string> exclusions = new List<string>();

            if (lstTopic.GetSelected(0))
                topics = GetTopics(true);
            else
                topics = GetTopics(false);

            if (lstContent.GetSelected(0))
                contents = GetContents(true);
            else
                contents = GetContents(false);

            if (lstProduct.GetSelected(0))
                products = GetProducts(true);
            else
                products = GetProducts(false);

            if (!chkIncludeNA.Checked)
                products.Remove("N/A");

            // make crosstab table
            DataTable crosstab = DBAction.GetProductsVariableList(surveys, topics, contents, products, exclusions);

            // add in # heading
            AddTensColumn(crosstab);
            // add in summary row
            AddHundredRow(crosstab);
             

            DataTableReport rpt = new DataTableReport(crosstab, "Product Crosstab Report");
            rpt.CreateReport();
        }

        private void AddTensColumn(DataTable crosstab )
        {
            List<string> products;
            if (lstProduct.GetSelected(0))
                products = GetProducts(true);
            else
                products = GetProducts(false);

            DataColumn tensColumn = new DataColumn("#", Type.GetType("System.String"));
            crosstab.Columns.Add(tensColumn);

            foreach (DataRow r in crosstab.Rows)
            {
                List<string> tens = new List<string>();
                foreach (DataColumn c in crosstab.Columns)
                {
                    if (!products.Contains(c.ColumnName))
                        continue;

                    string[] values = r[c].ToString().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in values)
                    {
                        if (!tens.Contains(s.Substring(3, 1) + "0"))
                            tens.Add(s.Substring(3, 1) + "0");
                    }
                }
                tens.Sort();

                r[tensColumn] = string.Join(", ", tens);
            }
        }

        private void AddHundredRow(DataTable crosstab)
        {
            List<string> products;
            if (lstProduct.GetSelected(0))
                products = GetProducts(true);
            else
                products = GetProducts(false);

            crosstab.Rows.InsertAt(crosstab.NewRow(), 0);

            foreach (DataColumn c in crosstab.Columns)
            {
                if (!products.Contains(c.ColumnName))
                    continue;

                List<string> hundreds = new List<string>();
                foreach (DataRow r in crosstab.Rows)
                {
                    
                    string[] values = r[c].ToString().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in values)
                    {
                        if (!hundreds.Contains(s.Substring(2, 1) + "00"))
                            hundreds.Add(s.Substring(2, 1) + "00");
                    }

                }
                hundreds.Sort();
                
                crosstab.Rows[0][c] = string.Join(", ", hundreds);
            }
        }

        private List<string> GetPrefixes()
        {
            List<string> prefixes = new List<string>();
            for (int i = 0; i < lstPrefix.Items.Count; i++)
            {
                if (lstPrefix.Items[i].Equals("<All>") || !lstPrefix.GetSelected(i))
                    continue;

                prefixes.Add(lstPrefix.Items[i].ToString());
            }

            return prefixes;
        }
        private List<string> GetSurveys()
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

        private List<string> GetTopics(bool all)
        {
            List<string> topics = new List<string>();

            for (int i = 0; i < lstTopic.Items.Count; i++)
            {
                if (lstTopic.Items[i].Equals("<All>") || (!lstTopic.GetSelected(i) && !all))
                    continue;

                topics.Add(lstTopic.Items[i].ToString());
            }

            return topics;
        }

        private List<string> GetContents(bool all)
        {
            List<string> contents = new List<string>();

            for (int i = 0; i < lstContent.Items.Count; i++)
            {
                if (lstContent.Items[i].Equals("<All>") || (!lstContent.GetSelected(i) && !all))
                    continue;

                contents.Add(lstContent.Items[i].ToString());
            }

            return contents;
        }

        private List<string> GetProducts(bool all)
        {
            List<string> products = new List<string>();

            for (int i = 0; i < lstProduct.Items.Count; i++)
            {
                if (lstProduct.Items[i].Equals("<All>") || (!lstProduct.GetSelected(i) && !all))
                    continue;

                products.Add(lstProduct.Items[i].ToString());
            }

            return products;
        }

        #endregion

        
    }
}
