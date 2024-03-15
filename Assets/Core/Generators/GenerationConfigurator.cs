using System;
using System.Collections.Generic;
using Core.Entity;

namespace Core.Generators
{
    [Serializable]
    public class StarSystemConfiguration
    {
        [NonSerialized]
        public float DefaultPlanetProbability;

        public Dictionary<string, SpectralClassConfiguration> spectralClassConfiguration;

        public Dictionary<Star.ESpectralClass, SpectralClassConfiguration> GetSpectralClassConfiguration()
        {
            var configuration = new Dictionary<Star.ESpectralClass, SpectralClassConfiguration>();
            foreach (var className in spectralClassConfiguration.Keys)
            {
                Star.ESpectralClass spectralClass;
                switch (className)
                {
                    case "classO":
                        spectralClass = Star.ESpectralClass.ClassO;
                        break;
                    case "classB":
                        spectralClass = Star.ESpectralClass.ClassB;
                        break;
                    case "classA":
                        spectralClass = Star.ESpectralClass.ClassA;
                        break;
                    case "classF":
                        spectralClass = Star.ESpectralClass.ClassF;
                        break;
                    case "classG":
                        spectralClass = Star.ESpectralClass.ClassG;
                        break;
                    case "classK":
                        spectralClass = Star.ESpectralClass.ClassK;
                        break;
                    case "classM":
                        spectralClass = Star.ESpectralClass.ClassM;
                        break;
                    default:
                        throw new Exception();
                }

                configuration[spectralClass] = spectralClassConfiguration[className];
            }
            return configuration;
        }
    }

    [Serializable]
    public class SpectralClassConfiguration
    {
        public int percent;

        public int defaultPlanetProbability;
    }
    
    public class GenerationConfigurator
    {
        public StarSystemConfiguration GetStarSystemConfiguration()
        {
            return new StarSystemConfiguration();
        }
    }
}