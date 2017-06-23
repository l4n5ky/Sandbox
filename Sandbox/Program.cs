using Sandbox.Interfaces;
using Sandbox.Models;
using System;
using System.Collections.Generic;

namespace Sandbox
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region creating user with encapsulation and ecrypting password
            Console.WriteLine("Creating an user...");
            IEncrypter encrypter = new Encrypter();
            User user = null;

            try
            {
                user = new User(Guid.NewGuid(), "mail@mail.com", "First User", "secret", encrypter);
                Console.WriteLine(user.ToString());
                Console.WriteLine($"Password: {user.Password} Salt: {user.Salt}");
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            #endregion

            Console.WriteLine("\nPress enter to start race...");
            Console.ReadKey();
            Console.Clear();

            #region car race with abstract
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
            #endregion
            /*
            Console.WriteLine("\nPress enter to start receiving temperature...");
            Console.ReadKey();
            Console.Clear();

            #region checking temperature with delegates
            Delegates delegates = new Delegates();
            delegates.Init();
            #endregion
            */

            Console.WriteLine("\nPress enter to do some counts...");
            Console.ReadKey();
            Console.Clear();

            #region lambdas
            Lambdas lambdas = new Lambdas();
            lambdas.Test();
            #endregion

            Console.WriteLine("\nPress enter to invoke event...");
            Console.ReadKey();
            Console.Clear();

            #region events
            Console.WriteLine("Text me anything :)");
            var something = Console.ReadLine();
            Events events = new Events();
            events.Value = something;
            #endregion

            Console.WriteLine("\nPress enter to ...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}