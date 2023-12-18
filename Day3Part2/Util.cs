using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Day3Part2
{
    internal class Util
    {
        string[,] schem;
        int width;
        int height;

        public Util(string[] lines)
        {
            width = lines[0].Length;
            height = lines.Length;
            schem = new string[height, width];
            int y = 0;
            foreach (string line in lines)
            {
                for (int x = 0; x < width; x++)
                {
                    schem[y, x] = line.Substring(x, 1);
                }
                y++;
            }
        }

    }
}
