using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoat : MonoBehaviour
{
    [SerializeField] private GameObject playerBoat;
    [SerializeField] private float distanceToShoot;
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        if (!Move()) {
            Shoot();
        }
    }

    private bool Move()
    {
        var step = Time.deltaTime * moveSpeed;

        if(Vector3.Distance(transform.position, playerBoat.transform.position) > distanceToShoot) {
            transform.position = Vector3.MoveTowards(transform.position, playerBoat.transform.position, step);
            return true;
        }
        return false;
    }

    private void Shoot()
    {
        Debug.Log("Shoot");
    }
}
