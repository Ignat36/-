//•	Рассчитать максимальную степень двойки, на которую делится произведение под-ряд идущих чисел от a до b (числа целые 64-битные без знака).
using System;

namespace _2_3
{
    class Program
    {
        static Int64 solve(Int64 x)
        {
            Int64 ans = 0, temp = 2;
            while (x / temp > 0)
            {
                ans += x / temp;
                temp *= 2;
            }

            return ans;
        }
        static void Main(string[] args)
        {
            Int64 a, b;
            Console.Write("Enter integer a: ");
            string A = Console.ReadLine();
            if (Int64.TryParse(A, out a)) { }
            else
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            Console.Write("Enter integer b: ");
            string B = Console.ReadLine();
            if (Int64.TryParse(B, out b)) { }
            else
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            Console.WriteLine("Product of numbers is divisible by 2 in power {0}",solve(b) - solve(a-1));

        }
    }
}
