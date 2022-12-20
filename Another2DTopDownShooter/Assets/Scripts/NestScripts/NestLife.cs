using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestLife : MonoBehaviour
{
    public GameObject enemies;

    void Awake()
    {
       Collider2D enemyCollider = enemies.GetComponent<Collider2D>();
       Physics2D.IgnoreCollision(enemyCollider, GetComponent<Collider2D>(), true);
    }


}
