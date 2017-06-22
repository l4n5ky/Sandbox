using Sandbox.Interfaces;
using Sandbox.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Sandbox
{
    public class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Creating an user...");
            IEncrypter encrypter = new Encrypter(); 

            User user = new User(Guid.NewGuid(), "mail@mail.com", "First", "secret", encrypter);
            Console.WriteLine(user.ToString());
            Console.WriteLine($"Password: {user.Password} Salt: {user.Salt}");

            Console.WriteLine("\nPress enter to start race!");
            Console.ReadKey();
            Console.Clear();

            Car truck = new Truck();
            Car sportCar = new SportCar();
            IEnumerable<Car> cars = new List<Car>(){ truck, sportCar };

            foreach(Car car in cars)
            {
                car.Start();
                car.Accelerate();
                car.Boost();
                car.Stop();
            }

            Console.ReadKey();
        }
    }
}