using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binar_2._0
{
    class Program
    {
        static Random rc = new Random();
        static int[] numbers = new int[10000];
        static int last = 0;
        static void Main(string[] args)
        {
            LoadIntArray();
            while (true)
            {
                Console.Write("Zadej číslo, které chceš najít: ");
                int find = int.Parse(Console.ReadLine());
                FindIndexOf(find, numbers, 0, numbers.Length);
                Console.WriteLine();
            }
        }
        public static void LoadIntArray()
        {
            int numOfGeneration = 0;
            int numOfBadGeneration = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int n = rc.Next(20000);
                if (numbers.Contains<int>(n))
                {
                    i--;
                    numOfGeneration++;
                    numOfBadGeneration++;
                }
                else
                {
                    numbers[i] = n;
                    Console.WriteLine($"Číslo {n} přidáno");
                    numOfGeneration++;
                }
            }
            Array.Sort(numbers);
            Console.WriteLine("Vygenerováno pole o velikosti " + numbers.Length + ". Vygenerovalo se " + numOfGeneration + " čísel, z toho bylo "+ numOfBadGeneration+" duplicitních.");
        }
        static void FindIndexOf(int find, int[] array, int from, int to)
        {
            int halfOfArray = 0;
            if (find > 20000 || find <= 0)
            {
                Console.WriteLine("Číslo není v poli");
                return;
            }
            else
            {
                halfOfArray = from + (to - from) / 2;
            }

            if (array[halfOfArray] == find)
            {
                Console.WriteLine($"Číslo: {array[halfOfArray]} je na indexu {halfOfArray}");
            }
            else if (last == to - from)
            {
                Console.WriteLine("Číslo není v poli");
                return;
            }
            else if (array[halfOfArray] > find)
            {
                last = to - from;
                FindIndexOf(find, array, from, halfOfArray - 1);
            }
            else if (array[halfOfArray] < find)
            {
                last = to - from;
                FindIndexOf(find, array, halfOfArray + 1, to);
            }
        }
    }
}
