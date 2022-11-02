using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binar_2._0
{
    class Program
    {
        static int[] numbers = new int[1000000];
        static void Main(string[] args)
        {
            LoadIntArray();
            FindIndexOf(169841, numbers, 0, numbers.Length);

            Console.ReadLine();
        }
        public static void LoadIntArray()
        {
            for (int i = 0; i < 1000000; i++)
            {
                numbers[i] = i + 1;
            }
        }
        static void FindIndexOf(int find, int[] array, int from, int to)
        {
            int halfOfArray = 0;
            if (find > array.Length || find <= 0)
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
            else if (array[halfOfArray] > find)
            {
                FindIndexOf(find, array, from, halfOfArray - 1);
            }
            else if (array[halfOfArray] < find)
            {
                FindIndexOf(find, array, halfOfArray + 1, to);
            }
            else
            {
                Console.WriteLine("Číslo není v poli");
            }
        }
    }
}
