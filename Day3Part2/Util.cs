using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Part2
{
    internal class Util
    {
        string[,] schem;
        int width;
        int height;
        string digits;
        int total;
        string num1;
        string num2;


        public Util(string[] lines)
        {
            int y = -1;
            width = lines[0].Length;
            height = lines.Length;
            schem = new string[height, width];
            num1 = "";
            num2 = "";
            foreach (string line in lines)
            {
                y++;
                for (int x = 0; x < line.Length; x++)
                {
                    schem[y, x] = line.Substring(x, 1);
                }
            }
            digits = "0123456789";
        }

        public bool CheckGear(int x, int y)
        {
            bool retValue = false;



            return retValue;
        }
    }
}
