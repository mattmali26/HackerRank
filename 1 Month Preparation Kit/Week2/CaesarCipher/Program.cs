using System;

namespace CaesarCipher
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            string s = Console.ReadLine();

            int k = Convert.ToInt32(Console.ReadLine().Trim());

            string result = Result.CaesarCipher(s, k);

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'caesarCipher' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts following parameters:
         *  1. STRING s
         *  2. INTEGER k
         */

        public static string CaesarCipher(string s, int k)
        {
            var encryptedString = string.Empty;
            foreach (var car in s)
            {
                var asciiCode = (int)car;
                if ((asciiCode >= 65 && asciiCode <= 90) || (asciiCode >= 97 && asciiCode <= 122))
                {
                    var actualK = k % 26;
                    var shiftedAscii = asciiCode + actualK;
                    if (asciiCode <= 90)
                    {
                        if (shiftedAscii > 90)
                        {
                            shiftedAscii = 65 + (shiftedAscii - 90) - 1;
                        }
                    }
                    else
                    {
                        if (shiftedAscii > 122)
                        {
                            shiftedAscii = 97 + (shiftedAscii - 122) - 1;
                        }
                    }

                    encryptedString += (char)shiftedAscii;
                }
                else
                {
                    encryptedString += car;
                }
            }

            return encryptedString;
        }
    }
}