using System;
using System.Linq;

namespace Pangrams
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string s = Console.ReadLine();

            string result = Result.Pangrams(s);

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'pangrams' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         */

        public static string Pangrams(string s)
        {
            char[] alphabet = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();

            foreach (var letter in alphabet)
            {
                if (!s.Contains(letter, StringComparison.OrdinalIgnoreCase))
                {
                    return "not pangram";
                }
            }

            return "pangram";
        }

        public static string Pangrams_MonoVersion(string s)
        {
            char[] alphabet = Enumerable.Range('a', 26).Select(x => (char)x).ToArray();
            s = s.ToLowerInvariant();

            foreach (var letter in alphabet)
            {
                if (!s.Contains(letter))
                {
                    return "not pangram";
                }
            }

            return "pangram";
        }
    }
}