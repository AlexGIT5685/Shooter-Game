using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed;
    public float horizontalInput;
    public float verticalInput;
    public float horizontalScreenLimit;    
    public GameObject bulletPrefab;
    public float middleScreen;
    public float bottomScreen;
    public int lives;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {       
        speed = 4f;
        horizontalScreenLimit = 9.4f;        
        middleScreen = 0.5f;
        bottomScreen = -3.5f;
        lives = 3;        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();        
    }

    void Movement()
    {
        //Set the movement of the player object
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);

        //If player reaches the left or right horizontal boundary, they will be teleported to the opposing side. If on the left, sent to the right. If on the right, sent to the left.
        if (transform.position.x > horizontalScreenLimit)
        {
            transform.position = new Vector3(-horizontalScreenLimit, transform.position.y, 0);
        }
        else if (transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(horizontalScreenLimit, transform.position.y, 0);
        }

        //If the player reaches the mid point/middle of the screen, prevent them from moving higher. Additionally, if the player reaches the bottom of the screen, prevent them from going any lower.
        if (transform.position.y >= middleScreen) 
        {
            transform.position = new Vector3(transform.position.x, middleScreen, 0);
        }
        else if (transform.position.y <= bottomScreen)
        {
            transform.position = new Vector3(transform.position.x, bottomScreen, 0);
        }
    }

    void Shooting()
    {
        //When space is pressed, bullets are spawned.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    public void LoseLife()
    {
        lives--;
        //lives -= 1;
        //lives = lives -1;
        if (lives <= 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}