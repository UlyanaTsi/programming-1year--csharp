using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace sem_6
{
    static class Extension
    {
        static Random rand = new Random();

        public static IEnumerable<T> HulfExchange<T>(this IEnumerable<T> firstHalf,
            IEnumerable<T> secondHalf)
        {
            var firstIterator = firstHalf.GetEnumerator();
            var secondIterator = secondHalf.GetEnumerator();

            while (firstIterator.MoveNext() && secondIterator.MoveNext())
            {
                yield return firstIterator.Current;
                yield return secondIterator.Current;
            }
        }

        public static IEnumerable<T> FaroShuffle<T>(this IEnumerable<T> deck)
        {
            var deckSize = deck.Count();
            var shuffle = deck;
            for (int i = 0; i < 7; ++i)
            {
                var deckIndex = rand.Next(0, deckSize);
                var firstHalf = shuffle.Take(deckIndex);
                var secondHalf = shuffle.Skip(deckIndex);
                shuffle = firstHalf.HulfExchange(secondHalf);


                Console.WriteLine($"Shuffle. Iter: {i + 1}");
            }

            return shuffle;
        }
    }


    class MainClass
    {
        public static void Main(string[] args)
        {
            var deck = from suit in Suits()
                       from rank in Ranks()
                       select new { Suit = suit, Rank = rank };

            Console.WriteLine("Колода распакована");

            foreach (var card in deck)
            {
                Console.WriteLine(card);
            }

            
            Console.WriteLine("Колода перемешана");
            foreach (var card in deck.FaroShuffle())
            {
                Console.WriteLine(card);
            }
        }
        static IEnumerable<String> Suits()
        {
            yield return "Бубны";
            yield return "Пики";
            yield return "Черви";
            yield return "Крести";
        }

        static IEnumerable<String> Ranks()
        {
            yield return "2";
            yield return "3";
            yield return "4";
            yield return "5";
            yield return "6";
            yield return "7";
            yield return "8";
            yield return "9";
            yield return "10";
            yield return "Валет";
            yield return "Дама";
            yield return "Король";
            yield return "Туз";
        }
    }
}
