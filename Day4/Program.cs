// I HATE everything about this. But it worked.
// Must put a break point on the break statement or it doesn't kick out fully.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Part1();
            Part2();
        }

        static void Part1()
        {
            var grids = new List<string[,]>();
            var markedGrids = new List<bool[,]>();
            List<string> numbers = null;

            var currentGrid = -1;
            var currentRow = 0;

            // we have all our numbers and grids
            foreach (var line in File.ReadLines("Inputs.txt"))
            {
                if (numbers is null)
                {
                    numbers = line.Split(',').ToList();
                }
                else if (line is "")
                {
                    grids.Add(new string[5,5]);
                    markedGrids.Add(new bool[5,5]);
                    currentGrid++;
                    currentRow = 0;
                }
                else
                {
                    var inputs = line.Split(" ").ToList();
                    inputs.RemoveAll(x => x == "");

                    // now go find the index from numbers
                    for (int i = 0; i < inputs.Count(); i++)
                    {                        
                        grids[currentGrid][currentRow, i] = inputs[i];
                    }

                    currentRow++;
                }
            }

            // go through each num and check for bingo
            foreach (var num in numbers)
            {
                // check for it in each grid
                for (int g = 0; g < grids.Count(); g++)
                {
                    //go through each row of the grid
                    for (int i = 0; i < 5; i++)
                    {
                        // go through each column in the grid
                        for (int j = 0; j < 5; j++)
                        {
                            // check if it matches the num
                            if (num.Equals(grids[g][i, j]))
                            {
                                // mark it in the marked Grid based on i and j
                                markedGrids[g][i, j] = true;

                                // now check through the row and column and check for bingo
                                // first check the whole row 
                                // i stays the same
                                var bingo = true;
                                for (int mj = 0; mj < 5; mj++)
                                {
                                    if (!markedGrids[g][i, mj])
                                    {
                                        bingo = false;
                                        break;
                                    }
                                }

                                if (!bingo)
                                {
                                    bingo = true;
                                    // then check the column
                                    for (int mi = 0; mi < 5; mi++)
                                    {
                                        if (!markedGrids[g][mi, j])
                                        {
                                            bingo = false;
                                            break;
                                        }
                                    }
                                }

                                if (bingo)
                                {
                                    Console.WriteLine("BINGO!");
                                    // go through the marked grid, if false grab value
                                    var sum = 0;
                                    for (int mi = 0; mi < 5; mi++)
                                    {
                                        for (int mj = 0; mj < 5; mj++)
                                        {
                                            if (!markedGrids[g][mi, mj])
                                            {
                                                sum += Int32.Parse(grids[g][mi, mj]);
                                            }
                                        }
                                    }

                                    Console.WriteLine($"Sum: {sum}");
                                    var lastNumberCalled = Int32.Parse(grids[g][i,j]);
                                    Console.WriteLine($"Last number called: {lastNumberCalled}");
                                    Console.WriteLine($"Answer: {sum * lastNumberCalled}");

                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    
        static void Part2()
        {
            var grids = new List<string[,]>();
            var markedGrids = new List<bool[,]>();
            List<string> numbers = null;

            var currentGrid = -1;
            var currentRow = 0;

            var alreadyWonGrids = new Dictionary<int, bool>();

            // we have all our numbers and grids
            foreach (var line in File.ReadLines("Inputs.txt"))
            {
                if (numbers is null)
                {
                    numbers = line.Split(',').ToList();
                }
                else if (line is "")
                {
                    grids.Add(new string[5,5]);
                    markedGrids.Add(new bool[5,5]);
                    currentGrid++;
                    alreadyWonGrids.Add(currentGrid, false);
                    currentRow = 0;
                }
                else
                {
                    var inputs = line.Split(" ").ToList();
                    inputs.RemoveAll(x => x == "");

                    // now go find the index from numbers
                    for (int i = 0; i < inputs.Count(); i++)
                    {                        
                        grids[currentGrid][currentRow, i] = inputs[i];
                    }

                    currentRow++;
                }
            }

            // go through each num and check for bingo
            foreach (var num in numbers)
            {
                // check for it in each grid
                for (int g = 0; g < grids.Count(); g++)
                {
                    //go through each row of the grid
                    for (int i = 0; i < 5; i++)
                    {
                        // go through each column in the grid
                        for (int j = 0; j < 5; j++)
                        {
                            // check if it matches the num
                            if (num.Equals(grids[g][i, j]))
                            {
                                // mark it in the marked Grid based on i and j
                                markedGrids[g][i, j] = true;

                                // now check through the row and column and check for bingo
                                // first check the whole row 
                                // i stays the same
                                var bingo = true;
                                for (int mj = 0; mj < 5; mj++)
                                {
                                    if (!markedGrids[g][i, mj])
                                    {
                                        bingo = false;
                                        break;
                                    }
                                }

                                if (!bingo)
                                {
                                    bingo = true;
                                    // then check the column
                                    for (int mi = 0; mi < 5; mi++)
                                    {
                                        if (!markedGrids[g][mi, j])
                                        {
                                            bingo = false;
                                            break;
                                        }
                                    }
                                }

                                if (bingo)
                                {
                                    // check if this grid already won
                                    // if not mark it, and see if there are any false values still
                                    alreadyWonGrids[g] = true;
                                    if (!alreadyWonGrids.ContainsValue(false))
                                    {
                                        Console.WriteLine("BINGO!");
                                        // go through the marked grid, if false grab value
                                        var sum = 0;
                                        for (int mi = 0; mi < 5; mi++)
                                        {
                                            for (int mj = 0; mj < 5; mj++)
                                            {
                                                if (!markedGrids[g][mi, mj])
                                                {
                                                    sum += Int32.Parse(grids[g][mi, mj]);
                                                }
                                            }
                                        }

                                        Console.WriteLine($"Sum: {sum}");
                                        var lastNumberCalled = Int32.Parse(grids[g][i,j]);
                                        Console.WriteLine($"Last number called: {lastNumberCalled}");
                                        Console.WriteLine($"Answer: {sum * lastNumberCalled}");

                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}