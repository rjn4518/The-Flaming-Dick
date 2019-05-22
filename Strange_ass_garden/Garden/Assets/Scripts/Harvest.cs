using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetMouseButtonDown(0) && GameManager.GetCarry() && GameManager.GetHarvest())
        {
            GameManager.UpdateFuckFace(true);
        }
    }
}
