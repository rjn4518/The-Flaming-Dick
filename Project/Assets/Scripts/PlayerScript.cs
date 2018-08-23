using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I wasn't entirely sure exactly what the Player script did because I know jackshit about C#, 
//so I made another PlayerScript solely for health and stamina

public class PlayerScript : MonoBehaviour
{
	[SerializeField]
	private Stat health;

	[SerializeField]
	private Stat stamina;

	private void Awake ()
	{
		health.Initialize ();
		stamina.Initialize ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Q))
		{
			health.CurrentVal -= 10;
		}
		if (Input.GetKeyDown (KeyCode.W))
		{
			health.CurrentVal += 10;
		}

		if (Input.GetKeyDown (KeyCode.Z))
		{
			stamina.CurrentVal -= 10;
		}
		if (Input.GetKeyDown (KeyCode.X))
		{
			stamina.CurrentVal += 10;
		}
	}
}
