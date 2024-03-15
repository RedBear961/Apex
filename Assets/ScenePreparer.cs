using System;
using Core.Entity;
using Core.Generators;
using Unity.VisualScripting;
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
        var starData = starSystem.Center as Star;

        var star = new GameObject();
        star.name = "Star";
        var starNode = star.AddComponent<StarNode>();
        starNode.Data = starData;
    }
}