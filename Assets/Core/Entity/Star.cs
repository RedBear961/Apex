using System;

namespace Core.Entity
{
    public class Star : ICelestialBody
    {
        // MARK: - ICelestialBody
    
        public WeakReference<ICelestialBody> Barycenter { get; set; }
    
        public ICelestialBody[] Sattelites { get; }
    
        // MARK: - Public
    
        public enum ESpectralClass
        {
        
        }

        public ESpectralClass SpectralClass;
    }
}