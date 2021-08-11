using System;

namespace CounterGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            long n = 660570904136157;
            string result = Result.CounterGame(n);

            Console.WriteLine(result);

            //int t = Convert.ToInt32(Console.ReadLine().Trim());

            //for (int tItr = 0; tItr < t; tItr++)
            //{
            //    long n = Convert.ToInt64(Console.ReadLine().Trim());

            //    string result = Result.CounterGame(n);

            //    Console.WriteLine(result);
            //}

            //Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'counterGame' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts LONG_INTEGER n as parameter.
         */

        public static string CounterGame(long n)
        {
            int turn = 1;

            Decrement(n, ref turn);

            return turn % 2 == 0 ? "Richard" : "Louise";
        }

        private static bool IsTwoPower(long n)
        {
            long pow = 1;
            while (pow < n)
            {
                pow *= 2;
            }

            return pow == n;

            //int powerNumber = 0;

            //while (true)
            //{
            //    if (n % 2 == 0)
            //    {
            //        n /= 2;
            //        powerNumber++;
            //        if (n.Equals(1))
            //        {
            //            return true;
            //        }
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            //return false;
        }

        private static void Decrement(long n, ref int turn)
        {
            var isTwoPower = (n % 2 == 0) && IsTwoPower(n);
            if (isTwoPower)
            {
                n /= 2;
            }
            else
            {
                var nextLowerTwoPower = (long)Math.Pow(2, (int)(Math.Log(n) / Math.Log(2)));
                n -= nextLowerTwoPower;
            }
            if (!n.Equals(1))
            {
                turn++;
                Decrement(n, ref turn);
            }
        }
    }
}