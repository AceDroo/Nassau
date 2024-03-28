using Sakura.Core;

namespace Sakura.Extensions;

public static class RandomExtensions
{
    public static int Next(this Random random, RangedInt rangedInt)
    {
        return random.Next(rangedInt.Min, rangedInt.Max);
    }

    public static T Choose<T>(this Random random, T[] array)
    {
        return array[random.Next(0, array.Length)];
    }
}