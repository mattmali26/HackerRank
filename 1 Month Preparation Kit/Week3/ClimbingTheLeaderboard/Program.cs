﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ClimbingTheLeaderboard
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string r = "100 100 50 40 40 20 10";
            string p = "5 25 50 120";

            List<int> ranked = r.Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();
            List<int> player = p.Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

            //int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

            //List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

            //int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

            //List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

            List<int> result = Result.ClimbingLeaderboard(ranked, player);

            Console.WriteLine(String.Join("\n", result));

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'climbingLeaderboard' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY ranked
         *  2. INTEGER_ARRAY player
         */

        public static List<int> ClimbingLeaderboard(List<int> ranked, List<int> player)
        {
            var newRanked = ranked.Distinct().ToList();

            var result = new List<int>();

            for (int i = 0; i < player.Count; i++)
            {
                //while (newRanked.Count > 0 && player[i] >= newRanked[newRanked.Count - 1])
                while (newRanked.Count > 0 && player[i] >= newRanked[^1])
                {
                    newRanked.RemoveAt(newRanked.Count - 1);
                }
                result.Add(newRanked.Count + 1);
            }

            return result;
        }

        public static List<int> ClimbingLeaderboard_FirstSolution_NotOptimized(List<int> ranked, List<int> player)
        {
            var newRanked = ranked.Distinct().ToList();

            var result = new List<int>();

            for (int i = 0; i < player.Count; i++)
            {
                var rank = newRanked.Where(x => x >= player[i]).OrderBy(x => x).FirstOrDefault();
                var index = newRanked.FindIndex(x => x.Equals(rank));
                if (rank.Equals(-1))
                {
                    result.Add(1);
                }
                else
                {
                    if (player[i].Equals(rank))
                    {
                        result.Add(index + 1);
                    }
                    else
                    {
                        result.Add(index + 2);
                    }
                }
            }

            return result;
        }
    }
}