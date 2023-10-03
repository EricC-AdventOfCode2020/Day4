using System.Runtime.InteropServices;

namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
            string[] fields = { "ecl", "pid", "eyr", "hcl", "byr", "iyr", "cid", "hgt" };

            bool[] fieldsPresent = { false, false, false, false, false, false, false, false };

            int validCount = 0;

            for (int i = 0; i < data.Count; i++)
            {
                string line = data[i];

                if (line == "-")
                {
                    for (int j = 0; j < fields.Length; j++)
                    {
                        if (fieldsPresent[j] == false && fields[j] != "cid")
                            break;
                        else if (fieldsPresent[j] == true && j == fields.Length - 1)
                            validCount++;
                    }
                }
                else
                {
                    string[] subStrings = line.Split(' ');

                    for (int j = 0;j < subStrings.Length; j++)
                    {
                        string[] subStringsAgain = subStrings[j].Split(':');

                        int indexOfField = Array.IndexOf(fields, subStringsAgain[0]);

                        fieldsPresent[indexOfField] = true;
                    }
                }
            }

            // 285 too high
            Console.WriteLine(validCount);
        }
    }
}