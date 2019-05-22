using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Transform dirt;

    private bool carry = false;
    private bool plant = false;
    private bool harvest = false;
    private bool fuckface = false;

    private int count = 0;

    [SerializeField]
    private Sprite sapling;
    [SerializeField]
    private Sprite pizza;
    [SerializeField]
    private Sprite iPhone;
    [SerializeField]
    private Sprite milk;
    [SerializeField]
    private Sprite vinyl;

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

            if(harvest)
            {
                fuckface = GameManager.GetFuckFace();

                if(fuckface)
                {
                    switch (tag)
                    {
                        case "Pizza":
                            GameManager.UpdateMoney(20);
                            break;

                        case "Milk":
                            GameManager.UpdateMoney(5);
                            break;

                        case "iPhone":
                            GameManager.UpdateMoney(1000);
                            break;

                        case "Vinyl":
                            GameManager.UpdateMoney(100);
                            break;

                        default:
                            break;
                    }

                    GameManager.UpdateCarry(false);
                    GameManager.UpdateHarvest(false);
                    GameManager.UpdateFuckFace(false);
                    GameManager.UpdatePlant(false);
                    Destroy(gameObject);
                }
            }
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
                        spriteRenderer.sprite = sapling;
                    }
                    else if(count == 100)
                    {
                        GameManager.UpdateHarvest(true);

                        harvest = GameManager.GetHarvest();

                        spriteRenderer.sprite = pizza;

                        plant = false;
                    }
                    break;

                case "Milk":
                    if(count == 10)
                    {
                        spriteRenderer.sprite = sapling;
                    }
                    else if(count == 100)
                    {
                        GameManager.UpdateHarvest(true);

                        harvest = GameManager.GetHarvest();

                        spriteRenderer.sprite = milk;

                        plant = false;
                    }
                    break;

                case "iPhone":
                    if(count == 10)
                    {
                        spriteRenderer.sprite = sapling;
                    }
                    else if (count == 100)
                    {
                        GameManager.UpdateHarvest(true);

                        harvest = GameManager.GetHarvest();

                        spriteRenderer.sprite = iPhone;

                        plant = false;
                    }
                    break;

                case "Vinyl":
                    if(count == 10)
                    {
                        spriteRenderer.sprite = sapling;
                    }
                    else if (count == 100)
                    {
                        GameManager.UpdateHarvest(true);

                        harvest = GameManager.GetHarvest();

                        spriteRenderer.sprite = vinyl;

                        plant = false;
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

            if(tag == "Pizza")
            { 
                GameManager.UpdatePizzaSeeds(-1);
            }

            if(tag == "Milk")
            {
                GameManager.UpdateMilkSeeds(-1);
            }

            if(tag == "Vinyl")
            {
                GameManager.UpdateVinylSeeds(-1);
            }

            if(tag == "iPhone")
            { 
                GameManager.UpdateiPhoneSeeds(-1);
            }
        }
        else
        {
            dirt = transform;
        }
    }
}
