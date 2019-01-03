using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CustomPhysics
{

    private Collider2D idleCollider;
    private Collider2D slidingCollider;

    public float maxSpeed = 7;      // Player's walking speed
    public float slideSpeed = 10;  // Player's sliding speed
    public float jumpSpeed = 7;  // Player's jumping speed
    public float doubleJumpSpeed = 5;  // Player's double jump speed
    public float horizontalForce = 10f;  // Force applied to player moving on ice

    private bool doubleJump;  // Can the player double jump?
    private bool sliding = false;

    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();  // Get player's sprite renderer
        }

        if (idleCollider == null)
        {
            idleCollider = GetComponent<CircleCollider2D>();
        }

        if (slidingCollider == null)
        {
            slidingCollider = GetComponent<CapsuleCollider2D>();
        }

        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }

        idleCollider.enabled = true;
        slidingCollider.enabled = false;
    }

    protected override void ComputeVelocity()
    {
        base.ComputeVelocity();

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

                if (GameMaster.GetCurrentStamina() == 0)
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
            if(idleCollider != null && slidingCollider!= null  && grounded)
            {
                idleCollider.enabled = false;
                slidingCollider.enabled = true;
            }
            else
            {
                idleCollider.enabled = true;
                slidingCollider.enabled = false;
            }

            if (GameMaster.GetCurrentStamina() > 0 && Mathf.Abs(_move) > 0)
            {
                if(grounded)
                {
                    targetVelocity.x = _move * slideSpeed;
                    GameMaster.UpdateStamina(-1f);
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

            if (GameMaster.GetCurrentStamina() < GameMaster.GetMaxStamina() && !Input.GetKey(KeyCode.X))
            {
                GameMaster.UpdateStamina(1);
            }

           
            targetVelocity.x = _move * maxSpeed;
        }
    }
}
