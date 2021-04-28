using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    sealed class Lamborgini : Car
    {
        enum Mode { ON, OFF }
        private Mode SportiveMode;
        public void SportON()
        {
            if (SportiveMode == Mode.OFF)
            {
                MaxSpeed = (int)(MaxSpeed * 1.5);
                SportiveMode = Mode.ON;
            }
            else
                Console.WriteLine("Sportive mode is alrady ON!");
        }
        public void SportOFF()
        {
            if (SportiveMode == Mode.ON)
            {
                MaxSpeed = (int)(MaxSpeed / 1.5);
                SportiveMode = Mode.OFF;
            }
            else
                Console.WriteLine("Sportive mode is alrady ON!");
        }
        public Lamborgini(string CarModel, int Weight, int MaxWeight, int PassengerSeats, int TankCapacity, int TrunkVolume, double FuelFlow, int MaxSpeed) :
            base(Weight, MaxWeight, PassengerSeats, TankCapacity, TrunkVolume, FuelFlow, MaxSpeed)
        {
            Brand = "Lamborgini";
            Model = CarModel;
            SportiveMode = Mode.OFF;
        }
    }
}
