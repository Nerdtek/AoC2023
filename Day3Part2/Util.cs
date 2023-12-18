using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
        string digits = "0123456789";

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

        public int ProcessSchematic()
        {
            int retValue = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (schem[y,x] == "*")
                    {
                        string res = FindGear(x, y);
                        if (res.Length > 0)
                        {
                            // found a gear
                            // parse the two values and add to the total
                            string[] values = res.Split(' ');
                            retValue += Convert.ToInt32(values[0]) * Convert.ToInt32(values[1]);
                        }
                    }
                }
            }

            return retValue;
        }

        public string FindGear(int x, int y)
        {
            string retValue = "";

            // Gear found see if there are two numbers and what those numbers are around the gear
            int xmin = x - 1 >= 0 ? x - 1 : 0;
            int xmax = x + 1 < width ? x + 1 : width - 1;
            int ymin = y - 1 >= 0 ? y - 1 : 0;
            int ymax = y + 1 < height ? y + 1 : height - 1;
            int numDigits = 0;
            for (int yi = ymin; yi <= ymax; yi++)
            {
                int xi = xmin;
                string res = "";
                while (res == "" && xi <= xmax)
                {
                    if (digits.Contains(schem[yi, xi]))
                    {
                        res = GetNumStr(xi, yi);
                        if (res.Length > 0)
                        {
                            string[] values = res.Split(' ');
                            retValue += retValue.Length == 0 ? values[0] : " " + values[0];
                            numDigits++;
                            int xtemp = Convert.ToInt32(values[1]);
                            xi = xtemp;
                            res = "";
                        }
                        else
                        {
                            xi++;
                        }
                    }
                    else
                    {
                        xi++;
                    }
                }
            }
            if (numDigits != 2)
            {
                retValue = "";
            }

            return retValue;
        }

        public string GetNumStr(int x, int y)
        {
            string retValue = "";

            int xmin = x;
            while (digits.Contains(schem[y, xmin]) && xmin != 0)
            {
               xmin = xmin - 1 >= 0 ? xmin - 1 : 0;
            }
            if (!digits.Contains(schem[y, xmin]))
            {
                xmin = xmin + 1 < width ? xmin + 1 : width - 1;
            }
            int xmax = x;
            while (digits.Contains(schem[y,xmax]) && xmax != width - 1)
            {
                xmax = xmax + 1 < width ? xmax + 1 : width - 1;
            }
            if (!digits.Contains(schem[y, xmax]))
            {
                xmax = xmax - 1 >= 0 ? xmax - 1 : 0;
            }
            
            for (int i = xmin; i <= xmax; i++)
            {
                retValue += schem[y, i];
            }
            xmax = xmax + 1 < width ? xmax + 1 : width - 1;

            retValue += " " + xmax.ToString();

            return retValue;
        }
    }
}
