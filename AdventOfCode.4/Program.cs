using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._4
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = File.ReadAllLines("input.txt");
            //  var items = File.ReadAllLines("sample.txt");

            var result = GetValidPassports(items).Count();

            Console.WriteLine($"total- {result}");
        }

        private static IEnumerable<Passport> GetValidPassports(string[] items)
        {
            if (items[^1] != string.Empty)
            {
                items = items.Concat(new[] { string.Empty }).ToArray();
            }

            var fields = new Dictionary<PassportFields, string>();
            foreach (var line in items)
            {
                if (line == string.Empty)
                {
                    //validate data
                    if (isPassportFieldsValid(fields))
                    {

                        yield return new Passport() { };
                    }

                    fields.Clear();
                }

                var pairs = line.Split(" ");
                foreach (var pair in pairs)
                {
                    var keyPair = pair.Split(":");
                    if (keyPair.Length != 2)
                    {
                        continue;
                    }

                    var key = keyPair[0];
                    var value = keyPair[1];
                    if (Enum.TryParse<PassportFields>(key, out var parsed))
                    {
                        fields.Add(parsed, value);
                    };
                }

            }
        }

        private static bool isPassportFieldsValid(Dictionary<PassportFields, string> fields)
        {
            if (fields.Count() < 7)
                return false;

            foreach (var field in fields)
            {
                switch (field.Key)
                {
                    case PassportFields.byr:
                        if (!int.TryParse(field.Value, out var year) || year < 1920 || year > 2002)
                            return false;
                        break;
                    case PassportFields.iyr:
                        if (!int.TryParse(field.Value, out var issueYear) || issueYear < 2010 || issueYear > 2020)
                            return false;
                        break;
                    case PassportFields.eyr:
                        if (!int.TryParse(field.Value, out var expYear) || expYear < 2020 || expYear > 2030)
                            return false;
                        break;
                    case PassportFields.hgt:
                       
                        if (!field.Value.EndsWith("cm") && !field.Value.EndsWith("in") )
                        {
                            return false;
                        }

                        if (field.Value.EndsWith("cm") )
                        {
                            var height = field.Value.Substring(0, field.Value.Length - 2);
                            if (!int.TryParse(height, out var intHeight) || intHeight < 150 || intHeight > 193)
                            return false;
                        }

                        if (field.Value.EndsWith("in"))
                        {
                            var height = field.Value.Substring(0, field.Value.Length - 2);
                            if(!int.TryParse(height,out var intHeight) || intHeight < 59 || intHeight > 76)
                                return false;

                        }
                       
                        break;
                    case PassportFields.hcl:
                        var regexHcl = @"(\#[a-f0-9]{6})"; 
                        var matchHcl = Regex.Match(field.Value, regexHcl, RegexOptions.IgnoreCase);

                        if (!matchHcl.Success)
                        {
                            return false;
                        }

                        break;
                    case PassportFields.ecl:
                        var validValues = new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                        if (!validValues.Contains(field.Value))
                            return false;
                        break;
                    case PassportFields.pid:
                        if (field.Value.Length != 9)
                            return false;

                        foreach (var character in field.Value)
                        {
                            if (!int.TryParse(character.ToString(), out var number))
                            {
                                return false;
                            }
                        }

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }


            return true;

        }
    }

    internal class Passport
    {
    }

    enum PassportFields
    {
        byr,
        iyr,
        eyr,
        hgt,
        hcl,
        ecl,
        pid,
        //cid,
    }
}
