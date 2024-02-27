using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private const float Speed = 15.0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(Speed * Time.deltaTime,0,0));
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-Speed * Time.deltaTime,0,0));
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0,-Speed * Time.deltaTime,0));
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0,Speed * Time.deltaTime,0));
        }
        
        var camera = gameObject.GetComponent<Camera>();
        var movement = Input.GetAxis("Mouse ScrollWheel");
        var cameraTransform = Time.deltaTime * 300;
        if (movement > 0.1)
        {
            camera.orthographicSize -= cameraTransform;
        }
        else if (movement < -0.1)
        {
            camera.orthographicSize += cameraTransform;
        }
    }
}
