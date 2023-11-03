using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class EnemyThreeBehaviour : MonoBehaviour
{

    private float timer = 0.0f;

    void Start()
    {


    }


   void Update()
   {
        timer += Time.deltaTime;

        transform.Translate(new Vector3(-1, -1, 0) * Time.deltaTime * 3);

        //make coutner for 10-20 frames change Vector3 x from -1 to 1
        //делить с остатком на 50,
        if (timer > 0.5f)
        {
            transform.Translate(new Vector3(2, -1, 0) * Time.deltaTime * 3);
        }

        if (timer > 1f)
        {
            transform.Translate(new Vector3(-2, -1, 0) * Time.deltaTime * 3);
        }

        if (timer > 1.5f)
        {
            transform.Translate(new Vector3(3, -1, 0) * Time.deltaTime * 3);
        }

        if (transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }
    }
}