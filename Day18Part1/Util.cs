using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18Part1
{
    internal class Util
    {
        int height;
        int width;
        List<string> plan;
        List<Color> colors;
        string[] Lines;

        public Util(string[] lines)
        {
            height = 1;
            width = 1;
            plan = new List<string>();
            plan.Add("#");

            Lines = lines;
        }

        public void ProcessInstructions()
        {
            int x = 0;
            int y = 0;
            foreach (string line in Lines)
            {
                string[] instructionItems = line.Split(' ');
                string command = instructionItems[0];
                int length = Convert.ToInt32(instructionItems[1]);
                int colourVal = Convert.ToInt32(string.Concat("0xff", instructionItems[2].AsSpan(2, 6)),16);
                Color colour = Color.FromArgb(colourVal);
                switch (command)
                {
                    case "U":   // up
                        // does a new line need to be added
                        if (y == 0)
                        {
                            
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
