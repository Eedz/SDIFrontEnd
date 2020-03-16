using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISISFrontEnd
{
    public partial class ITCForm : Form
    {
        public MainMenu frmParent;
        public string key;
        
        protected BindingSource bs;
        protected bool NewRecord = false;
        protected bool Dirty = false;
        protected bool Moving = false;

        public ITCForm()
        {
            InitializeComponent();
        }

        protected void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected void ITCForm_OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == -120)
                bs.MoveNext();
            else if (e.Delta == 120)
            {
                bs.MovePrevious();
            }

        }

        protected void ColorForm (int hex)
        {
            Color temp = Color.FromArgb(hex);
            Color result = Color.FromArgb(temp.R, temp.G, temp.B);
            this.BackColor = result;
        }

        protected void MoveRecord(int count)
        {
            Moving = true;
            if (count > 0)
                for (int i = 0; i < count; i++)
                {
                    bs.MoveNext();
                }
            else
                for (int i = 0; i < Math.Abs(count); i++)
                {
                    bs.MovePrevious();
                }
        }
    }
}
