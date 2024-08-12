using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Queue_System {

    public partial class frmWindow : Form {

        private frmLandingPage myLandingPage;
        private frmLogin loginPage;
        private frmMonitor myMonitor;

        // Define a delegate for the event
        public delegate void MonitorQueueUpdateHandler(string servingQueueNumber, string waitingQueueNumber);

        // Define the event using the delegate
        public event MonitorQueueUpdateHandler NextQueueNumberUpdate;


        public frmWindow(frmLogin loginPage, frmMonitor myMonitor) 
        {
            this.myMonitor = myMonitor;
            this.loginPage = loginPage;            
            InitializeComponent();
        }

        private string getNextInLine() {
            try
            {
                var nextPerson = MyQueue.myQueue.Peek();
                StringBuilder waiting = new StringBuilder();
                /* todo: copy queue to another queue and remove them */
                int SIZE = MyQueue.myQueue.Count;
                if (SIZE > 0) {
                    Person[] persons = new Person[SIZE];
                    MyQueue.myQueue.CopyTo(persons, 0);
                    for (int i = 0; i < 3 && i < persons.Length; ++i) {
                        waiting.Append(persons[i].QueueNumber); 
                        waiting.Append((i == persons.Length - 1) ? "." : ", ");
                    }
                }
                return waiting.ToString();
            } 
            catch (InvalidOperationException ex)
            {
                lblStatus.Text = ex.Message;
                return "No More"; /* signifies no more person in queue */
            }
        }

        private void btnNextWin1_Click(object sender, EventArgs e) {
            if (MyQueue.myQueue.Count < 1) { lblStatus.Text = "Queue is empty."; return; }
            var person = MyQueue.myQueue.Dequeue();
            lblQueueNumWin1.Text = person.QueueNumber;
            w1firstName.Text = person.FirstName;
            w1middleName.Text = person.MiddleName;
            w1lastName.Text = person.LastName;                       

            // Raise the event
            NextQueueNumberUpdate?.Invoke("Win1 " + person.QueueNumber, getNextInLine());
        }

        private void btnNextWin2_Click(object sender, EventArgs e) {
            if (MyQueue.myQueue.Count < 1) { lblStatus.Text = "Queue is empty."; return; }
            var person = MyQueue.myQueue.Dequeue();
            lblQueueNumWin2.Text = person.QueueNumber;
            w2firstName.Text = person.FirstName;
            w2middleName.Text = person.MiddleName;
            w2lastName.Text = person.LastName;

            // Raise the event
            NextQueueNumberUpdate?.Invoke("Win2 " + person.QueueNumber, getNextInLine());
        }

        private void btnNextWin3_Click(object sender, EventArgs e) {
            if (MyQueue.myQueue.Count < 1) { lblStatus.Text = "Queue is empty."; return; }
            var person = MyQueue.myQueue.Dequeue();
            lblQueueNumWin3.Text = person.QueueNumber;
            w3firstName.Text = person.FirstName;
            w3middleName.Text = person.MiddleName;
            w3lastName.Text = person.LastName;

            // Raise the event
            NextQueueNumberUpdate?.Invoke("Win3 " + person.QueueNumber, getNextInLine());
        }

        private void backToLoginPage() 
        {   
            this.myMonitor.Dispose();
            this.myMonitor.Close();

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
