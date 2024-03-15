using Core.Entity;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(SpriteRenderer))]
public class StarNode : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public LineRenderer[] orbits;
    public Star Data;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("[StarNode] Begin system drawing");
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.yellow;

        var texture = Resources.Load<Texture2D>("Circle");
        var sprite = Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f),
            256
            );
        sprite.name = "Star";
        spriteRenderer.sprite = sprite;

        gameObject.transform.localScale = new Vector3(2, 2);
        
        if (Data.Sattelites != null)
        {
            orbits = new LineRenderer[Data.Sattelites.Length];
            AppendSattelites();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void AppendSattelites()
    {
        var sattelites = Data.Sattelites;
        if (sattelites == null)
        {
            return;
        }

        int index = 0;
        foreach (var sattelite in sattelites)
        {
            switch (sattelite)
            {
                case Planet planet:
                    AppendPlanet(planet, index);
                    break;
                default:
                    break;
            }

            index += 1;
        }
    }

    private void AppendPlanet(Planet planet, int index)
    {
        var newPlanet = new GameObject
        {
            name = "Planet"
        };
        newPlanet.transform.SetParent(gameObject.transform);
                    
        var planetNode = newPlanet.AddComponent<PlanetNode>();
        planetNode.Planet = planet;
        planetNode.index = index;
        
        var orbit = new GameObject();
        orbit.transform.SetParent(gameObject.transform);
        orbit.name = "Orbit " + index.ToString();
        var orbitNode = orbit.AddComponent<OrbitNode>();
        orbitNode.radius = (index + 1) * 10f;
    }
}