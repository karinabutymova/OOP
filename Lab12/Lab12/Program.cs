using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public partial class Product
    {

        public const int NumberOfProducts = 10000;
        public string Name { get; set; }
        public readonly int UPC;
        public string Manufacturer { get; set; }
        public float Price { get; set; }
        public string ShelfLife { get; set; }
        public int Quantity { get; set; }

        public static Random random = new Random();

    }

    public partial class Product
    {
        public Product() {}
        public Product(string name, string manufacturer, float price, string shelf_life, int quantity) 
        {
            Name = name;
            UPC = GetHashCode();
            Manufacturer = manufacturer;
            Price = price;
            ShelfLife = shelf_life;
            Quantity = quantity;
        }

    }
    public partial class Product
    {

        public override int GetHashCode()
        {
            int hash = random.Next(1, 2001);
            hash = (hash * (hash + 23456));
            return hash;

        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Product prod = (Product)obj;
            return (this.Name == prod.Name && this.Price == prod.Price && this.Quantity == prod.Quantity);
        }
        public override string ToString()
        {
            Console.WriteLine("____________________________________________________");
            return "Наименование: " + Name + "\nUPC: " + UPC + "\nПроизводитель: " + Manufacturer + "\nЦена: " + Price + "\nСрок хранения: " + ShelfLife + "\nКоличество: " + Quantity;
        }

        public float SumOfProduct(int i)
        {
            return Price * Quantity * i;
        }
    }
    public abstract class Info
    {
        public string Language { get; set; }
        public int YearOfIssue { get; set; }
        public int NumberOfPages { get; set; }
    }
    interface IShow1
    {
        void Show(string str);
    }
    class Textbook : Info, IShow1
    {
        public Textbook() { }
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
        public void Show(string str)
        {
            Console.WriteLine($"Выполнена {str}");
        }
    }

    public class Reflector
    {
        public void ClassContent(Type NameOfClass, StreamWriter write) //содержимое класса
        {
            MemberInfo[] content = NameOfClass.GetMembers();
            
            write.WriteLine($"Содержимое класса {NameOfClass}:");
            foreach(var i in content)
            {
                write.WriteLine(i.MemberType + " —— " + i.Name);
            }
            write.Write("\n\n");
        }

        public void PublicMethods(Type NameOfClass, StreamWriter write) // публичные методы класса
        {
            MethodInfo[] content = NameOfClass.GetMethods();
            write.WriteLine($"Публичные методы класса {NameOfClass}:");
            foreach (var i in content)
            {
                write.WriteLine(i.Name + " —— " + i.ReturnType.Name);
            }
            write.Write("\n\n");
        }

        public void FieldsProperties(Type NameOfClass, StreamWriter write) //информация о полях и свойствах класса
        {
            FieldInfo[] fields = NameOfClass.GetFields();
            write.WriteLine($"Поля класса {NameOfClass}:");
            foreach (var i in fields)
            {
                write.WriteLine(i.Name);
            }
            write.Write("\n\n");

            write.WriteLine($"Свойства класса {NameOfClass}:");
            PropertyInfo[] properties = NameOfClass.GetProperties();
            foreach (var i in properties)
            {
                write.WriteLine(i.Name);
            }
            write.Write("\n\n");
        }
        public void Interfaces(Type NameOfClass, StreamWriter write) // реализованные классом интерфейсы
        {
            var content = NameOfClass.GetInterfaces();
            write.WriteLine($"Реализованные интерфейсы класса {NameOfClass}:");
            foreach (var i in content)
            {
                write.WriteLine(i.Name);
            }
            write.Write("\n\n");
        }

        public void TypeOfParameter(Type NameOfClass, StreamWriter write, string par) // имя метода с заданным типом параметра
        {
            MethodInfo[] content = NameOfClass.GetMethods();
            write.WriteLine($"Методы класса {NameOfClass}, которые содержат параметр типа {par}:");
            foreach (var i in content)
            {
                foreach(var j in i.GetParameters())
                {
                    if(j.ParameterType.Name == par)
                        write.WriteLine(i.Name);
                }
            }
            write.Write("\n\n");
        }

        public void FileParameter(Type NameOfClass, string met) // вызвать метод и прочитать его параметры из файла
        {
            StreamReader read = new StreamReader(@"C:\OOP\Lab12\Для чтения.txt", Encoding.GetEncoding(1251));
            string str = read.ReadLine();
            read.Close();
            MethodInfo content = NameOfClass.GetMethod(met);
            object obj = Activator.CreateInstance(NameOfClass);
            object newmathod = content.Invoke(obj, new object[] {str});
            Console.WriteLine(newmathod);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StreamWriter write = new StreamWriter(@"C:\OOP\Lab12\Лабораторная 12.txt", false);
                Type classProduct = typeof(Product);
                Type classTextbook = typeof(Textbook);

                Reflector reflector = new Reflector();
                reflector.ClassContent(classProduct, write);
                reflector.ClassContent(classTextbook, write);

                reflector.PublicMethods(classProduct, write);
                reflector.PublicMethods(classTextbook, write);

                reflector.FieldsProperties(classProduct, write);
                reflector.FieldsProperties(classTextbook, write);

                reflector.Interfaces(classTextbook, write);

                reflector.TypeOfParameter(classProduct, write, "Int32");
                reflector.TypeOfParameter(classTextbook, write, "String");

                reflector.FileParameter(classTextbook, "Show");

                write.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \n" + ex.TargetSite);
            }
            Console.ReadKey();
        }
    }
}
