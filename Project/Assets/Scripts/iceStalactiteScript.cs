using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceStalactiteScript : GameMaster
{
	protected override void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Idle")
		{
			currentHealth -= 20f;
			Debug.Log(currentHealth);
		}
	}
}