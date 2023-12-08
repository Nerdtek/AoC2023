using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Part2
{
    internal class CardManager
    {
        List<Card> originalCards;
        List<Card> wins;

        public CardManager(string[] lines)
        {
            originalCards = CreateCards(lines);
            wins = new List<Card>();
        }

        public List<Card> CreateCards(string[] lines)
        {
            List<Card> retValue = new List<Card>();

            foreach (string line in lines)
            {
                retValue.Add(new Card(line));
            }

            return retValue;
        }

        public List<Card> ProcessCards(List<Card> cards)
        {
            List<Card> retValue = new List<Card>();

            for (int ci = 0; ci < cards.Count; ci++)
            {
                int origInd = originalCards.FindIndex(c => c.CardTitle == cards[ci].CardTitle);
                if (origInd > -1)
                {
                    int numWins = cards[ci].CheckCard();
                    if (numWins > 0)
                    {
                        int startIndex = origInd + 1;
                        if (startIndex < originalCards.Count)
                        {
                            int endIndex = origInd + numWins;
                            endIndex = endIndex < originalCards.Count ? endIndex : originalCards.Count - 1;
                            for (int wi = startIndex; wi <= endIndex; wi++)
                            {
                                retValue.Add(originalCards[wi]);
                            }
                        }
                    }
                }
            }

            return retValue;
        }

        public int CheckWins()
        {
            int retValue = 0;


            List<Card> newCards = ProcessCards(originalCards);
            wins.AddRange(newCards);
            bool moreWins = true;
            while (moreWins)
            {
                newCards = ProcessCards(newCards);
                if (newCards.Count == 0)
                {
                    moreWins = false;
                }
                else
                {
                    wins.AddRange(newCards);
                }
            }
            retValue = originalCards.Count + wins.Count;
            return retValue;
        }
    }
}
