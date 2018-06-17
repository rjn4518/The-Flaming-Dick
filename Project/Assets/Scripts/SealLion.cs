using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealLion : GameMaster
{
    protected override void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "PlayerSprite")
        {
            currentHealth -= 100f;  // If you run into this shit, you die
        }
    }
}
