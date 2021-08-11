using System;
using System.Collections.Generic;
using System.Linq;

namespace BetweenTwoSets
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

            int total = Result.GetTotalX(arr, brr);

            Console.WriteLine(total);

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'getTotalX' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY a
         *  2. INTEGER_ARRAY b
         */

        public static int GetTotalX(List<int> a, List<int> b)
        {
            // x => x % a[i] == 0 && b[i] % x == 0

            // Get factors for b
            var max = b.Max();
            var factors = GetFactors(max);

            foreach (var item in b)
            {
                var factorsCopy = new List<int>();
                factorsCopy.AddRange(factors);
                foreach (var factor in factorsCopy)
                {
                    if (item % factor != 0)
                    {
                        factors.Remove(factor);
                    }
                }
            }

            foreach (var item in a)
            {
                var factorsCopy = new List<int>();
                factorsCopy.AddRange(factors);
                foreach (var factor in factorsCopy)
                {
                    if (factor % item != 0)
                    {
                        factors.Remove(factor);
                    }
                }
            }

            return factors.Count;
        }

        private static List<int> GetFactors(int n)
        {
            // Loop from 1 to the square root of the number
            // If number mod i is 0, add i and number / i to the list of factors

            var factors = new List<int>();
            int max = (int)Math.Sqrt(n);

            for (int factor = 1; factor <= max; factor++)
            {
                if (n % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != n / factor)
                    {
                        factors.Add(n / factor);
                    }
                }
            }

            return factors;
        }
    }
}