using System;
using System.Collections.Generic;
using System.Linq;

namespace SubarrayDivision1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int d = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            int result = Result.Birthday(s, d, m);

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'birthday' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY s
         *  2. INTEGER d
         *  3. INTEGER m
         */

        public static int Birthday(List<int> s, int d, int m)
        {
            int result = 0;

            if (m > s.Count)
            {
                return result;
            }

            if (s.Count.Equals(1))
            {
                if (s.Sum().Equals(d))
                {
                    return 1;
                }
                else
                {
                    return result;
                }
            }

            int startIndex = 0;
            while (startIndex <= s.Count - m)
            {
                int currentSum = 0;
                for (int segmentLength = startIndex; segmentLength < startIndex + m; segmentLength++)
                {
                    currentSum += s[segmentLength];
                }
                if (currentSum.Equals(d))
                {
                    result++;
                    startIndex++;
                }
                else
                {
                    startIndex++;
                }
            }

            return result;
        }
    }
}