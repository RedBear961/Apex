using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Common
{
    public class RandomDistribution<T>
    {
        private readonly Random _random;
        private readonly T[] _distribution;
        private readonly int _count;

        public RandomDistribution(Dictionary<T, int> values)
        {
            var distribution = new List<T>();
            foreach (var key in values.Keys)
            {
                var percent = values[key];
                for (var i = 0; i < percent; ++i)
                {
                    distribution.Add(key);
                }
            }

            this._random = new Random();
            this._distribution = distribution.ToArray();
            this._count = distribution.Count;
        }

        public T Next()
        {
            var index = _random.Next(0, _count);
            return _distribution[index];
        }
    }
}