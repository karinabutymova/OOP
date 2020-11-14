using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Game
    {
        int health;
        public Game(int _health)
        {
            health = _health;
        }
        public void Add (int _health)
        {
            if (Heal != null && Attack != null)
            {
                health += _health;
                if (health > 100 || health == 100)
                {
                    Heal("Здоровье полностью восстановлено");
                    health = 100;
                }
                else
                    Heal($"После лечения текущее здоровье: {health}");
            }
            else
            {
                Console.WriteLine("Невозможно получить корректную информация");
            }
        }
        public void TakeAway(int _health)
        {
            
            if (Attack != null && Heal != null)
            {
                if (health == 100 || health > 100)
                    health = 100 - _health;
                else
                    health -= _health;

                if (health > 0 || health != 0)
                    Attack($"После атаки текущее здоровье: {health}");
                else
                    Attack($"Игрок убит");
            }
            else
            {
                Console.WriteLine("Невозможно получить корректную информация");
            }
        }
        public delegate void GameMessage(string message);
        public event GameMessage Heal;
        public event GameMessage Attack;
        public static void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
     class Program
    {
        
        static void DeleteDoubleSpaces (string str)
        {
            Console.WriteLine(str.Replace("  ", " "));
        }
        static void DeleteDotComma (string str)
        {
            str = str.Replace(".", String.Empty);
            str = str.Replace(",", String.Empty);
            Console.WriteLine(str);
        }
        static string AddSymbol(string str)
        {
            return str += " №9";
        }
        static string AddStatus(string str, Func<string, string> addsym)
        {
            string str1 = addsym(str);
            Console.WriteLine(str1);
            return str1.Insert(0, "выполнена ");
        }
        static string Upper(string str, Func<string, string> addsym, Func<string, Func<string, string>, string> addst)
        {
            string str1 = addst(str, addsym);
            Console.WriteLine(str1);
            return str1.ToUpper();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("-------------Игрок №1------------ - ");
            Game player1 = new Game(100);
            player1.Heal += Game.Display;
            player1.Attack += Game.Display;
            player1.TakeAway(50);
            player1.Add(23);
            player1.Attack -= (Game.Display);
            player1.Add(100);

            Console.WriteLine("\n-------------Игрок №2------------ - ");
            Game player2 = new Game(100);
            player2.Heal += Game.Display;
            player2.Attack += Game.Display;
            player2.TakeAway(10);
            player2.Add(5);
            player2.TakeAway(45);

            Console.WriteLine("\n________________________________Работа с строкой________________________________");
            string str = "лабо.рат,орная  работа";
            Console.WriteLine(str);
            Func<string, string> addsym = AddSymbol;
            Func<string, Func<string,string>, string> addst = AddStatus;
            Func<string, Func<string, string>, Func<string, Func<string, string>, string>, string> WorkStr2 = Upper;
            string str1 = WorkStr2(str, addsym, addst);
            Console.WriteLine(str1);

            Action<string> WorkSrt = DeleteDoubleSpaces;
            WorkSrt(str1);
            WorkSrt = DeleteDotComma;
            WorkSrt(str1);
            Console.ReadKey();
        }
    }
}
