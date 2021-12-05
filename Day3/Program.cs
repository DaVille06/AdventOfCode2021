/*
    Go back and work on this one. Not a fan of the nested loops,
    making this O(n^2)
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
        }

        static void Part1()
        {
            // build 5 lists of ints
            // after placing them all in
            // find the max of 0 and 1
            // which ever is bigger, store value for gamma
            // which ever is smaller, store value for epsilon
            var gamma = "";
            var epsilon = "";

            var bits = new List<string>
            {
                "", "", "", "", "", "",
                "", "", "", "", "", ""
            };

            // gives us a list containing all values
            foreach (var line in File.ReadLines("Inputs.txt"))
            {
                for (int i = 0; i < line.Length; i++)
                {
                    bits[i] = bits[i] + line[i];
                }
            }

            for (int i = 0; i < bits.Count; i++)
            {
                var zeros = bits[i].Count(x => x == '0');
                var ones = bits[i].Count(x => x == '1');

                if (zeros > ones)
                {
                    gamma += '0';
                    epsilon += '1';
                }
                else
                {
                    gamma += '1';
                    epsilon += '0';
                }
            }

            var gammaDecimal = Convert.ToInt32(gamma, 2);
            var epsilonDecimal = Convert.ToInt32(epsilon, 2);

            Console.WriteLine($"Gamma: {gamma}\t\tGamma Decimal: {gammaDecimal}");
            Console.WriteLine($"Epsilon: {epsilon}\t\tEpsilon Decimal: {epsilonDecimal}");
            Console.WriteLine($"Answer: {gammaDecimal * epsilonDecimal}");
        }
    }
}
