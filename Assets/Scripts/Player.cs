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
<<<<<<< Updated upstream
        
        //SHhhhhhhhhh this is a cheat for testing purposes.
        if (Input.GetKeyDown(KeyCode.L))
        {
            lives++;
            lifeText.text = "Lives: " + lives;
        }   
        //SHhhhhhhhhh this is a cheat for testing purposes.
        if (Input.GetKeyDown(KeyCode.K))
        {
            lives--;
            lifeText.text = "Lives: " + lives;
        }     
=======
>>>>>>> Stashed changes
    }

    void Movement ()
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    public void LoseLife()
    {
<<<<<<< Updated upstream
        lives--;        
        //lives -= 1;
        //lives = lives - 1;
        lifeText.text = "Lives: " + lives;
=======
        // Subtract a life and display the current lives value. If the player has no more lives, end the game.
        lives--;
        livesText.text = "Lives: " + lives;
>>>>>>> Stashed changes
        if (lives <= 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }   

    void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if(whatIHit.tag == "Coin")
        {
<<<<<<< Updated upstream
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(1);   
            coinPickup = GameObject.Find("CoinAudio").GetComponent<AudioSource>();         
            coinPickup.Play();  
            Destroy(whatIHit.gameObject);
        }
        else if(whatIHit.tag == "Heart")
        {   
            // Should we make the coin sound play when above 3 health because they earn 1 score? Or should we always play health sound? 
            heartPickup = GameObject.Find("HeartAudio").GetComponent<AudioSource>();        
=======
            // Give the player a point, play the coin sound, and destroy the coin when the player collides with it.
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(1);
            coinPickup = GameObject.Find("CoinAudio").GetComponent<AudioSource>();
            coinPickup.Play();
            Destroy(whatIHit.gameObject);
        }
        else if (whatIHit.tag == "Heart")
        {
            // Play pickup audio when player collides with heart, and destroy the heart.
            heartPickup = GameObject.Find("HeartAudio").GetComponent<AudioSource>();
>>>>>>> Stashed changes
            heartPickup.Play();
            Destroy(whatIHit.gameObject);

            // If the player has 3 lives or more, give them 1 score instead of a life. Else if they have less than 3 lives, give them 1 life and display the current lives on screen.
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
<<<<<<< Updated upstream
    } 
=======
    }
>>>>>>> Stashed changes
}