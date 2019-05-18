using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactiteScript : MonoBehaviour
{
    [SerializeField]
    private LayerMask playerLayer;

    [SerializeField]
    private float castDistance = 10000f;

    [SerializeField]
    private float delay = 0.25f;

    [SerializeField]
    private float damage = -25f;

    [SerializeField]
    private float gravity = 2f;

    private Rigidbody2D rb;
    private RaycastHit2D hit;
    private BoxCollider2D collider;
    private Vector3 offset;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;

        collider = GetComponent<BoxCollider2D>();
        offset = new Vector3(0f, collider.size.y, 0f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        hit = Physics2D.Raycast(transform.position - offset, Vector2.down, castDistance);

        if (hit == true && hit.collider.tag == "PlayerSprite")
        {
            StartCoroutine(StalactiteTrigger());
        }
	}

    private IEnumerator StalactiteTrigger()
    {
        yield return new WaitForSeconds(delay);

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = gravity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerSprite")
        {
            GameMaster.UpdateHealth(damage);
        }
    }
}
