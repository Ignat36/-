using System;

namespace UtilityLibraries
{
    public static class MyLibrary
    {
        public static unsafe void Swap(int *x, int *y)
        {
            int tmp = *x;
            *x = *y;
            *y = tmp;
        }

        public static unsafe void Inc(int *x)
        {
            (*x)++;
        }

        public static unsafe int Sum(int* x, int *y)
        {
            return *x + *y;
        }
    }
}