using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FindTheMedian
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            int result = Result.FindMedian(arr);

            Console.WriteLine(result);
        }
    }

    class Result
    {

        /*
         * Complete the 'findMedian' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static int FindMedian(List<int> arr)
        {
            arr.Sort();
            var index = arr.Count / 2;
            return arr[index];
        }
    }
}
