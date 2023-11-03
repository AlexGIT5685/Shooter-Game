using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneBehavior : MonoBehaviour
{  

    // Update is called once per frame
    void Update()
    {
        //Set the movement speed and direction of the enemy.
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 4.38f);

        //Once the enemy goes off the screen, destroy the object.
        if (transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }
    }
}