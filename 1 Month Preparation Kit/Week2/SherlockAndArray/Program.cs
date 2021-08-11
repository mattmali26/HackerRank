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

            var sum = arr.Sum();

            var add = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (add == sum - i - add)
                {
                    return "YES";
                }
                add += i;
            }

            return "NO";
        }
    }
}