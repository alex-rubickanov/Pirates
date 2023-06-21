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
    private enum States
    {
        Moving,
        Shooting
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        state = IsOnLineWithPlayerBoat();
        Debug.Log(state);
        transform.position = new Vector3(playerBoat.transform.position.x + 10f, transform.position.y, transform.position.z);
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
         
        if (transform.position.y > playerBoat.transform.position.y) {
             transform.position -= Time.deltaTime * Vector3.up * moveSpeed;
        } else if (transform.position.y < playerBoat.transform.position.y) {
            transform.position += Time.deltaTime * Vector3.up * moveSpeed;
        }
        
    }

    private void Shoot()
    {

    }

    private States IsOnLineWithPlayerBoat()
        {
            if (transform.position.y - playerBoat.transform.position.y < -2
            || transform.position.y - playerBoat.transform.position.y > 2) {
                return States.Moving;
            } else {
                return States.Shooting;
            }
        }
    }
