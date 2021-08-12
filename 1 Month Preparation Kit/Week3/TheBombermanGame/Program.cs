using System;
using System.Collections.Generic;
using System.Linq;

namespace TheBombermanGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int r = Convert.ToInt32(firstMultipleInput[0]);

            int c = Convert.ToInt32(firstMultipleInput[1]);

            int n = Convert.ToInt32(firstMultipleInput[2]);

            List<string> grid = new List<string>();

            for (int i = 0; i < r; i++)
            {
                string gridItem = Console.ReadLine();
                grid.Add(gridItem);
            }

            List<string> result = Result.BomberMan(n, grid);

            Console.WriteLine(String.Join("\n", result));

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'bomberMan' function below.
         *
         * The function is expected to return a STRING_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. STRING_ARRAY grid
         */

        public static List<string> BomberMan(int n, List<string> grid)
        {
            if (n.Equals(1))
            {
                return grid;
            }

            if (n % 2 == 0)
            {
                return grid.Select(row => string.Concat(Enumerable.Repeat("O", row.Length))).ToList();
            }

            if (n > 6)
            {
                n = ((n - 3) % 4) + 3;
            }

            var seconds = 1;
            var rows = grid.Count;
            for (int row = 0; row < rows; row++)
            {
                grid[row] = grid[row].Replace("O", "1");
            }

            // 2s -> bombs
            // 3s -> explode bombs 0s
            // 4s -> bombs
            // 5s -> explode bombs 2s
            // 6s -> bombs
            // 7s -> explode bombs 4s
            // 8s -> bombs
            // 9s -> explode bombs 6s

            while (seconds < n)
            {
                seconds++;
                if (seconds % 2 == 0)
                {
                    for (int row = 0; row < rows; row++)
                    {
                        grid[row] = grid[row].Replace("2", "3").Replace("1", "2").Replace("O", "1").Replace(".", "O");
                    }
                }
                else
                {
                    for (int row = 0; row < rows; row++)
                    {
                        grid[row] = grid[row].Replace("2", "3").Replace("1", "2").Replace("O", "1");
                    }
                    grid = ExplodeBombs(grid);
                }
            }

            for (int row = 0; row < rows; row++)
            {
                grid[row] = grid[row].Replace("3", "O").Replace("2", "O").Replace("1", "O");
            }
            return grid;
        }

        private static List<string> ExplodeBombs(List<string> grid)
        {
            var array = grid.Select(a => a.ToArray()).ToList();

            for (int row = 0; row < grid.Count; row++)
            {
                while (true)
                {
                    var index = Array.FindIndex(array[row], col => col.Equals('3'));
                    if (index.Equals(-1))
                    {
                        break;
                    }

                    array[row][index] = '.';
                    if (row > 0)
                    {
                        array[row - 1][index] = '.';
                    }
                    if (row < grid.Count - 1)
                    {
                        if (array[row + 1][index] != '3')
                        {
                            array[row + 1][index] = '.';
                        }
                    }
                    if (index > 0)
                    {
                        array[row][index - 1] = '.';
                    }
                    if (index < grid[0].Length - 1)
                    {
                        if (array[row][index + 1] != '3')
                        {
                            array[row][index + 1] = '.';
                        }
                    }
                }
            }

            var resultGrid = array.Select(row => string.Concat(row)).ToList();
            return resultGrid;
        }
    }
}