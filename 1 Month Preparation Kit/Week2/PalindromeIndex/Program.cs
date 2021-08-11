using System;
using System.Linq;

namespace PalindromeIndex
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var s = "aaab";

            //for (int i = 0; i < 10 * 10000; i++)
            //{
            //    s += "a";
            //    //if (i == 10 * 10000 / 2 - 1)
            //    //{
            //    //    s += "dc";
            //    //}
            //    //else
            //    //{
            //    //    if (i == 10 * 10000 / 2)
            //    //    {
            //    //    }
            //    //    else
            //    //    {
            //    //        s += "a";
            //    //    }
            //    //}
            //}
            //s += "b";
            int result = Result.PalindromeIndex(s);
            Console.WriteLine(result);

            //int q = Convert.ToInt32(Console.ReadLine().Trim());

            //for (int qItr = 0; qItr < q; qItr++)
            //{
            //    string s = Console.ReadLine();

            //    int result = Result.PalindromeIndex(s);

            //    Console.WriteLine(result);
            //}

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'palindromeIndex' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts STRING s as parameter.
         */

        public static int PalindromeIndex(string s)
        {
            if (s.Equals(string.Concat(s.Reverse())))
            {
                return -1;
            }

            var half = s.Length / 2;
            var firstHalfString = s.Substring(0, half);
            var secondHalfString = s.Substring(s.Length - half, half);

            var diff1 = firstHalfString.Except(secondHalfString);
            var diff2 = secondHalfString.Except(firstHalfString);
            var diff = Math.Max(diff1.Count(), diff2.Count());
            if (diff > 1)
            {
                return -1;
            }

            int forwardIndex = 0;
            int backwardIndex = s.Length - 1;
            while (forwardIndex < s.Length)
            {
                if (s[forwardIndex] != s[backwardIndex])
                {
                    break;
                }
                forwardIndex++;
                backwardIndex--;
            }

            int forwardIndex2 = forwardIndex + 1;
            int backwardIndex2 = backwardIndex;
            while (forwardIndex2 < backwardIndex && backwardIndex2 > forwardIndex + 1)
            {
                if (s[forwardIndex2] != s[backwardIndex2])
                {
                    return backwardIndex;
                }
                forwardIndex2++;
                backwardIndex2--;
            }

            return forwardIndex;
        }

        public static int PalindromeIndex_Solution2(string s)
        {
            int palindromeIndex = -1;
            int len = s.Length;

            for (int i = 0; i < len / 2; i++)
            {
                if (s[i] != s[len - i - 1])
                {
                    if (i + 1 < len)
                    {
                        //var isRightStringValidPalindrome = isValidPalindrome(s.Substring(i + 1, (len - i) - (i + 1)));
                        var isRightStringValidPalindrome = isValidPalindrome(s[(i + 1)..(len - i)]);
                        if (isRightStringValidPalindrome)
                        {
                            return i;
                        }

                        return len - i - 1;
                    }
                }
            }

            return palindromeIndex;
        }

        private static bool isValidPalindrome(string str)
        {
            int length = str.Length;

            for (int i = 0; i < length / 2; i++)
            {
                if (str[i] != str[length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }

    //3       q = 3
    //aaab s = 'aaab'(first query)
    //baa s = 'baa'(second query)
    //aaa s = 'aaa'(third query)
}