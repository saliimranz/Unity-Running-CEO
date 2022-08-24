using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticles;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    public float jumpStart ;
    public float gravityModifier;
    public bool isOnGround = true;
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
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
             playerRb.AddForce(Vector3.up*jumpStart,ForceMode.Impulse);
             isOnGround = false;
             playerAnim.SetTrigger("Jump_trig");  
             dirtParticles.Stop();
             playerAudio.PlayOneShot(jumpSound, 1.0f);  
        }
    }
   void OnCollisionEnter(Collision collision){
       
        if(collision.gameObject.CompareTag("Ground")){
             isOnGround = true;
             dirtParticles.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle")){
            gameOver = true;
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticles.Stop();
            playerAudio.PlayOneShot(crashSound, 50.0f);

            Debug.Log("Game Over!");
        }
    }
}
