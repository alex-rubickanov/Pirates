using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] float boatSpeed = 5f;
    Vector3 boatPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        float forwardMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");
        boatPos = new Vector3(horizontalMovement, forwardMovement);
        rb.velocity = boatPos * boatSpeed;
    }
}
