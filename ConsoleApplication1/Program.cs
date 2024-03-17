<<<<<<< HEAD
﻿
using System;
=======
﻿using System;
>>>>>>> 12e58c13876776b24b73557f18507d1574fab6d7
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
<<<<<<< HEAD
            
        }
        static double AverageTab(int[] tab)
        {
            return tab.Average();
        }
=======
            Console.WriteLine(GetMax(tab));
        }

        static int GetMax(int[] tab)
        {
            return tab.Max();
        }
        static double AverageTab(int[] tab)
        {
            return tab.Average();
        }
>>>>>>> 12e58c13876776b24b73557f18507d1574fab6d7
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