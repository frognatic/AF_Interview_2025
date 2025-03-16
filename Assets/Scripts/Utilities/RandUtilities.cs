using UnityEngine;

namespace AF_Interview.Utilities
{
    public static class RandUtilities
    {
        private static readonly System.Random _random = new System.Random();

        public static bool CanProceed(float chancePercentage)
        {
            return chancePercentage switch
            {
                <= 0 => false,
                >= 100 => true,
                _ => _random.NextDouble() * 100 < chancePercentage
            };
        }

        public static int GetRandomValueFromRange(Vector2Int range)
        {
            // For Random.Range int maximum parameter is exclusive, so we need to add +1
            return Random.Range(range.x, range.y + 1);
        }
    }
}
