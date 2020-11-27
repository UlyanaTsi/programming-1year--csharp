using System;
using System.Collections;

// перечисления

namespace sem_4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Library library = new Library();

            foreach (Book b in library)
            {
                Console.WriteLine(b.Name);
            }
        }
    }

    class Book
    {
        public Book(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }

    class Library
    {
        Book[] books;

        public Library()
        {
            books = new Book[] { new Book("Отцы и дети"), new Book("Война и мир"),
                new Book("Евгений Онегин") };
        }

        public int Length
        {
            get { return books.Length; }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < books.Length; i++)
            {
                yield return books[i];
            }
        }
    }
}
