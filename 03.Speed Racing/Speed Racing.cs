using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace programs
{
    internal class Program
    {


        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int count = int.Parse(Console.ReadLine());

            for ( int i =0; i< count; i++)
            {
                string comand = Console.ReadLine();

                string[] token = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car(token[0], double.Parse(token[1]), double.Parse(token[2]));
                cars.Add(car);

            }
            while (true)
            {
                string comand = Console.ReadLine();
                if (comand == "End") break;
                string[] token = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = token[0];


                if (action == "Drive")
                {
                    string model = token[1];
                    int km = int.Parse(token[2]);
                    Car car = cars.First(C => C.Model == model);
                    double necessaryFuel = km * car.FuelConsuptions;

                    if(necessaryFuel <= car.Fuel)
                    {
                        car.Km += km;
                        car.Fuel -= necessaryFuel;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }
                }



            }
            foreach(Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.Fuel:f2} {car.Km}");
            }




        }
        class Car
        {
            public string  Model { get; set; }
            public double  Fuel { get; set; }
            public double  FuelConsuptions { get; set; }
            public int Km { get; set; }=0;
            public Car(string model, double fuel, double fuelConsuptions)
            {
                Model = model;
                Fuel = fuel;
                FuelConsuptions = fuelConsuptions;
            }
        }
    }
}