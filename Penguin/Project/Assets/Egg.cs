using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public LayerMask layerMask;

    public float eggSpeedX = 10f;
    public float eggSpeedY = 10f;
    public int duration = 1;

    private Rigidbody2D rb;
    private CircleCollider2D collider;

    private int count = 0;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
    }

    void FixedUpdate ()
    {
        rb.velocity = new Vector2(eggSpeedX, eggSpeedY);

        eggSpeedY -= (9.81f*rb.gravityScale) * Time.deltaTime;
    }

    private void Update()
    {
        if(!collider.isTrigger && collider.IsTouchingLayers(layerMask))
        {
            Destroy(gameObject);
        }
        if(count > 300)
        {
            Destroy(gameObject);
        }

        count++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "PlayerSprite")
        {
            collider.isTrigger = false;
        }
    }
}
