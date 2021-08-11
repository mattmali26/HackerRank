using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniMaxSum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

            Result.MiniMaxSum(arr);

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'miniMaxSum' function below.
         *
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static void MiniMaxSum(List<long> arr)
        {
            long minValue = arr.Min();
            long maxValue = arr.Max();

            long minSumValue = arr.Sum() - maxValue;
            long maxSumValue = arr.Sum() - minValue;

            Console.WriteLine($"{minSumValue} {maxSumValue}");
        }
    }
}