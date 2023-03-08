using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject projectileProfab;
    private float horizontalInput;
    private float verticalInput;
    private float movementSpeed = 15.0f;
    private float leftBorder = -15.0f;
    private float rightBorder = 15.0f;
    private float topBorder = 15.0f;
    private float bottomBorder = 0.0f;
    private int health = 5;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Update variables
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Update player postion
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * movementSpeed);
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * movementSpeed);

        //Correct player postion
        if (transform.position.x < leftBorder)
            transform.position = new Vector3(leftBorder, transform.position.y, transform.position.z);
        else if (transform.position.x > rightBorder)
            transform.position = new Vector3(rightBorder, transform.position.y, transform.position.z);

        if (transform.position.z > topBorder)
            transform.position = new Vector3(transform.position.x, transform.position.y, topBorder);
        else if (transform.position.z < bottomBorder)
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomBorder);

        //Detect Space press and clone projectile at player's position
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(projectileProfab, transform.position, projectileProfab.transform.rotation);
    }

    public void ReduceHealth()
    {
        //Reduce health
        health--;

        //Display
        Debug.Log(string.Format("Player damaged! Health left: {0}", health));

        //Check for game over
        if (health == 0)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
            Debug.Log(string.Format("Final Score: {0}", score));
        }
    }

    public void IncreaseScore(int scoreBonus)
    {
        //Increase score
        score += scoreBonus;

        //Display
        Debug.Log(string.Format("Score: {0}", score));
    }
}
