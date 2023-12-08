using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Part1
{
    internal class CubeGame
    {
        List<int> red;
        List<int> green;
        List<int> blue;
        int _numRed;
        int _numGreen;
        int _numBlue;
        int gameIdsTotal;

        public CubeGame(int numRed, int numGreen, int numBlue)
        {
            red = new List<int>();
            green = new List<int>();
            blue = new List<int>();
            _numRed = numRed;
            _numGreen = numGreen;
            _numBlue = numBlue;
            gameIdsTotal = 0;
        }

        public void ResetBag()
        {
            red.Clear();
            green.Clear();
            blue.Clear();
            for (int r = 0; r < _numRed; r++)
            {
                red.Add(r);
            }
            for (int g = 0; g < _numGreen; g++)
            {
                green.Add(g);
            }
            for (int b = 0; b < _numBlue; b++)
            {
                blue.Add(b);
            }
        }

        public bool RemoveRed(int num = 1)
        {
            return num <= red.Count;
        }

        public bool RemoveGreen(int num = 1)
        {
            return num <= green.Count;
        }

        public bool RemoveBlue(int num = 1)
        {
            return num <= blue.Count;
        }

        public void RunGame(string line)
        {
            ResetBag();
            int startIndex = line.IndexOf(' ') + 1;
            int endIndex = line.IndexOf(':') - 1;
            int gameNumLen = endIndex - startIndex + 1;
            int gameNum = Convert.ToInt32(line.Substring(startIndex, gameNumLen));
            string[] picks = line.Substring(endIndex + 2).Split(';');
            bool gameWon = true;
            foreach (string pick in picks)
            {
                string[] choices = pick.Split(",");
                foreach (string choice in choices)
                {
                    string[] items = choice.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    int num = Convert.ToInt32(items[0]);
                    switch (items[1])
                    {
                        case "red":
                            if (!RemoveRed(num))
                            {
                                gameWon = false;
                            }
                            break;
                        case "green":
                            if (!RemoveGreen(num))
                            {
                                gameWon = false;
                            }
                            break;
                        case "blue":
                            if (!RemoveBlue(num))
                            {
                                gameWon = false;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            if (gameWon)
            {
                gameIdsTotal += gameNum;
            }
        }

        public int RunGames(string[] lines)
        {
            foreach (string line in lines)
            {
                RunGame(line);
            }

            return gameIdsTotal;
        }
    }
}
