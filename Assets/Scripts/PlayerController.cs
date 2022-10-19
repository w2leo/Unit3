using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private const string DIST_TEXT = "Distance = ";

    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravityModifier = 1.5f;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip crashClip;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text distanceText;
    private AudioSource playerAudio;
    private Rigidbody playerRb;
    private Animator playerAnim;
    private bool isOnGround = true;
    private bool gameIsOver;

    public bool GameIsOver => gameIsOver;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !GameIsOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpClip, 1.0f);
        }

       // distanceText.text = DIST_TEXT + (int)transform.position.x;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !GameIsOver)
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && !GameIsOver)
        {
            Debug.Log("Game Over");
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashClip, 1.0f);
            gameIsOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            Invoke("GameOverPanelShow", 1.0f);
        }
    }

    private void GameOverPanelShow()
    {
        gameOverPanel.SetActive(true);
    }
}
