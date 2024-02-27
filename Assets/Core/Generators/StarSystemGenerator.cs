using System;
using Core.Common;
using Core.Entity;
using JetBrains.Annotations;
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

        public StarSystemGenerator(Configuration configuration)
        {
            this._configuration = configuration;
        }
    
        public StarSystem Generate()
        {
            Debug.Log("[StarSystemGenerator] Begin star system generation");
            var random = new Random();
            var star = new Star();
            var values = Enum.GetValues(typeof(Star.ESpectralClass)) as Star.ESpectralClass[];
            var spectralClass = values[random.Next(0, values.Length)];
            star.SpectralClass = spectralClass;
            return new StarSystem(star);
        }

        private Planet[] GeneratePlanetSystem(float probability)
        {
            return new Planet[] { };
        }

        [CanBeNull]
        private Planet NextPlanet(float probability, int index)
        {
            return null;
        }
    }
}