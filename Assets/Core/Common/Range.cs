using System;

namespace Core.Common
{
    public struct ClosedRange
    {
        public int Min;
        public int Max;
    }

    public static class IntExtension
    {
        public static int InRange(this Random random, ClosedRange range)
        {
            return random.Next(range.Min, range.Max);
        }
    }
}