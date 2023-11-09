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
    public TextMeshProUGUI livesText;

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
        
        //SHhhhhhhhhh this is a cheat for testing purposes.
        if (Input.GetKeyDown(KeyCode.L))
        {
            lives++;
        }   
        //SHhhhhhhhhh this is a cheat for testing purposes.
        if (Input.GetKeyDown(KeyCode.K))
        {
            lives--;
        }     
    }

    void Movement ()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * playerSpeed);

        //when the left or right edge is reached, go to the other side.
        if (transform.position.x >= horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1f, transform.position.y, 0);
        }

        //if at mid point of screen, stop player from going higher. Else if at the bottom of screen, prevent player from going lower.
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
        lives--;
        livesText.text = "Lives: " + lives;

        if (lives <= 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }    
}