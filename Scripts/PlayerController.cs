using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRG; //corpo rigido do player
    private Animator playerAnim; //controla a animação do player
    private AudioSource playerAudio; //controla o audio

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
        playerAnim = GetComponent<Animator>();
        playerRG = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity = new Vector3(0f, -9.81f * gravityModifier, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //playerAnim.SetBool("Jump_b", isonGround);
        if (Input.GetAxis("Jump") > 0 && isonGround && !GameController.gameOver)
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            dirtParticle.Stop();
            playerRG.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isonGround = false;
            //playerAnim.SetBool("Jump_b", true);
            playerAnim.SetTrigger("Jump_trig"); //disparo o gatilho do pulo
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isonGround = true;
            //playerAnim.SetBool("Jump_b", false);
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacles"))
        {
            GameController.gameOver = true;
            playerAudio.PlayOneShot(crashSound, 1.0f);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            Invoke("GameRestart", 5f);
        }
    }

    private void GameRestart()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
