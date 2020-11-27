using System;
using System.Threading;

namespace sem_7
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            Thread t = new Thread(Mew);
            t.Start();
            t.Join(); // сначала выполнится поток t , потом главный

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Woof { i + 1}");
                Thread.Sleep(0);
            }

            Console.WriteLine("Нажми любую клавишу");

        }

        static void Mew()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Mew { i + 1}");
            }
        }
    }
}
