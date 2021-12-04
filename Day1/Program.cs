using System;
using System.Collections.Generic;
using System.IO;

namespace Day1
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
            var increases = 0;
            // we don't want the first value to be counted
            // we can assume the first depth won't be this large
            var previousDepth = Int32.MaxValue;

            foreach (var line in File.ReadLines("Inputs.txt")) 
            {
                var currentDepth = Int32.Parse(line);

                if (currentDepth > previousDepth)
                    increases++;

                previousDepth = currentDepth;
            }

            Console.WriteLine($"Part 1 # of increases: {increases}");
        }
    
        static void Part2() 
        {
            // max value indicates that we haven't filled the array yet
            var array = new int[] {0, 0, 0, Int32.MaxValue};
            var currentPosition = 0;
            var increases = 0;
            
            foreach (var line in File.ReadLines("inputs.txt"))
            {
                var currentDepth = Int32.Parse(line);
                array[currentPosition] = currentDepth;

                if (array[3] != Int32.MaxValue)
                {
                    var latestValue = array[currentPosition];
                    var oldValue = (currentPosition + 1 == 4) ? array[0] : array[currentPosition + 1];

                    if (latestValue > oldValue) increases++;
                }


                currentPosition++;

                currentPosition = (currentPosition > 3) ? 0 : currentPosition;
            }

            Console.WriteLine($"Part 2 # of increases: {increases}");
        }
    }
}
