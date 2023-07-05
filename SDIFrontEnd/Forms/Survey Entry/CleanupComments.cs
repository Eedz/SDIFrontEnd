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
            txtSurvey.DataBindings.Add("Text", bs, "SurveyCode");
            txtVarName.DataBindings.Add("Text", bs, "VarName");
            txtNoteDate.DataBindings.Add("Text", bs, "NoteDateOnly");
            txtAuthor.DataBindings.Add("Text", bs, "NoteAuthor.Name");
            txtAuthority.DataBindings.Add("Text", bs, "NoteAuthority.Name");
            txtType.DataBindings.Add("Text", bs, "NoteType.TypeName");
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
    }
}
