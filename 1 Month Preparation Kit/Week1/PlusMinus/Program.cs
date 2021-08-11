using System;
using System.Collections.Generic;
using System.Linq;

namespace PlusMinus
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            Result.PlusMinus(arr);

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'plusMinus' function below.
         *
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static void PlusMinus(List<int> arr)
        {
            int positive = 0, negative = 0, zero = 0;

            foreach (var item in arr)
            {
                if (item.Equals(0))
                {
                    zero++;
                }
                else
                {
                    if (item > 0)
                    {
                        positive++;
                    }
                    else
                    {
                        negative++;
                    }
                }
            }

            int count = arr.Count();

            Console.WriteLine(string.Format("{0:0.000000}", decimal.Divide(positive, count)));
            Console.WriteLine(string.Format("{0:0.000000}", decimal.Divide(negative, count)));
            Console.WriteLine(string.Format("{0:0.000000}", decimal.Divide(zero, count)));
        }
    }
}