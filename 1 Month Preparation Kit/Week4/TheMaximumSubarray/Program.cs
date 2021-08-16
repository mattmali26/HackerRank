using System;
using System.Collections.Generic;
using System.Linq;

namespace TheMaximumSubarray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());

                List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

                List<int> result = Result.MaxSubarray(arr);

                Console.WriteLine(String.Join(" ", result));
            }

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'maxSubarray' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static List<int> MaxSubarray(List<int> arr)
        {
            // SubArray sum
            var max = arr[0];
            var sum = arr[0];
            for (int i = 1; i < arr.Count; i++)
            {
                if (sum > 0)
                {
                    sum += arr[i];
                }
                else
                {
                    sum = arr[i];
                }

                if (sum > max)
                {
                    max = sum;
                }
            }

            // SubSequence sum
            var orderedArr = arr.OrderByDescending(x => x).ToList();
            var subsequenceSum = orderedArr[0];
            for (int i = 1; i < orderedArr.Count; i++)
            {
                if (subsequenceSum + orderedArr[i] > subsequenceSum)
                {
                    subsequenceSum += orderedArr[i];
                }
                else
                {
                    break;
                }
            }

            return new List<int> { max, subsequenceSum };
        }
    }
}