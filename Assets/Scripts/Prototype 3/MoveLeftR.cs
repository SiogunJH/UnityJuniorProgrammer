using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftR : MonoBehaviour
{
    private float movementSpeed = 20;
    private PlayerControllerR playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerR>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
            transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);
    }
}
