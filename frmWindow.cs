using System;
using System.Windows.Forms;

namespace Queue_System {

    public partial class frmWindow : Form {

        private frmLandingPage myLandingPage;
        private frmLogin loginPage;

        // Define a delegate for the event
        public delegate void LabelUpdateHandler(string newText);

        // Define the event using the delegate
        public event LabelUpdateHandler LabelUpdated;


        public frmWindow(frmLogin loginPage) 
        {
            this.loginPage = loginPage;
            InitializeComponent();
        }        

        private void btnNextWin1_Click(object sender, EventArgs e) {
            if (MyQueue.myQueue.Count < 1) { lblStatus.Text = "Queue is empty."; return; }
            var person1 = MyQueue.myQueue.Dequeue();
            lblQueueNumWin1.Text = person1.QueueNumber;
            w1firstName.Text = person1.FirstName;
            w1middleName.Text = person1.MiddleName;
            w1lastName.Text = person1.LastName;

            // Raise the event
            LabelUpdated?.Invoke("Serving: " + person1.QueueNumber + " at Window 1");
        }

        private void btnNextWin2_Click(object sender, EventArgs e) {
            if (MyQueue.myQueue.Count < 1) { lblStatus.Text = "Queue is empty."; return; }
            var person2 = MyQueue.myQueue.Dequeue();
            lblQueueNumWin2.Text = person2.QueueNumber;
            w2firstName.Text = person2.FirstName;
            w2middleName.Text = person2.MiddleName;
            w2lastName.Text = person2.LastName;

            // Raise the event
            LabelUpdated?.Invoke("Serving: " + person2.QueueNumber + " at Window 2");
        }

        private void btnNextWin3_Click(object sender, EventArgs e) {
            if (MyQueue.myQueue.Count < 1) { lblStatus.Text = "Queue is empty."; return; }
            var person3 = MyQueue.myQueue.Dequeue();
            lblQueueNumWin3.Text = person3.QueueNumber;
            w3firstName.Text = person3.FirstName;
            w3middleName.Text = person3.MiddleName;
            w3lastName.Text = person3.LastName;

            // Raise the event
            LabelUpdated?.Invoke("Serving: " + person3.QueueNumber + " at Window 3");
        }

        private void backToLoginPage() 
        {
            this.loginPage.Show();
            this.Dispose();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e) 
        {
            backToLoginPage();
        }

        private void frmWindow_FormClosing(object sender, FormClosingEventArgs e) 
        {
            backToLoginPage();
        }
    }
}
