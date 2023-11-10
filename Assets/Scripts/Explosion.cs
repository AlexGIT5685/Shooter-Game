using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Destroy after 2.63 seconds, the amount of time for the entire animation to play.
        Destroy(this.gameObject, 2.63f);
    }
}