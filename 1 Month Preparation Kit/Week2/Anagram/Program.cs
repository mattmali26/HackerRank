using System;
using System.Linq;

namespace Anagram
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine().Trim());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                int result = Result.Anagram(s);

                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'anagram' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts STRING s as parameter.
         */

        public static int Anagram(string s)
        {
            if (s.Length % 2 != 0)
            {
                return -1;
            }

            var firstHalf = s.Substring(0, s.Length / 2);
            //var secondHalf = s.Substring(s.Length / 2);
            var secondHalf = s[(s.Length / 2)..];

            var diff = 0;

            var multipleCharList = firstHalf.GroupBy(x => x).Select(x => new { Car = x.Key, Count = x.Count() });
            foreach (var item in multipleCharList.Where(x => x.Count > 1))
            {
                if (item.Count > secondHalf.Where(x => x.Equals(item.Car)).Count())
                {
                    diff += Math.Abs(item.Count - secondHalf.Where(x => x.Equals(item.Car)).Count());
                    firstHalf = firstHalf.Replace($"{item.Car}", "");
                }
            }

            diff += firstHalf.Except(secondHalf).Count();
            //var diff = Math.Max(firstHalf.Except(secondHalf).Count(), secondHalf.Except(firstHalf).Count());

            return diff;
        }
    }
}