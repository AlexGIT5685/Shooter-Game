using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject enemyThreePrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Repeat the creation of the enemies at various time intervals.
        InvokeRepeating("CreateEnemyOne", 1.5f, 4.5f);
        InvokeRepeating("CreateEnemyTwo", 3.0f, 3f);
        InvokeRepeating("CreateEnemyThree", 1.0f, 3.0f);
    }
    
    //Create the enemies in various places.
    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-8, 8), 8, 0), Quaternion.identity);
    }

    void CreateEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-8, 8), Random.Range(7, 9f), 0), Quaternion.identity);
    }
    void CreateEnemyThree()
    {
        Instantiate(enemyThreePrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
    }
}