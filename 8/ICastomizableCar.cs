using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public interface ICastomizableCar
    {
        public void setCastomColor(int[,] arr);
        public void NeonColor(int color);
        public void setEngine(int speed, int capacity);
        public void setSaspension(int height, int KHidraulicCompression);
        public void setWindowColor(int color);
    }
}
