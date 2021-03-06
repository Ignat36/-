//•	Дана строка, состоящая из строчных английских букв. Заменить в ней все буквы, стоящие после гласных, на следующие по алфавиту (z заменяется на a).
using System;
using System.Text;
namespace _2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder Str = new StringBuilder();
            Str.Append(Console.ReadLine());

            int i;
            char temp = '\n';
            if (Str.Length > 0)
                temp = Str[0];
            for (i = 1; i < Str.Length; i++)
            {

                if(temp <'a' || temp > 'z')
                {
                    Console.WriteLine("Wrong input");
                    break;
                }

                if (temp == 'a' || temp == 'e' || temp == 'i' || temp == 'o' || temp == 'u')
                {
                    temp = Str[i];
                    Str[i] = Convert.ToChar((Convert.ToInt32(Str[i]) + 1 - 'a') % 26 + 'a');
                }
                else
                    temp = Str[i];
            }
            if(i >= Str.Length)
                Console.WriteLine(Str);
        }
    }
}
