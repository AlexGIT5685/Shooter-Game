using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    public int objectType;
    private float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (objectType == 4)
        {
            // The object is the bullet.
            transform.Translate(Vector3.up * Time.deltaTime * 8f);
        }
        else if (objectType == 1)
        {
            // The object is enemy one.
            transform.Translate(Vector3.up * Time.deltaTime * 4.5f);
        }
        else if (objectType == 2)
        {
            // The object is enemy two.
            transform.Translate(Vector3.up * Time.deltaTime * 3f);
        }
        else if (objectType == 3)
        {
            // The object is enemy three.
            timer += Time.deltaTime;

            transform.Translate(new Vector3(1, 1, 0) * Time.deltaTime * 2f);

            //make coutner for 10-20 frames change Vector3 x from -1 to 1
            //делить с остатком на 50,
            if (timer > 1.2f)
            {
                transform.Translate(new Vector3(-2, .3f, 0) * Time.deltaTime * 3);
            }

            if (timer > 2.1f)
            {
                transform.Translate(new Vector3(2.5f, .2f, 0) * Time.deltaTime * 3);
            }

            if (timer > 3f)
            {
                transform.Translate(new Vector3(-2.5f, .1f, 0) * Time.deltaTime * 3);
            }

            if (timer > 3.9f)
            {
                transform.Translate(new Vector3(2.5f, .1f, 0) * Time.deltaTime * 3);
            }
        }
        else if (objectType == 5)
        {
            // The object is the coin.            
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 2.9f);
            Destroy(this.gameObject, 3.6f);

            if (transform.position.x >= 9.8f)
            {
                // When it reaches the edge, go to the opposite side.
                transform.position = new Vector3(-transform.position.x, transform.position.y, 0);
            }
        }
        else if (objectType == 6)
        {
            // The object is the health powerup.            
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 2.1f);
            Destroy(this.gameObject, 3.6f);

            if (transform.position.x <= -9.8f)
            {
                // When it reaches the edge, go to the opposite side.
                transform.position = new Vector3(-transform.position.x, transform.position.y, 0);
            }
        }
        else if (objectType == 7)
        {
            // The object is the powerup.            
            transform.Translate(new Vector3(1, 0.16f, 0) * Time.deltaTime * 2.9f);
            Destroy(this.gameObject, 3.6f);

            if (transform.position.x >= 9.8f)
            {
                // When it reaches the edge, go to the opposite side.
                transform.position = new Vector3(-transform.position.x, transform.position.y, 0);
            }
        }

        if (transform.position.y > 10f || transform.position.y < -10f)
        {
            // When it goes above or below the limit, it gets destroyed.
            Destroy(this.gameObject);
        }
    }
}