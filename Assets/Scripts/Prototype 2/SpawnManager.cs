using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Array of prefabs
    public GameObject[] animalPrefabs;

    //Spawn positions
    private float spawnMaxTop = 20.0f;
    private float spawnMaxBottom = -8.0f;
    private float spawnMaxLeft = -20.0f;
    private float spawnMaxRight = 20.0f;

    //Other
    private float startDelay = 1;
    private float spawnInterval = 1.0f / 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomAnimal()
    {
        //Randomize
        int animalID = Random.Range(0, animalPrefabs.Length);
        int direction = Random.Range(0, 3); //0-top to bottom, 1-left to right, 2-right to left

        //Spawn animal
        switch (direction)
        {
            case 0: //from top
                Instantiate(
                            animalPrefabs[animalID],
                            new Vector3(Random.Range(spawnMaxLeft, spawnMaxRight), 0, spawnMaxTop),
                            Quaternion.Euler(0, 180, 0)
                            );
                break;
            case 1: //from left
                Instantiate(
                            animalPrefabs[animalID],
                            new Vector3(spawnMaxLeft, 0, Random.Range(spawnMaxBottom, spawnMaxTop)),
                            Quaternion.Euler(0, 90, 0)
                            );
                break;
            case 2: //from right
                Instantiate(
                            animalPrefabs[animalID],
                            new Vector3(spawnMaxRight, 0, Random.Range(spawnMaxBottom, spawnMaxTop)),
                            Quaternion.Euler(0, 270, 0)
                            );
                break;
        }
    }
}
