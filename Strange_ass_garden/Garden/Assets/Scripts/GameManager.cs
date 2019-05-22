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

    protected static GameObject[] seeds = new GameObject[100];

    protected static int[] startingSeeds = new int[10];

    protected static int pizzaSeeds = 0;

    protected static int iPhoneSeeds = 0;

    protected static int vinylSeeds = 0;

    protected static int milkSeeds = 0;


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

    protected static GameObject carryLocation;

    protected static Transform dirt;

    protected static bool carry = false;
    protected static bool plant = false;
    protected static bool harvest = false;
    protected static bool fuckFace = false;

    protected static int money = 1;

    private void Start()
    {
        UpdateCarryLocation(GameObject.FindGameObjectWithTag("CarryLocation"));

        UpdateDirt(GameObject.FindGameObjectWithTag("Dirt").transform);
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

    public static bool GetFuckFace()
    {
        return fuckFace;
    }

    public static int GetMoney()
    {
        return money;
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

    public static void UpdateFuckFace(bool newFuckFace)
    {
        fuckFace = newFuckFace;
    }

    public static void UpdateMoney(int shit)
    {
        money += shit;
    }
}
