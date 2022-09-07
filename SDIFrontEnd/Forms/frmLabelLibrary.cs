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
    public partial class frmLabelLibrary : Form
    {
        public enum LabelType { Domain, Topic, Content, Product, Keyword }
        int gap = 25;

        List<DomainLabel> DomainLabels { get; set; }
        List<TopicLabel> TopicLabels { get; set; }
        List<ContentLabel> ContentLabels { get; set; }
        List<ProductLabel> ProductLabels { get; set; }
        List<Keyword> Keywords { get; set; }

        LabelType CurrentType;

        public frmLabelLibrary()
        {
            InitializeComponent();

            DomainLabels = Globals.AllDomainLabels;
            TopicLabels = Globals.AllTopicLabels;
            ContentLabels = Globals.AllContentLabels;
            ProductLabels = Globals.AllProductLabels;
            Keywords = DBAction.GetKeywords();

            rbDomain.Checked = true;
            
        }

        #region Events
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            dgvLabels.Height = this.Height - dgvLabels.Top - menuStrip1.Height - gap;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewLabel();
        }

        private void showUsesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUses();
        }

        private void LabelTypeChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            switch (rb.Tag)
            {
                case "1":
                    showUsesToolStripMenuItem.Enabled = true;
                    CurrentType = LabelType.Domain;
                    break;
                case "2":
                    showUsesToolStripMenuItem.Enabled = true;
                    CurrentType = LabelType.Topic;
                    break;
                case "3":
                    showUsesToolStripMenuItem.Enabled = true;
                    CurrentType = LabelType.Content;
                    break;
                case "4":
                    showUsesToolStripMenuItem.Enabled = true;
                    CurrentType = LabelType.Product;
                    break;
                case "5":
                    showUsesToolStripMenuItem.Enabled = false;
                    CurrentType = LabelType.Keyword;
                    break;
            }

            LoadLabels(CurrentType);

        }

        private void dgvLabels_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // if label is double clicked, show editing form
            int id = Int32.Parse(dgvLabels.Rows[e.RowIndex].Cells[0].Value.ToString());

            if (id == 0)
            {
                MessageBox.Show("Label #0 is reserved and cannot be edited.");
                return;
            }
                 
            string label = dgvLabels.Rows[e.RowIndex].Cells[1].Value.ToString();
            InputBox frm = new InputBox("Edit Label", "Edit Label", label);
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.Cancel)
                return;

            // update in database
            if (DBAction.UpdateLabel(GetCurrentLabelType(), frm.userInput, id) == 1)
            {
                MessageBox.Show("Error: could not update " + GetCurrentLabelType() + " label #" + id);
                return;
            }
            // update on this form
            UpdateLabel(CurrentType, frm.userInput, id);
            // refresh list
            LoadLabels(CurrentType);
        }

        #endregion

        #region Methods

        private void ShowUses()
        {
            int id = Int32.Parse(dgvLabels.SelectedRows[0].Cells[0].Value.ToString());
            SurveyQuestionCriteria criteria = new SurveyQuestionCriteria();

            switch (CurrentType)
            {
                case LabelType.Domain:
                    criteria.DomainNums.Add(id);
                    break;
                case LabelType.Topic:
                    criteria.TopicNums.Add(id);
                    break;
                case LabelType.Content:
                    criteria.ContentNums.Add(id);
                    break;
                case LabelType.Product:
                    criteria.ProductNums.Add(id);
                    break;
                case LabelType.Keyword:
                    break;
            }

            frmLabelUses frm = new frmLabelUses(DBAction.GetSurveyQuestions(criteria));
            frm.Show();
        }

        private void UpdateLabel(LabelType type, string label, int id)
        {
            switch (CurrentType)
            {
                case LabelType.Domain:
                    DomainLabel editedDomain = DomainLabels.Where(x => x.ID == id).FirstOrDefault();
                    editedDomain.LabelText = label;
                    break;
                case LabelType.Topic:
                    TopicLabel editedTopic = TopicLabels.Where(x => x.ID == id).FirstOrDefault();
                    editedTopic.LabelText = label;
                    break;
                case LabelType.Content:
                    ContentLabel editedContent = ContentLabels.Where(x => x.ID == id).FirstOrDefault();
                    editedContent.LabelText = label;
                    break;
                case LabelType.Product:
                    ProductLabel editedProduct = ProductLabels.Where(x => x.ID == id).FirstOrDefault();
                    editedProduct.LabelText = label;
                    break;
                case LabelType.Keyword:
                    Keyword editedKeyword = Keywords.Where(x => x.ID == id).FirstOrDefault();
                    editedKeyword.LabelText = label;
                    break;
            }
        }

        private void AddNewLabel()
        {
            InputBox frm = new InputBox("New Label", "New Label", "New Label");
            frm.ShowDialog();

            string newLabel = frm.userInput;

            switch (CurrentType)
            {
                case LabelType.Domain:
                    DomainLabel newDomain = new DomainLabel(0, newLabel);
                    DBAction.InsertDomainLabel(newDomain);
                    Globals.AllDomainLabels.Add(newDomain);
                    
                    LoadLabels(LabelType.Domain);
                    break;
                case LabelType.Topic:
                    TopicLabel newTopic = new TopicLabel(0, newLabel);
                    DBAction.InsertTopicLabel(newTopic);
                    Globals.AllTopicLabels.Add(newTopic);
                    LoadLabels(LabelType.Topic);
                    break;
                case LabelType.Content:
                    ContentLabel newContent = new ContentLabel(0, newLabel);
                    DBAction.InsertContentLabel(newContent);
                    Globals.AllContentLabels.Add(newContent);
                    LoadLabels(LabelType.Content);
                    break;
                case LabelType.Product:
                    ProductLabel newProduct = new ProductLabel(0, newLabel);
                    DBAction.InsertProductLabel(newProduct);
                    Globals.AllProductLabels.Add(newProduct);
                    LoadLabels(LabelType.Product);
                    break;
                case LabelType.Keyword:
                    Keyword newKeyword = new Keyword(0, newLabel);
                    DBAction.InsertKeyword(newKeyword);
                    LoadLabels(LabelType.Keyword);
                    break;
            }
        }

        private void LoadLabels(LabelType type)
        {
            dgvLabels.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvLabels.Rows.Clear();

            switch (CurrentType)
            {
                case LabelType.Domain:
                    LoadDomainLabels();
                    break;
                case LabelType.Topic:
                    LoadTopicLabels();
                    break;
                case LabelType.Content:
                    LoadContentLabels();
                    break;
                case LabelType.Product:
                    LoadProductLabels();
                    break;
                case LabelType.Keyword:
                    LoadKeywords();
                    break;
            }
            
        }

        private void LoadDomainLabels()
        {
            foreach (DomainLabel d in DomainLabels)
            {
                int rowID = dgvLabels.Rows.Add();
                DataGridViewRow row = dgvLabels.Rows[rowID];

                row.Cells["chID"].Value = d.ID;
                row.Cells["chLabel"].Value = d.LabelText;
                row.Cells["chCount"].Value = d.Uses;

            }
        }

        private void LoadTopicLabels()
        {
            foreach (TopicLabel d in TopicLabels)
            {
                int rowID = dgvLabels.Rows.Add();
                DataGridViewRow row = dgvLabels.Rows[rowID];

                row.Cells["chID"].Value = d.ID;
                row.Cells["chLabel"].Value = d.LabelText;
                row.Cells["chCount"].Value = d.Uses;

            }
        }

        private void LoadContentLabels()
        {
            foreach (ContentLabel d in ContentLabels)
            {
                int rowID = dgvLabels.Rows.Add();
                DataGridViewRow row = dgvLabels.Rows[rowID];

                row.Cells["chID"].Value = d.ID;
                row.Cells["chLabel"].Value = d.LabelText;
                row.Cells["chCount"].Value = d.Uses;

            }
        }

        private void LoadProductLabels()
        {
            foreach (ProductLabel d in ProductLabels)
            {
                int rowID = dgvLabels.Rows.Add();
                DataGridViewRow row = dgvLabels.Rows[rowID];

                row.Cells["chID"].Value = d.ID;
                row.Cells["chLabel"].Value = d.LabelText;
                row.Cells["chCount"].Value = d.Uses;

            }
        }

        private void LoadKeywords()
        {
            foreach (Keyword d in Keywords)
            {
                int rowID = dgvLabels.Rows.Add();
                DataGridViewRow row = dgvLabels.Rows[rowID];

                row.Cells["chID"].Value = d.ID;
                row.Cells["chLabel"].Value = d.LabelText;
                row.Cells["chCount"].Value = DBAction.CountKeywordUses(d.ID);

            }
        }

        

        private string GetCurrentLabelType()
        {
            switch (CurrentType)
            {
                case LabelType.Domain:
                    return "Domain";
                case LabelType.Topic:
                    return "Topic";
                case LabelType.Content:
                    return "Content";
                case LabelType.Product:
                    return "Product";
                case LabelType.Keyword:
                    return "Keyword";
            }
            return "";
        }

        #endregion
    }
}
