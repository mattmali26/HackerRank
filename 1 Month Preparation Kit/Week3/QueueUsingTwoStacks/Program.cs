using System;
using System.Collections.Generic;
using System.Linq;

namespace QueueUsingTwoStacks
{
    internal class Program
    {
        private class Query
        {
            public int Type { get; set; }
            public int? ValueToEnqueue { get; set; }

            public Query(int type)
            {
                Type = type;
                ValueToEnqueue = null;
            }

            public Query(int type, int valueToEnqueue)
            {
                Type = type;
                ValueToEnqueue = valueToEnqueue;
            }
        }

        private static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine().Trim());

            var queryList = new List<Query>();

            for (int tItr = 0; tItr < q; tItr++)
            {
                List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
                queryList.Add(arr.Count.Equals(2) ? new Query(arr[0], arr[1]) : new Query(arr[0]));
            }

            QueueUsingTwoStacks(queryList);

            Console.ReadLine();
        }

        private static void QueueUsingTwoStacks(List<Query> queryList)
        {
            var queue = new List<int>();
            foreach (var query in queryList)
            {
                switch (query.Type)
                {
                    case 1:
                        queue.Add(query.ValueToEnqueue.Value);
                        break;

                    case 2:
                        queue.RemoveAt(0);
                        break;

                    case 3:
                        Console.WriteLine(queue.FirstOrDefault());
                        break;
                }
            }
        }
    }
}