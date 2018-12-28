/*----------------------------------------------------------------------------------------------------------------------------------------------------------------------
 * This script is the only script that inherits directly from MonoBehavior.
 * All other scripts inherit from this script.
 ---------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    public static GameMaster gm;  // Creates instance of GameMaster
    public Property property = new Property();

    public GameObject player;
    public GameObject playerPrefab;
    public GameObject playerSprite;
    public GameObject playerTemp;
    public static GameObject spawnPoint;

    [HideInInspector]
    public Text fishCountText;
    [HideInInspector]
    public Image healthBar;
    [HideInInspector]
    public Image staminaBar;
    [HideInInspector]
    public Camera mainCamera;

    private float defaultWidth;

    private void Awake()
    {
        // If any of these are null, go find that shit

        if (gm == null)
        {
           gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameMaster>();
        }

        if (mainCamera == null)
        {
            Camera[] cameras = FindObjectsOfType<Camera>();

            for(int i = 0; i < cameras.Length; i++)
            {
                if(cameras[i].tag == "MainCamera")
                {
                    mainCamera = cameras[i];
                }
            }
        }

        if (spawnPoint == null)
        {
            spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        }

        if (fishCountText == null)
        {
            Text[] texts = FindObjectsOfType<Text>();

            for(int i = 0; i < texts.Length; i++)
            {
                if(texts[i].tag == "FishCount")
                {
                    fishCountText = texts[i];
                }
            }
        }

        if (healthBar == null)
        {
            Image[] images = FindObjectsOfType<Image>();

            for(int i = 0; i < images.Length; i++)
            {
                if(images[i].tag == "HealthBar")
                {
                    healthBar = images[i];
                }
            }

        }

        if (staminaBar == null)
        {
            Image[] images = FindObjectsOfType<Image>();

            for (int i = 0; i < images.Length; i++)
            {
                if (images[i].tag == "StaminaBar")
                {
                    staminaBar = images[i];
                }
            }

        }

        defaultWidth = staminaBar.rectTransform.sizeDelta.x;
        gm.property.MaxHealth = 100f;
        gm.property.MaxStamina = 100f;
        gm.property.CurrentHealth = gm.property.MaxHealth;
        gm.property.CurrentStamina = gm.property.MaxStamina;
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (playerSprite == null)
        {
            playerSprite = GameObject.FindGameObjectWithTag("PlayerSprite");
        }

        Fall();

        healthBar.rectTransform.sizeDelta = new Vector2((gm.property.CurrentHealth / gm.property.MaxHealth) * defaultWidth, healthBar.rectTransform.sizeDelta.y);
        staminaBar.rectTransform.sizeDelta = new Vector2((gm.property.CurrentStamina / gm.property.MaxStamina) * defaultWidth, staminaBar.rectTransform.sizeDelta.y);

        if (gm.property.CurrentHealth <= 0)
        {
            Death();
        }
    }

    protected virtual void GrapplingHook()
    {
        // Defined in Abilities script
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        // Defined in Seal Lion script
    }

    protected virtual void Fall()
    {

    }

    void Death()
    {
        // Kills player and spawns a new one

        Destroy(player);
        player = Instantiate(playerTemp, spawnPoint.transform.position, Quaternion.identity);
        StartCoroutine(Respawn());
        gm.property.CurrentHealth = gm.property.MaxHealth;
        Debug.Log("Kill that bitch");
    }

    IEnumerator Respawn()
    {
        // Waits 2 seconds and then spawns new player

        yield return new WaitForSeconds(2f);

        Destroy(player);
        player = Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
    }

    protected virtual void Damage()
    {

    }
}
