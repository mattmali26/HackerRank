using System;
using System.Collections.Generic;
using System.Linq;

namespace Pairs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            int result = Result.Pairs(k, arr);

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'pairs' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER k
         *  2. INTEGER_ARRAY arr
         */

        public static int Pairs(int k, List<int> arr)
        {
            if (k >= arr.Max())
            {
                return 0;
            }

            var result = 0;

            arr.Sort();

            var index1 = 0;
            var index2 = 1;
            while (index2 < arr.Count)
            {
                if (arr[index2] - arr[index1] == k)
                {
                    result++;
                    index1++;
                    continue;
                }

                if (arr[index2] - arr[index1] < k)
                {
                    index2++;
                    continue;
                }

                if (arr[index2] - arr[index1] > k)
                {
                    index1++;
                    continue;
                }
            }

            return result;
        }
    }
}