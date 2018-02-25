/*----------------------------------------------------------------------------------------------------------------------------------------------------------------------
 * This script is the only script that inherits directly from MonoBehavior.
 * All other scripts inherit from this script.
 ---------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;  // Creates instance of GameMaster

    public GameObject player;
    public GameObject playerPrefab;
    public static GameObject spawnPoint;

    public float maxHealth = 100f;
    [HideInInspector]
    public float currentHealth;

    private void Awake()
    {
        // If any of these are null, go find that shit

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (spawnPoint == null)
        {
            spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        }

        if (gm == null)
        {
           gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameMaster>();
        }

        currentHealth = maxHealth;
    }

    void Update()
    {
        GrapplingHook();
        Death();
    }

    protected virtual void GrapplingHook()
    {
        // Defined in Abilities script
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
      // Deined in Seal Lion script
    }

    void Death()
    {
        // Kills player and spawns a new one

        if (currentHealth <= 0)
        {
            Destroy(player);
            StartCoroutine(Respawn());
            currentHealth = maxHealth;
        }
    }

    IEnumerator Respawn()
    {
        // Waits 2 seconds and then spawns new player

        yield return new WaitForSeconds(2f);

        player = Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}
