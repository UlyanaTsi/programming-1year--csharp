using System;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

// Асинхронность

namespace sem10
{
    class MainClass
    {
        static readonly string path = @"../../../../../hello.txt";

        static void Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Factorial {n} is {result}");
        }

        // определение асинхронного метода
        static async void FactorialAsync()
        {
            Task t1 = Task.Run(() => Factorial(4));
            Task t2 = Task.Run(() => Factorial(3));
            Task t3 = Task.Run(() => Factorial(5));
            await Task.WhenAll(new[] { t1, t2, t3 });
        }

        static void Main(string[] args)
        {
            FactorialAsync();

            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(i);
            }

            Console.Read();
        }

        /// <summary>
        /// Асинхронный метод для чтения из файла
        /// </summary>
        /// <param name="path"></param>
        static async void ReadAsync(string path)
        {
            string result;
            using (StreamReader reader = new StreamReader(path))
            {
                result = await reader.ReadLineAsync();
                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// Асинхронный метод записи в файл
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        static async void WriteAsync(string path, string text)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                await writer.WriteLineAsync(text);
            }
        }
    }
}
