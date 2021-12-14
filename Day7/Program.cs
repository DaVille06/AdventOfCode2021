using System;
using System.IO;
using System.Linq;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        public static void Part1()
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

        public static void Part2()
        {
            var fuelSpent = 0;
            // there's only one line
            foreach (var line in File.ReadLines("Inputs.txt"))
            {
                var inputs = line.Split(',').Select(int.Parse).ToList();
                var sum = 0;
                foreach (var input in inputs)
                {
                    sum += input;
                }

                // only want to consider 1 decimal place here
                var position = (int)Math.Round(((double)sum / inputs.Count()), 1);

                Console.WriteLine($"Chosen Position: {position}");

                foreach (var input in inputs)
                {
                    var difference = Math.Abs(input - position);
                    for (int i = 1; i <= difference; i++)
                    {
                        fuelSpent += i;
                    }
                }
            }

            Console.WriteLine($"Part 2 Answer: {fuelSpent}");
        }
    }
}


// 100148861 - TOO HIGH