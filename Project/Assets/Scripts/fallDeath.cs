using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT DOESN'T WORK!!! :DDDDD

public class FallDeath : GameMaster
{
    Property property = new Property();

    public float maxFallDist = 20f;

    // Detects "Idle," respawns

    protected override void Fall()
    {
        if (playerSprite.transform.position.y <= -maxFallDist)
        {
            gm.property.CurrentHealth -= 100f;
        }
    }
}