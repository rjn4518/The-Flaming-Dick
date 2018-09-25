using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : GameMaster
{
    public AudioClip fishPickUp;

	protected override void OnTriggerEnter2D (Collider2D other)
	{
        // Destroys the fish when you run into it
		if(other.name == "Player Sprite")
		{
			//other.GetComponent<playerControllerRedo>().points++;  <-- We can add a points system later
			Destroy(gameObject);

            switch(tag)
            {
                case "Bronze":
                    gm.fishCount++;
                    break;

                case "Silver":
                    gm.fishCount += 2;
                    break;

                case "Gold":
                    gm.fishCount += 10;
                    break;

                case "Red":
                    if(gm.currentHealth <= gm.maxHealth - 25)
                    {
                        gm.currentHealth += 25;
                    }
                    else
                    {
                       gm.currentHealth = gm.maxHealth;
                    }
                    gm.fishCount++;
                    break;

                default:
                    break;
            }
            gm.fishCountText.text = "X " + gm.fishCount;
		}
	}
}