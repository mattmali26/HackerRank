using System;
using System.Collections.Generic;

namespace FlippingTheMatrix
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var matrix = new List<List<int>>
            {
                new List<int> { 112, 42, 83, 119},
                new List<int> {56, 125, 56, 49},
                new List<int> {15, 78, 101, 43},
                new List<int> {62, 98, 114, 108}
            };

            int result = Result.FlippingMatrix(matrix);
            Console.WriteLine(result);

            //int q = Convert.ToInt32(Console.ReadLine().Trim());

            //for (int qItr = 0; qItr < q; qItr++)
            //{
            //    int n = Convert.ToInt32(Console.ReadLine().Trim());

            //    List<List<int>> matrix = new List<List<int>>();

            //    for (int i = 0; i < 2 * n; i++)
            //    {
            //        matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
            //    }

            //    int result = Result.FlippingMatrix(matrix);

            //    Console.WriteLine(result);
            //}

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'flippingMatrix' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY matrix as parameter.
         */

        public static int FlippingMatrix(List<List<int>> matrix)
        {
            int n = matrix.Count / 2;

            int sum = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    int r1 = row;
                    int r2 = matrix.Count - row - 1;
                    int c1 = col;
                    int c2 = matrix.Count - col - 1;

                    sum += Math.Max(Math.Max(matrix[r1][c1], matrix[r1][c2]), Math.Max(matrix[r2][c1], matrix[r2][c2]));
                }
            }

            return sum;
        }
    }
}

//1
//2
//112 42 83 119
//56 125 56 49
//15 78 101 43
//62 98 114 108

//out: 414