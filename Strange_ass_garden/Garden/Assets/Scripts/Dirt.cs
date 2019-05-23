﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{ 
    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonDown(0) && GameManager.GetCarry())
        {
            if(GameManager.GetPlant())
            {
                GameManager.UpdateCarry(false);
                GameManager.UpdateDirt(transform);
            }
        }
    }
}
