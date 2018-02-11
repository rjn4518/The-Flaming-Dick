using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : GameMaster
{
    public AudioClip fishPickUp;

	protected override void OnTriggerEnter2D (Collider2D other)
	{

		if (other.name =="Idle")
		{
			//other.GetComponent<playerControllerRedo>().points++;
			Destroy (gameObject);
		}
	}
}