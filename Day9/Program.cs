using System;
using System.IO;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            var lowPointSum = 0;
            var grid = new int[100,100];
            // a low point is when the number above, below, left and right are higher than this number
            // first we need to fill out the grid
            // then step through the grid
            int currentRow = 0;
            foreach (var line in File.ReadLines("Inputs.txt"))
            {
                for (int i = 0; i < line.Length; i++)
                {
                    grid[currentRow, i] = Int32.Parse(line[i].ToString());
                }

                currentRow++;
            }

            // go back through and find low numbers
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    var isLowPoint = true;
                    var currentDigit = grid[i, j];
                    if (i != 0 && isLowPoint)
                    {
                        // check above ie i - 1, same j
                        if (currentDigit >= grid[i - 1, j])
                            isLowPoint = false;
                    }

                    if (i != (100 - 1) && isLowPoint)
                    {
                        // check below ie i + 1, same j
                        if (currentDigit >= grid[i + 1, j])
                            isLowPoint = false;
                    }
                        
                    if (j != 0 && isLowPoint)
                    {
                        // check left ie same i, j - 1
                        if (currentDigit >= grid[i, j - 1])
                            isLowPoint = false;
                    }

                    if (j != (100 - 1) && isLowPoint)
                    {
                        // check right ie same i, j + 1
                        if (currentDigit >= grid[i, j + 1])
                            isLowPoint = false;
                    } 

                    if (isLowPoint)
                        lowPointSum += (grid[i, j] + 1);
                }
            }

            Console.WriteLine($"Part 1 Answer: {lowPointSum}");
        }
    }
}
