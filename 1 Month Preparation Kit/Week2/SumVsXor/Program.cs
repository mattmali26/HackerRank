using System;
using System.Linq;

namespace SumVsXor
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            long n = Convert.ToInt64(Console.ReadLine().Trim());

            long result = Result.SumXor(n);

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'sumXor' function below.
         *
         * The function is expected to return a LONG_INTEGER.
         * The function accepts LONG_INTEGER n as parameter.
         */

        public static long SumXor(long n)
        {
            var base2 = Convert.ToString(n, 2).TrimStart('0');
            var k = base2.Count(x => x.Equals('0'));
            return (long)Math.Pow(2, k);

            //long result = 0;
            //for (int i = 0; i <= n; i++)
            //{
            //    if ((n + i) == (n ^ i))
            //    {
            //        result++;
            //    }
            //}

            //return result;
        }
    }
}