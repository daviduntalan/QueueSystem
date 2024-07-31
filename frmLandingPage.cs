using System;
using System.Windows.Forms;

namespace Queue_System {
    public partial class frmLandingPage : Form
    {
        public frmLandingPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            myLoginForm = new frmLogin(this);
            myLoginForm.Show();
            this.Hide();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            myRegistrationForm = new frmRegistration(this);
            myRegistrationForm.Show();
            this.Hide();
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            myMonitorForm = new frmMonitor(this);
            myMonitorForm.Show();   
            // this.Hide();
        }

        private frmLogin myLoginForm;
        private frmRegistration myRegistrationForm;
        private frmMonitor myMonitorForm;
    }
}
