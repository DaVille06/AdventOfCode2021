using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> calledNumbers = null;
            var grids = new List<Dictionary<string, Coordinate>>();
            var currentGrid = -1;
            var currentRow = 0;

            foreach (var line in File.ReadLines("Inputs.txt"))
            {
                if (calledNumbers is null)
                {
                    calledNumbers = line.Split(',').ToList();
                }
                else if (line is "")
                {
                    grids.Add(new Dictionary<string, Coordinate>());
                    currentGrid++;
                    currentRow = 0;
                    continue;
                }
                else
                {
                    var gridData = line.Split(' ').ToList();
                    gridData.RemoveAll(x => x == "");

                    for (int i = 0; i < gridData.Count(); i++)
                    {
                        grids[currentGrid].Add(gridData[i], new Coordinate(currentRow, i));
                    }
                    currentRow++;
                }
            }
        }
    }

    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            XValue = x;
            YValue = y;
        }

        public int XValue { get; set; }
        public int YValue { get; set; }
    }
}
