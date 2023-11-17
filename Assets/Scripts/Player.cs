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
    private GameObject gM;
    // private GameManager gMS;
    public AudioClip coin;
    public AudioClip health;
    public AudioClip powerup;
    public AudioClip powerdown;
    private bool upgradedWeapon;
    public GameObject thruster;
    private bool shieldOn;
    public GameObject shield;
    private bool speedBoost;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 6f;
        speedBoost = false;
        upgradedWeapon = false;
        shieldOn = false;
        lives = 3;
        gM = GameObject.Find("GameManager");
        // gMS = GameObject.Find("GameManager").GetComponent<GameManager>();
        // As seen above, you can use the GameManager script instead of the GameManager object.
        // Using the script shortens your lines of code, but it may mess up if you change scripts.
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
        if (Input.GetKeyDown(KeyCode.Space) && !upgradedWeapon)
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && upgradedWeapon)
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(-0.5f, 1, 0), Quaternion.Euler(0, 0, 30f));
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 1, 0), Quaternion.Euler(0, 0, -30f));
        }
    }

    public void LoseLife()
    {
        // Subtract life, display lives text, and run game over if 0 lives left.
        if (shieldOn)
        {
            AudioSource.PlayClipAtPoint(powerdown, transform.position);
            shield.SetActive(false);
            shieldOn = false;
            if(speedBoost)
            {
                gM.GetComponent<GameManager>().PowerupChange("Speed");
            }
            else if (upgradedWeapon)
            {
                gM.GetComponent<GameManager>().PowerupChange("Weapon");
            }
            else if (!speedBoost && !upgradedWeapon)
            {
                gM.GetComponent<GameManager>().PowerupChange("No Powerup");
            }
        }       
        else if (!shieldOn)
        {
            lives--;            
        }
        gM.GetComponent<GameManager>().LivesChange(lives);
        if (lives <= 0)
        {
            gM.GetComponent<GameManager>().GameOver();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D pickup)
    {
        switch(pickup.name)
        {
            case "Coin(Clone)":
                // Picked up coin.
                AudioSource.PlayClipAtPoint(coin, transform.position);   
                gM.GetComponent<GameManager>().EarnScore(1);
                Destroy(pickup.gameObject);        
                break;            
            case "Heart(Clone)":
                // Picked up health.
                AudioSource.PlayClipAtPoint(health, transform.position);
                if (lives >= 3)
                {
                    gM.GetComponent<GameManager>().EarnScore(1);
                }
                else if (lives < 3)
                {
                    lives++;
                    gM.GetComponent<GameManager>().LivesChange(lives);
                }
                Destroy(pickup.gameObject);
                break;
            case "Powerup(Clone)":
                // Picked up powerup.
                AudioSource.PlayClipAtPoint(powerup, transform.position);
                Destroy(pickup.gameObject);
                int tempInt;
                tempInt = Random.Range(1, 4);
                if (tempInt == 1)
                {
                    // Speed powerup.
                    speedBoost = true;
                    playerSpeed = 10f;
                    StartCoroutine("SpeedPowerDown");
                    gM.GetComponent<GameManager>().PowerupChange("Speed");
                    thruster.SetActive(true);
                }
                else if (tempInt == 2)
                {
                    // Weapon powerup.
                    upgradedWeapon = true;
                    StartCoroutine("WeaponPowerDown");
                    gM.GetComponent<GameManager>().PowerupChange("Weapon");
                }
                else if (tempInt == 3)
                {
                    // Shield powerup.
                    shieldOn = true;
                    gM.GetComponent<GameManager>().PowerupChange("Shield");
                    shield.SetActive(true);
                }
                break;
        }
    }

    IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(4f);
        AudioSource.PlayClipAtPoint(powerdown, transform.position);
        playerSpeed = 6f;
        speedBoost = false;
        thruster.SetActive(false);
        if (shieldOn)
        {
            gM.GetComponent<GameManager>().PowerupChange("Shield");
        }
        else if (upgradedWeapon)
        {
            gM.GetComponent<GameManager>().PowerupChange("Weapon");
        }
        else if (!shieldOn && !upgradedWeapon)
        {
            gM.GetComponent<GameManager>().PowerupChange("No Powerup");
        }
    }

    IEnumerator WeaponPowerDown()
    {
        yield return new WaitForSeconds(4f);
        AudioSource.PlayClipAtPoint(powerdown, transform.position);
        upgradedWeapon = false;
        gM.GetComponent<GameManager>().PowerupChange("No Powerup");
        if (shieldOn)
        {
            gM.GetComponent<GameManager>().PowerupChange("Shield");
        }
        else if (speedBoost)
        {
            gM.GetComponent<GameManager>().PowerupChange("Speed");
        }
        else if (!shieldOn && !speedBoost)
        {
            gM.GetComponent<GameManager>().PowerupChange("No Powerup");
        }
    }
}