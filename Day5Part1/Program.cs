﻿namespace Day5Part1
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
                    Util util = new (lines);
                    Console.WriteLine(util.ProcessSeeds().ToString());
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