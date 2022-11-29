using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SDIFrontEnd
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();

            this.worker.DoWork += BackgroundWorker1_DoWork;
            worker.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            worker.ProgressChanged += Worker_ProgressChanged; 
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker helperBW = sender as BackgroundWorker;

            try
            {
                Globals.CreateUser();
                worker.ReportProgress(17);
                Globals.CreateSurveys();
                worker.ReportProgress(34);
                Globals.CreateVarNames();
                worker.ReportProgress(51);
                Globals.CreateWordings();
                worker.ReportProgress(68);
                Globals.CreateOtherLists();
                worker.ReportProgress(85);
                Globals.CreateComments();
                worker.ReportProgress(100);
            }
            catch
            {
                MessageBox.Show("Error reading database.");
                e.Cancel = true;
            }

        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;

            if (e.ProgressPercentage == 100)
            {
                progressBar.Value = 101;
                progressBar.Maximum = 100;
                progressBar.Value = 100;
            }
        }

        

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                //progressBar.Value = progressBar.Maximum;
                
                //Thread.Sleep(2000);
            
                MainMenu frm = new MainMenu();
                frm.Show();
                this.Visible = false;
            }
            


        }

        
    }
}
