using System;
using System.IO;
using System.Linq;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
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
    }
}
