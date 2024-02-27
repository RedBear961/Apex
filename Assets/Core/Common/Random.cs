using System;

namespace Core.Common
{
    public static class RandomExtensions
    {
        public static T Next<T>(this Random random, T[] array)
        {
            return array[random.Next(0, array.Length)];
        }
    }
}