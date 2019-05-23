using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Vector3 mousePos;
	
	void Update ()
    {
        MouseFollow();
        Purchase();
	}

    private void MouseFollow()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

        transform.position = Vector3.Lerp(transform.position, mousePos, 0.05f);
    }

    private void Purchase()
    {
        if (Input.GetKeyDown("p") && GameManager.GetMoney() >= 5)
        {
            GameManager.UpdateMoney(-5);
            GameManager.UpdatePizzaSeeds(1);
        }

        if(Input.GetKeyDown("i") && GameManager.GetMoney() >= 500)
        {
            GameManager.UpdateMoney(-500);
            GameManager.UpdateiPhoneSeeds(1);
        }

        if(Input.GetKeyDown("m") && GameManager.GetMoney() >= 2)
        {
            GameManager.UpdateMoney(-2);
            GameManager.UpdateMilkSeeds(1);
        }

        if(Input.GetKeyDown("v") && GameManager.GetMoney() >= 2)
        {
            GameManager.UpdateMoney(-60);
            GameManager.UpdateVinylSeeds(1);
        }
    }
}
