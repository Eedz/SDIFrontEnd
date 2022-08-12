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
    // TODO adjust height base on number of comments
    public partial class ViewQuestionComments : Form
    {
        List<QuestionComment> CommentList;
        BindingSource bs;
        SurveyQuestion CurrentQuestion;
        bool Dirty;

        int minHeight = 47;
        int maxHeight = 595;

        public ViewQuestionComments(SurveyQuestion question)
        {
            InitializeComponent();

            CommentList = new List<QuestionComment>(question.Comments);
            CurrentQuestion = question;

            bs = new BindingSource();
            bs.DataSource = CommentList;

            

            BindProperties();
     

            dataRepeater1.DataSource = bs;
       
            lblTitle.Text = "Comments for " + question.SurveyCode + "." + question.VarName.RefVarName;
        }

        private void ViewQuestionComments_Load(object sender, EventArgs e)
        {
            if (dataRepeater1.ItemCount == 0)
            {
                this.Height = minHeight + +dataRepeater1.ItemTemplate.Height;
            }
            else if (dataRepeater1.ItemCount <= 3)
            {
                this.Height = minHeight + dataRepeater1.ItemTemplate.Height * dataRepeater1.ItemCount;
            }
            else
            {
                this.Height = maxHeight;
            }
        }

        /// <summary>
        /// Bind the simple properties.
        /// </summary>
        private void BindProperties()
        {
            txtNoteAuthority.DataBindings.Add("Text", bs, "SourceName");
            txtNoteSource.DataBindings.Add("Text", bs, "Source");
            dtpNoteDate.DataBindings.Add("Value", bs, "NoteDate");
        }

        
        /// <summary>
        /// Bind the complex properties.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataRepeater1_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var panel = (Panel)e.DataRepeaterItem.Controls.Find("panel1", false)[0];
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)sender;
            var datasource = ((BindingSource)dataRepeater.DataSource);
            var currentQuestion = ((QuestionComment)datasource[e.DataRepeaterItem.ItemIndex]);

            var noteText = (TextBox)panel.Controls.Find("txtComment", false)[0];
            noteText.Text = currentQuestion.Notes.NoteText;

            var noteAuthor = (ComboBox)panel.Controls.Find("cboAuthor", false)[0];
            noteAuthor.SelectedItem = currentQuestion.Author;

            var noteType = (ComboBox)panel.Controls.Find("cboNoteType", false)[0];
            noteType.SelectedItem = currentQuestion.NoteType;


            
        }

        /// <summary>
        /// Fill the comboboxes when an item is cloned.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataRepeater1_ItemCloned(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var panel = (Panel)e.DataRepeaterItem.Controls.Find("panel1", false)[0];
            var combo = (ComboBox)panel.Controls.Find("cboAuthor", false)[0];
            //Set the data source
            combo.DisplayMember = "Name";
            combo.ValueMember = "ID";
            combo.DataSource = new List<Person>(Globals.AllPeople);

            var combo2 = (ComboBox)panel.Controls.Find("cboNoteType", false)[0];
            //Set the data source
            combo2.DisplayMember = "TypeName";
            combo2.ValueMember = "ID";
            combo2.DataSource = new List<CommentType>(Globals.AllCommentTypes);
        }


        private void cmdAdd_Click(object sender, EventArgs e)
        {
            OpenCommentEntry(true);



        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdOpenCommentUsage_Click(object sender, EventArgs e)
        {
            OpenCommentEntry(false);

        }

        private void OpenCommentEntry(bool newrecord)
        {
            if (newrecord)
            {
                CommentEntry frm = new CommentEntry(CurrentQuestion);
                frm.ShowDialog();
            }
            else
            {
                var datasource = ((BindingSource)dataRepeater1.DataSource);
                int index = dataRepeater1.CurrentItemIndex;
                CommentEntry frm = new CommentEntry(((QuestionComment)datasource[index]).CID);
                frm.ShowDialog();
            }
            
        }

        public void UpdateQuestion(SurveyQuestion question)
        {
            CommentList = new List<QuestionComment>(question.Comments);
            bs.DataSource = CommentList;
            dataRepeater1.DataSource = bs;
            lblTitle.Text = "Comments for " + question.SurveyCode + "." + question.VarName.RefVarName;
        }

        private void cboAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            var panel = (Panel)combo.Parent;
            var dataRepeaterItem = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem)panel.Parent;
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)panel.Parent.Parent;

            var source = (List<QuestionComment>)((BindingSource)dataRepeater.DataSource).DataSource;
            source[dataRepeaterItem.ItemIndex].Author = (Person)combo.SelectedItem;
        }

        

        private void panel1_Leave(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            Microsoft.VisualBasic.PowerPacks.DataRepeaterItem item = (Microsoft.VisualBasic.PowerPacks.DataRepeaterItem) p.Parent;
            
            var datasource = ((BindingSource)dataRepeater1.DataSource);
            int index = dataRepeater1.CurrentItemIndex;
            QuestionComment itemComment = (QuestionComment)datasource[index];

            if (itemComment.ID == 0)
            {
                if (DBAction.InsertQuestionComment(itemComment) == 1)
                    MessageBox.Show("Error creating comment");

            }
            else if (item.IsDirty || Dirty)
            {

                if (DBAction.UpdateQuestionComment(itemComment) != 1) 
                    Dirty = false;
            }
        }

        
        private void cboNoteType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Dirty = true;
            
        }

        private void cboAuthor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Dirty = true;
        }

        
    }
}
