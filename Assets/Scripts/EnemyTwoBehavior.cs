using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoBehavior : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        //Set the movement speed and direction of the enemy.
        transform.Translate(new Vector3(0.4f, -1, 0) * Time.deltaTime * 4);
     
        //When the enemy goes off screen, destroy it.
        if (transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }
    }
}