using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT DOESN'T WORK!!! :DDDDD

public class FallDeath : MonoBehaviour
{
    private static float startYPosition;
    public float maxFallDist = 20f;

    // Detects "Idle," respawns

    private void Start()
    {
        startYPosition = transform.position.y;
    }

    void Update()
    {
        if (transform.position.y <= startYPosition - maxFallDist)
        {
            GameMaster.UpdateHealth(-GameMaster.GetMaxHealth());
        }
    }
}