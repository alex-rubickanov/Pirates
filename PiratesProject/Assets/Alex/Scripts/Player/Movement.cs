using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector2 movement;
    private Rigidbody2D rb;
    private InputHandler inputHandler;

    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
        rb= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovementHandler();
    }
    
    private void MovementHandler()
    {
        movement.x = Input.GetAxis(inputHandler.GetPlayerRole() + "Horizontal");
        movement.y = Input.GetAxis(inputHandler.GetPlayerRole() + "Vertical");

        rb.velocity = movement.normalized * moveSpeed;

    }

    public Vector2 GetVelocity()
    {
        return rb.velocity.normalized;
    }
}
