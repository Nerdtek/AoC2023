using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9Part1
{
    internal class Util
    {
        List<int> values;
        List<List<int>> diffs;
        int total;

        public Util(string[] lines)
        {
            values = new List<int>();
            diffs = new List<List<int>>();
            total = 0;
            int linectr = 0;
            foreach (string line in lines)
            {
                Console.WriteLine("Line:" + linectr.ToString());
                values = new List<int>();
                diffs = new List<List<int>>();
                string[] valStrs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                foreach (string valStr in valStrs)
                {
                    values.Add(Convert.ToInt32(valStr));
                }
                if (values.Count > 1)
                {
                    diffs.Add(new List<int>());
                    Console.Write("Level: 0 :");
                    for (int di = 1; di < values.Count; di++)
                    {
                        int curdiff = values[di] - values[di - 1];
                        diffs[0].Add(curdiff);
                        Console.Write(curdiff.ToString()+ " ");
                    }
                    Console.WriteLine();
                }
                int lvl = 0;
                while (isDiffNonZero(lvl))
                {
                    Console.Write("Level: " + lvl.ToString() + " :");
                    if (diffs[lvl].Count > 1)
                    {
                        diffs.Add(new List<int>());
                        for (int di = 1; di < diffs[lvl].Count; di++)
                        {
                            int workdiff = diffs[lvl][di] - diffs[lvl][di - 1];
                            diffs[lvl + 1].Add(workdiff);
                            Console.Write(workdiff.ToString() + " ");
                        }
                    }
                    lvl++;
                    Console.WriteLine();
                }
                diffs[lvl].Add(0);
                lvl--;
                while (lvl >= 0)
                {
                    int finaldiff = diffs[lvl + 1][diffs[lvl + 1].Count - 1];
                    int finalval = diffs[lvl][diffs[lvl].Count - 1] + finaldiff;
                    diffs[lvl].Add(finalval);
                    lvl--;
                }
                int diff = diffs[0][diffs[0].Count - 1];
                int val = values[values.Count - 1] + diff;
                total += val;
                linectr++;
            }
            Console.WriteLine("Total: " + total.ToString());
        }

        public bool isDiffNonZero(int index = 0)
        {
            bool retValue = false;

            foreach (int diff in diffs[index])
            {
                if (diff > 0)
                {
                    retValue = true;
                    break;
                }
            }

            return retValue;
        }
    }
}
