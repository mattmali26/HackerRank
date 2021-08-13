using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedBrackets
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string s = Console.ReadLine();

                string result = Result.IsBalanced(s);

                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'isBalanced' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         */

        public static string IsBalanced(string s)
        {
            var openBrackets = new List<char> { '{', '[', '(' };
            var closeBrackets = new List<char> { '}', ']', ')' };
            var alreadyOpenBrackets = new List<char>();

            foreach (var symbol in s)
            {
                if (closeBrackets.Contains(symbol))
                {
                    if (alreadyOpenBrackets.Count.Equals(0))
                    {
                        return "NO";
                    }
                    if (closeBrackets.FindIndex(x => x.Equals(symbol)) == openBrackets.FindIndex(x => x.Equals(alreadyOpenBrackets.FirstOrDefault())))
                    {
                        alreadyOpenBrackets.RemoveAt(0);
                    }
                    else
                    {
                        return "NO";
                    }
                }
                else
                {
                    alreadyOpenBrackets.Insert(0, symbol);
                }
            }

            if (alreadyOpenBrackets.Count != 0)
            {
                return "NO";
            }
            return "YES";
        }
    }
}