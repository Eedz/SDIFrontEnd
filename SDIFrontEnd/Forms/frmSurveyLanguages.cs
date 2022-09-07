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
    public partial class frmSurveyLanguages : Form
    {
        BindingSource bs;
        BindingSource bsLanguage;

        List<SurveyLanguage> records;
        List<Language> AvailableLanguages;
        int defaultSurvID;
        bool newRow = false;
        bool editedRow = false;

        public frmSurveyLanguages(Survey survey)
        {
            InitializeComponent();
            defaultSurvID = survey.SID;
            records = survey.LanguageList;
            bs = new BindingSource();
            bsLanguage = new BindingSource();

            bs.DataSource = records;
          
            chID.DataPropertyName = "ID";
            chSurvID.DataPropertyName = "SurvID";

            AvailableLanguages = DBAction.ListLanguages();

            chLangID.DataSource = AvailableLanguages;
            chLangID.DisplayMember = "LanguageName";
            chLangID.ValueMember = "ID";
            chLangID.DataPropertyName = "SurvLanguage";
            chLangID.ValueType = typeof(Language);
            


            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bs;


            lblTitle.Text = survey.SurveyCode + " Languages";
        }

        

        private void newLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLanguages frm = new frmLanguages();
            frm.ShowDialog();

            dataGridView1.DataSource = records;
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            newRow = true;
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {

            e.Row.Cells["chSurvID"].Value = defaultSurvID;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dataGridView1.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the Language column.
            if (!headerText.Equals("Language")) return;


            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = AvailableLanguages.First(x => x.LanguageName.Equals(e.FormattedValue.ToString()));



        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SurveyLanguage theRow = (SurveyLanguage)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                if (!newRow && editedRow)
                {
                    // update language
                    if (DBAction.UpdateSurveyLanguage(theRow) == 1)
                        MessageBox.Show("Error updating language.");
                    editedRow = false;
                }
                else if (newRow)
                {

                    // insert language
                    if (DBAction.InsertSurveyLanguage(theRow) == 1)
                        MessageBox.Show("Error adding new language.");
                    newRow = false;
                }
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
           
            if (!dataGridView1.IsCurrentRowDirty)
                return;

            SurveyLanguage newLanguage = (SurveyLanguage)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            if (newLanguage == null)
                return;

            editedRow = newLanguage.ID > 0;
               
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }


    }
}
