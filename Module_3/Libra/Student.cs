using System;
using System.Threading;

namespace Libra
{
    public class Student
    {
        public event EventHandler<MovingEventArgs> Moving;

        public event EventHandler d;

        public void Move(int distance)
        {
            d?.Invoke(this, new EventArgs());

            for (int i = 0; i < distance; i++)
            {
                Thread.Sleep(1000);
                Moving?.Invoke(this,
                    new MovingEventArgs(string.Format("Пройдено: {0} км", i)));
            }
        }
    }

    public class MovingEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public MovingEventArgs(string message)
        {
            Message = message;
        }
    }
}
