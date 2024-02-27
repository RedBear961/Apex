using System.Linq;
using System.Threading;
using Core.Entity;
using Core.Generators;
using JetBrains.Annotations;
using UnityEngine;

// #if DEBUG

public class DebugGenerator : IGalaxyGeneratorDelegate
{
    private GalaxyGenerator _galaxyGenerator;
    private Semaphore _semaphore;

    [CanBeNull] private Galaxy _galaxy;
    
    public DebugGenerator()
    {
        this._galaxyGenerator = new GalaxyGenerator(this);
        this._semaphore = new Semaphore(0, 1);
    }

    public StarSystem GetStarSystem()
    {
        // _galaxyGenerator.Begin();
        // _semaphore.WaitOne();
        var galaxy = _galaxyGenerator.DebugGenerate();
        // _galaxy = null;
        // return galaxy!.StarSystems.First();
        Debug.Log("[DebugGenerator] End debug galaxy generation");
        return galaxy.StarSystems.First();
    } 
    
    // MARK: - IGalaxyGeneratorDelegate

    public void OnComplete(Galaxy galaxy)
    {
        _galaxy = galaxy;
        _semaphore.Release();
    }

    public void OnFailed(GeneratorError error)
    {
        throw new System.NotImplementedException();
    }
}

// #endif