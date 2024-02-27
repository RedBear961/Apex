using System;
using UnityEngine;

namespace Core.Entity
{
    public class Star : ICelestialBody
    {
        // MARK: - ICelestialBody
    
        public WeakReference<ICelestialBody> Barycenter { get; internal set; }
    
        public ICelestialBody[] Sattelites { get; internal set; }
        
        // MARK: - INode
        
        public void ApplyBehavior(GameObject gameObject)
        {
            var node = gameObject.AddComponent<StarNode>();
            node.data = this;
        }
    
        // MARK: - Public
    
        public enum ESpectralClass
        {
            ClassO,
            ClassB,
            ClassA,
            ClassF,
            ClassG,
            ClassK,
            ClassM
        }

        public ESpectralClass SpectralClass { get; internal set; }
    }
}