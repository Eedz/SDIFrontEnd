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
    public partial class ProductCrosstab : Form
    {
        // TODO basic report
        // TODO expanded report
        // TODO # column
        public ProductCrosstab()
        {
            InitializeComponent();

            lstSurvey.Tag = true;
            lstSurvey.Items.Add("<All>");
            foreach (Survey s in Globals.AllSurveys)
                lstSurvey.Items.Add(s.SurveyCode);

            lstSurvey.SetSelected(0, true);
            
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
            FormManager.Remove(this);
        }

        private void lstSurvey_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lst = (ListBox)sender;

            // only the <All> option is in the box
            if (lst.Items.Count == 1)
                return;

            lst.SelectedIndexChanged -= lstSurvey_SelectedIndexChanged;

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
        #endregion

        #region Methods
        private void UpdatePrefixes()
        {
            List<string> surveys = new List<string>();
            foreach (string s in lstSurvey.SelectedItems)
                surveys.Add(s);

            var prefixes = DBAction.GetVariablePrefixes(surveys);

            lstPrefix.Items.Clear();
            lstPrefix.Items.Add("<All>");
            foreach (string s in prefixes)
                if (!lstPrefix.Items.Contains(s)) lstPrefix.Items.Add(s);

            lstPrefix.Tag = true;
            lstPrefix.SetSelected(0, true);
        }

        private void UpdateTopics()
        {
            List<string> prefixes = new List<string>();
            foreach (string s in lstPrefix.SelectedItems)
                prefixes.Add(s);

            var topics = Globals.AllVarNames.Where(x=>prefixes.Contains(x.Prefix)).OrderBy(x=>x.Topic.LabelText).ToList();

            lstTopic.Items.Clear();
            lstTopic.Items.Add("<All>");
            foreach (VariableName s in topics)
                if (!lstTopic.Items.Contains(s.Topic.LabelText)) lstTopic.Items.Add(s.Topic.LabelText);

            lstTopic.Tag = true;
            lstTopic.SetSelected(0, true);
        }

        private void UpdateContent()
        {
            List<string> topics = new List<string>();
            foreach (string s in lstTopic.SelectedItems)
                topics.Add(s);

            var contents = Globals.AllVarNames.Where(x => topics.Contains(x.Topic.LabelText)).OrderBy(o=>o.Content.LabelText);

            lstContent.Items.Clear();
            lstContent.Items.Add("<All>");
            foreach (VariableName s in contents)
                if (!lstContent.Items.Contains(s.Content.LabelText)) lstContent.Items.Add(s.Content.LabelText);

            lstContent.Tag = true;
            lstContent.SetSelected(0, true);
        }

        private void UpdateProducts()
        {
            List<string> contents = new List<string>();
            foreach (string s in lstContent.SelectedItems)
                contents.Add(s);

            var products = Globals.AllVarNames.Where(x => contents.Contains(x.Product.LabelText));

            lstProduct.Items.Clear();
            lstProduct.Items.Add("<All>");
            foreach (VariableName s in products)
                if (!lstProduct.Items.Contains(s.Product.LabelText)) lstProduct.Items.Add(s.Product.LabelText);

            lstProduct.Tag = true;
            lstProduct.SetSelected(0, true);
        }

        private void RunReport()
        {

        }
        #endregion

        
    }
}
