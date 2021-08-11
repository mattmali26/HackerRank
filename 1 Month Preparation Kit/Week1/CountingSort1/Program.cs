using System;
using System.Collections.Generic;
using System.Linq;

namespace CountingSort1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> result = Result.CountingSort(arr);

            Console.WriteLine(String.Join(" ", result));

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'countingSort' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static List<int> CountingSort(List<int> arr)
        {
            //var max = arr.Max();
            var result = new int[100];

            for (int i = 0; i < arr.Count; i++)
            {
                result[arr[i]]++;
            }

            return result.ToList();
        }
    }
}