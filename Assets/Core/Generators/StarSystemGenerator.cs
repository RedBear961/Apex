using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Core.Common;
using Core.Entity;
using JetBrains.Annotations;
using UnityEditor.PackageManager;
using UnityEngine;
using Random = System.Random;

namespace Core.Generators
{
    public class StarSystemGenerator
    {
        public class Configuration
        {
            public float DefaultPlanetProbability;

            // public static Configuration Default()
            // {
            //     return new Configuration();
            // }
        }

        private Configuration _configuration;
        private readonly Random _random;

        public StarSystemGenerator(Configuration configuration)
        {
            this._configuration = configuration;
            this._random = new Random();
        }
    
        public StarSystem Generate()
        {
            Debug.Log("[StarSystemGenerator] Begin star system generation");
            var star = new Star();
            var values = Enum.GetValues(typeof(Star.ESpectralClass)) as Star.ESpectralClass[];
            if (values == null)
            {
                throw new Exception();
            }
            
            var spectralClass = values[_random.Next(0, values.Length)];
            star.SpectralClass = spectralClass;

            float probability = 0.8f;
            var planets = GeneratePlanetSystem(probability, star);
            star.Sattelites = planets;
            
            return new StarSystem(star);
        }

        private Planet[] GeneratePlanetSystem(float probability, ICelestialBody barycenter)
        {
            Debug.Log("[StarSystemGenerator] Begin planet system generation");
            
            var intProbability = Convert.ToInt32(probability * 100);
            int index = 0;
            List<Planet> planets = new List<Planet>();
            while (intProbability > 0)
            {
                var planet = NextPlanet(intProbability, index, barycenter);
                if (planet == null)
                {
                    break;
                }

                planets.Add(planet);
                index += 1;

                if (index > 2)
                {
                    intProbability -= 10;
                }
            }

            Debug.Log("[StarSystemGenerator] End planet system generation with " + index.ToString() + " planets");
            return planets.ToArray();
        }

        [CanBeNull]
        private Planet NextPlanet(int probability, int index, ICelestialBody barycenter)
        {
            Debug.Log("[StarSystemGenerator] Begin next planet generation at index " + index.ToString());
            
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