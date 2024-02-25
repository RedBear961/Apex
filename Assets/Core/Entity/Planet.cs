using System;
using JetBrains.Annotations;

namespace Core.Entity
{
    public class Planet : ICelestialBody
    {
        [NotNull] public WeakReference<ICelestialBody> Barycenter { get; set; }
    
        public ICelestialBody[] Sattelites { get; }
    }
}