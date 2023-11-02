using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float bulletVerticalLimit = 8f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 9);
        
        if (transform.position.y > bulletVerticalLimit)
        {
            Destroy(this.gameObject);
        }
    }
}
