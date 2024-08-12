using System.Collections.Generic;

namespace Queue_System {
    internal class MyQueue
    {        
        public static int STARTING_NUMBER = 0;
        public const int INITIAL_CAPACITY = 10;

        /* creates queue collection */
        public static Queue<Person> myQueue = new Queue<Person>(INITIAL_CAPACITY);        
    }
}
