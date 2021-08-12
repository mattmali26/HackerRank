using System;
using System.Linq;

namespace SherlockAndTheValidString
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string s = Console.ReadLine();

            string result = Result.IsValid(s);

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'isValid' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         */

        public static string IsValid(string s)
        {
            var letters = s.GroupBy(x => x).Select(x => new { Letter = x.Key, Count = x.Count() });
            var differentCount = letters.Select(x => x.Count).Distinct();
            if (differentCount.Count() > 2)
            {
                return "NO";
            }
            if (differentCount.Count().Equals(1))
            {
                return "YES";
            }

            var maxCounter = differentCount.Max();
            var minCounter = differentCount.Min();

            if (letters.Where(x => x.Count.Equals(maxCounter)).Select(x => x.Letter).Count().Equals(1) || letters.Where(x => x.Count.Equals(minCounter)).Select(x => x.Letter).Count().Equals(1))
            {
                if (letters.Where(x => x.Count.Equals(maxCounter)).Select(x => x.Letter).Count().Equals(1) && maxCounter - minCounter > 1)
                {
                    return "NO";
                }
                if (letters.Where(x => x.Count.Equals(minCounter)).Select(x => x.Letter).Count().Equals(1) && minCounter > 1)
                {
                    return "NO";
                }
                return "YES";
            }
            else
            {
                return "NO";
            }
        }
    }
}