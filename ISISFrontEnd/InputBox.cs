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
    public partial class InputBox : Form
    {
        public string userInput;
        public InputBox(string prompt, string title = "Enter text", string defaultText = "")
        {
            InitializeComponent();

            lblPrompt.Text = prompt;
            this.Text = title;
            txtInput.Text = defaultText;

            userInput = "";
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            userInput = txtInput.Text;
            Close();
        }

        private void cmCancel_Click(object sender, EventArgs e)
        {
            userInput = "";
            Close();
        }
    }
}
