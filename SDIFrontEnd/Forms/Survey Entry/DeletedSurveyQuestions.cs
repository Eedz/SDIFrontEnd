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
    /// <summary>
    /// This form displays all questions that were deleted from a particular survey.
    /// </summary>
    public partial class DeletedSurveyQuestions : Form
    {
        List<DeletedQuestion> DeletedQuestions;
        BindingSource bs;
        BindingSource bsComments;

        public DeletedSurveyQuestions(Survey s)
        {
            InitializeComponent();

            DeletedQuestions = DBAction.GetDeletedQuestions(s.SurveyCode);

            bs = new BindingSource();
            bs.DataSource = DeletedQuestions;
            bs.PositionChanged += Bs_PositionChanged;
            bsComments = new BindingSource();
            bsComments.DataSource = bs;
            bsComments.DataMember = "DeleteNotes";

            bindingNavigator2.BindingSource = bs;
            bindingNavigator1.BindingSource = bsComments;

            this.MouseWheel += DeletedSurveyQuestions_MouseWheel;

            cboGoToVar.DataSource = DeletedQuestions.Select(x => x.VarName).ToList();
            lblTitle.Text = "Questions Deleted from " + s.SurveyCode;

            BindProperties();
        }

        #region Form Setup
        private void BindProperties()
        {
            // deleted question
            txtVarName.DataBindings.Add("Text", bs, "VarName");
            txtVarLabel.DataBindings.Add("Text", bs, "VarLabel");
            txtDomain.DataBindings.Add("Text", bs, "DomainLabel");
            txtTopic.DataBindings.Add("Text", bs, "TopicLabel");
            txtContent.DataBindings.Add("Text", bs, "ContentLabel");
            txtDeletedOn.DataBindings.Add("Text", bs, "DeleteDate");
            txtDeletedBy.DataBindings.Add("Text", bs, "DeletedBy");

            // comments
            txtNoteDate.DataBindings.Add("Text", bsComments, "NoteDate");
            txtNoteAuthor.DataBindings.Add("Text", bsComments, "Author.Name");
            txtNoteType.DataBindings.Add("Text", bsComments, "NoteType.TypeName");
            txtAuthority.DataBindings.Add("Text", bsComments, "SourceName");
            txtNoteSource.DataBindings.Add("Text", bsComments, "Source");
            txtNote.DataBindings.Add("Text", bsComments, "Notes.NoteText");
        }
        #endregion

        #region Events
        private void DeletedSurveyQuestions_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == -120)
                bs.MoveNext();
            else if (e.Delta == 120)
            {
                bs.MovePrevious();
            }
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            lblComments.Text = "Comments: " + bsComments.Count;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void cboGoToVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGoToVar.SelectedItem == null)
                return;

            GoToVar((string)cboGoToVar.SelectedItem);
        }
        #endregion

        #region Methods 
        /// <summary>
        /// Navigate to the specified VarName.
        /// </summary>
        /// <param name="var"></param>
        private void GoToVar(string var)
        {
            int index = 0;
            int currentIndex = bs.Position;
            bool found = false;
            foreach (DeletedQuestion dq in DeletedQuestions)
            {
                if (dq.VarName == var)
                {
                    found = true;
                    break;
                }
                else
                {
                    index++;
                }
            }

            if (found) bs.Position = index;
        }
        #endregion

    }
}
