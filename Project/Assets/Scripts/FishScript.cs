using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : GameMaster
{
    public AudioClip fishPickUp;

	protected override void OnTriggerEnter2D (Collider2D other)
	{
        // Destroys the fish when you run into it
		if (other.name == "Player Sprite")
		{
			//other.GetComponent<playerControllerRedo>().points++;  <-- We can add a points system later
			Destroy(gameObject);

            switch(tag)
            {
                case "Bronze":
                    // +1
                    break;

                case "Silver":
                    // +2
                    break;

                case "Gold":
                    // +5
                    break;

                case "Red":
                    // Restore health
                    break;

                default:
                    break;
            }
		}
	}
}