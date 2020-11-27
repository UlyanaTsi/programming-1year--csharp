using System;

namespace astro
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int day1;
            int month1;
            Console.WriteLine("Введи своею дату рождения в формате дд.мм:");
            string datee = Console.ReadLine();
            string[] words = datee.Split('.');
            string day = words[0];
            string month = words[1];
            int.TryParse(day, out day1);
            int.TryParse(month, out month1); 
            if (month1 == 01)
            {
                if (day1 >= 21)
                    Console.WriteLine("Aquarius");

                else
                    Console.WriteLine("Capricorn");
            }
            if (month1 == 02)
            {
                if (day1 >= 20)
                    Console.WriteLine("Pisces");
                else
                    Console.WriteLine("Aquarius");
            }
            if (month1 == 03)
            {
                if (day1 >= 21)
                    Console.WriteLine("Aries");
                else
                    Console.WriteLine("Pisces");
            }
            if (month1 == 04)
            {
                if (day1 >= 21)
                    Console.WriteLine("Taurus");
                else
                    Console.WriteLine("Aries");
            }
            if (month1 == 05)
            {
                if (day1 >= 22)
                    Console.WriteLine("Gemini");
                else
                    Console.WriteLine("Taurus");
            }
            if (month1 == 06)
            {
                if (day1 >= 22)
                    Console.WriteLine("Cancer");
                else
                    Console.WriteLine("Gemini");
            }
            if (month1 == 07)
            {
                if (day1 >= 22)
                    Console.WriteLine("Leo");
                else
                    Console.WriteLine("Cancer");
            }
            if (month1 == 08)
            {
                if (day1 >= 23)
                    Console.WriteLine("Virgo");
                else
                    Console.WriteLine("Leo");
            }
            if (month1 == 09)
            {
                if (day1 >= 24)
                    Console.WriteLine("Libra");
                else
                    Console.WriteLine("Virgo");
            }
            if (month1 == 10)
            {
                if (day1 >= 24)
                    Console.WriteLine("Scorpio");
                else
                    Console.WriteLine("Libra");
            }
            if (month1 == 11)
            {
                if (day1 >= 23)
                    Console.WriteLine("Sagittarius");
                else
                    Console.WriteLine("Scorpio");
            }
            if (month1 == 12)
            {
                if (day1 >= 22)
                    Console.WriteLine("Capricorn");
                else
                    Console.WriteLine("Sagittarius");
            }
            string[] prediction = new string[11] { "Сегодня будет хороший день","Сегодня лучше решать старые проблемы, а не создавать новые", "Не бойся, что не получится, бойся не попробовать", "Хочешь найти новый путь - прямо сейчас сойди со старой дороги", "Не доверяй Стрельцам, даже если сама стрелец", " Подними свою задницу и сделай это", "После этого дня ваша самооценка резко возрастет", "Сегодня у вас получится покорить новые вершины", "Этот день будет переполнен любовью и заботой", "Хватит провоцировать людей на конфликты", "Cегодня некотрые ваши проблемы решаются сами собой"};
            Console.WriteLine(prediction[new Random().Next(0, prediction.Length)]);






        }
    }
}