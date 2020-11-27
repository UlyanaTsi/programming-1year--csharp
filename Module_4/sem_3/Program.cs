using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace sem_3
{
    interface IValuable
    {
        decimal Value { get; }
    }

    abstract class Valuable : IValuable, IComparable<Valuable>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }

        public Valuable(string name, decimal value)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Value = value;
        }

        public int CompareTo(Valuable other)
        {
            return Value.CompareTo(other.Value);
        }
    }

    class RichGuy : Valuable
    {
        public RichGuy(string name, decimal value) : base(name, value) { }

        public static Company operator +(RichGuy richGuy, Company company)
        {
            if (richGuy.Value < company.Value)
            {
                return company;
            }

            richGuy.Value -= company.Value;
            company.Name = $"{richGuy.Name}'s {company.Name}";

            return company;
        }

        public static Company operator +(Company company, RichGuy richGuy)
        {
            return richGuy + company;
        }
    }

    class Company : Valuable
    {
        public Company(string name, decimal value) : base(name, value) { }

        public static Company operator +(Company a, Company b)
        {
            string name;
            decimal value;
            if (a > b)
            {
                name = $"{b.Name} of {a.Name}"; // Sberbank of Russia
                value = a.Value - b.Value;
            }
            else if (a < b)
            {
                name = $"{a.Name} of {b.Name}"; // Sberbank of Russia
                value = b.Value - a.Value;
            }
            else
            {
                name = $"{a.Name} & {b.Name}";
                value = a.Value + b.Value;
            }

            return new Company(name, value);
        }

        public static bool operator >(Company a, Company b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator <(Company a, Company b)
        {
            return b > a; // a > b -> a < b == b > a
        }

        public static bool operator ==(Company a, Company b)
        {
            return a.CompareTo(b) == 0; // !(a > b || a < b)
        }

        public static bool operator !=(Company a, Company b)
        {
            return a.CompareTo(b) != 0;
        }

        public override string ToString()
        {
            return $"Company \"{Name}\" with balance {Value}";
        }
    }
    class Exchange : IEnumerable<Company>
    {
        public string Name { get; }
        public List<Company> Companies { get; }

        public Exchange(string name, params Company[] companies) : this(name, new List<Company>(companies)) { }

        public Exchange(string name, List<Company> companies)
        {
            Name = name;
            Companies = companies;
        }

        IEnumerator<Company> IEnumerable<Company>.GetEnumerator()
        {
            yield return IEnumerable.GetEnumerator();
        }

        // Если IEnumerable

        /*public IEnumerator<Company> GetEnumerator()
        {
            foreach (var company in Companies)
            {
                yield return company;
            }

            // yield break; опционально 
        }*/

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var company in Companies)
            {
                yield return company;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Company sbrf = new Company("Sberbank", 2.14m * 1e12m);
            Company mcd = new Company("Mcdonalds", 13606020);
            Company tesla = new Company("Tesla", 13606020);

            Exchange mosExchange = new Exchange("Московская биржа",sbrf);
            IEnumerable<Company> otherExchange = new Exchange("Другая биржа", tesla, mcd);

            var sortedCompanies = from company in otherExchange
                                  where company.Value >= 100
                                  orderby company.Name ascending 
                                  select company;

            foreach (var company in sortedCompanies) { Console.WriteLine(company); }

            var allCompanies = mosExchange.Concat(mosExchange);
            foreach (var company in allCompanies) { Console.WriteLine(company); }

            var avgValue = allCompanies.Average(company => company.Value);
            Console.WriteLine(avgValue);

            var hugeCompany = allCompanies.Aggregate((a, b) => { return a + b; });
            var hugeCompanySum = allCompanies.Sum(company => company.Value);
            Console.WriteLine(hugeCompany);

            Console.WriteLine(
                (from company in otherExchange
                 where company.Value >= 100
                 orderby company.Name ascending
                 select company)
                                .Distinct()
                                .Count());
        }
    }
}
