using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5
{
    class Program
    {
        // At how many points do at least two lines overlap?
        static void Main(string[] args)
        {
            Part1();
        }

        public static void Part1()
        {
            // string of x,y coords key
            // int of # of times intersected
            var points = new Dictionary<string, int>();
            foreach (var line in File.ReadLines("Inputs.txt"))
            {
                var inputs = line.Split(' ');

                var firstCoord = inputs[0].Split(',');
                var x1 = Int32.Parse(firstCoord[0]);
                var y1 = Int32.Parse(firstCoord[1]);

                var secondCoord = inputs[2].Split(',');
                var x2 = Int32.Parse(secondCoord[0]);
                var y2 = Int32.Parse(secondCoord[1]);

                if (x1 == x2 || y1 == y2)
                {
                    // then do work
                    // whichever one is not the same, then we walk through
                    // ex. x1 == x2
                    //      then we do everything between the two y's (inclusive)
                    if (x1 == x2)
                    {
                        // walk through y's
                        var times = Math.Abs(y1 - y2);
                        // starting with y do times + 1 (so we get y as well)
                        // x stays the same through out
                        // doesn't matter which x we use 1 or 2
                        for (int i = 0; i <= times; i++)
                        {
                            var key = string.Empty;
                            // need to know if x1 or x2 is bigger
                            if (y1 < y2)
                                key = $"{x1},{y1+i}";
                            else
                                key = $"{x1},{y2+i}";

                            // check if point already exists
                            var alreadyExists = points.ContainsKey(key);
                            // if already exists - increase value
                            // otherwise add it and set value to 1
                            if (alreadyExists)
                                points[key] += 1;
                            else
                                points.Add(key, 1);
                        }

                    }
                    else 
                    {
                        // walk through x's
                        var times = Math.Abs(x1 - x2);
                        // starting with x do times + 1 (so we get x as well)
                        // y stays the same through out
                        // doesn't matter which y we use 1 or 2
                        for (int i = 0; i <= times; i++)
                        {
                            var key = string.Empty;
                            // need to know if x1 or x2 is bigger
                            if (x1 < x2)
                                key = $"{x1+i},{y1}";
                            else
                                key = $"{x2+i},{y1}";

                            // check if point already exists
                            var alreadyExists = points.ContainsKey(key);
                            // if already exists - increase value
                            // otherwise add it and set value to 1
                            if (alreadyExists)
                                points[key] += 1;
                            else
                                points.Add(key, 1);
                        }
                    }
                }

                // other wise do nothing
            }

            // next find all keys with a value of 2 or more
            // get the count
            var count = points.Values.Where(x => x > 1).Count();
            Console.WriteLine($"Answer: {count}");
        }
    }
}
