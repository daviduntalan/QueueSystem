using System;
using System.Windows.Forms;

namespace Queue_System {
    public partial class frmMonitor : Form
    {
        private frmLandingPage landingPage;

        public frmMonitor(frmLandingPage landingPage)
        {
            this.landingPage = landingPage;
            InitializeComponent();
        }

        // Method to handle the event
        public static void OnLabelUpdated(string newText) 
        {
            try
            {
                lblCurrentlyServing.Text = newText;
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("You probably didn't open, Monitor window: " + nre.Message);
            }
        }

        private void backToLandingPage() 
        {
            this.landingPage.Show();
            this.Dispose();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e) 
        {
            backToLandingPage();
        }

        private void frmMonitor_FormClosing(object sender, FormClosingEventArgs e) 
        {
            backToLandingPage();
        }
    }
}
