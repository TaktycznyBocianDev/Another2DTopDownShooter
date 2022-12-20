using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitByBullet : MonoBehaviour
{

    public GameObject diedEffect;
    public SpriteRenderer sr;
    public Collider2D enemyColl;

    private bool once = true;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Bullet") && once)
        {

            GameObject eff = Instantiate(diedEffect, transform.position, Quaternion.identity);
            
            once = false;

            Destroy(sr);
            Destroy(enemyColl);

            Destroy(eff, 1f);
            Destroy(gameObject, 1f);
        }

        if (collision.transform.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
