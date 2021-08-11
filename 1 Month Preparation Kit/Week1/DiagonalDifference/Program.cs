using System;
using System.Collections.Generic;
using System.Linq;

namespace DiagonalDifference
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> arr = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
            }

            int result = Result.DiagonalDifference(arr);

            Console.WriteLine(result);
        }
    }

    internal class Result
    {
        /*
         * Complete the 'diagonalDifference' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY arr as parameter.
         */

        public static int DiagonalDifference(List<List<int>> arr)
        {
            var rows = arr.Count;

            var leftSum = 0;
            var rightSum = 0;

            for (int i = 0; i < rows; i++)
            {
                leftSum += arr[i][i];
                rightSum += arr[i][(rows - 1) - i];
            }

            return Math.Abs(leftSum - rightSum);
        }
    }
}