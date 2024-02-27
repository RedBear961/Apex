using System;
using UnityEngine;

namespace Core.Entity
{
    public class StarSystem : ICelestialObject
    {
        // MARK: - ICelestialObject
        
        public ICelestialBody Center { get; set; }

        // MARK: - INode
        
        public void ApplyBehavior(GameObject gameObject)
        {
            throw new NotImplementedException();
        }
        
        public StarSystem(ICelestialBody center)
        {
            this.Center = center;
        }
    }
}