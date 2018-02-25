using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT DOESN'T WORK!!! :DDDDD

public class fallDeath : GameMaster
{ 
    public float maxFallDist = 50f;

    // Detects "Idle," respawns

        // I tried to fix this but I might've just made it worse :'((((

    protected override void FallDeath()
    {
        if (playerSprite.transform.position.y == -maxFallDist)
        {
            currentHealth -= 100f;
            Debug.Log(currentHealth);
        }
    }
}