﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Transform dirt;

    private bool carry = false;
    private bool plant = false;
    private bool harvest = false;

    private int count = 0;

    private void Awake()
    {
        if(spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sortingOrder = 1;
        }

        if(dirt == null)
        {
            dirt = GetComponent<Transform>();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetMouseButtonDown(0) && !GameManager.GetCarry() && !GameManager.GetPlant())
        {
            GameManager.UpdateCarry(true);
            GameManager.UpdatePlant(true);

            carry = GameManager.GetCarry();
            plant = GameManager.GetPlant();
        }
        else if(Input.GetMouseButtonDown(0) && !GameManager.GetCarry() && harvest)
        {
            GameManager.UpdateCarry(true);

            carry = GameManager.GetCarry();
        }
    }

    private void Update()
    {
        DirtPosition();

        if(carry)
        {
            transform.position = GameManager.GetCarryLocation().transform.position;
            spriteRenderer.sortingOrder = 3;

            carry = GameManager.GetCarry();
        }
        else if(!carry && plant)
        {
            transform.position = dirt.position;
            spriteRenderer.sortingOrder = 1;

            GameManager.UpdatePlant(false);

            switch(tag)
            {
                case "Pizza":
                    if(count == 10)
                    {
                        Debug.Log("Sapling");
                    }
                    else if(count == 100)
                    {
                        GameManager.UpdateHarvest(true);

                        harvest = GameManager.GetHarvest();

                        Debug.Log("Harvest that bittchh");
                        plant = false;
                    }
                    break;

                case "Milk":
                    if(count == 10)
                    {
                        Debug.Log("Sapling");
                    }
                    break;

                case "Human":
                    if(count == 10)
                    {
                        Debug.Log("Sapling");
                    }
                    break;

                case "iPhone":
                    if(count == 10)
                    {
                        Debug.Log("Sapling");
                    }
                    break;

                case "Vinyl":
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

    private void DirtPosition()
    {
        if(!carry && plant && count == 0)
        {
            dirt = GameManager.GetDirt();
        }
        else
        {
            dirt = transform;
        }
    }
}