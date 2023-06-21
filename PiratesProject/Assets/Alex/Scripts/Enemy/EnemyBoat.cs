using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoat : MonoBehaviour
{
    [SerializeField] private GameObject playerBoat;
    [SerializeField] private float distanceToShoot;
    [SerializeField] private float moveSpeed;
    [SerializeField] private States state;
    private enum States
    {
        Moving,
        Shooting
    }

    private void Update()
    {
        state = IsOnLineWithPlayerBoat();

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
        if(transform.position.y != playerBoat.transform.position.y) {
            if(transform.position.y > playerBoat.transform.position.y) {
                transform.position -= Time.deltaTime * Vector3.up * moveSpeed;
            } else if (transform.position.y < playerBoat.transform.position.y) {
                transform.position += Time.deltaTime * Vector3.up * moveSpeed;
            }
        }
    }

    private void Shoot()
    {
        Debug.Log("Shoot");
    }

    private States IsOnLineWithPlayerBoat()
    {
        if(transform.position.y == playerBoat.transform.position.y) {
            return States.Moving;
        } else {
            return States.Shooting;
        }
    }
}
