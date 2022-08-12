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
    
    public partial class ImportedDuplicates : Form
    {
        List<Translation> Duplicates { get; set; }
        BindingSource bs;

        public ImportedDuplicates(List<Translation> duplicates)
        {
            InitializeComponent();

            this.MouseWheel += ImportedDuplicates_MouseWheel;

            Duplicates = duplicates;
            bs = new BindingSource();
            bs.DataSource = Duplicates;
            navDuplicates.BindingSource = bs;

            txtSurvey.DataBindings.Add(new Binding("Text", bs, "Survey"));
            txtVarName.DataBindings.Add(new Binding("Text", bs, "VarName"));
            rtbTranslationText.DataBindings.Add(new Binding("RTF", bs, "TranslationRTF"));
        }

        private void ImportedDuplicates_MouseWheel(object sender, MouseEventArgs e)
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
