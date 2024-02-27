using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Core.Entity
{
    public class Planet : ICelestialBody
    {
        [NotNull] public WeakReference<ICelestialBody> Barycenter { get; set; }
    
        public ICelestialBody[] Sattelites { get; }
        
        // MARK: - INode

        public void ApplyBehavior(GameObject gameObject)
        {
            throw new NotImplementedException();
        }
    }
}