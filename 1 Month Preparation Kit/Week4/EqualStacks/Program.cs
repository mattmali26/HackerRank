using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualStacks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n1 = Convert.ToInt32(firstMultipleInput[0]);

            int n2 = Convert.ToInt32(firstMultipleInput[1]);

            int n3 = Convert.ToInt32(firstMultipleInput[2]);

            List<int> h1 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(h1Temp => Convert.ToInt32(h1Temp)).ToList();

            List<int> h2 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(h2Temp => Convert.ToInt32(h2Temp)).ToList();

            List<int> h3 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(h3Temp => Convert.ToInt32(h3Temp)).ToList();

            int result = Result.EqualStacks(h1, h2, h3);

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'equalStacks' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY h1
         *  2. INTEGER_ARRAY h2
         *  3. INTEGER_ARRAY h3
         */

        public static int EqualStacks(List<int> h1, List<int> h2, List<int> h3)
        {
            if (h1.Count.Equals(0) || h2.Count.Equals(0) || h3.Count.Equals(0))
            {
                return 0;
            }

            var h1Sum = h1.Sum();
            var h2Sum = h2.Sum();
            var h3Sum = h3.Sum();

            if (h1Sum == h2Sum && h1Sum == h3Sum)
            {
                return h1Sum;
            }

            var stack1 = new Stack<int>();
            var stack2 = new Stack<int>();
            var stack3 = new Stack<int>();

            for (int i = h1.Count - 1; i >= 0; i--)
            {
                if (stack1.Count.Equals(0))
                {
                    stack1.Push(h1[i]);
                }
                else
                {
                    stack1.Push(h1[i] + stack1.Peek());
                }
            }
            for (int i = h2.Count - 1; i >= 0; i--)
            {
                if (stack2.Count.Equals(0))
                {
                    stack2.Push(h2[i]);
                }
                else
                {
                    stack2.Push(h2[i] + stack2.Peek());
                }
            }
            for (int i = h3.Count - 1; i >= 0; i--)
            {
                if (stack3.Count.Equals(0))
                {
                    stack3.Push(h3[i]);
                }
                else
                {
                    stack3.Push(h3[i] + stack3.Peek());
                }
            }

            while (!stack1.Count.Equals(0) && !stack2.Count.Equals(0) && !stack3.Count.Equals(0))
            {
                var stackHeight1 = stack1.Peek();
                var stackHeight2 = stack2.Peek();
                var stackHeight3 = stack3.Peek();

                if (stackHeight1.Equals(stackHeight2) && stackHeight1.Equals(stackHeight3))
                {
                    return stackHeight1;
                }

                if (stackHeight1 > stackHeight2 || stackHeight1 > stackHeight3)
                {
                    stack1.Pop();
                }

                if (stackHeight2 > stackHeight1 || stackHeight2 > stackHeight3)
                {
                    stack2.Pop();
                }

                if (stackHeight3 > stackHeight1 || stackHeight3 > stackHeight2)
                {
                    stack3.Pop();
                }
            }

            return 0;
        }
    }
}