using System;
using System.Collections.Generic;
using System.Linq;

namespace SherlockAndArray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int T = Convert.ToInt32(Console.ReadLine().Trim());

            for (int TItr = 0; TItr < T; TItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());

                List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

                string result = Result.BalancedSums(arr);

                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'balancedSums' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static string BalancedSums(List<int> arr)
        {
            if (arr.Count.Equals(1))
            {
                return "YES";
            }
            else
            {
                if (arr.Count.Equals(2))
                {
                    return "NO";
                }
            }

            var sum = arr.Sum();

            var leftSum = arr[0];
            var rightSum = sum - arr[1] - arr[0];
            if (leftSum == rightSum)
            {
                return "YES";
            }
            else
            {
                var i = 2;
                for (; i < arr.Count; i++)
                {
                    leftSum += arr[i - 1];
                    rightSum -= arr[i];
                    if (leftSum == rightSum)
                    {
                        return "YES";
                        //break;
                    }
                }
                if (i == arr.Count)
                {
                    return "NO";
                }
            }

            return "NO";
        }
    }
}