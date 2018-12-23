using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property
{
    private float maxHealth;
    private float currentHealth;

    private float maxStamina;
    private float currentStamina;

    private int fishCount;

    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
        }
    }

    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
        }
    }

    public float MaxStamina
    {
        get
        {
            return maxStamina;
        }
        set
        {
            maxStamina = value;
        }
    }

    public float CurrentStamina
    {
        get
        {
            return currentStamina;
        }
        set
        {
            currentStamina = value;
        }
    }

    public int FishCount
    {
        get
        {
            return fishCount;
        }
        set
        {
            fishCount = value;
        }
    }
}
