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
    /// Displays the different sets of labels for a particular refVarName.
    /// </summary>
    public partial class VariableLabelSelector : Form
    {
        public SurveyEntry frmParent;
        List<RefVariableName> Variables;
        int panelTop = 80;
        int panelHeight = 180;
        int panelGap = 10; // space between panels

        int varnameTop = 0;
        int varnameHeight = 20;
        int boxGap = 5;

        public VariableLabelSelector(string refVarName)
        {
            Variables = DBAction.GetRefVarNames(refVarName);
            InitializeComponent();
        }

        private void VariableLabelSelector_Load(object sender, EventArgs e)
        {
            CreatePanels();   
        }

        private void CreatePanels()
        {
            int index = 1;
            // create copies of the panelVar1 for each item in the current bindingsource
            foreach (RefVariableName v in Variables)
            {

                // add a new panel
                Panel p = new Panel();

                if (index == 1)
                    p.Top = panelTop;
                else
                    p.Top = panelTop + (panelHeight + panelGap) * (index - 1);

                p.Left = 17;
                p.Height = panelHeight;
                p.Width = 400;
                p.BorderStyle = BorderStyle.FixedSingle;

                // varname label and box
                Label varnameLabel = new Label();
                varnameLabel.Text = "VarName";
                varnameLabel.Top = varnameTop;
                varnameLabel.Left = 0;
                varnameLabel.Width = 54;
                TextBox varname = new TextBox();
                varname.Text = v.refVarName;
                varname.Top = varnameTop;
                varname.Left = 55;
                // varlabel label and box
                Label varlabelLabel = new Label();
                varlabelLabel.Text = "VarLabel";
                varlabelLabel.Top = varnameTop + varnameHeight + boxGap;
                varlabelLabel.Left = 0;
                varlabelLabel.Width = 50;
                TextBox varlabel = new TextBox();
                varlabel.Text = v.VarLabel;
                varlabel.Top = varnameTop + varnameHeight + boxGap;
                varlabel.Left = 55;
                varlabel.Width = 300;
                // domain label and box
                Label domainLabel = new Label();
                domainLabel.Text = "Domain";
                domainLabel.Top = (varnameTop + varnameHeight + boxGap) * 2;
                domainLabel.Left = 0;
                domainLabel.Width = 50;
                TextBox domain = new TextBox();
                domain.Text = v.Domain.LabelText;
                domain.Top = (varnameTop + varnameHeight + boxGap) * 2;
                domain.Left = 55;
                domain.Width = 300;
                // topic label and box
                Label topicLabel = new Label();
                topicLabel.Text = "Topic";
                topicLabel.Top = (varnameTop + varnameHeight + boxGap) * 3;
                topicLabel.Left = 0;
                topicLabel.Width = 50;
                TextBox topic = new TextBox();
                topic.Text = v.Topic.LabelText;
                topic.Top = (varnameTop + varnameHeight + boxGap) * 3;
                topic.Left = 55;
                topic.Width = 300;
                // content label and box
                Label contentLabel = new Label();
                contentLabel.Text = "Content";
                contentLabel.Top = (varnameTop + varnameHeight + boxGap) * 4;
                contentLabel.Left = 0;
                contentLabel.Width = 50;
                TextBox content = new TextBox();
                content.Text = v.Content.LabelText;
                content.Top = (varnameTop + varnameHeight + boxGap) * 4;
                content.Left = 55;
                content.Width = 300;
                // product label
                Label productLabel = new Label();
                productLabel.Text = "Product";
                productLabel.Top = (varnameTop + varnameHeight + boxGap) * 5;
                productLabel.Left = 0;
                productLabel.Width = 50;
                TextBox product = new TextBox();
                product.Text = v.Product.LabelText;
                product.Top = (varnameTop + varnameHeight + boxGap) * 5;
                product.Left = 55;
                product.Width = 300;
                // select button
                Button select = new Button();
                select.Top = 0;
                select.Left = 300;
                select.Text = "Select";
                select.Click += Select_Click;

                p.Controls.Add(varnameLabel);
                p.Controls.Add(varname);
                p.Controls.Add(varlabelLabel);
                p.Controls.Add(varlabel);
                p.Controls.Add(domainLabel);
                p.Controls.Add(domain);
                p.Controls.Add(topicLabel);
                p.Controls.Add(topic);
                p.Controls.Add(contentLabel);
                p.Controls.Add(content);
                p.Controls.Add(productLabel);
                p.Controls.Add(product);
                p.Controls.Add(select);

                this.Controls.Add(p);
                p.Tag = index - 1;
                index++;

            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            if (frmParent == null)
            {
                MessageBox.Show("Parent form not set.");
                return;
            }

            Button selectButton = (Button)sender;
            Panel p = (Panel) selectButton.Parent;

            RefVariableName r = Variables[(int)p.Tag];

            try
            {
                frmParent.SetLabels(r.VarLabel, r.Domain, r.Topic, r.Content, r.Product);
            }
            catch
            {
                MessageBox.Show("Parent form does not implement SetLabels.");
            }

            Close();
        }

        private void cmdOpenAssignLabels_Click(object sender, EventArgs e)
        {

        }

        private void cmdOpenVarDetails_Click(object sender, EventArgs e)
        {

        }
    }
}
