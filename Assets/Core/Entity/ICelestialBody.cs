using System;
using JetBrains.Annotations;

namespace Core.Entity
{
    public interface ICelestialBody
    {
        [CanBeNull] public WeakReference<ICelestialBody> Barycenter { get; }

        [CanBeNull] public ICelestialBody[] Sattelites { get; }
    }
}