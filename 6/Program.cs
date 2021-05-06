using System;
using System.Text;
using System.Collections.Generic;

namespace Cars
{ 
    class Program
    {

        static void Castomize(ICastomizableCar car)
        {
            Console.WriteLine("Покрасить машину : 1");
            Console.WriteLine("Добавить подсветку : 2");
            Console.WriteLine("Поменять двигатель : 3");
            Console.WriteLine("Изменить подвеску : 4");
            Console.WriteLine("Поменять цвет тонировки окон : 5");

            int request;
            string tmp;


            do
            {
                Console.WriteLine("Введите номер запроса : ");
                tmp = Console.ReadLine();
            } while (!int.TryParse(tmp, out request));
        }

        static void Main(string[] args)
        {
            int Weight, MaxWeight;
            int PassengerSeats;
            int TankCapacity;
            int TrunkVolume;
            double FuelFlow;
            int MaxSpeed;
            string tmp;
            do
            {
                Console.WriteLine("Введите вес автомобиля : ");
                tmp = Console.ReadLine();
            } while (!int.TryParse(tmp, out Weight));

            do
            {
                Console.WriteLine("Введите грузоподъемность автомобиля : ");
                tmp = Console.ReadLine();
            } while (!int.TryParse(tmp, out MaxWeight));

            MaxWeight += Weight;

            do
            {
                Console.WriteLine("Введите кол-во пассажирских мест в автомобиле : ");
                tmp = Console.ReadLine();
            } while (!int.TryParse(tmp, out PassengerSeats));

            do
            {
                Console.WriteLine("Введите объем бака автомобиля : ");
                tmp = Console.ReadLine();
            } while (!int.TryParse(tmp, out TankCapacity));

            do
            {
                Console.WriteLine("Введите объем багажника автомобиля : ");
                tmp = Console.ReadLine();
            } while (!int.TryParse(tmp, out TrunkVolume));

            do
            {
                Console.WriteLine("Введите расход топлива на 100 километров : ");
                tmp = Console.ReadLine();
            } while (!double.TryParse(tmp, out FuelFlow));

            do
            {
                Console.WriteLine("Введите максимальную скорость автомобиля : ");
                tmp = Console.ReadLine();
            } while (!int.TryParse(tmp, out MaxSpeed));

            Lamborgini MyCar = new Lamborgini("Aventodor", Weight, MaxWeight, PassengerSeats, TankCapacity, TrunkVolume, FuelFlow, MaxSpeed);

            int request = 1;

            while(request > 0)
            {
                tmp = Console.ReadLine();
                int.TryParse(tmp, out request);

                double x;
                switch (request)
                {
                    case 1:
                        MyCar.ShowInfo();
                        break;
                    case 2:
                        MyCar.ShoWTrunkContent();
                        break;
                    case 3:
                        Console.WriteLine("В баке {0} л. топлива", MyCar.CurrentFuelVolume);
                        break;
                    case 4:
                        tmp = Console.ReadLine();
                        double.TryParse(tmp, out x);
                        MyCar.Move(x);
                        break;
                    case 5:
                        tmp = Console.ReadLine();
                        double.TryParse(tmp, out x);
                        x = MyCar.DrainFuel(x);
                        break;
                    case 6:
                        MyCar.FillUpTank();
                        break;
                    case 7:
                        tmp = Console.ReadLine();
                        double.TryParse(tmp, out x);
                        MyCar.FillUpTank(x);
                        break;
                    case 8:
                        tmp = Console.ReadLine();
                        double.TryParse(tmp, out x);
                        tmp = Console.ReadLine();
                        MyCar.AddItem(new Item(tmp, x));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
