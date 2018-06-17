using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT DOESN'T WORK!!! :DDDDD

public class FallDeath : GameMaster
{ 
    public float maxFallDist = 50f;

    // Detects "Idle," respawns

    protected override void Fall()
    {
        if (playerSprite.transform.position.y <= -maxFallDist)
        {
            currentHealth -= 100f;
            Debug.Log(currentHealth);
        }
    }
}