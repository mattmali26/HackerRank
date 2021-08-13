using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxMin
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int k = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int arrItem = Convert.ToInt32(Console.ReadLine().Trim());
                arr.Add(arrItem);
            }

            int result = Result.MaxMin(k, arr);

            Console.WriteLine(result);
        }
    }

    internal class Result
    {
        /*
         * Complete the 'maxMin' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER k
         *  2. INTEGER_ARRAY arr
         */

        public static int MaxMin(int k, List<int> arr)
        {
            if (k == arr.Count)
            {
                return arr.Max() - arr.Min();
            }

            arr.Sort();

            var min = int.MaxValue;

            for (var i = 0; i < arr.Count - k + 1; i++)
            {
                min = Math.Min(min, arr[i + k - 1] - arr[i]);
            }

            return min;
        }
    }
}