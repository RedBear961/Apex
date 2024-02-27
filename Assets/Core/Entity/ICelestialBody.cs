using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Core.Entity
{
    public interface INode
    {
        public void ApplyBehavior(GameObject gameObject);
    }

    public interface ICelestialObject : INode
    {
        [CanBeNull] public ICelestialBody Center { get; }
    }

    public interface ICelestialBody : INode
    {
        [CanBeNull] public WeakReference<ICelestialBody> Barycenter { get; }

        [CanBeNull] public ICelestialBody[] Sattelites { get; }
    }
}