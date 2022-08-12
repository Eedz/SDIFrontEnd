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
    public partial class frmLanguages : Form
    {
        List<Language> languages;
        BindingSource bs;
        public frmLanguages()
        {
            InitializeComponent();
            languages = DBAction.ListLanguages();
            bs = new BindingSource();
            bs.DataSource = languages;
            dataGridView1.DataSource = bs;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow newRow = dataGridView1.Rows[e.RowIndex];

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
