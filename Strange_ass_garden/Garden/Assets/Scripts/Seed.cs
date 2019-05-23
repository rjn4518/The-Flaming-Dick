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
    private bool shittyshitshit = false;

    private int count = 0;
    private int ripeCount = 0;

    public int pizzaShit = 100;
    public int iPhoneShit = 100;
    public int milkShit = 100;
    public int vinylShit = 100;

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
    [SerializeField]
    private Sprite shit;

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

        ripeCount = Random.Range(100, 20000);
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
            GameManager.UpdatePlant(false);

            carry = GameManager.GetCarry();
            plant = GameManager.GetPlant();
        }
    }

    private void Update()
    {
        DirtPosition();

        if(harvest)
        {
            fuckface = GameManager.GetFuckFace();
        }

        Debug.Log(shittyshitshit);

        if (carry)
        {
            transform.position = dirt.position;
            spriteRenderer.sortingOrder = 3;

            carry = GameManager.GetCarry();
        }
        else if(!carry && plant)
        {
            transform.position = dirt.position;
            spriteRenderer.sortingOrder = 1;

            if(count == 0)
            {
                GameManager.UpdatePlant(false);
            }

            switch (tag)
            {
                case "Pizza":
                    if(count == 10)
                    {
                        spriteRenderer.sprite = sapling;
                    }
                    else if(count == ripeCount)
                    {
                        GameManager.UpdateHarvest(true);

                        harvest = GameManager.GetHarvest();

                        spriteRenderer.sprite = pizza;

                        //plant = false;
                    }
                    else if(count == ripeCount + pizzaShit)
                    {
                        spriteRenderer.sprite = shit;
                        shittyshitshit = true;
                        Debug.Log("shit");
                    }
                    break;

                case "Milk":
                    if(count == 10)
                    {
                        spriteRenderer.sprite = sapling;
                    }
                    else if(count == ripeCount)
                    {
                        GameManager.UpdateHarvest(true);

                        harvest = GameManager.GetHarvest();

                        spriteRenderer.sprite = milk;

                       // plant = false;
                    }
                    else if(count == ripeCount + milkShit)
                    {
                        spriteRenderer.sprite = shit;
                        shittyshitshit = true;
                    }
                    break;

                case "iPhone":
                    if(count == 10)
                    {
                        spriteRenderer.sprite = sapling;
                    }
                    else if (count == ripeCount)
                    {
                        GameManager.UpdateHarvest(true);

                        harvest = GameManager.GetHarvest();

                        spriteRenderer.sprite = iPhone;

                        //plant = false;
                    }
                    else if(count == ripeCount + iPhoneShit)
                    {
                        spriteRenderer.sprite = shit;
                        shittyshitshit = true;
                    }
                    break;

                case "Vinyl":
                    if(count == 10)
                    {
                        spriteRenderer.sprite = sapling;
                    }
                    else if (count == ripeCount)
                    {
                        GameManager.UpdateHarvest(true);

                        harvest = GameManager.GetHarvest();

                        spriteRenderer.sprite = vinyl;

                        //plant = false;
                    }
                    else if(count == ripeCount + vinylShit)
                    {
                        spriteRenderer.sprite = shit;
                        shittyshitshit = true;
                    }
                    break;

                default:
                    break;
            }

            count++;
        }

        if (fuckface)
        {
            switch (tag)
            {
                case "Pizza":
                    if(!shittyshitshit)
                    {
                        GameManager.UpdateMoney(20);
                    }
                    else
                    {
                        GameManager.UpdateMoney(-10);
                    }
                    break;

                case "Milk":
                    if(!shittyshitshit)
                    {
                        GameManager.UpdateMoney(5);
                    }
                    else
                    {
                        GameManager.UpdateMoney(-10);
                    }
                    break;

                case "iPhone":
                    if(!shittyshitshit)
                    {
                        GameManager.UpdateMoney(1000);
                    }
                    else
                    {
                        GameManager.UpdateMoney(-10);
                    }
                    break;

                case "Vinyl":
                    if(shittyshitshit)
                    {
                        GameManager.UpdateMoney(100);
                    }
                    else
                    {
                        GameManager.UpdateMoney(-10);
                    }
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
        else if(carry)
        {
            dirt = GameManager.GetCarryLocation().transform;
        }
        else
        {
            dirt = transform;
        }
    }
}
