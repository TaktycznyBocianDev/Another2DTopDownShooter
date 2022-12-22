using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinRoundRound : MonoBehaviour
{
    private GameObject target; // obiekt, wokó³ którego ma siê poruszaæ inny obiekt
    public float speed = 5.0f; // szybkoœæ poruszania siê obiektu
    public float minDistance = 10.0f; // minimalna odleg³oœæ, przy której poruszanie siê obiektu ma byæ uruchomione

    private Rigidbody2D rb;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // obliczanie odleg³oœci miêdzy obiektem poruszaj¹cym siê a celem
        float distance = Vector3.Distance(target.transform.position, transform.position);

        // sprawdzenie, czy obiekt jest oddalony od celu o co najmniej minDistance jednostek
        if (distance >= minDistance)
        {
            // obliczanie wektora odleg³oœci miêdzy obiektem poruszaj¹cym siê a celem
            Vector3 direction = target.transform.position - transform.position;

            // obliczanie k¹ta pomiêdzy wektorem odleg³oœci a osi¹ x
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // obliczanie si³y do zadania na obiekt za pomoc¹ k¹ta
            Vector2 force = Quaternion.AngleAxis(angle, Vector3.forward) * Vector2.right;

            // dodawanie si³y do obiektu za pomoc¹ RigidBody2D
            rb.AddForce(force * speed);
        }
    }
}