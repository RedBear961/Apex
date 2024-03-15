using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class OrbitNode: MonoBehaviour
{
    public float radius;

    public void Start()
    {
        var lineRenderer = this.AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        DrawPolygon(lineRenderer,128, radius, Vector3.zero, 1f, 1f);
    }

    private void DrawPolygon(LineRenderer lineRenderer, int vertexNumber, float radius, Vector3 centerPos, float startWidth, float endWidth)
    {
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.loop = true;
        float angle = 2 * Mathf.PI / vertexNumber;
        lineRenderer.positionCount = vertexNumber;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.sortingOrder = -1;

        for (int i = 0; i < vertexNumber; i++)
        {
            Matrix4x4 rotationMatrix = new Matrix4x4(
                new Vector4(Mathf.Cos(angle * i), Mathf.Sin(angle * i), 0, 0),
                new Vector4(-1 * Mathf.Sin(angle * i), Mathf.Cos(angle * i), 0, 0),
                new Vector4(0, 0, 1, 0),
                new Vector4(0, 0, 0, 1));
            Vector3 initialRelativePosition = new Vector3(0, radius, 0);
            lineRenderer.SetPosition(i, centerPos + rotationMatrix.MultiplyPoint(initialRelativePosition));
        }
    }
}