using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB;

    [SerializeField] private Animator playerAnimator;

    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtSplatterParticle;

    [SerializeField] private AudioSource playerAudio;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float gravityModifier = 1;
    
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private bool gameOver = false;

    void Start()
    {
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirtSplatterParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirtSplatterParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtSplatterParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

    public bool GetGameOver()
    {
        return gameOver;
    }
}
