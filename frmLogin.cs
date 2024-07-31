using System;
using System.Windows.Forms;

namespace Queue_System 
{
    public partial class frmLogin : Form 
    {
        private frmLandingPage myLandingPage;
        private frmWindow myWindow;

        public frmLogin(frmLandingPage landingPage) 
        {
            /* sinasave natin yung landingPage na pinagmulan para pwede tayong bumalik doon pag ng back tayo */
            this.myLandingPage = landingPage; 
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) 
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (username.Equals("user") && password.Equals("pass"))
            {
                myWindow = new frmWindow(this);

                // Subscribe frmMonitor to frmWindow's event
                myWindow.LabelUpdated += frmMonitor.OnLabelUpdated;

                myWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password. Please try again.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information
                );
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) 
        {
            backToLandingPage();
        }

        private void backToLandingPage() 
        {
            this.myLandingPage.Show();
            this.Dispose();
            this.Close();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e) 
        {
            backToLandingPage();
        }
    }
}
