using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Part1
{
    internal class Util
    {
        string[,] schem;
        int width;
        int height;
        int total;
        string digits;

        public Util(string[] lines)
        {
            digits = "0123456789";
            width = lines[0].Length;
            height = lines.Length;
            total = 0;
            schem = new string[height, width];
            int lineCtr = -1;
            foreach (string line in lines)
            {
                lineCtr++;
                for (int i = 0; i < line.Length; i++)
                {
                    schem[lineCtr, i] = line.Substring(i, 1);
                }
            }
        }

        public int Search()
        {
            int num = 0;
            bool startnum = false;
            string numStr = "";
            int startIndex = -1;
            int endIndex = -1;
            for (int y = 0; y < height; y++)
            {
                startnum = false;
                numStr = "";
                for (int x = 0; x < width; x++)
                {
                    if (digits.Contains(schem[y, x]))
                    {
                        numStr += schem[y, x];
                        if (!startnum)
                        {
                            startnum = true;
                            startIndex = x;
                            if (x == (width - 1))
                            {
                                startnum = false;
                                num = Convert.ToInt32(numStr);
                                endIndex = width - 1;
                                if (SearchNum(y, startIndex, endIndex))
                                {
                                    total += num;
                                }
                                numStr = "";
                                num = 0;
                            }
                        }
                        else if (x == (width - 1))
                        {
                            startnum = false;
                            endIndex = x;
                            num = Convert.ToInt32(numStr);
                            if (SearchNum(y, startIndex, endIndex))
                            {
                                total += num;
                            }
                            numStr = "";
                            num = 0;
                        }
                    }
                    else if (startnum)
                    {
                        startnum = false;
                        endIndex = x > startIndex ? x - 1 : startIndex;
                        num = Convert.ToInt32(numStr);
                        if (SearchNum(y, startIndex, endIndex))
                        {
                            total += num;
                        }
                        numStr = "";
                        num = 0;
                    }
                }
            }

            return total;
        }

        public bool SearchNum(int y,int startInd, int endInd)
        {
            bool retValue = false;

            int minY = y > 0 ? y - 1 : 0;
            int maxY = y < height - 1 ? y + 1 : height - 1;
            int minX = startInd > 0 ? startInd - 1 : 0;
            int maxX = endInd < width - 1 ? endInd + 1 : width - 1;
            for (int yi = minY; yi <= maxY; yi++)
            {
                if (yi == minY)
                {
                    for (int xi = minX; xi <= maxX; xi++)
                    {
                        if (schem[yi,xi] != "." && !digits.Contains(schem[yi, xi]))
                        {
                            retValue = true;
                            break;
                        }
                    }
                    if (retValue)
                    {
                        break;
                    }
                } 
                else if (yi < maxY)
                {
                    if (schem[yi,minX] != "." && !digits.Contains(schem[yi, minX]))
                    {
                        retValue = true;
                        break;
                    }
                    if (schem[yi, maxX] != "." && !digits.Contains(schem[yi, maxX]))
                    {
                        retValue = true;
                        break;
                    }
                }
                else if (yi == maxY)
                {
                    for (int xi = minX; xi <= maxX; xi++)
                    {
                        if (schem[yi,xi] != "." && !digits.Contains(schem[yi, xi]))
                        {
                            retValue = true;
                            break;
                        }
                    }
                    if (retValue)
                    {
                        break;
                    }
                }
            }


            return retValue;
        }
    }
}
