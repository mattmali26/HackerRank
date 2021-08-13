using System;
using System.Collections.Generic;
using System.Linq;

namespace IceCreamParlor
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int m = Convert.ToInt32(Console.ReadLine().Trim());

                int n = Convert.ToInt32(Console.ReadLine().Trim());

                List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

                List<int> result = Result.IceCreamParlor(m, arr);

                Console.WriteLine(String.Join(" ", result));
            }

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'icecreamParlor' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER m
         *  2. INTEGER_ARRAY arr
         */

        public static List<int> IceCreamParlor(int m, List<int> arr)
        {
            var newArr = arr.Where(x => x < m).ToList();
            for (int i = 0; i < newArr.Count; i++)
            {
                for (int j = i + 1; j < newArr.Count; j++)
                {
                    if (newArr[i] + newArr[j] == m)
                    {
                        var firstIndex = arr.FindIndex(x => x.Equals(newArr[i])) + 1;
                        var secondIndex = arr.FindIndex(x => x.Equals(newArr[j])) + 1;
                        if (secondIndex.Equals(firstIndex))
                        {
                            secondIndex = arr.FindIndex(firstIndex, x => x.Equals(newArr[j])) + 1;
                        }
                        return new List<int>
                        {
                            firstIndex, secondIndex
                        };
                    }
                }
            }

            return null;
        }
    }
}