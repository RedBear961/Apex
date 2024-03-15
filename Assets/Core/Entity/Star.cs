using System;
using UnityEngine;
using Core.Common;

namespace Core.Entity
{
    public class Star : ICelestialBody
    {
        // MARK: - ICelestialBody
    
        public Weak<ICelestialBody> Barycenter { get; internal set; }
    
        public ICelestialBody[] Sattelites { get; internal set; }
        
        // MARK: - INode
        
        public void ApplyBehavior(GameObject gameObject)
        {
            var node = gameObject.AddComponent<StarNode>();
            node.Data = this;
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