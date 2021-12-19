// started but coming back to Part2.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8
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
            var count = 0;
            // we are looking for 1 4 7 8
            // this means things after the | which have either
            // 2 3 4 or 7 letters in the count
            foreach (var line in File.ReadLines("Inputs.txt"))
            {
                var delimitedSplit = line.Split('|');
                var inputs = delimitedSplit[1].Split(" ").ToList();
                inputs.RemoveAll(x => x == "");

                // go through each input
                // check for 2 3 4 or 7 count
                foreach (var input in inputs)
                {
                    if (input.Count() == 2 ||
                        input.Count() == 3 ||
                        input.Count() == 4 ||
                        input.Count() == 7)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine($"Part1 Answer: {count}");
        }

        public static void Part2()
        {
            var signalPatterns = new List<List<string>>();
            var outputValues = new List<List<string>>();

            // grab data
            foreach (var line in File.ReadLines("Inputs.txt"))
            {
                var delimitedSPlit = line.Split('|');
                var signalPattern = delimitedSPlit[0].Split(" ").ToList();
                signalPattern.RemoveAll(x => x == "");
                signalPatterns.Add(signalPattern);

                var outputValue = delimitedSPlit[1].Split(" ").ToList();
                outputValue.RemoveAll(x => x == "");
                outputValues.Add(outputValue);
            }

            // figure out problem
            for (int i = 0; i < signalPatterns.Count(); i++)
            {
                var positions = new int[7];
                // sort the list of strings
                var orderedPattern = signalPatterns[i].OrderBy(x => x.Length);

                // next we need to go through each line of strings
            }
        }
    }
}
