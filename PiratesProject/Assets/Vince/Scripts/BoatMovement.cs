using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float boatSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;
     Vector3 boatPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       // Rotation();
        Movement();
    }

    private void Movement()
    {
        // boatPos = new Vector3(0, forwardMovement) * boatSpeed;
        float forwardMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        boatPos = new Vector3(horizontalMovement, forwardMovement);

        rb.velocity = boatPos * boatSpeed;
    }

    private void Rotation()
    {
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, 0, -rotation * rotationSpeed));
    }
}
