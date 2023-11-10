using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosionPrefab;
    
    void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if(whatIHit.tag == "Player")
        {
            // When player is hit, subtract a life and destroy the enemy.
            whatIHit.GetComponent<Player>().LoseLife();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(whatIHit.tag == "Weapon")
        {
            // When hit by weapon, destroy the weapon, destroy the enemy, and add score.
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(2);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(whatIHit.gameObject);            
            Destroy(this.gameObject);
        }        
    }
}