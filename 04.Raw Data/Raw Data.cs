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
                Car car = new Car(token[0], int.Parse(token[1]), int.Parse(token[2]), int.Parse(token[3]));
                cars.Add(car);

            }

            string input = Console.ReadLine();

            if( input == "fragile")
            {
                foreach(Car car in cars)
                {
                    if (car.Weigth < 1000)
                    {
                        Console.WriteLine(car.Model);
                    }

                }

            }

            if(input == "flamable")
            {
                foreach (Car car in cars)
                {
                    if (car.Power > 250)
                    {
                        Console.WriteLine(car.Model);

                    }

                }

            }
            




        }
        class Car
        {
            public string  Model { get; set; }
            public int Speed { get; set; }
            public int  Power { get; set; }
            public int Weigth { get; set; }
            public Car(string model, int speed,int power,int weigth)
            {
                Model = model;
                Speed = speed;
                Power = power;
                Weigth = weigth;
            }
        }
    }
}
