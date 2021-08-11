using System;

namespace TimeConversion
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string s = Console.ReadLine();

            string result = Result.TimeConversion(s);

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'timeConversion' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         */

        public static string TimeConversion(string s)
        {
            var timespan = DateTime.Parse(s);
            return timespan.ToString("HH:mm:ss");
        }
    }
}