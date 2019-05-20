using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private bool carry = false;
    private bool plant = false;

    private int count = 0;

    private void Awake()
    {
        if(spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sortingOrder = 1;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetMouseButtonDown(0) && GameManager.GetCarry() == false && GameManager.GetPlant() == false)
        {
            GameManager.UpdateCarry(true);
            GameManager.UpdatePlant(true);

            carry = GameManager.GetCarry();
        }
    }

    private void Update()
    {
        if(carry == true)
        {
            transform.position = GameManager.GetCarryLocation().transform.position;
            spriteRenderer.sortingOrder = 3;

            carry = GameManager.GetCarry();
            plant = GameManager.GetPlant();
        }
        else if(carry == false && plant == true)
        {
            transform.position = GameManager.GetDirt().position;
            spriteRenderer.sortingOrder = 1;

            GameManager.UpdatePlant(false);

            switch(tag)
            {
                case "Pizza":
                    if(count == 10)
                    {
                        Debug.Log("Sapling");
                    }
                    break;

                default:
                    break;
            }

            count++;
        }
    }
}
