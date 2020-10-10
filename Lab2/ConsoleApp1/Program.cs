using System;
using System.Text;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte type_1 = 99; //хранит целое число от -128 до 127(Sbyte)
            short type_2 = -30000; // хранит целое число от -32768 до 32767 (Int16 2 байта)
            int type_3 = 10; // (Int32 4 байта)
            long type_4 =-30 ; // Int64 8 байт
            byte type_5 = 0; // хранит целое число от 0 до 255 (Byte 1 байт)
            ushort type_6 = 64758; //хранит целое число от 0 до 65535 (UInt16 2 байта)
            uint type_7 = 10; // 4 байта UInt32
            ulong type_8 = 18345; // 8 байт UInt64
            char type_9 = 'N'; //хранит одиночный символ в кодировке Unicode и занимает 2 байта
            bool type_10 = false; // хранит значение true или false (логические литералы)
            float type_11 = -3.45F; // 4 байта (Single)
            double type_12 = 2.6; // 8 байт
            decimal type_13 = 0.045m; //хранит десятичное дробное число
            string type_14 = "ООП";
            object type_15 = "code"; //может хранить значение любого типа данных и занимает 4 байта на 32-разрядной платформе и 8 байт на 64-разрядной платформе.

            int i32 = 10;
            // неявное преобразование
            float a = i32;
            double b = i32;
            object c = i32;
            long d = i32;
            decimal e = i32;

            // явное преобразование
            byte f = (byte)i32;
            short g = (short)i32;
            sbyte h = (sbyte)i32;
            float i = (float)i32;
            ulong j = (ulong)i32;

            int p = 5;
            Object pak = p; //упаковка p
            byte x = (byte)(int)pak; //распаковка, приведение типа

            //неявно типизированная переменная

            var MyName = "Карина";
            var NumGroup = 11;
            Console.WriteLine($"Тип MyName: {MyName.GetType()}");
            Console.WriteLine($"Тип NumGroup: {NumGroup.GetType()}");


            int? n = 15;
            Nullable<int> nl = 15;
            Console.WriteLine(n.Value);
            Console.WriteLine(nl.Value);


            Console.WriteLine("--------------------------------------------------------------------");

            string lit1 = "Объявить ";
            string lit2 = "строковые литералы ";
            string lit3 = "и cравнить ";
            string lit4 = "и cравнить ";

            Console.WriteLine(string.Compare(lit1, lit2));
            Console.WriteLine(string.Compare(lit2, lit3)); 
            Console.WriteLine(string.Compare(lit4, lit3)); 
            Console.WriteLine();

            string lit5 = string.Concat(lit1, lit2, lit3);
            Console.WriteLine(lit5); 
            string cop = string.Copy(lit1); 
            Console.WriteLine(cop);
            Console.WriteLine(lit2.Substring(2,11)); 
            Console.WriteLine();

            string[] words = lit5.Split(' ');
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

            lit1 = lit1.Insert(9, lit3);
            Console.WriteLine(lit1);
            lit2 = lit2.Remove(0, 10);
            Console.WriteLine(lit2);

            string s = "";
            string s1 = null;
            Console.WriteLine();
            Console.WriteLine(string.IsNullOrEmpty(s));
            Console.WriteLine(string.IsNullOrWhiteSpace(s1));
            Console.WriteLine();

            StringBuilder str = new StringBuilder("Строка на основе StringBuilder");
            Console.WriteLine(str.Remove(0, 6));
            Console.WriteLine(str.Insert(0, "Эта строка"));
            Console.WriteLine(str.Append("!"));

            Console.WriteLine("--------------------------------------------------------------------");

            int[,] mass = new int[2,3] { { 1, 2, 3 }, { 4, 5, 6 } };
            for(int y = 0; y < 2; y++)
            {
                for (int z = 0; z < 3; z++)
                    Console.Write($"{mass[y, z]} \t");
                Console.WriteLine();
            }
            Console.WriteLine();

            string[] strmass = new string[] { "Одномерный ", "массив ", "строк" };
            foreach(string w in strmass)
            {
                Console.Write(w);
            }
            Console.WriteLine();
            Console.WriteLine($"Длина массива: {strmass.Length}");
            strmass[0] = "Создать одномерный ";
            Console.WriteLine();
            foreach (string w in strmass)
            {
                Console.Write(w);
            }

            Console.WriteLine();Console.WriteLine();

            Console.WriteLine("Ступенчатый массив");
            float[][] jagged = new float[3][];
            jagged[0] = new float[2] { 1.3f, 2.45f };
            jagged[1] = new float[3] { 9.7f, 8.775f, 33.3f };
            jagged[2] = new float[4] { 87.3f, 21.4f, 32.7f, 4.88f };

            foreach(float[] q in jagged)
            {
                foreach (float r in q)
                    Console.Write("\t" + r);
                Console.WriteLine();
            }
            Console.WriteLine();

            var massvar1 = new[] { 1, 2, 3 };
            var massvar2 = new[] { "неявно", "типизированные", "переменные" };
            Console.WriteLine($"Тип массива:  { massvar1.GetType()}");
            Console.WriteLine($"Тип массива:  {massvar2.GetType()}");

            Console.WriteLine("--------------------------------------------------------------------");

            ValueTuple<int, string, char, string, ulong> kort = (11, "group", 'u', "student", 23456);
            Console.WriteLine($"Вывод всего кортежа: {kort}");
            Console.WriteLine($"Вывод 1,2,4 элементов: {kort.Item1 + " " + kort.Item2 + " " + kort.Item4 }");
            Console.WriteLine();

            (int num, char lit) = (140, 'v');
            Console.WriteLine($"Распаковка: {num} {lit}");

            ValueTuple <string, int> Tuple1 = ("number", 23);
            ValueTuple <string, int> Tuple2 = ("number", 21);

            if (Tuple1 == Tuple2)
                Console.WriteLine("Кортежи равны");

            else Console.WriteLine("Кортежи неравны");
            Console.WriteLine();

            Console.WriteLine("--------------------------------------------------------------------");

            string first = "Работа с локальной функцией";
            int[] array = { 3, 4, 34, 2, 67, 8 };

            var res = GetTuple(array, first);
            Console.WriteLine(res);
           

            Console.ReadKey();
        }

        static (int, int, int, string) GetTuple(int[] array, string first)
        {
            int max = 0, min = array[0], sum = 0;

            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];

                if (array[i] < min)
                    min = array[i];

                sum += array[i];
            }

            string let = first.Substring(0, 1);

            var Results = (max, min, sum, let);
            return Results;
        
        }
    }
}
