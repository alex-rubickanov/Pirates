using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public bool enableCannon;

    [Header("Cannon Status")]
    [SerializeField] float amountOfBullets = 50f;

    [Header("Shooting")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] float currentTime;

    [Header("Rotation")]
    [SerializeField] float rotSpeed = 2f;
    [SerializeField] float minAngle;
    [SerializeField] float maxAngle;
    float canonAngle;

    void Update()
    {
        CanonRotation();
        CanonShoot();
    }

    void CanonShoot()
    {
        if (Input.GetAxis("Fire1") > 0 && amountOfBullets > 0)
        {
            if (currentTime < fireRate)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                amountOfBullets--;
                currentTime = 0;
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
            }
        }
        else
        {
            currentTime = 0;
        }
    }

    private void CanonRotation()
    {
        canonAngle += Input.GetAxis("Vertical") * rotSpeed * Time.deltaTime;
        canonAngle = Mathf.Clamp(canonAngle, minAngle, maxAngle);
        transform.rotation = Quaternion.Euler(0.0f, transform.eulerAngles.y, canonAngle);
    }
}
