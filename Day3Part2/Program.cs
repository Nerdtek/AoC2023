namespace Day3Part2
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
                    Console.WriteLine(util.ProcessSchematic().ToString());
                }
                else
                {
                    Console.WriteLine("Could not find the input file.");
                }
            } else
            {
                Console.WriteLine("Please specify the path to the input file.");
            }
        }
    }
}
