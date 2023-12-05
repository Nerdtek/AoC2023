namespace Day4_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (File.Exists(args[0]))
                {
                    long totalScore = 0;
                    long cardScore = 0;
                    string[] cards = File.ReadAllLines(args[0]);
                    foreach (string card in cards)
                    {
                        int titleIndex = card.IndexOf(':');
                        int winStart = titleIndex + 1;
                        int winEnd = card.IndexOf('|');
                        int winLen = winEnd - winStart;
                        int numStart = winEnd + 1;
                        int numLen = card.Length - numStart;
                        string[] winNums = card.Substring(winStart, winLen).Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                        string[] checkNums = card.Substring(numStart, numLen).Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                        int numWins = winNums.Intersect(checkNums).Count();
                        cardScore = numWins > 0 ? 1 << (numWins - 1) : 0;
                        totalScore += cardScore;
                    }
                    Console.WriteLine("Total score: " + totalScore.ToString());
                }
                else
                {
                    Console.WriteLine("Input file not found.");
                }
            }
            else
            {
                Console.WriteLine("Please specify a valid input file path.");
            }
        }
    }
}
