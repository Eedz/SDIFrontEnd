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
    public partial class Picker<T> : Form
    {
        bool Multi;
        public T Data;
        string DisplayMember;
        string ValueMember;

        public Picker(List<T> items, string DisplayMember, string ValueMember,  string title)
        {
            InitializeComponent();

            this.Text = title;

            lst.DataSource = items;
            lst.DisplayMember = DisplayMember;
            lst.ValueMember = "";
            lst.SelectedItem = null;
            lst.SelectedIndexChanged += lst_SelectedIndexChanged;
            Data = default;
        }


        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            T item = (T)lst.SelectedItem;

            Data = item;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Picker_FormClosed(object sender, FormClosedEventArgs e)
        {
            

        }
    }
}
