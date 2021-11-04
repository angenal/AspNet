using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;

namespace Common.Utility
{
    public static class RandomUtils
    {
        private static readonly RNGCryptoServiceProvider CryptoRandomProvider = new RNGCryptoServiceProvider();

        public static string AlphaString(int length) => String(length, Char.IsLetter);

        public static string AlphaNumericString(int length) => String(length, Char.IsLetterOrDigit);

        public static string String(int length, Func<char, bool> filter)
        {
            if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length));
            if (filter == null) throw new ArgumentNullException(nameof(filter));

            var chars =
                EnumerableUtils
                    .Init(_ => (char)Integer(32, 126))
                    .Where(filter)
                    .Take(length)
                    .ToArray();

            return new string(chars);
        }

        private static int Integer(int minValue, int maxExclusiveValue)
        {
            Debug.Assert(maxExclusiveValue > minValue);

            var diff = (long)maxExclusiveValue - minValue;
            var upperBound = uint.MaxValue / diff * diff;

            uint ui;
            do
            {
                ui = GetRandomUInt();
            } while (ui >= upperBound);

            return (int)(minValue + (ui % diff));
        }

        private static uint GetRandomUInt()
        {
            var randomBytes = GenerateRandomBytes(sizeof(uint));
            return BitConverter.ToUInt32(randomBytes, 0);
        }

        private static byte[] GenerateRandomBytes(int bytesNumber)
        {
            var buffer = new byte[bytesNumber];
            CryptoRandomProvider.GetBytes(buffer);
            return buffer;
        }
    }

}
