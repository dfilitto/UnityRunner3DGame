using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRG; //corpo rigido do player
    private Animator playerAnim; //controla a animação do player
    private AudioSource playerAudio;
    
    public float jumpForce = 10f; //força do pulo
    public float gravityModifier = 1.5f; //gravidade do jogo
    public bool isonGround = true; //verifica se o player estão no chão
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;


    // Start is called before the first frame update
    void Start()
    {
        playerRG = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Jump") > 0 && isonGround && !GameController.gameOver)
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            dirtParticle.Stop();
            playerRG.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isonGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!GameController.gameOver) dirtParticle.Play();
            isonGround = true;
        } else if (collision.gameObject.CompareTag("Obstacles"))
        {
            playerAudio.PlayOneShot(crashSound, 1.0f);
            dirtParticle.Stop();
            explosionParticle.Play();
            GameController.gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
