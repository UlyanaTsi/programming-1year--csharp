using System;
namespace Libra
{
    public class Account
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler Notify;  //объявление события

        private int Sum { get; set; }
        public string Name { get; private set; }
        public Account(int sum, string name)
        {
            Sum = sum;
            Name = name;
        }

        public void Put(int sum)
        {
            try
            {
                Sum += sum;
                Notify?.Invoke($"\nНа счёт {Name} поступило {sum}$"); // вызов события
            }
            catch (Exception ex)
            {
                Console.WriteLine("Неверный формат ввода!" + ex.Message);
            }
        }

        public void Take(int sum)
        {
            try
            {
                if (Sum >= sum)
                {
                    Sum -= sum;
                    Notify?.Invoke($"\nСо счета {Name} снято {sum}$");
                }
                else
                    Notify?.Invoke($"\nНедостаточно средств на счёте {Name}." +
                        $"\nДоступно {Sum}$");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Неверный формат ввода!" + ex.Message);
            }
        }

        public void Info()
        {
            Notify?.Invoke($"\nСчёт: {Name}" +
                $"\nБаланс: {Sum}");
        }

    }
}
