using System;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace Lab14
{
    [Serializable]
    public abstract class Info
    {
        public string Language { get; set; }
        public int YearOfIssue { get; set; }
        public int NumberOfPages { get; set; }
        public Info() { }
    }
    [Serializable]
    public class Book : Info
    {
        public string NameOfBook { get; set; }
        public Book() { }
        public Book(string name, string language, int year, int pages)
        {
            NameOfBook = name;
            Language = language;
            YearOfIssue = year;
            NumberOfPages = pages;
        }
        public override string ToString()
        {
            return "Информация об издании: \nНазвание - " + NameOfBook + "\nГод выпуска -" + YearOfIssue + "\nКол-во страниц - " + NumberOfPages + "\nЯзык - " + Language;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Немного ненависти", "русский", 2019, 702);
            Book book2 = new Book("EnglishInfo", "английский", 2020, 408);
            Book book3 = new Book("Маленькие женщины", "русский", 2019, 193);
            Book book4 = new Book("Carrie", "английский", 2017, 203);

            Console.WriteLine("-----Бинарная сериализация-----");
            BinaryFormatter binaryfor = new BinaryFormatter(); 
            using (FileStream fs = new FileStream(@"C:\OOP\Lab14\book.dat", FileMode.OpenOrCreate))
            {
                binaryfor.Serialize(fs, book1);
            }

            using (FileStream fs = new FileStream(@"C:\OOP\Lab14\book.dat", FileMode.OpenOrCreate))
            {
                Book newbook1 = (Book)binaryfor.Deserialize(fs);
                Console.WriteLine(newbook1.ToString() + "\n");
            }

            Console.WriteLine("\n-----Soap сериализация-----");
            SoapFormatter soapfor = new SoapFormatter();
            using (FileStream fs = new FileStream(@"C:\OOP\Lab14\book.soap", FileMode.OpenOrCreate))
            {
                soapfor.Serialize(fs, book2);
            }

            using (FileStream fs = new FileStream(@"C:\OOP\Lab14\book.soap", FileMode.OpenOrCreate))
            {
                Book newbook2 = (Book)soapfor.Deserialize(fs);
                Console.WriteLine(newbook2.ToString() + "\n");
            }

            Console.WriteLine("\n-----Json сериализация-----");
            DataContractJsonSerializer jsonfor = new DataContractJsonSerializer(typeof(Book));
            using (FileStream fs = new FileStream(@"C:\OOP\Lab14\book.json", FileMode.OpenOrCreate))
            {
                jsonfor.WriteObject(fs, book3);
            }

            using (FileStream fs = new FileStream(@"C:\OOP\Lab14\book.json", FileMode.OpenOrCreate))
            {
                Book newbook3 = (Book)jsonfor.ReadObject(fs);
                Console.WriteLine(newbook3.ToString() + "\n");
            }

            Console.WriteLine("\n-----XML сериализация-----");
            XmlSerializer xmlfor = new XmlSerializer(typeof(Book));
            using (FileStream fs = new FileStream(@"C:\OOP\Lab14\book.xml", FileMode.OpenOrCreate))
            {
                xmlfor.Serialize(fs, book4);
            }

            using (FileStream fs = new FileStream(@"C:\OOP\Lab14\book.xml", FileMode.OpenOrCreate))
            {
                Book newbook4 = (Book)xmlfor.Deserialize(fs);
                Console.WriteLine(newbook4.ToString() + "\n");
            }

            Book[] allbooks = new Book[] { book1, book2, book3, book4 };

            Console.WriteLine("\n-----XML сериализация массива объектов-----");
            XmlSerializer masxml = new XmlSerializer(typeof(Book[]));
            using (FileStream fs = new FileStream(@"C:\OOP\Lab14\bookmas.xml", FileMode.OpenOrCreate))
            {
                masxml.Serialize(fs, allbooks);
            }

            using (FileStream fs = new FileStream(@"C:\OOP\Lab14\bookmas.xml", FileMode.OpenOrCreate))
            {
                Book[] newallbooks = (Book[])masxml.Deserialize(fs);
                foreach(Book i in newallbooks)
                {
                    Console.WriteLine(i.ToString() + "\n");
                }
            }

            Console.WriteLine("\n-----Использование XPath-----");
            XmlDocument document = new XmlDocument();
            document.Load("C://OOP//Lab14//bookmas.xml");
            XmlElement element = document.DocumentElement;

            XmlNodeList nodes = element.SelectNodes("Book[Language = 'русский']"); // все эл-ты с определенным значением вложенного эл-та
            if (nodes != null)
            {
                foreach (XmlNode n in nodes)
                {
                    Console.WriteLine(n.OuterXml + "\n");
                }
            }
               
            XmlNode el = element.SelectSingleNode("Book[4]"); // выбор по индексу
            if (el != null)
                Console.WriteLine(el.OuterXml);

            Console.WriteLine("\n-----Linq to XML-----");
            XDocument newxml = new XDocument();
            XElement root = new XElement("goods");

            XElement goodElel1 = new XElement("good");
            XAttribute nameAttr1 = new XAttribute("name","Простой карандаш");
            XElement number1 = new XElement("quantity", "70");
            XElement country1 = new XElement("country", "Чехия");

            XElement goodElel2 = new XElement("good");
            XAttribute nameAttr2 = new XAttribute("name", "Ручка шариковая");
            XElement number2 = new XElement("quantity", "100");
            XElement country2 = new XElement("country", "Польша");

            XElement goodElel3 = new XElement("good");
            XAttribute nameAttr3 = new XAttribute("name", "Фломатеры");
            XElement number3 = new XElement("quantity", "12");
            XElement country3 = new XElement("country", "Чехия");

            goodElel1.Add(nameAttr1);
            goodElel1.Add(number1);
            goodElel1.Add(country1);

            goodElel2.Add(nameAttr2);
            goodElel2.Add(number2);
            goodElel2.Add(country2);

            goodElel3.Add(nameAttr3);
            goodElel3.Add(number3);
            goodElel3.Add(country3);

            root.Add(goodElel1);
            root.Add(goodElel2);
            root.Add(goodElel3);
            newxml.Add(root);
            newxml.Save("C://OOP//Lab14//linqxml.xml");

            var linq1 = newxml.Element("goods").Elements("good").Where(n => n.Attribute("name").Value != "Ручка шариковая");
            foreach (var i in linq1)
            {
                Console.WriteLine(i + "\n");
            }

            Console.WriteLine("------------------------------");
            var linq2 = from i in newxml.Element("goods").Elements("good")
                        orderby (i.Element("country").Value)
                        select i;
            foreach (var i in linq2)
            {
                Console.WriteLine(i + "\n");
            }

            Console.ReadKey();
        }
    }
}
