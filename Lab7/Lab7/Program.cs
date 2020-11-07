using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab7
{
    class OutOfRange : NullReferenceException
    {
        public OutOfRange(string message) : base(message) { }
    }
    class EmptyName : InvalidCastException
    {
        public EmptyName(string message) : base(message) { }
    }
    class LengthExcep : Exception
    {
        public LengthExcep(string message) : base(message) { }
    }
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
            if (list.Contains(obj))
            {
                list.Remove(obj);
            }
            else
                throw new OutOfRange("Вы пытаетесь удалить объект, которого нет в списке");
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
    public static class Controller
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
        public static void CountOfTextbook()
        {
            int count = 0;
            foreach (Info i in Library.list)
            {
                if (i is Textbook)
                    count++;
            }
            Console.WriteLine($"Количество учебников в библиотеке: {count}");
        }
        public static void PriceAll()
        {
            double count = 0;
            foreach (Info i in Library.list)
            {
                count += i.Price;
            }
            Console.WriteLine($"Cтоимость изданий,находящихся в библиотеке: {count}");
        }
    }
    public class Info
    {
        public int CurrentYear = 2020;
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
            if (name.Length > 8)
                throw new LengthExcep("Превышена допустимая длина названия издания");
            else
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
            int n = -7;
            Debug.Assert(n > 0, "Значение n не может быть меньше нуля");
            Random random = new Random();
            int hash = random.Next(1, 100);
            hash = (hash * (hash + 23456)) * n;
            return hash;
        }
    }
    public class Book : Info
    {
        public string NameOfBook { get; set; }
        public Book(string name, string language, int year, int pages, double price)
        {
            if (name == "" || name == null)
            {
                throw new EmptyName("Вы не ввели название книги");
            }
            else
                NameOfBook = name;
            Language = language;
            if (year > CurrentYear)
                throw new ArgumentOutOfRangeException("YearOfIssue");
            else
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
            if (year > CurrentYear)
                throw new ArgumentOutOfRangeException("YearOfIssue");
            else
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
            if (year > CurrentYear)
                throw new ArgumentOutOfRangeException("YearOfIssue");
            else
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

            Visitor visitor1 = new Visitor("Бутымова Карина", "учебник");
            visitor1.Info();
            Console.WriteLine("_____________________________________________");

            PrintEdition PrintEdition1 = new PrintEdition("Книга");
            Book Book1 = new Book("Немного ненависти", "русский", 2018, 702, 15.79);
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
           
            Library.Add(Book1); Library.Add(Magazin); Library.Add(Textbook1); 
            Library.Print();

            //Console.WriteLine("_____________________________________________");
            //Controller.YearOfPrinting();
            Console.WriteLine("_____________________________________________");
            Controller.CountOfTextbook();
            Console.WriteLine("_____________________________________________");
            Controller.PriceAll();
            Console.WriteLine("\n-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\n------------------------------------------Исключения --------------------------------------------------");
            try
            {
                Library.Delete(Textbook2);  
            }
            catch(OutOfRange ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.TargetSite + "\n" + ex.StackTrace + "\n\n");
            }

            try
            {
                Book Book2 = new Book("", "русский", 2016, 452, 15.6);
            }
            catch (EmptyName ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.TargetSite + "\n" + ex.StackTrace + "\n\n");
            }

            try
            {
                PrintEdition PrintEdition4 = new PrintEdition("Рабочая тетрадь");
            }
            catch (LengthExcep ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.TargetSite + "\n" + ex.StackTrace + "\n\n");
            }

            try
            {
                Magazin Magazin1 = new Magazin("Мурзилка", "русский", 2021, 193, 3.60);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.TargetSite + "\n" + ex.StackTrace + "\n\n");
            }

            try
            {
                
                int n = 0;
                Random random = new Random();
                int hash = random.Next(1, 100);
                hash = (hash * (hash + 23456)) / n;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.TargetSite + "\n" + ex.StackTrace + "\n\n");
            }

            finally
            {
                Console.WriteLine("Завершена работа с исключениями");
            }

            Console.ReadKey();
        }
    }
}
