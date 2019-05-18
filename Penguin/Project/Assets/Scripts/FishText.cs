using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishText : MonoBehaviour
{
    private Text fishText;

    private void Awake()
    {
        if (fishText == null)
        {
            Text[] texts = FindObjectsOfType<Text>();

            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].tag == "FishCount")
                {
                    fishText = texts[i];
                }
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        fishText.text = GameMaster.GetFishCount().ToString();
	}
}
