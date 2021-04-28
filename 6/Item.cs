using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    class Item
    {
        private string ItemName;
        private double ItemVolume;
        private bool NullItemFlag;

        public string Name
        {
            get
            {
                return ItemName;
            }
        }
        public double Volume
        {
            get
            {
                return ItemVolume;
            }
        }
        public Item(string name, double volume = 0.0001)
        {
            name.Clone();
            ItemName = name;
            ItemVolume = volume;
            NullItemFlag = false;
        }
        public Item(string name, double height, double length, double width)
        {
            name.Clone();
            ItemName = name;
            ItemVolume = height * length * width;
            NullItemFlag = false;
        }

        public Item() { NullItemFlag = true; }

        public bool IsNull
        {
            get { return NullItemFlag; }
        }
    }
}
