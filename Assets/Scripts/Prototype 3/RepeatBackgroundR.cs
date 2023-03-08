using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundR : MonoBehaviour
{
    private Vector3 startPos = new Vector3(45, 9.5f, 4);
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (startPos.x - repeatWidth > transform.position.x)
        {
            transform.position = new Vector3(transform.position.x + repeatWidth, transform.position.y, transform.position.z);
        }
    }
}
