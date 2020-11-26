using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    public class Manufacturer
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    public class Product
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public float Price { get; set; }
        public string ShelfLife { get; set; }

        public Product(string name, string manufacturer, float price, string shelf_life)
        {
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
            ShelfLife = shelf_life;
        }
    }
    public class Matrix {
        public int[,] arr;
        public Matrix(int[,] _arr)
        {
            arr = _arr;
        }

        public int GetLength()
        {
            return arr.Length;
        }

        public int GetRows()
        {
            return arr.GetLength(0);
        }

        public int GetColumns()
        {
            return arr.GetLength(1);
        }

        public void Print()
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i,j] + "  ");
                }
                Console.WriteLine();
            }
        }

        public int CountOfUnits()
        {
            int num = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 1) num++;
                }
            }
            return num;
        }

        public bool EqualNumber (int n)
        {
            int num = 0, kol; ;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                kol = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 5) kol++;
                }
                if (i == 0)
                    num = kol;
                else
                {
                    if (kol != num || num == 0)
                        return false;
                }  
            }
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("______________________________________________________Задание 1______________________________________________________");
            string[] months = { "January", "Febrary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string[] sum_win_months = { "January", "Febrary", "December", "June", "July", "August" };
            int l = 7;

            IEnumerable<string> len = months.Where(n => n.Length == l);
            Console.Write("\nМесяцы с длиной строки 7: ");
            foreach (string s in len)
            {
                Console.Write(s + ' ');
            }

            IEnumerable<string> sum_win = months.Intersect(sum_win_months);
            Console.Write("\nТолько летние и зимие месяцы: ");
            foreach (string s in sum_win)
            {
                Console.Write(s + ' ');
            }

            IEnumerable<string> alph_order = months.OrderBy(n => n);
            Console.Write("\nМесяцы в алфавитном порядке: ");
            foreach (string s in alph_order)
            {
                Console.Write(s + ' ');
            }

            IEnumerable<string> u_len = months.Where(n => n.Length > 4 && n.Contains("u"));
            Console.Write("\nМесяцы длиной строки > 4 и содержат u: ");
            foreach (string s in u_len)
            {
                Console.Write(s + ' ');
            }

            Console.WriteLine("\n\n______________________________________________________Задание 2, 4______________________________________________________");

            List<Product> products = new List<Product>
            {
                new Product("Ручка шариковая", "Япония", 2.31F, "5 лет"),
                new Product("Ручка капиллярная", "Германия", 2.81F, "5 лет"),
                new Product("Карандаш простой", "Чехия", 0.9F, "Не ограничен"),
                new Product("Фломастеры 12 цветов", "Чехия", 8.48F, "3 года"),
                new Product("Ручка шариковая", "Япония", 2.31F, "5 лет"),
                new Product("Карандаш простой", "Германия", 0.9F, "Не ограничен"),

            };
            var prod = products
                .Take(5) //разбиение
                .Where(n => n.Price > 1F && n.ShelfLife.Contains("5")) //ограничение и квантификатор
                .GroupBy(n => n.Manufacturer);// упорядочивание

            foreach (var manufacturer in prod)
            {
                Console.WriteLine(manufacturer.Key + ' ' + manufacturer.Count()); //агрегация
                foreach (var n in manufacturer)
                {
                    Console.WriteLine(n.Name);
                }
            }

            Console.WriteLine("\n______________________________________________________Задание 3______________________________________________________");

            Matrix mat1 = new Matrix(new int[,]{ { 0, 1, 5 }, { 3, 1, 5 }, { 0, 1, 5 } });
            Matrix mat2 = new Matrix(new int[,] { { 5, 5, 2 }, { 1, 5, 5 } });
            Matrix mat3 = new Matrix(new int[,] { { 1, 3, 2 }, { 0, 1, 5 } });
            Matrix mat4 = new Matrix(new int[,]{ { 3, 7, 1 }, { 1, 1, 1 }, { 2, 4, 2 } });
            Matrix mat5 = new Matrix(new int[,]{ { 3, 7, 2 }, { 1, 1, 0 }, { 2, 4, 2 }, { 7, 4, 9 } });
            List<Matrix> matrix = new List<Matrix>{};
            matrix.Add(mat1);matrix.Add(mat2);matrix.Add(mat3);matrix.Add(mat4);matrix.Add(mat5);
            
            Console.Write("Cписок матриц с равным количеством 5 в каждой строке:\n");

            var equal_number = from el in matrix
                               where el.EqualNumber(5)
                               select el;

            foreach (var elem in equal_number)
            {
                elem.Print();
                Console.WriteLine("\n");
            }

            Console.Write("Максимальная(ые) матрица(ы):\n");
            var max_mat = matrix.GroupBy(el => el.GetLength());
            var key_mas = max_mat.Select(p => p.Key).ToArray();
            int max_key = key_mas.Max();

            foreach (var item in max_mat)
            {
                if (item.Key == max_key)
                {
                    foreach (var element in item)
                    {
                        element.Print();
                    }
                }
            }

            Console.Write("\nКоличество матриц размера 3х3: ");
            var num_size = from el in matrix
                           where el.GetRows() == 3 && el.GetColumns() == 3
                           select el;

            Console.WriteLine(num_size.Count());

            Console.Write("Упорядоченный список матриц по количеству единиц:\n\n");
            var orderbyunit = matrix.OrderBy(el => el.CountOfUnits());
            foreach(var elem in orderbyunit)
            {
                elem.Print();
                Console.WriteLine("\n");
            }

            var maxcountofunit = orderbyunit.Take(1);
            Console.WriteLine("Матрицa с наименьшим количеством единиц:");
            foreach(var elem in maxcountofunit)
            {
                elem.Print();
                Console.WriteLine();
            }

            maxcountofunit = orderbyunit.Skip(orderbyunit.Count() - 1);
            Console.WriteLine("Матрицa с наибольшим количеством единиц:");
            foreach (var elem in maxcountofunit)
            {
                elem.Print();
            }

            Console.WriteLine("______________________________________________________Задание 5______________________________________________________\n");

            List<Manufacturer> manufacturers = new List<Manufacturer> {
                new Manufacturer { Name = "Faber-Castell AG", Country = "Германия"},
                new Manufacturer { Name = "Penmania", Country = "Чехия"}
            };

            var join_item = from pr in products
                            join m in manufacturers on pr.Manufacturer equals m.Country
                            select new { Name = pr.Name, Country = m.Country, Manufacturer = m.Name };

            foreach (var item in join_item)
            {
                Console.WriteLine($"{item.Name} - {item.Manufacturer} ({item.Country})");
            }
            Console.ReadKey();
        }
    }
}
