using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private void Awake()
    {
        //To destroy bullet in mid-air after some time
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
    }
}