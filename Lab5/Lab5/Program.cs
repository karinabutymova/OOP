using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    abstract class Info
    {
        public string Language { get; set; }
        public int YearOfIssue { get; set; }
        public int NumberOfPages { get; set; }
    }
    interface IShow1
    {
        void Show();
    }
    abstract class Show2
    {
        public abstract void Show();
    }
    class PrintEdition
    {
        public string NameOfEdition { get; set; }
        public int HashCode { get; set; }
        public PrintEdition (string name)
        {
            NameOfEdition = name;
            HashCode = GetHashCode();
        }
        public override string ToString()
        {
            return NameOfEdition + "(хэш-код:" + HashCode + ")";
        }
        public override bool Equals(object obj)
        {
            
            obj = obj as Book;
            if (obj != null)
            {
                obj.ToString();
                return true;
            }

            Console.WriteLine("Невозможно преобразовать к Book");
            return false;
        }
        public override int GetHashCode()
        {
            Random random = new Random();
            int hash = random.Next(1, 100);
            hash = (hash * (hash + 23456));
            return hash;
        }
    }
    class Book : Info
    {
        public string NameOfBook { get; set; }
        public Book(string name, string language, int year, int pages)
        {
            NameOfBook = name;
            Language = language;
            YearOfIssue = year;
            NumberOfPages = pages;
        }
        public override string ToString()
        {
            return "Информация об издании: \nНазвание - " + NameOfBook + "\nГод выпуска -" + YearOfIssue + "\nКол-во страниц - " + NumberOfPages + "\nЯзык - "+ Language;
        }

    }
    class Magazin : Info
    {
        public string NameOfMagazin { get; set; }
        public Magazin(string name, string language, int year, int pages)
        {
            NameOfMagazin = name;
            Language = language;
            YearOfIssue = year;
            NumberOfPages = pages;
        }
        public override string ToString()
        {
            return "Информация об издании: \nНазвание - " + NameOfMagazin + "\nГод выпуска -" + YearOfIssue + "\nКол-во страниц - " + NumberOfPages + "\nЯзык - " + Language;

        }
    }
    class Textbook : Info
    {
        public string NameOfTextbook { get; set; }
        public Textbook(string name, string language, int year, int pages)
        {
            NameOfTextbook = name;
            Language = language;
            YearOfIssue = year;
            NumberOfPages = pages;
        }
        public override string ToString()
        {
            return "Информация об издании: \nНазвание - " + NameOfTextbook + "\nГод выпуска -" + YearOfIssue + "\nКол-во страниц - " + NumberOfPages + "\nЯзык - " + Language;

        }
    }
    sealed class Author: Show2, IShow1
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Author(string name, string surname)
        {
            Name = name;
            Surname = surname;
            
        }
        public override string ToString()
        {
            return "Имя автора: " + Surname + ' ' + Name;
        }
        public override void Show()
        {
            Console.WriteLine("Только отличные авторы!");
        }
    }
    class Publishing : Show2, IShow1
    {
        public string NamePrint { get; set; }
        public Publishing(string name)
        {
            NamePrint = name;
        }
        public override string ToString()
        {
            return "Название издательства: " + NamePrint;
        }
        public override void Show()
        {
            Console.WriteLine("Только надежные издательства!" );
        }
    }
    public class Printer
    {
        public string IAmPrinting(Object obj)
        {
            return obj.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PrintEdition PrintEdition1 = new PrintEdition("Книга");
            Book Book = new Book("Немного ненависти","русский", 2019, 702);
            Author AuthorOfBook = new Author("Джо", "Аберкромби");
            Publishing PublishingOfBook = new Publishing("FanZone");

            PrintEdition PrintEdition2 = new PrintEdition("Журнал");
            Magazin Magazin = new Magazin("Мурзилка", "русский", 2019, 193);
            Author AuthorOfMagazin = new Author("Виктория", "Абрамова");
            Publishing PublishingOfMagazin = new Publishing("Детский мир");

            PrintEdition PrintEdition3 = new PrintEdition("Учебник");
            Textbook Textbook = new Textbook("EnglishInfo", "английский", 2020, 408);
            Author AuthorOfTextbook = new Author("Ellen", "Page");
            Publishing PublishingOаTextbook = new Publishing("Express Publishin");

            Printer Printer = new Printer();
            Object[] mas = new Object[] { PrintEdition1, Book, AuthorOfBook, PublishingOfBook, PrintEdition2, Magazin, AuthorOfMagazin, PublishingOfMagazin, PrintEdition3, Textbook, AuthorOfTextbook, PublishingOаTextbook };

            for (int i = 0; i < mas.Length; i++)
            {
                Console.WriteLine(Printer.IAmPrinting(mas[i]));
                Console.WriteLine();
            }
            AuthorOfTextbook.Show();
            PublishingOаTextbook.Show();

            Console.WriteLine();
            Console.Write(AuthorOfBook.Name + " " + AuthorOfBook.Surname);
            if (AuthorOfBook is IShow1)
                Console.WriteLine("-- очень известный автор");
            else
                Console.WriteLine("-- начинающий автор");

            Console.WriteLine();
            PrintEdition1.Equals(Magazin);
            Console.ReadKey();
        }
    }
}
