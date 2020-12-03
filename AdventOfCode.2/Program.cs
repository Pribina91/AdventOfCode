using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = File.ReadAllLines("input.txt");
          //  var items = new string[]{"1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };
            var result = GetValidPasswords(items);

            Console.WriteLine($"count={result.Count()}");
        }

        private static IEnumerable<string> GetValidPasswords(string[] strings)
        {
            foreach (var line in strings)
            {
                var splited = line.Split(' ');
                if ((splited.Length != 3))
                    throw new ArgumentException("strings");

                var minAndMax = splited[0].Split("-").Select(x => int.Parse(x)).ToArray();
                var min = minAndMax[0];
                var max = minAndMax[1];

                var letter = splited[1];
                var password = splited[2];

                //if (IsPasswordValid(password,letter[0],min,max))
                //{
                //    yield return password;
                //}

                if (IsPasswordValidB(password, letter[0], min, max))
                {
                    yield return password;
                }
            }
        }

        private static bool IsPasswordValid(string password, char c, in int min, in int max)
        {
            var characterCount = password.Count(x => x == c);
            return characterCount >= min && characterCount <= max;
        }
        private static bool IsPasswordValidB(string password, char c, in int position1, in int position2)
        {
            var validPosition1 = password.Length >= position1 && password[position1 - 1] == c;
            var validPosition2 = password.Length >= position2 && password[position2 - 1] == c;
            
            if (validPosition1 && validPosition2)
                return false;

            return validPosition1 || validPosition2;
        }
    }
}
