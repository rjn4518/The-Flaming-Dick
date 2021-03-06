﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics : MonoBehaviour
{
    public float gravityModifier = 1f;  // Allows for more or less gravity

    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private Transform ceilingCheck;

    protected Vector2 targetVelocity;  // Target velocity of the object
    protected bool grounded;  // Determines whether or not object is grounded
    protected bool onIce = false;
    protected bool ceiling = false;
    protected Vector2 groundNormal;  // Stores the unit vector perpendicular to ground
    protected Rigidbody2D rb;  // Reference to the object's rigidbody
    protected Vector2 velocity;  // Object's current velocity
    protected ContactFilter2D contactFilter;  // Determines which layers the object can collide with
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];  // Array to store all collidable things in front of the object
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);  // List of all things the object is colliding with or will collide with next frame
    protected bool y_Movement;

    protected const float minGroundNormalY = 0.65f;  // Determines the steepest slope an object can stand on
    protected const float minMoveDistance = 0.001f;  // Minimum distance the object can move
    protected const float shellRadius = 0.01f;  // Specifies a small buffer distance between objects so they don't end up inside each other
    protected const float ceilingRadius = 0.2f;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();  // Gets the rigidbody of the current object
    }

    // Use this for initialization
    void Start ()
    {
        contactFilter.useTriggers = true;  // Don't collide with objects used as triggers
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));  // Gets a list of all layers the object can collide with
        contactFilter.useLayerMask = true;  // Uses the layer mask above
	}
	
	// Update is called once per frame
	void Update ()
    {
        //targetVelocity = Vector2.zero;
        ComputeVelocity();  // Function defined in the player controller
        DetectEdge();
	}

    protected virtual void ComputeVelocity()
    {

    }

    protected virtual void DetectEdge()
    {

    }

    private void FixedUpdate()
    {
        float rotationAngle = Rotation();

        if (Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
        {
            ceiling = true;
        }
        else
        {
            ceiling = false;
        }

        if (onIce && rotationAngle != 0)
        //if(onIce && grounded)
        {
            Vector2 adjustedGravity = new Vector2(-Mathf.Sin(rotationAngle * Mathf.Deg2Rad), 
            -Mathf.Cos(rotationAngle * Mathf.Deg2Rad)) * Physics2D.gravity.magnitude * gravityModifier;  // Makes ice hills slippery

            velocity += adjustedGravity * Time.deltaTime;

            Debug.Log(adjustedGravity);
        }
        else
        {
            velocity.x = targetVelocity.x;   // Sets velocity of object and computes velocity change due to gravity each frame

            velocity += Physics2D.gravity * gravityModifier * Time.deltaTime;
        }

        grounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;  // Calculates object's position next frame

        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);  // Makes sure object always walks on the ground
        Vector2 move = moveAlongGround * deltaPosition.x;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);  // Sets rotation of the object

        y_Movement = false;

        Movement(move, y_Movement);  // Calculates horizontal movement of the object

        move = Vector2.up * deltaPosition.y;

        y_Movement = true;

        Movement(move, y_Movement);  // Calculates vertical movement of the object

        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
    }

    void Movement(Vector2 move, bool yMovement)  // Determines if there is anything in the object's path and adjusts its position accordingly
    {
        float distance = move.magnitude;

        if (distance > minMoveDistance)
        {
            int count = rb.Cast(move, contactFilter, hitBuffer, distance + shellRadius);  // Casts object's rigidbody in front of it and returns amount of collisions

            hitBufferList.Clear();

            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);

                if (hitBufferList[i].collider.CompareTag("Ice"))  // Check if any the hits are ice
                {
                    onIce = true;
                }
                else
                {
                    onIce = false;
                }
            }

            for (int i = 0; i < hitBufferList.Count; i++)  // Cycle through all hits
            {
                if (!hitBufferList[i].collider.isTrigger)  // If the hit isn't a trigger
                {
                    Vector2 currentNormal = hitBufferList[i].normal;

                    if (currentNormal.y > minGroundNormalY)  // If the slope of the ground isn't too steep
                    {
                        grounded = true;

                        if (yMovement)
                        {
                            groundNormal = currentNormal;  // Allows object to move on hills... i think lol 
                            currentNormal.x = 0;
                        }
                    }

                    float projection = Vector2.Dot(velocity, currentNormal);

                    if (projection != 0)  // Fuck if I know lol
                    {
                        velocity = velocity - projection * currentNormal;  // Think I copied this from somewhere3
                    }

                    float modifiedDistance = hitBufferList[i].distance - shellRadius;  // Reduced the target distance if there is a collider is the object path
                    distance = modifiedDistance < distance ? modifiedDistance : distance;  // Makes sure object's collider doesn't end up inside another collider
                }

            }
        }

        rb.position = rb.position + move.normalized * distance;  // Sets new object position
    }

    // Using the dot product, we can determine the direction and angle of the incline and rotate the player accordingly
    float Rotation() 
    {
        float rotationAngle;

        // If positive, we have a leftward incline; if negative, we have a rightward incline
        float hillDirection = Vector2.Dot(Vector2.right, groundNormal);

        // Gives us the anlge of the hill
        float hillAngle = Mathf.Acos(hillDirection) * Mathf.Rad2Deg;

        // If we have a rightward facing hill with angle between 135deg and 180deg
        if (hillAngle < 180 && hillAngle > 130)
        {
            rotationAngle = 45f;
        }
        // If we have a leftward facing hill with angle between 0deg and 50deg
        else if (hillAngle < 50 && hillAngle > 0)
        {
            rotationAngle = -45f;
        }
        else
        {
            rotationAngle = 0f;
        }

        return rotationAngle;
    }
}
