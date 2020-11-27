using System;
using Libra;

namespace BankSimulator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("\nВведите номер счёта:");
                string name = Console.ReadLine();

                Account acc = new Account(100, name);
                acc.Notify += DisplayMessage;

                Actions(acc);

                Console.WriteLine($"\nНажмите любую клавишу, чтобы продолжить, " +
                    $"нажмите Escape, чтобы завершить работу");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        public static void Actions(Account account)
        {
            int sum;
            do
            {
                Console.WriteLine($"\nВыберите действие со счетом {account.Name}:" +
                $"\n1. Снять наличные." +
                $"\n2. Внести наличные." +
                $"\n3. Перевод." +
                $"\n4. Узнать баланс.");

                switch (Console.ReadLine())
                {
                    case "1":
                        sum = Input();
                        account.Take(sum);
                        break;
                    case "2":
                        sum = Input();
                        account.Put(sum);
                        break;
                    case "3":
                        Send(account);
                        break;
                    case "4":
                        account.Info();
                        break;
                    default:
                        Console.WriteLine("\nВведено неверное действие!");
                        break;
                }

                Console.WriteLine($"\nПродолжить действия со счётом: {account.Name}?\n" +
                    $"Нажмите Y или N");
            } while (Console.ReadKey().Key != ConsoleKey.N);
        }

        private static void Send(Account sender)
        {
            Console.WriteLine("\nВведите номер счёта");

            string name = Console.ReadLine();
            Account acc2 = new Account(0, name);

            try
            {
                int sum = Input();
                sender.Take(sum);
                acc2.Put(sum);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Неверный формат ввода!" + ex.Message);
            }
        }

        /// <summary>
        /// Обработчик события: событие происходит и вызывается этот метод
        /// </summary>
        /// <param name="message">Сообщение</param>
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static int Input()
        {
            int n;

            Console.WriteLine("Введите сумму");
            while (!int.TryParse(Console.ReadLine(), out n) || n > 10000)
            {
                Console.WriteLine("Неверное значение");
            }

            return n;
        }
    }

}
