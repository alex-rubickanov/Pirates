using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] float boatSpeed = 5f;
    Vector3 boatPos;

    public string playerRole;
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
        float forwardMovement = Input.GetAxis(playerRole+"Vertical");
        float horizontalMovement = Input.GetAxis(playerRole+"Horizontal");
        boatPos = new Vector3(horizontalMovement, forwardMovement);
        rb.velocity = boatPos * boatSpeed;
    }

    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
    }
}
