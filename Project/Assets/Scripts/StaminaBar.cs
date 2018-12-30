using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private Image staminaBar;
    private float defaultWidth;

	// Use this for initialization
	void Start ()
    {
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
    }
	
	// Update is called once per frame
	void Update ()
    {
        staminaBar.rectTransform.sizeDelta = new Vector2((GameMaster.GetCurrentStamina() / GameMaster.GetMaxStamina()) * defaultWidth, staminaBar.rectTransform.sizeDelta.y);
    }
}
