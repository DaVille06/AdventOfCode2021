/*
Part1:
    Go back and work on this one. Not a fan of the nested loops,
    making this O(n^2)
Part2:
    Don't like how the work was done twice on two separate lists.
    Should try to work this where both can be completed simultaneously.
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
            Console.WriteLine("");
            Part2();
        }

        static void Part1()
        {
            // build 5 lists of ints
 
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

        static void Part2()
        {
            var inputs = new List<string>();
            var lineCount = 0;

            foreach (var line in File.ReadLines("Inputs.txt"))
            {
                lineCount++;
                inputs.Add(line);
            }

            // using this instead of hard coding value
            // if you wanted to use less inputs per row, you could
            var rowLength = inputs.ElementAt(0).Count();

            // find oxyegn generator rating
            var oxygenGeneratorRatingInputs = inputs.ToList();
            var oxygenGeneratorLineCount = lineCount;
            for (int i = 0; i < rowLength; i++)
            {
                var firstPositionCount = oxygenGeneratorRatingInputs.Where(x => x.ElementAt(i) == '0').Count();

                if (oxygenGeneratorLineCount - firstPositionCount < firstPositionCount)
                {
                    oxygenGeneratorRatingInputs.RemoveAll(x => x.ElementAt(i) == '1');
                }
                else
                {
                    oxygenGeneratorRatingInputs.RemoveAll(x => x.ElementAt(i) == '0');
                }

                oxygenGeneratorLineCount = oxygenGeneratorRatingInputs.Count();
                // if we only have 1 value left, no need to continue
                if (oxygenGeneratorLineCount == 1)
                    break;
            }

            // find co2 scrubber rating
            var co2ScrubberRatingInputs = inputs.ToList();
            var co2ScrubberLineCount = lineCount;
            for (int i = 0; i < rowLength; i++)
            {
                var firstPositionCount = co2ScrubberRatingInputs.Where(x => x.ElementAt(i) == '0').Count();

                if (co2ScrubberLineCount - firstPositionCount < firstPositionCount)
                {
                    co2ScrubberRatingInputs.RemoveAll(x => x.ElementAt(i) == '0');
                }
                else
                {
                    co2ScrubberRatingInputs.RemoveAll(x => x.ElementAt(i) == '1');
                }

                co2ScrubberLineCount = co2ScrubberRatingInputs.Count();
                // if we only have 1 value left, no need to continue
                if (co2ScrubberLineCount == 1)
                    break;
            }

            var oxygenGenerator = oxygenGeneratorRatingInputs[0];
            var oxygenGeneratorDecimal = Convert.ToInt32(oxygenGenerator, 2);
            var co2Scrubber = co2ScrubberRatingInputs[0];
            var co2ScrubberDecimal = Convert.ToInt32(co2Scrubber, 2);

            Console.WriteLine($"Oxygen Generator: {oxygenGenerator}\t\tOxygen Generator Decimal: {oxygenGeneratorDecimal}");
            Console.WriteLine($"CO2 Scrubber: {co2Scrubber}\t\tCO2 Scrubber Decimal: {co2ScrubberDecimal}");
            Console.WriteLine($"Answer: {oxygenGeneratorDecimal * co2ScrubberDecimal}");
        }
    }
}
