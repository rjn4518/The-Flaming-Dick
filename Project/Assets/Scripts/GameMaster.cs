using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;

    public GameObject player;
    public GameObject playerPrefab;
    public static GameObject spawnPoint;

    public float maxHealth = 100f;
    [HideInInspector]
    public float currentHealth;

    private void Awake()
    {
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

    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
      
    }

    void Death()
    {
        if (currentHealth <= 0)
        {
            Destroy(player);
            StartCoroutine(Respawn());
            currentHealth = maxHealth;
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2f);

        player = Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}
