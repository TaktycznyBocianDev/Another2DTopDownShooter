using UnityEngine;

public class EnemyHitByBullet : MonoBehaviour
{

    public GameObject diedEffect;
    public SpriteRenderer sr;
    public Collider2D enemyColl;

    // Flag to prevent multiple death effects from being instantiated
    private bool once = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the enemy collides with a bullet and has not already died
        if (collision.transform.CompareTag("Bullet") && once)
        {

            GameObject eff = Instantiate(diedEffect, transform.position, Quaternion.identity);

            // Set the "once" flag to false to prevent multiple death effects from being instantiated
            once = false;

            Destroy(sr);
            Destroy(enemyColl);

            Destroy(eff, 1f);
            Destroy(gameObject, 1f);
        }

        // If the enemy collides with the player, destroy the enemy game object - everything else is on Player side
        if (collision.transform.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
