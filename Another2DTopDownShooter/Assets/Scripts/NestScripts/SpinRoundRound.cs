using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinRoundRound : MonoBehaviour
{
    private GameObject target; // obiekt, wok� kt�rego ma si� porusza� inny obiekt
    public float speed = 5.0f; // szybko�� poruszania si� obiektu
    public float minDistance = 10.0f; // minimalna odleg�o��, przy kt�rej poruszanie si� obiektu ma by� uruchomione

    private Rigidbody2D rb;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // obliczanie odleg�o�ci mi�dzy obiektem poruszaj�cym si� a celem
        float distance = Vector3.Distance(target.transform.position, transform.position);

        // sprawdzenie, czy obiekt jest oddalony od celu o co najmniej minDistance jednostek
        if (distance >= minDistance)
        {
            // obliczanie wektora odleg�o�ci mi�dzy obiektem poruszaj�cym si� a celem
            Vector3 direction = target.transform.position - transform.position;

            // obliczanie k�ta pomi�dzy wektorem odleg�o�ci a osi� x
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // obliczanie si�y do zadania na obiekt za pomoc� k�ta
            Vector2 force = Quaternion.AngleAxis(angle, Vector3.forward) * Vector2.right;

            // dodawanie si�y do obiektu za pomoc� RigidBody2D
            rb.AddForce(force * speed);
        }
    }
}