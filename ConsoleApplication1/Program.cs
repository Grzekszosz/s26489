
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
            
        }
        static double AverageTab(int[] tab)
        {
            return tab.Average();
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