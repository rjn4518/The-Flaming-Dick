﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimmm : MonoBehaviour
{
    public float swimSpeed = 5f;
    public float boostSpeed = 7f;
    public float sinkSpeed = 0.75f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private GameObject surfaceMarker;
    private Vector2 move;
    private Vector2 direction;
    public float surfaceHeight;
    private bool boost = false;

    // Use this for initialization
    void Awake ()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if(surfaceMarker == null)
        {
            surfaceMarker = GameObject.FindGameObjectWithTag("SurfaceMarker");
        }

        surfaceHeight = surfaceMarker.transform.position.y;
        rb.gravityScale = 0f;

    }

    private void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(Input.GetKey(KeyCode.X))
        {
            boost = true;
        }
        else
        {
            boost = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
       if(transform.position.y <= surfaceHeight)
        {
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;

            if (boost && GameMaster.GetCurrentStamina() > 0)
            {
                move = new Vector2(direction.x * boostSpeed, direction.y * boostSpeed - sinkSpeed);

                if (direction.magnitude > 0)
                {
                    GameMaster.UpdateStamina(-1f);
                }
            }
            else
            {
                move = new Vector2(direction.x * swimSpeed, direction.y * swimSpeed - sinkSpeed);

                if (GameMaster.GetCurrentStamina() < GameMaster.GetMaxStamina() && !boost)
                {
                    GameMaster.UpdateStamina(1f);
                }
            }

            Flip();
            Rotate();

            rb.position += move * Time.deltaTime;
        }
        else
        {
            while(transform.position.y > surfaceHeight - 0.5f)
            {
                rb.gravityScale = 1f;
            }
        }
	}

    void Flip()
    {
        if (Input.GetAxis("Horizontal") < -0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") > 0.01f)
        {
            spriteRenderer.flipX = true;
        }

    }

    void Rotate()
    {
        if (direction.y > 0.1f)
        {
            if (direction.x != 0f)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 45f));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
            }
        }
        else if(direction.y < -0.1f)
        {
            if (direction.x != 0f)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -45f));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -90f));
            }
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }

        if (spriteRenderer.flipX == false)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -transform.rotation.eulerAngles.z));
        }
    }
}
