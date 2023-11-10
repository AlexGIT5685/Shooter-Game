using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public GameObject coinPrefab;
    public GameObject heartPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn things like the player and enemies. Also, display the score.
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("SpawnEnemyOne", 1.5f, 7.5f);
        InvokeRepeating("SpawnEnemyTwo", 3.0f, 5.5f);
        InvokeRepeating("SpawnEnemyThree", 1.0f, 3.0f);
        InvokeRepeating("SpawnCoin", 8.5f, 12.8f);
        InvokeRepeating("SpawnHeart", 9.7f, 14.2f);
        cloudsMove = 1;
        score = 0;
        scoreText.text = "Score: " + score;
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

    void SpawnCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-8.7f, 8.7f), Random.Range(-4.2f, 0f), 0), Quaternion.identity);
        Destroy(GameObject.FindWithTag("Coin"), 90f);
    }

    void SpawnHeart()
    {
        Instantiate(heartPrefab, new Vector3(Random.Range(-9f, 9f), Random.Range(-4.2f, 0f), 0), Quaternion.identity);
        Destroy(GameObject.FindWithTag("Heart"), 100f);
    }

    public void GameOver()
    {
        CancelInvoke();
        cloudsMove = 0;
    }

    public void EarnScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}