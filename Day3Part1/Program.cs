namespace Day3Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (File.Exists(args[0]))
                {
                    string[] lines = File.ReadAllLines(args[0]);
                    Util util = new Util(lines);
                    Console.WriteLine(util.Search());
                }
                else
                {
                    Console.WriteLine("Input file not file.  Check Path.");
                }
            }
            else
            {
                Console.WriteLine("Missing file path in arguments.");
            }
        }
    }
}
