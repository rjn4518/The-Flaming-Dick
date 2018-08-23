using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : GameMaster
{
    public float baseSpeed = 3f;
    public float speedMultiplier = 0.01f;

    private Vector3 velocity;

    private void Update()
    {
        if (gm.playerSprite.transform.position.x - transform.position.x < -30f)
        {
            transform.position = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        velocity.y = 0f;
        velocity.x = baseSpeed * Mathf.Exp(speedMultiplier * transform.position.x);
        velocity.z = 0f;

        transform.position += velocity * Time.deltaTime;
    }
}
