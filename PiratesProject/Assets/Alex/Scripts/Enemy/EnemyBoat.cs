using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBoat : MonoBehaviour
{
    [SerializeField] private GameObject playerBoat;
    [SerializeField] private float distanceToShoot;
    [SerializeField] private float moveSpeed;
    [SerializeField] private States state;
    private Rigidbody2D rb;
    [SerializeField] private float timeToWait;
    private enum States
    {
        Moving,
        Shooting
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        state = IsOnLineWithPlayerBoat();
        Debug.Log(state);

        switch (state) {
            case States.Moving:
                Move();
                break;
            case States.Shooting:
                Shoot();
                break;
        }
    }

    private void Move()
    {
        var step = moveSpeed * Time.deltaTime;
        rb.velocity = Vector3.MoveTowards(transform.position, playerBoat.transform.position, step);
    }

    private void Shoot()
    {
        rb.velocity = Vector3.zero;
    }

    private States IsOnLineWithPlayerBoat()
    {
        if(Vector3.Distance(transform.position, playerBoat.transform.position) > distanceToShoot) {
            return States.Moving;
        } else {
            return States.Shooting;
        }
    }
}
