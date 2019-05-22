using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SeedText : MonoBehaviour
{
    private Text text;

	void Start ()
    {
        text = GetComponent<Text>();
	}
	
	void Update ()
    {
        switch (tag)
        {
            case "Pizza":
                text.text = "" + GameManager.GetPizzaSeeds();
                break;

            case "Milk":
                text.text = "" + GameManager.GetMilkSeeds();
                break;

            case "iPhone":
                text.text = "" + GameManager.GetiPhoneSeeds();
                break;

            case "Vinyl":
                text.text = "" + GameManager.GetVinylSeeds();
                break;

            default:
                break;
        }
    }
}
