using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    sealed class McLaren : Car
    {
        public McLaren(string CarModel, int Weight, int MaxWeight, int PassengerSeats, int TankCapacity, int TrunkVolume, double FuelFlow, int MaxSpeed) :
            base(Weight, MaxWeight, PassengerSeats, TankCapacity, TrunkVolume, FuelFlow, MaxSpeed)
        {
            Brand = "McLaren";
            Model = CarModel;
        }
    }
}
