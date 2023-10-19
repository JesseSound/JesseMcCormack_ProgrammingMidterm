using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public GameObject bullet;

    float rotation = 0.0f;
    float rotationSpeed = 250.0f * Mathf.Deg2Rad;
    public float playerSpeed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Example code to create a bullet and change its velocity:
       
    }

    void Update()
    {
        float dt = Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            rotation += rotationSpeed * dt;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotation -= rotationSpeed * dt;
        }

        Vector3 direction = new Vector3(Mathf.Cos(rotation), Mathf.Sin(rotation), 0.0f);
        Debug.DrawLine(transform.position, transform.position + direction * 10.0f);

        // Task 1: Move the player forwards when W is held, and backwards when S is held
        // Ensure movement is time-based

        Vector3 forward = transform.right;
        Vector3 right = transform.up;


        if (Input.GetKey (KeyCode.W))
        {
            transform.position += direction * playerSpeed * dt;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= direction * playerSpeed * dt;
        }
        // Task 2: Create a bullet when space is pressed
        // Ensure the bullet is not touching the player when it's created
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // Vector3 offset = transform.forward * 10 ;
            //Vector3 newPos = transform.position + offset;
            GameObject bulletClone = Instantiate(bullet, transform.position + direction, Quaternion.identity) ;
            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * 5.0f;
            Destroy(bulletClone, 2.0f);

        }
    }
}
