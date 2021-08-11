using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesByMatch
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

            int result = Result.SockMerchant(n, ar);

            Console.WriteLine(result);
        }
    }

    internal class Result
    {
        /*
         * Complete the 'sockMerchant' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER_ARRAY ar
         */

        public static int SockMerchant(int n, List<int> ar)
        {
            int pairNumber = 0;
            IsPair(ar, ref pairNumber);

            return pairNumber;
        }

        private static void IsPair(List<int> ar, ref int pairNumber)
        {
            if (ar.Count > 0)
            {
                int match = ar[0];
                ar.RemoveAt(0);
                var indexMatch = ar.IndexOf(match);
                if (indexMatch != -1)
                {
                    pairNumber++;
                    ar.RemoveAt(indexMatch);
                }
                IsPair(ar, ref pairNumber);
            }
        }
    }
}