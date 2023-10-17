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

            using (var sr = new StreamReader(@".\input"))
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
                    Regex rx = new Regex(@"byr:\b(19[2-9][0-9]|200[0-2])\b|iyr:\b(201[0-9]|2020)\b|eyr:\b(202[0-9]|2030)\b|hgt:\b(15[0-9]cm|16[0-9]cm|17[0-9]cm|18[0-9]cm|19[0-3]cm|59in|6[0-9]in|7[0-6]in)\b|hcl:#[a-f0-9]{6}|ecl:\b(amb|blu|brn|gry|grn|hzl|oth)\b|pid:[0-9]{9}");
                    //Regex rx = new Regex(@"byr:\b19[2-9][0-9]|200[0-2]\b|iyr:\b201[0-9]|2020\b|eyr:\b202[0-9]|2030\b|hgt:\b15[0-9]cm|16[0-9]cm|17[0-9]cm|18[0-9]cm|19[0-3]cm|59in|6[0-9]in|7[0-6]in\b|hcl:#[a-f0-9]{6}|\becl:amb|ecl:blu|ecl:brn|ecl:gry|ecl:grn|ecl:hzl|ecl:oth\b|pid:[0-9]{9}");

                    string line = sb.ToString();
                    sb.Clear();

                    MatchCollection match = rx.Matches(line);
                    if (match.Count == 7)
                    {
                        Console.WriteLine(line);
                        validCount++;
                    }
                }
            }

            // 285 too high
            // 200 too low
            // 253 too low
            // 254 correct

            // 186 too high (but also that's someone's answer??)
            // 185 too high
            Console.WriteLine(validCount);
            Console.ReadKey();
        }
    }
}