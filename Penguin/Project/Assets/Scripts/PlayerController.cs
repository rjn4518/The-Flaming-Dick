using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CustomPhysics
{

    private Collider2D idleCollider;
    private Collider2D slidingCollider;

    public GameObject egg;

    public float maxSpeed = 7;      // Player's walking speed
    public float slideSpeed = 10;  // Player's sliding speed
    public float jumpSpeed = 7;  // Player's jumping speed
    public float doubleJumpSpeed = 5;  // Player's double jump speed
    public float floatSpeed = 3f;
    public float glideSpeed = -1f;
    public float horizontalForce = 10f;  // Force applied to player moving on ice
    public float eggSpeed = 10f;

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

        float move;

        move = Input.GetAxis("Horizontal");  // = 1 if moving right, = -1 if moving left

		if (Input.GetButtonDown("Jump") && grounded) // If pressing spacebar and grounded, jump
        {  
			velocity.y = jumpSpeed;
			Abilities.SetDoubleJump(false);
		}
        else if (Input.GetButtonDown("Jump") && !Abilities.GetDoubleJump()) // If player hasn't already double jumped
        {  
			velocity.y += doubleJumpSpeed;  // Add double jump speed to velocity
			Abilities.SetDoubleJump(true);
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
            targetVelocity += new Vector2((force/rb.mass) * Time.deltaTime, velocity.y);  // Converts force to velocity and adds it to current velocity (f=m(v/t))
        }
        else
        {
            if (Input.GetKey(KeyCode.X)) //&& grounded)
            {
                Abilities.SetSlide(true);  // If pressing X, set velocity to sliding speed

                if (GameMaster.GetCurrentStamina() == 0)
                {
                    Abilities.SetSlide(false);
                }
            }
            else
            {
                Abilities.SetSlide(false);  // If not pressing X, set velocity to walking speed
            }

            if(Input.GetKeyDown(KeyCode.C))
            {
                Abilities.SetEggThrow(true);

                if(GameMaster.GetCurrentStamina() < (GameMaster.GetMaxStamina() / 3))
                {
                    Abilities.SetEggThrow(false);
                }
            }
            else
            {
                Abilities.SetEggThrow(false);
            }

            if(!grounded)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Abilities.SetFly(true);
                }
                else if (Input.GetKey(KeyCode.Tab))
                {
                    Abilities.SetGlide(true);
                }
                else
                {
                    Abilities.SetFly(false);
                    Abilities.SetGlide(false);
                }
            }

            Slide(Abilities.GetSlide(), ceiling, move);
            Fly(Abilities.GetFly());
            Glide(Abilities.GetGlide());
            Egg(Abilities.GetEggThrow());
        }


        if (GameMaster.GetCurrentStamina() < GameMaster.GetMaxStamina() && !Input.GetKey(KeyCode.X) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Tab) && grounded)
        {
            GameMaster.UpdateStamina(0.25f);
        }

        anim.SetFloat("Speed", Mathf.Abs(move));
        anim.SetBool("Grounded", grounded);
        anim.SetBool("Slide", Abilities.GetSlide());
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
           
            targetVelocity.x = _move * maxSpeed;
        }
    }

    private void Fly(bool _fly)
    {
        if(_fly && GameMaster.GetCurrentStamina() > 0f)
        {
            velocity.y = floatSpeed;
            GameMaster.UpdateStamina(-1f);
        }
    }

    private void Glide(bool _glide)
    {
        if(_glide && GameMaster.GetCurrentStamina() > 0f)
        {
            velocity.y = glideSpeed;
            GameMaster.UpdateStamina(-1f);
        }
    }

    private void Egg(bool _egg)
    {
        if(_egg && GameMaster.GetCurrentStamina() > 0f && !Abilities.GetSlide())
        {
            Instantiate(egg, transform.position, transform.rotation);
            GameMaster.UpdateStamina(-GameMaster.GetMaxStamina() / 3);
        }
    }
}
