using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Transform target;
    bool bulletInited;
    public float bulletSpeed = 10f;
    [SerializeField] Vector3 playerPos;

    private void Start()
    {
        target = GameObject.Find("Boat").transform;
        playerPos = target.position;
    }

    private void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, playerPos, bulletSpeed * Time.deltaTime);

    }
}

