using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private static class Const
    {
        internal const float Speed = 60.0f;
        internal const float ScrollSpeed = 1000f;
    }
    
    private Camera _camera;

    private void Awake()
    {
        _camera = gameObject.GetComponent<Camera>();
    }

    private void Update()
    {
        HandleKeyboard();
        HandleScroll();
        HandleMousePosition();
    }

    private void HandleKeyboard()
    {
        var translation = Const.Speed * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(translation,0,0));
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-translation,0,0));
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0,-translation,0));
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0,translation,0));
        }
    }

    private void HandleScroll()
    {
        var movement = Input.GetAxis("Mouse ScrollWheel");
        var translation = Time.deltaTime * Const.ScrollSpeed;
        if (movement > 0.1)
        {
            _camera.orthographicSize -= translation;
        }
        else if (movement < -0.1)
        {
            _camera.orthographicSize += translation;
        }
    }

    private void HandleMousePosition()
    {
        var translation = Const.Speed * Time.deltaTime;
        
        if (Input.mousePosition.x < Screen.width * 0.05)
        {
            transform.Translate(new Vector3(-translation,0,0));
        }
        
        if (Input.mousePosition.x > Screen.width * 0.95)
        {
            transform.Translate(new Vector3(translation,0,0));
        }
        
        if (Input.mousePosition.y < Screen.height * 0.05)
        {
            transform.Translate(new Vector3(0,-translation,0));
        }
        
        if (Input.mousePosition.y > Screen.height * 0.95)
        {
            transform.Translate(new Vector3(0,translation,0));
        }
    }
}
