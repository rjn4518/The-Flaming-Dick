using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{ 
	void Start ()
    {
        Debug.Log(GameManager.GetPizzaSeeds());
        switch (tag)
        {
            case "Pizza":
                if(GameManager.GetPizzaSeeds() >= 1)
                {
                    Instantiate(GameManager.GetSeeds(0), transform.position, transform.rotation);
                }
                break;

            case "Milk":
                if (GameManager.GetMilkSeeds() >= 1)
                {
                    Instantiate(GameManager.GetSeeds(1), transform.position, transform.rotation);
                }
                break;

            case "Human":
                if (GameManager.GetHumanSeeds() >= 1)
                {
                    Instantiate(GameManager.GetSeeds(2), transform.position, transform.rotation);
                }
                break;

            case "iPhone":
                if (GameManager.GetiPhoneSeeds() >= 1)
                {
                    Instantiate(GameManager.GetSeeds(3), transform.position, transform.rotation);
                }
                break;

            case "Vinyl":
                if (GameManager.GetVinylSeeds() >= 1)
                {
                    Instantiate(GameManager.GetSeeds(4), transform.position, transform.rotation);
                }
                break;

            default:
                break;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
