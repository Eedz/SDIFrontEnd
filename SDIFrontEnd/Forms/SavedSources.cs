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
    public partial class SavedSources : Form
    {

        private class SourceObj
        {
            public string Source { get; set; }

            public SourceObj(string source)
            {
                Source = source;
            }
        }
        List<SourceObj> Sources;
        List<string> Sources2;
        public string SelectedSource;
        BindingSource bs;

        public SavedSources(List<string> sources)
        {
            InitializeComponent();
            Sources = new List<SourceObj>();
            foreach (string s in sources)
                Sources.Add(new SourceObj(s));

            Sources2 = sources;

            bs = new BindingSource();
            bs.DataSource = Sources;
            
            dataRepeater1.DataSource = bs;

            txtSource.DataBindings.Add("Text", bs, "Source");
        }

        private void cmdUse_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            SelectedSource = Sources[dataRepeater1.CurrentItemIndex].Source;
            Close();
        }

        private void txtSource_Validated(object sender, EventArgs e)
        {
            Globals.CurrentUser.SavedSources[dataRepeater1.CurrentItemIndex] = Sources[dataRepeater1.CurrentItemIndex].Source;

            DBAction.UpdateSavedSource(Globals.CurrentUser.userid, Sources[dataRepeater1.CurrentItemIndex].Source, dataRepeater1.CurrentItemIndex + 1);
        }
    }
}
