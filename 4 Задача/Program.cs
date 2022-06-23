using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int Fibonachi(int n)
            {
                int result = 0;
                int b = 1;
                int tmp;
                for (int i = 0; i < n; i++)
                {
                    tmp = result;
                    result = b;
                    b += tmp;
                }
                return result;
            }
            int fib4 = Fibonachi(4);
            Console.WriteLine(fib4);
            Console.ReadLine();
            
            





            /*int Fibonachi(int n)
            {
                if (n == 0 || n == 1) return n;

                return Fibonachi(n - 1) + Fibonachi(n - 2);
            }

            int fib4 = Fibonachi(4);
            int fib5 = Fibonachi(5);
            int fib6 = Fibonachi(6);

            Console.WriteLine(fib4);
            Console.WriteLine(fib5);
            Console.WriteLine(fib6);
*/





            /*int Factorial(int n)
            {
                if (n == 1) return 1;

                return n * Factorial(n - 1);
            }
            int factorial4 = Factorial(4);
            int factorial5 = Factorial(5);
            int factorial6 = Factorial(6);

            Console.WriteLine($"Факториал числа 4 = {factorial4}");
            Console.WriteLine($"Факториал числа 5 = {factorial5}");
            Console.WriteLine($"Факториал числа 6 = {factorial6}");*/
        }
    }
}
