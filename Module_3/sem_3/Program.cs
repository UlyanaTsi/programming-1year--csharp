using System;

/* События
 * 
 *
 */

namespace sem_3
{
    // событийный делегат
    public delegate void EventHappend();

    public class Publisher
    {
        // событие
        public event EventHappend smthHappend;

        public void fireEvent()
        {
            Console.WriteLine("Fire snthHappend");
            smthHappend(); // запуск события
        }
    }

    public class SmthHappendSubscriber
    {
        public void SmthHappenedHandler()
        {
            Console.WriteLine("Subscriber has handled an event");
        }
    }
    class MainClass
    {
        static void Main()
        {
            Publisher publ = new Publisher();

            SmthHappendSubscriber shs = new SmthHappendSubscriber();

            publ.smthHappend += shs.SmthHappenedHandler;

            publ.fireEvent(); 

            
        }

        
    }
}
 