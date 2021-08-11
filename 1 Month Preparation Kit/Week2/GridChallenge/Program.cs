using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography;

namespace GridChallenge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());

                List<string> grid = new List<string>();

                for (int i = 0; i < n; i++)
                {
                    string gridItem = Console.ReadLine();
                    grid.Add(gridItem);
                }

                string result = Result.GridChallenge(grid);

                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'gridChallenge' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING_ARRAY grid as parameter.
         */

        public static string GridChallenge(List<string> grid)
        {
            var orderedGrid = new List<string>();

            grid.ForEach(row =>
            {
                orderedGrid.Add(string.Concat(row.OrderBy(c => c)));
            });

            var colsNum = orderedGrid.FirstOrDefault().Length;
            for (int col = 0; col < colsNum; col++)
            {
                var columnString = string.Empty;
                orderedGrid.ForEach(row => columnString += row[col]);
                if (columnString != string.Concat(columnString.OrderBy(c => c)))
                {
                    return "NO";
                }
            }

            return "YES";
        }
    }
}