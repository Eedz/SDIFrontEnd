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
    public partial class CleanupComments : Form
    {
        List<DeletedComment> Comments;
        BindingSource bs;
        public CleanupComments(List<DeletedComment> comments)
        {
            InitializeComponent();

            Comments = comments;
            bs = new BindingSource()
            {
                DataSource = Comments
            };

            BindProperties();

            dataRepeater1.DataSource = bs; 
        }

        public CleanupComments(List<SurveyQuestion> deletedQuestions)
        {
            InitializeComponent();

            List<DeletedComment> comments = new List<DeletedComment>();
            foreach (SurveyQuestion qr in deletedQuestions)
                comments.AddRange(DBAction.GetDeletedComments(qr.SurveyCode, qr.VarName.VarName));

            Comments = comments;
            bs = new BindingSource()
            {
                DataSource = Comments
            };

            BindProperties();

            dataRepeater1.DataSource = bs;
        }

        private void BindProperties()
        {
            txtSurvey.DataBindings.Add("Text", bs, "Survey");
            txtVarName.DataBindings.Add("Text", bs, "VarName");
            txtNoteDate.DataBindings.Add("Text", bs, "NoteDateOnly");
            txtSource.DataBindings.Add("Text", bs, "Source");
            txtComment.DataBindings.Add("Text", bs, "Notes.NoteText");
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            var datasource = ((BindingSource)dataRepeater1.DataSource);
            int index = dataRepeater1.CurrentItemIndex;
            int id =  ((Comment)datasource[index]).ID;

            if (DBAction.DeleteDeletedComment(id)==1)
            {
                MessageBox.Show("Error deleting comment.");
            }
            Comments.RemoveAt(index);
            bs.ResetBindings(false);
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataRepeater1_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            var dataRepeater = (Microsoft.VisualBasic.PowerPacks.DataRepeater)sender;
            var datasource = (List<DeletedComment>)((BindingSource)dataRepeater.DataSource).List;
            DeletedComment item = datasource[e.DataRepeaterItem.ItemIndex];

            var author = (TextBox)e.DataRepeaterItem.Controls.Find("txtAuthor", false)[0];
            author.Text = item.Author.Name;

            var authority = (TextBox)e.DataRepeaterItem.Controls.Find("txtAuthority", false)[0];
            authority.Text = item.Authority.Name;

            var type = (TextBox)e.DataRepeaterItem.Controls.Find("txtType", false)[0];
            type.Text = item.NoteType.TypeName;

            var notes = (TextBox)e.DataRepeaterItem.Controls.Find("txtComment", false)[0];
            notes.Text = item.Notes.NoteText;
        }
    }
}
