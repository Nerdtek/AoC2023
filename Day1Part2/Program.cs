namespace Day1Part2
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
                    int total = 0;
                    Day1Part2Util util = new Day1Part2Util();
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                        string firstNumber = util.First(line);
                        string lastNumber = util.Last(line);
                        Console.WriteLine(firstNumber + lastNumber);
                        total += Convert.ToInt32(firstNumber + lastNumber);
                    }
                    Console.WriteLine("Total:" + total.ToString());
                }
            }
        }
    }
}
