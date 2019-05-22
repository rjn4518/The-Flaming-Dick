using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private bool bitch = true;

    private void OnTriggerExit2D(Collider2D collision)
    {
        bitch = true;
    }

    void Update ()
    {
        if(GameManager.GetPizzaSeeds() >= 1 && tag == "Pizza" && bitch)
        {
            Instantiate(GameManager.GetSeeds(0), transform.position, transform.rotation);
            bitch = false;
        }

        if(GameManager.GetMilkSeeds() >= 1 && tag == "Milk" && bitch)
        {
            Instantiate(GameManager.GetSeeds(2), transform.position, transform.rotation);
            bitch = false;
        }

        if(GameManager.GetVinylSeeds() >= 1 && tag == "Vinyl" && bitch)
        {
            Instantiate(GameManager.GetSeeds(3), transform.position, transform.rotation);
            bitch = false;
        }

        if(GameManager.GetiPhoneSeeds() >= 1 && tag == "iPhone" && bitch)
        {
            Instantiate(GameManager.GetSeeds(1), transform.position, transform.rotation);
            bitch = false;
        }
    }
}
