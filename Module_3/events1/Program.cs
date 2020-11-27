using System;
using Libra;

namespace events1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Student student = new Student();

            student.Moving += Student_Moving;
            student.d += Student_d;

            student.Move(10);
        }

        private static void Student_d(object sender, EventArgs e)
        {
            Console.WriteLine("Началась ходьба лол");
        }

        private static void Student_Moving(object sender, MovingEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
