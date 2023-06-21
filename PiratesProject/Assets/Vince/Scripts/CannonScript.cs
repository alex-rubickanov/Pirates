using System;
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
    [SerializeField] KeyCode shootCtrls;

    [Header("Rotation")]
    [SerializeField] float rotSpeed = 2f;
    [SerializeField] float minAngle;
    [SerializeField] float maxAngle;
    public string playerRole;
    float canonAngle;

    void Update()
    {
        CanonRotation();
        CanonShoot();
    }

    public void CheckControls(string playerRole)
    {
       if(playerRole == "P1_")
        {
            shootCtrls = KeyCode.LeftShift;
        }else if(playerRole == "P2_")
        {
            shootCtrls = KeyCode.RightShift;
        }
        else
        {
            shootCtrls = KeyCode.Joystick1Button5;
        }
    }

    void CanonShoot()
    {
        if (Input.GetKey(shootCtrls) && amountOfBullets > 0)
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
        canonAngle += Input.GetAxis(playerRole+"Vertical") * rotSpeed * Time.deltaTime;
        canonAngle = Mathf.Clamp(canonAngle, minAngle, maxAngle);
        transform.rotation = Quaternion.Euler(0.0f, transform.eulerAngles.y, canonAngle);
    }
    private void OnEnable()
    {
        enableCannon = true;
    }
    private void OnDisable()
    {
        enableCannon = false;
    }
}
