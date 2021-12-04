using System;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        static void Part1()
        {
            var depth = 0;
            var horizontal = 0;

            foreach (var line in File.ReadLines("Inputs.txt"))
            {
                var inputs = line.Split(' ');
                // inputs[0] = direction
                // inputs[1] = value;
                var value = Int32.Parse(inputs[1]);

                if (inputs[0].Equals("forward"))
                    horizontal += value;
                if (inputs[0].Equals("up"))
                    depth -= value;
                if (inputs[0].Equals("down"))
                    depth += value;
            }
            
            Console.WriteLine($"Part 1 Current Position:\thorizontal-{horizontal}\t\tdepth-{depth}");
            Console.WriteLine($"Answer: {depth * horizontal}");
        }

        static void Part2()
        {
            var depth = 0;
            var horizontal = 0;
            var aim = 0;

            foreach (var line in File.ReadLines("Inputs.txt"))
            {
                var inputs = line.Split(' ');
                // inputs[0] = direction
                // inputs[1] = value;
                var value = Int32.Parse(inputs[1]);

                if (inputs[0].Equals("forward"))
                {
                    horizontal += value;
                    depth += aim * value;
                }
                if (inputs[0].Equals("up"))
                {
                    aim -= value;
                }
                if (inputs[0].Equals("down"))
                {
                    aim += value;
                }
            }
            
            Console.WriteLine($"Part 1 Current Position:\thorizontal-{horizontal}\t\tdepth-{depth}\taim-{aim}");
            Console.WriteLine($"Answer: {depth * horizontal}");
        }
    }
}


/*
forward X does two things:
It increases your horizontal position by X units.
It increases your depth by your aim multiplied by X.
*/