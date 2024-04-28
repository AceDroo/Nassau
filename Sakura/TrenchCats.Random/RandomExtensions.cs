using TrenchCats.Core;

namespace TrenchCats.Random;

public static class RandomExtensions
{
    public static int Next(this System.Random random, RangedInt rangedInt)
    {
        return random.Next(rangedInt.Min, rangedInt.Max);
    }

    public static T Choose<T>(this System.Random random, T[] array)
    {
        return array[random.Next(0, array.Length)];
    }
}