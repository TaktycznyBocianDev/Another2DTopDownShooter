using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;

    private GameObject Player;
    private Rigidbody2D PlayerRb;

    private Rigidbody2D enemyRb;

    private void Awake()
    {
        enemyRb = gameObject.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerRb = Player.GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Movement();
        Rotation();
    }

    private void Movement()
    {
        Vector2 moveDir = PlayerRb.position - enemyRb.position;
        enemyRb.MovePosition(enemyRb.position + moveDir * enemySpeed * Time.deltaTime);
    }

    private void Rotation()
    {
        Vector2 lookDir = PlayerRb.position - enemyRb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        enemyRb.rotation = angle;
    }

}
