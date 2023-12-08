namespace Day2Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (File.Exists(args[0]))
                {
                    CubeGame cubeGame = new CubeGame(12, 13, 14);
                    string[] lines = File.ReadAllLines(args[0]);
                    Console.WriteLine(cubeGame.RunGames(lines).ToString());
                }
                else
                {
                    Console.WriteLine("Input file not found.  Check path specified.");
                }
            }
            else
            {
                Console.WriteLine("Please specify a path to an input file.");
            }
        }
    }
}
