using System;

namespace FlippingBits
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine().Trim());

            for (int qItr = 0; qItr < q; qItr++)
            {
                long n = Convert.ToInt64(Console.ReadLine().Trim());

                long result = Result.FlippingBits(n);

                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'flippingBits' function below.
         *
         * The function is expected to return a LONG_INTEGER.
         * The function accepts LONG_INTEGER n as parameter.
         */

        public static long FlippingBits(long n)
        {
            var binaryString = Convert.ToString(n, 2).PadLeft(32, '0');
            string binaryXor = string.Empty;
            foreach (var bit in binaryString)
            {
                binaryXor += Convert.ToInt32(!Convert.ToBoolean(Char.GetNumericValue(bit))).ToString();
            }

            return Convert.ToInt64(binaryXor, 2);
        }
    }
}