//•	Сгенерировать равновероятно случайную строку длиной не более четырех строч-ных английских букв.
using System;
using System.Text;
namespace _2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            StringBuilder Str = new StringBuilder();

            for(int i = 0; i < 4; i++)
                Str.Append(Convert.ToChar(rnd.Next() % 26 + 'a'));

            Console.WriteLine(Str);
        }
    }
}
