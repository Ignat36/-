using System;
using UtilityLibraries;

class Program
{
    static unsafe void Main(string[] args)
    {
        int x, y;
        x = 5;
        y = 6;

        MyLibrary.Swap(&x, &y);
        MyLibrary.Inc(&x);

        Console.WriteLine("x = {0},  y = {1}", x, y);
    }
}