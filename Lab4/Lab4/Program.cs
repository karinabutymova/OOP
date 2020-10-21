using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Lists
    {
        List<string> word = new List<string>();

        public void Add(string element)
        {
            word.Add(element);
        }
        public void Delete(int element)
        {
            word.RemoveAt(element);
        }
        public void AddPos(int pos, string elem)
        {
            word.Insert(pos, elem);
        }

        public void Output()
        {
            foreach (string i in word)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }
        public int Count()
        {
            return word.Count();
        }

        public string GetElement(int i)
        {
            return word[i];
        }

        public static Lists operator >>(Lists Words, int element)
        {
            Words.Delete(1);
            return Words;
        }

        public static Lists operator +(Lists Words, int pos)
        {
            Console.Write("Введите слово, которое надо вставить: ");
            string elem = Console.ReadLine();
            Words.AddPos(pos, elem);
            return Words;
        }

        public static bool operator !=(Lists Words, Lists Words2)
        {
            int kol = 0;
            if (Words.Count() != Words2.Count()) return true;
            else
            {
                for (int i = 0; i < Words.Count(); i++)
                {
                    if (Words.GetElement(i) == Words2.GetElement(i))
                        kol++;
                }
                if (kol == Words.Count()) return true;
                else return false;
            }
        }
        public static bool operator ==(Lists Words, Lists Words2)
        {
            int kol = 0;
            if (Words.Count() != Words2.Count()) return false;
            else
            {
                for (int i = 0; i < Words.Count(); i++)
                {
                    if (Words.GetElement(i) == Words2.GetElement(i))
                        kol++;
                }
            }
            if (kol == Words.Count()) return true;
            else return false;
        }

        public class Owner
        {
            public int id = 6;
            public string name = "Бутымова Карина";
            public string organization = "БГТУ";

            public class Date
            {
                public string date { get; set; }
                public Date()
                {
                    date = DateTime.Now.ToString();
                }

            }
        }
      
    }  

    public static class StatisticOperation
    {
        public static void Sum(Lists Words)
        {

            string text = "";
            for (int i = 0; i < Words.Count(); i++)
            {
                text += Words.GetElement(i) + " ";
            }
                
            Console.WriteLine("Список в единую строку: " + text);
        }

        public static void Max_Min(Lists Words)
        {
            int max = Words.GetElement(0).Length;
            int min = Words.GetElement(0).Length;
            for (int i = 0; i < Words.Count(); i++)
            {
                if(Words.GetElement(i).Length > max)
                    max = Words.GetElement(i).Length;

                if (Words.GetElement(i).Length < min)
                    min = Words.GetElement(i).Length;
            }
            int max_min = max - min;

            Console.WriteLine("Разница символов максимальнонго и минимального слова:" + max_min);

        }

        public static void CountOfElem(Lists Words)
        {
            Console.WriteLine("Количество элементов в списке:" + Words.Count());
        }

        public static string WordMax(this Lists Words)
        {
            int max = Words.GetElement(0).Length;
            int index_max = 0;
            for (int i = 0; i < Words.Count(); i++)
            {
                if (Words.GetElement(i).Length > max)
                {
                    index_max = i;
                }
            }
            return Words.GetElement(index_max);
        }
        public static Lists DelLast(this Lists Words)
        {
            int indexlast = Words.Count() - 1;
            Words.Delete(indexlast);
            return Words;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Lists.Owner owner = new Lists.Owner();
            Console.WriteLine("Я: {0} {1} {2}", owner.id, owner.name, owner.organization);

            Lists.Owner.Date time = new Lists.Owner.Date();
            Console.WriteLine(time.date);
            Console.WriteLine();


            Lists Words = new Lists();
            Words.Add("Минск");
            Words.Add("Гродно");
            Words.Add("Витебск");
            Words.Add("Могилев");

            Console.WriteLine("Список:");
            Words.Output();

            Console.WriteLine("Удаление элемента: ");
            Words = Words >> 1;
            Words.Output();

            Console.WriteLine("Добавление элемента в заданную позицию: ");
            Words = Words + 1;
            Words.Output();

            Lists Words2 = new Lists();
            Words2.Add("Минск");
            Words2.Add("Гродно");
            Words2.Add("Витебск");

            Console.WriteLine("Проверка на равенство множеств: ");
            bool eq = Words != Words2;
            if (eq)
                Console.WriteLine("Списки равны");
            else
                Console.WriteLine("Списки не равны");

            StatisticOperation.CountOfElem(Words);
            StatisticOperation.Sum(Words);
            StatisticOperation.Max_Min(Words);

            string i = Words.WordMax();
            Console.WriteLine("Самое длинное слово: " + i);

            Words.DelLast();
            Console.WriteLine("Удаление последнего: ");
            Words.Output();


            Console.ReadKey();
        }
    }
}
