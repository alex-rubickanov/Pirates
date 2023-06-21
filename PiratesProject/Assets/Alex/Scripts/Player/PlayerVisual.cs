using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Movement playerMovement;
    private Animator animator;

    private const string VELOCITY_X = "VelocityX";
    private const string VELOCITY_Y = "VelocityY";

    private bool isFacingRight;

    private void Awake()
    {
        playerMovement = GetComponentInParent<Movement>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SyncAnimationWithMovement();
        Flip();
    }

    private void SyncAnimationWithMovement()
    {
        animator.SetFloat(VELOCITY_X, playerMovement.GetVelocity().x);
        animator.SetFloat(VELOCITY_Y, playerMovement.GetVelocity().y);
    }

    private void Flip()
    {
        if (isFacingRight && playerMovement.GetVelocity().x < 0f || !isFacingRight && playerMovement.GetVelocity().x > 0f) {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
