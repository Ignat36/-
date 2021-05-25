using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    class CarCompare : IComparer<Car>
    {

        public int Compare(Car first, Car second)
        {
            double value1 = first.MSpeed / 400.0 + first.MDistance / 1000.0;
            double value2 = second.MSpeed / 400.0 + second.MDistance / 1000.0;

            if (value1 > value2)
                return 1;
            else
                return 2;
        }

    }
}
