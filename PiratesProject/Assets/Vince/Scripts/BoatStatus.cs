using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatStatus : MonoBehaviour
{
    [SerializeField] float boatHealth = 100f;
    [SerializeField] RandomHoles randomHoles;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DamageBoat(10);
        }
    }
    public void DamageBoat(float damage)
    {
        randomHoles.SpawnHole();
        boatHealth -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyBullet") {
            Destroy(collision.gameObject);
        }
    }
}
