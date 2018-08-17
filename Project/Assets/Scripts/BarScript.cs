using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
	[SerializeField]
	private float fillAmount;

	[SerializeField]
	private Image Health;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		HandleBar();
	}

	private void HandleBar()
	{
		Health.fillAmount = fillAmount;
		//Health fill currently on a scale from 0-1, ex. half health = 0.5
	}
}
