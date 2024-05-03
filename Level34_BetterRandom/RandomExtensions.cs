using System.Runtime.CompilerServices;

namespace Level34_BetterRandom {
    internal static class RandomExtensions {
        public static double NextDouble(this Random random, int maxValue) {
            return random.NextDouble() * maxValue;
        }

        public static String NextString(this Random random, params string[] strings) {
            return strings[random.Next(strings.Length)];    
        }

        public static bool CoinFlip(this Random random, double frequencyHeads = 0.5) {
            return random.NextDouble() < frequencyHeads;
        }
    }
}
