
namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World");
            System.Console.WriteLine("2+2 ="+Addition(2,2) + "; 10-5 =" + Substraction(10,5));
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