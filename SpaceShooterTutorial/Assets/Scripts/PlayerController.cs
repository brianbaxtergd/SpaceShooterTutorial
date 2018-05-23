using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    [SerializeField]
    Boundary boundary = new Boundary();

    public GameObject shot;
    public Transform shotSpawn;
    float nextFire;
    public float fireRate;

    void Update()
    {
        // Executes just before updating the frame, every frame.
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            /*GameObject clone = */
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //as GameObject;
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        // Executes on fixed intervals, perfect for code involving physics.

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }
}
