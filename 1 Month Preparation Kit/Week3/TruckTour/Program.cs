using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> petrolpumps = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                petrolpumps.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(petrolpumpsTemp => Convert.ToInt32(petrolpumpsTemp)).ToList());
            }

            int result = Result.TruckTour(petrolpumps);

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'truckTour' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY petrolpumps as parameter.
         */

        public static int TruckTour(List<List<int>> petrolpumps)
        {
            var pump = 0;
            var tank = 0;

            for (int i = 0; i < petrolpumps.Count; i++)
            {
                tank += petrolpumps[i][0] - petrolpumps[i][1];
                // If tank < 0 set pump = next pump
                if (tank < 0)
                {
                    tank = 0;
                    pump = i + 1;
                }
            }

            return pump;
        }
    }
}