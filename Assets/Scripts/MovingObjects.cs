using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    public int objectType;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(objectType == 1)
        {
            //The object is the bullet.
            transform.Translate(Vector3.up * Time.deltaTime * 8f);
        }
        else if (objectType == 2)
        {
            //The object is enemy one.
            transform.Translate(Vector3.up * Time.deltaTime * 4.5f);
        }
        else if (objectType == 3)
        {
            //The object is enemy two.
            transform.Translate(Vector3.up * Time.deltaTime * 3f);
        }
        else if (objectType == 4)
        {
            //The object is enemy three.
            transform.Translate(Vector3.up * Time.deltaTime * 2f);
        }

        if(transform.position.y > 10f || transform.position.y < -10f)
        {
            //When it goes above or below the limit, it gets destroyed.
            Destroy(this.gameObject);
        }
    }
}
