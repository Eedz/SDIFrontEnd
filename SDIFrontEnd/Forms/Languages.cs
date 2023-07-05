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
    public partial class Languages : Form
    {
        List<Language> Records;
        BindingSource bs;

        public Languages()
        {
            InitializeComponent();

            Records = DBAction.ListLanguages();

            bs = new BindingSource();
            bs.DataSource = Records;

            dgv.DataSource = bs;
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow newRow = dgv.Rows[e.RowIndex];

            Language newLanguage = (Language)newRow.DataBoundItem;
            if (newLanguage == null)
                return;

            if (newLanguage.ID > 0)
            {
                // update language
                if (DBAction.UpdateLanguage(newLanguage) == 1)
                    MessageBox.Show("Error updating language.");
            }
            else
            {
                // insert language
                if (DBAction.InsertLanguage(newLanguage) == 1)
                    MessageBox.Show("Error adding new language.");
            }
        }
    }
}
