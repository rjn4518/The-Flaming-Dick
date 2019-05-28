using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealLion : MonoBehaviour
{
    public float health = 100f;
    public float eggDamage = 20f;

    private static float damage = -50f;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "PlayerSprite")
        {
            GameMaster.UpdateHealth(damage);
        }
        else if(other.tag == "Egg")
        {
            health -= eggDamage;
        }
    }

	void Start ()
	{
		
	}

	void Update ()
	{
		if(health <= 0f)
        {
            Destroy(gameObject);
        }
	}
}
