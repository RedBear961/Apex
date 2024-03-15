using System;
using System.Collections.Generic;
using Core.Common;
using Core.Entity;
using JetBrains.Annotations;
using UnityEngine;
using Random = System.Random;

using ESpectralClass = Core.Entity.Star.ESpectralClass;

namespace Core.Generators
{
    public class StarSystemGenerator
    {
        private StarSystemConfiguration _configuration;
        private Dictionary<ESpectralClass, SpectralClassConfiguration> _spectralClassConfiguration;
        
        private RandomDistribution<ESpectralClass> _spectralDistribution;
        private readonly Random _random;

        public StarSystemGenerator(StarSystemConfiguration configuration)
        {
            var values = new Dictionary<ESpectralClass, int>();
            
            this._configuration = configuration;
            this._spectralClassConfiguration = configuration.GetSpectralClassConfiguration();
            this._spectralDistribution = new RandomDistribution<ESpectralClass>(values);
            this._random = new Random();
        }
    
        public StarSystem Generate()
        {
            var star = new Star();
            
            var spectralClass = _spectralDistribution.Next();
            var configuration = _spectralClassConfiguration[spectralClass];
            var planets = GeneratePlanetSystem(configuration.defaultPlanetProbability, star);
            
            star.SpectralClass = spectralClass;
            star.Sattelites = planets;
            
            return new StarSystem(star);
        }

        private Planet[] GeneratePlanetSystem(int probability, ICelestialBody barycenter)
        {
            int index = 0;
            List<Planet> planets = new List<Planet>();
            while (probability > 0)
            {
                var planet = NextPlanet(probability, index, barycenter);
                if (planet == null)
                {
                    break;
                }

                planets.Add(planet);
                index += 1;

                if (index > 2)
                {
                    probability -= 10;
                }
            }

            return planets.ToArray();
        }

        [CanBeNull]
        private Planet NextPlanet(int probability, int index, ICelestialBody barycenter)
        {
            var chance = _random.Next(0, 100);
            if (probability < chance)
            {
                return null;
            }
            
            var planet = new Planet();
            planet.Barycenter = new Weak<ICelestialBody>(barycenter);
            return planet;
        }
    }
}