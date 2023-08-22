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
    public partial class CommentList : Form
    {
        List<QuestionComment> Comments;
        BindingSource bs, bsPrev, bsNext;

        public CommentList(string survey, string varname, List<QuestionComment> comments )
        {
            InitializeComponent();

            Comments = comments;
            bs = new BindingSource();
            bsNext = new BindingSource();

            this.MouseWheel += CommentList_MouseWheel;          
            bs.PositionChanged += Bs_PositionChanged;

            lblTitle.Text = "Comments for " + survey + "." + varname;
            RefreshForm();
        }

        public void ChangeQuestion(string survey, string varname, List<QuestionComment> comments)
        {
            Comments = comments;
            lblTitle.Text = "Comments for " + survey + "." + varname;
            RefreshForm();
        }

        private void CommentList_MouseWheel(object sender, MouseEventArgs e)
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
            MoveRecord();
        }

        private void MoveRecord()
        {
            //if (bs.Position == 0)
            //{
            //    bsPrev.Position = 0;
            //    // hide previous question
            //    panelPrev.Visible = false;
            //}
            //else
            //{
            //    bsPrev.Position = bs.Position - 1;
            //    panelPrev.Visible = true;
            //}

            if (bs.Position == bs.Count - 1)
            {
                bsNext.Position = bs.Count - 1;
                panelNext.Visible = false;
            }
            else
            {
                bsNext.Position = bs.Position + 1;
                panelNext.Visible = true;
            }
        }

        private void RefreshForm()
        {
            //bsPrev.Position = 0;
            bsNext.Position = 0;
            bs.Position = 0;

            //bsPrev.DataSource = Comments;
            bsNext.DataSource = Comments;
            bs.DataSource = Comments;


            navComments.BindingSource = bs;
            navComments.Refresh();

            foreach (Control c in this.panelCurrent.Controls)
            {
                if (c is TextBox || c is DateTimePicker || c is RichTextBox || c is CheckBox)
                {
                    c.DataBindings.Clear();
                }
            }

            //foreach (Control c in this.panelPrev.Controls)
            //{
            //    if (c is TextBox || c is DateTimePicker || c is RichTextBox || c is CheckBox)
            //    {
            //        c.DataBindings.Clear();
            //    }
            //}

            foreach (Control c in this.panelNext.Controls)
            {
                if (c is TextBox || c is DateTimePicker || c is RichTextBox || c is CheckBox)
                {
                    c.DataBindings.Clear();
                }
            }

            BindControl(panelCurrent.Controls["txtNoteDate"], "NoteDate");
            BindControl(panelCurrent.Controls["txtNoteInit"], "Name");
            BindControl(panelCurrent.Controls["txtNoteType"], "NoteType");

            BindControl(panelCurrent.Controls["txtNoteSource"], "Source");
            BindControl(panelCurrent.Controls["txtNoteAuth"], "SourceName");
            BindControl(panelCurrent.Controls["txtNote"], "Notes.NoteText");
            

            bs.Position = 0;
            MoveRecord();
        }

        private void BindControl(Control c, string member)
        {
            if (c is TextBox)
            {

                //panelPrev.Controls[c.Name + "Prev"].DataBindings.Add(new Binding("Text", bsPrev, member));
                panelCurrent.Controls[c.Name].DataBindings.Add(new Binding("Text", bs, member));
                panelNext.Controls[c.Name + "Next"].DataBindings.Add(new Binding("Text", bsNext, member));
            }
            else if (c is CheckBox)
            {
                // panelPrev.Controls[c.Name + "Prev"].DataBindings.Add(new Binding("Checked", bsPrev, member));
                panelCurrent.Controls[c.Name].DataBindings.Add(new Binding("Checked", bs, member));
                panelNext.Controls[c.Name + "Next"].DataBindings.Add(new Binding("Checked", bsNext, member));
            }
            else if (c is DateTimePicker)
            {
                //panelPrev.Controls[c.Name + "Prev"].DataBindings.Add(new Binding("Value", bsPrev, member));
                panelCurrent.Controls[c.Name].DataBindings.Add(new Binding("Value", bs, member));
                panelNext.Controls[c.Name + "Next"].DataBindings.Add(new Binding("Value", bsNext, member));
            }
        }
    }
}
