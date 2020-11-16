using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab10
{
    class Student
    {
        public string Name { get; set; }
        public int Course { get; set; }
        public string Spec { get; set; }
        public Student(string name, int course, string spec)
        {
            Name = name;
            Course = course;
            Spec = spec;
        }
        public override string ToString()
        {
            return "Имя студента: " + Name + "\tКурс: " + Course + "\tСпециальность: " + Spec;
        } 
    }
    abstract class Info
    {
        public int YearOfIssue { get; set; }
        public int NumberOfPages { get; set; }
    }
    class Book : Info
    {
        public string NameOfBook { get; set; }
        public Book(string name,  int year, int pages)
        {
            NameOfBook = name;
            YearOfIssue = year;
            NumberOfPages = pages;
        }
        public override string ToString()
        {
            return "Название - " + NameOfBook + "\nГод выпуска -" + YearOfIssue + "\nКол-во страниц - " + NumberOfPages;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("________________________________Задание 1________________________________");
            ArrayList list = new ArrayList();
            Random random = new Random();
            for(int i = 0; i < 4; i++)
            {
                list.Add(random.Next(1, 50));
            }
            list.Add("Строка в коллекции");
            Student student = new Student("Карина Бутымова", 2, "ДЭиВИ");
            list.Add(student);

            Console.WriteLine("---Коллекция ArrayList---");
            Console.WriteLine($"Количество элементов в коллекции ArrayList: {list.Count}");
            foreach (object obj in list)
            {
                if(obj is Student)
                {
                    Console.WriteLine(obj.ToString());
                }
                else
                    Console.WriteLine(obj);
            }

            list.RemoveAt(3);

            Console.WriteLine("---Коллекции ArrayList после удаления элемента---");
            Console.WriteLine($"\nКоличество элементов в коллекции ArrayList: {list.Count}");
            foreach (object obj in list)
            {
                if (obj is Student)
                {
                    Console.WriteLine(obj.ToString());
                } 
                else
                    Console.WriteLine(obj);
            }
            Console.WriteLine($"\nСодержится ли в коллекции объект типа Student: {list.Contains(student)}");
            Console.WriteLine($"Содержится ли в коллекции число 26: {list.Contains(26)}");

            Console.WriteLine("________________________________Задание 2________________________________");

            LinkedList<char> linked_list = new LinkedList<char>();
            linked_list.AddLast('a');
            linked_list.AddLast('g');
            linked_list.AddLast('e');
            linked_list.AddFirst('b');
            linked_list.AddFirst('f');
            linked_list.AddAfter(linked_list.Last,'c');
            linked_list.AddBefore(linked_list.First,'d');

            Console.WriteLine("---Коллекции LinkedList ---");
            foreach(char i in linked_list)
            {
                Console.Write(i + " ");
            }

            linked_list.RemoveFirst();
            linked_list.RemoveLast();

            Console.WriteLine("\n---Коллекции LinkedList после удаления ---");
            foreach (char i in linked_list)
            {
                Console.Write(i + " ");
            }
            HashSet<char> hashset = new HashSet<char>();
            foreach(char i in linked_list)
            {
                hashset.Add(i);
            }
            Console.WriteLine("\n\n---Коллекции HashSet ---");
            foreach (char i in hashset)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine($"\nСодержится ли в коллекции HashSet 'c': {hashset.Contains('c')}");
            Console.WriteLine($"Содержится ли в коллекции HashSet 'a': {hashset.Contains('a')}");

            Console.WriteLine("________________________________Задание 3________________________________");

            Book Book1 = new Book("Немного ненависти", 2019, 702);
            Book Book2 = new Book("EnglishInfo",  2020, 408);
            Book Book3 = new Book("Маленькие женщины", 2020, 384);

            LinkedList<Book> list_Book = new LinkedList<Book>();
            list_Book.AddLast(Book1);
            list_Book.AddFirst(Book2);
            list_Book.AddBefore(list_Book.First, Book3);

            Console.WriteLine("\n\n---Коллекции LinkedList с типом Book---\n");
            foreach (Book i in list_Book)
            {
                Console.WriteLine(i.ToString() + "\n");
            }

            list_Book.RemoveFirst();
            list_Book.RemoveLast();

            Console.WriteLine("\n\n---Коллекции LinkedList после удаления ---\n");
            foreach (Book i in list_Book)
            {
                Console.Write(i.ToString());
            }
            HashSet<Book> hashset_book = new HashSet<Book>();
            foreach (Book i in list_Book)
            {
                hashset_book.Add(i);
            }
            Console.WriteLine("\n\n---Коллекции HashSet с типом Book ---\n");
            foreach (Book i in hashset_book)
            {
                Console.Write(i.ToString());
            }
            Console.WriteLine($"\nСодержится ли в коллекции HashSet объект Book1: {hashset_book.Contains(Book1)}");
            Console.WriteLine($"Содержится ли в коллекции HashSet объект Book2: {hashset_book.Contains(Book2)}");

            Console.WriteLine("________________________________Задание 4________________________________");

            ObservableCollection<Book> books = new ObservableCollection<Book>();
            books.CollectionChanged += CollectionChanged;
            books.Add(Book1);
            books.Add(Book2);
            books.Add(Book3);
            books.RemoveAt(1);

            void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    Book addbook = e.NewItems[0] as Book;
                    Console.WriteLine($"Добавлен новый объект: {addbook.ToString()}\n");
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    Book rembook = e.OldItems[0] as Book;
                    Console.WriteLine($"Удален объект: {rembook.NameOfBook}");
                }
            }

            Console.ReadKey();
        }
    }
}
