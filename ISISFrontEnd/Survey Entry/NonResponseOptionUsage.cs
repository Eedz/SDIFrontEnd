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
     // TODO moving to next item is triggering ListChanged event
     // TODO allow editing of rich text, allow bold, italics (on save, convert RTF to HTML)
    public partial class NonResponseOptionUsage : Form
    {
        public SurveyEntry frmParent;
        public string key; // TODO maybe not needed

        List<ResponseSet> ResponseSets;
        BindingSource bs;
       

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
                    lblTitle.Text = "Document Wording Usage*";
                }
                else
                {
                    lblTitle.Text = "Document Wording Usage";
                }
            }
        }

        public NonResponseOptionUsage()
        {
            InitializeComponent();

            ResponseSets = DBAction.GetResponseSets("NRCodes");

            bs = new BindingSource
            {
                DataSource = ResponseSets
            };
            bs.ListChanged += Bs_ListChanged;
            navWordings.BindingSource = bs;
            this.MouseWheel += WordingUsage_MouseWheel;


            


        }

        public NonResponseOptionUsage(string fieldname, string respName)
        {
            InitializeComponent();

            ResponseSets = DBAction.GetResponseSets(fieldname);

            bs = new BindingSource
            {
                DataSource = ResponseSets
            };
            bs.ListChanged += Bs_ListChanged;
            navWordings.BindingSource = bs;
            this.MouseWheel += WordingUsage_MouseWheel;


            // navigate to wordID
            foreach (ResponseSet r in ResponseSets)
            {

                if (r.RespSetName != respName)
                    bs.MoveNext();
                else
                    break;
            }

            
           

        }

        private void NonResponseOptionUsage_Load(object sender, EventArgs e)
        {
            BindProperties();

            Color temp = Color.FromArgb(0xCCCC99);
            Color result = Color.FromArgb(temp.R, temp.G, temp.B);
            this.BackColor = result;

            LoadUsageList(txtFieldName.Text, txtWordID.Text);
        }

        private void Bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            Dirty = true;
        }

        private void MoveRecord(int count)
        {

            if (count > 0)
                for (int i = 0; i < count; i++)
                {
                    bs.MoveNext();
                }
            else
                for (int i = 0; i < Math.Abs(count); i++)
                {
                    bs.MovePrevious();
                }
        }

        private void SaveRecord()
        {
            ResponseSet current = (ResponseSet)bs.Current;
            if (current.RespSetName == "0") // new wording created by this form
            {
                // insert into table
                DBAction.InsertResponseSet(current);
                Dirty = false;
            }
            else if (Dirty) // existing study edited
            {
                DBAction.UpdateResponseSet(current);
                Dirty = false;
            }
        }

        /// <summary>
        /// When moving to the next/previous item, check if there are changes, save them and then move to the next record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WordingUsage_MouseWheel(object sender, MouseEventArgs e)
        {
            SaveRecord();
            if (e.Delta == -120)
                MoveRecord(1);
            else if (e.Delta == 120)
                MoveRecord(-1);

        }

        private void BindProperties()
        {
            txtFieldName.DataBindings.Add("Text", bs, "FieldName");
            txtWordID.DataBindings.Add("Text", bs, "RespSetName");
           // txtWording.DataBindings.Add("Text", bs, "WordingText");
            txtWordingR.DataBindings.Add("RTF", bs, "RespListR");

            
        }

        private void LoadUsageList(string field, string respName)
        {
            if (respName == "0")
            {
                dgvWordingUsage.Visible = false;
                lblUses.Visible = false;
            }
            else
            {

                dgvWordingUsage.DataSource = DBAction.GetResponseUsage(field, respName);
                for (int i = 0; i < dgvWordingUsage.ColumnCount; i++)
                {

                    if (dgvWordingUsage.Columns[i].Name == "RespName")
                    {
                        dgvWordingUsage.Columns[i].Name = field;
                        dgvWordingUsage.Columns[i].HeaderText = field;
                        break;
                    }


                }
                dgvWordingUsage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvWordingUsage.Visible = true;
                lblUses.Visible = true;
            }
        }

        private void cmdSearchClip_Click(object sender, EventArgs e)
        {
            string searchTerm = Clipboard.GetText();
            
            bs.DataSource = ResponseSets.Where(x => x.RespSetName.Contains(searchTerm));
            navWordings.BindingSource = null;
            navWordings.BindingSource = bs;
        }

        public int FilterWordings(string criteria)
        {
            bs.DataSource = ResponseSets.Where(x => x.RespList.Contains(criteria));
            navWordings.BindingSource = null;
            navWordings.BindingSource = bs;

            return bs.Count;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            // TODO go to new wording
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            // TODO remove from list, then remove from database
        }

        #region Navigator button events
        /// <summary>
        /// When moving to the next item, check if there are changes, save them and then move to the next record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            MoveRecord(1);
            LoadUsageList(txtFieldName.Text, txtWordID.Text);
        }

        /// <summary>
        /// When moving to the next item, check if there are changes, save them and then move to the next record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            MoveRecord(-1);
            LoadUsageList(txtFieldName.Text, txtWordID.Text);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            bs.MoveLast();
            LoadUsageList(txtFieldName.Text, txtWordID.Text);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            bs.MoveFirst();
            LoadUsageList(txtFieldName.Text, txtWordID.Text);
        }


        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
        }
        #endregion

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
