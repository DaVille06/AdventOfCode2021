using System;
using System.IO;
using System.Linq;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            var fuelSpent = 0;
            // there's only one line
            foreach (var line in File.ReadLines("Inputs.txt"))
            {
                var inputs = line.Split(',').Select(int.Parse).ToList();
                inputs.Sort();
                var position = inputs.Count() / 2;
                Console.WriteLine($"Chosen Position: {position}");
                Console.WriteLine($"Value at the position: {inputs[position]}");

                // each Math.Abs(input - input[position])
                foreach (var input in inputs)
                {
                    fuelSpent += Math.Abs(input - inputs[position]);
                }
            }

            Console.WriteLine($"Part 1 Answer: {fuelSpent}");
        }
    }
}
