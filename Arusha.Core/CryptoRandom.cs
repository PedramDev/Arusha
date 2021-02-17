using System;
using System.Linq;
using System.Security.Cryptography;

namespace Arusha.Core
{
    public class CryptoRandom
    {
        public static string GenerateString(int length, string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
        {
            var bytes = new byte[length];

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(bytes);
            }

            return new string(bytes.Select(x => characters[x % characters.Length]).ToArray());
        }

        public static int Next(int minValue = 0, int maxValue = int.MaxValue)
        {
            return (int)Math.Round(NextDouble() * (maxValue - minValue - 1)) + minValue;
        }

        public static double NextDouble()
        {
            byte[] bytes = new byte[4];

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(bytes);
            }

            return (double)BitConverter.ToUInt32(bytes, 0) / uint.MaxValue;
        }
    }
}
