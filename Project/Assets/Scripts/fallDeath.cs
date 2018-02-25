using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT DOESN'T WORK!!! :DDDDD

public class fallDeath : MonoBehaviour
{
	// Your variables from GameMaster for the player
	public GameObject player;
	public GameObject playerPrefab;
	public static GameObject spawnPoint;

	// Detects "Idle," respawns
	void OnCollisionEnter2D (Collision other)
	{
		if (other.gameObject.name == "Idle")
		{
			Respawn ();
		}
	}

	// Respawn function
	IEnumerator Respawn ()
	{
		yield return new WaitForSeconds(2f);
		player = Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
	}
}