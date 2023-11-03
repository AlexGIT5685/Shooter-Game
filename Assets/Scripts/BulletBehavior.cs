using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float bulletVerticalLimit = 8f;

    // Update is called once per frame
    void Update()
    {
        //Set the speed and direction in which the bullet will travel.
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 10);
        
        //Once the bullet reaches the vertical limit, it will be destroyed.
        if (transform.position.y > bulletVerticalLimit)
        {
            Destroy(this.gameObject);
        }
    }
}