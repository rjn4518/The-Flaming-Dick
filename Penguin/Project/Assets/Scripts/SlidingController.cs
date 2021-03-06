﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingController : MonoBehaviour
{
    public float baseSpeed = 3f;
    public float speedMultiplier = 0.01f;
    public float verticalSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 velocity;
    private float yDirection;
    private static Vector3 startingPos = new Vector3(0f, 0f, 0f);
    
    private void Awake()
    {
        transform.position = startingPos;

        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();  // Gets the rigidbody of the current object
        }
    }

    private void FixedUpdate()
    {
        velocity.x = baseSpeed*Mathf.Exp(speedMultiplier * rb.position.x);

        yDirection = Input.GetAxis("Vertical");

        velocity.y = yDirection * verticalSpeed;

        rb.position += velocity * Time.deltaTime;
    }

    public static Vector3 GetStartingPos()
    {
        return startingPos;
    }

    public static void SetStartingPos(Vector3 position)
    {
        startingPos = position;
    }
}
