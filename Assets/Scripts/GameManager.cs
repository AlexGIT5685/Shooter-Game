using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject enemyThreePrefab;
    public GameObject cloudPrefab;
    public int score;
    public int cloudsMove;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI powerupText;
    public GameObject[] thingsThatSpawn;
    public GameObject gameOverSet;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn things like the player and enemies. Also, display the score.
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("SpawnEnemyOne", 1.5f, 7.5f);
        InvokeRepeating("SpawnEnemyTwo", 3.0f, 5.5f);
        InvokeRepeating("SpawnEnemyThree", 1.0f, 3.0f);
        InvokeRepeating("SpawnSomething", 5.0f, 3.8f);
        cloudsMove = 1;
        score = 0;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: 3";
        isGameOver = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isGameOver)
        {
            SceneManager.LoadScene("Game");
        }
    }

    void SpawnEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-8, 8), 8f, 0), Quaternion.Euler(0, 0, 180));
    }

    void SpawnEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-8, 8), Random.Range(8, 9), 0), Quaternion.Euler(0, 0, 180));
    }

    void SpawnEnemyThree()
    {
        Instantiate(enemyThreePrefab, new Vector3(Random.Range(-8, 8), 8, 0), Quaternion.Euler(0, 0, 180));
    }

    void CreateSky()
    {
        // Spawn 50 clouds. "i" is a temporary variable that indicates how many clouds have been created.
        for (int i = 0; i < 50; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-11f, 11f), Random.Range(-7.5f, 7.5f), 0), Quaternion.identity);
        }
    }

    void SpawnSomething()
    {
        int tempInt;
        tempInt = Random.Range(0, 3);
        Instantiate(thingsThatSpawn[tempInt], new Vector3(Random.Range(-8.7f, 8.7f), Random.Range(-4.2f, 0f), 0), Quaternion.identity);
    }

    public void GameOver()
    {
        CancelInvoke();
        cloudsMove = 0;
        GetComponent<AudioSource>().Stop();
        gameOverSet.SetActive(true);
        isGameOver = true;
    }

    public void EarnScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void LivesChange(int currentLife)
    {
        livesText.text = "Lives: " + currentLife;
    }

    public void PowerupChange(string whatPowerup)
    {
        powerupText.text = whatPowerup;
    }
}