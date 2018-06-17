using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingController : MonoBehaviour
{
    public float baseSpeed = 3f;
    public float speedMultiplier = 0.01f;
    public float horizontalSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 velocity;
    private float xDirection;

    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();  // Gets the rigidbody of the current object
        }
    }

    private void FixedUpdate()
    {
        velocity.y = -baseSpeed*Mathf.Exp(-speedMultiplier*rb.position.y);

        xDirection = Input.GetAxis("Horizontal");

        velocity.x = xDirection * horizontalSpeed;

        rb.position += velocity * Time.deltaTime;
    }
}
