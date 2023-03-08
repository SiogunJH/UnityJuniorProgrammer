using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private Vector3 scale;

    public float angle = 0;

    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        scale = transform.localScale;

        Material material = Renderer.material;

        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }

    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);

        UpdateScale();
        transform.localScale = scale;
    }

    void UpdateScale()
    {
        angle += 60 * Time.deltaTime;
        if (angle > 360) angle -= 360;

        float xz = 1.1f + 1.0f * Mathf.Sin((angle + 180) / 180 * Mathf.PI);
        float y = 2.1f + 2.0f * Mathf.Sin(angle / 180 * Mathf.PI);
        scale = new Vector3(xz, y, xz);
    }
}
