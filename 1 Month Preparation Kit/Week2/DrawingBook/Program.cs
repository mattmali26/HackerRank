using System;

namespace DrawingBook
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int p = Convert.ToInt32(Console.ReadLine().Trim());

            int result = Result.PageCount(n, p);

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'pageCount' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER p
         */

        public static int PageCount(int n, int p)
        {
            var totalIndex = n / 2;
            var index = p / 2;

            if (totalIndex - index < index)
            {
                return totalIndex - index;
            }

            return index;
        }
    }
}