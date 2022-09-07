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
    public partial class ImportedEmpties : Form
    {
        List<Translation> Empties { get; set; }
        BindingSource bs;

        public ImportedEmpties(List<Translation> empties)
        {
            InitializeComponent();

            this.MouseWheel += ImportedEmpties_MouseWheel;

            Empties = empties;
            bs = new BindingSource();
            bs.DataSource = Empties;
            navEmpties.BindingSource = bs;

            txtSurvey.DataBindings.Add(new Binding("Text", bs, "Survey"));
            txtVarName.DataBindings.Add(new Binding("Text", bs, "VarName"));
            rtbTranslationText.DataBindings.Add(new Binding("RTF", bs, "TranslationRTF"));
        }

        private void ImportedEmpties_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == -120)
                bs.MoveNext();
            else if (e.Delta == 120)
            {
                bs.MovePrevious();
            }
        }
    }
}
