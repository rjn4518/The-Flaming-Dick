using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlippyObstacle : MonoBehaviour
{
    private static float damage;

    private void Damage()
    {
        switch(tag)
        {
            case "Puddle":
                damage = -50f;
                break;

            case "SealLion":
                damage = -20f;
                break;

            case "Icicle":
                damage = -10f;
                break;

            case "Trash":
                damage = -25f;
                break;

            case "TrashCan":
                damage = -15f;
                break;

            default:
                damage = -20f;
                break;

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerSprite")
        {
            Damage();
            GameMaster.UpdateHealth(damage);
        }
    }
}
