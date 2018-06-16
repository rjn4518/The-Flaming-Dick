using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    public float baseSpeed = 3f;
    public float speedMultiplier = 0.01f;

    private Vector3 velocity;

    private void FixedUpdate()
    {
        velocity.x = 0f;
        velocity.y = -baseSpeed * Mathf.Exp(-speedMultiplier * transform.position.y);
        velocity.z = 0f;

        transform.position += velocity * Time.deltaTime;
    }
}
