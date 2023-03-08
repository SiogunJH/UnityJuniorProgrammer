using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBorder = 30.0f;
    private float bottomBorder = -10.0f;
    private float leftBorder = -30.0f;
    private float rightBorder = 30.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Destroy when out of bounds
        if (
            transform.position.z > topBorder ||
            transform.position.z < bottomBorder ||
            transform.position.x < leftBorder ||
            transform.position.x > rightBorder
            )
            Destroy(gameObject);
    }
}
