using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    [SerializeField] private float leftOrRight;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject[] bulletSpawnPoints;
    [SerializeField] private float reloadingTime;
    [SerializeField] private float fireRate;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int amountOfBullets;
    private float currentTime;
    private float timer;
    


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
        transform.position = new Vector3(playerBoat.transform.position.x + leftOrRight, transform.position.y, transform.position.z);
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
        if(amountOfBullets > 0) {
            if (currentTime < fireRate) {
                currentTime += Time.deltaTime;
            } else {
                amountOfBullets--;
                currentTime = 0;
                foreach (GameObject bulletSpawnPoint in bulletSpawnPoints) {
                    GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.transform.up * bulletSpeed;
                }
            }
        } else {
            timer += Time.deltaTime;
            if(timer >= reloadingTime) {
                timer = 0;
                amountOfBullets = 10;
            }
}
        
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
