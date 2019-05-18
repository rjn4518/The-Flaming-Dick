using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealLion : MonoBehaviour
{
    private static float damage = -50f;



    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "PlayerSprite")
        {
            GameMaster.UpdateHealth(damage);
        }      
    }

	void Start ()
	{
		
	}

	void Update ()
	{
		
	}
}
