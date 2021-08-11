using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicArray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int q = Convert.ToInt32(firstMultipleInput[1]);

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }

            List<int> result = Result.DynamicArray(n, queries);

            Console.WriteLine(String.Join("\n", result));
        }
    }

    internal class Result
    {
        /*
         * Complete the 'dynamicArray' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. 2D_INTEGER_ARRAY queries
         */

        public static List<int> DynamicArray(int n, List<List<int>> queries)
        {
            var array = new List<int>[n];
            var lastAnswerArray = new List<int>();
            var lastAnswer = 0;

            foreach (var query in queries)
            {
                var idx = (query[1] ^ lastAnswer) % n;
                if (array[idx] == null)
                {
                    array[idx] = new List<int>();
                }
                if (query.FirstOrDefault().Equals(1))
                {
                    array[idx].Add(query.LastOrDefault());
                }
                if (query.FirstOrDefault().Equals(2))
                {
                    lastAnswer = array[idx][query.LastOrDefault() % array[idx].Count];
                    lastAnswerArray.Add(lastAnswer);
                }
            }

            return lastAnswerArray;
        }
    }
}