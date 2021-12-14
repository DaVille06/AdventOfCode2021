using System;
using System.Collections.Generic;
using System.IO;

namespace Day6
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
            var fishCount = new Dictionary<string, int>();

            foreach (var line in File.ReadLines("Inputs.txt"))
            {
                var inputs = line.Split(',');

                // foreach input we need to add a new key to the fish count
                foreach (var input in inputs)
                {
                    if (fishCount.ContainsKey(input))
                        fishCount[input] += 1;
                    else
                        fishCount.Add(input, 1);
                }
            }

            // need to loop through 80 times
            // go through each 0-8
            var numOfDays = 80;
            for (int i = 1; i <= numOfDays; i++)
            {
                var tempFishCounts = new Dictionary<string, int>();
                for (int j = 8; j >= 0; j--)
                {
                    // take the key j
                    // get its value
                    if (fishCount.ContainsKey(j.ToString()))
                    {
                        var jFishValue = fishCount[j.ToString()];
                        // if j is 0
                        // then we need to add the value to 6 and add the value to 8
                        if (j == 0)
                        {
                            if (tempFishCounts.ContainsKey("6"))
                                tempFishCounts["6"] += jFishValue;
                            else
                                tempFishCounts.Add("6", jFishValue);

                            tempFishCounts.Add("8", jFishValue);
                        }
                        else
                        {
                            // it now is the value of j - 1
                            tempFishCounts.Add((j - 1).ToString(), jFishValue);
                        }
                    }
                }

                // at the end of the day assign it back to main fishCount
                fishCount = tempFishCounts;               
            }

            // get the sum of all values
            var sum = 0;
            for (int i = 0; i <= 8; i++)
            {
                if (fishCount.ContainsKey(i.ToString()))
                    sum += fishCount[i.ToString()];
            }
            Console.WriteLine($"Answer: {sum}");
        }

        public static void Part2()
        {
            var fishCount = new Dictionary<string, ulong>();

            foreach (var line in File.ReadLines("Inputs.txt"))
            {
                var inputs = line.Split(',');

                // foreach input we need to add a new key to the fish count
                foreach (var input in inputs)
                {
                    if (fishCount.ContainsKey(input))
                        fishCount[input] += 1;
                    else
                        fishCount.Add(input, 1);
                }
            }

            // need to loop through 80 times
            // go through each 0-8
            var numOfDays = 256;
            for (int i = 1; i <= numOfDays; i++)
            {
                var tempFishCounts = new Dictionary<string, ulong>();
                for (int j = 8; j >= 0; j--)
                {
                    // take the key j
                    // get its value
                    if (fishCount.ContainsKey(j.ToString()))
                    {
                        var jFishValue = fishCount[j.ToString()];
                        // if j is 0
                        // then we need to add the value to 6 and add the value to 8
                        if (j == 0)
                        {
                            if (tempFishCounts.ContainsKey("6"))
                                tempFishCounts["6"] += jFishValue;
                            else
                                tempFishCounts.Add("6", jFishValue);

                            tempFishCounts.Add("8", jFishValue);
                        }
                        else
                        {
                            // it now is the value of j - 1
                            tempFishCounts.Add((j - 1).ToString(), jFishValue);
                        }
                    }
                }

                // at the end of the day assign it back to main fishCount
                fishCount = tempFishCounts;               
            }

            // get the sum of all values
            ulong sum = 0;
            for (int i = 0; i <= 8; i++)
            {
                if (fishCount.ContainsKey(i.ToString()))
                    sum += fishCount[i.ToString()];
            }
            Console.WriteLine($"Answer: {sum}");
        }
    }
}
