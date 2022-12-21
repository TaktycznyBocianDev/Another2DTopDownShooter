using UnityEngine;

public class NestLife : MonoBehaviour
{
    public GameObject enemies;

    void Awake()
    {
        Collider2D enemyCollider = enemies.GetComponent<Collider2D>();                // Get the collider component attached to the enemy game object
        Physics2D.IgnoreCollision(enemyCollider, GetComponent<Collider2D>(), true);  // Ignore collisions between the enemy and the nest
    }


}
