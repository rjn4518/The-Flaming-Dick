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

    protected static GameObject carryLocation;

    protected static Transform dirt;

    protected static bool carry = false;
    protected static bool plant = false;
    protected static bool harvest = false;

    private void Start()
    {
        UpdateCarryLocation(GameObject.FindGameObjectWithTag("CarryLocation"));

        UpdateDirt(GameObject.FindGameObjectWithTag("Dirt").transform);
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
