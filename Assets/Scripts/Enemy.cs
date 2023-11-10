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
            // If player is hit by enemy, destroy the enemy and play the explosion animation. Also, subtract a life from the player's lives count.
            whatIHit.GetComponent<Player>().LoseLife();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(whatIHit.tag == "Weapon")
        {
            // If the weapon hits the enemy, destroy both weapon and enemy. Also, gain 2 score.
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(2);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(whatIHit.gameObject);            
            Destroy(this.gameObject);
        }        
    }
}