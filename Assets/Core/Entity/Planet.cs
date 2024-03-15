using System;
using JetBrains.Annotations;
using UnityEngine;
using Core.Common;

namespace Core.Entity
{
    public class Planet : ICelestialBody
    {
        [NotNull] public Weak<ICelestialBody> Barycenter { get; set; }
    
        public ICelestialBody[] Sattelites { get; }
        
        // MARK: - INode

        public void ApplyBehavior(GameObject gameObject)
        {
            throw new NotImplementedException();
        }
    }
}