using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    private float defaultWidth;

    // Use this for initialization
    void Start()
    {
        if (healthBar == null)
        {
            Image[] images = FindObjectsOfType<Image>();

            for (int i = 0; i < images.Length; i++)
            {
                if (images[i].tag == "HealthBar")
                {
                    healthBar = images[i];
                }
            }
        }

        defaultWidth = healthBar.rectTransform.sizeDelta.x;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.rectTransform.sizeDelta = new Vector2((GameMaster.GetCurrentHealth() / GameMaster.GetMaxHealth()) * defaultWidth, healthBar.rectTransform.sizeDelta.y);
    }
}
