using System.Collections;
using System.Collections.Generic;
using Core.Entity;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class StarNode : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Star data;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Some log");
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.yellow;

        var texture = Resources.Load<Texture2D>("Circle");
        var sprite = Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f),
            256
            );
        sprite.name = "Circle";
        spriteRenderer.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}