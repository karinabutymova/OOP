using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lab8
{
    interface IGeneral<T>
    {
        void Add(T element);
        void Delete(T element);
        void Show();
    }
    public class CollectionType<T> : IGeneral<T>  // where T : Book
    {
        List<T> item = new List<T>();
        public void Add(T element)
        {
            item.Add(element);
        }
        public void Delete(T element)
        {
            if (item.Contains(element))
                item.Remove(element);
            else
                throw new OutOfList("Элемент, который вы хотите удалить, не содержится в списке");
        }
        public void AddPos(int pos, T elem)
        {
            item.Insert(pos, elem);
        }
        public void Show()
        {
            foreach (T i in item)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }
        public int Count()
        {
            return item.Count();
        }
        public T GetElement(int i)
        {
            return item[i];
        }
        public static bool operator !=(CollectionType<T> list1, CollectionType<T> list2)
        {
            int kol = 0;
            if (list1.Count() != list2.Count()) return false;
            else
            {
                foreach (T el in list1.item)
                {
                    if (list2.item.Contains(el))
                        kol++;
                }
               
                if (kol == list1.Count()) return true;
                else return false;
            }
        }
        public static bool operator ==(CollectionType<T> list1, CollectionType<T> list2)
        {
            int kol = 0;
            if (list1.Count() != list2.Count()) return false;
            else
            {
                foreach (T el in list1.item)
                {
                    if (list2.item.Contains(el))
                        kol++;
                }

                if (kol == list1.Count()) return true;
                else return false;
            }
        }
        public void FileWrite(StreamWriter write)
        {
            foreach (T i in item)
            {
                write.WriteLine(i);
            }
        }
    }
    class OutOfList : NullReferenceException
    {
        public string NewMess { get; set; }
        public OutOfList(string message)
        {
            NewMess = message;
        }
    }
    abstract class Info
    {
        public string Language { get; set; }
        public int YearOfIssue { get; set; }
        public int NumberOfPages { get; set; }
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
            return "\nИнформация об издании: \nНазвание - " + NameOfBook + "\nГод выпуска -" + YearOfIssue + "\nКол-во страниц - " + NumberOfPages + "\nЯзык - " + Language;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CollectionType<string> StringList = new CollectionType<string>();
            StringList.Add("Минск");
            StringList.Add("Гродно");
            StringList.Add("Витебск");
            StringList.Add("Могилев");
            Console.WriteLine("Список 1:");
            StringList.Show();

            Console.WriteLine("Удаление элемента: ");
            StringList.Delete("Минск");
            StringList.Show();

            CollectionType<int> IntList = new CollectionType<int>();
            IntList.Add(10); IntList.Add(9); IntList.Add(7); IntList.Add(8);

            Console.WriteLine("Список 2:");
            IntList.Delete(8);
            IntList.Show();

            CollectionType<int> IntList2 = new CollectionType<int>();
            Console.WriteLine("Список 3:");
            IntList2.Add(10); IntList2.Add(9); IntList2.Add(7); IntList2.Add(7);  IntList2.Show();

            try
            {
                IntList2.Delete(6);
            }
            catch (OutOfList ex)
            {
                Console.WriteLine("_______________Исключения_______________");
                Console.WriteLine("Возникло исключение: " + ex.NewMess);
            }
            finally
            {
                Console.WriteLine("_______________Завершена работа с исключениями_______________\n");
            }

            Console.WriteLine("\nСписок 4 (пользовательский класс, который используется в качестве параметра обобщения):");
            CollectionType<Book> BookList = new CollectionType<Book>();
            Book Book = new Book("Немного ненависти", "русский", 2019, 702);
            BookList.Add(Book);
            Book = new Book("Мурзилка", "русский", 2019, 193);
            BookList.Add(Book);
            BookList.Show();

            Console.WriteLine("Проверка на равенство множеств (список 2 и список 3): ");
            bool eq = IntList != IntList2;
            if (eq)
                Console.WriteLine("Списки равны");
            else
                Console.WriteLine("Списки не равны");
           
            try
            {
                Console.WriteLine("\n__________________________Запись в файл__________________________");
                StreamWriter write = new StreamWriter(@"C:\OOP\Lab8\Для записи и чтения.txt");
                write.WriteLine("Список 1:");
                StringList.FileWrite(write);
                write.WriteLine("\nСписок 2:");
                IntList.FileWrite(write);
                write.WriteLine("\nСписок 3:");
                IntList2.FileWrite(write);
                write.WriteLine("\nСписок 4:");
                BookList.FileWrite(write);
                write.Close();
                Console.WriteLine("Запись в файл выполнена");

                Console.WriteLine("\n__________________________Чтение из файла__________________________");
                StreamReader read = new StreamReader(@"C:\OOP\Lab8\Для записи и чтения.txt");
                Console.WriteLine(read.ReadToEnd());
                read.Close();
                Console.WriteLine("Чтение из файла выполнено");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
