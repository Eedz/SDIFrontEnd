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
    public partial class WaveDetails : Form
    {
        public MainMenu frmParent;
        public string key;

        private List<StudyWave> Waves;
        private BindingSource bs;

        public WaveDetails()
        {
            InitializeComponent();

            Waves = DBAction.GetWaveInfo();

            bs = new BindingSource()
            {
                DataSource = Waves
            };
            navWaves.BindingSource = bs;

            BindProperties();
        }

        private void BindProperties()
        {
            txtID.DataBindings.Add("Text", bs, "WaveID");
            txtISOCode.DataBindings.Add("Text", bs, "ISO_Code");
            txtWave.DataBindings.Add("Text", bs, "Wave");
        }



        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WaveDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmParent.CloseTab(key);
        }
    
    }
}
