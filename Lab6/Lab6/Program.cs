using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    struct Visitor
    {
        public string Name;
        public string TypeOfPrinting;
        public Visitor(string name, string printing)
        {
            Name = name;
            TypeOfPrinting = printing;
        }
        public void Info()
        {
            Console.WriteLine($"Имя посетителя: {Name}  Что хочет взять: {TypeOfPrinting}");
            Console.WriteLine();
        }
    }
    enum Type
    {
        Книга,
        Журнал,
        Учебник
    }

    public static class Library
    {
        public static List<Info> list = new List<Info>();
        public static void Add(Info obj)
        {
            list.Add(obj);

        }
        public static void Delete(Info obj)
        {
            list.Remove(obj);
        }
        public static void Print()
        {
            foreach (Info i in list)
            {
                Console.WriteLine(i);
                Console.WriteLine();
            }

        }
    }
    public static partial class Controller
    {
        public static void YearOfPrinting()
        {
            Console.Write("Введите год: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Информация о всех изданиях, вышедших не ранее указанного года: ");
            foreach (Info i in Library.list)
            {
                if (i.YearOfIssue > year || i.YearOfIssue == year)
                    Console.WriteLine(i);
                    Console.WriteLine();
            }
        }
        

    }
     
    public class Info
    {
        public string Language { get; set; }
        public int YearOfIssue { get; set; }
        public int NumberOfPages { get; set; }
        public double Price { get; set; }

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
        public PrintEdition(string name)
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
        public Book(string name, string language, int year, int pages, double price)
        {
            NameOfBook = name;
            Language = language;
            YearOfIssue = year;
            NumberOfPages = pages;
            Price = price;
        }
        public override string ToString()
        {
            return "Информация об издании: \nНазвание - " + NameOfBook + "\nГод выпуска -" + YearOfIssue + "\nКол-во страниц - " + NumberOfPages + "\nЯзык - " + Language + "\nСтоимость - " + Price;
        }

    }
    class Magazin : Info
    {
        public string NameOfMagazin { get; set; }
        public Magazin(string name, string language, int year, int pages, double price)
        {
            NameOfMagazin = name;
            Language = language;
            YearOfIssue = year;
            NumberOfPages = pages;
            Price = price;
        }
        public override string ToString()
        {
            return "Информация об издании: \nНазвание - " + NameOfMagazin + "\nГод выпуска -" + YearOfIssue + "\nКол-во страниц - " + NumberOfPages + "\nЯзык - " + Language + "\nСтоимость - " + Price;

        }
    }
    class Textbook : Info
    {
        public string NameOfTextbook { get; set; }
        public Textbook(string name, string language, int year, int pages, double price)
        {
            NameOfTextbook = name;
            Language = language;
            YearOfIssue = year;
            NumberOfPages = pages;
            Price = price;
        }
        public override string ToString()
        {
            return "Информация об издании: \nНазвание - " + NameOfTextbook + "\nГод выпуска -" + YearOfIssue + "\nКол-во страниц - " + NumberOfPages + "\nЯзык - " + Language + "\nСтоимость - " + Price;

        }
    }
    sealed class Author : Show2, IShow1
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
        void IShow1.Show()
        {
            Console.WriteLine("--------------------------------");
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
            Console.WriteLine("Только надежные издательства!");
        }
        void IShow1.Show()
        {
            Console.WriteLine("--------------------------------");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Типы изданий, присутствующие в библиотеке: ");
            foreach (var t in Type.GetNames(typeof(Type)))
            {
                Console.Write(t + ' ');
            }
            Console.WriteLine('\n');
            Console.WriteLine("_____________________________________________");

            Visitor visitor1 = new Visitor("Бутымова Карина","учебник");
            visitor1.Info();
            Console.WriteLine("_____________________________________________");

            PrintEdition PrintEdition1 = new PrintEdition("Книга");
            Book Book = new Book("Немного ненависти", "русский", 2018, 702, 15.79);
            Author AuthorOfBook = new Author("Джо", "Аберкромби");
            Publishing PublishingOfBook = new Publishing("FanZone");

            PrintEdition PrintEdition2 = new PrintEdition("Журнал");
            Magazin Magazin = new Magazin("Мурзилка", "русский", 2019, 193, 3.60);
            Author AuthorOfMagazin = new Author("Виктория", "Абрамова");
            Publishing PublishingOfMagazin = new Publishing("Детский мир");

            PrintEdition PrintEdition3 = new PrintEdition("Учебник");
            Textbook Textbook1 = new Textbook("EnglishInfo", "английский", 2020, 408, 25.87);
            Textbook Textbook2 = new Textbook("Русский язык", "русский", 2010, 329, 5.60);
            Author AuthorOfTextbook = new Author("Ellen", "Page");
            Publishing PublishingOаTextbook = new Publishing("Express Publishin");

            Library.Add(Book); Library.Add(Magazin); Library.Add(Textbook1);Library.Add(Textbook2);
            Library.Print();

            Console.WriteLine("_____________________________________________");
            Controller.YearOfPrinting();
            Console.WriteLine("_____________________________________________");
            Controller.CountOfTextbook();
            Console.WriteLine("_____________________________________________");
            Controller.PriceAll();
            Console.ReadKey();
        }
    }
}