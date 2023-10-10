using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> fixedData = new List<string>()
            {
                "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
                "byr:1937 iyr:2017 cid:147 hgt:183cm",
                "-",
                "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884",
                "hcl:#cfa07d byr:1929",
                "-",
                "hcl:#ae17e1 iyr:2013",
                "eyr:2024",
                "ecl:brn pid:760753108 byr:1931",
                "hgt:179cm",
                "-",
                "hcl:#cfa07d eyr:2025 pid:166559648",
                "iyr:2011 ecl:brn hgt:59in",
                "-"
            };

            List<string> data = new List<string>();

            using (var sr = new StreamReader(@"..\..\..\input"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine()!;

                    if (line == "")
                        line = "-";

                    data.Add(line!);
                }
                data.Add("-");
            }

            // TODO: find way to split different batches (DONE)
            // SOLUTION: made it so when reading file, if line == empty string, replace line with '-'

            // TODO: solve problem now
            int validCount = 0;

            StringBuilder sb = new StringBuilder();

            var theThing = data;

            // im going to kill myself
            for (int i = 0; i < theThing.Count; i++)
            {
                if (theThing[i] != "-")
                {
                    sb.Append(theThing[i]);
                }

                if (i + 1 < theThing.Count && theThing[i + 1] != "-" && theThing[i] != "-")
                {
                    sb.Append(" ");
                }

                if (theThing[i] == "-")
                {
                    string lines = sb.ToString();
                    sb.Clear();

                    string[] split = lines.Split(' ');

                    for (int j =  0; j < split.Length; j++)
                    {
                        string[] splitSplit = split[j].Split(':');

                        if (splitSplit[0] == "byr")
                        {
                            Regex rg = new("^[1920-2002]$");

                            MatchCollection matches = rg.Matches(splitSplit[1]);
                            if (matches.Count == 0)
                                break;
                        }
                        else if (splitSplit[0] == "iyr")
                        {
                            Regex rg = new("^[2010-2020]$");

                            MatchCollection matches = rg.Matches(splitSplit[1]);
                            if (matches.Count == 0)
                                break;
                        }
                        else if (splitSplit[0] == "eyr")
                        {
                            Regex rg = new("^[2020-2030]$");

                            MatchCollection matches = rg.Matches(splitSplit[1]);
                            if (matches.Count == 0)
                                break;
                        }
                        else if (splitSplit[0] == "hgt")
                        {
                            Regex rg = new("^$");

                            MatchCollection matches = rg.Matches(splitSplit[1]);
                            if (matches.Count == 0)
                                break;
                        }
                        else if (splitSplit[0] == "hcl")
                        {

                        }
                        else if (splitSplit[0] == "ecl")
                        {

                        }
                        else if (splitSplit[0] == "pid")
                        {

                        }
                        else if (splitSplit[0] == "cid")
                        {
                            continue;
                        }
                    }
                }
            }

            // 285 too high
            // 200 too low
            // 253 too low
            Console.WriteLine(validCount);
        }
    }
}