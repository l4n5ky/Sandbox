using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sandbox.Models
{
    public class Delegates
    {
        public delegate void TemperatureReceiver(string message);

        public void Init()
        {
            TemperatureReceiver temperatureReceiver = message => { Console.WriteLine(message); };

            CheckTemperature(temperatureReceiver, temperatureReceiver, temperatureReceiver);
        }

        public void CheckTemperature(TemperatureReceiver tooLow, TemperatureReceiver optimal, TemperatureReceiver tooHigh)
        {
            var random = new Random();
            var temperature = 15;
            var seconds = 0;

            while (seconds < 15)
            {
                var difference = random.Next(-5, 5);
                temperature += difference;

                if (temperature < 10)
                {
                    tooLow($"Temperature is too low: {temperature}*C.");
                }
                else if (temperature >= 10 && temperature <= 20)
                {
                    tooLow($"Temperature is optimal: {temperature}*C.");
                }
                else
                {
                    tooHigh($"Temperature is too high: {temperature}*C.");
                }

                Thread.Sleep(1000);
                seconds++;
            }
        }
    }
}
