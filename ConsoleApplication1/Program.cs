
using System;
using System.Linq;

namespace ConsoleApplication1
{
    internal class Program      
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            int[] tab={1,2,3,4,5};
            Console.WriteLine(AverageTab(tab));
            Console.WriteLine(GetMax(tab));
        }

        //Wylicza max z tablicy int
        static int GetMax(int[] tab)
        {
            return tab.Max();
        }
        static double AverageTab(int[] tab)
        {
            Console.WriteLine("Obliczanie średniej");
            var avarage = 0;
            foreach (var i in tab)
            {
                avarage += i;
            }
            return avarage / tab.Length;

        }
        static int Addition(int a, int b)
        {
            return a + b;
        }

        static int Substraction(int a, int b)
        {
            return a - b;
        }
        
    }
}