namespace Queue_System {
    internal class Person
    {
        private string qNumber;
        private string fName;
        private string mName;
        private string lName;

        public Person(string qNumber, string fName, string mName, string lName)
        {
            this.qNumber = qNumber;
            this.fName = fName;
            this.mName = mName;
            this.lName = lName;
        }

        public string QueueNumber { get { return qNumber; } }
        public string FirstName { get { return fName; } }
        public string MiddleName { get { return mName; } }
        public string LastName { get { return lName; } }
    }
}
