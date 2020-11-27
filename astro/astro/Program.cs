using System;

namespace astro
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int day1;
            int month1;
            Console.WriteLine("Введите свою дату рождения в формвте дд.мм:");
          //  do
          //  {
           //    int a = 123123123;
          //  } while ( ;

            string datee = Console.ReadLine();

            string[] words = datee.Split('.');
            string day = words[0];
            string month = words[1];

            int.TryParse(day, out day1);
            int.TryParse(month, out month1);
           

            if ((month1 > 12) || (day1 > 31) || (day1 < 01)  || (month1 < 00))
                Console.WriteLine("Тебе так сложно ввести правильную дату?");

            if (month1 == 01)
            {
                if (day1 >= 21)
                    Console.WriteLine("Водолей");

                else
                    Console.WriteLine("Козерог");
            }
            if (month1 == 02)
            {
                if (day1 >= 20)
                    Console.WriteLine("Рыбы");
                else
                    Console.WriteLine("Водолей");
            }
            if (month1 == 03)
            {
                if (day1 >= 21)
                    Console.WriteLine("Овен");
                else
                    Console.WriteLine("Рыбы");
            }
            if (month1 == 04)
            {
                if (day1 >= 21)
                    Console.WriteLine("Телец");
                else
                    Console.WriteLine("Овен");
            }
            if (month1 == 05)
            {
                if (day1 >= 22)
                    Console.WriteLine("Близнецы");
                else
                    Console.WriteLine("Tелец");
            }
            if (month1 == 06)
            {
                if (day1 >= 22)
                    Console.WriteLine("Рак");
                else
                    Console.WriteLine("Близнецы");
            }
            if (month1 == 07)
            {
                if (day1 >= 22)
                    Console.WriteLine("Лев");
                else
                    Console.WriteLine("Рак");
            }
            if (month1 == 08)
            {
                if (day1 >= 23)
                    Console.WriteLine("Дева");
                else
                    Console.WriteLine("Лев");
            }
            if (month1 == 09)
            {
                if (day1 >= 24)
                    Console.WriteLine("Весы");
                else
                    Console.WriteLine("Дева");
            }
            if (month1 == 10)
            {
                if (day1 >= 24)
                    Console.WriteLine("Скропион");
                else
                    Console.WriteLine("Весы");
            }
            if (month1 == 11)
            {
                if (day1 >= 23)
                    Console.WriteLine("Стрелец");
                else
                    Console.WriteLine("Скропион");
            }
            if (month1 == 12)
            {
                if (day1 >= 22)
                    Console.WriteLine("Козерог");
                else
                    Console.WriteLine("Стрелец");
            }


            string[] prediction = new string[12] { "Сегодня будет хороший день", "Сегодня лучше решать старые проблемы, а не создавать новые", "Не бойся, что не получится, бойся не попробовать", "Хочешь найти новый путь - прямо сейчас сойди со старой дороги", "Не доверяй Стрельцам, даже если сама стрелец", " Подними свою задницу и сделай это", "После этого дня ваша самооценка резко возрастет", "Сегодня у вас получится покорить новые вершины", "Этот день будет переполнен любовью и заботой", "Хватит провоцировать людей на конфликты", "Cегодня некотрые ваши проблемы решаются сами собой", "Сегодня играем в ролевые игры. Вы омеба" };
            Console.WriteLine(prediction[new Random().Next(0, prediction.Length)]);
        }
    }
}