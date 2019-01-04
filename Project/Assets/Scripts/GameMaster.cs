using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    static GameMaster instance;  // Creates instance of GameMaster

    public static GameMaster GetInstance()
    {
        return instance;
    }

    protected static float maxHealth = 100f;
    protected static float currentHealth = maxHealth;

    protected static float maxStamina = 100f;
    protected static float currentStamina = maxStamina;

    protected static int fishCount;

    protected static bool flag;

    public static float GetMaxHealth()
    {
        return maxHealth;
    }

    public static float GetCurrentHealth()
    {
        return currentHealth;
    }

    public static float GetMaxStamina()
    {
        return maxStamina;
    }

    public static float GetCurrentStamina()
    {
        return currentStamina;
    }

    public static int GetFishCount()
    {
        return fishCount;
    }

    public static bool GetFlag()
    {
        return flag;
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

    public static void UpdateHealth(float amount)
    {
        if(amount > 0f && currentHealth <= maxHealth - amount)
        {
            currentHealth += amount;
        }
        else if(amount > 0f && currentHealth > maxHealth - amount)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
            flag = true;
        }

        if(currentHealth <= 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            currentHealth = maxHealth;
            fishCount = PlayerPrefs.GetInt("fish", LevelChangerAnim.Fish());
        }
    }

    public static void UpdateStamina(float amount)
    {
        if(currentStamina <= maxStamina - amount)
        {
            currentStamina += amount;
        }
        else
        {
            currentStamina = maxStamina;
        }
    }

    public static void UpdateFish(int amount)
    {
        fishCount += amount;
    }

    public static void UpgradeHealth(float amount)
    {
        maxHealth += amount;
    }

    public static void UpgradeStamina(float amount)
    {
        maxStamina += amount;
    }

    public static void ResetFlag()
    {
        flag = false;
    }
}
