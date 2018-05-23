using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;

    void Start()
    {
        // Executed on first frame object is instantiated.
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
