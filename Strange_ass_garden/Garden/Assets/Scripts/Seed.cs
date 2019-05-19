using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{ 
    void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetMouseButtonDown(0) && GameManager.GetCarry() == false)
        {
            GameManager.UpdateCarry(true);
        }
    }

    private void Update()
    {
        if(GameManager.GetCarry() == true)
        {
            // Seed follows player
        }
    }
}
