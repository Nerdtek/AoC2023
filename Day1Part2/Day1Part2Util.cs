using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Part2
{
    internal class Day1Part2Util
    {
        string[] digits;
        Dictionary<string, string> digitLookup;

        public Day1Part2Util()
        {
            digits = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            digitLookup = new Dictionary<string, string>();
            digitLookup.Add("zero", "0");
            digitLookup.Add("one", "1");
            digitLookup.Add("two", "2");
            digitLookup.Add("three", "3");
            digitLookup.Add("four", "4");
            digitLookup.Add("five", "5");
            digitLookup.Add("six", "6");
            digitLookup.Add("seven", "7");
            digitLookup.Add("eight", "8");
            digitLookup.Add("nine", "9");
        }

        public string First(string check)
        {
            string retValue = "";

            int ind = -1;
            string firstDigit = "";

            foreach (string digit in digits)
            {
                int checkInd = check.IndexOf(digit);
                if (checkInd > -1)
                {
                    ind = ind == -1 ? checkInd : checkInd < ind ? checkInd : ind;
                }
                if (ind == checkInd && checkInd > -1)
                {
                    firstDigit = digit;
                }
            }
            if (firstDigit.Length > 1)
            {
                retValue = digitLookup[firstDigit];
            }
            else
            {
                retValue = firstDigit;
            }

            return retValue;
        }

        public string Last(string check)
        {
            string retValue = "";

            int ind = -1;
            string firstDigit = "";

            foreach (string digit in digits)
            {
                int checkInd = check.IndexOf(digit);
                if (checkInd > -1)
                {
                    ind = ind == -1 ? checkInd : checkInd > ind ? checkInd : ind;
                }
                if (ind == checkInd && checkInd > -1)
                {
                    firstDigit = digit;
                }
                if (firstDigit.Length > 1)
                {
                    retValue = digitLookup[firstDigit];
                }
                else
                {
                    retValue = firstDigit;
                }
            }

            return retValue;
        }
    }
}
