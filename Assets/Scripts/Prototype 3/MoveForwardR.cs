using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardR : MonoBehaviour
{
    private float movementSpeed = 20;
    private PlayerControllerR playerControllerScript;
    private float leftBorder = -15;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerR>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);

        if (transform.position.x < leftBorder)
            Destroy(gameObject);
    }
}
