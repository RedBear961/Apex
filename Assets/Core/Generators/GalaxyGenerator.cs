using System.Threading.Tasks;
using Core.Common;
using Core.Entity;
using JetBrains.Annotations;
using UnityEngine;

namespace Core.Generators
{
    public struct GeneratorError
    {
        
    }

    public interface IGalaxyGeneratorDelegate
    {
        public void OnComplete(Galaxy galaxy);
        
        public void OnFailed(GeneratorError error);
    }

    public class GalaxyGenerator
    {
        private readonly GenerationConfigurator _configurator;
        private Weak<IGalaxyGeneratorDelegate> _delegate;
        private StarSystemGenerator _starSystemGenerator;

        public GalaxyGenerator([CanBeNull] IGalaxyGeneratorDelegate generatorDelegate)
        {
            this._configurator = new GenerationConfigurator();
            this._delegate = new Weak<IGalaxyGeneratorDelegate>(generatorDelegate);
            this._starSystemGenerator = new StarSystemGenerator(_configurator.GetStarSystemConfiguration());
        }

        // MARK: - Public

        public void Begin()
        {
            Task.Run(() =>
            {
                var starSystem = _starSystemGenerator.Generate();
                var galaxy = new Galaxy(new[] {starSystem});
                _delegate.TryValue?.OnComplete(galaxy);
            });
        }

        public Galaxy DebugGenerate()
        {
            Debug.Log("[GalaxyGenerator] Begin debug galaxy generation");
            var starSystem = _starSystemGenerator.Generate();
            var galaxy = new Galaxy(new[] {starSystem});
            return galaxy;
        }
    }
}