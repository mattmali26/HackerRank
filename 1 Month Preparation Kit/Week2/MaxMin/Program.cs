using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxMin
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int k = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int arrItem = Convert.ToInt32(Console.ReadLine().Trim());
                arr.Add(arrItem);
            }

            int result = Result.MaxMin(k, arr);

            Console.WriteLine(result);
        }
    }

    internal class Result
    {
        /*
         * Complete the 'maxMin' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER k
         *  2. INTEGER_ARRAY arr
         */

        public static int MaxMin(int k, List<int> arr)
        {
            if (k == arr.Count)
            {
                return arr.Max() - arr.Min();
            }

            arr.Sort();
            var unfairnessSum = 0;
            var sumList = new List<int>();
            var val = 1 - k;

            sumList.Add(arr[0]);
            for (int i = 1; i < arr.Count; i++)
            {
                sumList.Add(sumList[i - 1] + arr[i]);
            }

            for (int i = 0; i < k; i++)
            {
                unfairnessSum += val * arr[i];
                val += 2;
            }

            var finalUnfainerssSum = unfairnessSum;
            for (int i = k; i < arr.Count; i++)
            {
                var newUnfairnessSum = unfairnessSum + (k - 1) * arr[i] + (k - 1) * arr[i - k] - 2 * (sumList[i - 1] - sumList[i - k]);
                finalUnfainerssSum = Math.Min(newUnfairnessSum, finalUnfainerssSum);
                unfairnessSum = newUnfairnessSum;
            }

            //for (int i = 0; i < arr.Count - k + 1; i++)
            //{
            //    var subArray = arr.GetRange(i, k);
            //    var currentUnfairnessSum = subArray.Max() - subArray.Min();
            //    if (unfairnessSum.Equals(-1) || currentUnfairnessSum < unfairnessSum)
            //    {
            //        unfairnessSum = currentUnfairnessSum;
            //    }
            //}

            return finalUnfainerssSum;
        }
    }
}