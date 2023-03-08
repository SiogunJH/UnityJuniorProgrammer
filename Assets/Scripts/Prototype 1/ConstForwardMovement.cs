using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstForwardMovement : MonoBehaviour
{
    private float speed = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
