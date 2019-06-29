using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealLion : MonoBehaviour
{
    public float health = 100f;
    public float eggDamage = 20f;
    public float sealLionSpeed = 0.1f;

    private Vector3 leftPos;
    private Vector3 rightPos;
    private Vector3 currentPos;
    private Transform startPos;
    private int count = 0;
    private static float damage = -50f;
    private Rigidbody2D rb;

	void Start ()
	{
        rb = GetComponent<Rigidbody2D>();

        Transform[] endPoints = new Transform[2];

        endPoints = GetComponentsInChildren<Transform>();

        for(int i=0; i<endPoints.Length; i++)
        {
            if(endPoints[i].tag == "Left")
            {
                leftPos = endPoints[i].position;
            }
            else if(endPoints[i].tag == "Right")
            {
                rightPos = endPoints[i].position;
            }
        }

        startPos = transform;
	}

	void Update ()
	{
		if(health <= 0f)
        {
            Destroy(gameObject);
        }
	}

    private void FixedUpdate()
    {
        if(count == 0)
        {
            transform.position = Vector3.Lerp(startPos.position, leftPos, sealLionSpeed);

            if(transform.position.x <= leftPos.x + 0.01f)
            {
                count++;
                currentPos = transform.position;
            }
        }
        else if((count & 1) == 1)
        {
            transform.position = Vector3.Lerp(currentPos, rightPos, -sealLionSpeed);
            Debug.Log("Bitch");

            if (transform.position.x >= rightPos.x - 0.1f)
            {
                count++;
                currentPos = transform.position;
            }
        }
        else if((count & 1) == 0)
        {
            transform.position = Vector3.Lerp(currentPos, leftPos, sealLionSpeed);

            if(transform.position.x <= leftPos.x + 0.1f)
            {
                count++;
                currentPos = transform.position;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerSprite")
        {
            GameMaster.UpdateHealth(damage);
        }
        else if (other.tag == "Egg")
        {
            health -= eggDamage;
        }
    }
}
