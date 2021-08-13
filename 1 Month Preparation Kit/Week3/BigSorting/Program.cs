using System;
using System.Collections.Generic;

namespace BigSorting
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> unsorted = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string unsortedItem = Console.ReadLine();
                unsorted.Add(unsortedItem);
            }

            List<string> result = Result.BigSorting(unsorted);

            Console.WriteLine(String.Join("\n", result));

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'bigSorting' function below.
         *
         * The function is expected to return a STRING_ARRAY.
         * The function accepts STRING_ARRAY unsorted as parameter.
         */

        public static List<string> BigSorting(List<string> unsorted)
        {
            //return unsorted.OrderBy(x => x.Length).ThenBy(x => x).ToList();
            unsorted.Sort(new SortComparer());
            return unsorted;
        }
    }

    internal class SortComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Length < y.Length)
            {
                return -1;
            }
            else
            {
                if (x.Length > y.Length)
                {
                    return 1;
                }
                else
                {
                    if (x == y)
                    {
                        return 0;
                    }
                    else
                    {
                        var i = 0;
                        while (x[i] == y[i])
                        {
                            i++;
                        }

                        return x[i].CompareTo(y[i]);
                    }
                }
            }
        }
    }
}