using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;
    private GameObject Player;

    private Rigidbody2D PlayerRb;
    private Rigidbody2D enemyRb;

    private void Awake()
    {
        // Get the Rigidbody2D component attached to the enemy
        enemyRb = gameObject.GetComponent<Rigidbody2D>();

        // Find the player game object with the "Player" tag
        Player = GameObject.FindGameObjectWithTag("Player");
        // Get the Rigidbody2D component attached to the player
        PlayerRb = Player.GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Movement();
        Rotation();
    }

    // Function to move the enemy towards the player
    private void Movement()
    {
        Vector2 moveDir = PlayerRb.position - enemyRb.position;
        enemyRb.MovePosition(enemyRb.position + moveDir * enemySpeed * Time.deltaTime);
    }

    // Function to rotate the enemy towards the player
    private void Rotation()
    {
        Vector2 lookDir = PlayerRb.position - enemyRb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        enemyRb.rotation = angle;
    }

}
