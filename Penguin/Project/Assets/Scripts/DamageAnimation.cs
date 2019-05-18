using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAnimation : MonoBehaviour
{
    private GameObject playerSprite;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        playerSprite = GameObject.FindGameObjectWithTag("PlayerSprite");
        spriteRenderer = playerSprite.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(GameMaster.GetFlag())
        {
            StartCoroutine(Damage());
            GameMaster.ResetFlag();
        }
    }

    private IEnumerator Damage()
    {
        for(int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
        }
    }
}
