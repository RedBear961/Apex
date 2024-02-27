using System;
using Core.Entity;
using Core.Generators;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePreparer : MonoBehaviour
{
    // #if DEBUG
    private DebugGenerator _generator = new DebugGenerator();
    // #endif
    
    private void Awake()
    {
        // var scene = SceneManager.GetActiveScene();

        // var starSystem = _generator.GetStarSystem();
        // Debug.Log(starSystem != null);
        //
        // var star = new GameObject();
        // star.AddComponent<StarNode>();
    }

    private void Start()
    {
        var starSystem = _generator.GetStarSystem();
        
        var star = new GameObject();
        star.AddComponent<StarNode>();
    }
}