using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._3
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = File.ReadAllLines("input.txt");
           // var items = File.ReadAllLines("sample.txt");

            var speeds = new List<(int down, int right)>()
            {
                (1,1),
                (1,3),
                (1,5),
                (1,7),
                (2,1),
            };
            long result = 1; 
            foreach (var speed in speeds)
            {
                var treesCount = GetTreesDownHill(speed, items).Count();
                Console.WriteLine($"down-{speed.down} right-{speed.right} count- {treesCount}");
                result *= treesCount;
            }

            Console.WriteLine($"total- {result}");
        }

        private static IEnumerable<(int x, int y)> GetTreesDownHill((int down,int right) speed, string[] items)
        {
            var yPosition = 0;
            for (int i = 0; i < items.Length; i += speed.down)
            {
                var line = items[i];
               
                if (line[yPosition] == '#')
                {
                    yield return (i, yPosition);
                }

                yPosition += speed.right;
                if (yPosition >= line.Length)
                {
                    yPosition -= line.Length;
                }
            }

        }
    }
}
