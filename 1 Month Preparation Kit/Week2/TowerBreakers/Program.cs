using System;

namespace TowerBreakers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

                int n = Convert.ToInt32(firstMultipleInput[0]);

                int m = Convert.ToInt32(firstMultipleInput[1]);

                int result = Result.TowerBreakers(n, m);

                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'towerBreakers' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER m
         */

        public static int TowerBreakers(int n, int m)
        {
            if (m.Equals(1))
            {
                return 2;
            }

            if (n % 2 == 0)
            {
                return 2;
            }
            return 1;
        }
    }
}