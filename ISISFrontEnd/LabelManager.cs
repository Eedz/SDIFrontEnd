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
    // TODO label usage counts
    public partial class LabelManager : Form
    {
        public MainMenu frmParent;
        public string key;

        List<DomainLabel> domains;
        List<TopicLabel> topics;
        List<ContentLabel> contents;
        List<ProductLabel> products;

        public string currentType;

        public LabelManager()
        {
            InitializeComponent();
            gridLabels.AutoGenerateColumns = false;
            optDomain.Checked = true;
        }

        private void LabelType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = (RadioButton)sender;

            currentType = (string)r.Tag;

            GetLabels();

            UpdateGridView();
        }

        private void GetLabels()
        {
            switch (currentType) {
                case "domain":
                    domains = DBAction.ListDomainLabels();
                    break;
                case "topic":
                    topics = DBAction.GetTopicLabels();
                    break;
                case "content":
                    contents = DBAction.GetContentLabels();
                    break;
                case "product":
                    products = DBAction.GetProductLabels();
                    break;
            }
        }

        private void UpdateGridView()
        {
            switch (currentType)
            {
                case "domain":
                    gridLabels.DataSource = domains;
                    
                    break;
                case "topic":
                    gridLabels.DataSource = topics;
                    break;
                case "content":
                    gridLabels.DataSource = contents;
                    break;
                case "product":
                    gridLabels.DataSource = products;
                    break;
            }

            gridLabels.Columns["Label"].DataPropertyName = "LabelText";
            gridLabels.Columns["ID"].DataPropertyName = "ID";
            // gridLabels.Columns["Uses"].DataPropertyName = "Uses";

        }

        private void cmdNewLabel_Click(object sender, EventArgs e)
        {
            InputBox frm = new InputBox("New label text", "Enter New Label");

            frm.ShowDialog();

            string newLabel = frm.userInput;

            if (DBAction.InsertLabel(currentType, newLabel) == 1)
                MessageBox.Show("Error creating label");
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LabelManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmParent.CloseTab(key);
        }

        
    }
}
