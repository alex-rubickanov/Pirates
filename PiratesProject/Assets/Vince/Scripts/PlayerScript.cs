using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float boatSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] BoatMovement bm;
    Vector3 boatPos;
    [SerializeField] bool boat;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bm = GetComponentInParent<BoatMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation();

        if (Input.GetKeyDown(KeyCode.F) && !boat)
        {
            boat = true;
        }
        else if(Input.GetKeyDown(KeyCode.F) && boat)
        {

            boat = false;
        }

        if (!boat)
        {
            Movement();
            bm.rb.velocity = Vector2.zero;
        }
        else
        {
            bm.Movement();
        }
    }

    private void Movement()
    {
        // boatPos = new Vector3(0, forwardMovement) * boatSpeed;
        float forwardMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        boatPos = new Vector3(horizontalMovement, forwardMovement);

        rb.velocity = boatPos * boatSpeed;
    }

}
