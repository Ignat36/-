using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    abstract class Car : TransportFacility, IComparable<Car>
    {
        protected int WheelAxle, Wheels;

        protected Int64 IdentificationNumber;
        protected string Number;
        protected string Model, Brand;

        protected double Fuel;
        protected int TankCapacity;
        protected double FuelFlow;

        protected int height, length, width;
        protected int TrunkVolume;

        protected List<Item> Trunk;
        protected double OccupiedVolume;

        protected int Color, WindowColor, NeonColor, Suspention;

        public Car() { }
        public Car(int Weight, int MaxWeight, int PassengerSeats, int TankCapacity, int TrunkVolume, double FuelFlow, int MaxSpeed)
        {
            this.Weight = Weight;
            this.MaxWeight = MaxWeight;
            this.PassengerSeats = PassengerSeats;
            this.TankCapacity = TankCapacity;
            this.TrunkVolume = TrunkVolume;
            this.FuelFlow = FuelFlow;
            this.MaxSpeed = MaxSpeed;

            Fuel = 0;
            OccupiedVolume = 0;
            MaxDistance = TankCapacity * FuelFlow;
            Trunk = new List<Item>();
            IdentificationNumber = Math.Abs(GetRand());
        }

        static Int64 GetRand()
        {
            Random rnd = new Random();
            Int64 tmp = (long)((rnd.Next() * rnd.Next()) % 1e18);
            return tmp;
        }

        public void AddItem(Item NewItem)
        {
            if (OccupiedVolume + NewItem.Volume > TrunkVolume)
                Console.WriteLine("В багажнике недостаточно места для данного предмета");
            else
            {
                Trunk.Add(NewItem);
                OccupiedVolume += NewItem.Volume;
            }
        }

        public void ShoWTrunkContent()
        {
            if (Trunk.Count <= 0) return;

            Console.WriteLine("*********************************\n" +
                              "Содержимое багажника : ");

            for (int i = 0; i < Trunk.Count; i++)
                Console.WriteLine(Trunk[i].Name);

            Console.WriteLine("*********************************");
        }

        public Item TakeItem(string name)
        {
            for (int i = 0; i < Trunk.Count; i++)
                if (Trunk[i].Name == name)
                {
                    Item tmp = Trunk[i];

                    Trunk.RemoveAt(i);
                    OccupiedVolume -= tmp.Volume;

                    return tmp;
                }

            Console.WriteLine("В багажнике нат денного предмета");
            return new Item();
        }

        public virtual void FillUpTank(double Fuel)
        {
            if (Fuel <= 0)
                return;

            if (this.Fuel + Fuel >= TankCapacity)
            {
                this.Fuel = TankCapacity;
                if (TankCapacity - this.Fuel - Fuel < 0)
                    Console.WriteLine("Бак полон, остаток бензина : {0} л.", Fuel + this.Fuel - TankCapacity);
                else
                    Console.WriteLine("Бак полон");
                this.Fuel = TankCapacity;
            }
            else
            {
                this.Fuel += Fuel;
                Console.WriteLine("В баке {0} л. топлива", this.Fuel);
            }
        }

        public virtual void FillUpTank()
        {
            if (Fuel == TankCapacity)
                Console.WriteLine("Бак полон");
            else
            {
                Console.WriteLine("Долито {0} л. топлива, бак полон", TankCapacity - Fuel);
                Fuel = TankCapacity;
            }
        }

        public virtual double DrainFuel(double Fuel)
        {
            if (Fuel >= this.Fuel)
            {
                Console.WriteLine("Слито {0} л. топлива, бак пуст", this.Fuel);
                Fuel = this.Fuel;
                this.Fuel = 0;
                return Fuel;
            }
            else
            {
                Console.WriteLine("Слито {0} л. топлива, в баке осталось {1} л.", Fuel, this.Fuel - Fuel);
                this.Fuel -= Fuel;
                return Fuel;
            }
        }

        public void Move(double distance)
        {
            if (distance * FuelFlow > Fuel)
            {
                Console.WriteLine("Недостаточно топлива");
                return;
            }

            Fuel -= distance * FuelFlow;
        }

        public double CurrentFuelVolume
        {
            get
            {
                return Fuel;
            }
        }

        public int MSpeed
        {
            get
            {
                return MaxSpeed;
            }
        }

        public double MDistance
        {
            get
            {
                return MaxDistance;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Объем бака : {0}\n" +
                "Расход топлива : {1} л. на 100 км.\n" +
                "Объем багажника : {2} л.\n" +
                "Масса автомобиля : {3} т.\n" +
                "Грузоподъемность : {4} кг.\n" +
                "Максимальная скорость : {5} км/ч\n" +
                "Кол-во пассажирских мест : {6}\n" +
                "Идентификационный номер : {7}\n" +
                "Название автомобиля : {8}", TankCapacity, FuelFlow, TrunkVolume, Weight / 1000.0, MaxWeight - Weight, MaxSpeed, PassengerSeats, IdentificationNumber, Brand + Model);
        }

        public int CompareTo(Car mashina)
        {
            double value1 = MSpeed / 400.0 + MDistance / 1000.0;
            double value2 = mashina.MSpeed / 400.0 + mashina.MDistance / 1000.0;

            if (value1 > value2)
                return 1;
            else if (value1 < value2)
                return -1;
            else return 0;
        }
    }
}
