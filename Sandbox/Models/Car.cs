using System;

namespace Sandbox.Models
{
    public abstract class Car
    {
        public int Speed { get; protected set; } = 100;
        public int Acceleration { get; protected set; } = 10;

        public void Start()
        {
            Console.WriteLine("Engine is turning on...");
            Console.WriteLine($"{GetType().Name} running at {Speed} km/h.");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping the car...");
        }

        public virtual void Accelerate() // method is virtual, child can override it
        {
            Console.WriteLine($"Accelerating {GetType().Name}!");
            Speed += Acceleration;
        }

        public abstract void Boost(); // abstract method must be empty, it's only to override by child
    }

    public class SportCar : Car
    {
        public override void Boost()
        {
            Console.WriteLine("Boosting a sport car!");
            Speed += 50;
            Console.WriteLine($"Sport car running at {Speed} km/h.");
        }
    }

    public class Truck : Car
    {
        public override void Boost()
        {
            Console.WriteLine("Boosting a truck car!");
            Speed += 20;
            Console.WriteLine($"Truck running at {Speed} km/h.");
        }
    }
}
