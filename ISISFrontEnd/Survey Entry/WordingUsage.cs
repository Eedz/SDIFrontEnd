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
     
     // TODO allow editing of rich text, allow bold, italics (on save, convert RTF to HTML)
    public partial class WordingUsage : Form
    {
        public SurveyEntry frmParent;
        public string key; // TODO maybe not needed

        List<Wording> Wordings;
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

        public WordingUsage()
        {
            InitializeComponent();

            Wordings = DBAction.GetWordings();

            bs = new BindingSource
            {
                DataSource = Wordings
            };
            bs.ListChanged += Bs_ListChanged;

            navWordings.BindingSource = bs;
            this.MouseWheel += WordingUsage_MouseWheel;


            
        }

        public WordingUsage(string fieldname, int wordID)
        {
            InitializeComponent();

            Wordings = DBAction.GetWordings(fieldname);

            bs = new BindingSource
            {
                DataSource = Wordings
            };
            bs.ListChanged += Bs_ListChanged;
            
            navWordings.BindingSource = bs;
            this.MouseWheel += WordingUsage_MouseWheel;


            // navigate to wordID
            foreach (Wording w in Wordings)
            {

                if (w.WordID != wordID)
                    bs.MoveNext();
                else
                    break;
            }

            
           

        }

        private void WordingUsage_Load(object sender, EventArgs e)
        {
            BindProperties();

            Color temp = Color.FromArgb(0x71B5FF);
            Color result = Color.FromArgb(temp.R, temp.G, temp.B);
            this.BackColor = result;

            LoadUsageList(txtFieldName.Text, Int32.Parse(txtWordID.Text));
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
            Wording current = (Wording)bs.Current;
            if (current.WordID == 0) // new wording created by this form
            {
                // insert into table
                DBAction.InsertWording(current);
                Dirty = false;
            }
            else if (Dirty) // existing study edited
            {
                DBAction.UpdateWording(current);
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
            txtWordID.DataBindings.Add("Text", bs, "WordID");
           // txtWording.DataBindings.Add("Text", bs, "WordingText");
            txtWordingR.DataBindings.Add("RTF", bs, "WordingTextR");

            
        }

        private void LoadUsageList(string field, int wordID)
        {
            if (wordID == 0)
            {
                dgvWordingUsage.Visible = false;
                lblUses.Visible = false;
            }
            else
            {

                dgvWordingUsage.DataSource = DBAction.GetWordingUsage(field, wordID);
                for (int i = 0; i < dgvWordingUsage.ColumnCount; i++)
                {

                    if (dgvWordingUsage.Columns[i].Name == "WordID")
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
            
            bs.DataSource = Wordings.Where(x => x.WordingText.Contains(searchTerm));
            navWordings.BindingSource = null;
            navWordings.BindingSource = bs;
        }

        public int FilterWordings (string criteria)
        {
            bs.DataSource = Wordings.Where(x => x.WordingText.Contains(criteria));
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
            LoadUsageList(txtFieldName.Text, Int32.Parse(txtWordID.Text));
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
            LoadUsageList(txtFieldName.Text, Int32.Parse(txtWordID.Text));
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            bs.MoveLast();
            LoadUsageList(txtFieldName.Text, Int32.Parse(txtWordID.Text));
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            SaveRecord();
            bs.MoveFirst();
            LoadUsageList(txtFieldName.Text, Int32.Parse(txtWordID.Text));
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
