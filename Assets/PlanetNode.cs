using System;
using Core.Entity;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class PlanetNode : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Planet Planet;
    public int index;

    private void Awake()
    {
        var collider = gameObject.AddComponent<BoxCollider2D>();
        collider.size = Vector2.one;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("[StarNode] Begin planet drawing at index " + index.ToString());

        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        
        var texture = Resources.Load<Texture2D>("Circle");
        var sprite = Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f),
            256
        );
        
        sprite.name = "Planet " + index.ToString();
        spriteRenderer.sprite = sprite;
        
        var position = Random.Range(0, 2) == 0 ? 1 : -1;
        gameObject.transform.position = new Vector3((index + 1) * 10 * position, 0);
    }

    void OnMouseDown()
    {
        Debug.Log("Mouse down");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}