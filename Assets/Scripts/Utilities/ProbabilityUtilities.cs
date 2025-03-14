using System;

namespace AF_Interview.Utilities
{
    public static class ProbabilityUtilities
    {
        private static readonly Random _random = new Random();

        public static bool IsSuccess(float chancePercentage)
        {
            return chancePercentage switch
            {
                <= 0 => false,
                >= 100 => true,
                _ => _random.NextDouble() * 100 < chancePercentage
            };
        }
    }
}
