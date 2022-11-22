using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDIFrontEnd
{
    public partial class RichTextEditor : Form
    {
        public string OriginalText { get; set; }
        public string EditedText { get; set; }

        public RichTextEditor(string text)
        {
            InitializeComponent();
            OriginalText = text;
            rtbEditor.Rtf = text;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            EditedText = OriginalText;
            Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            EditedText = rtbEditor.Rtf;
            Close();
        }

        private void cmdBold_Click(object sender, EventArgs e)
        {
            Font oldFont = rtbEditor.SelectionFont;
            Font newFont;

            if (oldFont.Bold)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);

            rtbEditor.SelectionFont = newFont;
        }

        private void cmdItalic_Click(object sender, EventArgs e)
        {
            Font oldFont = rtbEditor.SelectionFont;
            Font newFont;

            if (oldFont.Italic)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Italic);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);

            rtbEditor.SelectionFont = newFont;
        }

        private void cmdUnderline_Click(object sender, EventArgs e)
        {
            Font oldFont = rtbEditor.SelectionFont;
            Font newFont;

            if (oldFont.Underline)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Underline);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Underline);

            rtbEditor.SelectionFont = newFont;
        }

        private void cmdStrikethrough_Click(object sender, EventArgs e)
        {
            Font oldFont = rtbEditor.SelectionFont;
            Font newFont;

            if (oldFont.Strikeout)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Strikeout);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Strikeout);

            rtbEditor.SelectionFont = newFont;
        }

        private void cmdHighlight_Click(object sender, EventArgs e)
        {
            if (rtbEditor.SelectionBackColor == Color.Yellow)
            {
                rtbEditor.SelectionBackColor = Color.White;
            }
            else
            {
                rtbEditor.SelectionBackColor = Color.Yellow;
            }
        }
    }
}
