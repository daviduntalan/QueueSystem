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
        public void OnNextQueueNumberUpdated(string servingQueueNumber, string waitingQueueNumber) 
        {
            string whichWindow = servingQueueNumber.Substring(0, 4);
            string queueNumber = servingQueueNumber.Substring(5);

            switch (whichWindow)
            {
                case "Win1": lblCurrentlyServing1.Text = queueNumber; break;
                case "Win2": lblCurrentlyServing2.Text = queueNumber; break;
                case "Win3": lblCurrentlyServing3.Text = queueNumber; break;
            }

            lblWaitingInQueue.Text = waitingQueueNumber;
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
