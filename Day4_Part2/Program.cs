namespace Day4_Part2
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
                    CardManager cardManager = new CardManager(lines);
                    Console.WriteLine("Total cards: " + cardManager.CheckWins());
                }
                else
                {
                    Console.WriteLine("Input file not found.  Check the path you provided. " + args[0]);
                }
            }
            else
            {
                Console.WriteLine("Please specify an input file path.");
            }
        }
    }
}
