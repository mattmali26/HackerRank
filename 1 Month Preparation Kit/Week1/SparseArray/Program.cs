using System;
using System.Collections.Generic;
using System.Linq;

namespace SparseArray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int stringsCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> strings = new List<string>();

            for (int i = 0; i < stringsCount; i++)
            {
                string stringsItem = Console.ReadLine();
                strings.Add(stringsItem);
            }

            int queriesCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> queries = new List<string>();

            for (int i = 0; i < queriesCount; i++)
            {
                string queriesItem = Console.ReadLine();
                queries.Add(queriesItem);
            }

            List<int> res = Result.MatchingStrings(strings, queries);

            Console.WriteLine(String.Join("\n", res));

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'matchingStrings' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. STRING_ARRAY strings
         *  2. STRING_ARRAY queries
         */

        public static List<int> MatchingStrings(List<string> strings, List<string> queries)
        {
            var result = new List<int>(queries.Count);
            for (int i = 0; i < queries.Count; i++)
            {
                result.Add(strings.Where(s => s.Equals(queries[i])).Count());
            }

            return result;
        }
    }
}