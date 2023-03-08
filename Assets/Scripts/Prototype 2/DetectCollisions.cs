using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Variables
    private int currentFood = 0;
    public int neededFood;
    PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        // Debug Info
        //Debug.Log(string.Format("{0} and {1}", name, other.name));

        //Find player

        //Food collides with animal
        if (other.name == "Food(Clone)")
        {
            Destroy(other.gameObject);
            IncreaseFood();
        }

        //Player collides with animal
        else if (other.name == "Player")
        {
            player.ReduceHealth();
        }
    }

    public void IncreaseFood()
    {
        currentFood++;
        if (currentFood == neededFood)
        {
            Destroy(gameObject);
            player.IncreaseScore(neededFood);
        }
    }
}
