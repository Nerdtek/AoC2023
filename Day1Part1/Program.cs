namespace Day1Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >0)
            {
                if (File.Exists(args[0]))
                {
                    string[] lines = File.ReadAllLines(args[0]);
                    int total = 0;
                    foreach (string line in lines)
                    {
                        int firstNumber = line.IndexOfAny("0123456789".ToCharArray());
                        int lastNumber = line.LastIndexOfAny("0123456789".ToCharArray());
                        if (firstNumber > -1 && lastNumber > -1)
                        {
                            total += Convert.ToInt32(line.Substring(firstNumber, 1) + line.Substring(lastNumber, 1));
                        }
                    }
                    Console.WriteLine("Total: " + total.ToString());
                }
                else
                {
                    Console.WriteLine("Input file not found.  Please provide a valid path.");
                }
            }
            else
            {
                Console.WriteLine("Missing arguments.  Please specify a path to an input file.");
            }
        }
    }
}
