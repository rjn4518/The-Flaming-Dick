﻿/* --------------------------------------------------------------------------TO DO----------------------------------------------------------------------------------

--------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CustomPhysics
{
    public float maxSpeed = 7;      // Player's walking speed
    public float slideSpeed = 10;  // Player's sliding speed
    public float jumpSpeed = 7;  // Player's jumping speed
    public float doubleJumpSpeed = 5;  // Player's double jump speed
    public float horizontalForce = 10f;  // Force applied to player moving on ice

    private bool doubleJump;  // Can the player double jump?

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // Get player's sprite renderer
        animator = GetComponent<Animator>();  // Get player's animator
    }

    protected override void ComputeVelocity()
    {
        base.ComputeVelocity();

        if (Input.GetMouseButtonDown(0))  // Left click to use grappling hook
        {
            GrapplingHook();
        }

        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");  // = 1 if moving right, = -1 if moving left

        if (Input.GetButtonDown("Jump") && grounded)  // If pressing spacebar and grounded, jump
        {
            velocity.y = jumpSpeed;
            doubleJump = false;
        }
        else if (Input.GetButtonDown("Jump") && !doubleJump)  // If player hasn't already double jumped
        {
            velocity.y += doubleJumpSpeed;  // Add double jump speed to velocity
            doubleJump = true;
        }
        else if (Input.GetButtonUp("Jump"))  // When spacebar is released, reduce y velocity so player falls faster
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y / 2;
            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < -0.01f));  // Flip sprite in direrction of motion

        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        //animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Math.Abs(velocity.x / maxSpeed);

        if (onIce && grounded)
        {
            float force = move.x * horizontalForce;
            Debug.Log("MOVING ON ICE MOTHERFUCKER");
            targetVelocity += new Vector2((force/rb.mass) * Time.deltaTime, velocity.y);  // Converts force to velocity and adds it to current velocity (f=m(v/t))
            Debug.Log(targetVelocity);
        }
        else
        {
            if (Input.GetKey(KeyCode.X))
            {
                targetVelocity = move * slideSpeed;  // If pressing X, set velocity to sliding speed
            }
            else
            {
                targetVelocity = move * maxSpeed;  // If not pressing X, set velocity to walking speed
            }
        }
    }
}
