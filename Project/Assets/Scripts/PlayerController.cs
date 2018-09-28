/* --------------------------------------------------------------------------TO DO----------------------------------------------------------------------------------

--------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CustomPhysics
{
    [SerializeField]
    private Collider2D idleCollider;
    [SerializeField]
    private Collider2D slidingCollider;

    public float maxSpeed = 7;      // Player's walking speed
    public float slideSpeed = 10;  // Player's sliding speed
    public float jumpSpeed = 7;  // Player's jumping speed
    public float doubleJumpSpeed = 5;  // Player's double jump speed
    public float horizontalForce = 10f;  // Force applied to player moving on ice
    public DistanceJoint2D joint;
    public float step = 0.02f;

    private bool doubleJump;  // Can the player double jump?
    private bool sliding = false;

    private SpriteRenderer spriteRenderer;
    private Animator anim;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // Get player's sprite renderer
        //animator = GetComponent<Animator>();  // Get player's animator

        if (joint == null)
        {
            joint = GetComponent<DistanceJoint2D>();
            joint.enabled = false;
        }

        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }

        idleCollider.enabled = true;
        slidingCollider.enabled = false;
    }

    protected override void ComputeVelocity()
    {
        base.ComputeVelocity();

        if (Input.GetMouseButtonDown(0))  // Left click to use grappling hook
        {
            GrapplingHook();
        }

        if (joint.distance > 0.5f && Input.GetAxis("Vertical") != 0)
        {
            joint.distance -= step * Input.GetAxis("Vertical");
        }

        float move;// = Vector2.zero;

        move = Input.GetAxis("Horizontal");  // = 1 if moving right, = -1 if moving left

		if (Input.GetButtonDown("Jump") && grounded) // If pressing spacebar and grounded, jump
        {  
			velocity.y = jumpSpeed;
			doubleJump = false;
		}
        else if (Input.GetButtonDown("Jump") && !doubleJump) // If player hasn't already double jumped
        {  
			velocity.y += doubleJumpSpeed;  // Add double jump speed to velocity
			doubleJump = true;
		}
        else if (Input.GetButtonUp("Jump")) // When spacebar is released, reduce y velocity so player falls faster
        {  
			if (velocity.y > 0)
            {
				velocity.y = velocity.y / 2;
			}
		}

        bool flipSprite = (spriteRenderer.flipX ? (move > 0.01f) : (move < -0.01f));  // Flip sprite in direrction of motion

        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        if (onIce && grounded)
        {
            float force = move * horizontalForce;
            //Debug.Log("MOVING ON ICE MOTHERFUCKER");
            targetVelocity += new Vector2((force/rb.mass) * Time.deltaTime, velocity.y);  // Converts force to velocity and adds it to current velocity (f=m(v/t))
            //Debug.Log(targetVelocity);
        }
        else
        {
            if (Input.GetKey(KeyCode.X)) //&& grounded)
            {
                sliding = true;  // If pressing X, set velocity to sliding speed

                if (gm.currentStamina == 0)
                {
                    sliding = false;
                }
            }
            else
            {
                sliding = false;  // If not pressing X, set velocity to walking speed
            }

            Slide(sliding, ceiling, move);
        }

        anim.SetFloat("Speed", Mathf.Abs(move));
        anim.SetBool("Grounded", grounded);
        anim.SetBool("Slide", sliding);
    }

    private void Slide(bool _sliding, bool ceiling, float _move)
    {
        //Vector2 _targetVelocity;

        if(!_sliding && grounded)
        {
            if(ceiling)
            {
                _sliding = true;
            }
        }

        if(_sliding)
        {
            if(idleCollider != null && slidingCollider!= null)
            {
                idleCollider.enabled = false;
                slidingCollider.enabled = true;
            }

            if (gm.currentStamina > 0 && Mathf.Abs(_move) > 0)
            {
                if(grounded)
                {
                    targetVelocity.x = _move * slideSpeed;
                    gm.currentStamina--;
                }
            }
            else
            {
                targetVelocity.x = _move * maxSpeed;
            }
        }
        else if (!_sliding)
        {
            if(idleCollider != null && slidingCollider != null)
            {
                idleCollider.enabled = true;
                slidingCollider.enabled = false;
            }

            if (gm.currentStamina < gm.maxStamina && !Input.GetKey(KeyCode.X))
            {
                gm.currentStamina++;
            }

           
            targetVelocity.x = _move * maxSpeed;
        }
    }
}
