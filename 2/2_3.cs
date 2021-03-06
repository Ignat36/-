//•	Рассчитать максимальную степень двойки, на которую делится произведение под-ряд идущих чисел от a до b (числа целые 64-битные без знака).
using System;

namespace _2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Arr_string = Console.ReadLine().Split();
            int res = 0;
            for (int i = 0; i < Arr_string.Length; i++)
            {
                UInt64 tmp = Convert.ToUInt64(Arr_string[i]);
                while (tmp % 2 == 0)
                {
                    res++;
                    tmp /= 2;
                }
            }
            Console.WriteLine("Composition is division by 2^{0}", res);
        }
    }
}
