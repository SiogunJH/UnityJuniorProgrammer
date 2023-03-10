using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerR : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    private float jumpForce = 2250;
    private float gravityModifier = 5;
    private bool isOnGround = false;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {

        AnimatorStateInfo stateInfo = playerAnim.GetCurrentAnimatorStateInfo(3);


        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver && stateInfo.IsName("Run"))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_b");
            swapOnGroundStatus();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            gameOverFun();
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            playerAnim.ResetTrigger("Jump_b");
            dirtParticle.Play();
            swapOnGroundStatus();
        }
    }

    void swapOnGroundStatus()
    {
        isOnGround = !isOnGround;
    }

    void gameOverFun()
    {
        gameOver = true;
        Debug.Log("Game Over");
        playerAnim.SetInteger("DeathType_int", 1);
        playerAnim.SetBool("Death_b", true);
        explosionParticle.Play();
        dirtParticle.Stop();
        playerAudio.PlayOneShot(crashSound, 1.0f);
    }
}