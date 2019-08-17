using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealLion : MonoBehaviour
{
    public float health = 100f;
    public float eggDamage = 20f;
    public float sealLionSpeed = 0.1f;

    private SpriteRenderer sprite;
    private Vector3 leftPos;
    private Vector3 rightPos;
    private Vector3 currentPos;
    private Transform startPos;
    private int count = 0;
    private static float damage = -50f;
    private float startTime = 0f;

	void Start ()
	{
        sprite = GetComponent<SpriteRenderer>();

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
        startTime = Time.time;

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
        float dist = 0f;
        float length = 0f;
        float fraction = 0f;
        float currentTime = Time.time;

        if (count == 0)
        {
            dist = sealLionSpeed * (currentTime - startTime);

            length = Vector3.Distance(startPos.position, leftPos);

            fraction = dist / length;

            transform.position = Vector3.Lerp(startPos.position, leftPos, fraction);

            if(transform.position.x <= leftPos.x + 0.01f)
            {
                count++;
                currentPos = transform.position;
                startTime = Time.deltaTime;
                sprite.flipX = !sprite.flipX;
            }
        }
        else if((count & 1) == 1)
        {
            dist = sealLionSpeed * (currentTime - startTime);

            length = Vector3.Distance(currentPos, rightPos);

            fraction = dist / length;

            transform.position = Vector3.Lerp(currentPos, rightPos, fraction);

            if (transform.position.x >= rightPos.x - 0.1f)
            {
                count++;
                currentPos = transform.position;
                startTime = Time.time;
                sprite.flipX = !sprite.flipX;
            }
        }
        else if((count & 1) == 0)
        {
            dist = sealLionSpeed * (currentTime - startTime);

            length = Vector3.Distance(currentPos, leftPos);

            fraction = dist / length;

            transform.position = Vector3.Lerp(currentPos, leftPos, fraction);

            if(transform.position.x <= leftPos.x + 0.1f)
            {
                count++;
                currentPos = transform.position;
                startTime = Time.time;
                sprite.flipX = !sprite.flipX;
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
