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
                    string line = sr.ReadLine();

                    if (line == "")
                        line = "-";

                    data.Add(line!);
                }
            }

            // TODO: find way to split different batches (DONE)
            // SOLUTION: made it so when reading file, if line == empty string, replace line with '-'

            // TODO: solve problem now
            for (int i = 0; i < data.Count; i++)
            {

            }
        }
    }
}