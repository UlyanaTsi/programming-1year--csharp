using System;
using System.Collections.Generic;
using System.IO;

/* Делегаты
 *
 *
 *
 */

namespace Module_3
{
    class MainClass
    {
        static readonly string path_1 = @"expressions.txt";
        static readonly string path_2 = "answers.txt";
        
        delegate double MathOperation(double a, double b);

        static Dictionary<string, MathOperation> operations;

        static MainClass()
        {
            operations = new Dictionary<string, MathOperation>();

            operations.Add("+", (x, y) => x + y);
            operations.Add("*", (x, y) => x * y);
            operations.Add("-", (x, y) => x - y);
            operations.Add("/", (x, y) => x / y);
            operations.Add("^", (x, y) => Math.Pow(x, y));

        }

        public static double Calculate(string expr)
        {
            try
            {
                string[] inp = expr.Split(' ');

                double a = double.Parse(inp[0]);
                double b = double.Parse(inp[2]);
                string op = inp[1];

                return operations[op](a, b);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неверный формат примера: {ex.Message}");
                return 0;
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                File.WriteAllText(path_2, "");

                string[] expressions = File.ReadAllLines(path_1);

                foreach (string s in expressions)
                {
                    File.AppendAllText(path_2, Calculate(s).ToString("F" + 3) + "\n");
                }

                Console.WriteLine("Запись в файл завершена");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка при работе с файлом: {ex.Message}");
            }
        }
    }
}