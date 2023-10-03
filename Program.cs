using System.Runtime.InteropServices;
using System.Text;

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
                "iyr:2011 ecl:brn hgt:59in"
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
            }

            // TODO: find way to split different batches (DONE)
            // SOLUTION: made it so when reading file, if line == empty string, replace line with '-'

            // TODO: solve problem now
            List<string> fields = new List<string>() { "ecl", "pid", "eyr", "hcl", "byr", "iyr", "hgt", "cid" };
            List<string> fieldsCopy = new List<string>() { "ecl", "pid", "eyr", "hcl", "byr", "iyr", "hgt", "cid" };

            bool[] fieldsPresent = { false, false, false, false, false, false, false, false };

            int validCount = 0;

            StringBuilder sb = new StringBuilder();

            // im going to kill myself
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] != "-")
                {
                    sb.Append(data[i]);
                }

                if (i + 1 < data.Count && data[i + 1] != "-" && data[i] != "-")
                {
                    sb.Append(" ");
                }

                if (data[i] == "-")
                {
                    string lines = sb.ToString();
                    sb.Clear();

                    string[] split = lines.Split(' ');

                    if (split.Length == 8)
                        validCount++;
                    else if (split.Length == 7)
                    {
                        string line = "";
                        foreach (string s in split)
                        {
                            line += $"{s} ";
                        }

                        Console.WriteLine(line);
                    }
                }
            }

            // 285 too high
            // 200 too low
            Console.WriteLine(validCount);
        }
    }
}