/* --------------------------------------------------------------------------TO DO----------------------------------------------------------------------------------
 * 2) {Set up double jump}
--------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CustomPhysics
{
    public float maxSpeed = 7;
    public float slideSpeed = 10;
    public float jumpSpeed = 7;
    public float doubleJumpSpeed = 5;
    public float horizontalForce = 10f;

    private bool doubleJump;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        base.ComputeVelocity();

        if (Input.GetMouseButtonDown(0))
        {
            GrapplingHook();
        }

        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpSpeed;
            doubleJump = false;
            /*Vector2 jumpDirection = new Vector2(Mathf.Sqrt(1 - Mathf.Pow(Vector2.Dot(new Vector2(0f, 1f), groundNormal), 2)), Vector2.Dot(new Vector2(0f, 1f), groundNormal));
            velocity = velocity + jumpDirection * jumpSpeed;
            Debug.Log(jumpDirection);*/
        }
        else if (Input.GetButtonDown("Jump") && !doubleJump)
        {
            velocity.y += doubleJumpSpeed;
            doubleJump = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y / 2;
            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < -0.01f));

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
            targetVelocity += new Vector2(force * Time.deltaTime, velocity.y);
            Debug.Log(targetVelocity);
        }
        else
        {
            if (Input.GetKey(KeyCode.X))
            {
                targetVelocity = move * slideSpeed;
            }
            else
            {
                targetVelocity = move * maxSpeed;
            }
        }
    }
}
