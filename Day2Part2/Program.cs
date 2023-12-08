namespace Day2Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (File.Exists(args[0]))
                {

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
