using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public float playerSpeed;
    private float horizontalScreenLimit = 10.38f;
    private float verticalScreenLimit = 4f;
    public int lives;
    [HideInInspector] public TextMeshProUGUI livesText;
    [HideInInspector] public AudioSource coinPickup;
    [HideInInspector] public AudioSource heartPickup;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 6f;
        lives = 3;
        livesText = GameObject.Find("GameManager").GetComponent<GameManager>().livesText;
        livesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * playerSpeed);

        // When the left or right edge is reached, go to the other side.
        if (transform.position.x >= horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1f, transform.position.y, 0);
        }

        // If at mid point of screen, stop player from going higher. Else if at the bottom of screen, prevent player from going lower.
        if (transform.position.y <= -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, -verticalScreenLimit, 0);
        }
        else if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    public void LoseLife()
    {
        // Subtract life, display lives text, and run game over if 0 lives left.
        lives--;
        livesText.text = "Lives: " + lives;
        if (lives <= 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Coin")
        {
            // If the coin is hit, add 1 score, play the coin sound, and destroy the coin.
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(1);
            coinPickup = GameObject.Find("CoinAudio").GetComponent<AudioSource>();
            coinPickup.Play();
            Destroy(whatIHit.gameObject);
        }
        else if (whatIHit.tag == "Heart")
        { 
            // If the heart is hit, play the heart sound, destroy it, and check the number of lives. If more than 3, give 1 score. Else if less than 3, give 1 life.
            heartPickup = GameObject.Find("HeartAudio").GetComponent<AudioSource>();
            heartPickup.Play();
            Destroy(whatIHit.gameObject);

            if (lives >= 3)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(1);
            }
            else if (lives < 3)
            {
                lives++;
                livesText.text = "Lives: " + lives;
            }
        }
    }
}