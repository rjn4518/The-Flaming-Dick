using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public AudioClip fishPickUp;

	void OnTriggerEnter2D (Collider2D other)
	{
        // Destroys the fish when you run into it
		if(other.name == "Player Sprite")
		{
			//other.GetComponent<playerControllerRedo>().points++;  <-- We can add a points system later
			Destroy(gameObject);

            switch(tag)
            {
                case "Bronze":
                    GameMaster.UpdateFish(1);
                    break;

                case "Silver":
                    GameMaster.UpdateFish(2);
                    break;

                case "Gold":
                    GameMaster.UpdateFish(10);
                    break;

                case "Red":
                    GameMaster.UpdateHealth(25f);

                    GameMaster.UpdateFish(1);
                    break;

                default:
                    break;
            }
		}
	}
}