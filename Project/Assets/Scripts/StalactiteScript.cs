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

    private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Physics2D.Raycast(transform.position, Vector3.down, castDistance, playerLayer) != false)
        {
            StartCoroutine(StalactiteTrigger());
        }
	}

    private IEnumerator StalactiteTrigger()
    {
        yield return new WaitForSeconds(delay);

        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerSprite")
        {
            GameMaster.UpdateHealth(damage);
        }
    }
}
