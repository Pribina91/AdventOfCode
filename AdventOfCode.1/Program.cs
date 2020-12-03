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

            var resultB = Find2020Triple(input.ToArray());
            Console.WriteLine($"1-{resultB.Item1} 2-{resultB.Item2} 3-{resultB.Item3} => {resultB.Item1 * resultB.Item2 * resultB.Item3}");
        }

        public static Tuple<int, int> Find2020Couple(int[] input)
        {
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

        public static Tuple<int, int, int> Find2020Triple(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i; j < input.Length; j++)
                {
                    for (int k = j; k < input.Length; k++)
                    {
                        var sum = input[i] + input[j] + input[k];
                        if (sum == 2020)
                        {
                            return new Tuple<int,int, int>(input[i], input[j], input[k]);
                        }
                    }
                    
                }
            }

            return new Tuple<int, int,int>(input[0],input[1],input[2]);
        }
    }

    
}
