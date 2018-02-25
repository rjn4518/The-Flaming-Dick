using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : GameMaster
{
    public AudioClip fishPickUp;

	protected override void OnTriggerEnter2D (Collider2D other)
	{
        // Destroys the fish when you run into it
		if (other.name =="Idle")
		{
			//other.GetComponent<playerControllerRedo>().points++;  <-- We can add a points system later
			Destroy (gameObject);
		}
	}
}