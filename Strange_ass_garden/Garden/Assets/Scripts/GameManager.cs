using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public GameObject[] publicSeeds;

    protected static GameObject[] seeds = new GameObject[100];

    protected static int[] startingSeeds = new int[10];

    protected static int pizzaSeeds = 0;

    protected static int iPhoneSeeds = 0;

    protected static int vinylSeeds = 0;

    protected static int milkSeeds = 0;

    protected static int humanSeeds = 0;

    protected static GameObject carryLocation;

    protected static Transform dirt;

    protected static bool carry = false;
    protected static bool plant = false;
    protected static bool harvest = false;

    private void Start()
    {
        UpdateCarryLocation(GameObject.FindGameObjectWithTag("CarryLocation"));

        UpdateDirt(GameObject.FindGameObjectWithTag("Dirt").transform);


        //Move to Awake
        for(int i=0; i<100; i++)
        {
            if(i < publicSeeds.Length)
            {
                UpdateSeeds(i, publicSeeds[i]);
            }
            else
            {
                UpdateSeeds(i, publicSeeds[0]);
            }
        }

        for(int j=0; j<10; j++)
        {
            float random = Random.Range(1f, seeds.Length + 1);

            if(random == publicSeeds.Length + 1f)
            {
                random = publicSeeds.Length;
            }

            UpdateStartingSeeds(j, (int)random);
            Debug.Log(startingSeeds);
        }

        for(int k=0; k<10; k++)
        {
            switch(GetStartingSeeds(k))
            {
                case 1:
                    UpdatePizzaSeeds(1);
                    break;

                case 2:
                    UpdateiPhoneSeeds(1);
                    break;

                case 3:
                    UpdateVinylSeeds(1);
                    break;

                case 4:
                    UpdateMilkSeeds(1);
                    break;

                case 5:
                    UpdateHumanSeeds(1);
                    break;

                default:
                    break;
            }
        }
    }

    public static GameObject GetSeeds(int i)
    {
        return seeds[i];
    }

    public static int GetStartingSeeds(int i)
    {
        return startingSeeds[i];
    }

    public static int GetPizzaSeeds()
    {
        return pizzaSeeds;
    }

    public static int GetiPhoneSeeds()
    {
        return iPhoneSeeds;
    }

    public static int GetVinylSeeds()
    {
        return vinylSeeds;
    }

    public static int GetMilkSeeds()
    {
        return milkSeeds;
    }

    public static int GetHumanSeeds()
    {
        return humanSeeds;
    }

    public static GameObject GetCarryLocation()
    {
        return carryLocation;
    }

    public static Transform GetDirt()
    {
        return dirt;
    }

    public static bool GetCarry()
    {
        return carry;
    }

    public static bool GetPlant()
    {
        return plant;
    }

    public static bool GetHarvest()
    {
        return harvest;
    }

    public static void UpdateSeeds(int i, GameObject j)
    {
        seeds[i] = j;
    }

    public static void UpdateStartingSeeds(int i, int num)
    {
        startingSeeds[i] = num;
    }

    public static void UpdatePizzaSeeds(int p)
    {
        pizzaSeeds += p;
    }

    public static void UpdateiPhoneSeeds(int i)
    {
        iPhoneSeeds += i;
    }

    public static void UpdateVinylSeeds(int v)
    {
        vinylSeeds += v;
    }

    public static void UpdateMilkSeeds(int m)
    {
        milkSeeds += m;
    }

    public static void UpdateHumanSeeds(int h)
    {
        humanSeeds += h;
    }

    public static void UpdateCarryLocation(GameObject newLocation)
    {
        carryLocation = newLocation;
    }

    public static void UpdateDirt(Transform newDirt)
    {
        dirt = newDirt;
    }

    public static void UpdateCarry(bool newCarry)
    {
        carry = newCarry;
    }

    public static void UpdatePlant(bool newPlant)
    {
        plant = newPlant;
    }

    public static void UpdateHarvest(bool newHarvest)
    {
        harvest = newHarvest;
    }
}
