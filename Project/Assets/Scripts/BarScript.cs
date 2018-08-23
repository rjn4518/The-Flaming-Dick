using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
	private float fillAmount;

	[SerializeField]
	private float lerpSpeed;

	[SerializeField]
	private Image Content;

	public float MaxValue { get; set; }

	public float Value
	{
		set
		{
			fillAmount = Map (value, 0, MaxValue, 0, 1);
		}
	}

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
		if (fillAmount != Content.fillAmount)
		{
			Content.fillAmount = Mathf.Lerp(Content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
			//Health fill currently on a scale from 0-1, ex. half health = 0.5
		}
	}

	private float Map (float value, float inMin, float inMax, float outMin, float outMax)
	{
		//actual health, minimum health, maximum health, outMin and outMax for fill amounts
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
		//takes health amount (e.g. 690 health) and sets it on a scale of 0-1 for fill amount
		//e.g. 80 health out of 100 total with 0 minimum, (80 - 0) * (1 - 0) / (100 - 0) + 0 = 0.8
	}
}
