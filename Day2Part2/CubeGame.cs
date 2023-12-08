using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Part2
{
    internal class CubeGame
    {
        int red;
        int green;
        int blue;
        int gameTotal;
        int total;

        public CubeGame()
        {
            red = 0;
            green = 0;
            blue = 0;
            gameTotal = 0;
            total = 0;
        }

        public void ResetGame()
        {
            red = 0;
            green = 0;
            blue = 0;
            gameTotal = 0;
        }

        public void RunGame(string line)
        {
            int titleInd = line.IndexOf(':');
            string gameData = line.Substring(titleInd + 1);
            string[] games = gameData.Split(';');
            ResetGame();
            foreach (string game in games)
            {
                string[] choices = game.Split(',');
                foreach (string choice in choices)
                {
                    string[] items = choice.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                    int num = Convert.ToInt32(items[0]);
                    switch (items[1])
                    {
                        case "red":
                            red = num > red ? num : red;
                            break;
                        case "green":
                            green = num > green ? num : green;
                            break;
                        case "blue":
                            blue = num > blue ? num : blue;
                            break;
                        default:
                            break;
                    }
                }
            }
            gameTotal = red * green * blue;
        }

        public int RunGames(string[] lines)
        {
            total = 0;
            foreach(string line in lines)
            {
                RunGame(line);
                total += gameTotal;
            }

            return total;
        }
    }
}
