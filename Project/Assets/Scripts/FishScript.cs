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
                    gm.property.FishCount++;
                    break;

                case "Silver":
                    gm.property.FishCount += 2;
                    break;

                case "Gold":
                    gm.property.FishCount += 10;
                    break;

                case "Red":
                    if(gm.property.CurrentHealth <= gm.property.MaxHealth - 25)
                    {
                        gm.property.CurrentHealth += 25;
                    }
                    else
                    {
                        gm.property.CurrentHealth = gm.property.MaxHealth;
                        Debug.Log(property.CurrentHealth);
                    }
                    gm.property.FishCount++;
                    break;

                default:
                    break;
            }
			gm.fishCountText.text = gm.property.FishCount.ToString();
			// Changed from gm.fishCountText.text = "X " + gm.property.FishCount;
		}
	}
}