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

    protected static bool carry = false;

    public static bool GetCarry()
    {
        return carry;
    }

    public static void UpdateCarry(bool status)
    {
        carry = status;
    }
}
