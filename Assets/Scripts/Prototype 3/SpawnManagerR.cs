using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerR : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(30, 0, 0);
    private float spawnDelay = 3.0f;
    private float spawnRepeatDelay = 3.0f;
    private PlayerControllerR playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnDelay, spawnRepeatDelay);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerR>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
            Instantiate(obstaclePrefab, spawnPos, Quaternion.Euler(0, 270, 0));
    }
}
