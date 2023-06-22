using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement2 : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] float boatSpeed = 5f;
    Vector3 boatPos;
    public bool enableDriving;

    public string playerRole;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (enableDriving)
        {
            Movement();

        }
    }

    public void Movement()
    {
        float forwardMovement = Input.GetAxis(playerRole + "Vertical");
        float horizontalMovement = Input.GetAxis(playerRole + "Horizontal");
        boatPos = new Vector3(horizontalMovement, forwardMovement);
        rb.velocity = -boatPos * boatSpeed;
    }

    private void OnDisable()
    {
        enableDriving = false;
        rb.velocity = Vector3.zero;
    }

    private void OnEnable()
    {
        enableDriving = true;
    }
}
