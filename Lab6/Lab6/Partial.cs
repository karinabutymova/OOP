using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public static partial class Controller
    {
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
}
