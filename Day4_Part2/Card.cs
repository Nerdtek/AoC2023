using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Part2
{
    internal class Card
    {
        public string CardTitle;
        string[] WinNums;
        string[] CheckNums;

        public Card(string cardData)
        {
            CardTitle = "";
            WinNums = new string[0];
            CheckNums = new string[0];
            if (cardData.Length > 0)
            {
                int titleDelInd = cardData.IndexOf(':');
                if (titleDelInd > -1)
                {
                    CardTitle = cardData.Substring(0, titleDelInd);
                    int winDelInd = cardData.IndexOf('|');
                    if (winDelInd > -1)
                    {
                        int winNumLen = winDelInd - titleDelInd;
                        WinNums = cardData.Substring(titleDelInd + 1, winNumLen).Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                        CheckNums = cardData.Substring(winDelInd + 1).Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                    }
                }
            }
        }

        public int CheckCard()
        {
            int retValue = 0;

            if (WinNums.Length > 0)
            {
                retValue = WinNums.Intersect(CheckNums).Count();
            }

            return retValue;
        }
    }
}
