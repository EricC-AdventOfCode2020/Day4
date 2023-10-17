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
                "pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980",
                "hcl:#623a2f",
                "-",
                "eyr:2029 ecl:blu cid:129 byr:1989",
                "iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm",
                "-",
                "hcl:#888785",
                "hgt:164cm byr:2001 iyr:2015 cid:88",
                "pid:545766238 ecl:hzl",
                "eyr:2022",
                "-",
                "iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719",
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
                    Regex rx = new Regex(@"byr:\b(19[2-9][0-9]|200[0-2])\b|iyr:\b(201[0-9]|2020)\b|eyr:\b(202[0-9]|2030)\b|hgt:\b(15[0-9]cm|16[0-9]cm|17[0-9]cm|18[0-9]cm|19[0-3]cm|59in|6[0-9]in|7[0-6]in)\b|hcl:#[a-f0-9]{6}|ecl:\b(amb|blu|brn|gry|grn|hzl|oth)\b|pid:\b[0-9]{9}\b");
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
            // 184 was correct i'm going to kill myself
            Console.WriteLine(validCount);
            Console.ReadKey();
        }
    }
}
