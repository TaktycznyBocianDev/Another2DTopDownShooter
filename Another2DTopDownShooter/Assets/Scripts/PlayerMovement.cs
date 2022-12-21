using UnityEngine;

// It requires a Rigidbody2D component to be attached to the player game object.
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    // A camera is required to determine the mouse position in the game world.
    public Camera cam;

    // Reference to the Rigidbody2D component attached to the player
    Rigidbody2D rb;

    // Vectors - to store the player's movement input and to store the mouse position in the game world 
    Vector2 movement;
    Vector2 mousePos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get the player's input on the horizontal and vertical axis
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // Get the mouse position in the game world
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    private void FixedUpdate()
    {
        // Move the player based on the input and move speed
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        // Calculate the direction the player should be facing based on the mouse position
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        // Rotate the player to face the mouse cursor
        rb.rotation = angle;
    }
}
