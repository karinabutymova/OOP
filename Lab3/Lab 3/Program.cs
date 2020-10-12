using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
  
    public partial class Product
    {

        public const int NumberOfProducts = 10000;
        private string Name { get; set; }
        private readonly int UPC;
        private string Manufacturer { get; set; }
        private float Price { get; set; }
        private string ShelfLife { get; set; }
        private int Quantity { get; set; }
        private static int size;

        private static Random random = new Random();

    }

    public partial class Product
    {
        static Product() //статический конструктор
        {
            size = 0;
        }

        public Product() //без параметров
        {
            size++;
            Name = "Карандаш простой";
            Manufacturer = "Чехия";
            UPC = GetHashCode();
            Price = 0.9F;
            ShelfLife = "Не ограничен";
            Quantity = 30;

        }

        public Product(string name, string manufacturer, float price, string shelf_life, int quantity) //  с параметрами
        {
            size++;
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

        public float SumOfProduct()
        {
            return Price * Quantity;
        }

        public static void SelectName(ref Product[] ListOfProducts)
        {
            Console.Write("Введите наименование товара: ");
            string sName = Console.ReadLine();

            for (int i = 0; i < ListOfProducts.Length; i++)
            {
                if (ListOfProducts[i].Name == sName)
                {
                    Console.WriteLine(ListOfProducts[i]);
                    Console.WriteLine();
                }
            }
        }
        public static void SelectPrice(ref Product[] ListOfProducts)
        {
            Console.Write("Введите наименование товара: ");
            string sName = Console.ReadLine();
            Console.Write("Введите цену: ");
            int sPrice = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < ListOfProducts.Length; i++)
            {
                if (ListOfProducts[i].Name == sName && (ListOfProducts[i].Price < sPrice || ListOfProducts[i].Price == sPrice))
                {
                    Console.WriteLine(ListOfProducts[i]);
                    Console.WriteLine();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Количество всех товаров: " + Product.NumberOfProducts);

            Product product1 = new Product();
            Console.WriteLine(product1.ToString()); Console.WriteLine();
            Console.WriteLine("Общая сумма продукта: " + product1.SumOfProduct());


            Product product2 = new Product("Ручка шариковая", "Япония", 2.31F, "5 лет", 15);
            Console.WriteLine(product2.ToString()); Console.WriteLine();
            Console.WriteLine("Общая сумма продукта: " + product2.SumOfProduct());

            Product product3 = new Product("Фломастеры 12 цветов", "Франция", 8.48F, "3 года", 3);
            Console.WriteLine(product3.ToString()); Console.WriteLine();
            Console.WriteLine("Общая сумма продукта: " + product3.SumOfProduct());

            Product product4 = new Product("Фломастеры 12 цветов", "Италия", 6.17F, "3 года", 9);
            Console.WriteLine(product4.ToString()); Console.WriteLine();
            Console.WriteLine("Общая сумма продукта: " + product4.SumOfProduct());

            Product product5 = new Product("Ручка капиллярная", "Германия", 2.81F, "3 года", 21);
            Console.WriteLine(product5.ToString()); Console.WriteLine();
            Console.WriteLine("Общая сумма продукта: " + product5.SumOfProduct());

            Product product6 = new Product("Карандаш простой", "Чехия", 0.9F, "Не ограничен", 30);
            Console.WriteLine(product6.ToString()); Console.WriteLine();
            Console.WriteLine("Общая сумма продукта: " + product6.SumOfProduct());

            Console.WriteLine("____________________________________________________");
            Console.Write("Идентичность товаров: ");
            Console.WriteLine(product1.Equals(product6));

            
            Product[] ListOfProducts = new Product[] { product1, product2, product3, product4, product5, product6};

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Список товаров заданного наименования: ");
            Product.SelectName(ref ListOfProducts);

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Список товаров заданного наименования, цена которых не превосходит заданную: ");
            Product.SelectPrice(ref ListOfProducts);








            Console.ReadKey();
        }
        
    }
    
}
