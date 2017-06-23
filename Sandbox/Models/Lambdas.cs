using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox.Models
{
    public class Lambdas
    {
        public void Test()
        {
            Func<int, int, int> adder = (x, y) => x + y;
            Func<int, int> doubler = (x) => x * 2;
            Func<double, double> powerer = (x) => Math.Pow(x, 2);

            var sum = adder(5, 6);
            var doubled = doubler(311);
            var powered = powerer(3.33);

            Console.WriteLine($"5 + 6 = {sum}, 311*2 = {doubled}, 3.33^2 = {powered}");
        }
    }
}
