using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanon : MonoBehaviour
{
    public float damage = 1f;
    public bool playExplosion;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(playExplosion)
            {
                Audiomanager.instance.PlayExplosion();
            }
            collision.gameObject.GetComponentInParent<BoatStatus>().boatHealth -= damage;
        }
    }
}
