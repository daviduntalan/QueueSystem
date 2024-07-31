using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Queue_System {
    public partial class frmRegistration : Form
    {        
        private frmLandingPage myLandingPage;
        private int currentSelectedIndex;        

        public frmRegistration(frmLandingPage landingPage)
        {                    
            /* keeps a reference of landingPage */
            this.myLandingPage = landingPage;

            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e) {

            if (dataGridView1.Rows.Count < 1)
            {
                if (MyQueue.myQueue.Count == 0)
                {
                    DialogResult result = MessageBox.Show("Queue is empty, would you like to load sample data?",
                        "Empty Queue", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string[] sampleData1 = { (++MyQueue.STARTING_NUMBER).ToString(), "David, Jr.", "Caabay", "Untalan" };
                        string[] sampleData2 = { (++MyQueue.STARTING_NUMBER).ToString(), "Salamona", "Timan", "Utara" };
                        string[] sampleData3 = { (++MyQueue.STARTING_NUMBER).ToString(), "John David", "Caleb", "Pangan" };
                        dataGridView1.Rows.Add(sampleData1);
                        dataGridView1.Rows.Add(sampleData2);
                        dataGridView1.Rows.Add(sampleData3);
                    }
                }
                else
                {
                    dataGridView1.Rows.Clear();
                    foreach (var item in MyQueue.myQueue)
                    {
                        string[] sampleData = { item.QueueNumber, item.FirstName, item.MiddleName, item.LastName };
                        dataGridView1.Rows.Add(sampleData);
                    }
                }
                dataGridView1.Sort(colQueueNumber, ListSortDirection.Ascending);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            /* get entries from from text boxes */
            string fName = txtFirstName.Text;
            string mName = txtMiddleName.Text;
            string lName = txtLastName.Text;

            if (fName.Length == 0) {
                MessageBox.Show("Have you forgotten your first name?", "Empty Firstname", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtFirstName.Focus();
                return;
            }

            if (mName.Length == 0) {
                MessageBox.Show("Have you forgotten your middle name?", "Empty Middlename", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtMiddleName.Focus();
                return;
            }

            if (lName.Length == 0) {
                MessageBox.Show("Have you forgotten your last name?", "Empty Lastname", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtLastName.Focus();
                return;
            }

            string qNumber = (++MyQueue.STARTING_NUMBER).ToString();
            string[] newEntry = { qNumber, fName, mName, lName };
            dataGridView1.Rows.Add(newEntry);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {            
            txtLastName.Clear();
            txtMiddleName.Clear();
            txtFirstName.Clear();
            txtFirstName.Focus(); // set focus para pumunta doon automatic yung cursor
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            currentSelectedIndex = e.RowIndex;
            if (currentSelectedIndex < 0) return; // don't proceed if index is less than zero

            DataGridViewRow currentSelectedRow = dataGridView1.Rows[currentSelectedIndex];
            if (currentSelectedRow.Cells[0].Value != null)
            {
                txtFirstName.Text = currentSelectedRow.Cells[1].Value.ToString();
                txtMiddleName.Text = currentSelectedRow.Cells[2].Value.ToString();
                txtLastName.Text = currentSelectedRow.Cells[3].Value.ToString();
                lblStatusQueueIndex.Text = "index: " + currentSelectedIndex.ToString() +
                    " queue: " + currentSelectedRow.Cells[0].Value.ToString();
            }
            else
            {
                lblStatusQueueIndex.Text = "";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            if (currentSelectedIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow updatedData = dataGridView1.Rows[currentSelectedIndex];
                updatedData.Cells[1].Value = txtFirstName.Text;
                updatedData.Cells[2].Value = txtMiddleName.Text;
                updatedData.Cells[3].Value = txtLastName.Text;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0) 
            {                
                this.dataGridView1.Rows.RemoveAt( this.dataGridView1.SelectedRows[0].Index );                
            }
        }                

        private void saveRegisteredToQueue() {

            MyQueue.myQueue.Clear();

            /* ensure that we serve our customer on a 'first come per serve basis' */
            dataGridView1.Sort(colQueueNumber, ListSortDirection.Ascending);
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {                
                if (row.Cells["colQueueNumber"].Value != null) 
                {
                    Person person = new Person(
                        row.Cells["colQueueNumber"].Value.ToString(),
                        row.Cells["colFirstName"].Value.ToString(),
                        row.Cells["colMiddleName"].Value.ToString(),
                        row.Cells["colLastName"].Value.ToString()                     
                    );
                    
                    MyQueue.myQueue.Enqueue(person);
                }
            }
        }

        private void backToLandingPage() {
            
            saveRegisteredToQueue();

            this.myLandingPage.Show();
            this.Dispose();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e) 
        {
            backToLandingPage();
        }

        private void frmRegistration_FormClosing(object sender, FormClosingEventArgs e) 
        {
            backToLandingPage();
        }        
    }
}
