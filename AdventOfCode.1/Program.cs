using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = File.ReadAllLines("input.txt");
            var input = items.Select(x => int.Parse(x));
            var result = Find2020Couple(input.ToArray());

            Console.WriteLine($"1-{result.Item1} 2-{result.Item2} => {result.Item1 * result.Item2}");
        }

        public static Tuple<int, int> Find2020Couple(int[] input)
        {
            //var ordered = input.OrderBy(x => x).ToArray();
            var first = 0;
            var lastIndex = input.Length - 1;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i; j < input.Length; j++)
                {
                    var sum = input[i] + input[j];
                    if (sum == 2020)
                    {
                        return new Tuple<int, int>(input[i], input[j]);
                    }
                }
            }

            return new Tuple<int, int>(input[0],input[1]);
        }
    }

    
}
